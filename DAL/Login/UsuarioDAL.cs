using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;
namespace DAL
{
    public class UsuarioDAL
    {
        ConexionBD conexion = new ConexionBD();

        // Devuelve el Usuario si NombreUsuario + hash coinciden, o null si no matchea
        public Usuario ValidarCredenciales(string nombreUsuario,string hashContraseña)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT IdUsuario, Nombre, Apellido, Email, NombreUsuario, Contrasena, CodRol
                                  FROM Usuario
                                  WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasena", hashContraseña);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Apellido = reader.GetString(2),
                        Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                        NombreUsuario = reader.GetString(4),
                        Contrasena = reader.GetString(5),
                        CodRol = reader.GetInt32(6)
                    };
                }
                return null;
            }
        }
        public string ObtenerNombreRol(int codRol)
        {
            using(SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT NombreRol FROM Roles WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@CodRol", codRol);
                var resultado = cmd.ExecuteScalar();
                return resultado?.ToString();
            }
        }
    }
}
