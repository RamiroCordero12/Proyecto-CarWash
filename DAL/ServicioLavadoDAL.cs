using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;
using MPP;

namespace DAL
{
    public class ServicioLavadoDAL
    {
        ConexionBD conexion = new ConexionBD();

        private List<ServicioLavadoMPP.FilaServicio> ListarFilas()
        {
            var lista = new List<ServicioLavadoMPP.FilaServicio>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT IdServicio, Nombre, PrecioBase, EsCombo FROM ServicioLavado", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(ServicioLavadoMPP.MapearFilaDesdeReader(reader));
                }
            }
            return lista;
        }

        private List<(int IdCombo, int IdServicio)> ListarJerarquia()
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

        // Único método público de lectura del árbol: el DAL orquesta
        // ListarFilas() + ListarJerarquia() + MPP.ArmarArbol(), y a BLL
        // le entrega el resultado ya armado como objetos de dominio (BE puro)
        public List<IComponenteServicio> ListarArbol()
        {
            var filas = ListarFilas();
            var jerarquia = ListarJerarquia();
            return ServicioLavadoMPP.ArmarArbol(filas, jerarquia);
        }

        // Para el combo de selección al armar un paquete nuevo:
        // devuelve solo los ServiIndividual, ya como objetos de dominio
        public List<ServiIndividual> ListarServiciosIndividuales()
        {
            var filas = ListarFilas();
            var lista = new List<ServiIndividual>();

            foreach (var fila in filas)
            {
                if (!fila.EsCombo)
                {
                    lista.Add(new ServiIndividual
                    {
                        IdServicio = fila.IdServicio,
                        Nombre = fila.Nombre,
                        Precio = fila.PrecioBase
                    });
                }
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
