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

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WindowAdministradorPanel.xaml
    /// </summary>
    public partial class WindowAdministradorPanel : Window
    {
        private String administradorNombre;
        public WindowAdministradorPanel(String nombre)
        {
            InitializeComponent();
            this.administradorNombre = nombre;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            btnDashboard(null, null);
            tbAdministradorNombre.Text = administradorNombre;
        }

        private void btnDashboard(object sender, RoutedEventArgs e)
        {
            UCAdministradorDashboard uCAdministradorDashboard = new UCAdministradorDashboard();
            MainContentArea.Content = uCAdministradorDashboard;
        }

        private void btnCleaners(object sender, RoutedEventArgs e)
        {
            UCAdministradorCleaners ucCleaners = new UCAdministradorCleaners();
            ucCleaners.AñadirCleaner += AdministradorPanel_AñadirCleaner;

            MainContentArea.Content = ucCleaners;
        }

        private void AdministradorPanel_AñadirCleaner(object sender, RoutedEventArgs e)
        {
            UCAdministradorCleanersAgregarCleaners ucAddCleaner = new UCAdministradorCleanersAgregarCleaners();
            ucAddCleaner.VolverUCAdministradorCleaners += AdministradorPanel_VolverCleaners;

            MainContentArea.Content = ucAddCleaner;
        }

        private void AdministradorPanel_VolverCleaners(object sender, RoutedEventArgs e)
        {
            btnCleaners(null, null);
        }

        private void btnReservas(object sender, RoutedEventArgs e)
        {
            UCAdministradorReservas ucReservas = new UCAdministradorReservas();
            ucReservas.AñadirReservas += AdministradorPanel_AñadirReserva;
            MainContentArea.Content = ucReservas;
        }

        private void AdministradorPanel_AñadirReserva(object sender, RoutedEventArgs e)
        {
            UCAdministradorReservasAgregarReservas ucAddReserva = new UCAdministradorReservasAgregarReservas();
            ucAddReserva.VolverUCAdministradorReservas += AdministradorPanel_VolverReservas;

            MainContentArea.Content = ucAddReserva;
        }

        private void AdministradorPanel_VolverReservas(object sender, RoutedEventArgs e)
        {
            btnReservas(null, null);
        }

        private void btnReportes(object sender, RoutedEventArgs e)
        {
            UCAdministradorReportes uCAdministradorReportes = new UCAdministradorReportes();
            MainContentArea.Content = uCAdministradorReportes;
        }

        private void btnSalir(object sender, RoutedEventArgs e)
        {
            WindowInicio windowInicio = new WindowInicio();
            windowInicio.Show();
            this.Close();
        }
    }
}
