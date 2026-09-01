using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ConexionBD
    {     
        //Cadena que conecta la base de datos con el codigo
        //---------------------------------------------------
        //Cadena casa de ramiro: "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarWashDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";
        //---------------------------------------------------

        string cadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CarWashDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True";

        //Metodo que valida la conexion con la base de datos
        public SqlConnection ValidarConexion()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                return conexion;
            }
            catch
            {
                throw new Exception("Error al conectar la base de datos");
            }
        }
    }
}
