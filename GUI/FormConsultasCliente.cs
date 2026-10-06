using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormConsultasCliente : Form
    {
        private ClienteBLL bll = new ClienteBLL();
        private DataSet dsClientes;
        
        public FormConsultasCliente()
        {
            InitializeComponent();
        }

        private DataGridViewCellStyle BuildHeaderStyle()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(0, 131, 143);
            style.ForeColor = Color.White;
            style.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style.Padding = new Padding(5, 0, 0, 0);
            return style;
        }

        private DataGridViewCellStyle BuildCellStyle()
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

        private void CargarTodo()
        {
            dsClientes = bll.ListarDataSet();
            dgvConsulta.DataSource = dsClientes.Tables["Clientes"];
        }

        private void FormConsultasCliente_Load(object sender, EventArgs e)
        {
            dgvConsulta.ColumnHeadersDefaultCellStyle = BuildHeaderStyle();
            dgvConsulta.DefaultCellStyle = BuildCellStyle();
            CargarTodo();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dni = string.IsNullOrWhiteSpace(txtDni.Text) ? null : txtDni.Text.Trim();
            string nombre = string.IsNullOrWhiteSpace(txtNombre.Text) ? null : txtNombre.Text.Trim();
            string apellido = string.IsNullOrWhiteSpace(txtBuscarApellido.Text) ? null : txtBuscarApellido.Text.Trim();
            string telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();

            if (dni == null && nombre == null && apellido == null && telefono == null)
            {
                dgvConsulta.DataSource = dsClientes.Tables["Clientes"];
                return;
            }

            DataTable filtrado = bll.Buscar(dsClientes, dni, nombre, apellido, telefono);
            dgvConsulta.DataSource = filtrado;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtBuscarApellido.Clear();
            txtTelefono.Clear();
            dgvConsulta.DataSource = dsClientes.Tables["Clientes"];
        }
    }
}
