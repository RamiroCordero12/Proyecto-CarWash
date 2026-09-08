using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ServicioLavadoDAL
    {
        ConexionBD conexion = new ConexionBD();

        // Fila cruda de ServicioLavado, sin armar todavía el Composite
        public class FilaServicio
        {
            public int IdServicio { get; set; }
            public string Nombre { get; set; }
            public decimal PrecioBase { get; set; }
            public bool EsCombo { get; set; }
        }

        public List<FilaServicio> ListarFilas()
        {
            var lista = new List<FilaServicio>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT IdServicio, Nombre, PrecioBase, EsCombo FROM ServicioLavado", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new FilaServicio
                    {
                        IdServicio = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        PrecioBase = reader.GetDecimal(2),
                        EsCombo = reader.GetBoolean(3)
                    });
                }
            }
            return lista;
        }

        // Relación combo -> componente
        public List<(int IdCombo, int IdServicio)> ListarJerarquia()
        {
            var lista = new List<(int, int)>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT IdCombo, IdServicio FROM LavadoJerarquia", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add((reader.GetInt32(0), reader.GetInt32(1)));
            }
            return lista;
        }

        public void AgregarServicioIndividual(string nombre, decimal precio)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO ServicioLavado (Nombre, PrecioBase, EsCombo) VALUES (@Nombre, @Precio, 0)",
                    conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precio);
                cmd.ExecuteNonQuery();
            }
        }

        public int AgregarCombo(string nombre, decimal precioFinal)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"INSERT INTO ServicioLavado (Nombre, PrecioBase, EsCombo)
                      OUTPUT INSERTED.IdServicio
                      VALUES (@Nombre, @Precio, 1)",
                    conn);
                cmd.Parameters.AddWithValue("@Nombre", nombre);
                cmd.Parameters.AddWithValue("@Precio", precioFinal);
                return (int)cmd.ExecuteScalar();
            }
        }

        public void AgregarComponenteACombo(int idCombo, int idServicioComponente)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO LavadoJerarquia (IdCombo, IdServicio) VALUES (@IdCombo, @IdServicio)",
                    conn);
                cmd.Parameters.AddWithValue("@IdCombo", idCombo);
                cmd.Parameters.AddWithValue("@IdServicio", idServicioComponente);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idServicio)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                // Primero limpiar relaciones donde participe (como combo o como componente)
                var cmdJerarquia = new SqlCommand(
                    "DELETE FROM LavadoJerarquia WHERE IdCombo = @Id OR IdServicio = @Id", conn);
                cmdJerarquia.Parameters.AddWithValue("@Id", idServicio);
                cmdJerarquia.ExecuteNonQuery();

                var cmd = new SqlCommand("DELETE FROM ServicioLavado WHERE IdServicio = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", idServicio);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
