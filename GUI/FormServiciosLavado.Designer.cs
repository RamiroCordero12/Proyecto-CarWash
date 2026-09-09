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
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(12, 511);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(166, 23);
            this.btnEliminar.TabIndex = 36;
            this.btnEliminar.Text = "Eliminar servicio o combo";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // trvArbol
            // 
            this.trvArbol.Location = new System.Drawing.Point(12, 53);
            this.trvArbol.Name = "trvArbol";
            this.trvArbol.Size = new System.Drawing.Size(343, 452);
            this.trvArbol.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(362, 303);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(153, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Servicios que incluye el combo";
            // 
            // clbComponentes
            // 
            this.clbComponentes.FormattingEnabled = true;
            this.clbComponentes.Location = new System.Drawing.Point(365, 322);
            this.clbComponentes.Name = "clbComponentes";
            this.clbComponentes.Size = new System.Drawing.Size(177, 154);
            this.clbComponentes.TabIndex = 33;
            // 
            // btnAgregarCombo
            // 
            this.btnAgregarCombo.Location = new System.Drawing.Point(361, 482);
            this.btnAgregarCombo.Name = "btnAgregarCombo";
            this.btnAgregarCombo.Size = new System.Drawing.Size(100, 23);
            this.btnAgregarCombo.TabIndex = 32;
            this.btnAgregarCombo.Text = "Agregar combo";
            this.btnAgregarCombo.UseVisualStyleBackColor = true;
            this.btnAgregarCombo.Click += new System.EventHandler(this.btnAgregarCombo_Click);
            // 
            // txtPrecioCombo
            // 
            this.txtPrecioCombo.Location = new System.Drawing.Point(365, 268);
            this.txtPrecioCombo.Name = "txtPrecioCombo";
            this.txtPrecioCombo.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioCombo.TabIndex = 31;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Precio";
            // 
            // txtNombreCombo
            // 
            this.txtNombreCombo.Location = new System.Drawing.Point(365, 223);
            this.txtNombreCombo.Name = "txtNombreCombo";
            this.txtNombreCombo.Size = new System.Drawing.Size(100, 20);
            this.txtNombreCombo.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(365, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Nombre del combo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Nuevo combo";
            // 
            // btnAgregarServicio
            // 
            this.btnAgregarServicio.Location = new System.Drawing.Point(362, 148);
            this.btnAgregarServicio.Name = "btnAgregarServicio";
            this.btnAgregarServicio.Size = new System.Drawing.Size(99, 23);
            this.btnAgregarServicio.TabIndex = 26;
            this.btnAgregarServicio.Text = "Agregar servicio";
            this.btnAgregarServicio.UseVisualStyleBackColor = true;
            this.btnAgregarServicio.Click += new System.EventHandler(this.btnAgregarServicio_Click);
            // 
            // txtPrecioServicio
            // 
            this.txtPrecioServicio.Location = new System.Drawing.Point(362, 121);
            this.txtPrecioServicio.Name = "txtPrecioServicio";
            this.txtPrecioServicio.Size = new System.Drawing.Size(100, 20);
            this.txtPrecioServicio.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(362, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Precio";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Location = new System.Drawing.Point(362, 76);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(100, 20);
            this.txtNombreServicio.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(362, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Nombre del servicio";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Nuevo servicio de lavado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Servicios y combos existentes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, -43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Gestion de servicios de lavado";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Gestion de servicios de lavado";
            // 
            // FormServiciosLavado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 544);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.trvArbol);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.clbComponentes);
            this.Controls.Add(this.btnAgregarCombo);
            this.Controls.Add(this.txtPrecioCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombreCombo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAgregarServicio);
            this.Controls.Add(this.txtPrecioServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNombreServicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormServiciosLavado";
            this.Text = "FormServiciosLavado";
            this.Load += new System.EventHandler(this.FormServiciosLavado_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
    }
}