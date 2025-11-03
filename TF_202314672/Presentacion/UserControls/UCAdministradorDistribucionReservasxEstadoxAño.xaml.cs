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
    /// Interaction logic for UCAdministradorDistribucionReservasxEstadoxAño.xaml
    /// </summary>
    public partial class UCAdministradorDistribucionReservasxEstadoxAño : UserControl
    {
        private readonly List<EntityReservasxEstadoxYear> datosGrafico;

        public UCAdministradorDistribucionReservasxEstadoxAño(List<EntityReservasxEstadoxYear> datos)
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
            chartReservas.ChartAreas.Add(area);

            var legend = new Legend("Leyenda");
            chartReservas.Legends.Add(legend);

            var serie = new Series("Distribución")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P1}",
                ToolTip = "#VALX: #VAL (#PERCENT)"
            };

            chartReservas.Series.Add(serie);
        }

        private void CargarDatos(List<EntityReservasxEstadoxYear> datos)
        {
            var serie = chartReservas.Series["Distribución"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                var point = serie.Points.Add(item.Cantidad);
                point.AxisLabel = item.EstadoNombre;
                point.LegendText = item.EstadoNombre;
            }
        }
    }
}
