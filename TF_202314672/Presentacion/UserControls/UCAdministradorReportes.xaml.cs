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
    /// Interaction logic for UCAdministradorReportes.xaml
    /// </summary>
    public partial class UCAdministradorReportes : UserControl
    {
        private NReserva nReserva = new NReserva();

        public UCAdministradorReportes()
        {
            InitializeComponent();
        }

        private void UCAdministradorReportes_Loaded(object sender, RoutedEventArgs e)
        {
            cbAñoReporte1.SelectedIndex = 0;
            cbAñoReporte2.SelectedIndex = 0;
            cbAñoReporte3.SelectedIndex = 0;
            cbAñoReporte4.SelectedIndex = 0;
            cbAñoReporte5.SelectedIndex = 0;
            cbAñoReporte6.SelectedIndex = 0;

            CargarReporte1(DateTime.Now.Year);
            CargarReporte2(DateTime.Now.Year);
            CargarReporte3(DateTime.Now.Year);
            CargarReporte4(DateTime.Now.Year);
            CargarReporte5(DateTime.Now.Year);
            CargarReporte6(DateTime.Now.Year);
        }

        private void SelectionChangedAño1(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte1.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte1(yearSeleccionado);
            }
        }

        private void SelectionChangedAño2(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte2.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte2(yearSeleccionado);
            }
        }

        private void SelectionChangedAño3(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte3.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte3(yearSeleccionado);
            }
        }

        private void SelectionChangedAño4(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte4.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte4(yearSeleccionado);
            }
        }

        private void SelectionChangedAño5(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte5.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte5(yearSeleccionado);
            }
        }

        private void SelectionChangedAño6(object sender, SelectionChangedEventArgs e)
        {
            if (cbAñoReporte6.SelectedItem is ComboBoxItem item)
            {
                int yearSeleccionado = int.Parse(item.Content.ToString());
                CargarReporte6(yearSeleccionado);
            }
        }

        private void CargarReporte1(int year)
        {
            var datos = nReserva.VolumenReservasxMesxYear(year);
            dgReporte1.ItemsSource = datos;
            UCAdministradorReportesVolumenReservasxMesxAño grafico = new UCAdministradorReportesVolumenReservasxMesxAño(datos);
            graficoContainer1.Content = grafico;
        }

        private void CargarReporte2(int year)
        {
            var datos = nReserva.DistribucionReservasxEstadoxYear(year);
            dgReporte2.ItemsSource = datos;
            UCAdministradorDistribucionReservasxEstadoxAño grafico = new UCAdministradorDistribucionReservasxEstadoxAño(datos);
            graficoContainer2.Content = grafico;
        }

        private void CargarReporte3(int year)
        {
            var datos = nReserva.PopularidadReservasPorTipoServicio(year);
            dgReporte3.ItemsSource = datos;
            UCAdministradorReportesPopularidadTipoServicioxAño grafico = new UCAdministradorReportesPopularidadTipoServicioxAño(datos);
            graficoContainer3.Content = grafico;
        }

        private void CargarReporte4(int year)
        {
            var datos = nReserva.CantidadReservasTop10Provincia(year);
            dgReporte4.ItemsSource = datos;
            UCAdministradorReportesCantidadReservasProvinciaxAño grafico = new UCAdministradorReportesCantidadReservasProvinciaxAño(datos);
            graficoContainer4.Content = grafico;
        }

        private void CargarReporte5(int year)
        {
            var datos = nReserva.RankingCleanersxYear(year);
            dgReporte5.ItemsSource = datos;
            UCAdministradorReportesRankingCleaners grafico = new UCAdministradorReportesRankingCleaners(datos);
            graficoContainer5.Content = grafico;
        }

        private void CargarReporte6(int year)
        {
            var datos = nReserva.CargaCleanersxYear(year);
            dgReporte6.ItemsSource = datos;
            UCAdministradorReportesCargaCleaners grafico = new UCAdministradorReportesCargaCleaners(datos);
            graficoContainer6.Content = grafico; 
        }
    }
}
