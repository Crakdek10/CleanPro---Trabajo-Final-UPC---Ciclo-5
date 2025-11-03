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
    /// Interaction logic for UCAdministradorReportesVolumenReservasxMesxAño.xaml
    /// </summary>
    public partial class UCAdministradorReportesVolumenReservasxMesxAño : UserControl
    {
        private readonly List<EntityReservasxMesxYear> datosGrafico;

        public UCAdministradorReportesVolumenReservasxMesxAño(List<EntityReservasxMesxYear> datos)
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
            if (datosGrafico == null || datosGrafico.Count == 0) return;

            chartReservas.Series.Clear();
            chartReservas.ChartAreas.Clear();
            chartReservas.Legends.Clear();

            var area = new ChartArea("MainArea");
            area.AxisX.Interval = 1;
            area.AxisY.Title = "Reservas";
            chartReservas.ChartAreas.Add(area);

            chartReservas.Legends.Add(new Legend("Leyenda"));

            Series serieCompletado = new Series("Completado")
            {
                ChartType = SeriesChartType.StackedColumn,
                Color = System.Drawing.Color.FromArgb(102, 255, 102),
                IsValueShownAsLabel = true
            };

            Series serieCancelado = new Series("Cancelado")
            {
                ChartType = SeriesChartType.StackedColumn,
                Color = System.Drawing.Color.FromArgb(255, 221, 51),
                IsValueShownAsLabel = true
            };

            chartReservas.Series.Add(serieCompletado);
            chartReservas.Series.Add(serieCancelado);
        }

        public void CargarDatos(List<EntityReservasxMesxYear> datos)
        {
            chartReservas.Series["Completado"].Points.Clear();
            chartReservas.Series["Cancelado"].Points.Clear();

            foreach (var item in datos)
            {
                chartReservas.Series["Completado"].Points.AddXY(item.MesNombre, item.Completadas);
                chartReservas.Series["Cancelado"].Points.AddXY(item.MesNombre, item.Canceladas);
            }
        }
    }
}
