using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DServicio
    {
        public List<Servicio> ListarServicios()
        {
            List<Servicio> servicios = new List<Servicio>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    servicios = context.Servicio.ToList();
                }
                return servicios;
            }
            catch (Exception ex)
            {
                return servicios;
            }
        }

        public int ObtenerServicioIdPorNombre(string servicioNombre)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Servicio servicio = context.Servicio.FirstOrDefault(s => s.ServicioNombre == servicioNombre);
                    if (servicio != null)
                    {
                        return servicio.ServicioId;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Servicio ObtenerPorId(int servicioId)
        {
            using (var context = new BDEFEntities())
            {
                return context.Servicio.FirstOrDefault(s => s.ServicioId == servicioId);
            }
        }
    }
}
