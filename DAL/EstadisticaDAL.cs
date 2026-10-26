using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CarWash.BE;
using MPP;

namespace DAL
{
    public class EstadisticaDAL : IDisposable
    {
        private ConexionBD conexion = new ConexionBD();
        private bool disposed = false;

        public List<EstadisticaFacturacionDiaria> ListarFacturacionPorDia(DateTime fechaDesde, DateTime fechaHasta)
        {
            var lista = new List<EstadisticaFacturacionDiaria>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT CAST(FechaHora AS DATE) AS Fecha,
                                        SUM(Precio) AS TotalFacturado,
                                        COUNT(*) AS CantidadTurnos
                                 FROM TurnoWash
                                 WHERE Estado <> 'Cancelado'
                                   AND FechaHora >= @Desde AND FechaHora <= @Hasta
                                 GROUP BY CAST(FechaHora AS DATE)
                                 ORDER BY Fecha ASC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Desde", fechaDesde.Date);
                cmd.Parameters.AddWithValue("@Hasta", fechaHasta.Date.AddDays(1).AddTicks(-1));

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(EstadisticaMPP.MapearFacturacionDiaria(reader));
                    }
                }
            }
            return lista;
        }

        public List<EstadisticaServicioMes> ListarServiciosMasContratados(int mes, int anio)
        {
            var lista = new List<EstadisticaServicioMes>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT S.Nombre AS Servicio,
                                        COUNT(T.IdTurno) AS Cantidad,
                                        SUM(T.Precio) AS TotalRecaudado
                                 FROM TurnoWash T
                                 INNER JOIN ServicioLavado S ON T.IdServicio = S.IdServicio
                                 WHERE T.Estado <> 'Cancelado'
                                   AND MONTH(T.FechaHora) = @Mes
                                   AND YEAR(T.FechaHora) = @Anio
                                 GROUP BY S.Nombre
                                 ORDER BY Cantidad DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mes", mes);
                cmd.Parameters.AddWithValue("@Anio", anio);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(EstadisticaMPP.MapearServicioMes(reader));
                    }
                }
            }
            return lista;
        }

        public void ObtenerResumenMes(int mes, int anio, out decimal totalFacturado, out int totalTurnos, out decimal promedioTicket)
        {
            totalFacturado = 0m;
            totalTurnos = 0;
            promedioTicket = 0m;

            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT ISNULL(SUM(Precio), 0),
                                        COUNT(*),
                                        ISNULL(AVG(Precio), 0)
                                 FROM TurnoWash
                                 WHERE Estado <> 'Cancelado'
                                   AND MONTH(FechaHora) = @Mes
                                   AND YEAR(FechaHora) = @Anio";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Mes", mes);
                cmd.Parameters.AddWithValue("@Anio", anio);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        totalFacturado = reader.GetDecimal(0);
                        totalTurnos = reader.GetInt32(1);
                        promedioTicket = reader.GetDecimal(2);
                    }
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                conexion = null;
            }
            disposed = true;
        }
    }
}
