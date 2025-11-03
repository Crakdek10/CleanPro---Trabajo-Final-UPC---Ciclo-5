using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCleaner
    {
        private DCleaner dCleaner = new DCleaner();

        public String Registrar(Cleaner cleaner)
        {
            return dCleaner.Registrar(cleaner);
        }

        public String Modificar(Cleaner cleaner)
        {
            return dCleaner.Modificar(cleaner);
        }

        public Cleaner ObtenerPorDni(string dni)
        {
            return dCleaner.ObtenerPorDni(dni);
        }

        public List<Cleaner> ListarCleaners()
        {
            return dCleaner.ListarCleaners();
        }

        public Cleaner Login(String cleanerDNI, String cleanercontrasena)
        {
            return dCleaner.Login(cleanerDNI, cleanercontrasena);
        }

        public List<Cleaner> ListarCleanerxNombre(String nombre)
        {
            return dCleaner.ListarCleanerxNombre(nombre);
        }

        public List<Cleaner> ListarCleanerxEstado(String estado)
        {
            return dCleaner.ListarCleanerxEstado(estado);
        }

        public List<Cleaner> ListarCleanerxProvincia(String provincia)
        {
            return dCleaner.ListarCleanerxProvincia(provincia);
        }

        public List<Cleaner> ListarCleanerxProvinciaActivos(String provincia)
        {
            return dCleaner.ListarCleanerxProvinciaActivos(provincia);
        }

        public List<Cleaner> ListarCleanerNombrexEstado(String nombre, String estado)
        {
            return dCleaner.ListarCleanerNombrexEstado(nombre, estado);
        }

        public List<Cleaner> ListarCleanerNombrexProvincia(String nombre, String provincia)
        {
            return dCleaner.ListarCleanerNombrexProvincia(nombre, provincia);
        }

        public List<Cleaner> ListarCleanerEstadoxProvincia(String estado, String provincia)
        {
            return dCleaner.ListarCleanerEstadoxProvincia(estado, provincia);
        }

        public List<Cleaner> ListarCleanerMultiple(String nombre, String estado, String provincia)
        {
            return dCleaner.ListarCleanerMultiple(nombre, estado, provincia);
        }
    }
}
