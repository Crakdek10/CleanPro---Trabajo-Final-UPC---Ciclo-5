using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.DataVisualization.Charting;
using Negocio;
using Datos;

namespace Presentacion.UserControls
{
    /// <summary>
    /// Interaction logic for UCCleanerInformes.xaml
    /// </summary>
    public partial class UCCleanerInformes : UserControl
    {
        private NReserva nReserva = new NReserva();
        private NCleaner nCleaner = new NCleaner();
        private Cleaner cleanerlogueado;

        public UCCleanerInformes(Cleaner cleaner)
        {
            InitializeComponent();
            this.cleanerlogueado = cleaner;
        }

        private void loaded(object sender, RoutedEventArgs e)
        {
            CargarDatos();

            var datos = nReserva.ListarReservasxTipo(cleanerlogueado.CleanerDNI);
            CargarGrafico(datos);
        }

        private void CargarDatos()
        {
            cleanerlogueado = nCleaner.ObtenerPorDni(cleanerlogueado.CleanerDNI);
            tbTotalReservasRealizadas.Text = nReserva.MostrarCantidadReservasCompletadas(cleanerlogueado.CleanerDNI).ToString();
            tbTotalReservasRealizadasMesActual.Text = nReserva.MostrarCantidadReservasCompletadasEnElMes(cleanerlogueado.CleanerDNI).ToString();
            tbSueldo.Text = cleanerlogueado.CleanerSueldo.ToString("C");
        }

        private void CargarGrafico(List<EntityReservasxTipo> datos)
        {
            if (datos == null || datos.Count == 0)
            {
                System.Windows.MessageBox.Show("No hay datos para mostrar en el gráfico.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            pieChartReservas.Series.Clear();
            pieChartReservas.ChartAreas.Clear();
            pieChartReservas.Legends.Clear();

            var chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea("MainArea");
            pieChartReservas.ChartAreas.Add(chartArea);

            var series = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Servicios",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                Label = "#PERCENT{P0}"
            };

            foreach (var item in datos)
            {
                var point = series.Points.Add(item.Cantidad);
                point.AxisLabel = item.ServicioNombre;        
                point.LegendText = item.ServicioNombre;        
            }

            pieChartReservas.Series.Add(series);
            pieChartReservas.Legends.Add(new System.Windows.Forms.DataVisualization.Charting.Legend("Leyenda"));
        }

    }
}
