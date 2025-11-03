using Datos;
using Negocio;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for WindowCleanerComprobante.xaml
    /// </summary>
    public partial class WindowCleanerComprobante : Window
    {
        private Reserva reservaSeleccionada;
        private Comprobante comprobanteGenerado;
        private NReserva nReserva = new NReserva();
        private NComprobante nComprobante = new NComprobante();
        private NServicio nServicio = new NServicio();

        public WindowCleanerComprobante(Reserva reserva, Comprobante comprobante)
        {
            InitializeComponent();
            this.reservaSeleccionada = reserva;
            this.comprobanteGenerado = comprobante;
            MostrarInformacion();
            GenerarComprobanteQR(); 
        }

        private void MostrarInformacion()
        {
            tbOrden.Text = $"Orden N° {comprobanteGenerado.ComprobanteId}";
            tbCleaner.Text = reservaSeleccionada.Cleaner.CleanerNombre;
            tbFecha.Text = comprobanteGenerado.ComprobanteFechaEmision.ToString("dd/MM/yyyy");
            tbMonto.Text = $"S/ {comprobanteGenerado.ComprobanteMontoTotal:0.00}";
        }

        private async void GenerarComprobanteQR()
        {
            try
            {
                var preview = new WindowComprobantePreview(comprobanteGenerado, reservaSeleccionada);
                preview.SetearDatos();

                preview.WindowStartupLocation = WindowStartupLocation.Manual;
                preview.Left = -3000;
                preview.Top = -3000;
                preview.Show();

                bool renderizado = false;
                preview.ContentRendered += (s, e) => { renderizado = true; };

                while (!renderizado)
                {
                    await Task.Delay(50);
                }

                preview.UpdateLayout();

                var rtb = new RenderTargetBitmap(
                    (int)preview.ActualWidth,
                    (int)preview.ActualHeight,
                    96, 96,
                    PixelFormats.Pbgra32);
                rtb.Render(preview);

                string ruta = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"comp_{comprobanteGenerado.ComprobanteId}.png");
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(rtb));
                using (var fs = new FileStream(ruta, FileMode.Create))
                {
                    encoder.Save(fs);
                }

                preview.Close();

                string url = await SubirImagenAImgBB(ruta);
                Bitmap qr = GenerarQR(url);
                imgQR.Source = ConvertirBitmapAImageSource(qr);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el QR: {ex.Message}");
            }
        }

        public async Task<string> SubirImagenAImgBB(string ruta)
        {
            using (var client = new HttpClient())
            {
                var bytes = File.ReadAllBytes(ruta);
                var base64 = Convert.ToBase64String(bytes);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("key", "ae6d243c5d324d77b9f52e1163389dc9"),
                    new KeyValuePair<string, string>("image", base64)
                });

                var response = await client.PostAsync("https://api.imgbb.com/1/upload", content);
                var json = await response.Content.ReadAsStringAsync();

                dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                return obj.data.url;
            }
        }

        public Bitmap GenerarQR(string url)
        {
            QRCodeGenerator gen = new QRCodeGenerator();
            QRCodeData data = gen.CreateQrCode(url, QRCodeGenerator.ECCLevel.Q);
            QRCode qr = new QRCode(data);
            return qr.GetGraphic(20);
        }

        public ImageSource ConvertirBitmapAImageSource(Bitmap bmp)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bmp.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private void BtnVolver(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
