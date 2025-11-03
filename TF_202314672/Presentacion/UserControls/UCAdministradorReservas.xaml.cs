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
    /// Interaction logic for UCAdministradorReservas.xaml
    /// </summary>
    public partial class UCAdministradorReservas : UserControl
    {
        private NReserva nReserva = new NReserva();
        public event RoutedEventHandler AñadirReservas;

        public UCAdministradorReservas()
        {
            InitializeComponent();
            cbEstado.SelectedIndex = 0;
            cbProvincia.SelectedIndex = 0;
            MostrarReservas(nReserva.ListarReservas());
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
                lsbReservas.ItemsSource = reservas;
                tbContadorReservas.Text = reservas.Count().ToString();
            }
        }

        private void AplicarFiltros()
        {
            DateTime? fechaInicio = dpFechaInicio.SelectedDate;
            DateTime? fechaFin = dpFechaFinal.SelectedDate;
            string estado = (cbEstado.SelectedItem as ComboBoxItem)?.Content.ToString();
            string provincia = (cbProvincia.SelectedItem as ComboBoxItem)?.Content.ToString();


            if (fechaInicio != null && fechaFin != null && estado == "Todos" && provincia == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxRangoFechas((DateTime)fechaInicio, (DateTime)fechaFin));
            }
            else if (fechaInicio == null && fechaFin == null && estado != "Todos" && provincia == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxEstado(estado));
            }
            else if (fechaInicio == null && fechaFin == null && estado == "Todos" && provincia != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaxProvincia(provincia));
            }
            else if (fechaInicio == null && fechaFin == null && estado != "Todos" && provincia != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaEstadoxProvincia(estado, provincia));
            }
            else if (fechaInicio != null && fechaFin != null && estado != "Todos" && provincia == "Todos")
            {
                MostrarReservas(nReserva.ListarReservaRangoFechasxEstado((DateTime)fechaInicio, (DateTime)fechaFin, estado));
            }
            else if (fechaInicio != null && fechaFin != null && estado == "Todos" && provincia != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaRangoFechasxProvincia((DateTime)fechaInicio, (DateTime)fechaFin, provincia));
            }
            else if (fechaInicio != null && fechaFin != null && estado != "Todos" && provincia != "Todos")
            {
                MostrarReservas(nReserva.ListarReservaMultiple((DateTime)fechaInicio, (DateTime)fechaFin, estado, provincia));
            }
            else
            {
                MostrarReservas(nReserva.ListarReservas());
            }
        }

        private void btnAgregarReserva(object sender, RoutedEventArgs e)
        {
            AñadirReservas?.Invoke(this, e);
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

        private void SelectionChangedProvincia(object sender, SelectionChangedEventArgs e)
        {
            AplicarFiltros();
        }

        private void DoubleClickListBox(object sender, MouseButtonEventArgs e)
        {
            Reserva reservaSeleccionada = lsbReservas.SelectedItem as Reserva;

            if (reservaSeleccionada != null)
            {
                WindowAdministradorReservasInformacion windowAdministradorReservasInformacion = new WindowAdministradorReservasInformacion(reservaSeleccionada);
                windowAdministradorReservasInformacion.ShowDialog();
                MostrarReservas(nReserva.ListarReservas());
            }
        }
    }
}
