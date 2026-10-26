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
        private ConexionBD conexion = new ConexionBD();

        // Devuelve el Usuario si NombreUsuario + hash coinciden, o null si no matchea
        public Usuario ValidarCredenciales(string nombreUsuario, string hashContraseña)
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

                using (var reader = cmd.ExecuteReader())
                {
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
                }
                return null;
            }
        }

        public string ObtenerNombreRol(int codRol)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT NombreRol FROM Roles WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@CodRol", codRol);
                var resultado = cmd.ExecuteScalar();
                return resultado?.ToString();
            }
        }

        #region CU16 - ABM Usuarios

        public List<Usuario> Listar()
        {
            var lista = new List<Usuario>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Email, U.NombreUsuario, U.Contrasena, U.CodRol,
                                        R.NombreRol, R.DescRol
                                 FROM Usuario U
                                 INNER JOIN Roles R ON U.CodRol = R.CodRol
                                 ORDER BY U.IdUsuario";
                var cmd = new SqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var u = new Usuario
                        {
                            IdUsuario = reader.GetInt32(0),
                            Nombre = reader.GetString(1),
                            Apellido = reader.GetString(2),
                            Email = reader.IsDBNull(3) ? null : reader.GetString(3),
                            NombreUsuario = reader.GetString(4),
                            Contrasena = reader.GetString(5),
                            CodRol = reader.GetInt32(6),
                            Rol = new Rol
                            {
                                CodRol = reader.GetInt32(6),
                                NombreRol = reader.GetString(7),
                                DescRol = reader.IsDBNull(8) ? null : reader.GetString(8)
                            }
                        };
                        lista.Add(u);
                    }
                }
            }
            return lista;
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT U.IdUsuario, U.Nombre, U.Apellido, U.Email, U.NombreUsuario, U.Contrasena, U.CodRol,
                                        R.NombreRol, R.DescRol
                                 FROM Usuario U
                                 INNER JOIN Roles R ON U.CodRol = R.CodRol
                                 WHERE U.IdUsuario = @IdUsuario";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                using (var reader = cmd.ExecuteReader())
                {
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
                            CodRol = reader.GetInt32(6),
                            Rol = new Rol
                            {
                                CodRol = reader.GetInt32(6),
                                NombreRol = reader.GetString(7),
                                DescRol = reader.IsDBNull(8) ? null : reader.GetString(8)
                            }
                        };
                    }
                }
            }
            return null;
        }

        public bool ExisteNombreUsuario(string nombreUsuario, int? excluirIdUsuario = null)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Usuario WHERE NombreUsuario = @NombreUsuario";
                if (excluirIdUsuario.HasValue)
                    sql += " AND IdUsuario <> @ExcluirIdUsuario";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                if (excluirIdUsuario.HasValue)
                    cmd.Parameters.AddWithValue("@ExcluirIdUsuario", excluirIdUsuario.Value);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int Agregar(Usuario usuario)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = @"INSERT INTO Usuario (Nombre, Apellido, Email, NombreUsuario, Contrasena, CodRol)
                               VALUES (@Nombre, @Apellido, @Email, @NombreUsuario, @Contrasena, @CodRol);
                               SELECT SCOPE_IDENTITY();";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", (object)usuario.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);
                cmd.Parameters.AddWithValue("@CodRol", usuario.CodRol);

                usuario.IdUsuario = Convert.ToInt32(cmd.ExecuteScalar());
                return usuario.IdUsuario;
            }
        }

        public void Modificar(Usuario usuario, bool actualizarContrasena = false)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql;
                if (actualizarContrasena)
                {
                    sql = @"UPDATE Usuario 
                            SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, 
                                NombreUsuario = @NombreUsuario, Contrasena = @Contrasena, CodRol = @CodRol
                            WHERE IdUsuario = @IdUsuario";
                }
                else
                {
                    sql = @"UPDATE Usuario 
                            SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, 
                                NombreUsuario = @NombreUsuario, CodRol = @CodRol
                            WHERE IdUsuario = @IdUsuario";
                }

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@Email", (object)usuario.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@CodRol", usuario.CodRol);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                if (actualizarContrasena)
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contrasena);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idUsuario)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                // Validar si tiene turnos registrados
                var cmdTurnos = new SqlCommand("SELECT COUNT(1) FROM TurnoWash WHERE IdUsuarioRegistro = @IdUsuario", conn);
                cmdTurnos.Parameters.AddWithValue("@IdUsuario", idUsuario);
                int turnos = (int)cmdTurnos.ExecuteScalar();
                if (turnos > 0)
                    throw new InvalidOperationException($"No se puede eliminar el usuario porque tiene {turnos} turno(s) registrado(s) en auditoría.");

                // Bitácora registros con IdUsuario
                // En RegistroBitacora, IdUsuario es FK nullable o NOT NULL?
                // En ScriptBD.sql: FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario) ON DELETE SET NULL si fuera, o verificar
                var cmdBit = new SqlCommand("SELECT COUNT(1) FROM RegistroBitacora WHERE IdUsuario = @IdUsuario", conn);
                cmdBit.Parameters.AddWithValue("@IdUsuario", idUsuario);
                int bitacoraCount = (int)cmdBit.ExecuteScalar();
                if (bitacoraCount > 0)
                {
                    // Si tiene bitácora, desvincular o impedir
                    var cmdNull = new SqlCommand("UPDATE RegistroBitacora SET IdUsuario = NULL WHERE IdUsuario = @IdUsuario", conn);
                    cmdNull.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmdNull.ExecuteNonQuery();
                }

                var cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        #endregion
    }
}
