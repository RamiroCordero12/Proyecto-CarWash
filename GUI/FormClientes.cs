using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void FormClientes_Load_1(object sender, EventArgs e)
        {
            CargarClientes();
        }
    }
}
