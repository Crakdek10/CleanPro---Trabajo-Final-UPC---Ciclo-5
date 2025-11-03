using Datos;
using Presentacion.UserControls;
using System;
using System.Collections.Generic;
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
using System.Windows.Interop;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WindowCleanerPanel.xaml
    /// </summary>
    public partial class WindowCleanerPanel : Window
    {
        private Cleaner cleanerlogueado;

        public WindowCleanerPanel(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerlogueado = cleaner;
            ActualizarNombreCleaner();
        }

        private void ActualizarNombreCleaner()
        {
            tbCleanerNombre.Text = cleanerlogueado.CleanerNombre;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnDashboard(null, null);
        }

        private void btnDashboard(object sender, RoutedEventArgs e)
        {
            ActualizarNombreCleaner();

            UCCleanerDashboard uCCleanerDashboard = new UCCleanerDashboard(cleanerlogueado);
            MainContentArea.Content = uCCleanerDashboard;
        }

        private void btnHistorial(object sender, RoutedEventArgs e)
        {
            ActualizarNombreCleaner();

            UCCleanerHistorial uCCleanerHistorial = new UCCleanerHistorial(cleanerlogueado);
            MainContentArea.Content = uCCleanerHistorial;
        }

        private void btnInformes(object sender, RoutedEventArgs e)
        {
            ActualizarNombreCleaner();

            UCCleanerInformes uCCleanerInformes = new UCCleanerInformes(cleanerlogueado);
            MainContentArea.Content = uCCleanerInformes;
        }

        private void btnInformacionPersonal(object sender, RoutedEventArgs e)
        {
            UCCleanerInformacionPersonal uCCleanerInformacionPersonal = new UCCleanerInformacionPersonal(cleanerlogueado);
            MainContentArea.Content = uCCleanerInformacionPersonal;
        }

        private void btnSalir(object sender, RoutedEventArgs e)
        {
            WindowInicio windowInicio = new WindowInicio();
            windowInicio.Show();
            this.Close();
        }
    }
}
