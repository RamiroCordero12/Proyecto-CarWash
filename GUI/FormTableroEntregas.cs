using BLL;
using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormTableroEntregas : FormBase
    {
        private readonly Alertaentregabll bll = new Alertaentregabll();
        private readonly TurnoBLL turnoBll = new TurnoBLL();

        public FormTableroEntregas()
        {
            InitializeComponent();
            ConfigurarEstilosYTimer();
        }

        private void FormTableroEntregas_Load(object sender, EventArgs e)
        {
            CargarTablero();
            TurnoBLL.EstadoTurnoCambiado += Turno_EstadoCambiado;
        }

        private void FormTableroEntregas_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Desuscribirse del evento estático para evitar fugas de memoria y llamadas duplicadas
            TurnoBLL.EstadoTurnoCambiado -= Turno_EstadoCambiado;
        }

        private void ConfigurarEstilosYTimer()
        {
            dgvEntregas.ColumnHeadersDefaultCellStyle = BuildHeaderStyle();
            dgvEntregas.DefaultCellStyle = BuildCellStyle();

            timerAviso.Interval = 6000;
        }

        private static DataGridViewCellStyle BuildHeaderStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(0, 131, 143);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(5, 0, 0, 0);
            return style;
        }

        private static DataGridViewCellStyle BuildCellStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.White;
            style.ForeColor = Color.FromArgb(55, 71, 79);
            style.Font = new Font("Segoe UI", 9.5F);
            style.SelectionBackColor = Color.FromArgb(178, 235, 242);
            style.SelectionForeColor = Color.FromArgb(38, 50, 56);
            style.Padding = new Padding(5, 0, 0, 0);
            return style;
        }

        // ==================== PATRÓN OBSERVER ====================
        // Recibe las notificaciones de cambio de estado de los turnos en tiempo real
        private void Turno_EstadoCambiado(object sender, TurnoEventArgs e)
        {
            if (IsDisposed) return;
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => Turno_EstadoCambiado(sender, e)));
                return;
            }

            CargarTablero();

            if (e.Turno.Estado == EstadoTurno.LavadoTerminado)
            {
                MostrarAviso(
                    $"✔  {e.Turno.Patente} terminó el lavado y está listo para entregar",
                    Color.FromArgb(224, 242, 241),
                    Color.FromArgb(0, 105, 92));
                try { SystemSounds.Asterisk.Play(); } catch { }
            }
            else if (e.Turno.Estado == EstadoTurno.Entregado)
            {
                MostrarAviso(
                    $"🚗  Vehículo {e.Turno.Patente} entregado exitosamente al cliente",
                    Color.FromArgb(232, 245, 233),
                    Color.FromArgb(46, 125, 50));
            }
        }

        private void MostrarAviso(string mensaje, Color backColor, Color foreColor)
        {
            lblAviso.Text = mensaje;
            panelAviso.BackColor = backColor;
            lblAviso.ForeColor = foreColor;
            panelAviso.Visible = true;
            timerAviso.Stop();
            timerAviso.Start();
        }

        private void timerAviso_Tick(object sender, EventArgs e)
        {
            panelAviso.Visible = false;
            timerAviso.Stop();
        }

        private void lblCerrarAviso_Click(object sender, EventArgs e)
        {
            panelAviso.Visible = false;
            timerAviso.Stop();
        }

        private void CargarTablero()
        {
            try
            {
                var lista = bll.ListarPendientes();
                dgvEntregas.DataSource = null;
                dgvEntregas.DataSource = lista;

                OcultarColumna("IdAlerta");
                OcultarColumna("IdTurno");
                Encabezado("Patente", "Patente");
                Encabezado("Marca", "Marca");
                Encabezado("Color", "Color");
                Encabezado("NombreCliente", "Cliente");
                Encabezado("Telefono", "Teléfono");
                Encabezado("NombreServicio", "Servicio");
                Encabezado("NombreOperador", "Operario");
                Encabezado("FechaCompletado", "Terminado a las");
                if (dgvEntregas.Columns["FechaCompletado"] != null)
                    dgvEntregas.Columns["FechaCompletado"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

                if (lista.Count > 0)
                {
                    lblContador.Text = $"Listos para entrega: {lista.Count}";
                    lblContador.ForeColor = Color.FromArgb(0, 121, 107);
                    lblContador.BackColor = Color.FromArgb(224, 242, 241);
                    dgvEntregas.Rows[0].Selected = true;
                }
                else
                {
                    lblContador.Text = "No hay vehículos esperando entrega";
                    lblContador.ForeColor = Color.FromArgb(120, 144, 156);
                    lblContador.BackColor = Color.FromArgb(240, 244, 248);
                    dgvEntregas.ClearSelection();
                }

                ActualizarDetalleSeleccionado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar tablero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarDetalleSeleccionado()
        {
            Alertaentrega alerta = dgvEntregas.CurrentRow?.DataBoundItem as Alertaentrega;
            if (alerta != null)
            {
                lblDetallePatente.Text = alerta.Patente;
                lblDetalleVehiculo.Text = $"{alerta.Marca}  ·  Color: {alerta.Color}";
                lblDetalleCliente.Text = alerta.NombreCliente;
                lblDetalleTelefono.Text = string.IsNullOrWhiteSpace(alerta.Telefono) ? "(Sin teléfono)" : alerta.Telefono;
                lblDetalleServicio.Text = alerta.NombreServicio;
                lblDetalleOperador.Text = $"Operario: {alerta.NombreOperador}";
                btnEntregar.Enabled = true;
            }
            else
            {
                lblDetallePatente.Text = "---";
                lblDetalleVehiculo.Text = "Seleccioná un vehículo de la grilla";
                lblDetalleCliente.Text = "-";
                lblDetalleTelefono.Text = "-";
                lblDetalleServicio.Text = "-";
                lblDetalleOperador.Text = "";
                btnEntregar.Enabled = false;
            }
        }

        private void dgvEntregas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarDetalleSeleccionado();
        }

        private void dgvEntregas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ActualizarDetalleSeleccionado();
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            Alertaentrega alerta = dgvEntregas.CurrentRow?.DataBoundItem as Alertaentrega;
            if (alerta == null)
            {
                MessageBox.Show("Seleccioná un vehículo del tablero primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Confirmás la entrega del vehículo con patente {alerta.Patente} al cliente {alerta.NombreCliente}?",
                "Confirmar Entrega de Vehículo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes) return;

            try
            {
                Turno turno = new Turno
                {
                    IdTurno = alerta.IdTurno,
                    Patente = alerta.Patente,
                    Estado = EstadoTurno.LavadoTerminado
                };
                turnoBll.AvanzarEstado(turno);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al entregar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarTablero();
        }

        private void OcultarColumna(string nombre)
        {
            if (dgvEntregas.Columns[nombre] != null) dgvEntregas.Columns[nombre].Visible = false;
        }

        private void Encabezado(string nombre, string texto)
        {
            if (dgvEntregas.Columns[nombre] != null) dgvEntregas.Columns[nombre].HeaderText = texto;
        }

        // ==================== ESTILOS VISUALES ROUNDED CARDS ====================
        private void panelDetalle_Paint(object sender, PaintEventArgs e)
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

        private void panelAviso_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(Color.FromArgb(165, 214, 167), 1))
            {
                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                int radius = 6;
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
    }
}
