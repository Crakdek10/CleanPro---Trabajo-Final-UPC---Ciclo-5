using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datos
{
    public class DReserva
    {

        public String Registrar(Reserva reserva)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Reserva.Add(reserva);
                    context.SaveChanges();
                }
                return "Reserva registrada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public String Modificar(Reserva reserva)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Entry(reserva).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                return "Reserva modificada correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public String Eliminar(String reservaId)
        {
            try
            {
                using (var context = new BDEFEntities())
                {
                    Reserva reservaTemp = context.Reserva.Find(reservaId);
                    reservaTemp.ReservaEstado = "Cancelado";
                    context.SaveChanges();
                }
                return "Eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void RegistrarPago(string cleanerDni, string reservaId, decimal monto)
        {
            using (var context = new BDEFEntities())
            {
                var cleaner = context.Cleaner.FirstOrDefault(c => c.CleanerDNI == cleanerDni);
                if (cleaner != null)
                {
                    cleaner.CleanerSueldo += monto;
                    context.SaveChanges();
                }
            }
        }

        public bool ExisteConflictoDeReserva(string cleanerDNI, DateTime fecha, TimeSpan hora, string reservaIdAExcluir = null)
        {
            using (var context = new BDEFEntities())
            {
                return context.Reserva.Any(r =>
                    r.CleanerDNI == cleanerDNI &&
                    r.ReservaFechaProgramada == fecha.Date &&
                    r.ReservaHora == hora &&
                    (reservaIdAExcluir == null || r.ReservaId != reservaIdAExcluir));
            }
        }

        //GENERAL
        public List<Reserva> ListarReservas()
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Include(r => r.Cliente).Include(r => r.Servicio).Include(r => r.Cleaner).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin)
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxEstado(String estado)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaEstado.Equals(estado))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxProvincia(String provincia)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaProvincia.Equals(provincia))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaEstadoxProvincia(String estado, String provincia)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaEstado.Equals(estado) && e.ReservaProvincia.Equals(provincia))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaRangoFechasxEstado(DateTime fechaInicio, DateTime fechaFin, String estado)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ReservaEstado.Equals(estado))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaRangoFechasxProvincia(DateTime fechaInicio, DateTime fechaFin, String provincia)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ReservaProvincia.Equals(provincia))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaMultiple(DateTime fechaInicio, DateTime fechaFin, String estado, String provincia)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ReservaEstado.Equals(estado) && e.ReservaProvincia.Equals(provincia))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }
        //GENERAL

        //LISTAR SOLO PARA UN CLEANER
        public List<Reserva> ListarReservasxCleaner(String cleanerDni)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(r => r.CleanerDNI == cleanerDni).Include(r => r.Cliente).Include(r => r.Servicio).Include(r => r.Cleaner).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxRangoFechasxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin)
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxEstadoxCleaner(String cleanerDni, String estado)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaEstado.Equals(estado))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaxTipoServicioxCleaner(String cleanerDni, int tipoServicio)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ServicioId.Equals(tipoServicio))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaEstadoxtipoServicioxCleaner(String cleanerDni, String estado, int tipoServicio)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaEstado.Equals(estado) && e.ServicioId.Equals(tipoServicio))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaRangoFechasxEstadoxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, String estado)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ReservaEstado.Equals(estado))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaRangoFechasxtipoServicioxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, int tipoServicio)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ServicioId.Equals(tipoServicio))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        public List<Reserva> ListarReservaMultiplexCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, String estado, int tipoServicio)
        {
            List<Reserva> reservas = new List<Reserva>();
            try
            {
                using (var context = new BDEFEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    reservas = context.Reserva.Where(e => e.CleanerDNI == cleanerDni && e.ReservaFechaProgramada >= fechaInicio && e.ReservaFechaProgramada <= fechaFin && e.ReservaEstado.Equals(estado) && e.ServicioId.Equals(tipoServicio))
                                              .Include(r => r.Cliente).Include(r => r.Servicio).ToList();
                }
                return reservas;
            }
            catch (Exception ex)
            {
                return reservas;
            }
        }

        //LISTAR SOLO PARA UN CLEANER

        public int MostrarCantidadReservasCompletadas(String cleanerDni)
        {
            int Cantidadreservas = 0;

            try
            {
                using (var context = new BDEFEntities())
                {
                    Cantidadreservas = context.Reserva.Where(r => r.CleanerDNI == cleanerDni && r.ReservaEstado.Equals("Completado")).Count();
                }
                return Cantidadreservas;
            }
            catch (Exception ex)
            {
                return Cantidadreservas;
            }
        }

        public int MostrarCantidadReservasCompletadasEnElMes(String cleanerDni)
        {
            int cantidadReservas = 0;

            try
            {
                using (var context = new BDEFEntities())
                {
                    DateTime ahora = DateTime.Now;
                    int MonthActual = ahora.Month;
                    int YearActual = ahora.Year;

                    cantidadReservas = context.Reserva.Where(r => r.CleanerDNI == cleanerDni && r.ReservaFechaTerminado.Value.Month == MonthActual && r.ReservaFechaTerminado.Value.Year == YearActual).Count();
                }

                return cantidadReservas;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public List<EntityReservasxTipo> ListarReservasxTipo(string cleanerDni)
        {
            using (var context = new BDEFEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                var reservasPorTipo = context.Reserva
                    .Where(r => r.CleanerDNI == cleanerDni)
                    .GroupBy(r => r.Servicio.ServicioNombre)
                    .Select(g => new EntityReservasxTipo
                    {
                        ServicioNombre = g.Key,
                        Cantidad = g.Count()
                    })
                    .ToList();

                return reservasPorTipo;
            }
        }

        //Reportes

        public List<EntityReservasxMesxYear> VolumenReservasxMesxYear(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservas = context.Reserva.Where(r => r.ReservaFechaProgramada.Year == year).ToList();

                var cultura = new System.Globalization.CultureInfo("es-ES");

                List<EntityReservasxMesxYear> meses = Enumerable.Range(1, 12)
                    .Select(m => new EntityReservasxMesxYear
                    {
                        NumeroMes = m,
                        MesNombre = cultura.DateTimeFormat.GetMonthName(m),
                        Completadas = 0,
                        Canceladas = 0
                    }).ToList();

                var agrupado = reservas.GroupBy(r => r.ReservaFechaProgramada.Month)
                    .Select(g => new
                    {
                        Mes = g.Key,
                        Completadas = g.Count(r => r.ReservaEstado == "Completado"),
                        Canceladas = g.Count(r => r.ReservaEstado == "Cancelado")
                    }).ToList();

                foreach (var item in agrupado)
                {
                    var mes = meses.FirstOrDefault(m => m.NumeroMes == item.Mes);

                    if (mes != null)
                    {
                        mes.Completadas = item.Completadas;
                        mes.Canceladas = item.Canceladas;
                    }
                }

                return meses.OrderBy(m => m.NumeroMes).ToList();
            }
        }

        public List<EntityReservasxEstadoxYear> DistribucionReservasxEstadoxYear(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservasdelaño = context.Reserva.Where(r => r.ReservaFechaProgramada.Year == year).ToList();

                double totalReservas = reservasdelaño.Count();

                if (totalReservas == 0) return new List<EntityReservasxEstadoxYear>();

                var reporte = reservasdelaño.GroupBy(r => r.ReservaEstado)
                    .Select(g => new EntityReservasxEstadoxYear
                    {
                        EstadoNombre = g.Key,
                        Cantidad = g.Count(), 
                        Porcentaje = g.Count()/totalReservas 
                    }).OrderBy(r => r.EstadoNombre).ToList();

                return reporte;
            }
        }

        public List<EntityReservasCantidadTipoServicioxYear> PopularidadReservasPorTipoServicio(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservasDelAño = context.Reserva.Where(r => r.ReservaFechaProgramada.Year == year && r.Servicio != null).ToList();

                double total = reservasDelAño.Count();

                if (total == 0) return new List<EntityReservasCantidadTipoServicioxYear>();

                var reporte = reservasDelAño.GroupBy(r => r.Servicio.ServicioNombre)
                    .Select(g => new EntityReservasCantidadTipoServicioxYear
                    {
                        TipoServicioNombre = g.Key,
                        Cantidad = g.Count(),
                        Porcentaje = Math.Round(g.Count() / total, 4)
                    })
                    .OrderByDescending(r => r.Cantidad).ToList();

                return reporte;
            }
        }

        public List<EntityReservasCantidadTop10ProvinciaxYear> CantidadReservasTop10Provincia(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservasDelAño = context.Reserva
                    .Where(r => r.ReservaFechaProgramada.Year == year && r.ReservaProvincia != null)
                    .ToList();

                var reporte = reservasDelAño
                    .GroupBy(r => r.ReservaProvincia)
                    .Select(g => new EntityReservasCantidadTop10ProvinciaxYear
                    {
                        ProvinciaNombre = g.Key,
                        Cantidad = g.Count()
                    })
                    .OrderByDescending(r => r.Cantidad)
                    .Take(10)
                    .ToList();

                return reporte;
            }
        }

        public List<EntityRankingCleanersxYear> RankingCleanersxYear(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservas = context.Reserva
                    .Where(r =>
                        r.ReservaFechaProgramada.Year == year &&
                        r.ReservaEstado == "Completado" &&
                        r.Cleaner != null &&
                        r.ReservaFechaInicio != null &&
                        r.ReservaFechaTerminado != null)
                    .ToList();

                var resultado = reservas
                    .GroupBy(r => r.Cleaner.CleanerNombre) 
                    .Select(g => new EntityRankingCleanersxYear
                    {
                        CleanerNombre = g.Key,
                        ReservasCompletadas = g.Count(),
                        PromedioDuracionHoras = Math.Round(
                            g.Average(r =>
                                (r.ReservaFechaTerminado.Value - r.ReservaFechaInicio.Value).TotalHours
                            ), 2)
                    })
                    .OrderByDescending(e => e.ReservasCompletadas).Take(10).ToList();

                return resultado;
            }
        }

        public List<EntityCargaCleanersxYear> CargaCleanersxYear(int year)
        {
            using (var context = new BDEFEntities())
            {
                var reservas = context.Reserva
                    .Where(r => r.ReservaFechaProgramada.Year == year
                                && r.Cleaner != null)
                    .ToList();

                double total = reservas.Count();
                if (total == 0) return new List<EntityCargaCleanersxYear>();

                var resultado = reservas
                    .GroupBy(r => r.Cleaner.CleanerNombre)
                    .Select(g => new EntityCargaCleanersxYear
                    {
                        CleanerNombre = g.Key,
                        CantidadReservas = g.Count(),
                        Porcentaje = Math.Round(g.Count() / total, 4)
                    })
                    .OrderByDescending(r => r.CantidadReservas).Take(10).ToList();

                return resultado;
            }
        }

        //Reportes

        public string GenerarCodigoReserva()
        {
            using (var context = new BDEFEntities())
            {
                int año = DateTime.Now.Year;
                string prefijo = $"R{año}-";

                int cantidad = context.Reserva.Count(r => r.ReservaId.StartsWith(prefijo));

                int siguienteNumero = cantidad + 1;
                return $"{prefijo}{siguienteNumero.ToString("D4")}";
            }
        }
    }
}
