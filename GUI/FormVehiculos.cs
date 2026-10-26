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
using BLL;
using CarWash.BE;

namespace GUI
{
    public partial class FormVehiculos : Form
    {
        private VehiculoBLL bll = new VehiculoBLL();
        private int idVehiculoSeleccionado = 0;
        private ClienteBLL c = new ClienteBLL();

        public FormVehiculos()
        {
            InitializeComponent();
        }

        private void FormVehiculos_Load(object sender, EventArgs e)
        {
            cmbModelo.Items.Add("Sedan");
            cmbModelo.Items.Add("SUV_Camioneta");
            cmbModelo.SelectedIndex = 0;
            CargarVehiculos();
            CargarClientes();
        }

        private void CargarVehiculos()
        {
            var lista = bll.Listar();
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = lista;
            lblTotalVehiculos.Text = $"Total: {lista.Count}";
            dgvVehiculos.ClearSelection();
        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarVehiculoSeleccionado();
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarVehiculoSeleccionado();
        }

        private void CargarVehiculoSeleccionado()
        {
            if (dgvVehiculos.CurrentRow == null) return;
            Vehiculo v = dgvVehiculos.CurrentRow.DataBoundItem as Vehiculo;
            if (v == null) return;

            idVehiculoSeleccionado = v.IdVehiculo;
            txtDni.Text = v.DNI.ToString();
            txtPatente.Text = v.Patente;
            txtMarca.Text = v.Marca;
            txtColor.Text = v.Color;
            cmbModelo.SelectedItem = v.Tipo;
            cmbModelo.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Vehiculo nuevo = bll.CrearPorTipo(cmbModelo.SelectedItem?.ToString());
                nuevo.DNI = int.Parse(txtDni.Text.Trim());
                nuevo.Patente = txtPatente.Text.Trim().ToUpper();
                nuevo.Marca = txtMarca.Text.Trim();
                nuevo.Color = txtColor.Text.Trim();
                bll.Agregar(nuevo);
                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idVehiculoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccioná un vehículo de la grilla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                bll.Eliminar(idVehiculoSeleccionado);
                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idVehiculoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccioná un vehículo de la grilla primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Vehiculo editado = bll.CrearPorTipo(cmbModelo.SelectedItem?.ToString());
                editado.IdVehiculo = idVehiculoSeleccionado;
                editado.DNI = int.Parse(txtDni.Text.Trim());
                editado.Patente = txtPatente.Text.Trim().ToUpper();
                editado.Marca = txtMarca.Text.Trim();
                editado.Color = txtColor.Text.Trim();
                bll.Modificar(editado);
                CargarVehiculos();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            idVehiculoSeleccionado = 0;
            txtDni.Clear();
            txtPatente.Clear();
            txtMarca.Clear();
            txtColor.Clear();
            cmbModelo.Enabled = true;
            cmbModelo.SelectedIndex = 0;
            dgvVehiculos.ClearSelection();
        }

        // ==================== CU07: FILTRAR VEHÍCULOS POR CLIENTE ====================
        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            EjecutarFiltroPorDni();
        }

        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtFiltroDni.Clear();
            CargarVehiculos();
        }

        private void txtFiltroDni_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                EjecutarFiltroPorDni();
            }
        }

        private void EjecutarFiltroPorDni()
        {
            string dni = txtFiltroDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni))
            {
                CargarVehiculos();
                return;
            }

            try
            {
                var filtrados = bll.ListarPorCliente(dni);
                dgvVehiculos.DataSource = null;
                dgvVehiculos.DataSource = filtrados;
                lblTotalVehiculos.Text = $"{filtrados.Count} veh.";

                if (filtrados.Count == 0)
                {
                    MessageBox.Show(
                        $"No se encontraron vehículos registrados para el cliente con DNI {dni}.",
                        "Sin resultados",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al filtrar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ==================== GRILLA DE CLIENTES AUXILIAR ====================
        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = c.Listar();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;
            Cliente cli = dgvClientes.CurrentRow.DataBoundItem as Cliente;
            if (cli != null)
            {
                txtDni.Text = cli.DNI;
                txtFiltroDni.Text = cli.DNI; // Sincroniza el DNI para permitir filtrar vehículos con 1 click
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClientes_CellClick(sender, e);
        }

        // ==================== ESTILOS VISUALES ROUNDED CARDS ====================
        private void panelForm_Paint(object sender, PaintEventArgs e)
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
    }
}
