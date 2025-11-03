using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NAdministrador
    {
        private DAdministrador dAdministrador = new DAdministrador();

        public Administrador Login(String administradorUsuario, String administradorContrasena)
        {
            return dAdministrador.Login(administradorUsuario, administradorContrasena);
        }
    }
}
