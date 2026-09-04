using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE.Bitacora;
using MPP;

namespace DAL.Bitacora
{
    public class RegistroBitacoraDAL
    {
        ConexionBD conexion = new ConexionBD();

        // idUsuario ahora es int? — null cuando no hay usuario válido (ej. login fallido)
        public void Registrar(int? idUsuario, string accion, string modulo, Criticidad criticidad)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Bitacora (IdUsuario, Accion, FechaHora, Modulo, Criticidad)
                                  VALUES (@IdUsuario, @Accion, GETDATE(), @Modulo, @Criticidad)";
                var cmd = new SqlCommand(query, conn);

                if (idUsuario.HasValue)
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario.Value);
                else
                    cmd.Parameters.AddWithValue("@IdUsuario", DBNull.Value);

                cmd.Parameters.AddWithValue("@Accion", accion);
                cmd.Parameters.AddWithValue("@Modulo", modulo);
                cmd.Parameters.AddWithValue("@Criticidad", criticidad.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        // LEFT JOIN porque ahora puede haber registros sin Usuario asociado
        public List<RegistroBitacoraBE> Listar()
        {
            var lista = new List<RegistroBitacoraBE>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT B.IdBitacora, B.IdUsuario, U.NombreUsuario, B.Accion, B.FechaHora, B.Modulo, B.Criticidad
                                  FROM Bitacora B
                                  LEFT JOIN Usuario U ON B.IdUsuario = U.IdUsuario
                                  ORDER BY B.FechaHora DESC";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(RegistroBitacoraMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }
    }
}
