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
    public class VehiculoDAL
    {
        ConexionBD conexion = new ConexionBD();

        public void Agregar(Vehiculo vehiculo)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"INSERT INTO Vehiculos (Patente, TipoVehiculo, DNI, Marca, Color)
                                  VALUES (@Patente, @TipoVehiculo, @DNI, @Marca, @Color)";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                cmd.Parameters.AddWithValue("@TipoVehiculo", VehiculoMPP.ObtenerTipoParaPersistir(vehiculo));
                cmd.Parameters.AddWithValue("@DNI", vehiculo.DNI);
                cmd.Parameters.AddWithValue("@Marca", (object)vehiculo.Marca ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Color", (object)vehiculo.Color ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idVehiculo)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "DELETE FROM Vehiculos WHERE IdVehiculo = @IdVehiculo";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVehiculo", idVehiculo);
                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Vehiculo vehiculo)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                // Nota: no se permite cambiar el Tipo (Sedan <-> SUV) desde Modificar,
                // porque cambiaría la clase concreta del objeto. Si el usuario se
                // equivocó de tipo, se elimina y se da de alta de nuevo.
                string query = @"UPDATE Vehiculos
                                  SET Patente = @Patente, DNI = @DNI, Marca = @Marca, Color = @Color
                                  WHERE IdVehiculo = @IdVehiculo";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdVehiculo", vehiculo.IdVehiculo);
                cmd.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                cmd.Parameters.AddWithValue("@DNI", vehiculo.DNI);
                cmd.Parameters.AddWithValue("@Marca", (object)vehiculo.Marca ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Color", (object)vehiculo.Color ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Vehiculo> Listar()
        {
            var lista = new List<Vehiculo>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "SELECT IdVehiculo, Patente, TipoVehiculo, DNI, Marca, Color FROM Vehiculos";
                var cmd = new SqlCommand(query, conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(VehiculoMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }

        // Útil para el ABM: traer solo los vehículos de un cliente puntual
        public List<Vehiculo> ListarPorCliente(string dni)
        {
            var lista = new List<Vehiculo>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "SELECT IdVehiculo, Patente, TipoVehiculo, DNI, Marca, Color FROM Vehiculos WHERE DNI = @DNI";
                var cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@DNI", dni);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(VehiculoMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }
}
