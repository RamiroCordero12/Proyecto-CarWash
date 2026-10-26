using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormBackup : Form
    {
        private BackupBLL backupBLL = new BackupBLL();

        public FormBackup()
        {
            InitializeComponent();
        }

        private void FormBackup_Load(object sender, EventArgs e)
        {
            SugerirRutaBackup();
        }

        private void SugerirRutaBackup()
        {
            string carpetaBackups = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CarWash_Backups");
            string archivoSugerido = $"CarWashDB_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
            txtRutaBackup.Text = Path.Combine(carpetaBackups, archivoSugerido);
        }

        private void btnExaminarBackup_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Seleccionar destino para la copia de seguridad";
                sfd.Filter = "Copia de Seguridad de SQL Server (*.bak)|*.bak";
                sfd.FileName = Path.GetFileName(txtRutaBackup.Text);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaBackup.Text = sfd.FileName;
                }
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRutaBackup.Text))
                {
                    MessageBox.Show("Debes ingresar una ruta para el archivo de backup.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.Cursor = Cursors.WaitCursor;
                lblEstado.Text = "Generando copia de seguridad... por favor espere.";
                Application.DoEvents();

                backupBLL.GenerarBackup(txtRutaBackup.Text.Trim());

                lblEstado.Text = $"Backup generado exitosamente a las {DateTime.Now:HH:mm:ss}.";
                MessageBox.Show(
                    $"La copia de seguridad se ha generado con éxito en:\n{txtRutaBackup.Text.Trim()}",
                    "Backup Exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Sugerir un nuevo nombre con timestamp para el próximo
                SugerirRutaBackup();
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al generar la copia de seguridad.";
                MessageBox.Show(
                    "Ocurrió un error al generar el backup:\n" + ex.Message,
                    "Error de Backup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExaminarRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Seleccionar archivo de copia de seguridad a restaurar";
                ofd.Filter = "Copia de Seguridad de SQL Server (*.bak)|*.bak|Todos los archivos (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtRutaRestore.Text = ofd.FileName;
                }
            }
        }

        private void btnRestaurarBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtRutaRestore.Text))
                {
                    MessageBox.Show("Debes seleccionar un archivo .bak para restaurar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(txtRutaRestore.Text.Trim()))
                {
                    MessageBox.Show("El archivo seleccionado no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var confirmacion = MessageBox.Show(
                    "¡ATENCIÓN! La restauración sobrescribirá todos los datos actuales de la base de datos CarWashDB con los del archivo seleccionado.\n\n" +
                    "¿Está completamente seguro de continuar con la restauración?",
                    "Confirmación de Restauración Crítica",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirmacion != DialogResult.Yes) return;

                this.Cursor = Cursors.WaitCursor;
                lblEstado.Text = "Restaurando base de datos... cerrando conexiones activas...";
                Application.DoEvents();

                backupBLL.RestaurarBackup(txtRutaRestore.Text.Trim());

                lblEstado.Text = $"Base de datos restaurada exitosamente a las {DateTime.Now:HH:mm:ss}.";
                MessageBox.Show(
                    "La base de datos CarWashDB ha sido restaurada con éxito desde la copia seleccionada.\n" +
                    "Se recomienda reiniciar la sesión para recargar los datos actualizados.",
                    "Restauración Completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Error al restaurar la base de datos.";
                MessageBox.Show(
                    "Ocurrió un error al restaurar la base de datos:\n" + ex.Message,
                    "Error de Restore",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
