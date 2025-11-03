using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCleaner
    {
        public String Registrar(Cleaner cleaner)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Cleaner.Add(cleaner);
                    context.SaveChanges();
                }
                return "Registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Cleaner cleaner)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Cleaner cleanerTemp = context.Cleaner.Find(cleaner.CleanerDNI);
                    cleanerTemp.CleanerDNI = cleaner.CleanerDNI;
                    cleanerTemp.CleanerNombre = cleaner.CleanerNombre;
                    cleanerTemp.CleanerNumero = cleaner.CleanerNumero;
                    cleanerTemp.CleanerFechaNacimiento = cleaner.CleanerFechaNacimiento;
                    cleanerTemp.CleanerProvincia = cleaner.CleanerProvincia;
                    cleanerTemp.CleanerSexo = cleaner.CleanerSexo;
                    cleanerTemp.CleanerEstado = cleaner.CleanerEstado;
                    cleanerTemp.CleanerFoto = cleaner.CleanerFoto;
                    context.SaveChanges();
                }
                return "Modificado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public Cleaner ObtenerPorDni(string dni)
        {
            using (var context = new BDEFEntities())
            {
                return context.Cleaner.FirstOrDefault(c => c.CleanerDNI == dni);
            }
        }

        public List<Cleaner> ListarCleaners()
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public Cleaner Login(String cleanerDNI, String cleanercontrasena)
        {
            try
            {
                using(var context = new BDEFEntities())
                {
                    Cleaner cleaner = context.Cleaner.FirstOrDefault(c => c.CleanerDNI.Equals(cleanerDNI) && 
                                                                          c.CleanerContrasena.Equals(cleanercontrasena) && 
                                                                          c.CleanerEstado.Equals("ACTIVO"));
                    return cleaner;
                }
            }
            catch (Exception ex)
            {
                return null;    
            }
        }

        public List<Cleaner> ListarCleanerxNombre(String nombre)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerNombre.Contains(nombre)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerxEstado(String estado)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerEstado.Equals(estado)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerxProvincia(String provincia)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerProvincia.Equals(provincia)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerxProvinciaActivos(String provincia)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerProvincia.Equals(provincia) && e.CleanerEstado.Equals("Activo")).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerNombrexEstado(String nombre, String estado)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerNombre.Contains(nombre) &&
                                                          e.CleanerEstado.Equals(estado)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerNombrexProvincia(String nombre, String provincia)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerNombre.Contains(nombre) &&
                                                          e.CleanerProvincia.Equals(provincia)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerEstadoxProvincia(String estado, String provincia)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerEstado.Equals(estado) &&
                                                          e.CleanerProvincia.Equals(provincia)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }

        public List<Cleaner> ListarCleanerMultiple(String nombre, String estado, String provincia)
        {
            List<Cleaner> cleaners = new List<Cleaner>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    cleaners = context.Cleaner.Where(e => e.CleanerNombre.Contains(nombre) && 
                                                          e.CleanerEstado.Equals(estado) && 
                                                          e.CleanerProvincia.Equals(provincia)).ToList();
                }
                return cleaners;
            }
            catch (Exception ex)
            {
                return cleaners;
            }
        }
    }
}
