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
    /// Interaction logic for WindowInicio.xaml
    /// </summary>
    public partial class WindowInicio : Window
    {
        public WindowInicio()
        {
            InitializeComponent();
        }

        private void btnIngresarAdministrador(object sender, RoutedEventArgs e)
        {
            WindowAdministradorLogin windowAdministradorLogin = new WindowAdministradorLogin();
            windowAdministradorLogin.Show();
            this.Close();
        }

        private void btnIngresarCleaner(object sender, RoutedEventArgs e)
        {
            WindowCleanerLogin windowCleanerLogin = new WindowCleanerLogin();
            windowCleanerLogin.Show();
            this.Close();
        }

        private void btnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
