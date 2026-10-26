using System;
using System.Data.SqlClient;
using CarWash.BE;

namespace MPP
{
    public static class EstadisticaMPP
    {
        public static EstadisticaFacturacionDiaria MapearFacturacionDiaria(SqlDataReader reader)
        {
            return new EstadisticaFacturacionDiaria
            {
                Fecha = reader.GetDateTime(0),
                TotalFacturado = reader.IsDBNull(1) ? 0m : reader.GetDecimal(1),
                CantidadTurnos = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)
            };
        }

        public static EstadisticaServicioMes MapearServicioMes(SqlDataReader reader)
        {
            return new EstadisticaServicioMes
            {
                Servicio = reader.IsDBNull(0) ? "(Sin nombre)" : reader.GetString(0),
                Cantidad = reader.IsDBNull(1) ? 0 : reader.GetInt32(1),
                TotalRecaudado = reader.IsDBNull(2) ? 0m : reader.GetDecimal(2)
            };
        }
    }
}
