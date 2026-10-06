namespace GUI
{
    partial class FormServiciosLavado
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
            this.btnEliminar = new System.Windows.Forms.Button();
            this.trvArbol = new System.Windows.Forms.TreeView();
            this.label9 = new System.Windows.Forms.Label();
            this.clbComponentes = new System.Windows.Forms.CheckedListBox();
            this.btnAgregarCombo = new System.Windows.Forms.Button();
            this.txtPrecioCombo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombreCombo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAgregarServicio = new System.Windows.Forms.Button();
            this.txtPrecioServicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelTree = new System.Windows.Forms.Panel();
            this.panelServicio = new System.Windows.Forms.Panel();
            this.panelSep1 = new System.Windows.Forms.Panel();
            this.panelCombo = new System.Windows.Forms.Panel();
            this.panelSep2 = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelTree.SuspendLayout();
            this.panelServicio.SuspendLayout();
            this.panelCombo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(57)))), ((int)(((byte)(53)))));
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(12, 445);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(180, 38);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "✖  Eliminar selección";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // trvArbol
            // 
            this.trvArbol.BackColor = System.Drawing.Color.White;
            this.trvArbol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvArbol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.trvArbol.Location = new System.Drawing.Point(12, 35);
            this.trvArbol.Name = "trvArbol";
            this.trvArbol.Size = new System.Drawing.Size(376, 400);
            this.trvArbol.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label9.Location = new System.Drawing.Point(12, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "Servicios que incluye";
            // 
            // clbComponentes
            // 
            this.clbComponentes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.clbComponentes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbComponentes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.clbComponentes.FormattingEnabled = true;
            this.clbComponentes.Location = new System.Drawing.Point(15, 165);
            this.clbComponentes.Name = "clbComponentes";
            this.clbComponentes.Size = new System.Drawing.Size(240, 72);
            this.clbComponentes.TabIndex = 7;
            // 
            // btnAgregarCombo
            // 
            this.btnAgregarCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(143)))), ((int)(((byte)(0)))));
            this.btnAgregarCombo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCombo.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCombo.ForeColor = System.Drawing.Color.White;
            this.btnAgregarCombo.Location = new System.Drawing.Point(185, 260);
            this.btnAgregarCombo.Name = "btnAgregarCombo";
            this.btnAgregarCombo.Size = new System.Drawing.Size(180, 38);
            this.btnAgregarCombo.TabIndex = 8;
            this.btnAgregarCombo.Text = "✚  Agregar Combo";
            this.btnAgregarCombo.UseVisualStyleBackColor = false;
            this.btnAgregarCombo.Click += new System.EventHandler(this.btnAgregarCombo_Click);
            // 
            // txtPrecioCombo
            // 
            this.txtPrecioCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtPrecioCombo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioCombo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecioCombo.Location = new System.Drawing.Point(15, 115);
            this.txtPrecioCombo.Name = "txtPrecioCombo";
            this.txtPrecioCombo.Size = new System.Drawing.Size(240, 23);
            this.txtPrecioCombo.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label6.Location = new System.Drawing.Point(12, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Precio";
            // 
            // txtNombreCombo
            // 
            this.txtNombreCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNombreCombo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreCombo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCombo.Location = new System.Drawing.Point(15, 65);
            this.txtNombreCombo.Name = "txtNombreCombo";
            this.txtNombreCombo.Size = new System.Drawing.Size(240, 23);
            this.txtNombreCombo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label7.Location = new System.Drawing.Point(12, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre del combo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.label8.Location = new System.Drawing.Point(12, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nuevo Combo";
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(123)))));
            this.btnAgregarServicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarServicio.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarServicio.ForeColor = System.Drawing.Color.White;
            this.btnAgregarServicio.Location = new System.Drawing.Point(15, 150);
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.Size = new System.Drawing.Size(180, 38);
            this.btnAgregarServicio.TabIndex = 6;
            this.btnAgregarServicio.Text = "✚  Agregar Servicio";
            this.btnAgregarServicio.UseVisualStyleBackColor = false;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click);
            // 
            // txtPrecioServicio
            // 
            this.txtPrecioServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtPrecioServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPrecioServicio.Location = new System.Drawing.Point(15, 115);
            this.txtPrecioServicio.Name = "txtPrecioServicio";
            this.txtPrecioServicio.Size = new System.Drawing.Size(240, 23);
            this.txtPrecioServicio.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.txtNombreServicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreServicio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreServicio.Location = new System.Drawing.Point(15, 65);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(240, 23);
            this.txtNombreServicio.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.label4.Location = new System.Drawing.Point(12, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nombre del servicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.label3.Location = new System.Drawing.Point(12, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(172, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Nuevo Servicio de Lavado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Servicios y combos existentes";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(850, 60);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(276, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🧽  Servicios de Lavado";
            // 
            // panelTree
            // 
            this.panelTree.BackColor = System.Drawing.Color.White;
            this.panelTree.Controls.Add(this.label2);
            this.panelTree.Controls.Add(this.trvArbol);
            this.panelTree.Controls.Add(this.btnEliminar);
            this.panelTree.Location = new System.Drawing.Point(20, 80);
            this.panelTree.Name = "panelTree";
            this.panelTree.Padding = new System.Windows.Forms.Padding(12);
            this.panelTree.Size = new System.Drawing.Size(400, 528);
            this.panelTree.TabIndex = 1;
            // 
            // panelServicio
            // 
            this.panelServicio.BackColor = System.Drawing.Color.White;
            this.panelServicio.Controls.Add(this.label3);
            this.panelServicio.Controls.Add(this.panelSep1);
            this.panelServicio.Controls.Add(this.label4);
            this.panelServicio.Controls.Add(this.txtNombreServicio);
            this.panelServicio.Controls.Add(this.label5);
            this.panelServicio.Controls.Add(this.txtPrecioServicio);
            this.panelServicio.Controls.Add(this.btnAgregarServicio);
            this.panelServicio.Location = new System.Drawing.Point(440, 80);
            this.panelServicio.Name = "panelServicio";
            this.panelServicio.Padding = new System.Windows.Forms.Padding(12);
            this.panelServicio.Size = new System.Drawing.Size(380, 200);
            this.panelServicio.TabIndex = 2;
            // 
            // panelSep1
            // 
            this.panelSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.panelSep1.Location = new System.Drawing.Point(15, 32);
            this.panelSep1.Name = "panelSep1";
            this.panelSep1.Size = new System.Drawing.Size(40, 2);
            this.panelSep1.TabIndex = 1;
            // 
            // panelCombo
            // 
            this.panelCombo.BackColor = System.Drawing.Color.White;
            this.panelCombo.Controls.Add(this.label8);
            this.panelCombo.Controls.Add(this.panelSep2);
            this.panelCombo.Controls.Add(this.label7);
            this.panelCombo.Controls.Add(this.txtNombreCombo);
            this.panelCombo.Controls.Add(this.label6);
            this.panelCombo.Controls.Add(this.txtPrecioCombo);
            this.panelCombo.Controls.Add(this.label9);
            this.panelCombo.Controls.Add(this.clbComponentes);
            this.panelCombo.Controls.Add(this.btnAgregarCombo);
            this.panelCombo.Location = new System.Drawing.Point(440, 295);
            this.panelCombo.Name = "panelCombo";
            this.panelCombo.Padding = new System.Windows.Forms.Padding(12);
            this.panelCombo.Size = new System.Drawing.Size(380, 313);
            this.panelCombo.TabIndex = 3;
            // 
            // panelSep2
            // 
            this.panelSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(212)))));
            this.panelSep2.Location = new System.Drawing.Point(15, 32);
            this.panelSep2.Name = "panelSep2";
            this.panelSep2.Size = new System.Drawing.Size(40, 2);
            this.panelSep2.TabIndex = 1;
            // 
            // FormServiciosLavado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(850, 620);
            this.Controls.Add(this.panelCombo);
            this.Controls.Add(this.panelServicio);
            this.Controls.Add(this.panelTree);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormServiciosLavado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🧽 Gestión de Servicios de Lavado";
            this.Load += new System.EventHandler(this.FormServiciosLavado_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelTree.ResumeLayout(false);
            this.panelTree.PerformLayout();
            this.panelServicio.ResumeLayout(false);
            this.panelServicio.PerformLayout();
            this.panelCombo.ResumeLayout(false);
            this.panelCombo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.TreeView trvArbol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox clbComponentes;
        private System.Windows.Forms.Button btnAgregarCombo;
        private System.Windows.Forms.TextBox txtPrecioCombo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombreCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAgregarServicio;
        private System.Windows.Forms.TextBox txtPrecioServicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelTree;
        private System.Windows.Forms.Panel panelServicio;
        private System.Windows.Forms.Panel panelSep1;
        private System.Windows.Forms.Panel panelCombo;
        private System.Windows.Forms.Panel panelSep2;
    }
}