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
        ConexionBD conexion = new ConexionBD();

        public List<Hoja> ListarHojas()
        {
            var lista = new List<Hoja>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodHoja, NombreHoja, DescHoja FROM Hojas", conn);
                var reader = cmd.ExecuteReader();
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
            return lista;
        }

        public List<Familia> ListarFamilias()
        {
            var lista = new List<Familia>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFam, NombreFamilia, DescFamilia FROM Familia", conn);
                var reader = cmd.ExecuteReader();
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
            return lista;
        }

        // Relación Familia -> Hoja (Pat_Fam)
        public List<(int CodFam, int CodHoja)> ListarPatFam()
        {
            var lista = new List<(int, int)>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT CodFam, CodHoja FROM Pat_Fam", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
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
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
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
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(reader.GetInt32(0));
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
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(reader.GetInt32(0));
            }
            return lista;
        }
    }
}

