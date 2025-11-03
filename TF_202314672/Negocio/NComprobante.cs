using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NComprobante
    {
        private DComprobante dComprobante = new DComprobante();
        public String Registrar(Comprobante comprobante)
        {
            return dComprobante.Registrar(comprobante);
        }

        public string ObtenerMetodoPagoAleatorio()
        {
            return dComprobante.ObtenerMetodoPagoAleatorio();
        }
    }
}
