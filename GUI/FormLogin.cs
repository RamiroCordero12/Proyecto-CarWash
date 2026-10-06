using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using CarWash.BE;

namespace GUI
{
    public partial class FormLogin : Form
    {
        private LoginBLL bll = new LoginBLL();
        public Usuario UsuarioLogueado { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioLogueado = bll.IniciarSesion(txtNombreUsuario.Text.Trim(), txtContraseña.Text);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
        }

        private void FormLogin_Paint(object sender, PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(10, 22, 40), Color.FromArgb(26, 41, 64), 90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
    }
}
