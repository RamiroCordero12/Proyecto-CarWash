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
using CarWash.BE;
using BLL;

namespace GUI
{
    public partial class FormClientes : Form
    {

        private ClienteBLL bll = new ClienteBLL();

        public FormClientes()
        {
            InitializeComponent();
            CargarClientes();
            dgvClientes.ClearSelection(); // para que no quede nada seleccionado al iniciar
        }

        public void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = bll.Listar();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            Cliente cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;

            txtDni.Text = cliente.DNI;
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente()
            {
                DNI = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Telefono = txtTelefono.Text.Trim()
            };

            bll.Agregar(nuevo);
            CargarClientes();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                Cliente cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                bll.Eliminar(cliente.DNI);
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                Cliente cliente = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Apellido = txtApellido.Text.Trim();
                cliente.Telefono = txtTelefono.Text.Trim();

                bll.Modificar(cliente);
                CargarClientes();
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            dgvClientes.ClearSelection();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void FormClientes_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
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
