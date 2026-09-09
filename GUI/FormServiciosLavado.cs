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
    public partial class FormServiciosLavado : Form
    {
        private ServicioLavadoBLL bll = new ServicioLavadoBLL();
        private List<ServiIndividual> serviciosDisponibles;
        public FormServiciosLavado()
        {
            InitializeComponent();
        }

        private void FormServiciosLavado_Load(object sender, EventArgs e)
        {
            CargarArbol();
            CargarComponentesDisponibles();
        }

        private void CargarArbol()
        {
            trvArbol.Nodes.Clear();
            var arbol = bll.Listar();

            foreach (IComponenteServicio item in arbol)
            {
                if (item is PaqueteServicio paquete)
                {
                    var nodoCombo = new TreeNode($"[COMBO] {paquete}")
                    {
                        Tag = paquete // <-- clave: guarda el objeto real
                    };
                    foreach (var componente in paquete.Componentes)
                    {
                        nodoCombo.Nodes.Add(new TreeNode(componente.ToString())
                        {
                            Tag = componente // <-- clave
                        });
                    }
                    trvArbol.Nodes.Add(nodoCombo);
                }
                else
                {
                    trvArbol.Nodes.Add(new TreeNode(item.ToString())
                    {
                        Tag = item // <-- clave
                    });
                }
            }
            trvArbol.CollapseAll();
        }

        private void CargarComponentesDisponibles()
        {
            serviciosDisponibles = bll.ListarServiciosIndividuales();

            clbComponentes.Items.Clear();
            foreach (var servicio in serviciosDisponibles)
            {
                clbComponentes.Items.Add(servicio.ToString());
            }
        }

        private void btnAgregarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreServicio.Text.Trim();

                if (!decimal.TryParse(txtPrecioServicio.Text, out decimal precio))
                    throw new Exception("El precio ingresado no es válido");

                bll.AgregarServicioIndividual(nombre, precio);

                txtNombreServicio.Clear();
                txtPrecioServicio.Clear();

                CargarArbol();
                CargarComponentesDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarCombo_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreCombo.Text.Trim();

                if (!decimal.TryParse(txtPrecioCombo.Text, out decimal precioFinal))
                    throw new Exception("El precio del combo no es válido");

                var idsSeleccionados = new List<int>();
                for (int i = 0; i < clbComponentes.Items.Count; i++)
                {
                    if (clbComponentes.GetItemChecked(i))
                    {
                        idsSeleccionados.Add(serviciosDisponibles[i].IdServicio);
                    }
                }

                bll.CrearCombo(nombre, precioFinal, idsSeleccionados);

                txtNombreCombo.Clear();
                txtPrecioCombo.Clear();
                for (int i = 0; i < clbComponentes.Items.Count; i++)
                    clbComponentes.SetItemChecked(i, false);

                CargarArbol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TreeNode nodoSeleccionado = trvArbol.SelectedNode;

            if (nodoSeleccionado == null)
            {
                MessageBox.Show("Seleccioná un servicio o combo del árbol primero.");
                return;
            }

            // Nodo hijo (servicio individual dentro de un combo)
            if (nodoSeleccionado.Parent != null)
            {
                MessageBox.Show(
                    "Este servicio forma parte de un combo. Si querés eliminarlo del catálogo, " +
                    "seleccionalo directamente en la lista principal (no dentro del combo).",
                    "Acción no permitida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            // Blindaje: si por algún motivo el Tag no quedó asignado, avisamos
            // en vez de crashear con NullReferenceException
            IComponenteServicio item = nodoSeleccionado.Tag as IComponenteServicio;

            if (item == null)
            {
                MessageBox.Show(
                    "No se pudo identificar el elemento seleccionado. Volvé a seleccionarlo e intentá de nuevo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int idAEliminar = item is PaqueteServicio paquete
                ? paquete.IdPaquete
                : ((ServiIndividual)item).IdServicio;

            string tipoTexto = item is PaqueteServicio ? "el combo" : "el servicio";

            var confirmar = MessageBox.Show(
                $"¿Seguro que querés eliminar {tipoTexto} \"{nodoSeleccionado.Text}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            try
            {
                bll.Eliminar(idAEliminar);

                CargarArbol();
                CargarComponentesDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
