using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class EntityReservasxTipo
    {
        public String ServicioNombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class EntityReservasxMesxYear
    {
        public String MesNombre { get; set; }
        public int NumeroMes { get; set; }
        public int Completadas { get; set; }
        public int Canceladas { get; set; }
        public int Total => Completadas + Canceladas;
    }

    public class EntityReservasxEstadoxYear
    {
        public String EstadoNombre { get; set; }
        public int Cantidad { get; set; }
        public double Porcentaje { get; set; }
    }

    public class EntityReservasCantidadTipoServicioxYear
    {
        public String TipoServicioNombre { get; set; }
        public int Cantidad { get; set; }
        public double Porcentaje { get; set; }
    }

    public class EntityReservasCantidadTop10ProvinciaxYear
    {
        public String ProvinciaNombre { get; set; }
        public int Cantidad { get; set; }
    }

    public class EntityRankingCleanersxYear
    {
        public string CleanerNombre { get; set; }
        public int ReservasCompletadas { get; set; }
        public double PromedioDuracionHoras { get; set; }
    }

    public class EntityCargaCleanersxYear
    {
        public string CleanerNombre { get; set; }
        public int CantidadReservas { get; set; }
        public double Porcentaje { get; set; }
    }
}
