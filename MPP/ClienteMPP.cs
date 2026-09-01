using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;

namespace MPP
{
    public static class ClienteMPP
    {
        public static Cliente MapearDesdeReader(SqlDataReader reader)
        {
            return new Cliente
            {
                DNI = reader.GetString(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                Telefono = reader.IsDBNull(3) ? null : reader.GetString(3)
            };
        }
    }
}