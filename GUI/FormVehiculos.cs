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
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = bll.Listar();
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVehiculos.CurrentRow == null) return;

            Vehiculo v = (Vehiculo)dgvVehiculos.CurrentRow.DataBoundItem;

            idVehiculoSeleccionado = v.IdVehiculo;
            txtDni.Text = v.DNI.ToString();
            txtPatente.Text = v.Patente;
            txtMarca.Text = v.Marca;
            txtColor.Text = v.Color;

            // El tipo no se puede editar una vez creado (ver nota en VehiculoDAL.Modificar)
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
                MessageBox.Show("Seleccioná un vehículo de la grilla primero.");
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
                MessageBox.Show("Seleccioná un vehículo de la grilla primero.");
                return;
            }

            try
            {
                // Recreamos el objeto del tipo correcto (no se puede mutar
                // el tipo concreto de un objeto ya instanciado)
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

        private void LimpiarCampos()
        {
            idVehiculoSeleccionado = 0;
            txtDni.Clear();
            txtPatente.Clear();
            txtMarca.Clear();
            txtColor.Clear();
            cmbModelo.Enabled = true;
            cmbModelo.SelectedIndex = 0;
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = null;
            dgvClientes.DataSource = c.Listar();
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            Cliente c = (Cliente)dgvClientes.CurrentRow.DataBoundItem;
            txtDni.Text = c.DNI;
        }
    }
}
