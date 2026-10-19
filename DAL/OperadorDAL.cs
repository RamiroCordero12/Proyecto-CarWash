using CarWash.BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OperadorDAL : IABM<Operador, int>
    {
        ConexionBD conexion = new ConexionBD();

        public void Agregar(Operador operador)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "INSERT INTO Operarios (Nombre, PorcentajeComision) VALUES (@Nombre, @Comision)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nombre", operador.Nombre);
                cmd.Parameters.AddWithValue("@Comision", operador.PorcentajeComision);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Operador operador)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "UPDATE Operarios SET Nombre = @Nombre, PorcentajeComision = @Comision WHERE IdOperario = @Id";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", operador.IDOperador);
                cmd.Parameters.AddWithValue("@Nombre", operador.Nombre);
                cmd.Parameters.AddWithValue("@Comision", operador.PorcentajeComision);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idOperador)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Operarios WHERE IdOperario = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", idOperador);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex) when (ex.Number == 547)
                {
                    // FK desde TurnoWash: el operario ya tiene turnos asignados
                    throw new Exception("No se puede eliminar el operario porque tiene turnos asociados");
                }
            }
        }

        public List<Operador> Listar()
        {
            var lista = new List<Operador>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT IdOperario, Nombre, PorcentajeComision FROM Operarios", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(OperadorMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }
    }
}
