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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.UserControls
{
    /// <summary>
    /// Interaction logic for UCCleanerInformacionPersonal.xaml
    /// </summary>
    public partial class UCCleanerInformacionPersonal : UserControl
    {
        private Cleaner cleanerlogueado;
        private NCleaner nCleaner = new NCleaner();
        private byte[] datosNuevaFoto = null;

        public UCCleanerInformacionPersonal(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerlogueado = cleaner;
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
            string provinciaGuardada = cleanerlogueado.CleanerProvincia;
            var itemProvincia = cbProvinciaCleaner.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == provinciaGuardada);

            string sexoGuardado = cleanerlogueado.CleanerSexo;
            var itemSexo = cbSexoCleaner.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == sexoGuardado);


            tbDNICleaner.Text = cleanerlogueado.CleanerDNI;
            tbNombreCleaner.Text = cleanerlogueado.CleanerNombre;
            tbNumeroCelCleaner.Text = cleanerlogueado.CleanerNumero;
            dpFechaNacimiento.SelectedDate = cleanerlogueado.CleanerFechaNacimiento;
            cbProvinciaCleaner.SelectedItem = itemProvincia;
            cbSexoCleaner.SelectedItem = itemSexo;
            CargarImagenDesdeBytes(cleanerlogueado.CleanerFoto);
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            tbNombreCleaner.IsReadOnly = false;
            tbNumeroCelCleaner.IsReadOnly = false;
            dpFechaNacimiento.IsEnabled = true;
            cbProvinciaCleaner.IsEnabled = true;
            cbSexoCleaner.IsEnabled = true;

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
            if (tbNombreCleaner.Text == "" || tbNumeroCelCleaner.Text == "" || dpFechaNacimiento.SelectedDate == null || cbProvinciaCleaner.SelectedItem == null || cbSexoCleaner.SelectedItem == null)
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbNumeroCelCleaner.Text.Length != 9)
            {
                MessageBox.Show("El Número celular debe ser de 9 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            cleanerlogueado.CleanerNombre = tbNombreCleaner.Text;
            cleanerlogueado.CleanerNumero = tbNumeroCelCleaner.Text;
            cleanerlogueado.CleanerFechaNacimiento = dpFechaNacimiento.SelectedDate.Value;
            cleanerlogueado.CleanerProvincia = (cbProvinciaCleaner.SelectedItem as ComboBoxItem).Content.ToString();
            cleanerlogueado.CleanerSexo = (cbSexoCleaner.SelectedItem as ComboBoxItem).Content.ToString();

            if (datosNuevaFoto != null)
            {
                cleanerlogueado.CleanerFoto = datosNuevaFoto;
            }

            String mensaje = nCleaner.Modificar(cleanerlogueado);
            MessageBox.Show(mensaje);

            tbNombreCleaner.IsReadOnly = true;
            tbNumeroCelCleaner.IsReadOnly = true;
            dpFechaNacimiento.IsEnabled = false;
            cbProvinciaCleaner.IsEnabled = false;
            cbSexoCleaner.IsEnabled = false;

            btn_Guardar.IsEnabled = false;
            btn_Editar.IsEnabled = true;
        }
    }
}
