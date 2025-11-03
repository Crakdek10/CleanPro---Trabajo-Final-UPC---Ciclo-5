using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DComprobante
    {
        public String Registrar(Comprobante comprobante)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Comprobante.Add(comprobante);
                    context.SaveChanges();
                }
                return "Guardado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ObtenerMetodoPagoAleatorio()
        {
            string[] metodos = { "Efectivo", "Yape", "Plin", "Tarjeta" };
            Random rnd = new Random();
            return metodos[rnd.Next(metodos.Length)];
        }
    }
}
