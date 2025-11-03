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
    /// Interaction logic for UCAdministradorCleanersAgregarCleaners.xaml
    /// </summary>
    public partial class UCAdministradorCleanersAgregarCleaners : UserControl
    {
        private NCleaner ncleaner = new NCleaner();
        public event RoutedEventHandler VolverUCAdministradorCleaners;
        private byte[] datosFotoSeleccionada;

        public UCAdministradorCleanersAgregarCleaners()
        {
            InitializeComponent();
        }

        private void btnAgregar(object sender, RoutedEventArgs e)
        {
            if (tbDNICleaner.Text == "" || tbNombreCleaner.Text == "" || tbNumeroCelCleaner.Text == "" || dpFechaNacimiento.SelectedDate == null || cbProvincia.SelectedItem == null || cbSexo.SelectedItem == null || pbContrasena.Password == "")
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbDNICleaner.Text.Length != 8 || !tbDNICleaner.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe ser un número de 8 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbNumeroCelCleaner.Text.Length != 9)
            {
                MessageBox.Show("El Número celular debe ser de 9 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Cleaner cleaner = new Cleaner()
            {
                CleanerDNI = tbDNICleaner.Text,
                CleanerNombre = tbNombreCleaner.Text,
                CleanerNumero = tbNumeroCelCleaner.Text,
                CleanerFechaNacimiento = dpFechaNacimiento.SelectedDate.Value,
                CleanerProvincia = (cbProvincia.SelectedItem as ComboBoxItem).Content.ToString(),
                CleanerSexo = (cbSexo.SelectedItem as ComboBoxItem).Content.ToString(),
                CleanerContrasena = pbContrasena.Password,
                CleanerEstado = "Activo",
                CleanerFoto = datosFotoSeleccionada,
                CleanerSueldo = 0
            };

            String mensaje = ncleaner.Registrar(cleaner);
            MessageBox.Show(mensaje);

            VolverUCAdministradorCleaners?.Invoke(this, e);
        }

        private void btnSeleccionarFoto(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Archivos de Imagen (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    datosFotoSeleccionada = File.ReadAllBytes(openFileDialog.FileName);

                    BitmapImage bitmap = new BitmapImage();
                    using (MemoryStream stream = new MemoryStream(datosFotoSeleccionada))
                    {
                        stream.Position = 0;
                        bitmap.BeginInit();
                        bitmap.StreamSource = stream;
                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();
                    }
                    imgFotoCleaner.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                    datosFotoSeleccionada = null;
                }
            }
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            VolverUCAdministradorCleaners?.Invoke(this, e);
        }

    }
}
