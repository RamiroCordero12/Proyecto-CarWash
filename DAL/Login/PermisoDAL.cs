using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;

namespace DAL
{
    public class PermisoDAL
    {
        private ConexionBD conexion = new ConexionBD();

        #region Lecturas Básicas

        public List<Hoja> ListarHojas()
        {
            var lista = new List<Hoja>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodHoja, NombreHoja, DescHoja FROM Hojas ORDER BY NombreHoja", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Hoja
                        {
                            CodHoja = reader.GetInt32(0),
                            NombreHoja = reader.GetString(1),
                            DescHoja = reader.IsDBNull(2) ? null : reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public List<Familia> ListarFamilias()
        {
            var lista = new List<Familia>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFam, NombreFamilia, DescFamilia FROM Familia ORDER BY NombreFamilia", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Familia
                        {
                            CodFam = reader.GetInt32(0),
                            NombreFamilia = reader.GetString(1),
                            DescFamilia = reader.IsDBNull(2) ? null : reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public List<Rol> ListarRoles()
        {
            var lista = new List<Rol>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodRol, NombreRol, DescRol FROM Roles ORDER BY CodRol", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Rol
                        {
                            CodRol = reader.GetInt32(0),
                            NombreRol = reader.GetString(1),
                            DescRol = reader.IsDBNull(2) ? null : reader.GetString(2)
                        });
                    }
                }
            }
            return lista;
        }

