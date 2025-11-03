using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DAdministrador
    {
        public Administrador Login(String administradorUsuario, String administradorContrasena)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Administrador administrador = context.Administrador.FirstOrDefault(c => c.AdministradorUsuario.Equals(administradorUsuario) &&
                                                                                            c.AdministradorContrasena.Equals(administradorContrasena));
                    return administrador;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
