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
    public partial class FormOperador : Form
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
    }
}
