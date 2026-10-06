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
            this.btnMenuBitacora = new System.Windows.Forms.Button();
            this.btnMenuConsultas = new System.Windows.Forms.Button();
            this.btnMenuServicios = new System.Windows.Forms.Button();
            this.btnMenuVehiculos = new System.Windows.Forms.Button();
            this.btnMenuClientes = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelSidebar.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.panelSidebar.Controls.Add(this.btnMenuBitacora);
            this.panelSidebar.Controls.Add(this.btnMenuConsultas);
            this.panelSidebar.Controls.Add(this.btnMenuServicios);
            this.panelSidebar.Controls.Add(this.btnMenuVehiculos);
            this.panelSidebar.Controls.Add(this.btnMenuClientes);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.panelSeparator);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 650);
            this.panelSidebar.TabIndex = 0;
            // 
            // btnMenuBitacora
            // 
            this.btnMenuBitacora.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMenuBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuBitacora.FlatAppearance.BorderSize = 0;
            this.btnMenuBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuBitacora.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuBitacora.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuBitacora.Location = new System.Drawing.Point(0, 262);
            this.btnMenuBitacora.Name = "btnMenuBitacora";
            this.btnMenuBitacora.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuBitacora.Size = new System.Drawing.Size(220, 45);
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
            this.btnMenuConsultas.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuConsultas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuConsultas.Location = new System.Drawing.Point(0, 217);
            this.btnMenuConsultas.Name = "btnMenuConsultas";
            this.btnMenuConsultas.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuConsultas.Size = new System.Drawing.Size(220, 45);
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
            this.btnMenuServicios.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuServicios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuServicios.Location = new System.Drawing.Point(0, 172);
            this.btnMenuServicios.Name = "btnMenuServicios";
            this.btnMenuServicios.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuServicios.Size = new System.Drawing.Size(220, 45);
            this.btnMenuServicios.TabIndex = 4;
            this.btnMenuServicios.Text = "  🧽  Servicios de Lavado";
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
            this.btnMenuVehiculos.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuVehiculos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuVehiculos.Location = new System.Drawing.Point(0, 127);
            this.btnMenuVehiculos.Name = "btnMenuVehiculos";
            this.btnMenuVehiculos.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuVehiculos.Size = new System.Drawing.Size(220, 45);
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
            this.btnMenuClientes.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnMenuClientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(190)))), ((int)(((byte)(197)))));
            this.btnMenuClientes.Location = new System.Drawing.Point(0, 82);
            this.btnMenuClientes.Name = "btnMenuClientes";
            this.btnMenuClientes.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMenuClientes.Size = new System.Drawing.Size(220, 45);
            this.btnMenuClientes.TabIndex = 2;
            this.btnMenuClientes.Text = "  👤  Clientes";
            this.btnMenuClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuClientes.UseVisualStyleBackColor = false;
            this.btnMenuClientes.Click += new System.EventHandler(this.gestorDeClientesToolStripMenuItem_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(41)))), ((int)(((byte)(64)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 605);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(220, 45);
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
            this.panelSeparator.Size = new System.Drawing.Size(220, 2);
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
            this.panelLogo.Size = new System.Drawing.Size(220, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblVersion.Location = new System.Drawing.Point(25, 45);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(94, 13);
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
            this.lblLogo.Size = new System.Drawing.Size(183, 30);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "💧 AQUA WASH";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1100, 650);
            this.Controls.Add(this.panelSidebar);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🚿 AquaWash Pro — Panel Principal";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
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
    }
}
