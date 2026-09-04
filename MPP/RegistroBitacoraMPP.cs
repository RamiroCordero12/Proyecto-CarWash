using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE.Bitacora;

namespace MPP
{
    //Mapeo del reader 
    public static class RegistroBitacoraMPP
    {
        public static RegistroBitacoraBE MapearDesdeReader(SqlDataReader reader)
        {
            return new RegistroBitacoraBE
            {
                IdBitacora = reader.GetInt32(0),
                IdUsuario = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                NombreUsuario = reader.IsDBNull(2) ? "(usuario desconocido)" : reader.GetString(2),
                Accion = reader.GetString(3),
                FechaHora = reader.GetDateTime(4),
                Modulo = reader.GetString(5),
                Criticidad = (Criticidad)System.Enum.Parse(
                    typeof(Criticidad), reader.GetString(6))
            };
        }
    }
}
