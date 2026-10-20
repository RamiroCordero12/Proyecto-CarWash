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

        // LavadoTerminado va por el SP (cambia el estado y genera la alerta de entrega)
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
