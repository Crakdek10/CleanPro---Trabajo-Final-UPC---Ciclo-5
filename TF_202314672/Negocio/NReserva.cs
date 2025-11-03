using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NReserva
    {
        private DReserva dReserva = new DReserva();
        public String Registrar(Reserva reserva)
        {
            return dReserva.Registrar(reserva);
        }

        public String Modificar(Reserva reserva)
        {
            return dReserva.Modificar(reserva);
        }

        public String Eliminar(String reservaId)
        {
            return dReserva.Eliminar(reservaId);
        }

        public void RegistrarPago(string cleanerDni, string reservaId, decimal monto)
        {
            dReserva.RegistrarPago(cleanerDni, reservaId, monto);
        }

        public bool ExisteConflictoDeReserva(string cleanerDNI, DateTime fecha, TimeSpan hora, string reservaIdAExcluir = null)
        {
            return dReserva.ExisteConflictoDeReserva(cleanerDNI, fecha, hora, reservaIdAExcluir) ;
        }

        public List<Reserva> ListarReservas()
        {
            return dReserva.ListarReservas();
        }

        public List<Reserva> ListarReservaxRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            return dReserva.ListarReservaxRangoFechas(fechaInicio, fechaFin);
        }

        public List<Reserva> ListarReservaxEstado(String estado)
        {
            return dReserva.ListarReservaxEstado(estado);
        }

        public List<Reserva> ListarReservaxProvincia(String provincia)
        {
            return dReserva.ListarReservaxProvincia(provincia);
        }

        public List<Reserva> ListarReservaEstadoxProvincia(String estado, String provincia)
        {
            return dReserva.ListarReservaEstadoxProvincia(estado, provincia);
        }

        public List<Reserva> ListarReservaRangoFechasxEstado(DateTime fechaInicio, DateTime fechaFin, String estado)
        {
            return dReserva.ListarReservaRangoFechasxEstado(fechaInicio, fechaFin, estado);
        }

        public List<Reserva> ListarReservaRangoFechasxProvincia(DateTime fechaInicio, DateTime fechaFin, String provincia)
        {
            return dReserva.ListarReservaRangoFechasxProvincia(fechaInicio, fechaFin, provincia);
        }

        public List<Reserva> ListarReservaMultiple(DateTime fechaInicio, DateTime fechaFin, String estado, String provincia)
        {
            return dReserva.ListarReservaMultiple(fechaInicio, fechaFin, estado, provincia);
        }

        public List<Reserva> ListarReservasxCleaner(String cleanerDni)
        {
            return dReserva.ListarReservasxCleaner(cleanerDni);
        }

        public List<Reserva> ListarReservaxRangoFechasxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin)
        {
            return dReserva.ListarReservaxRangoFechasxCleaner(cleanerDni, fechaInicio, fechaFin);
        }

        public List<Reserva> ListarReservaxEstadoxCleaner(String cleanerDni, String estado)
        {
            return dReserva.ListarReservaxEstadoxCleaner(cleanerDni, estado);
        }

        public List<Reserva> ListarReservaxTipoServicioxCleaner(String cleanerDni, int tipoServicio)
        {
            return dReserva.ListarReservaxTipoServicioxCleaner(cleanerDni, tipoServicio);
        }

        public List<Reserva> ListarReservaEstadoxtipoServicioxCleaner(String cleanerDni, String estado, int tipoServicio)
        {
            return dReserva.ListarReservaEstadoxtipoServicioxCleaner(cleanerDni, estado, tipoServicio);
        }

        public List<Reserva> ListarReservaRangoFechasxEstadoxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, String estado)
        {
            return dReserva.ListarReservaRangoFechasxEstadoxCleaner(cleanerDni, fechaInicio, fechaFin, estado);
        }

        public List<Reserva> ListarReservaRangoFechasxtipoServicioxCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, int tipoServicio)
        {
            return dReserva.ListarReservaRangoFechasxtipoServicioxCleaner(cleanerDni, fechaInicio, fechaFin, tipoServicio);
        }

        public List<Reserva> ListarReservaMultiplexCleaner(String cleanerDni, DateTime fechaInicio, DateTime fechaFin, String estado, int tipoServicio)
        {
            return dReserva.ListarReservaMultiplexCleaner(cleanerDni, fechaInicio, fechaFin, estado, tipoServicio);
        }

        public int MostrarCantidadReservasCompletadas(String cleanerDni)
        {
            return dReserva.MostrarCantidadReservasCompletadas(cleanerDni);
        }

        public int MostrarCantidadReservasCompletadasEnElMes(String cleanerDni)
        {
            return dReserva.MostrarCantidadReservasCompletadasEnElMes(cleanerDni);
        }

        public List<EntityReservasxTipo> ListarReservasxTipo(string cleanerDni)
        {
            return dReserva.ListarReservasxTipo(cleanerDni);
        }

        public List<EntityReservasxMesxYear> VolumenReservasxMesxYear(int year)
        {
            return dReserva.VolumenReservasxMesxYear(year);
        }

        public List<EntityReservasxEstadoxYear> DistribucionReservasxEstadoxYear(int year)
        {
            return dReserva.DistribucionReservasxEstadoxYear(year);
        }

        public List<EntityReservasCantidadTipoServicioxYear> PopularidadReservasPorTipoServicio(int year)
        {
            return dReserva.PopularidadReservasPorTipoServicio(year);
        }

        public List<EntityReservasCantidadTop10ProvinciaxYear> CantidadReservasTop10Provincia(int year)
        {
            return dReserva.CantidadReservasTop10Provincia(year);
        }

        public List<EntityRankingCleanersxYear> RankingCleanersxYear(int year)
        {
            return dReserva.RankingCleanersxYear(year);
        }

        public List<EntityCargaCleanersxYear> CargaCleanersxYear(int year)
        {
            return dReserva.CargaCleanersxYear(year);
        }

        public string GenerarCodigoReserva()
        {
            return dReserva.GenerarCodigoReserva();
        }
    }
}
