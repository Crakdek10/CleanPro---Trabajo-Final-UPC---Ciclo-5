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
    /// Interaction logic for WindowCleanerReservasInformacion.xaml
    /// </summary>
    public partial class WindowCleanerReservasInformacion : Window
    {
        private Reserva reservaSeleccionada;
        private NComprobante nComprobante = new NComprobante();
        private NReserva nReserva = new NReserva();
        private NServicio nServicio = new NServicio();
        public WindowCleanerReservasInformacion(Reserva reserva)
        {
            InitializeComponent();
            this.reservaSeleccionada = reserva;
        }

        private void Informacion_Loaded(object sender, RoutedEventArgs e)
        {
            CargarComboBoxes();
            MostrarInformacion();
            ActualizarEstadoBotones();
        }

        private void ActualizarEstadoBotones()
        {
            if (reservaSeleccionada.ReservaEstado == "Completado")
            {
                btn_Inicio.IsEnabled = false;
                btn_Terminado.IsEnabled = false;
                btn_Imprimir.IsEnabled = true;
            }
            else if (reservaSeleccionada.ReservaEstado == "En proceso")
            {
                btn_Inicio.IsEnabled = false;
                btn_Terminado.IsEnabled = true;
                btn_Imprimir.IsEnabled = false;
            }
            else
            {
                btn_Inicio.IsEnabled = true;
                btn_Terminado.IsEnabled = false;
                btn_Imprimir.IsEnabled = false;
            }
        }

        private void CargarComboBoxes()
        {
            cbTipoServicio.ItemsSource = nServicio.ListarServicios();
            cbTipoServicio.DisplayMemberPath = "ServicioNombre";
            cbTipoServicio.SelectedValuePath = "ServicioId";
        }

        private void MostrarInformacion()
        {
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
        }

        private void btnInicio(object sender, RoutedEventArgs e)
        {
            reservaSeleccionada.ReservaFechaInicio = DateTime.Now;
            reservaSeleccionada.ReservaEstado = "En proceso";
            String mensaje = nReserva.Modificar(reservaSeleccionada);
            MessageBox.Show(mensaje);

            ActualizarEstadoBotones();
            this.Close();
        }

        private void btnTerminado(object sender, RoutedEventArgs e)
        {
            reservaSeleccionada.ReservaFechaTerminado = DateTime.Now;
            reservaSeleccionada.ReservaEstado = "Completado";

            Servicio servicio = nServicio.ObtenerPorId(reservaSeleccionada.ServicioId);

            if (servicio != null)
            {
                decimal pago = servicio.ServicioPrecioBase * 0.80M;
                string cleanerDni = reservaSeleccionada.CleanerDNI;

                nReserva.RegistrarPago(cleanerDni, reservaSeleccionada.ReservaId, pago);
            }


            String mensaje = nReserva.Modificar(reservaSeleccionada);
            MessageBox.Show(mensaje);

            ActualizarEstadoBotones();
        }

        private void btnImprimir(object sender, RoutedEventArgs e)
        {
            Servicio servicio = nServicio.ObtenerPorId(reservaSeleccionada.ServicioId);

            Comprobante comprobante = new Comprobante
            {
                ReservaId = reservaSeleccionada.ReservaId,
                ComprobanteFechaEmision = DateTime.Now,
                ComprobanteMetodoPago = nComprobante.ObtenerMetodoPagoAleatorio(),
                ComprobanteMontoTotal = servicio.ServicioPrecioBase
            };

            nComprobante.Registrar(comprobante);

            WindowCleanerComprobante windowCleanerComprobante = new WindowCleanerComprobante(reservaSeleccionada, comprobante);
            windowCleanerComprobante.Show();
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
