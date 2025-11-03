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
    /// Interaction logic for UCAdministradorReportesCantidadReservasProvinciaxAño.xaml
    /// </summary>
    public partial class UCAdministradorReportesCantidadReservasProvinciaxAño : UserControl
    {
        private readonly List<EntityReservasCantidadTop10ProvinciaxYear> datosGrafico;

        public UCAdministradorReportesCantidadReservasProvinciaxAño(List<EntityReservasCantidadTop10ProvinciaxYear> datos)
        {
            InitializeComponent();
            this.datosGrafico = datos;
        }

        private void UCGrafico_Loaded(object sender, System.Windows.RoutedEventArgs e)
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
            area.AxisX.Title = "Provincia";
            area.AxisY.Title = "Cantidad de Reservas";
            area.AxisX.LabelStyle.Font = new Font("Arial", 9f);
            area.AxisY.LabelStyle.Font = new Font("Arial", 9f);
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.AxisY.MajorGrid.Enabled = false;
            area.BackColor = System.Drawing.Color.Transparent;

            chartReservas.ChartAreas.Add(area);

            var legend = new Legend("Leyenda");
            legend.Docking = Docking.Top;
            chartReservas.Legends.Add(legend);

            var serie = new Series("Reservas")
            {
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true,
                Font = new Font("Arial", 9f),
                Label = "#VAL"
            };

            chartReservas.Series.Add(serie);
        }

        private void CargarDatos(List<EntityReservasCantidadTop10ProvinciaxYear> datos)
        {
            var serie = chartReservas.Series["Reservas"];
            serie.Points.Clear();

            foreach (var item in datos)
            {
                var point = serie.Points.Add(item.Cantidad);
                point.AxisLabel = item.ProvinciaNombre;
                point.LegendText = item.ProvinciaNombre;
            }
        }
    }
}
