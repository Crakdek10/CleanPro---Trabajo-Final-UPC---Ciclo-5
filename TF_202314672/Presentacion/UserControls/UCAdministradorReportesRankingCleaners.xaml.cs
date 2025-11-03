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
    /// Interaction logic for UCAdministradorReportesRankingCleaners.xaml
    /// </summary>
    public partial class UCAdministradorReportesRankingCleaners : UserControl
    {
        private readonly List<EntityRankingCleanersxYear> datosGrafico;

        public UCAdministradorReportesRankingCleaners(List<EntityRankingCleanersxYear> datos)
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
            area.AxisX.Interval = 1;
            area.AxisX.Title = "Cleaners";
            area.AxisY.Title = "Reservas Completadas";
            area.AxisX.LabelStyle.Angle = -45; 
            chartReservas.ChartAreas.Add(area);

            var legend = new Legend("Leyenda");
            chartReservas.Legends.Add(legend);

            var serie = new Series("Reservas Completadas")
            {
                ChartType = SeriesChartType.Column, 
                IsValueShownAsLabel = true,
                Color = System.Drawing.Color.FromArgb(102, 153, 255)
            };

            chartReservas.Series.Add(serie);
        }

        private void CargarDatos(List<EntityRankingCleanersxYear> datos)
        {
            var serie = chartReservas.Series["Reservas Completadas"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                var point = serie.Points.Add(item.ReservasCompletadas);
                point.AxisLabel = item.CleanerNombre;
                point.ToolTip = $"{item.CleanerNombre}: {item.ReservasCompletadas} reservas\nPromedio: {item.PromedioDuracionHoras}h";
            }
        }
    }
}
