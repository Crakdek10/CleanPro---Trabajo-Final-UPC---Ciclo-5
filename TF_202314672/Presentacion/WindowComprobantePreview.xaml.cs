using Datos;
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
    /// Interaction logic for WindowComprobantePreview.xaml
    /// </summary>
    public partial class WindowComprobantePreview : Window
    {
        private Reserva reservaSeleccionada;
        private Comprobante comprobanteGenerado;

        public WindowComprobantePreview(Comprobante comprobante, Reserva reserva)
        {
            InitializeComponent();
            this.reservaSeleccionada = reserva;
            this.comprobanteGenerado = comprobante;
        }

        public void SetearDatos()
        {
            tbClienteNombre.Text = reservaSeleccionada.Cliente.ClienteNombre;
            tbClienteDNI.Text = reservaSeleccionada.ClienteDNI;
            tbDireccion.Text = reservaSeleccionada.ReservaDireccion;
            tbClienteTelefono.Text = reservaSeleccionada.Cliente.ClienteNumero;
            tbTipoServicio.Text = reservaSeleccionada.Servicio.ServicioNombre;
            tbTipoServicio2.Text = reservaSeleccionada.Servicio.ServicioNombre;
            tbFechaServicio.Text = reservaSeleccionada.ReservaFechaTerminado.Value.ToString("dd/MM/yyyy");
            tbTotal.Text = $"S/ {comprobanteGenerado.ComprobanteMontoTotal:0.00}";
            tbMetodoPago.Text = comprobanteGenerado.ComprobanteMetodoPago;
            tbCodigoOrden.Text = $"Orden N° {comprobanteGenerado.ComprobanteId}";
        }
    }
}
