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
    public partial class FormOperador : FormBase
    {
        private OperadorBLL bll = new OperadorBLL();
        private int idSeleccionado = 0;
        public FormOperador()
        {
            InitializeComponent();
        }

        private void FormOperador_Load(object sender, EventArgs e)
        {
            CargarOperarios();
        }

        private void CargarOperarios()
        {
            dgvOperarios.DataSource = null;
            dgvOperarios.DataSource = bll.Listar();

            // Operador tiene propiedades que la tabla no guarda; las ocultamos
            if (dgvOperarios.Columns["Especialidad"] != null) dgvOperarios.Columns["Especialidad"].Visible = false;
            if (dgvOperarios.Columns["Estado"] != null) dgvOperarios.Columns["Estado"].Visible = false;
            if (dgvOperarios.Columns["Turnos"] != null) dgvOperarios.Columns["Turnos"].Visible = false;

            dgvOperarios.ClearSelection();
        }

        private void dgvOperarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOperarios.CurrentRow == null) return;

            Operador op = dgvOperarios.CurrentRow.DataBoundItem as Operador;
            if (op == null) return;

            idSeleccionado = op.IDOperador;
            txtNombre.Text = op.Nombre;
            txtComision.Text = op.PorcentajeComision.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Operador nuevo = LeerFormulario();

                bll.Agregar(nuevo);
                CargarOperarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccioná un operador de la grilla primero.");
                return;
            }

            try
            {
                Operador editado = LeerFormulario();
                editado.IDOperador = idSeleccionado;

                bll.Modificar(editado);
                CargarOperarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado <= 0)
            {
                MessageBox.Show("Seleccioná un operador de la grilla primero.");
                return;
            }

            var confirmar = MessageBox.Show(
                $"¿Seguro que querés eliminar a \"{txtNombre.Text}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                bll.Eliminar(idSeleccionado);
                CargarOperarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private Operador LeerFormulario()
        {
            if (!decimal.TryParse(txtComision.Text.Trim(), out decimal comision))
                throw new Exception("La comisión ingresada no es un número válido");

            return new Operador
            {
                Nombre = txtNombre.Text.Trim(),
                PorcentajeComision = comision
            };
        }

        private void LimpiarCampos()
        {
            idSeleccionado = 0;
            txtNombre.Clear();
            txtComision.Clear();
            dgvOperarios.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        /// <summary>
        /// Builds the header cell style for the DataGridView.
        /// </summary>
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

        /// <summary>
        /// Builds the default cell style for the DataGridView.
        /// </summary>
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

        /// <summary>
        /// Draws a subtle rounded border and shadow around the form panel.
        /// </summary>
        private void panelFormulario_Paint(object sender, PaintEventArgs e)
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

        /// <summary>
        /// Helper to build a rounded rectangle path.
        /// </summary>
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
