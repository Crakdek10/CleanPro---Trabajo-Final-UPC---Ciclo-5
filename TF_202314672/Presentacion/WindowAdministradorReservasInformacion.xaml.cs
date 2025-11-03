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
    /// Interaction logic for WindowAdministradorReservasInformacion.xaml
    /// </summary>
    public partial class WindowAdministradorReservasInformacion : Window
    {
        private Reserva reservaSeleccionada;
        private NReserva nReserva = new NReserva();
        private NCleaner nCleaner = new NCleaner();
        private NServicio nServicio = new NServicio();
        private NCliente nCliente = new NCliente();
        public WindowAdministradorReservasInformacion(Reserva reserva)
        {
            InitializeComponent();
            this.reservaSeleccionada = reserva;

            CargarComboBoxes();
            MostrarInformacion();
        }

        private void cbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string provincia = (cbDepartamento.SelectedItem as ComboBoxItem)?.Content.ToString();
            cbCleaners.ItemsSource = nCleaner.ListarCleanerxProvinciaActivos(provincia);
            cbCleaners.DisplayMemberPath = "CleanerNombre";
            cbCleaners.SelectedValuePath = "CleanerDNI";
        }

        private void CargarComboBoxes()
        {
            cbTipoServicio.ItemsSource = nServicio.ListarServicios();
            cbTipoServicio.DisplayMemberPath = "ServicioNombre";
            cbTipoServicio.SelectedValuePath = "ServicioId";
        }

        private void MostrarInformacion()
        {
            string estado = reservaSeleccionada.ReservaEstado;
            string provinciaGuardada = reservaSeleccionada.ReservaProvincia;
            var itemASeleccionar = cbDepartamento.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == provinciaGuardada);

            tbReservaCreadaFecha.Text = $"Reserva creada - {reservaSeleccionada.ReservaFechaCreacion.ToString("dd/MM/yyyy")} {reservaSeleccionada.ReservaHora}";

            cbTipoServicio.SelectedValue = reservaSeleccionada.ServicioId;
            tbNombreCliente.Text = reservaSeleccionada.Cliente.ClienteNombre;
            tbDniCliente.Text = reservaSeleccionada.Cliente.ClienteDNI;
            tbNumeroCliente.Text = reservaSeleccionada.Cliente.ClienteNumero;
            tbCorreoCliente.Text = reservaSeleccionada.Cliente.ClienteCorreo;
            tbDireccion.Text = reservaSeleccionada.ReservaDireccion;
            cbDepartamento.SelectedItem = itemASeleccionar;
            dpFechaProgramada.SelectedDate = reservaSeleccionada.ReservaFechaProgramada;
            cbCleaners.SelectedValue = reservaSeleccionada.CleanerDNI;
            tbObservacion.Text = reservaSeleccionada.ReservaObservacion;

            if (estado == "Completado" || estado == "Cancelado")
            {
                btn_Editar.IsEnabled = false;
                btn_Eliminar.IsEnabled = false;
            }
        }

        private void btnEditar(object sender, RoutedEventArgs e)
        {
            cbTipoServicio.IsEnabled = true;
            tbNombreCliente.IsReadOnly = false;
            tbDniCliente.IsReadOnly = true;
            tbNumeroCliente.IsReadOnly = false;
            tbCorreoCliente.IsReadOnly = false;
            tbDireccion.IsReadOnly = false;
            cbDepartamento.IsEnabled = true;

            if (reservaSeleccionada.ReservaEstado == "Pendiente")
            {
                dpFechaProgramada.IsEnabled = true;
            }
            else
            {
                dpFechaProgramada.IsEnabled = false;
            }

            cbCleaners.IsEnabled = true;
            tbObservacion.IsReadOnly = false;

            btn_Guardar.IsEnabled = true;
            btn_Editar.IsEnabled = false;
            tbObservacion.Focus();
        }

        private void btnGuardar(object sender, RoutedEventArgs e)
        {
            if (tbNombreCliente.Text == "" || tbDniCliente.Text == "" || tbNumeroCliente.Text == "" || tbDireccion.Text == "" || cbDepartamento.SelectedItem == null || cbTipoServicio.SelectedItem == null || dpFechaProgramada.SelectedDate == null || cbCleaners.SelectedItem == null)
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbNumeroCliente.Text.Length != 9)
            {
                MessageBox.Show("El Número celular debe ser de 9 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DateTime.Parse(dpFechaProgramada.Text) < DateTime.Today)
            {
                MessageBox.Show("La fecha programada no debe ser inferior a hoy.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string cleanerDNI = cbCleaners.SelectedValue.ToString();
            DateTime fechaProgramada = dpFechaProgramada.SelectedDate.Value;
            TimeSpan horaSeleccionada = reservaSeleccionada.ReservaHora;

            if (nReserva.ExisteConflictoDeReserva(cleanerDNI, fechaProgramada, horaSeleccionada, reservaSeleccionada.ReservaId))
            {
                MessageBox.Show("El cleaner seleccionado ya tiene una reserva en esa fecha y hora.", "Conflicto de horario", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            reservaSeleccionada.Cliente.ClienteNombre = tbNombreCliente.Text;
            reservaSeleccionada.Cliente.ClienteNumero = tbNumeroCliente.Text;
            reservaSeleccionada.Cliente.ClienteCorreo = tbCorreoCliente.Text;

            reservaSeleccionada.ServicioId = int.Parse(cbTipoServicio.SelectedValue.ToString());
            reservaSeleccionada.CleanerDNI = cbCleaners.SelectedValue.ToString();
            reservaSeleccionada.ReservaDireccion = tbDireccion.Text;
            reservaSeleccionada.ReservaProvincia = (cbDepartamento.SelectedItem as ComboBoxItem).Content.ToString();
            reservaSeleccionada.ReservaFechaProgramada = dpFechaProgramada.SelectedDate.Value;
            reservaSeleccionada.ReservaObservacion = tbObservacion.Text;

            nCliente.Modificar(reservaSeleccionada.Cliente);
            String mensajeReserva = nReserva.Modificar(reservaSeleccionada);
            MessageBox.Show(mensajeReserva);

            cbTipoServicio.IsEnabled = false;
            tbNombreCliente.IsReadOnly = true;
            tbDniCliente.IsReadOnly = true;
            tbNumeroCliente.IsReadOnly = true;
            tbCorreoCliente.IsReadOnly = true;
            tbDireccion.IsReadOnly = true;
            cbDepartamento.IsReadOnly = true;
            dpFechaProgramada.IsEnabled = true;
            cbCleaners.IsReadOnly = true;
            tbObservacion.IsReadOnly = true;

            btn_Guardar.IsEnabled = false;
            btn_Editar.IsEnabled = true;
        }

        private void btnEliminar(object sender, RoutedEventArgs e)
        {
            var resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta reserva?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (resultado == MessageBoxResult.Yes)
            {
                String mensaje = nReserva.Eliminar(reservaSeleccionada.ReservaId);
                MessageBox.Show(mensaje);
                this.Close();
            }
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
