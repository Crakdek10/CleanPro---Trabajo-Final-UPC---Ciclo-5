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
    /// Interaction logic for UCCleanerHistorial.xaml
    /// </summary>
    public partial class UCCleanerHistorial : UserControl
    {
        private NReserva nReserva = new NReserva();
        private NServicio nServicio = new NServicio();
        private Cleaner cleanerlogueado;

        public UCCleanerHistorial(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerlogueado = cleaner;
            cbEstado.SelectedIndex = 0;
            cbTipoServicio.SelectedIndex = 0;

            MostrarReservas(nReserva.ListarReservasxCleaner(cleanerlogueado.CleanerDNI));
        }

        private void MostrarReservas(List<Reserva> reservas)
        {
            lsbReservas.ItemsSource = null;

            if (reservas.Count == 0)
            {
                tbContadorReservas.Text = "0";
                return;
            }
            else
            {
                lsbReservas.ItemsSource = reservas.Where(r => r.ReservaEstado != "Cancelado").ToList();
                tbContadorReservas.Text = reservas.Where(r => r.ReservaEstado != "Cancelado").Count().ToString();
            }
        }

        private void AplicarFiltros()
        {
            DateTime? fechaInicio = dpFechaInicio.SelectedDate;
            DateTime? fechaFin = dpFechaFinal.SelectedDate;
            string estado = (cbEstado.SelectedItem as ComboBoxItem)?.Content.ToString();
            string nombreServicio = (cbTipoServicio.SelectedItem as ComboBoxItem)?.Content.ToString();
            int tipoServicio = nServicio.ObtenerServicioIdPorNombre(nombreServicio);


            if (fechaInicio != null && fechaFin != null && estado == "Todos" && nombreServicio == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxRangoFechasxCleaner(cleanerlogueado.CleanerDNI, (DateTime)fechaInicio, (DateTime)fechaFin));
            }
            else if (fechaInicio == null && fechaFin == null && estado != "Todos" && nombreServicio == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxEstadoxCleaner(cleanerlogueado.CleanerDNI, estado));
            }
            else if (fechaInicio == null && fechaFin == null && estado == "Todos" && nombreServicio != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxTipoServicioxCleaner(cleanerlogueado.CleanerDNI, tipoServicio));
            }
            else if (fechaInicio == null && fechaFin == null && estado != "Todos" && nombreServicio != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaEstadoxtipoServicioxCleaner(cleanerlogueado.CleanerDNI, estado, tipoServicio));
            }
            else if (fechaInicio != null && fechaFin != null && estado != "Todos" && nombreServicio == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaRangoFechasxEstadoxCleaner(cleanerlogueado.CleanerDNI, (DateTime)fechaInicio, (DateTime)fechaFin, estado));
            }
            else if (fechaInicio != null && fechaFin != null && estado == "Todos" && nombreServicio != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaRangoFechasxtipoServicioxCleaner(cleanerlogueado.CleanerDNI, (DateTime)fechaInicio, (DateTime)fechaFin, tipoServicio));
            }
            else if (fechaInicio != null && fechaFin != null && estado != "Todos" && nombreServicio != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaMultiplexCleaner(cleanerlogueado.CleanerDNI, (DateTime)fechaInicio, (DateTime)fechaFin, estado, tipoServicio));
            }
            else
            {
                MostrarReservas(nReserva.ListarReservasxCleaner(cleanerlogueado.CleanerDNI));
            }
        }

        private void SelectionChangedFecha(object sender, SelectionChangedEventArgs e)
        {
            if (dpFechaInicio.SelectedDate > dpFechaFinal.SelectedDate)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha final.");
                return;
            }
            else
            {
                AplicarFiltros();
            }
        }

        private void SelectionChangedEstado(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void SelectionChangedTipoServicio(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void DoubleClickListBox(object sender, MouseButtonEventArgs e)
        {
            Reserva reservaSeleccionada = lsbReservas.SelectedItem as Reserva;

            if (reservaSeleccionada != null)
            {
                WindowCleanerReservasInformacion windowCleanerReservasInformacion = new WindowCleanerReservasInformacion(reservaSeleccionada);
                windowCleanerReservasInformacion.ShowDialog();
                MostrarReservas(nReserva.ListarReservasxCleaner(cleanerlogueado.CleanerDNI));
            }
        }

    }
}
