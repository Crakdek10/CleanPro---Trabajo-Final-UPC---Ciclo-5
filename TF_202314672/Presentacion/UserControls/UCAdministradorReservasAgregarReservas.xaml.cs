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
    /// Interaction logic for UCAdministradorReservasAgregarReservas.xaml
    /// </summary>
    public partial class UCAdministradorReservasAgregarReservas : UserControl
    {
        private NReserva nReserva = new NReserva();
        private NCleaner nCleaner = new NCleaner();
        private NServicio nServicio = new NServicio();
        private NCliente nCliente = new NCliente();
        public event RoutedEventHandler VolverUCAdministradorReservas;

        public UCAdministradorReservasAgregarReservas()
        {
            InitializeComponent();
            cbProvincia.SelectedIndex = 0;
            cbTipoServicio.ItemsSource = nServicio.ListarServicios();
            cbTipoServicio.SelectedValuePath = "ServicioId";
            cbTipoServicio.DisplayMemberPath = "ServicioNombre";
        }

        private void MostrarCleaners(List<Cleaner> cleaners)
        {
            cbCleaners.ItemsSource = null;

            if (cleaners.Count == 0)
            {
                return;
            }
            else
            {
                string provincia = (cbProvincia.SelectedItem as ComboBoxItem)?.Content.ToString();
                cbCleaners.ItemsSource = nCleaner.ListarCleanerxProvinciaActivos(provincia);
                cbCleaners.SelectedValuePath = "CleanerDNI";
                cbCleaners.DisplayMemberPath = "CleanerNombre";
            }
        }

        private void btnAgregar(object sender, RoutedEventArgs e)
        {
            if (tbNombreCliente.Text == "" || tbDniCliente.Text == "" || tbCorreoCliente.Text == "" || tbNumeroCliente.Text == "" || tbDireccion.Text == "" || cbTipoServicio.SelectedItem == null || dpFecha.SelectedDate == null || cbHora.SelectedItem == null || cbCleaners.SelectedItem == null)
            {
                MessageBox.Show("Debe rellenar todos los campos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbDniCliente.Text.Length != 8 || !tbDniCliente.Text.All(char.IsDigit))
            {
                MessageBox.Show("El DNI debe ser un número de 8 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (tbNumeroCliente.Text.Length != 9)
            {
                MessageBox.Show("El Número celular debe ser de 9 dígitos.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (cbProvincia.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor selecciona un departamento");
                return;
            }

            if (dpFecha.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("La fecha programada no debe ser inferior a hoy.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string clienteDNI = tbDniCliente.Text;
            Cliente clienteExistente = nCliente.BuscarxDNI(clienteDNI);

            string cleanerDNI = cbCleaners.SelectedValue.ToString();
            DateTime fechaProgramada = dpFecha.SelectedDate.Value;
            TimeSpan horaSeleccionada = DateTime.Parse(cbHora.Text).TimeOfDay;

            if (nReserva.ExisteConflictoDeReserva(cleanerDNI, fechaProgramada, horaSeleccionada))
            {
                MessageBox.Show("El cleaner seleccionado ya tiene una reserva en esa fecha y hora.", "Conflicto de horario", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (clienteExistente == null)
            {
                Cliente cliente = new Cliente
                {
                    ClienteDNI = clienteDNI,
                    ClienteNombre = tbNombreCliente.Text,
                    ClienteNumero = tbNumeroCliente.Text,
                    ClienteCorreo = tbCorreoCliente.Text
                };

                nCliente.Registrar(cliente);
            }

            Reserva reserva = new Reserva()
            {
                ReservaId = nReserva.GenerarCodigoReserva(),
                CleanerDNI = cbCleaners.SelectedValue.ToString(),
                ClienteDNI = clienteDNI,
                ServicioId = int.Parse(cbTipoServicio.SelectedValue.ToString()),
                ReservaDireccion = tbDireccion.Text,
                ReservaProvincia = (cbProvincia.SelectedItem as ComboBoxItem).Content.ToString(),
                ReservaFechaCreacion = DateTime.Now,
                ReservaFechaProgramada = dpFecha.SelectedDate.Value,
                ReservaHora = DateTime.Parse(cbHora.Text).TimeOfDay,
                ReservaEstado = "Pendiente",
            };

            String mensajeReserva = nReserva.Registrar(reserva);
            MessageBox.Show(mensajeReserva);

            VolverUCAdministradorReservas?.Invoke(this, e);
        }

        private void btnVolver(object sender, RoutedEventArgs e)
        {
            VolverUCAdministradorReservas?.Invoke(this, e);
        }

        private void DepartamentoSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarCleaners(nCleaner.ListarCleaners());
        }
    }
}
