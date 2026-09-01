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
        private void CargarTodo()
        {
            dsClientes = bll.ListarDataSet();
            dgvConsulta.DataSource = dsClientes.Tables["Clientes"];
        }
        private void FormConsultasCliente_Load(object sender, EventArgs e)
        {
            CargarTodo();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string apellido = txtBuscarApellido.Text.Trim();

            if(string.IsNullOrWhiteSpace(apellido))
            {
                dgvConsulta.DataSource = dsClientes.Tables["Clientes"];
                return;
            }

            DataTable filtrado = bll.BuscarPorApellido(dsClientes, apellido);
            dgvConsulta.DataSource = filtrado;


        }
    }
}
