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
    public partial class FormTurnos : Form
    {
        private TurnoBLL bll = new TurnoBLL();
        private VehiculoBLL vehiculoBll = new VehiculoBLL();
        private ServicioLavadoBLL servicioBll = new ServicioLavadoBLL();
        private OperadorBLL operadorBll = new OperadorBLL();

        public FormTurnos()
        {
            InitializeComponent();
        }

        private void CargarTurnos()
        {
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = bll.Listar();

            foreach (string col in new[] { "IdVehiculo", "IdServicio", "IdOperario", "IdUsuarioRegistro" })
            {
                if (dgvTurnos.Columns[col] != null) dgvTurnos.Columns[col].Visible = false;
            }
            if (dgvTurnos.Columns["NombreServicio"] != null) dgvTurnos.Columns["NombreServicio"].HeaderText = "Servicio";
            if (dgvTurnos.Columns["NombreOperador"] != null) dgvTurnos.Columns["NombreOperador"].HeaderText = "Operario";
            if (dgvTurnos.Columns["FechaHora"] != null) dgvTurnos.Columns["FechaHora"].HeaderText = "Fecha y hora";
            dgvTurnos.ClearSelection();
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

                CargarTurnos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bll.AvanzarEstado(dgvTurnos.CurrentRow?.DataBoundItem as Turno);
                CargarTurnos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Turno turno = dgvTurnos.CurrentRow?.DataBoundItem as Turno;
            if (turno == null)
            {
                MessageBox.Show("Seleccioná un turno de la grilla primero.");
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LimpiarFormulario()
        {
            ucSelectorCliente2.Limpiar();
            cmbVehiculo.DataSource = null;
            cmbServicio.SelectedIndex = -1;
            cmbOperario.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
            ActualizarPrecio();
        }

        private void ucSelectorCliente2_Load(object sender, EventArgs e)
        {

        }

        private void ucSelectorCliente2_ClienteSeleccionadoChanged(object sender, EventArgs e)
        {           
                try
                {
                    Cliente cliente = ucSelectorCliente2.ClienteSeleccionado;
                    cmbVehiculo.DataSource = null;
                    cmbVehiculo.DataSource = vehiculoBll.ListarPorCliente(cliente.DNI);

                    if (cmbVehiculo.Items.Count == 0)
                        MessageBox.Show("Este cliente no tiene vehículos registrados.", "Aviso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dtpFecha.Value = DateTime.Now;
                CargarTurnos();
                ActualizarPrecio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
