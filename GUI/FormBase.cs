using BLL.Idioma;
using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public class FormBase : Form, IIdiomaObserver
    
    {
        private class Par { public string Original; public string Aplicado; }

        private readonly Dictionary<object, Par> _textos = new Dictionary<object, Par>();
        private readonly HashSet<DataGridView> _grillasEnlazadas = new HashSet<DataGridView>();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); // acá corre el Load del form hijo, que ya cargó sus datos
            if (DesignMode) return;

            IdiomaManager.Instancia.Suscribir(this);
            ActualizarIdioma();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Importante: desuscribirse, si no el Manager retiene el form cerrado
            IdiomaManager.Instancia.Desuscribir(this);
            base.OnFormClosed(e);
        }

        // IIdiomaObserver
        public virtual void ActualizarIdioma()
        {
            if (IsDisposed) return;
            Text = Traducir(this, Text);
            TraducirControles(Controls);
        }

        private void TraducirControles(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                // Solo controles que muestran texto fijo; los TextBox/Combo/Date tienen datos del usuario
                if (c is Label || c is ButtonBase || c is GroupBox || c is TabPage)
                {
                    c.Text = Traducir(c, c.Text);
                }
                else if (c is DataGridView)
                {
                    TraducirGrilla((DataGridView)c);
                }

                if (c.HasChildren)
                    TraducirControles(c.Controls);
            }
        }

        private void TraducirGrilla(DataGridView dgv)
        {
            // Las columnas se (re)crean cada vez que se asigna el DataSource: hay que retraducir ahí.
            // BeginInvoke para correr DESPUÉS de que el form termine de renombrar sus encabezados.
            if (_grillasEnlazadas.Add(dgv))
            {
                dgv.DataBindingComplete += (s, e) =>
                {
                    if (!IsDisposed && IsHandleCreated)
                        BeginInvoke(new Action(() => TraducirEncabezados(dgv)));
                };
            }
            TraducirEncabezados(dgv);
        }

        private void TraducirEncabezados(DataGridView dgv)
        {
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderText = Traducir(col, col.HeaderText);
            }
        }

        // Devuelve el texto traducido y lo recuerda junto con el original
        private string Traducir(object clave, string textoActual)
        {
            if (string.IsNullOrEmpty(textoActual)) return textoActual;

            Par par;
            if (!_textos.TryGetValue(clave, out par))
            {
                par = new Par { Original = textoActual };
                _textos[clave] = par;
            }
            else if (textoActual != par.Aplicado)
            {
                // El código del form cambió el texto después de traducirlo: ese es el nuevo original
                par.Original = textoActual;
            }

            par.Aplicado = IdiomaManager.Instancia.TraducirTexto(par.Original);
            return par.Aplicado;
        }
    }

}

