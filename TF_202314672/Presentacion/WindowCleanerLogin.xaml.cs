using Datos;
using Negocio;
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
    /// Interaction logic for WindowCleanerLogin.xaml
    /// </summary>
    public partial class WindowCleanerLogin : Window
    {
        private NCleaner nCleaner = new NCleaner();

        public WindowCleanerLogin()
        {
            InitializeComponent();
        }

        private void TogglePassword_Click(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Visibility == Visibility.Visible)
            {
                tbPassword.Visibility = Visibility.Collapsed;
                tbVisiblePassword.Visibility = Visibility.Visible;
                tbVisiblePassword.Text = tbPassword.Password;
                tbVisiblePassword.Focus();
                iconPassword.Text = "\xED1A";
            }
            else
            {
                tbPassword.Visibility = Visibility.Visible;
                tbVisiblePassword.Visibility = Visibility.Collapsed;
                tbPassword.Password = tbVisiblePassword.Text;
                tbPassword.Focus();
                iconPassword.Text = "\uE890";
            }
        }

        private void btnAccederLoginCleaner(object sender, RoutedEventArgs e)
        {
            String dni = tbDNI.Text.Trim().ToUpper();
            String contrasena;

            if (tbPassword.Visibility == Visibility.Visible)
                contrasena = tbPassword.Password;
            else
                contrasena = tbVisiblePassword.Text;

            Cleaner cleaner = nCleaner.Login(dni, contrasena);

            if (cleaner != null)
            {
                WindowCleanerPanel windowCleanerPanel = new WindowCleanerPanel(cleaner);
                windowCleanerPanel.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nombre o contraseña incorrectos.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnVolverLoginCleaner(object sender, RoutedEventArgs e)
        {
            WindowInicio windowInicio = new WindowInicio();
            windowInicio.Show();
            this.Close();
        }
    }
}
