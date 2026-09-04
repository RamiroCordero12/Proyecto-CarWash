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
                // Ya NO crea Form1 acá — se lo dejamos a quien abrió este FormLogin
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContraseña.Clear();
                txtContraseña.Focus();
            }
            //try
            //{
            //    UsuarioLogueado = bll.IniciarSesion(txtNombreUsuario.Text.Trim(), txtContraseña.Text);
            //    this.DialogResult = DialogResult.OK;
            //    Form1 mainForm = new Form1(); 
            //    mainForm.Show();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error de acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtContraseña.Clear();
            //    txtContraseña.Focus();
            //}
        }
    }
}
