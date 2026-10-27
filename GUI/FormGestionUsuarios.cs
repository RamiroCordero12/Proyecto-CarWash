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
    public partial class FormGestionUsuarios : FormBase
    {
        private UsuarioBLL usuarioBLL = new UsuarioBLL();
        private PermisoBLL permisoBLL = new PermisoBLL();
        private int? idUsuarioSeleccionado = null;

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasGrilla();
            CargarComboRoles();
            CargarUsuarios();
            LimpiarFormulario();
        }

        private void ConfigurarColumnasGrilla()
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvUsuarios.Columns.Clear();

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "IdUsuario",
                HeaderText = "ID",
                Width = 45
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreUsuario",
                HeaderText = "Usuario",
                Width = 100
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NombreCompleto",
                HeaderText = "Nombre y Apellido",
                Width = 140
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Width = 140
            });

            dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ColRol",
                HeaderText = "Rol",
                Width = 100
            });
        }

        private void CargarComboRoles()
        {
            try
            {
                var roles = permisoBLL.ListarRoles();
                cmbRol.DataSource = roles;
                cmbRol.DisplayMember = "NombreRol";
                cmbRol.ValueMember = "CodRol";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                var usuarios = usuarioBLL.Listar();
                dgvUsuarios.Rows.Clear();

                foreach (var u in usuarios)
                {
                    int rowIndex = dgvUsuarios.Rows.Add(
                        u.IdUsuario,
                        u.NombreUsuario,
                        u.NombreCompleto,
                        u.Email ?? "-",
                        u.Rol?.NombreRol ?? "Sin Rol"
                    );
                    dgvUsuarios.Rows[rowIndex].Tag = u;
                }

                lblTotalUsuarios.Text = $"Total de usuarios registrados: {usuarios.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al listar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUsuarios.Rows.Count) return;

            var usuario = dgvUsuarios.Rows[e.RowIndex].Tag as Usuario;
            if (usuario != null)
            {
                idUsuarioSeleccionado = usuario.IdUsuario;
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtEmail.Text = usuario.Email ?? "";
                txtUsuario.Text = usuario.NombreUsuario;
                txtContrasena.Clear();
                cmbRol.SelectedValue = usuario.CodRol;

                btnAgregar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbRol.SelectedValue == null)
                    throw new Exception("Debes seleccionar un rol para el usuario.");

                var usuario = new Usuario
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    NombreUsuario = txtUsuario.Text,
                    CodRol = (int)cmbRol.SelectedValue
                };

                usuarioBLL.Agregar(usuario, txtContrasena.Text);

                MessageBox.Show($"Usuario '{usuario.NombreUsuario}' creado correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!idUsuarioSeleccionado.HasValue)
                {
                    MessageBox.Show("Selecciona un usuario de la grilla para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbRol.SelectedValue == null)
                    throw new Exception("Debes seleccionar un rol para el usuario.");

                var usuario = new Usuario
                {
                    IdUsuario = idUsuarioSeleccionado.Value,
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                    NombreUsuario = txtUsuario.Text,
                    CodRol = (int)cmbRol.SelectedValue
                };

                usuarioBLL.Modificar(usuario, txtContrasena.Text);

                MessageBox.Show($"Usuario '{usuario.NombreUsuario}' modificado correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!idUsuarioSeleccionado.HasValue)
                {
                    MessageBox.Show("Selecciona un usuario de la grilla para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string nombreUser = txtUsuario.Text;
                var confirmacion = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar al usuario '{nombreUser}'?\nEsta acción no se puede deshacer.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion != DialogResult.Yes) return;

                usuarioBLL.Eliminar(idUsuarioSeleccionado.Value, nombreUser);

                MessageBox.Show($"Usuario '{nombreUser}' eliminado correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            idUsuarioSeleccionado = null;
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            if (cmbRol.Items.Count > 0)
                cmbRol.SelectedIndex = 0;

            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dgvUsuarios.ClearSelection();
        }
    }
}
