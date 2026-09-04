namespace GUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestorDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestorDeClientesToolStripMenuItem,
            this.formConsultasToolStripMenuItem,
            this.formBitacoraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(869, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestorDeClientesToolStripMenuItem
            // 
            this.gestorDeClientesToolStripMenuItem.Name = "gestorDeClientesToolStripMenuItem";
            this.gestorDeClientesToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.gestorDeClientesToolStripMenuItem.Text = "Gestor de clientes";
            this.gestorDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gestorDeClientesToolStripMenuItem_Click);
            // 
            // formConsultasToolStripMenuItem
            // 
            this.formConsultasToolStripMenuItem.Name = "formConsultasToolStripMenuItem";
            this.formConsultasToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.formConsultasToolStripMenuItem.Text = "FormConsultas";
            this.formConsultasToolStripMenuItem.Click += new System.EventHandler(this.formConsultasToolStripMenuItem_Click);
            // 
            // formBitacoraToolStripMenuItem
            // 
            this.formBitacoraToolStripMenuItem.Name = "formBitacoraToolStripMenuItem";
            this.formBitacoraToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.formBitacoraToolStripMenuItem.Text = "FormBitacora";
            this.formBitacoraToolStripMenuItem.Click += new System.EventHandler(this.formBitacoraToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GUI.Properties.Resources.image;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(869, 412);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gestorDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formConsultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formBitacoraToolStripMenuItem;
    }
}

