using BLL.Bitacora;
using CarWash.BE.Bitacora;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BackupBLL
    {
        private BackupDAL dal = new BackupDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        private int? ObtenerIdUsuarioActual()
        {
            return SesionActual.Instancia?.UsuarioLogueado?.IdUsuario;
        }

        public void GenerarBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new Exception("Debes especificar la ruta de destino para el archivo de backup.");

            if (!rutaDestino.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                rutaDestino += ".bak";

            string directorio = Path.GetDirectoryName(rutaDestino);
            if (!string.IsNullOrEmpty(directorio) && !Directory.Exists(directorio))
                Directory.CreateDirectory(directorio);

            dal.GenerarBackup(rutaDestino);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Generación de copia de seguridad (Backup) en: {rutaDestino}",
                modulo: "BaseDeDatos",
                criticidad: Criticidad.Alta);
        }

        public void RestaurarBackup(string rutaOrigen)
        {
            if (string.IsNullOrWhiteSpace(rutaOrigen))
                throw new Exception("Debes seleccionar un archivo de copia de seguridad (.bak).");

            if (!File.Exists(rutaOrigen))
                throw new FileNotFoundException($"El archivo de backup seleccionado no existe: {rutaOrigen}");

            if (!rutaOrigen.EndsWith(".bak", StringComparison.OrdinalIgnoreCase))
                throw new Exception("El archivo seleccionado no tiene la extensión .bak requerida.");

            dal.RestaurarBackup(rutaOrigen);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Restauración de base de datos desde copia de seguridad: {rutaOrigen}",
                modulo: "BaseDeDatos",
                criticidad: Criticidad.Alta);
        }
    }
}
