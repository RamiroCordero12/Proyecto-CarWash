using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;
using MPP;

namespace DAL
{
    public class ClienteDAL : IABM<Cliente, string>
    {
        ConexionBD conexion = new ConexionBD();
     
        // Modo Conectado(Altas) 
        
        public void Agregar(Cliente cliente)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "INSERT INTO Clientes (DNI, Nombre, Apellido, Telefono) VALUES (@DNI, @Nombre, @Apellido, @Telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();
            }
        }

        public void Eliminar(string dni)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "DELETE FROM Clientes WHERE DNI = @DNI";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DNI", dni);

                cmd.ExecuteNonQuery();
            }
        }

        public void Modificar(Cliente cliente)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "UPDATE Clientes SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono WHERE DNI=@DNI";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@DNI", cliente.DNI);
                cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                cmd.ExecuteNonQuery();
            }
        }

        public List<Cliente> Listar()
        {
            List<Cliente> lista = new List<Cliente>();

            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "SELECT DNI, Nombre, Apellido, Telefono FROM Clientes";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(ClienteMPP.MapearDesdeReader(reader)); // <-- ahora pasa por MPP
                }
            }
            return lista;
        }


        //MODO DESCONECTADO(Consultas)

        public DataSet ListarDataSet()
        {
            // No pasa por MPP, ya que el modo desconectado trabaja nativamente con data set/table porque son genericos
            DataSet ds = new DataSet();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = "SELECT DNI, Nombre, Apellido, Telefono FROM Clientes";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(ds, "Clientes");
            }
            return ds;
        }

        // EJEMPLO MODO DESCONECTADO (Consultas) con DataView
        
        public DataTable BuscarPorApellido(DataSet dsOrigen, string apellido)
        {
            
            DataView vista = new DataView(dsOrigen.Tables["Clientes"]);
            vista.RowFilter = $"Apellido LIKE '%{apellido}%'";
            return vista.ToTable(); 
        }


    }
}
