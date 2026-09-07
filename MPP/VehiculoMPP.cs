using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;

namespace MPP
{
    public class VehiculoMPP
    {
        // Orden esperado del SELECT: IdVehiculo, Patente, TipoVehiculo, DNI, Marca, Color
        public static Vehiculo MapearDesdeReader(SqlDataReader reader)
        {
            int idVehiculo = reader.GetInt32(0);
            string patente = reader.GetString(1);
            string tipoVehiculo = reader.GetString(2);
            string dni = reader.GetString(3);
            string marca = reader.IsDBNull(4) ? null : reader.GetString(4);
            string color = reader.IsDBNull(5) ? null : reader.GetString(5);

            Vehiculo vehiculo;

            switch (tipoVehiculo)
            {
                case "Sedan":
                    vehiculo = new Sedan();
                    break;

                case "SUV_Camioneta":
                    vehiculo = new SUV_Camioneta();
                    break;

                default:
                    throw new ArgumentException(
                        $"Tipo de vehículo desconocido en la base: {tipoVehiculo}");
            }

            vehiculo.IdVehiculo = idVehiculo;
            vehiculo.Patente = patente;
            vehiculo.DNI = int.Parse(dni);
            vehiculo.Marca = marca;
            vehiculo.Color = color;

            return vehiculo;
        }

        // El string a persistir en TipoVehiculo sale por polimorfismo,
        // no por switch — cada derivada ya sabe su propio Tipo
        public static string ObtenerTipoParaPersistir(Vehiculo vehiculo)
        {
            return vehiculo.Tipo;
        }
    }
}
