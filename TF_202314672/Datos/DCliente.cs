using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCliente
    {
        public String Registrar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cliente.Add(cliente);
                    context.SaveChanges();
                }
                return "Cliente guardado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Cliente cliente)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(cliente.ClienteDNI);
                    clienteTemp.ClienteDNI = cliente.ClienteDNI;
                    clienteTemp.ClienteNombre = cliente.ClienteNombre;
                    clienteTemp.ClienteNumero = cliente.ClienteNumero;
                    clienteTemp.ClienteCorreo = cliente.ClienteCorreo;
                    context.SaveChanges();
                }
                return "Cliente modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Cliente BuscarxDNI(String clienteDni)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cliente clienteTemp = context.Cliente.Find(clienteDni);

                    return clienteTemp;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
