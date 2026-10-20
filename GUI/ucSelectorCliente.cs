using BLL;
using CarWash.BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ucSelectorCliente : UserControl
    {
        private ClienteBLL bll = new ClienteBLL();

        // El formulario que lo usa se suscribe a este evento
        public event EventHandler ClienteSeleccionadoChanged;

        public Cliente ClienteSeleccionado { get; private set; }

        public ucSelectorCliente()
        {
            InitializeComponent();
        }

        private void ucSelectorCliente_Load(object sender, EventArgs e)
        {
            // DesignMode evita ir a la base cuando el control se arrastra en el diseñador
            if (!DesignMode) Recargar();
        }
        public void Recargar()
        {
            dgvClientes.DataSource = bll.FiltrarPorTexto(txtBuscar.Text);
            dgvClientes.ClearSelection();
        }

        public void Limpiar()
        {
            txtBuscar.Clear();
            ClienteSeleccionado = null;
            Recargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Recargar();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            ClienteSeleccionado = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
            ClienteSeleccionadoChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
