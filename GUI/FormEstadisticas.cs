using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;
using CarWash.BE;

namespace GUI
{
    public partial class FormEstadisticas : FormBase
    {
        private readonly EstadisticaBLL bll = new EstadisticaBLL();

        // Paleta corporativa armónica AquaWash para los gráficos
        private readonly Color[] paletaColores = new Color[]
        {
            Color.FromArgb(0, 131, 143),    // Teal corporativo
            Color.FromArgb(255, 143, 0),    // Ámbar
            Color.FromArgb(0, 150, 136),    // Emerald
            Color.FromArgb(30, 136, 229),   // Azul
            Color.FromArgb(230, 74, 25),    // Coral
            Color.FromArgb(142, 36, 170),   // Violeta
            Color.FromArgb(67, 160, 71),    // Verde
            Color.FromArgb(120, 144, 156)   // Slate
        };

        public FormEstadisticas()
        {
            InitializeComponent();
        }

        private void FormEstadisticas_Load(object sender, EventArgs e)
        {
            InicializarCombosPeriodo();
            CargarEstadisticas();
        }

        private void InicializarCombosPeriodo()
        {
            cmbMes.Items.Clear();
            string[] nombresMeses = DateTimeFormatInfo.CurrentInfo.MonthNames;
            for (int i = 0; i < 12; i++)
            {
                cmbMes.Items.Add(new MesItem { Numero = i + 1, Nombre = Capitalizar(nombresMeses[i]) });
            }

            cmbAnio.Items.Clear();
            int anioActual = DateTime.Today.Year;
            for (int a = anioActual - 3; a <= anioActual + 1; a++)
            {
                cmbAnio.Items.Add(a);
            }

            // Seleccionar mes y año actuales
            cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            cmbAnio.SelectedItem = anioActual;
        }

        private void CargarEstadisticas()
        {
            if (cmbMes.SelectedItem == null || cmbAnio.SelectedItem == null)
                return;

            int mes = ((MesItem)cmbMes.SelectedItem).Numero;
            int anio = (int)cmbAnio.SelectedItem;

            DateTime fechaDesde = new DateTime(anio, mes, 1);
            DateTime fechaHasta = fechaDesde.AddMonths(1).AddDays(-1);

            try
            {
                // 1. Cargar KPIs superiores
                bll.ObtenerResumenMes(mes, anio, out decimal totalFacturado, out int totalTurnos, out decimal promedioTicket);
                lblTotalFacturado.Text = totalFacturado.ToString("C2", new CultureInfo("es-AR"));
                lblTotalTurnos.Text = totalTurnos == 1 ? "1 servicio" : $"{totalTurnos} servicios";
                lblTicketPromedio.Text = promedioTicket.ToString("C2", new CultureInfo("es-AR"));

                // 2. Cargar Gráfico 1: Facturación acumulada por día
                CargarChartFacturacionDiaria(fechaDesde, fechaHasta);

                // 3. Cargar Gráfico 2: Servicios más contratados del mes
                CargarChartServiciosMasContratados(mes, anio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar estadísticas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarChartFacturacionDiaria(DateTime desde, DateTime hasta)
        {
            var datos = bll.ListarFacturacionPorDia(desde, hasta);

            chartFacturacion.Series["Facturacion"].Points.Clear();
            chartFacturacion.ChartAreas["ChartAreaFacturacion"].AxisX.Interval = 2;

            if (datos.Count == 0)
            {
                // Punto ilustrativo en 0 si no hay turnos
                DataPoint pVacio = new DataPoint();
                pVacio.SetValueXY(desde.ToString("dd/MM"), 0);
                chartFacturacion.Series["Facturacion"].Points.Add(pVacio);
                return;
            }

            decimal acumulado = 0;
            foreach (var item in datos)
            {
                acumulado += item.TotalFacturado;

                int pIndex = chartFacturacion.Series["Facturacion"].Points.AddXY(
                    item.Fecha.ToString("dd/MM"),
                    item.TotalFacturado);

                DataPoint p = chartFacturacion.Series["Facturacion"].Points[pIndex];
                p.ToolTip = $"{item.Fecha:dd/MM/yyyy}\nFacturación: {item.TotalFacturado:C2}\nTurnos: {item.CantidadTurnos}\nAcumulado mes: {acumulado:C2}";
                p.Label = item.TotalFacturado > 0 ? $"{item.TotalFacturado:C0}" : "";
                p.Color = Color.FromArgb(0, 150, 136);
            }
        }

        private void CargarChartServiciosMasContratados(int mes, int anio)
        {
            var datos = bll.ListarServiciosMasContratados(mes, anio);

            chartServicios.Series["Servicios"].Points.Clear();

            if (datos.Count == 0)
            {
                int pIndex = chartServicios.Series["Servicios"].Points.AddXY("Sin datos en el mes", 1);
                chartServicios.Series["Servicios"].Points[pIndex].Color = Color.FromArgb(207, 216, 220);
                chartServicios.Series["Servicios"].Points[pIndex].LegendText = "Sin turnos registrados";
                return;
            }

            int colorIndex = 0;
            foreach (var item in datos)
            {
                int pIndex = chartServicios.Series["Servicios"].Points.AddXY(item.Servicio, item.Cantidad);
                DataPoint p = chartServicios.Series["Servicios"].Points[pIndex];
                p.Color = paletaColores[colorIndex % paletaColores.Length];
                p.LegendText = $"{item.Servicio} ({item.Cantidad})";
                p.ToolTip = $"{item.Servicio}: {item.Cantidad} turnos ({item.TotalRecaudado:C2})";
                p.Label = item.Cantidad.ToString();
                colorIndex++;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarEstadisticas();
        }

        private void btnMesActual_Click(object sender, EventArgs e)
        {
            cmbMes.SelectedIndex = DateTime.Today.Month - 1;
            cmbAnio.SelectedItem = DateTime.Today.Year;
            CargarEstadisticas();
        }

        // ==================== ESTILOS VISUALES ROUNDED CARDS ====================
        private void PanelBordeRedondeado_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(210, 215, 220), 1))
            {
                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                int radius = 8;
                using (GraphicsPath path = RoundedRect(rect, radius))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private static string Capitalizar(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return texto;
            return char.ToUpper(texto[0]) + texto.Substring(1);
        }

        private class MesItem
        {
            public int Numero { get; set; }
            public string Nombre { get; set; }
            public override string ToString() => Nombre;
        }
    }
}
