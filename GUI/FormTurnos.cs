using BLL;
using CarWash.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormTurnos : Form
    {
        private TurnoBLL bll = new TurnoBLL();
        private VehiculoBLL vehiculoBll = new VehiculoBLL();
        private ServicioLavadoBLL servicioBll = new ServicioLavadoBLL();
        private OperadorBLL operadorBll = new OperadorBLL();
        private Turno turnoSeleccionado = null;

        public FormTurnos()
        {
            InitializeComponent();
        }

        private void CargarTurnos(List<Turno> turnos = null)
        {
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = turnos ?? bll.Listar();

            foreach (string col in new[] { "IdVehiculo", "IdServicio", "IdOperario", "IdUsuarioRegistro" })
            {
                if (dgvTurnos.Columns[col] != null) dgvTurnos.Columns[col].Visible = false;
            }
            if (dgvTurnos.Columns["IdTurno"] != null) dgvTurnos.Columns["IdTurno"].HeaderText = "ID";
            if (dgvTurnos.Columns["NombreServicio"] != null) dgvTurnos.Columns["NombreServicio"].HeaderText = "Servicio";
            if (dgvTurnos.Columns["NombreOperador"] != null) dgvTurnos.Columns["NombreOperador"].HeaderText = "Operario";
            if (dgvTurnos.Columns["FechaHora"] != null) dgvTurnos.Columns["FechaHora"].HeaderText = "Fecha y hora";
            if (dgvTurnos.Columns["Precio"] != null) dgvTurnos.Columns["Precio"].DefaultCellStyle.Format = "C2";

            dgvTurnos.ClearSelection();
            turnoSeleccionado = null;
            ActualizarBotonesSeleccion();
        }

        private void ActualizarBotonesSeleccion()
        {
            bool haySeleccion = turnoSeleccionado != null;
            btnModificarTurno.Enabled = haySeleccion && turnoSeleccionado.Estado != EstadoTurno.Entregado && turnoSeleccionado.Estado != EstadoTurno.Cancelado;
            btnEliminarTurno.Enabled = haySeleccion && turnoSeleccionado.Estado != EstadoTurno.Entregado && turnoSeleccionado.Estado != EstadoTurno.LavadoTerminado;
        }

        private void ActualizarPrecio_Evento(object sender, EventArgs e)
        {
            ActualizarPrecio();
        }

        private void ActualizarPrecio()
        {
            Vehiculo vehiculo = cmbVehiculo.SelectedItem as Vehiculo;
            IComponenteServicio servicio = cmbServicio.SelectedItem as IComponenteServicio;

            lblPrecio.Text = (vehiculo == null || servicio == null)
                ? "$ 0,00"
                : bll.CalcularPrecio(vehiculo, servicio).ToString("C2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bll.Agregar(
                    cmbVehiculo.SelectedItem as Vehiculo,
                    cmbServicio.SelectedItem as IComponenteServicio,
                    cmbOperario.SelectedItem as Operador,
                    dtpFecha.Value);

                MessageBox.Show("Turno registrado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (turnoSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un turno de la grilla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bll.Modificar(
                    turnoSeleccionado,
                    cmbVehiculo.SelectedItem as Vehiculo,
                    cmbServicio.SelectedItem as IComponenteServicio,
                    cmbOperario.SelectedItem as Operador,
                    dtpFecha.Value);

                MessageBox.Show($"Turno ID {turnoSeleccionado.IdTurno} modificado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar turno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                if (turnoSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un turno de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el turno ID {turnoSeleccionado.IdTurno} ({turnoSeleccionado.Patente})?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes) return;

                bll.Eliminar(turnoSeleccionado);
                MessageBox.Show("Turno eliminado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar turno", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var turno = dgvTurnos.CurrentRow?.DataBoundItem as Turno;
                if (turno == null)
                {
                    MessageBox.Show("Seleccioná un turno de la grilla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bll.AvanzarEstado(turno);
                CargarTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al avanzar estado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Turno turno = dgvTurnos.CurrentRow?.DataBoundItem as Turno;
            if (turno == null)
            {
                MessageBox.Show("Seleccioná un turno de la grilla primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Seguro que querés cancelar el turno de {turno.Patente}?",
                "Cancelar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                bll.Cancelar(turno);
                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                string estado = cmbFiltroEstado.Text;
                string patente = txtFiltroPatente.Text.Trim();

                var resultados = bll.Filtrar(estado, patente);
                CargarTurnos(resultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al filtrar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            cmbFiltroEstado.SelectedIndex = 0;
            txtFiltroPatente.Clear();
            CargarTurnos();
        }

        private void btnLimpiarCampos_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            turnoSeleccionado = null;
            ucSelectorCliente2.Limpiar();
            cmbVehiculo.DataSource = null;
            cmbServicio.SelectedIndex = -1;
            cmbOperario.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            ActualizarPrecio();
            ActualizarBotonesSeleccion();
            dgvTurnos.ClearSelection();
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTurnos.Rows.Count) return;

            turnoSeleccionado = dgvTurnos.Rows[e.RowIndex].DataBoundItem as Turno;
            if (turnoSeleccionado == null) return;

            try
            {
                dtpFecha.Value = turnoSeleccionado.FechaHora;

                // Seleccionar servicio
                for (int i = 0; i < cmbServicio.Items.Count; i++)
                {
                    if (cmbServicio.Items[i] is IComponenteServicio serv && ObtenerNombreServicio(serv) == turnoSeleccionado.NombreServicio)
                    {
                        cmbServicio.SelectedIndex = i;
                        break;
                    }
                }

                // Seleccionar operario
                for (int i = 0; i < cmbOperario.Items.Count; i++)
                {
                    if (cmbOperario.Items[i] is Operador op && op.Nombre == turnoSeleccionado.NombreOperador)
                    {
                        cmbOperario.SelectedIndex = i;
                        break;
                    }
                }

                ActualizarPrecio();
            }
            catch { }

            ActualizarBotonesSeleccion();
        }

        private void ucSelectorCliente2_Load(object sender, EventArgs e)
        {
        }

        private void ucSelectorCliente2_ClienteSeleccionadoChanged(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = ucSelectorCliente2.ClienteSeleccionado;
                if (cliente != null)
                {
                    cmbVehiculo.DataSource = null;
                    cmbVehiculo.DataSource = vehiculoBll.ListarPorCliente(cliente.DNI);

                    if (cmbVehiculo.Items.Count == 0)
                        MessageBox.Show("Este cliente no tiene vehículos registrados.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormTurnos_Load_1(object sender, EventArgs e)
        {
            try
            {
                cmbServicio.DataSource = servicioBll.ListarParaTurno();
                cmbOperario.DataSource = operadorBll.Listar();
                cmbServicio.SelectedIndex = -1;
                cmbOperario.SelectedIndex = -1;
                cmbFiltroEstado.SelectedIndex = 0;
                dtpFecha.Value = DateTime.Now;
                CargarTurnos();
                ActualizarPrecio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void panelDatosTurno_Paint(object sender, PaintEventArgs e)
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

        private static string ObtenerNombreServicio(IComponenteServicio servicio)
        {
            if (servicio is PaqueteServicio p) return p.Nombre;
            if (servicio is ServiIndividual s) return s.Nombre;
            return servicio?.ObtenerDescripcion();
        }

        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
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
