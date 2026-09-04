using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Bitacora;
using CarWash.BE.Bitacora;

namespace GUI
{
    public partial class FormBitacora : Form
    {
        private RegistroBitacoraBLL bll = new RegistroBitacoraBLL();

        public FormBitacora()
        {
            InitializeComponent();
        }

        private void FormBitacora_Load(object sender, EventArgs e)
        {
            // Combo de criticidad: opción "Todas" + los valores del enum
            cmbCriticidad.Items.Add("(Todas)");
            cmbCriticidad.Items.AddRange(Enum.GetNames(typeof(Criticidad)));
            cmbCriticidad.SelectedIndex = 0;

            // Rango por defecto: últimos 30 días
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;

            CargarGrilla();
        }

        private void CargarGrilla(
            string usuario = null, DateTime? desde = null, DateTime? hasta = null,
            Criticidad? criticidad = null, string modulo = null)
        {
            var resultado = bll.Filtrar(usuario, desde, hasta, criticidad, modulo);
            dgvBitacora.DataSource = resultado;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string usuario = string.IsNullOrWhiteSpace(txtUsuario.Text) ? null : txtUsuario.Text.Trim();
            string modulo = string.IsNullOrWhiteSpace(txtModulo.Text) ? null : txtModulo.Text.Trim();

            Criticidad? criticidad = null;
            if (cmbCriticidad.SelectedIndex > 0) // 0 = "(Todas)"
            {
                criticidad = (Criticidad)Enum.Parse(typeof(Criticidad), cmbCriticidad.SelectedItem.ToString());
            }

            CargarGrilla(usuario, dtpDesde.Value.Date, dtpHasta.Value.Date, criticidad, modulo);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtModulo.Clear();
            cmbCriticidad.SelectedIndex = 0;
            dtpDesde.Value = DateTime.Today.AddDays(-30);
            dtpHasta.Value = DateTime.Today;
            CargarGrilla();
        }
    }
}
