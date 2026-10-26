namespace GUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRoles = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnEstadisticas = new System.Windows.Forms.Button();
            this.btnTableroEntregas = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnMenuBitacora = new System.Windows.Forms.Button();
            this.btnMenuConsultas = new System.Windows.Forms.Button();
            this.btnMenuServicios = new System.Windows.Forms.Button();
            this.btnMenuVehiculos = new System.Windows.Forms.Button();
            this.btnMenuClientes = new System.Windows.Forms.Button();
            this.panelIdioma = new System.Windows.Forms.Panel();
            this.lblIdiomaTag = new System.Windows.Forms.Label();
            this.cmbIdioma = new System.Windows.Forms.ComboBox();
            this.panelUserBadge = new System.Windows.Forms.Panel();
            this.lblUsuarioSesion = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelIdioma.SuspendLayout();
            this.panelUserBadge.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelSidebar
            // 
            this.panelSidebar.AutoScroll = true;
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.btnBackup);
            this.panelSidebar.Controls.Add(this.btnRoles);
            this.panelSidebar.Controls.Add(this.btnUsuarios);
            this.panelSidebar.Controls.Add(this.btnEstadisticas);
            this.panelSidebar.Controls.Add(this.btnTableroEntregas);
            this.panelSidebar.Controls.Add(this.button2);
            this.panelSidebar.Controls.Add(this.button1);
            this.panelSidebar.Controls.Add(this.btnMenuBitacora);
            this.panelSidebar.Controls.Add(this.btnMenuConsultas);
            this.panelSidebar.Controls.Add(this.btnMenuServicios);
            this.panelSidebar.Controls.Add(this.btnMenuVehiculos);
            this.panelSidebar.Controls.Add(this.btnMenuClientes);
            this.panelSidebar.Controls.Add(this.panelIdioma);
            this.panelSidebar.Controls.Add(this.panelUserBadge);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.panelSeparator);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(235, 680);
            this.panelSidebar.TabIndex = 0;
            this.panelSidebar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSidebar_Paint);

            // 
            // btnBackup
            // 
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnBackup.Location = new System.Drawing.Point(0, 567);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnBackup.Size = new System.Drawing.Size(235, 42);
            this.btnBackup.TabIndex = 14;
            this.btnBackup.Text = "  💾  Backup / Restore";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);

            // 
            // btnRoles
            // 
            this.btnRoles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoles.FlatAppearance.BorderSize = 0;
            this.btnRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRoles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnRoles.Location = new System.Drawing.Point(0, 525);
            this.btnRoles.Name = "btnRoles";
            this.btnRoles.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnRoles.Size = new System.Drawing.Size(235, 42);
            this.btnRoles.TabIndex = 13;
            this.btnRoles.Text = "  🛡️  Roles y Permisos";
            this.btnRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoles.UseVisualStyleBackColor = false;
            this.btnRoles.Click += new System.EventHandler(this.btnRoles_Click);

            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnUsuarios.Location = new System.Drawing.Point(0, 483);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(235, 42);
            this.btnUsuarios.TabIndex = 12;
            this.btnUsuarios.Text = "  👥  Usuarios";
            this.btnUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);

            // 
            // btnEstadisticas
            // 
            this.btnEstadisticas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadisticas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstadisticas.FlatAppearance.BorderSize = 0;
            this.btnEstadisticas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadisticas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnEstadisticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnEstadisticas.Location = new System.Drawing.Point(0, 441);
            this.btnEstadisticas.Name = "btnEstadisticas";
            this.btnEstadisticas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnEstadisticas.Size = new System.Drawing.Size(235, 42);
            this.btnEstadisticas.TabIndex = 11;
            this.btnEstadisticas.Text = "  📊  Estadísticas";
            this.btnEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEstadisticas.UseVisualStyleBackColor = false;
            this.btnEstadisticas.Click += new System.EventHandler(this.btnEstadisticas_Click);

            // 
            // btnTableroEntregas
            // 
            this.btnTableroEntregas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTableroEntregas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTableroEntregas.FlatAppearance.BorderSize = 0;
            this.btnTableroEntregas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableroEntregas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnTableroEntregas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnTableroEntregas.Location = new System.Drawing.Point(0, 399);
            this.btnTableroEntregas.Name = "btnTableroEntregas";
            this.btnTableroEntregas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnTableroEntregas.Size = new System.Drawing.Size(235, 42);
            this.btnTableroEntregas.TabIndex = 10;
            this.btnTableroEntregas.Text = "  🚗  Tablero Entregas";
            this.btnTableroEntregas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableroEntregas.UseVisualStyleBackColor = false;
            this.btnTableroEntregas.Click += new System.EventHandler(this.btnTableroEntregas_Click);

            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button2.Location = new System.Drawing.Point(0, 357);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button2.Size = new System.Drawing.Size(235, 42);
            this.button2.TabIndex = 9;
            this.button2.Text = "  📅  Turnos";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.button1.Location = new System.Drawing.Point(0, 315);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(235, 42);
            this.button1.TabIndex = 8;
            this.button1.Text = "  👷  Operarios";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);

            // 
            // btnMenuBitacora
            // 
            this.btnMenuBitacora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBitacora.FlatAppearance.BorderSize = 0;
            this.btnMenuBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBitacora.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuBitacora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuBitacora.Location = new System.Drawing.Point(0, 273);
            this.btnMenuBitacora.Name = "btnMenuBitacora";
            this.btnMenuBitacora.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenuBitacora.Size = new System.Drawing.Size(235, 42);
            this.btnMenuBitacora.TabIndex = 6;
            this.btnMenuBitacora.Text = "  📋  Bitácora";
            this.btnMenuBitacora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuBitacora.UseVisualStyleBackColor = false;
            this.btnMenuBitacora.Click += new System.EventHandler(this.formBitacoraToolStripMenuItem_Click);

            // 
            // btnMenuConsultas
            // 
            this.btnMenuConsultas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuConsultas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuConsultas.FlatAppearance.BorderSize = 0;
            this.btnMenuConsultas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuConsultas.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuConsultas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuConsultas.Location = new System.Drawing.Point(0, 231);
            this.btnMenuConsultas.Name = "btnMenuConsultas";
            this.btnMenuConsultas.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenuConsultas.Size = new System.Drawing.Size(235, 42);
            this.btnMenuConsultas.TabIndex = 5;
            this.btnMenuConsultas.Text = "  🔍  Consultas";
            this.btnMenuConsultas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuConsultas.UseVisualStyleBackColor = false;
            this.btnMenuConsultas.Click += new System.EventHandler(this.formConsultasToolStripMenuItem_Click);

            // 
            // btnMenuServicios
            // 
            this.btnMenuServicios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuServicios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuServicios.FlatAppearance.BorderSize = 0;
            this.btnMenuServicios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuServicios.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuServicios.Location = new System.Drawing.Point(0, 189);
            this.btnMenuServicios.Name = "btnMenuServicios";
            this.btnMenuServicios.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenuServicios.Size = new System.Drawing.Size(235, 42);
            this.btnMenuServicios.TabIndex = 4;
            this.btnMenuServicios.Text = "  🧽  Servicios y Combos";
            this.btnMenuServicios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuServicios.UseVisualStyleBackColor = false;
            this.btnMenuServicios.Click += new System.EventHandler(this.formServiciosLavadosToolStripMenuItem_Click);

            // 
            // btnMenuVehiculos
            // 
            this.btnMenuVehiculos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuVehiculos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuVehiculos.FlatAppearance.BorderSize = 0;
            this.btnMenuVehiculos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuVehiculos.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuVehiculos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuVehiculos.Location = new System.Drawing.Point(0, 147);
            this.btnMenuVehiculos.Name = "btnMenuVehiculos";
            this.btnMenuVehiculos.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenuVehiculos.Size = new System.Drawing.Size(235, 42);
            this.btnMenuVehiculos.TabIndex = 3;
            this.btnMenuVehiculos.Text = "  🚗  Vehículos";
            this.btnMenuVehiculos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuVehiculos.UseVisualStyleBackColor = false;
            this.btnMenuVehiculos.Click += new System.EventHandler(this.formVehiculosToolStripMenuItem_Click);

            // 
            // btnMenuClientes
            // 
            this.btnMenuClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuClientes.FlatAppearance.BorderSize = 0;
            this.btnMenuClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMenuClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuClientes.Location = new System.Drawing.Point(0, 105);
            this.btnMenuClientes.Name = "btnMenuClientes";
            this.btnMenuClientes.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnMenuClientes.Size = new System.Drawing.Size(235, 42);
            this.btnMenuClientes.TabIndex = 2;
            this.btnMenuClientes.Text = "  👤  Clientes";
            this.btnMenuClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuClientes.UseVisualStyleBackColor = false;
            this.btnMenuClientes.Click += new System.EventHandler(this.gestorDeClientesToolStripMenuItem_Click);

            // 
            // panelIdioma
            // 
            this.panelIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.panelIdioma.Controls.Add(this.cmbIdioma);
            this.panelIdioma.Controls.Add(this.lblIdiomaTag);
            this.panelIdioma.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelIdioma.Location = new System.Drawing.Point(0, 545);
            this.panelIdioma.Name = "panelIdioma";
            this.panelIdioma.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelIdioma.Size = new System.Drawing.Size(235, 35);
            this.panelIdioma.TabIndex = 16;

            // 
            // lblIdiomaTag
            // 
            this.lblIdiomaTag.AutoSize = true;
            this.lblIdiomaTag.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdiomaTag.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.lblIdiomaTag.Location = new System.Drawing.Point(10, 8);
            this.lblIdiomaTag.Name = "lblIdiomaTag";
            this.lblIdiomaTag.Size = new System.Drawing.Size(58, 15);
            this.lblIdiomaTag.TabIndex = 0;
            this.lblIdiomaTag.Text = "🌐 Idioma:";

            // 
            // cmbIdioma
            // 
            this.cmbIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdioma.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbIdioma.FormattingEnabled = true;
            this.cmbIdioma.Items.AddRange(new object[] {
            "Español",
            "English"});
            this.cmbIdioma.Location = new System.Drawing.Point(85, 5);
            this.cmbIdioma.Name = "cmbIdioma";
            this.cmbIdioma.Size = new System.Drawing.Size(140, 23);
            this.cmbIdioma.TabIndex = 1;
            this.cmbIdioma.SelectedIndexChanged += new System.EventHandler(this.cmbIdioma_SelectedIndexChanged);

            // 
            // panelUserBadge
            // 
            this.panelUserBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.panelUserBadge.Controls.Add(this.lblUsuarioSesion);
            this.panelUserBadge.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelUserBadge.Location = new System.Drawing.Point(0, 580);
            this.panelUserBadge.Name = "panelUserBadge";
            this.panelUserBadge.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.panelUserBadge.Size = new System.Drawing.Size(235, 50);
            this.panelUserBadge.TabIndex = 15;

            // 
            // lblUsuarioSesion
            // 
            this.lblUsuarioSesion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuarioSesion.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioSesion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lblUsuarioSesion.Location = new System.Drawing.Point(10, 5);
            this.lblUsuarioSesion.Name = "lblUsuarioSesion";
            this.lblUsuarioSesion.Size = new System.Drawing.Size(215, 40);
            this.lblUsuarioSesion.TabIndex = 0;
            this.lblUsuarioSesion.Text = "👤 Usuario\n🔑 Rol";
            this.lblUsuarioSesion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 630);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(235, 45);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "  🚪  Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Location = new System.Drawing.Point(0, 80);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(235, 2);
            this.panelSeparator.TabIndex = 1;

            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.panelLogo.Controls.Add(this.lblVersion);
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(235, 80);
            this.panelLogo.TabIndex = 0;

            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblVersion.Location = new System.Drawing.Point(25, 45);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(93, 13);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "Panel de Control";

            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.lblLogo.Location = new System.Drawing.Point(12, 15);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(184, 30);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "💧 AQUA WASH";

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1150, 680);
            this.Controls.Add(this.panelSidebar);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🚿 AquaWash Pro — Panel Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelIdioma.ResumeLayout(false);
            this.panelIdioma.PerformLayout();
            this.panelUserBadge.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Button btnMenuClientes;
        private System.Windows.Forms.Button btnMenuVehiculos;
        private System.Windows.Forms.Button btnMenuServicios;
        private System.Windows.Forms.Button btnMenuConsultas;
        private System.Windows.Forms.Button btnMenuBitacora;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnTableroEntregas;
        private System.Windows.Forms.Button btnEstadisticas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnRoles;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Panel panelIdioma;
        private System.Windows.Forms.Label lblIdiomaTag;
        private System.Windows.Forms.ComboBox cmbIdioma;
        private System.Windows.Forms.Panel panelUserBadge;
        private System.Windows.Forms.Label lblUsuarioSesion;
    }
}
