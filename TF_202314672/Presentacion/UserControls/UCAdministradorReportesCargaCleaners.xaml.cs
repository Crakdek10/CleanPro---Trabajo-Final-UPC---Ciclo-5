using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Presentacion.UserControls
{
    /// <summary>
    /// Interaction logic for UCAdministradorReportesCargaCleaners.xaml
    /// </summary>
    public partial class UCAdministradorReportesCargaCleaners : UserControl
    {
        private readonly List<EntityCargaCleanersxYear> datosGrafico;

        public UCAdministradorReportesCargaCleaners(List<EntityCargaCleanersxYear> datos)
        {
            InitializeComponent();
            this.datosGrafico = datos;
        }

        private void UCGrafico_Loaded(object sender, RoutedEventArgs e)
        {
            InicializarGrafico();

            if (datosGrafico != null && datosGrafico.Count > 0)
            {
                CargarDatos(datosGrafico);
            }
        }

        private void InicializarGrafico()
        {
            chartReservas.Series.Clear();
            chartReservas.ChartAreas.Clear();
            chartReservas.Legends.Clear();

            var area = new ChartArea("MainArea");
            area.AxisY.Interval = 1;
            area.AxisX.Title = "Cleaners";
            area.AxisY.Title = "Reservas Asignadas";
            chartReservas.ChartAreas.Add(area);

            chartReservas.Legends.Add(new Legend("Leyenda"));

            var serie = new Series("Carga de Trabajo")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.FromArgb(255, 153, 102)
            };

            chartReservas.Series.Add(serie);
        }

        private void CargarDatos(List<EntityCargaCleanersxYear> datos)
        {
            var serie = chartReservas.Series["Carga de Trabajo"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                var point = serie.Points.Add(item.CantidadReservas);
                point.AxisLabel = item.CleanerNombre;
                point.ToolTip = $"{item.CleanerNombre}: {item.CantidadReservas} reservas\n({item.Porcentaje:P1})";
            }
        }
    }
}
