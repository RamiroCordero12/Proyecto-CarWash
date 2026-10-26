using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BackupDAL
    {
        private ConexionBD conexion = new ConexionBD();

        public void GenerarBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new ArgumentException("La ruta de destino del backup no puede estar vacía.");

            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = @"BACKUP DATABASE CarWashDB 
                               TO DISK = @Ruta 
                               WITH INIT, FORMAT, MEDIANAME = 'CarWash_Backup', NAME = 'Full Backup of CarWashDB';";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 180; // dar hasta 3 minutos para operaciones de backup
                    cmd.Parameters.AddWithValue("@Ruta", rutaDestino);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RestaurarBackup(string rutaOrigen)
        {
            if (string.IsNullOrWhiteSpace(rutaOrigen))
                throw new ArgumentException("La ruta de origen del backup no puede estar vacía.");

            // Se debe conectar a master para desconectar CarWashDB y restaurarla
            using (SqlConnection conn = conexion.ValidarConexionMaster())
            {
                conn.Open();
                string sql = @"
                    IF DB_ID('CarWashDB') IS NOT NULL
                    BEGIN
                        ALTER DATABASE CarWashDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    END;
                    
                    RESTORE DATABASE CarWashDB 
                    FROM DISK = @Ruta 
                    WITH REPLACE;
                    
                    ALTER DATABASE CarWashDB SET MULTI_USER;";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 300; // 5 minutos de timeout
                    cmd.Parameters.AddWithValue("@Ruta", rutaOrigen);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch
                    {
                        // Asegurar que la base vuelva a MULTI_USER si algo falló a la mitad
                        try
                        {
                            using (var cmdReset = new SqlCommand("IF DB_ID('CarWashDB') IS NOT NULL ALTER DATABASE CarWashDB SET MULTI_USER;", conn))
                            {
                                cmdReset.ExecuteNonQuery();
                            }
                        }
                        catch { }
                        throw;
                    }
                }
            }
        }
    }
}
