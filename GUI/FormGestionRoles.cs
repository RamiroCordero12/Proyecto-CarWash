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
    public partial class FormGestionRoles : Form
    {
        private PermisoBLL permisoBLL = new PermisoBLL();

        private List<Rol> listaRoles = new List<Rol>();
        private List<Familia> arbolFamilias = new List<Familia>();
        private List<Hoja> todasLasHojas = new List<Hoja>();

        private Rol rolSeleccionado = null;
        private Familia familiaSeleccionada = null;

        public FormGestionRoles()
        {
            InitializeComponent();
        }

        private void FormGestionRoles_Load(object sender, EventArgs e)
        {
            RefrescarTodo();
        }

        private void RefrescarTodo()
        {
            CargarDatosBase();
            CargarRoles();
            CargarCatalogosFamiliasHojas();
        }

        private void CargarDatosBase()
        {
            todasLasHojas = permisoBLL.ListarHojas();
            arbolFamilias = permisoBLL.ConstruirArbolFamilias();
        }

        #region Pestaña 1: Roles y Asignaciones (CU13 y CU15)

        private void CargarRoles()
        {
            try
            {
                listaRoles = permisoBLL.ListarRoles();
                lstRoles.DataSource = null;
                lstRoles.DataSource = listaRoles;
                lstRoles.DisplayMember = "NombreRol";
                lstRoles.ValueMember = "CodRol";

                if (listaRoles.Count > 0)
                    lstRoles.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            rolSeleccionado = lstRoles.SelectedItem as Rol;
            if (rolSeleccionado == null) return;

            txtNombreRol.Text = rolSeleccionado.NombreRol;
            txtDescRol.Text = rolSeleccionado.DescRol ?? "";

            CargarCheckListsRol();
            ConstruirArbolJerarquiaRol();
        }

        private void CargarCheckListsRol()
        {
            if (rolSeleccionado == null) return;

            var codFamiliasAsignadas = permisoBLL.ListarFamiliasDeRol(rolSeleccionado.CodRol);
            var codHojasAsignadas = permisoBLL.ListarHojasDeRol(rolSeleccionado.CodRol);

            // Familias
            clbFamiliasRol.Items.Clear();
            foreach (var fam in arbolFamilias)
            {
                bool asignada = codFamiliasAsignadas.Contains(fam.CodFam);
                clbFamiliasRol.Items.Add(fam, asignada);
            }

            // Hojas sueltas
            clbHojasRol.Items.Clear();
            foreach (var hoja in todasLasHojas)
            {
                bool asignada = codHojasAsignadas.Contains(hoja.CodHoja);
                clbHojasRol.Items.Add(hoja, asignada);
            }
        }

        private void ConstruirArbolJerarquiaRol()
        {
            trvPermisosRol.Nodes.Clear();
            if (rolSeleccionado == null) return;

            // Cargar rol completo con sus familias y hojas asignadas
            Rol rolCompleto = permisoBLL.CargarRolCompleto(rolSeleccionado.CodRol, rolSeleccionado.NombreRol, arbolFamilias);

            var rootNode = new TreeNode($"Rol: {rolCompleto.NombreRol}")
            {
                ForeColor = Color.FromArgb(0, 131, 143),
                NodeFont = new Font("Segoe UI", 9.5F, FontStyle.Bold)
            };

            // Familias asignadas
            if (rolCompleto.Familias.Count > 0)
            {
                var nodoFamilias = new TreeNode($"📁 Familias Asignadas ({rolCompleto.Familias.Count})");
                foreach (var fam in rolCompleto.Familias)
                {
                    nodoFamilias.Nodes.Add(GenerarNodoFamilia(fam));
                }
                rootNode.Nodes.Add(nodoFamilias);
            }

            // Hojas sueltas asignadas
            if (rolCompleto.HojasSueltas.Count > 0)
            {
                var nodoHojas = new TreeNode($"🔑 Permisos Directos (Hojas Sueltas - {rolCompleto.HojasSueltas.Count})");
                foreach (var h in rolCompleto.HojasSueltas)
                {
                    nodoHojas.Nodes.Add(new TreeNode($"📄 {h.NombreHoja} (ID {h.CodHoja})"));
                }
                rootNode.Nodes.Add(nodoHojas);
            }

            if (rolCompleto.Familias.Count == 0 && rolCompleto.HojasSueltas.Count == 0)
            {
                rootNode.Nodes.Add(new TreeNode("(Sin permisos asignados)"));
            }

            trvPermisosRol.Nodes.Add(rootNode);
            trvPermisosRol.ExpandAll();
        }

        private TreeNode GenerarNodoFamilia(Familia f)
        {
            var nodo = new TreeNode($"📦 {f.NombreFamilia}");

            // Subfamilias recursivas
            foreach (var sub in f.SubFamilias)
            {
                nodo.Nodes.Add(GenerarNodoFamilia(sub));
            }

            // Hojas contenidas en la familia
            foreach (var h in f.Hojas)
            {
                nodo.Nodes.Add(new TreeNode($"📄 {h.NombreHoja}"));
            }

            return nodo;
        }

        private void btnCrearRol_Click(object sender, EventArgs e)
        {
            try
            {
                var nuevo = new Rol
                {
                    NombreRol = txtNombreRol.Text,
                    DescRol = txtDescRol.Text
                };

                int nuevoId = permisoBLL.CrearRol(nuevo);
                MessageBox.Show($"Rol '{nuevo.NombreRol}' creado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRoles();

                // Seleccionar el recién creado
                for (int i = 0; i < lstRoles.Items.Count; i++)
                {
                    if ((lstRoles.Items[i] as Rol)?.CodRol == nuevoId)
                    {
                        lstRoles.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (rolSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un rol para modificar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                rolSeleccionado.NombreRol = txtNombreRol.Text;
                rolSeleccionado.DescRol = txtDescRol.Text;

                permisoBLL.ModificarRol(rolSeleccionado);
                MessageBox.Show($"Rol '{rolSeleccionado.NombreRol}' actualizado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                int cod = rolSeleccionado.CodRol;
                CargarRoles();
                for (int i = 0; i < lstRoles.Items.Count; i++)
                {
                    if ((lstRoles.Items[i] as Rol)?.CodRol == cod)
                    {
                        lstRoles.SelectedIndex = i;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar rol", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (rolSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un rol para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el rol '{rolSeleccionado.NombreRol}'?\nSe eliminarán sus asignaciones de permisos.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                permisoBLL.EliminarRol(rolSeleccionado.CodRol, rolSeleccionado.NombreRol);
                MessageBox.Show("Rol eliminado correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarPermisosRol_Click(object sender, EventArgs e)
        {
            try
            {
                if (rolSeleccionado == null)
                {
                    MessageBox.Show("Selecciona un rol primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var familiasSeleccionadas = new List<int>();
                foreach (Familia f in clbFamiliasRol.CheckedItems)
                    familiasSeleccionadas.Add(f.CodFam);

                var hojasSeleccionadas = new List<int>();
                foreach (Hoja h in clbHojasRol.CheckedItems)
                    hojasSeleccionadas.Add(h.CodHoja);

                permisoBLL.GuardarPermisosRol(rolSeleccionado.CodRol, rolSeleccionado.NombreRol, familiasSeleccionadas, hojasSeleccionadas);

                MessageBox.Show($"Permisos del Rol '{rolSeleccionado.NombreRol}' actualizados correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refrescar árbol de jerarquía
                CargarDatosBase();
                ConstruirArbolJerarquiaRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Pestaña 2: Familias y Hojas (CU14)

        private void CargarCatalogosFamiliasHojas()
        {
            try
            {
                // Hojas
                lstHojasExistentes.DataSource = null;
                lstHojasExistentes.DataSource = todasLasHojas;
                lstHojasExistentes.DisplayMember = "NombreHoja";
                lstHojasExistentes.ValueMember = "CodHoja";

                // Familias
                lstFamiliasExistentes.DataSource = null;
                lstFamiliasExistentes.DataSource = arbolFamilias;
                lstFamiliasExistentes.DisplayMember = "NombreFamilia";
                lstFamiliasExistentes.ValueMember = "CodFam";

                if (arbolFamilias.Count > 0)
                    lstFamiliasExistentes.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstHojasExistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var hoja = lstHojasExistentes.SelectedItem as Hoja;
            if (hoja != null)
            {
                txtNombreHoja.Text = hoja.NombreHoja;
                txtDescHoja.Text = hoja.DescHoja ?? "";
            }
        }

        private void btnCrearHoja_Click(object sender, EventArgs e)
        {
            try
            {
                var h = new Hoja
                {
                    NombreHoja = txtNombreHoja.Text,
                    DescHoja = txtDescHoja.Text
                };

                permisoBLL.CrearHoja(h);
                MessageBox.Show($"Permiso '{h.NombreHoja}' creado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreHoja.Clear();
                txtDescHoja.Clear();
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarHoja_Click(object sender, EventArgs e)
        {
            try
            {
                var hoja = lstHojasExistentes.SelectedItem as Hoja;
                if (hoja == null)
                {
                    MessageBox.Show("Selecciona un permiso de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el permiso '{hoja.NombreHoja}'?\nSe quitará de todas las familias y roles donde esté asignado.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                permisoBLL.EliminarHoja(hoja.CodHoja, hoja.NombreHoja);
                MessageBox.Show("Permiso eliminado correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreHoja.Clear();
                txtDescHoja.Clear();
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar permiso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstFamiliasExistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            familiaSeleccionada = lstFamiliasExistentes.SelectedItem as Familia;
            if (familiaSeleccionada == null) return;

            txtNombreFam.Text = familiaSeleccionada.NombreFamilia;
            txtDescFam.Text = familiaSeleccionada.DescFamilia ?? "";

            CargarComposicionFamilia();
        }

        private void CargarComposicionFamilia()
        {
            if (familiaSeleccionada == null) return;

            lblCompFamTitle.Text = $"Componer: {familiaSeleccionada.NombreFamilia}";

            var relacionesFamFam = permisoBLL.ListarFamFam();
            var relacionesPatFam = permisoBLL.ListarPatFam();

            var idsSubfamilias = relacionesFamFam
                .Where(r => r.CodFamPadre == familiaSeleccionada.CodFam)
                .Select(r => r.CodFamHijo)
                .ToList();

            var idsHojas = relacionesPatFam
                .Where(r => r.CodFam == familiaSeleccionada.CodFam)
                .Select(r => r.CodHoja)
                .ToList();

            // Subfamilias (no se puede agregar a sí misma)
            clbSubfamilias.Items.Clear();
            foreach (var f in arbolFamilias)
            {
                if (f.CodFam == familiaSeleccionada.CodFam) continue;
                bool contenida = idsSubfamilias.Contains(f.CodFam);
                clbSubfamilias.Items.Add(f, contenida);
            }

            // Hojas
            clbHojasDeFam.Items.Clear();
            foreach (var h in todasLasHojas)
            {
                bool contenida = idsHojas.Contains(h.CodHoja);
                clbHojasDeFam.Items.Add(h, contenida);
            }
        }

        private void btnCrearFam_Click(object sender, EventArgs e)
        {
            try
            {
                var f = new Familia
                {
                    NombreFamilia = txtNombreFam.Text,
                    DescFamilia = txtDescFam.Text
                };

                permisoBLL.CrearFamilia(f);
                MessageBox.Show($"Familia '{f.NombreFamilia}' creada exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreFam.Clear();
                txtDescFam.Clear();
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarFam_Click(object sender, EventArgs e)
        {
            try
            {
                if (familiaSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una familia de la lista.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar la familia '{familiaSeleccionada.NombreFamilia}'?\nSe eliminarán todas sus relaciones de subfamilia y asignaciones.",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm != DialogResult.Yes) return;

                permisoBLL.EliminarFamilia(familiaSeleccionada.CodFam, familiaSeleccionada.NombreFamilia);
                MessageBox.Show("Familia eliminada correctamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNombreFam.Clear();
                txtDescFam.Clear();
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar familia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarComposicionFam_Click(object sender, EventArgs e)
        {
            try
            {
                if (familiaSeleccionada == null)
                {
                    MessageBox.Show("Selecciona una familia primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var subfamilias = new List<int>();
                foreach (Familia f in clbSubfamilias.CheckedItems)
                    subfamilias.Add(f.CodFam);

                var hojas = new List<int>();
                foreach (Hoja h in clbHojasDeFam.CheckedItems)
                    hojas.Add(h.CodHoja);

                permisoBLL.GuardarContenidoFamilia(familiaSeleccionada.CodFam, familiaSeleccionada.NombreFamilia, subfamilias, hojas);

                MessageBox.Show($"Contenido de la Familia '{familiaSeleccionada.NombreFamilia}' guardado exitosamente.", "AquaWash", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefrescarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar contenido de familia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
