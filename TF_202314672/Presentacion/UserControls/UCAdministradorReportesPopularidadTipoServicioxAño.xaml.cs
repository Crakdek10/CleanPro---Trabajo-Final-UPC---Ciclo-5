using Datos;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for UCAdministradorReportesPopularidadTipoServicioxAño.xaml
    /// </summary>
    public partial class UCAdministradorReportesPopularidadTipoServicioxAño : UserControl
    {
        private readonly List<EntityReservasCantidadTipoServicioxYear> datosGrafico;

        public UCAdministradorReportesPopularidadTipoServicioxAño(List<EntityReservasCantidadTipoServicioxYear> datos)
        {
            InitializeComponent();
            datosGrafico = datos;
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
            chartReservas.ChartAreas.Add(area);

            var legend = new Legend("Leyenda");
            chartReservas.Legends.Add(legend);

            var serie = new Series("Servicios")
            {
                ChartType = SeriesChartType.Doughnut,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P1}",
                ToolTip = "#VALX: #VAL (#PERCENT)",
                Font = new Font("Arial", 9f)
            };

            chartReservas.Series.Add(serie);
        }

        private void CargarDatos(List<EntityReservasCantidadTipoServicioxYear> datos)
        {

            var serie = chartReservas.Series["Servicios"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                var point = serie.Points.Add(item.Cantidad);
                point.AxisLabel = item.TipoServicioNombre;
                point.LegendText = item.TipoServicioNombre;
            }
        }
    }
}
