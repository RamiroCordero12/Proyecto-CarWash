using CarWash.BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TurnoDAL : IDisposable
    {
        private ConexionBD conexion = new ConexionBD();
        private bool disposed = false;

        public void Agregar(Turno turno)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (SqlTransaction tx = conn.BeginTransaction())
                {
                    try
                    {
                        string query = @"INSERT INTO TurnoWash
                            (IdVehiculo, IdServicio, IdOperario, IdUsuarioRegistro, FechaHora, Estado, Precio)
                            VALUES (@IdVehiculo, @IdServicio, @IdOperario, @IdUsuario, @FechaHora, @Estado, @Precio)";
                        SqlCommand cmd = new SqlCommand(query, conn, tx);
                        cmd.Parameters.AddWithValue("@IdVehiculo", turno.IdVehiculo);
                        cmd.Parameters.AddWithValue("@IdServicio", turno.IdServicio);
                        cmd.Parameters.AddWithValue("@IdOperario", turno.IdOperario);
                        cmd.Parameters.AddWithValue("@IdUsuario", turno.IdUsuarioRegistro);
                        cmd.Parameters.AddWithValue("@FechaHora", turno.FechaHora);
                        cmd.Parameters.AddWithValue("@Estado", turno.Estado.ToString());
                        cmd.Parameters.AddWithValue("@Precio", turno.Precio);
                        cmd.ExecuteNonQuery();
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Modificar(Turno turno)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"UPDATE TurnoWash
                                 SET IdVehiculo = @IdVehiculo,
                                     IdServicio = @IdServicio,
                                     IdOperario = @IdOperario,
                                     FechaHora = @FechaHora,
                                     Precio = @Precio
                                 WHERE IdTurno = @IdTurno";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdVehiculo", turno.IdVehiculo);
                    cmd.Parameters.AddWithValue("@IdServicio", turno.IdServicio);
                    cmd.Parameters.AddWithValue("@IdOperario", turno.IdOperario);
                    cmd.Parameters.AddWithValue("@FechaHora", turno.FechaHora);
                    cmd.Parameters.AddWithValue("@Precio", turno.Precio);
                    cmd.Parameters.AddWithValue("@IdTurno", turno.IdTurno);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar(int idTurno)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Eliminar alertas asociadas si existen
                        var cmdAlertas = new SqlCommand("DELETE FROM AlertaEntregaWash WHERE IdTurno = @IdTurno", conn, tx);
                        cmdAlertas.Parameters.AddWithValue("@IdTurno", idTurno);
                        cmdAlertas.ExecuteNonQuery();

                        // 2. Eliminar el turno
                        var cmdTurno = new SqlCommand("DELETE FROM TurnoWash WHERE IdTurno = @IdTurno", conn, tx);
                        cmdTurno.Parameters.AddWithValue("@IdTurno", idTurno);
                        cmdTurno.ExecuteNonQuery();

                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<Turno> Listar()
        {
            var lista = new List<Turno>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                string query = @"SELECT T.IdTurno, T.IdVehiculo, T.IdServicio, T.IdOperario, T.IdUsuarioRegistro,
                                        T.FechaHora, T.Estado, T.Precio, V.Patente, S.Nombre, O.Nombre
                                 FROM TurnoWash T
                                 INNER JOIN Vehiculos V ON T.IdVehiculo = V.IdVehiculo
                                 INNER JOIN ServicioLavado S ON T.IdServicio = S.IdServicio
                                 INNER JOIN Operarios O ON T.IdOperario = O.IdOperario
                                 ORDER BY T.FechaHora DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(TurnoMPP.MapearDesdeReader(reader));
                }
            }
            return lista;
        }

        public List<Turno> Filtrar(string estado = null, string patente = null, DateTime? fecha = null)
        {
            var lista = new List<Turno>();
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                var sb = new StringBuilder(@"SELECT T.IdTurno, T.IdVehiculo, T.IdServicio, T.IdOperario, T.IdUsuarioRegistro,
                                                    T.FechaHora, T.Estado, T.Precio, V.Patente, S.Nombre, O.Nombre
                                             FROM TurnoWash T
                                             INNER JOIN Vehiculos V ON T.IdVehiculo = V.IdVehiculo
                                             INNER JOIN ServicioLavado S ON T.IdServicio = S.IdServicio
                                             INNER JOIN Operarios O ON T.IdOperario = O.IdOperario
                                             WHERE 1=1 ");

                var cmd = new SqlCommand();
                cmd.Connection = conn;

                if (!string.IsNullOrWhiteSpace(estado) && estado != "Todos")
                {
                    sb.Append(" AND T.Estado = @Estado");
                    cmd.Parameters.AddWithValue("@Estado", estado.Trim());
                }

                if (!string.IsNullOrWhiteSpace(patente))
                {
                    sb.Append(" AND V.Patente LIKE @Patente");
                    cmd.Parameters.AddWithValue("@Patente", "%" + patente.Trim() + "%");
                }

                if (fecha.HasValue)
                {
                    sb.Append(" AND CAST(T.FechaHora AS DATE) = CAST(@Fecha AS DATE)");
                    cmd.Parameters.AddWithValue("@Fecha", fecha.Value.Date);
                }

                sb.Append(" ORDER BY T.FechaHora DESC");
                cmd.CommandText = sb.ToString();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(TurnoMPP.MapearDesdeReader(reader));
                    }
                }
            }
            return lista;
        }

        public void CambiarEstado(int idTurno, EstadoTurno nuevoEstado)
        {
            using (SqlConnection conn = conexion.ValidarConexion())
            {
                conn.Open();
                SqlCommand cmd;
                if (nuevoEstado == EstadoTurno.LavadoTerminado)
                {
                    cmd = new SqlCommand("sp_CompletarServicioLavado", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdTurno", idTurno);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE TurnoWash SET Estado = @Estado WHERE IdTurno = @IdTurno", conn);
                    cmd.Parameters.AddWithValue("@Estado", nuevoEstado.ToString());
                    cmd.Parameters.AddWithValue("@IdTurno", idTurno);
                }
                cmd.ExecuteNonQuery();
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
                conexion = null; // las conexiones SQL se cierran con using en cada método
            }
            disposed = true;
        }
    }
}
