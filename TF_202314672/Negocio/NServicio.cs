using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NServicio
    {
        private DServicio dServicio = new DServicio();
        public List<Servicio> ListarServicios()
        {
            return dServicio.ListarServicios();
        }

        public int ObtenerServicioIdPorNombre(string servicioNombre)
        {
            return dServicio.ObtenerServicioIdPorNombre(servicioNombre);
        }

        public Servicio ObtenerPorId(int servicioId)
        {
            return dServicio.ObtenerPorId(servicioId);
        }
    }
}
