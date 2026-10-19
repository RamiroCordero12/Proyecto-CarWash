using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public static class OperadorMPP
    {
        // Orden esperado del SELECT: IdOperario, Nombre, PorcentajeComision
        public static Operador MapearDesdeReader(SqlDataReader reader)
        {
            return new Operador
            {
                IDOperador = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                PorcentajeComision = reader.GetDecimal(2)
            };
        }
    }
}
