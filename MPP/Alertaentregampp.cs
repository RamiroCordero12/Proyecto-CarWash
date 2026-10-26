using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public static class AlertaEntregaMPP
    {
        // Orden esperado del SELECT:
        // IdAlerta, IdTurno, Patente, FechaCompletado, Marca, Color,
        // NombreCliente, Telefono, NombreServicio, NombreOperador
        public static Alertaentrega MapearDesdeReader(SqlDataReader reader)
        {
            return new Alertaentrega
            {
                IdAlerta = reader.GetInt32(0),
                IdTurno = reader.GetInt32(1),
                Patente = reader.IsDBNull(2) ? "" : reader.GetString(2),
                FechaCompletado = reader.IsDBNull(3) ? DateTime.Now : reader.GetDateTime(3),
                Marca = reader.IsDBNull(4) ? "" : reader.GetString(4),
                Color = reader.IsDBNull(5) ? "" : reader.GetString(5),
                NombreCliente = reader.IsDBNull(6) ? "" : reader.GetString(6),
                Telefono = reader.IsDBNull(7) ? "" : reader.GetString(7),
                NombreServicio = reader.IsDBNull(8) ? "" : reader.GetString(8),
                NombreOperador = reader.IsDBNull(9) ? "" : reader.GetString(9)
            };
        }
    }
}
