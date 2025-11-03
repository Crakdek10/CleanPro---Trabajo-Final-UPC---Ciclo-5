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
    /// Interaction logic for UCAdministradorDashboard.xaml
    /// </summary>
    public partial class UCAdministradorDashboard : UserControl
    {
        private NReserva nReserva = new NReserva();

        public UCAdministradorDashboard()
        {
            InitializeComponent();
            MostrarReservas(nReserva.ListarReservas());
        }

        private void UCAdministradorDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            int añoActual = 2025;

            var datos1 = nReserva.DistribucionReservasxEstadoxYear(añoActual);
            var grafico1 = new UCAdministradorDistribucionReservasxEstadoxAño(datos1);
            graficoContainer1.Content = grafico1;

            var datos2 = nReserva.CantidadReservasTop10Provincia(añoActual);
            var grafico2 = new UCAdministradorReportesCantidadReservasProvinciaxAño(datos2);
            graficoContainer2.Content = grafico2;
        }

        private void MostrarReservas(List<Reserva> reservas)
        {
            lsbReservas.ItemsSource = null;

            if (reservas.Count == 0)
            {
                return;
            }
            else
            {
                var ultimasReservas = nReserva.ListarReservas().OrderByDescending(r => r.ReservaFechaProgramada).Take(3).ToList();
                lsbReservas.ItemsSource = ultimasReservas;
            }
        }
    }
}
