using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP;
namespace DAL
{
    public class AlertaEntregaDAL : IDisposable
    {
        private ConexionBD conexion = new ConexionBD();
        private bool disposed = false;

        // Solo las alertas cuyo turno sigue en LavadoTerminado.
        // Cuando el turno pasa a Entregado (o se cancela), sale solo del tablero,
        // así no hace falta agregar columnas a la tabla AlertaEntregaWash.
        public List<Alertaentrega> ListarPendientes()
        {
            var lista = new List<Alertaentrega>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT A.IdAlerta, A.IdTurno, A.Patente, A.FechaCompletado,
                                        V.Marca, V.Color,
                                        C.Nombre + ' ' + C.Apellido, C.Telefono,
                                        S.Nombre, O.Nombre
                                 FROM AlertaEntregaWash A
                                 INNER JOIN TurnoWash T ON A.IdTurno = T.IdTurno
                                 INNER JOIN Vehiculos V ON T.IdVehiculo = V.IdVehiculo
                                 INNER JOIN Clientes C ON V.DNI = C.DNI
                                 INNER JOIN ServicioLavado S ON T.IdServicio = S.IdServicio
                                 INNER JOIN Operarios O ON T.IdOperario = O.IdOperario
                                 WHERE T.Estado = 'LavadoTerminado'
                                   AND A.IdAlerta = (
                                       SELECT MAX(A2.IdAlerta)
                                       FROM AlertaEntregaWash A2
                                       WHERE A2.IdTurno = T.IdTurno
                                   )
                                 ORDER BY A.FechaCompletado DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        lista.Add(AlertaEntregaMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing) conexion = null;
            disposed = true;
        }
    }
}
