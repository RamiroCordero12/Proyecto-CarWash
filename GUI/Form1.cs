using BLL;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AplicarPermisos();
        }

        public void AplicarPermisos()
        {
            var sesion = SesionActual.Instancia;
            var usuario = sesion?.UsuarioLogueado;
            var rol = sesion?.RolActivo;

            if (usuario == null || rol == null)
            {
                lblUsuarioSesion.Text = "👤 Invitado\n🔑 Sin Rol";
                return;
            }

            lblUsuarioSesion.Text = $"👤 {usuario.NombreUsuario} ({usuario.NombreCompleto})\n🔑 Rol: {rol.NombreRol}";

            // Determinar si es un Administrador
            bool esAdmin = rol.NombreRol.IndexOf("Admin", StringComparison.OrdinalIgnoreCase) >= 0;

            // CU13, CU14, CU15, CU16: Seguridad y administración restringida por rol/permisos
            bool tienePermisoOperarios = esAdmin || sesion.TienePermiso(6);    // Hoja: Operarios
            bool tienePermisoBitacora = esAdmin || sesion.TienePermiso(7);     // Hoja: Bitacora
            bool tienePermisoEstadisticas = esAdmin || sesion.TienePermiso(8); // Hoja: Estadisticas
            bool tienePermisoSeguridad = esAdmin || sesion.TienePermiso(9);    // Hoja: Seguridad (Usuarios + Roles)
            bool tienePermisoBackup = esAdmin || sesion.TienePermiso(10);      // Hoja: Backup

            // Módulos administrativos: visibilidad según permisos
            button1.Visible = tienePermisoOperarios;           // Operarios
            btnMenuBitacora.Visible = tienePermisoBitacora;     // Bitácora
            btnEstadisticas.Visible = tienePermisoEstadisticas; // Estadísticas
            btnUsuarios.Visible = tienePermisoSeguridad;       // Usuarios (CU16)
            btnRoles.Visible = tienePermisoSeguridad;          // Roles y Permisos (CU13, CU14, CU15)
            btnBackup.Visible = tienePermisoBackup;            // Backup y Restore (CU17, CU18)
        }

        private void gestorDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes c = new FormClientes();
            c.ShowDialog();
        }

        private void formConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormConsultasCliente f = new FormConsultasCliente();
            f.ShowDialog();
        }

        private void formBitacoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora b = new FormBitacora();
            b.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirmar = MessageBox.Show(
                "¿Seguro que querés cerrar sesión?",
                "Cerrar sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmar != DialogResult.Yes)
                return;

            foreach (Form hijo in this.MdiChildren)
            {
                hijo.Close();
            }

            if (tableroEntregasAbierto != null && !tableroEntregasAbierto.IsDisposed)
            {
                tableroEntregasAbierto.Close();
                tableroEntregasAbierto = null;
            }

            var bll = new LoginBLL();
            bll.CerrarSesion();

            this.Hide();

            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    AplicarPermisos();
                    this.Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void formVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVehiculos f = new FormVehiculos();
            f.ShowDialog();
        }

        private void formServiciosLavadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormServiciosLavado f = new FormServiciosLavado();
            f.ShowDialog();
        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOperador fo = new FormOperador();
            fo.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTurnos ft = new FormTurnos();
            ft.ShowDialog();
        }

        private FormTableroEntregas tableroEntregasAbierto = null;

        private void btnTableroEntregas_Click(object sender, EventArgs e)
        {
            if (tableroEntregasAbierto == null || tableroEntregasAbierto.IsDisposed)
            {
                tableroEntregasAbierto = new FormTableroEntregas();
                tableroEntregasAbierto.Show();
            }
            else
            {
                if (tableroEntregasAbierto.WindowState == FormWindowState.Minimized)
                    tableroEntregasAbierto.WindowState = FormWindowState.Normal;
                tableroEntregasAbierto.BringToFront();
                tableroEntregasAbierto.Focus();
            }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            FormEstadisticas fe = new FormEstadisticas();
            fe.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios fu = new FormGestionUsuarios();
            fu.ShowDialog();
        }

        private void btnRoles_Click(object sender, EventArgs e)
        {
            FormGestionRoles fr = new FormGestionRoles();
            fr.ShowDialog();
            // Si el rol activo del usuario actual fue modificado, re-aplicar permisos
            AplicarPermisos();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FormBackup fb = new FormBackup();
            fb.ShowDialog();
        }
    }
}
