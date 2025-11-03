using Datos;
using Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WindowAdministradorCleanersInformacion.xaml
    /// </summary>
    public partial class WindowAdministradorCleanersInformacion : Window
    {
        private Cleaner cleanerSeleccionado;
        private NCleaner nCleaner = new NCleaner();
        private byte[] datosNuevaFoto = null;

        public WindowAdministradorCleanersInformacion(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerSeleccionado = cleaner;
            MostrarInformacion();
        }

        private void CargarImagenDesdeBytes(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                try
                {
                    BitmapImage bitmap = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        stream.Position = 0;
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                    }
                    imgFotoCleaner.ImageSource = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al interpretar los datos de la imagen: " + ex.Message);
                }
            }
        }

        private void MostrarInformacion()
        {
            string provinciaGuardada = cleanerSeleccionado.CleanerProvincia;
            var itemProvincia = cbProvinciaCleaner.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == provinciaGuardada);

            string sexoGuardado = cleanerSeleccionado.CleanerSexo;
            var itemSexo = cbSexoCleaner.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == sexoGuardado);

            string estadoGuardado = cleanerSeleccionado.CleanerEstado;
            var itemEstado = cbEstado.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == estadoGuardado);


            tbDNICleaner.Text = cleanerSeleccionado.CleanerDNI;
            tbNombreCleaner.Text = cleanerSeleccionado.CleanerNombre;
            tbNumeroCelCleaner.Text = cleanerSeleccionado.CleanerNumero;
            dpFechaNacimiento.SelectedDate = cleanerSeleccionado.CleanerFechaNacimiento;
            cbProvinciaCleaner.SelectedItem = itemProvincia;
            cbSexoCleaner.SelectedItem = itemSexo;
            cbEstado.SelectedItem = itemEstado;
            tbSueldo.Text = cleanerSeleccionado.CleanerSueldo.ToString("C");
            CargarImagenDesdeBytes(cleanerSeleccionado.CleanerFoto);
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            imgFoto.Cursor = Cursors.Hand;
            tbNombreCleaner.IsReadOnly = false;
            tbNumeroCelCleaner.IsReadOnly = false;
            dpFechaNacimiento.IsEnabled = true;
            cbProvinciaCleaner.IsEnabled = true;
            cbSexoCleaner.IsEnabled = true;
            cbEstado.IsEnabled = true;

            btn_Guardar.IsEnabled = true;
            btn_Editar.IsEnabled = false;
            tbNombreCleaner.Focus();
        }

        private void btnSeleccionarFoto(object sender, RoutedEventArgs e)
        {
            if (btn_Guardar.IsEnabled == false)
            {
                return;
            }

            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                datosNuevaFoto = File.ReadAllBytes(openFileDialog.FileName);
                CargarImagenDesdeBytes(datosNuevaFoto);
            }
        }

        private void btnGuardar(object sender, RoutedEventArgs e)
        {
            if (tbNombreCleaner.Text == "" || tbNumeroCelCleaner.Text == "" || dpFechaNacimiento.SelectedDate == null || cbProvinciaCleaner.SelectedItem == null || cbSexoCleaner.SelectedItem == null || cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbNumeroCelCleaner.Text.Length != 9)
            {
                MessageBox.Show("El Número celular debe ser de 9 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            cleanerSeleccionado.CleanerNombre = tbNombreCleaner.Text;
            cleanerSeleccionado.CleanerNumero = tbNumeroCelCleaner.Text;
            cleanerSeleccionado.CleanerFechaNacimiento = dpFechaNacimiento.SelectedDate.Value;
            cleanerSeleccionado.CleanerProvincia = (cbProvinciaCleaner.SelectedItem as ComboBoxItem).Content.ToString();
            cleanerSeleccionado.CleanerSexo = (cbSexoCleaner.SelectedItem as ComboBoxItem).Content.ToString();
            cleanerSeleccionado.CleanerEstado = (cbEstado.SelectedItem as ComboBoxItem).Content.ToString();

            if (datosNuevaFoto != null)
            {
                cleanerSeleccionado.CleanerFoto = datosNuevaFoto;
            }

            String mensaje = nCleaner.Modificar(cleanerSeleccionado);
            MessageBox.Show(mensaje);

            tbNombreCleaner.IsReadOnly = true;
            tbNumeroCelCleaner.IsReadOnly = true;
            dpFechaNacimiento.IsEnabled = false;
            cbProvinciaCleaner.IsEnabled = false;
            cbSexoCleaner.IsEnabled = false;
            cbEstado.IsEnabled = false;
            imgFoto.Cursor = null;

            btn_Guardar.IsEnabled = false;
            btn_Editar.IsEnabled = true;
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
