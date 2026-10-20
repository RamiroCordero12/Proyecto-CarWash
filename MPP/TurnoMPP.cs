using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public static class TurnoMPP
    {
        public static Turno MapearDesdeReader(SqlDataReader reader)
        {
            Turno turno = new Turno
            {
                IdTurno = reader.GetInt32(0),
                IdVehiculo = reader.GetInt32(1),
                IdServicio = reader.GetInt32(2),
                IdOperario = reader.GetInt32(3),
                IdUsuarioRegistro = reader.GetInt32(4),
                FechaHora = reader.GetDateTime(5),
                Precio = reader.GetDecimal(7),
                Patente = reader.GetString(8),
                NombreServicio = reader.GetString(9),
                NombreOperador = reader.GetString(10)
            };
            turno.Estado = (EstadoTurno)Enum.Parse(typeof(EstadoTurno), reader.GetString(6));
            return turno;
        }
    }
}
