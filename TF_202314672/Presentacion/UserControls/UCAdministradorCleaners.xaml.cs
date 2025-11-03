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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.UserControls
{
    /// <summary>
    /// Interaction logic for UCAdministradorCleaners.xaml
    /// </summary>
    public partial class UCAdministradorCleaners : UserControl
    {
        private NCleaner nCleaner = new NCleaner();
        public event RoutedEventHandler AñadirCleaner;

        public UCAdministradorCleaners()
        {
            InitializeComponent();
            cbEstado.SelectedIndex = 0;
            cbProvincia.SelectedIndex = 0;
            MostrarCleaners(nCleaner.ListarCleaners());
        }

        private void MostrarCleaners(List<Cleaner> cleaners)
        {
            lsbCleaners.ItemsSource = null;

            if (cleaners.Count == 0)
            {
                return;
            }
            else
            {
                lsbCleaners.ItemsSource = cleaners;
                tbContadorCleaners.Text = cleaners.Count().ToString();
            }
        }

        private void AplicarFiltros()
        {
            String nombre = tbSearch.Text;
            String estado = (cbEstado.SelectedItem as ComboBoxItem)?.Content.ToString();
            String provincia = (cbProvincia.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (nombre != "" && estado == "Todos" && provincia == "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerxNombre(nombre));
            }
            else if (nombre == "" && estado != "Todos" && provincia == "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerxEstado(estado));
            }
            else if (nombre == "" && estado == "Todos" && provincia != "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerxProvincia(provincia));
            }
            else if (nombre != "" && estado != "Todos" && provincia == "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerNombrexEstado(nombre, estado));
            }
            else if (nombre != "" && estado == "Todos" && provincia != "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerNombrexProvincia(nombre, provincia));
            }
            else if (nombre == "" && estado != "Todos" && provincia != "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerEstadoxProvincia(estado, provincia));
            }
            else if (nombre != "" && estado != "Todos" && provincia != "Todos")
            {
                MostrarCleaners(nCleaner.ListarCleanerMultiple(nombre, estado, provincia));
            }
            else
            {
                MostrarCleaners(nCleaner.ListarCleaners());
            }
        }

        private void btnAgregarCleaner(object sender, RoutedEventArgs e)
        {
            AñadirCleaner?.Invoke(this, e);
        }

        private void txtChangedBuscarNombre(object sender, TextChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void SelectionChangedEstado(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void SelectionChangedProvincia(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void DoubleClickListBox(object sender, MouseButtonEventArgs e)
        {
            Cleaner cleanerSeleccionado = lsbCleaners.SelectedItem as Cleaner;

            if (cleanerSeleccionado != null)
            {
                WindowAdministradorCleanersInformacion windowAdministradorCleanersInformacion = new WindowAdministradorCleanersInformacion(cleanerSeleccionado);
                windowAdministradorCleanersInformacion.ShowDialog();
                MostrarCleaners(nCleaner.ListarCleaners());
            }
        }
    }
}
