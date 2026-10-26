namespace GUI
{
    partial class FormBackup
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
            this.panelBackupCard = new System.Windows.Forms.Panel();
            this.lblBackupCardTitle = new System.Windows.Forms.Label();
            this.lblBackupDesc = new System.Windows.Forms.Label();
            this.lblRutaBackup = new System.Windows.Forms.Label();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.btnExaminarBackup = new System.Windows.Forms.Button();
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.panelRestoreCard = new System.Windows.Forms.Panel();
            this.lblRestoreCardTitle = new System.Windows.Forms.Label();
            this.lblRestoreDesc = new System.Windows.Forms.Label();
            this.lblRestoreWarning = new System.Windows.Forms.Label();
            this.lblRutaRestore = new System.Windows.Forms.Label();
            this.txtRutaRestore = new System.Windows.Forms.TextBox();
            this.btnExaminarRestore = new System.Windows.Forms.Button();
            this.btnRestaurarBackup = new System.Windows.Forms.Button();
            this.lblEstado = new System.Windows.Forms.Label();

            this.panelHeader.SuspendLayout();
            this.panelBackupCard.SuspendLayout();
            this.panelRestoreCard.SuspendLayout();
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
            this.panelHeader.Size = new System.Drawing.Size(780, 65);
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
            this.lblTitulo.Text = "💾 Base de Datos: Copia y Restauración";

            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.lblSubtitulo.Location = new System.Drawing.Point(23, 40);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(380, 15);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Respaldo y recuperación de CarWashDB con auditoría en Bitácora";

            // 
            // panelBackupCard
            // 
            this.panelBackupCard.BackColor = System.Drawing.Color.White;
            this.panelBackupCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBackupCard.Controls.Add(this.lblBackupCardTitle);
            this.panelBackupCard.Controls.Add(this.lblBackupDesc);
            this.panelBackupCard.Controls.Add(this.lblRutaBackup);
            this.panelBackupCard.Controls.Add(this.txtRutaBackup);
            this.panelBackupCard.Controls.Add(this.btnExaminarBackup);
            this.panelBackupCard.Controls.Add(this.btnGenerarBackup);
            this.panelBackupCard.Location = new System.Drawing.Point(25, 85);
            this.panelBackupCard.Name = "panelBackupCard";
            this.panelBackupCard.Size = new System.Drawing.Size(730, 180);
            this.panelBackupCard.TabIndex = 1;

            // 
            // lblBackupCardTitle
            // 
            this.lblBackupCardTitle.AutoSize = true;
            this.lblBackupCardTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblBackupCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblBackupCardTitle.Location = new System.Drawing.Point(20, 15);
            this.lblBackupCardTitle.Name = "lblBackupCardTitle";
            this.lblBackupCardTitle.Size = new System.Drawing.Size(265, 21);
            this.lblBackupCardTitle.TabIndex = 0;
            this.lblBackupCardTitle.Text = "CU17: Generar Copia de Seguridad";

            // 
            // lblBackupDesc
            // 
            this.lblBackupDesc.AutoSize = true;
            this.lblBackupDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBackupDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblBackupDesc.Location = new System.Drawing.Point(22, 40);
            this.lblBackupDesc.Name = "lblBackupDesc";
            this.lblBackupDesc.Size = new System.Drawing.Size(530, 15);
            this.lblBackupDesc.TabIndex = 1;
            this.lblBackupDesc.Text = "Crea un archivo (.bak) con todos los clientes, vehículos, servicios, turnos, usuarios y bitácora actuales.";

            // 
            // lblRutaBackup
            // 
            this.lblRutaBackup.AutoSize = true;
            this.lblRutaBackup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRutaBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblRutaBackup.Location = new System.Drawing.Point(22, 70);
            this.lblRutaBackup.Name = "lblRutaBackup";
            this.lblRutaBackup.Size = new System.Drawing.Size(155, 15);
            this.lblRutaBackup.TabIndex = 2;
            this.lblRutaBackup.Text = "Ruta de archivo de destino:";

            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRutaBackup.Location = new System.Drawing.Point(25, 90);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.Size = new System.Drawing.Size(540, 24);
            this.txtRutaBackup.TabIndex = 3;

            // 
            // btnExaminarBackup
            // 
            this.btnExaminarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExaminarBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminarBackup.FlatAppearance.BorderSize = 0;
            this.btnExaminarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminarBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExaminarBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnExaminarBackup.Location = new System.Drawing.Point(575, 88);
            this.btnExaminarBackup.Name = "btnExaminarBackup";
            this.btnExaminarBackup.Size = new System.Drawing.Size(130, 28);
            this.btnExaminarBackup.TabIndex = 4;
            this.btnExaminarBackup.Text = "📁 Examinar...";
            this.btnExaminarBackup.UseVisualStyleBackColor = false;
            this.btnExaminarBackup.Click += new System.EventHandler(this.btnExaminarBackup_Click);

            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(143)))));
            this.btnGenerarBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarBackup.FlatAppearance.BorderSize = 0;
            this.btnGenerarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarBackup.ForeColor = System.Drawing.Color.White;
            this.btnGenerarBackup.Location = new System.Drawing.Point(25, 125);
            this.btnGenerarBackup.Name = "btnGenerarBackup";
            this.btnGenerarBackup.Size = new System.Drawing.Size(220, 38);
            this.btnGenerarBackup.TabIndex = 5;
            this.btnGenerarBackup.Text = "💾 Generar Backup Ahora";
            this.btnGenerarBackup.UseVisualStyleBackColor = false;
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);

            // 
            // panelRestoreCard
            // 
            this.panelRestoreCard.BackColor = System.Drawing.Color.White;
            this.panelRestoreCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRestoreCard.Controls.Add(this.lblRestoreCardTitle);
            this.panelRestoreCard.Controls.Add(this.lblRestoreDesc);
            this.panelRestoreCard.Controls.Add(this.lblRestoreWarning);
            this.panelRestoreCard.Controls.Add(this.lblRutaRestore);
            this.panelRestoreCard.Controls.Add(this.txtRutaRestore);
            this.panelRestoreCard.Controls.Add(this.btnExaminarRestore);
            this.panelRestoreCard.Controls.Add(this.btnRestaurarBackup);
            this.panelRestoreCard.Location = new System.Drawing.Point(25, 285);
            this.panelRestoreCard.Name = "panelRestoreCard";
            this.panelRestoreCard.Size = new System.Drawing.Size(730, 210);
            this.panelRestoreCard.TabIndex = 2;

            // 
            // lblRestoreCardTitle
            // 
            this.lblRestoreCardTitle.AutoSize = true;
            this.lblRestoreCardTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.lblRestoreCardTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.lblRestoreCardTitle.Location = new System.Drawing.Point(20, 15);
            this.lblRestoreCardTitle.Name = "lblRestoreCardTitle";
            this.lblRestoreCardTitle.Size = new System.Drawing.Size(280, 21);
            this.lblRestoreCardTitle.TabIndex = 0;
            this.lblRestoreCardTitle.Text = "CU18: Restaurar Copia de Seguridad";

            // 
            // lblRestoreDesc
            // 
            this.lblRestoreDesc.AutoSize = true;
            this.lblRestoreDesc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRestoreDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(110)))), ((int)(((byte)(122)))));
            this.lblRestoreDesc.Location = new System.Drawing.Point(22, 40);
            this.lblRestoreDesc.Name = "lblRestoreDesc";
            this.lblRestoreDesc.Size = new System.Drawing.Size(540, 15);
            this.lblRestoreDesc.TabIndex = 1;
            this.lblRestoreDesc.Text = "Restaura la base de datos CarWashDB completa desde un archivo previo de copia de seguridad (.bak).";

            // 
            // lblRestoreWarning
            // 
            this.lblRestoreWarning.AutoSize = true;
            this.lblRestoreWarning.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRestoreWarning.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.lblRestoreWarning.Location = new System.Drawing.Point(22, 60);
            this.lblRestoreWarning.Name = "lblRestoreWarning";
            this.lblRestoreWarning.Size = new System.Drawing.Size(595, 15);
            this.lblRestoreWarning.TabIndex = 2;
            this.lblRestoreWarning.Text = "⚠️ ¡ADVERTENCIA CRÍTICA! Esta acción reemplazará permanentemente los datos actuales con la copia seleccionada.";

            // 
            // lblRutaRestore
            // 
            this.lblRutaRestore.AutoSize = true;
            this.lblRutaRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRutaRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.lblRutaRestore.Location = new System.Drawing.Point(22, 90);
            this.lblRutaRestore.Name = "lblRutaRestore";
            this.lblRutaRestore.Size = new System.Drawing.Size(155, 15);
            this.lblRutaRestore.TabIndex = 3;
            this.lblRutaRestore.Text = "Archivo (.bak) a restaurar:";

            // 
            // txtRutaRestore
            // 
            this.txtRutaRestore.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtRutaRestore.Location = new System.Drawing.Point(25, 110);
            this.txtRutaRestore.Name = "txtRutaRestore";
            this.txtRutaRestore.Size = new System.Drawing.Size(540, 24);
            this.txtRutaRestore.TabIndex = 4;

            // 
            // btnExaminarRestore
            // 
            this.btnExaminarRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.btnExaminarRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExaminarRestore.FlatAppearance.BorderSize = 0;
            this.btnExaminarRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExaminarRestore.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnExaminarRestore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.btnExaminarRestore.Location = new System.Drawing.Point(575, 108);
            this.btnExaminarRestore.Name = "btnExaminarRestore";
            this.btnExaminarRestore.Size = new System.Drawing.Size(130, 28);
            this.btnExaminarRestore.TabIndex = 5;
            this.btnExaminarRestore.Text = "📁 Seleccionar...";
            this.btnExaminarRestore.UseVisualStyleBackColor = false;
            this.btnExaminarRestore.Click += new System.EventHandler(this.btnExaminarRestore_Click);

            // 
            // btnRestaurarBackup
            // 
            this.btnRestaurarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.btnRestaurarBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurarBackup.FlatAppearance.BorderSize = 0;
            this.btnRestaurarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestaurarBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.btnRestaurarBackup.ForeColor = System.Drawing.Color.White;
            this.btnRestaurarBackup.Location = new System.Drawing.Point(25, 150);
            this.btnRestaurarBackup.Name = "btnRestaurarBackup";
            this.btnRestaurarBackup.Size = new System.Drawing.Size(240, 38);
            this.btnRestaurarBackup.TabIndex = 6;
            this.btnRestaurarBackup.Text = "🔄 Restaurar Base de Datos";
            this.btnRestaurarBackup.UseVisualStyleBackColor = false;
            this.btnRestaurarBackup.Click += new System.EventHandler(this.btnRestaurarBackup_Click);

            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEstado.Location = new System.Drawing.Point(25, 510);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(130, 15);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Listo para operaciones.";

            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(246)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(780, 540);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.panelRestoreCard);
            this.Controls.Add(this.panelBackupCard);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AquaWash - Copia de Seguridad y Restauración";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBackupCard.ResumeLayout(false);
            this.panelBackupCard.PerformLayout();
            this.panelRestoreCard.ResumeLayout(false);
            this.panelRestoreCard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel panelBackupCard;
        private System.Windows.Forms.Label lblBackupCardTitle;
        private System.Windows.Forms.Label lblBackupDesc;
        private System.Windows.Forms.Label lblRutaBackup;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.Button btnExaminarBackup;
        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.Panel panelRestoreCard;
        private System.Windows.Forms.Label lblRestoreCardTitle;
        private System.Windows.Forms.Label lblRestoreDesc;
        private System.Windows.Forms.Label lblRestoreWarning;
        private System.Windows.Forms.Label lblRutaRestore;
        private System.Windows.Forms.TextBox txtRutaRestore;
        private System.Windows.Forms.Button btnExaminarRestore;
        private System.Windows.Forms.Button btnRestaurarBackup;
        private System.Windows.Forms.Label lblEstado;
    }
}
