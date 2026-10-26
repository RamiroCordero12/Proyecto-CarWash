namespace GUI
{
    partial class FormGestionRoles
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.tabControlSeguridad = new System.Windows.Forms.TabControl();
            this.tabRoles = new System.Windows.Forms.TabPage();
            this.panelRolesCard = new System.Windows.Forms.Panel();
            this.lblRolesTitle = new System.Windows.Forms.Label();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.lblNombreRol = new System.Windows.Forms.Label();
            this.txtNombreRol = new System.Windows.Forms.TextBox();
            this.lblDescRol = new System.Windows.Forms.Label();
            this.txtDescRol = new System.Windows.Forms.TextBox();
            this.btnCrearRol = new System.Windows.Forms.Button();
            this.btnModificarRol = new System.Windows.Forms.Button();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.panelAsignacion = new System.Windows.Forms.Panel();
            this.lblAsignacionTitle = new System.Windows.Forms.Label();
            this.lblFamilias = new System.Windows.Forms.Label();
            this.clbFamiliasRol = new System.Windows.Forms.CheckedListBox();
            this.lblHojas = new System.Windows.Forms.Label();
            this.clbHojasRol = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarPermisosRol = new System.Windows.Forms.Button();
            this.lblArbolTitle = new System.Windows.Forms.Label();
            this.trvPermisosRol = new System.Windows.Forms.TreeView();
            this.tabFamiliasHojas = new System.Windows.Forms.TabPage();
            this.panelCrearHoja = new System.Windows.Forms.Panel();
            this.lblCrearHojaTitle = new System.Windows.Forms.Label();
            this.lblNombreHoja = new System.Windows.Forms.Label();
            this.txtNombreHoja = new System.Windows.Forms.TextBox();
            this.lblDescHoja = new System.Windows.Forms.Label();
            this.txtDescHoja = new System.Windows.Forms.TextBox();
            this.btnCrearHoja = new System.Windows.Forms.Button();
            this.btnEliminarHoja = new System.Windows.Forms.Button();
            this.lstHojasExistentes = new System.Windows.Forms.ListBox();
            this.panelCrearFam = new System.Windows.Forms.Panel();
            this.lblCrearFamTitle = new System.Windows.Forms.Label();
            this.lblNombreFam = new System.Windows.Forms.Label();
            this.txtNombreFam = new System.Windows.Forms.TextBox();
            this.lblDescFam = new System.Windows.Forms.Label();
            this.txtDescFam = new System.Windows.Forms.TextBox();
            this.btnCrearFam = new System.Windows.Forms.Button();
            this.btnEliminarFam = new System.Windows.Forms.Button();
            this.lstFamiliasExistentes = new System.Windows.Forms.ListBox();
            this.panelComposicionFam = new System.Windows.Forms.Panel();
            this.lblCompFamTitle = new System.Windows.Forms.Label();
            this.lblSubfamilias = new System.Windows.Forms.Label();
            this.clbSubfamilias = new System.Windows.Forms.CheckedListBox();
            this.lblHojasDeFam = new System.Windows.Forms.Label();
            this.clbHojasDeFam = new System.Windows.Forms.CheckedListBox();
            this.btnGuardarComposicionFam = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.tabControlSeguridad.SuspendLayout();
            this.tabRoles.SuspendLayout();
            this.panelRolesCard.SuspendLayout();
            this.panelAsignacion.SuspendLayout();
            this.tabFamiliasHojas.SuspendLayout();
            this.panelCrearHoja.SuspendLayout();
            this.panelCrearFam.SuspendLayout();
            this.panelComposicionFam.SuspendLayout();
            this.SuspendLayout();

            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Controls.Add(this.lblSubtitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 65);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(390, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🛡️ Seguridad: Roles y Permisos (Composite)";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(23, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(430, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Administración de Roles (CU13), Hojas/Familias (CU14) y Asignaciones (CU15)";

            // 
            // tabControlSeguridad
            // 
            this.tabControlSeguridad.Controls.Add(this.tabRoles);
            this.tabControlSeguridad.Controls.Add(this.tabFamiliasHojas);
            this.tabControlSeguridad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSeguridad.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.tabControlSeguridad.Location = new System.Drawing.Point(0, 65);
            this.tabControlSeguridad.Name = "tabControlSeguridad";
            this.tabControlSeguridad.SelectedIndex = 0;
            this.tabControlSeguridad.Size = new System.Drawing.Size(1024, 585);
            this.tabControlSeguridad.TabIndex = 1;

            // 
            // tabRoles
            // 
            this.tabRoles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.tabRoles.Controls.Add(this.panelAsignacion);
            this.tabRoles.Controls.Add(this.panelRolesCard);
            this.tabRoles.Location = new System.Drawing.Point(4, 26);
            this.tabRoles.Name = "tabRoles";
            this.tabRoles.Padding = new System.Windows.Forms.Padding(10);
            this.tabRoles.Size = new System.Drawing.Size(1016, 555);
            this.tabRoles.Text = "  Roles y Permisos Asignados (CU13 y CU15)  ";

            // 
            // panelRolesCard
            // 
            this.panelRolesCard.BackColor = System.Drawing.Color.White;
            this.panelRolesCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRolesCard.Controls.Add(this.lblRolesTitle);
            this.panelRolesCard.Controls.Add(this.lstRoles);
            this.panelRolesCard.Controls.Add(this.lblNombreRol);
            this.panelRolesCard.Controls.Add(this.txtNombreRol);
            this.panelRolesCard.Controls.Add(this.lblDescRol);
            this.panelRolesCard.Controls.Add(this.txtDescRol);
            this.panelRolesCard.Controls.Add(this.btnCrearRol);
            this.panelRolesCard.Controls.Add(this.btnModificarRol);
            this.panelRolesCard.Controls.Add(this.btnEliminarRol);
            this.panelRolesCard.Location = new System.Drawing.Point(10, 10);
            this.panelRolesCard.Name = "panelRolesCard";
            this.panelRolesCard.Size = new System.Drawing.Size(320, 530);
            this.panelRolesCard.TabIndex = 0;

            // 
            // lblRolesTitle
            // 
            this.lblRolesTitle.AutoSize = true;
            this.lblRolesTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblRolesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblRolesTitle.Location = new System.Drawing.Point(12, 12);
            this.lblRolesTitle.Name = "lblRolesTitle";
            this.lblRolesTitle.Size = new System.Drawing.Size(130, 20);
            this.lblRolesTitle.TabIndex = 0;
            this.lblRolesTitle.Text = "Catálogo de Roles";

            // 
            // lstRoles
            // 
            this.lstRoles.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.ItemHeight = 17;
            this.lstRoles.Location = new System.Drawing.Point(15, 40);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.Size = new System.Drawing.Size(288, 208);
            this.lstRoles.TabIndex = 1;
            this.lstRoles.SelectedIndexChanged += new System.EventHandler(this.lstRoles_SelectedIndexChanged);

            // 
            // lblNombreRol
            // 
            this.lblNombreRol.AutoSize = true;
            this.lblNombreRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblNombreRol.Location = new System.Drawing.Point(12, 260);
            this.lblNombreRol.Name = "lblNombreRol";
            this.lblNombreRol.Size = new System.Drawing.Size(92, 15);
            this.lblNombreRol.TabIndex = 2;
            this.lblNombreRol.Text = "Nombre del Rol:";

            // 
            // txtNombreRol
            // 
            this.txtNombreRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreRol.Location = new System.Drawing.Point(15, 280);
            this.txtNombreRol.Name = "txtNombreRol";
            this.txtNombreRol.Size = new System.Drawing.Size(288, 24);
            this.txtNombreRol.TabIndex = 3;

            // 
            // lblDescRol
            // 
            this.lblDescRol.AutoSize = true;
            this.lblDescRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDescRol.Location = new System.Drawing.Point(12, 315);
            this.lblDescRol.Name = "lblDescRol";
            this.lblDescRol.Size = new System.Drawing.Size(72, 15);
            this.lblDescRol.TabIndex = 4;
            this.lblDescRol.Text = "Descripción:";

            // 
            // txtDescRol
            // 
            this.txtDescRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescRol.Location = new System.Drawing.Point(15, 335);
            this.txtDescRol.Multiline = true;
            this.txtDescRol.Name = "txtDescRol";
            this.txtDescRol.Size = new System.Drawing.Size(288, 60);
            this.txtDescRol.TabIndex = 5;

            // 
            // btnCrearRol
            // 
            this.btnCrearRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnCrearRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearRol.FlatAppearance.BorderSize = 0;
            this.btnCrearRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrearRol.ForeColor = System.Drawing.Color.White;
            this.btnCrearRol.Location = new System.Drawing.Point(15, 410);
            this.btnCrearRol.Name = "btnCrearRol";
            this.btnCrearRol.Size = new System.Drawing.Size(135, 36);
            this.btnCrearRol.TabIndex = 6;
            this.btnCrearRol.Text = "➕ Crear Rol";
            this.btnCrearRol.UseVisualStyleBackColor = false;
            this.btnCrearRol.Click += new System.EventHandler(this.btnCrearRol_Click);

            // 
            // btnModificarRol
            // 
            this.btnModificarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(136)))), ((int)(((byte)(209)))));
            this.btnModificarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarRol.FlatAppearance.BorderSize = 0;
            this.btnModificarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnModificarRol.ForeColor = System.Drawing.Color.White;
            this.btnModificarRol.Location = new System.Drawing.Point(168, 410);
            this.btnModificarRol.Name = "btnModificarRol";
            this.btnModificarRol.Size = new System.Drawing.Size(135, 36);
            this.btnModificarRol.TabIndex = 7;
            this.btnModificarRol.Text = "✏️ Modificar";
            this.btnModificarRol.UseVisualStyleBackColor = false;
            this.btnModificarRol.Click += new System.EventHandler(this.btnModificarRol_Click);

            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnEliminarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarRol.FlatAppearance.BorderSize = 0;
            this.btnEliminarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRol.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRol.ForeColor = System.Drawing.Color.White;
            this.btnEliminarRol.Location = new System.Drawing.Point(15, 460);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(288, 36);
            this.btnEliminarRol.TabIndex = 8;
            this.btnEliminarRol.Text = "🗑️ Eliminar Rol";
            this.btnEliminarRol.UseVisualStyleBackColor = false;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);

            // 
            // panelAsignacion
            // 
            this.panelAsignacion.BackColor = System.Drawing.Color.White;
            this.panelAsignacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAsignacion.Controls.Add(this.lblAsignacionTitle);
            this.panelAsignacion.Controls.Add(this.lblFamilias);
            this.panelAsignacion.Controls.Add(this.clbFamiliasRol);
            this.panelAsignacion.Controls.Add(this.lblHojas);
            this.panelAsignacion.Controls.Add(this.clbHojasRol);
            this.panelAsignacion.Controls.Add(this.btnGuardarPermisosRol);
            this.panelAsignacion.Controls.Add(this.lblArbolTitle);
            this.panelAsignacion.Controls.Add(this.trvPermisosRol);
            this.panelAsignacion.Location = new System.Drawing.Point(340, 10);
            this.panelAsignacion.Name = "panelAsignacion";
            this.panelAsignacion.Size = new System.Drawing.Size(660, 530);
            this.panelAsignacion.TabIndex = 1;

            // 
            // lblAsignacionTitle
            // 
            this.lblAsignacionTitle.AutoSize = true;
            this.lblAsignacionTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblAsignacionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblAsignacionTitle.Location = new System.Drawing.Point(15, 12);
            this.lblAsignacionTitle.Name = "lblAsignacionTitle";
            this.lblAsignacionTitle.Size = new System.Drawing.Size(340, 20);
            this.lblAsignacionTitle.TabIndex = 0;
            this.lblAsignacionTitle.Text = "Configurar Permisos del Rol Seleccionado (CU15)";

            // 
            // lblFamilias
            // 
            this.lblFamilias.AutoSize = true;
            this.lblFamilias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblFamilias.Location = new System.Drawing.Point(15, 42);
            this.lblFamilias.Name = "lblFamilias";
            this.lblFamilias.Size = new System.Drawing.Size(185, 15);
            this.lblFamilias.TabIndex = 1;
            this.lblFamilias.Text = "Familias de Permisos Asignadas:";

            // 
            // clbFamiliasRol
            // 
            this.clbFamiliasRol.CheckOnClick = true;
            this.clbFamiliasRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbFamiliasRol.FormattingEnabled = true;
            this.clbFamiliasRol.Location = new System.Drawing.Point(18, 62);
            this.clbFamiliasRol.Name = "clbFamiliasRol";
            this.clbFamiliasRol.Size = new System.Drawing.Size(295, 166);
            this.clbFamiliasRol.TabIndex = 2;

            // 
            // lblHojas
            // 
            this.lblHojas.AutoSize = true;
            this.lblHojas.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHojas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblHojas.Location = new System.Drawing.Point(15, 240);
            this.lblHojas.Name = "lblHojas";
            this.lblHojas.Size = new System.Drawing.Size(235, 15);
            this.lblHojas.TabIndex = 3;
            this.lblHojas.Text = "Hojas Sueltas (Permisos Directos del Rol):";

            // 
            // clbHojasRol
            // 
            this.clbHojasRol.CheckOnClick = true;
            this.clbHojasRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbHojasRol.FormattingEnabled = true;
            this.clbHojasRol.Location = new System.Drawing.Point(18, 260);
            this.clbHojasRol.Name = "clbHojasRol";
            this.clbHojasRol.Size = new System.Drawing.Size(295, 184);
            this.clbHojasRol.TabIndex = 4;

            // 
            // btnGuardarPermisosRol
            // 
            this.btnGuardarPermisosRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnGuardarPermisosRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarPermisosRol.FlatAppearance.BorderSize = 0;
            this.btnGuardarPermisosRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPermisosRol.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPermisosRol.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPermisosRol.Location = new System.Drawing.Point(18, 460);
            this.btnGuardarPermisosRol.Name = "btnGuardarPermisosRol";
            this.btnGuardarPermisosRol.Size = new System.Drawing.Size(295, 42);
            this.btnGuardarPermisosRol.TabIndex = 5;
            this.btnGuardarPermisosRol.Text = "💾 Guardar Permisos del Rol";
            this.btnGuardarPermisosRol.UseVisualStyleBackColor = false;
            this.btnGuardarPermisosRol.Click += new System.EventHandler(this.btnGuardarPermisosRol_Click);

            // 
            // lblArbolTitle
            // 
            this.lblArbolTitle.AutoSize = true;
            this.lblArbolTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblArbolTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblArbolTitle.Location = new System.Drawing.Point(335, 42);
            this.lblArbolTitle.Name = "lblArbolTitle";
            this.lblArbolTitle.Size = new System.Drawing.Size(190, 15);
            this.lblArbolTitle.TabIndex = 6;
            this.lblArbolTitle.Text = "Jerarquía Composite del Rol:";

            // 
            // trvPermisosRol
            // 
            this.trvPermisosRol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.trvPermisosRol.Location = new System.Drawing.Point(338, 62);
            this.trvPermisosRol.Name = "trvPermisosRol";
            this.trvPermisosRol.Size = new System.Drawing.Size(305, 440);
            this.trvPermisosRol.TabIndex = 7;

            // 
            // tabFamiliasHojas
            // 
            this.tabFamiliasHojas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.tabFamiliasHojas.Controls.Add(this.panelComposicionFam);
            this.tabFamiliasHojas.Controls.Add(this.panelCrearFam);
            this.tabFamiliasHojas.Controls.Add(this.panelCrearHoja);
            this.tabFamiliasHojas.Location = new System.Drawing.Point(4, 26);
            this.tabFamiliasHojas.Name = "tabFamiliasHojas";
            this.tabFamiliasHojas.Padding = new System.Windows.Forms.Padding(10);
            this.tabFamiliasHojas.Size = new System.Drawing.Size(1016, 555);
            this.tabFamiliasHojas.Text = "  Gestión de Familias y Hojas (CU14)  ";

            // 
            // panelCrearHoja
            // 
            this.panelCrearHoja.BackColor = System.Drawing.Color.White;
            this.panelCrearHoja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCrearHoja.Controls.Add(this.lblCrearHojaTitle);
            this.panelCrearHoja.Controls.Add(this.lstHojasExistentes);
            this.panelCrearHoja.Controls.Add(this.lblNombreHoja);
            this.panelCrearHoja.Controls.Add(this.txtNombreHoja);
            this.panelCrearHoja.Controls.Add(this.lblDescHoja);
            this.panelCrearHoja.Controls.Add(this.txtDescHoja);
            this.panelCrearHoja.Controls.Add(this.btnCrearHoja);
            this.panelCrearHoja.Controls.Add(this.btnEliminarHoja);
            this.panelCrearHoja.Location = new System.Drawing.Point(10, 10);
            this.panelCrearHoja.Name = "panelCrearHoja";
            this.panelCrearHoja.Size = new System.Drawing.Size(315, 530);
            this.panelCrearHoja.TabIndex = 0;

            // 
            // lblCrearHojaTitle
            // 
            this.lblCrearHojaTitle.AutoSize = true;
            this.lblCrearHojaTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCrearHojaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblCrearHojaTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCrearHojaTitle.Name = "lblCrearHojaTitle";
            this.lblCrearHojaTitle.Size = new System.Drawing.Size(200, 20);
            this.lblCrearHojaTitle.TabIndex = 0;
            this.lblCrearHojaTitle.Text = "Permisos Individuales (Hoja)";

            // 
            // lstHojasExistentes
            // 
            this.lstHojasExistentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstHojasExistentes.FormattingEnabled = true;
            this.lstHojasExistentes.ItemHeight = 15;
            this.lstHojasExistentes.Location = new System.Drawing.Point(15, 40);
            this.lstHojasExistentes.Name = "lstHojasExistentes";
            this.lstHojasExistentes.Size = new System.Drawing.Size(283, 229);
            this.lstHojasExistentes.TabIndex = 1;
            this.lstHojasExistentes.SelectedIndexChanged += new System.EventHandler(this.lstHojasExistentes_SelectedIndexChanged);

            // 
            // lblNombreHoja
            // 
            this.lblNombreHoja.AutoSize = true;
            this.lblNombreHoja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreHoja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblNombreHoja.Location = new System.Drawing.Point(12, 280);
            this.lblNombreHoja.Name = "lblNombreHoja";
            this.lblNombreHoja.Size = new System.Drawing.Size(115, 15);
            this.lblNombreHoja.TabIndex = 2;
            this.lblNombreHoja.Text = "Nombre del Permiso:";

            // 
            // txtNombreHoja
            // 
            this.txtNombreHoja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreHoja.Location = new System.Drawing.Point(15, 300);
            this.txtNombreHoja.Name = "txtNombreHoja";
            this.txtNombreHoja.Size = new System.Drawing.Size(283, 24);
            this.txtNombreHoja.TabIndex = 3;

            // 
            // lblDescHoja
            // 
            this.lblDescHoja.AutoSize = true;
            this.lblDescHoja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescHoja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDescHoja.Location = new System.Drawing.Point(12, 335);
            this.lblDescHoja.Name = "lblDescHoja";
            this.lblDescHoja.Size = new System.Drawing.Size(72, 15);
            this.lblDescHoja.TabIndex = 4;
            this.lblDescHoja.Text = "Descripción:";

            // 
            // txtDescHoja
            // 
            this.txtDescHoja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescHoja.Location = new System.Drawing.Point(15, 355);
            this.txtDescHoja.Multiline = true;
            this.txtDescHoja.Name = "txtDescHoja";
            this.txtDescHoja.Size = new System.Drawing.Size(283, 50);
            this.txtDescHoja.TabIndex = 5;

            // 
            // btnCrearHoja
            // 
            this.btnCrearHoja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnCrearHoja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearHoja.FlatAppearance.BorderSize = 0;
            this.btnCrearHoja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearHoja.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrearHoja.ForeColor = System.Drawing.Color.White;
            this.btnCrearHoja.Location = new System.Drawing.Point(15, 420);
            this.btnCrearHoja.Name = "btnCrearHoja";
            this.btnCrearHoja.Size = new System.Drawing.Size(135, 36);
            this.btnCrearHoja.TabIndex = 6;
            this.btnCrearHoja.Text = "➕ Crear Hoja";
            this.btnCrearHoja.UseVisualStyleBackColor = false;
            this.btnCrearHoja.Click += new System.EventHandler(this.btnCrearHoja_Click);

            // 
            // btnEliminarHoja
            // 
            this.btnEliminarHoja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnEliminarHoja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarHoja.FlatAppearance.BorderSize = 0;
            this.btnEliminarHoja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarHoja.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarHoja.ForeColor = System.Drawing.Color.White;
            this.btnEliminarHoja.Location = new System.Drawing.Point(163, 420);
            this.btnEliminarHoja.Name = "btnEliminarHoja";
            this.btnEliminarHoja.Size = new System.Drawing.Size(135, 36);
            this.btnEliminarHoja.TabIndex = 7;
            this.btnEliminarHoja.Text = "🗑️ Eliminar";
            this.btnEliminarHoja.UseVisualStyleBackColor = false;
            this.btnEliminarHoja.Click += new System.EventHandler(this.btnEliminarHoja_Click);

            // 
            // panelCrearFam
            // 
            this.panelCrearFam.BackColor = System.Drawing.Color.White;
            this.panelCrearFam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCrearFam.Controls.Add(this.lblCrearFamTitle);
            this.panelCrearFam.Controls.Add(this.lstFamiliasExistentes);
            this.panelCrearFam.Controls.Add(this.lblNombreFam);
            this.panelCrearFam.Controls.Add(this.txtNombreFam);
            this.panelCrearFam.Controls.Add(this.lblDescFam);
            this.panelCrearFam.Controls.Add(this.txtDescFam);
            this.panelCrearFam.Controls.Add(this.btnCrearFam);
            this.panelCrearFam.Controls.Add(this.btnEliminarFam);
            this.panelCrearFam.Location = new System.Drawing.Point(340, 10);
            this.panelCrearFam.Name = "panelCrearFam";
            this.panelCrearFam.Size = new System.Drawing.Size(315, 530);
            this.panelCrearFam.TabIndex = 1;

            // 
            // lblCrearFamTitle
            // 
            this.lblCrearFamTitle.AutoSize = true;
            this.lblCrearFamTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCrearFamTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblCrearFamTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCrearFamTitle.Name = "lblCrearFamTitle";
            this.lblCrearFamTitle.Size = new System.Drawing.Size(195, 20);
            this.lblCrearFamTitle.TabIndex = 0;
            this.lblCrearFamTitle.Text = "Grupos de Permisos (Familia)";

            // 
            // lstFamiliasExistentes
            // 
            this.lstFamiliasExistentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lstFamiliasExistentes.FormattingEnabled = true;
            this.lstFamiliasExistentes.ItemHeight = 15;
            this.lstFamiliasExistentes.Location = new System.Drawing.Point(15, 40);
            this.lstFamiliasExistentes.Name = "lstFamiliasExistentes";
            this.lstFamiliasExistentes.Size = new System.Drawing.Size(283, 229);
            this.lstFamiliasExistentes.TabIndex = 1;
            this.lstFamiliasExistentes.SelectedIndexChanged += new System.EventHandler(this.lstFamiliasExistentes_SelectedIndexChanged);

            // 
            // lblNombreFam
            // 
            this.lblNombreFam.AutoSize = true;
            this.lblNombreFam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreFam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblNombreFam.Location = new System.Drawing.Point(12, 280);
            this.lblNombreFam.Name = "lblNombreFam";
            this.lblNombreFam.Size = new System.Drawing.Size(126, 15);
            this.lblNombreFam.TabIndex = 2;
            this.lblNombreFam.Text = "Nombre de la Familia:";

            // 
            // txtNombreFam
            // 
            this.txtNombreFam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreFam.Location = new System.Drawing.Point(15, 300);
            this.txtNombreFam.Name = "txtNombreFam";
            this.txtNombreFam.Size = new System.Drawing.Size(283, 24);
            this.txtNombreFam.TabIndex = 3;

            // 
            // lblDescFam
            // 
            this.lblDescFam.AutoSize = true;
            this.lblDescFam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescFam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDescFam.Location = new System.Drawing.Point(12, 335);
            this.lblDescFam.Name = "lblDescFam";
            this.lblDescFam.Size = new System.Drawing.Size(72, 15);
            this.lblDescFam.TabIndex = 4;
            this.lblDescFam.Text = "Descripción:";

            // 
            // txtDescFam
            // 
            this.txtDescFam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescFam.Location = new System.Drawing.Point(15, 355);
            this.txtDescFam.Multiline = true;
            this.txtDescFam.Name = "txtDescFam";
            this.txtDescFam.Size = new System.Drawing.Size(283, 50);
            this.txtDescFam.TabIndex = 5;

            // 
            // btnCrearFam
            // 
            this.btnCrearFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnCrearFam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearFam.FlatAppearance.BorderSize = 0;
            this.btnCrearFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearFam.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCrearFam.ForeColor = System.Drawing.Color.White;
            this.btnCrearFam.Location = new System.Drawing.Point(15, 420);
            this.btnCrearFam.Name = "btnCrearFam";
            this.btnCrearFam.Size = new System.Drawing.Size(135, 36);
            this.btnCrearFam.TabIndex = 6;
            this.btnCrearFam.Text = "➕ Crear Familia";
            this.btnCrearFam.UseVisualStyleBackColor = false;
            this.btnCrearFam.Click += new System.EventHandler(this.btnCrearFam_Click);

            // 
            // btnEliminarFam
            // 
            this.btnEliminarFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnEliminarFam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarFam.FlatAppearance.BorderSize = 0;
            this.btnEliminarFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFam.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnEliminarFam.ForeColor = System.Drawing.Color.White;
            this.btnEliminarFam.Location = new System.Drawing.Point(163, 420);
            this.btnEliminarFam.Name = "btnEliminarFam";
            this.btnEliminarFam.Size = new System.Drawing.Size(135, 36);
            this.btnEliminarFam.TabIndex = 7;
            this.btnEliminarFam.Text = "🗑️ Eliminar";
            this.btnEliminarFam.UseVisualStyleBackColor = false;
            this.btnEliminarFam.Click += new System.EventHandler(this.btnEliminarFam_Click);

            // 
            // panelComposicionFam
            // 
            this.panelComposicionFam.BackColor = System.Drawing.Color.White;
            this.panelComposicionFam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelComposicionFam.Controls.Add(this.lblCompFamTitle);
            this.panelComposicionFam.Controls.Add(this.lblSubfamilias);
            this.panelComposicionFam.Controls.Add(this.clbSubfamilias);
            this.panelComposicionFam.Controls.Add(this.lblHojasDeFam);
            this.panelComposicionFam.Controls.Add(this.clbHojasDeFam);
            this.panelComposicionFam.Controls.Add(this.btnGuardarComposicionFam);
            this.panelComposicionFam.Location = new System.Drawing.Point(670, 10);
            this.panelComposicionFam.Name = "panelComposicionFam";
            this.panelComposicionFam.Size = new System.Drawing.Size(330, 530);
            this.panelComposicionFam.TabIndex = 2;

            // 
            // lblCompFamTitle
            // 
            this.lblCompFamTitle.AutoSize = true;
            this.lblCompFamTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCompFamTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblCompFamTitle.Location = new System.Drawing.Point(12, 12);
            this.lblCompFamTitle.Name = "lblCompFamTitle";
            this.lblCompFamTitle.Size = new System.Drawing.Size(235, 20);
            this.lblCompFamTitle.TabIndex = 0;
            this.lblCompFamTitle.Text = "Componer Familia Seleccionada";

            // 
            // lblSubfamilias
            // 
            this.lblSubfamilias.AutoSize = true;
            this.lblSubfamilias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubfamilias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblSubfamilias.Location = new System.Drawing.Point(12, 42);
            this.lblSubfamilias.Name = "lblSubfamilias";
            this.lblSubfamilias.Size = new System.Drawing.Size(142, 15);
            this.lblSubfamilias.TabIndex = 1;
            this.lblSubfamilias.Text = "Subfamilias contenidas:";

            // 
            // clbSubfamilias
            // 
            this.clbSubfamilias.CheckOnClick = true;
            this.clbSubfamilias.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbSubfamilias.FormattingEnabled = true;
            this.clbSubfamilias.Location = new System.Drawing.Point(15, 62);
            this.clbSubfamilias.Name = "clbSubfamilias";
            this.clbSubfamilias.Size = new System.Drawing.Size(298, 166);
            this.clbSubfamilias.TabIndex = 2;

            // 
            // lblHojasDeFam
            // 
            this.lblHojasDeFam.AutoSize = true;
            this.lblHojasDeFam.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblHojasDeFam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblHojasDeFam.Location = new System.Drawing.Point(12, 240);
            this.lblHojasDeFam.Name = "lblHojasDeFam";
            this.lblHojasDeFam.Size = new System.Drawing.Size(180, 15);
            this.lblHojasDeFam.TabIndex = 3;
            this.lblHojasDeFam.Text = "Hojas (Permisos) contenidas:";

            // 
            // clbHojasDeFam
            // 
            this.clbHojasDeFam.CheckOnClick = true;
            this.clbHojasDeFam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbHojasDeFam.FormattingEnabled = true;
            this.clbHojasDeFam.Location = new System.Drawing.Point(15, 260);
            this.clbHojasDeFam.Name = "clbHojasDeFam";
            this.clbHojasDeFam.Size = new System.Drawing.Size(298, 184);
            this.clbHojasDeFam.TabIndex = 4;

            // 
            // btnGuardarComposicionFam
            // 
            this.btnGuardarComposicionFam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnGuardarComposicionFam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarComposicionFam.FlatAppearance.BorderSize = 0;
            this.btnGuardarComposicionFam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarComposicionFam.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarComposicionFam.ForeColor = System.Drawing.Color.White;
            this.btnGuardarComposicionFam.Location = new System.Drawing.Point(15, 460);
            this.btnGuardarComposicionFam.Name = "btnGuardarComposicionFam";
            this.btnGuardarComposicionFam.Size = new System.Drawing.Size(298, 42);
            this.btnGuardarComposicionFam.TabIndex = 5;
            this.btnGuardarComposicionFam.Text = "💾 Guardar Contenido de Familia";
            this.btnGuardarComposicionFam.UseVisualStyleBackColor = false;
            this.btnGuardarComposicionFam.Click += new System.EventHandler(this.btnGuardarComposicionFam_Click);

            // 
            // FormGestionRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1024, 650);
            this.Controls.Add(this.tabControlSeguridad);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGestionRoles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AquaWash - Gestión de Seguridad y Roles";
            this.Load += new System.EventHandler(this.FormGestionRoles_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.tabControlSeguridad.ResumeLayout(false);
            this.tabRoles.ResumeLayout(false);
            this.panelRolesCard.ResumeLayout(false);
            this.panelRolesCard.PerformLayout();
            this.panelAsignacion.ResumeLayout(false);
            this.panelAsignacion.PerformLayout();
            this.tabFamiliasHojas.ResumeLayout(false);
            this.panelCrearHoja.ResumeLayout(false);
            this.panelCrearHoja.PerformLayout();
            this.panelCrearFam.ResumeLayout(false);
            this.panelCrearFam.PerformLayout();
            this.panelComposicionFam.ResumeLayout(false);
            this.panelComposicionFam.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.TabControl tabControlSeguridad;
        private System.Windows.Forms.TabPage tabRoles;
        private System.Windows.Forms.TabPage tabFamiliasHojas;
        private System.Windows.Forms.Panel panelRolesCard;
        private System.Windows.Forms.Label lblRolesTitle;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label lblNombreRol;
        private System.Windows.Forms.TextBox txtNombreRol;
        private System.Windows.Forms.Label lblDescRol;
        private System.Windows.Forms.TextBox txtDescRol;
        private System.Windows.Forms.Button btnCrearRol;
        private System.Windows.Forms.Button btnModificarRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.Panel panelAsignacion;
        private System.Windows.Forms.Label lblAsignacionTitle;
        private System.Windows.Forms.Label lblFamilias;
        private System.Windows.Forms.CheckedListBox clbFamiliasRol;
        private System.Windows.Forms.Label lblHojas;
        private System.Windows.Forms.CheckedListBox clbHojasRol;
        private System.Windows.Forms.Button btnGuardarPermisosRol;
        private System.Windows.Forms.Label lblArbolTitle;
        private System.Windows.Forms.TreeView trvPermisosRol;
        private System.Windows.Forms.Panel panelCrearHoja;
        private System.Windows.Forms.Label lblCrearHojaTitle;
        private System.Windows.Forms.ListBox lstHojasExistentes;
        private System.Windows.Forms.Label lblNombreHoja;
        private System.Windows.Forms.TextBox txtNombreHoja;
        private System.Windows.Forms.Label lblDescHoja;
        private System.Windows.Forms.TextBox txtDescHoja;
        private System.Windows.Forms.Button btnCrearHoja;
        private System.Windows.Forms.Button btnEliminarHoja;
        private System.Windows.Forms.Panel panelCrearFam;
        private System.Windows.Forms.Label lblCrearFamTitle;
        private System.Windows.Forms.ListBox lstFamiliasExistentes;
        private System.Windows.Forms.Label lblNombreFam;
        private System.Windows.Forms.TextBox txtNombreFam;
        private System.Windows.Forms.Label lblDescFam;
        private System.Windows.Forms.TextBox txtDescFam;
        private System.Windows.Forms.Button btnCrearFam;
        private System.Windows.Forms.Button btnEliminarFam;
        private System.Windows.Forms.Panel panelComposicionFam;
        private System.Windows.Forms.Label lblCompFamTitle;
        private System.Windows.Forms.Label lblSubfamilias;
        private System.Windows.Forms.CheckedListBox clbSubfamilias;
        private System.Windows.Forms.Label lblHojasDeFam;
        private System.Windows.Forms.CheckedListBox clbHojasDeFam;
        private System.Windows.Forms.Button btnGuardarComposicionFam;
    }
}