        public Rol ObtenerRolPorId(int codRol)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodRol, NombreRol, DescRol FROM Roles WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@CodRol", codRol);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Rol
                        {
                            CodRol = reader.GetInt32(0),
                            NombreRol = reader.GetString(1),
                            DescRol = reader.IsDBNull(2) ? null : reader.GetString(2)
                        };
                    }
                }
            }
            return null;
        }

        // Relación Familia -> Hoja (Pat_Fam)
        public List<(int CodFam, int CodHoja)> ListarPatFam()
        {
            var lista = new List<(int, int)>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFam, CodHoja FROM Pat_Fam", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
                }
            }
            return lista;
        }

        // Relación Familia -> Familia (Fam_Fam)
        public List<(int CodFamPadre, int CodFamHijo)> ListarFamFam()
        {
            var lista = new List<(int, int)>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFamPadre, CodFamHijo FROM Fam_Fam", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
                }
            }
            return lista;
        }

        // Asignaciones al Rol
        public List<int> ListarFamiliasDeRol(int codRol)
        {
            var lista = new List<int>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFam FROM Rol_Fam WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@CodRol", codRol);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(reader.GetInt32(0));
                }
            }
            return lista;
        }

        public List<int> ListarHojasDeRol(int codRol)
        {
            var lista = new List<int>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodHoja FROM Rol_Pat WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@CodRol", codRol);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(reader.GetInt32(0));
                }
            }
            return lista;
        }

        #endregion

        #region CU13 - ABM Roles

        public bool ExisteNombreRol(string nombreRol, int? excluirCodRol = null)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Roles WHERE NombreRol = @NombreRol";
                if (excluirCodRol.HasValue)
                    sql += " AND CodRol <> @ExcluirCodRol";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreRol", nombreRol);
                if (excluirCodRol.HasValue)
                    cmd.Parameters.AddWithValue("@ExcluirCodRol", excluirCodRol.Value);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int CrearRol(Rol rol)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Roles (NombreRol, DescRol) VALUES (@NombreRol, @DescRol); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@NombreRol", rol.NombreRol);
                cmd.Parameters.AddWithValue("@DescRol", (object)rol.DescRol ?? DBNull.Value);

                rol.CodRol = Convert.ToInt32(cmd.ExecuteScalar());
                return rol.CodRol;
            }
        }

        public void ModificarRol(Rol rol)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Roles SET NombreRol = @NombreRol, DescRol = @DescRol WHERE CodRol = @CodRol", conn);
                cmd.Parameters.AddWithValue("@NombreRol", rol.NombreRol);
                cmd.Parameters.AddWithValue("@DescRol", (object)rol.DescRol ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodRol", rol.CodRol);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarRol(int codRol)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                // Validar si tiene usuarios asociados
                var cmdCheck = new SqlCommand("SELECT COUNT(1) FROM Usuario WHERE CodRol = @CodRol", conn);
                cmdCheck.Parameters.AddWithValue("@CodRol", codRol);
                int usuariosAsociados = (int)cmdCheck.ExecuteScalar();
                if (usuariosAsociados > 0)
                    throw new InvalidOperationException($"No se puede eliminar el rol porque tiene {usuariosAsociados} usuario(s) asignado(s).");

                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdFam = new SqlCommand("DELETE FROM Rol_Fam WHERE CodRol = @CodRol", conn, tran);
                        cmdFam.Parameters.AddWithValue("@CodRol", codRol);
                        cmdFam.ExecuteNonQuery();

                        var cmdPat = new SqlCommand("DELETE FROM Rol_Pat WHERE CodRol = @CodRol", conn, tran);
                        cmdPat.Parameters.AddWithValue("@CodRol", codRol);
                        cmdPat.ExecuteNonQuery();

                        var cmdRol = new SqlCommand("DELETE FROM Roles WHERE CodRol = @CodRol", conn, tran);
                        cmdRol.Parameters.AddWithValue("@CodRol", codRol);
                        cmdRol.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region CU14 - ABM Hojas y Familias

        public bool ExisteNombreHoja(string nombreHoja, int? excluirCodHoja = null)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Hojas WHERE NombreHoja = @NombreHoja";
                if (excluirCodHoja.HasValue)
                    sql += " AND CodHoja <> @ExcluirCodHoja";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreHoja", nombreHoja);
                if (excluirCodHoja.HasValue)
                    cmd.Parameters.AddWithValue("@ExcluirCodHoja", excluirCodHoja.Value);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int CrearHoja(Hoja hoja)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Hojas (NombreHoja, DescHoja) VALUES (@NombreHoja, @DescHoja); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@NombreHoja", hoja.NombreHoja);
                cmd.Parameters.AddWithValue("@DescHoja", (object)hoja.DescHoja ?? DBNull.Value);

                hoja.CodHoja = Convert.ToInt32(cmd.ExecuteScalar());
                return hoja.CodHoja;
            }
        }

        public void ModificarHoja(Hoja hoja)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Hojas SET NombreHoja = @NombreHoja, DescHoja = @DescHoja WHERE CodHoja = @CodHoja", conn);
                cmd.Parameters.AddWithValue("@NombreHoja", hoja.NombreHoja);
                cmd.Parameters.AddWithValue("@DescHoja", (object)hoja.DescHoja ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodHoja", hoja.CodHoja);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarHoja(int codHoja)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdPatFam = new SqlCommand("DELETE FROM Pat_Fam WHERE CodHoja = @CodHoja", conn, tran);
                        cmdPatFam.Parameters.AddWithValue("@CodHoja", codHoja);
                        cmdPatFam.ExecuteNonQuery();

                        var cmdRolPat = new SqlCommand("DELETE FROM Rol_Pat WHERE CodHoja = @CodHoja", conn, tran);
                        cmdRolPat.Parameters.AddWithValue("@CodHoja", codHoja);
                        cmdRolPat.ExecuteNonQuery();

                        var cmdHoja = new SqlCommand("DELETE FROM Hojas WHERE CodHoja = @CodHoja", conn, tran);
                        cmdHoja.Parameters.AddWithValue("@CodHoja", codHoja);
                        cmdHoja.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public bool ExisteNombreFamilia(string nombreFamilia, int? excluirCodFam = null)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string sql = "SELECT COUNT(1) FROM Familia WHERE NombreFamilia = @NombreFamilia";
                if (excluirCodFam.HasValue)
                    sql += " AND CodFam <> @ExcluirCodFam";

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NombreFamilia", nombreFamilia);
                if (excluirCodFam.HasValue)
                    cmd.Parameters.AddWithValue("@ExcluirCodFam", excluirCodFam.Value);

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        public int CrearFamilia(Familia fam)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Familia (NombreFamilia, DescFamilia) VALUES (@NombreFamilia, @DescFamilia); SELECT SCOPE_IDENTITY();", conn);
                cmd.Parameters.AddWithValue("@NombreFamilia", fam.NombreFamilia);
                cmd.Parameters.AddWithValue("@DescFamilia", (object)fam.DescFamilia ?? DBNull.Value);

                fam.CodFam = Convert.ToInt32(cmd.ExecuteScalar());
                return fam.CodFam;
            }
        }

        public void ModificarFamilia(Familia fam)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "UPDATE Familia SET NombreFamilia = @NombreFamilia, DescFamilia = @DescFamilia WHERE CodFam = @CodFam", conn);
                cmd.Parameters.AddWithValue("@NombreFamilia", fam.NombreFamilia);
                cmd.Parameters.AddWithValue("@DescFamilia", (object)fam.DescFamilia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodFam", fam.CodFam);
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarFamilia(int codFam)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        var cmdFamFam = new SqlCommand("DELETE FROM Fam_Fam WHERE CodFamPadre = @CodFam OR CodFamHijo = @CodFam", conn, tran);
                        cmdFamFam.Parameters.AddWithValue("@CodFam", codFam);
                        cmdFamFam.ExecuteNonQuery();

                        var cmdPatFam = new SqlCommand("DELETE FROM Pat_Fam WHERE CodFam = @CodFam", conn, tran);
                        cmdPatFam.Parameters.AddWithValue("@CodFam", codFam);
                        cmdPatFam.ExecuteNonQuery();

                        var cmdRolFam = new SqlCommand("DELETE FROM Rol_Fam WHERE CodFam = @CodFam", conn, tran);
                        cmdRolFam.Parameters.AddWithValue("@CodFam", codFam);
                        cmdRolFam.ExecuteNonQuery();

                        var cmdFam = new SqlCommand("DELETE FROM Familia WHERE CodFam = @CodFam", conn, tran);
                        cmdFam.Parameters.AddWithValue("@CodFam", codFam);
                        cmdFam.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion

        #region CU15 - Asignaciones Composite (Guardado integral y atómico)

        public void GuardarPermisosRol(int codRol, IEnumerable<int> codFamilias, IEnumerable<int> codHojas)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Limpiar asignaciones previas del rol
                        var cmdDelFam = new SqlCommand("DELETE FROM Rol_Fam WHERE CodRol = @CodRol", conn, tran);
                        cmdDelFam.Parameters.AddWithValue("@CodRol", codRol);
                        cmdDelFam.ExecuteNonQuery();

                        var cmdDelPat = new SqlCommand("DELETE FROM Rol_Pat WHERE CodRol = @CodRol", conn, tran);
                        cmdDelPat.Parameters.AddWithValue("@CodRol", codRol);
                        cmdDelPat.ExecuteNonQuery();

                        // 2. Insertar familias asignadas
                        if (codFamilias != null)
                        {
                            foreach (int codFam in codFamilias.Distinct())
                            {
                                var cmdInsFam = new SqlCommand("INSERT INTO Rol_Fam (CodRol, CodFam) VALUES (@CodRol, @CodFam)", conn, tran);
                                cmdInsFam.Parameters.AddWithValue("@CodRol", codRol);
                                cmdInsFam.Parameters.AddWithValue("@CodFam", codFam);
                                cmdInsFam.ExecuteNonQuery();
                            }
                        }

                        // 3. Insertar hojas sueltas asignadas
                        if (codHojas != null)
                        {
                            foreach (int codHoja in codHojas.Distinct())
                            {
                                var cmdInsHoja = new SqlCommand("INSERT INTO Rol_Pat (CodRol, CodHoja) VALUES (@CodRol, @CodHoja)", conn, tran);
                                cmdInsHoja.Parameters.AddWithValue("@CodRol", codRol);
                                cmdInsHoja.Parameters.AddWithValue("@CodHoja", codHoja);
                                cmdInsHoja.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        public void GuardarContenidoFamilia(int codFamPadre, IEnumerable<int> codSubfamilias, IEnumerable<int> codHojas)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Limpiar asignaciones previas de la familia padre
                        var cmdDelFam = new SqlCommand("DELETE FROM Fam_Fam WHERE CodFamPadre = @CodFamPadre", conn, tran);
                        cmdDelFam.Parameters.AddWithValue("@CodFamPadre", codFamPadre);
                        cmdDelFam.ExecuteNonQuery();

                        var cmdDelPat = new SqlCommand("DELETE FROM Pat_Fam WHERE CodFam = @CodFamPadre", conn, tran);
                        cmdDelPat.Parameters.AddWithValue("@CodFamPadre", codFamPadre);
                        cmdDelPat.ExecuteNonQuery();

                        // 2. Insertar subfamilias
                        if (codSubfamilias != null)
                        {
                            foreach (int codHijo in codSubfamilias.Distinct())
                            {
                                if (codHijo == codFamPadre) continue; // seguridad extra
                                var cmdInsFam = new SqlCommand("INSERT INTO Fam_Fam (CodFamPadre, CodFamHijo) VALUES (@CodFamPadre, @CodFamHijo)", conn, tran);
                                cmdInsFam.Parameters.AddWithValue("@CodFamPadre", codFamPadre);
                                cmdInsFam.Parameters.AddWithValue("@CodFamHijo", codHijo);
                                cmdInsFam.ExecuteNonQuery();
                            }
                        }

                        // 3. Insertar hojas agrupadas
                        if (codHojas != null)
                        {
                            foreach (int codHoja in codHojas.Distinct())
                            {
                                var cmdInsHoja = new SqlCommand("INSERT INTO Pat_Fam (CodFam, CodHoja) VALUES (@CodFam, @CodHoja)", conn, tran);
                                cmdInsHoja.Parameters.AddWithValue("@CodFam", codFamPadre);
                                cmdInsHoja.Parameters.AddWithValue("@CodHoja", codHoja);
                                cmdInsHoja.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }

        #endregion
    }
}
