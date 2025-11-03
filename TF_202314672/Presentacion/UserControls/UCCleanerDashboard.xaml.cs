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
    /// Interaction logic for UCCleanerDashboard.xaml
    /// </summary>
    public partial class UCCleanerDashboard : UserControl
    {
        private Cleaner cleanerlogueado;
        private NReserva nReserva = new NReserva();

        public UCCleanerDashboard(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerlogueado = cleaner;
        }

        private async void UCCleanerDashboard_Loaded(object sender, RoutedEventArgs e)
        {
            MostrarReservas(nReserva.ListarReservasxCleaner(cleanerlogueado.CleanerDNI));

            await mapaBrowser.EnsureCoreWebView2Async();

            string url = "https://www.google.com/maps/@-12.0464,-77.0428,15z";
            mapaBrowser.CoreWebView2.Navigate(url);
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
                lsbReservas.ItemsSource = reservas.Where(r => r.ReservaEstado != "Cancelado" && r.ReservaEstado != "Completado").OrderByDescending(r => r.ReservaFechaProgramada).Take(3).ToList();
            }
        }
    }
}
