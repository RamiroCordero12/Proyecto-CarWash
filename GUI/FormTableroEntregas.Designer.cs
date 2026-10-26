namespace GUI
{
    partial class FormTableroEntregas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelAviso = new System.Windows.Forms.Panel();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblCerrarAviso = new System.Windows.Forms.Label();
            this.dgvEntregas = new System.Windows.Forms.DataGridView();
            this.panelDetalle = new System.Windows.Forms.Panel();
            this.lblDetalleTitle = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.lblContador = new System.Windows.Forms.Label();
            this.lblHeaderVehiculo = new System.Windows.Forms.Label();
            this.lblDetallePatente = new System.Windows.Forms.Label();
            this.lblDetalleVehiculo = new System.Windows.Forms.Label();
            this.lblHeaderCliente = new System.Windows.Forms.Label();
            this.lblDetalleCliente = new System.Windows.Forms.Label();
            this.lblHeaderTelefono = new System.Windows.Forms.Label();
            this.lblDetalleTelefono = new System.Windows.Forms.Label();
            this.lblHeaderServicio = new System.Windows.Forms.Label();
            this.lblDetalleServicio = new System.Windows.Forms.Label();
            this.lblDetalleOperador = new System.Windows.Forms.Label();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.timerAviso = new System.Windows.Forms.Timer(this.components);
            this.panelHeader.SuspendLayout();
            this.panelAviso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).BeginInit();
            this.panelDetalle.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(960, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 12);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(285, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🚗  Tablero de Entregas";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(223)))), ((int)(((byte)(219)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(24, 42);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(325, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Monitoreo en tiempo real de vehículos listos para entrega";
            // 
            // panelAviso
            // 
            this.panelAviso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.panelAviso.Controls.Add(this.lblAviso);
            this.panelAviso.Controls.Add(this.lblCerrarAviso);
            this.panelAviso.Location = new System.Drawing.Point(20, 72);
            this.panelAviso.Name = "panelAviso";
            this.panelAviso.Size = new System.Drawing.Size(920, 38);
            this.panelAviso.TabIndex = 1;
            this.panelAviso.Visible = false;
            this.panelAviso.Paint += new System.Windows.Forms.PaintEventHandler(this.panelAviso_Paint);
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(92)))));
            this.lblAviso.Location = new System.Drawing.Point(14, 10);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(126, 17);
            this.lblAviso.TabIndex = 0;
            this.lblAviso.Text = "✔  Vehículo listo";
            // 
            // lblCerrarAviso
            // 
            this.lblCerrarAviso.AutoSize = true;
            this.lblCerrarAviso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCerrarAviso.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCerrarAviso.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblCerrarAviso.Location = new System.Drawing.Point(895, 9);
            this.lblCerrarAviso.Name = "lblCerrarAviso";
            this.lblCerrarAviso.Size = new System.Drawing.Size(19, 19);
            this.lblCerrarAviso.TabIndex = 1;
            this.lblCerrarAviso.Text = "✕";
            this.lblCerrarAviso.Click += new System.EventHandler(this.lblCerrarAviso_Click);
            // 
            // dgvEntregas
            // 
            this.dgvEntregas.AllowUserToAddRows = false;
            this.dgvEntregas.AllowUserToDeleteRows = false;
            this.dgvEntregas.AllowUserToResizeRows = false;
            this.dgvEntregas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEntregas.BackgroundColor = System.Drawing.Color.White;
            this.dgvEntregas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEntregas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEntregas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvEntregas.ColumnHeadersHeight = 40;
            this.dgvEntregas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEntregas.EnableHeadersVisualStyles = false;
            this.dgvEntregas.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvEntregas.Location = new System.Drawing.Point(20, 120);
            this.dgvEntregas.MultiSelect = false;
            this.dgvEntregas.Name = "dgvEntregas";
            this.dgvEntregas.ReadOnly = true;
            this.dgvEntregas.RowHeadersVisible = false;
            this.dgvEntregas.RowTemplate.Height = 35;
            this.dgvEntregas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEntregas.Size = new System.Drawing.Size(620, 420);
            this.dgvEntregas.TabIndex = 2;
            this.dgvEntregas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEntregas_CellClick);
            this.dgvEntregas.SelectionChanged += new System.EventHandler(this.dgvEntregas_SelectionChanged);
            // 
            // panelDetalle
            // 
            this.panelDetalle.BackColor = System.Drawing.Color.White;
            this.panelDetalle.Controls.Add(this.lblDetalleTitle);
            this.panelDetalle.Controls.Add(this.panelSeparator);
            this.panelDetalle.Controls.Add(this.lblContador);
            this.panelDetalle.Controls.Add(this.lblHeaderVehiculo);
            this.panelDetalle.Controls.Add(this.lblDetallePatente);
            this.panelDetalle.Controls.Add(this.lblDetalleVehiculo);
            this.panelDetalle.Controls.Add(this.lblHeaderCliente);
            this.panelDetalle.Controls.Add(this.lblDetalleCliente);
            this.panelDetalle.Controls.Add(this.lblHeaderTelefono);
            this.panelDetalle.Controls.Add(this.lblDetalleTelefono);
            this.panelDetalle.Controls.Add(this.lblHeaderServicio);
            this.panelDetalle.Controls.Add(this.lblDetalleServicio);
            this.panelDetalle.Controls.Add(this.lblDetalleOperador);
            this.panelDetalle.Controls.Add(this.btnEntregar);
            this.panelDetalle.Controls.Add(this.btnActualizar);
            this.panelDetalle.Location = new System.Drawing.Point(660, 120);
            this.panelDetalle.Name = "panelDetalle";
            this.panelDetalle.Padding = new System.Windows.Forms.Padding(15);
            this.panelDetalle.Size = new System.Drawing.Size(280, 420);
            this.panelDetalle.TabIndex = 3;
            this.panelDetalle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDetalle_Paint);
            // 
            // lblDetalleTitle
            // 
            this.lblDetalleTitle.AutoSize = true;
            this.lblDetalleTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.lblDetalleTitle.Location = new System.Drawing.Point(18, 15);
            this.lblDetalleTitle.Name = "lblDetalleTitle";
            this.lblDetalleTitle.Size = new System.Drawing.Size(144, 20);
            this.lblDetalleTitle.TabIndex = 0;
            this.lblDetalleTitle.Text = "Detalles de Entrega";
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.panelSeparator.Location = new System.Drawing.Point(18, 40);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(50, 3);
            this.panelSeparator.TabIndex = 1;
            // 
            // lblContador
            // 
            this.lblContador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(248)))));
            this.lblContador.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblContador.Location = new System.Drawing.Point(18, 52);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(244, 28);
            this.lblContador.TabIndex = 2;
            this.lblContador.Text = "Listos para entrega: 0";
            this.lblContador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHeaderVehiculo
            // 
            this.lblHeaderVehiculo.AutoSize = true;
            this.lblHeaderVehiculo.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblHeaderVehiculo.Location = new System.Drawing.Point(18, 88);
            this.lblHeaderVehiculo.Name = "lblHeaderVehiculo";
            this.lblHeaderVehiculo.Size = new System.Drawing.Size(59, 13);
            this.lblHeaderVehiculo.TabIndex = 3;
            this.lblHeaderVehiculo.Text = "VEHÍCULO";
            // 
            // lblDetallePatente
            // 
            this.lblDetallePatente.AutoSize = true;
            this.lblDetallePatente.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetallePatente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.lblDetallePatente.Location = new System.Drawing.Point(18, 104);
            this.lblDetallePatente.Name = "lblDetallePatente";
            this.lblDetallePatente.Size = new System.Drawing.Size(37, 28);
            this.lblDetallePatente.TabIndex = 4;
            this.lblDetallePatente.Text = "---";
            // 
            // lblDetalleVehiculo
            // 
            this.lblDetalleVehiculo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleVehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDetalleVehiculo.Location = new System.Drawing.Point(18, 132);
            this.lblDetalleVehiculo.Name = "lblDetalleVehiculo";
            this.lblDetalleVehiculo.Size = new System.Drawing.Size(244, 18);
            this.lblDetalleVehiculo.TabIndex = 5;
            this.lblDetalleVehiculo.Text = "Seleccioná un vehículo";
            // 
            // lblHeaderCliente
            // 
            this.lblHeaderCliente.AutoSize = true;
            this.lblHeaderCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblHeaderCliente.Location = new System.Drawing.Point(18, 158);
            this.lblHeaderCliente.Name = "lblHeaderCliente";
            this.lblHeaderCliente.Size = new System.Drawing.Size(51, 13);
            this.lblHeaderCliente.TabIndex = 6;
            this.lblHeaderCliente.Text = "CLIENTE";
            // 
            // lblDetalleCliente
            // 
            this.lblDetalleCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDetalleCliente.Location = new System.Drawing.Point(18, 174);
            this.lblDetalleCliente.Name = "lblDetalleCliente";
            this.lblDetalleCliente.Size = new System.Drawing.Size(244, 18);
            this.lblDetalleCliente.TabIndex = 7;
            this.lblDetalleCliente.Text = "-";
            // 
            // lblHeaderTelefono
            // 
            this.lblHeaderTelefono.AutoSize = true;
            this.lblHeaderTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblHeaderTelefono.Location = new System.Drawing.Point(18, 200);
            this.lblHeaderTelefono.Name = "lblHeaderTelefono";
            this.lblHeaderTelefono.Size = new System.Drawing.Size(61, 13);
            this.lblHeaderTelefono.TabIndex = 8;
            this.lblHeaderTelefono.Text = "TELÉFONO";
            // 
            // lblDetalleTelefono
            // 
            this.lblDetalleTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDetalleTelefono.Location = new System.Drawing.Point(18, 216);
            this.lblDetalleTelefono.Name = "lblDetalleTelefono";
            this.lblDetalleTelefono.Size = new System.Drawing.Size(244, 18);
            this.lblDetalleTelefono.TabIndex = 9;
            this.lblDetalleTelefono.Text = "-";
            // 
            // lblHeaderServicio
            // 
            this.lblHeaderServicio.AutoSize = true;
            this.lblHeaderServicio.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeaderServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblHeaderServicio.Location = new System.Drawing.Point(18, 242);
            this.lblHeaderServicio.Name = "lblHeaderServicio";
            this.lblHeaderServicio.Size = new System.Drawing.Size(56, 13);
            this.lblHeaderServicio.TabIndex = 10;
            this.lblHeaderServicio.Text = "SERVICIO";
            // 
            // lblDetalleServicio
            // 
            this.lblDetalleServicio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleServicio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblDetalleServicio.Location = new System.Drawing.Point(18, 258);
            this.lblDetalleServicio.Name = "lblDetalleServicio";
            this.lblDetalleServicio.Size = new System.Drawing.Size(244, 18);
            this.lblDetalleServicio.TabIndex = 11;
            this.lblDetalleServicio.Text = "-";
            // 
            // lblDetalleOperador
            // 
            this.lblDetalleOperador.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalleOperador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.lblDetalleOperador.Location = new System.Drawing.Point(18, 284);
            this.lblDetalleOperador.Name = "lblDetalleOperador";
            this.lblDetalleOperador.Size = new System.Drawing.Size(244, 18);
            this.lblDetalleOperador.TabIndex = 12;
            this.lblDetalleOperador.Text = "";
            // 
            // btnEntregar
            // 
            this.btnEntregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.btnEntregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEntregar.FlatAppearance.BorderSize = 0;
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregar.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregar.ForeColor = System.Drawing.Color.White;
            this.btnEntregar.Location = new System.Drawing.Point(18, 318);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(244, 42);
            this.btnEntregar.TabIndex = 13;
            this.btnEntregar.Text = "✔  Confirmar Entrega";
            this.btnEntregar.UseVisualStyleBackColor = false;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(144)))), ((int)(((byte)(156)))));
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(18, 370);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(244, 34);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "⟳  Actualizar Tablero";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // timerAviso
            // 
            this.timerAviso.Tick += new System.EventHandler(this.timerAviso_Tick);
            // 
            // FormTableroEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(960, 560);
            this.Controls.Add(this.panelDetalle);
            this.Controls.Add(this.dgvEntregas);
            this.Controls.Add(this.panelAviso);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormTableroEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🚗 Tablero de Entregas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormTableroEntregas_FormClosing);
            this.Load += new System.EventHandler(this.FormTableroEntregas_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelAviso.ResumeLayout(false);
            this.panelAviso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEntregas)).EndInit();
            this.panelDetalle.ResumeLayout(false);
            this.panelDetalle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelAviso;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.Label lblCerrarAviso;
        private System.Windows.Forms.DataGridView dgvEntregas;
        private System.Windows.Forms.Panel panelDetalle;
        private System.Windows.Forms.Label lblDetalleTitle;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Label lblContador;
        private System.Windows.Forms.Label lblHeaderVehiculo;
        private System.Windows.Forms.Label lblDetallePatente;
        private System.Windows.Forms.Label lblDetalleVehiculo;
        private System.Windows.Forms.Label lblHeaderCliente;
        private System.Windows.Forms.Label lblDetalleCliente;
        private System.Windows.Forms.Label lblHeaderTelefono;
        private System.Windows.Forms.Label lblDetalleTelefono;
        private System.Windows.Forms.Label lblHeaderServicio;
        private System.Windows.Forms.Label lblDetalleServicio;
        private System.Windows.Forms.Label lblDetalleOperador;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Timer timerAviso;
    }
}