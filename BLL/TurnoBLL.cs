using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
using DAL;

namespace BLL
{
    public class TurnoBLL
    {
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        // ===== OBSERVER =====
        // Sujeto: Turno (evento EstadoChanged).
        // Este evento estático es el "canal" al que se suscriben los observadores
        // (por ejemplo FormTableroEntregas) sin acoplarse a FormTurnos.
        // Se dispara DESPUÉS de que el cambio se guardó en la base.
        public static event EventHandler<TurnoEventArgs> EstadoTurnoCambiado;

        private static void RetransmitirCambio(object sender, TurnoEventArgs e)
        {
            EstadoTurnoCambiado?.Invoke(sender, e);
        }

        // Cambia el estado en memoria y deja que el Turno avise por su evento.
        private static void AplicarEstadoYNotificar(Turno turno, EstadoTurno nuevoEstado)
        {
            turno.EstadoChanged += RetransmitirCambio;
            try
            {
                turno.Estado = nuevoEstado;
            }
            finally
            {
                turno.EstadoChanged -= RetransmitirCambio;
            }
        }
        // ====================

        public List<Turno> Listar()
        {
            using (TurnoDAL dal = new TurnoDAL())
            {
                return dal.Listar();
            }
        }

        // Precio = servicio/combo + recargo del vehículo (SUV +150)
        public decimal CalcularPrecio(Vehiculo vehiculo, IComponenteServicio servicio)
        {
            return servicio.ObtenerPrecio() + vehiculo.CalcularRecargo();
        }

        public void Agregar(Vehiculo vehiculo, IComponenteServicio servicio, Operador operador, DateTime fechaHora)
        {
            if (vehiculo == null)
                throw new Exception("Debes seleccionar un vehículo");
            if (servicio == null)
                throw new Exception("Debes seleccionar un servicio o combo");
            if (operador == null)
                throw new Exception("Debes seleccionar un operario");
            if (fechaHora.Date < DateTime.Today)
                throw new Exception("La fecha del turno no puede ser anterior a hoy");

            Usuario usuario = SesionActual.Instancia.UsuarioLogueado;
            if (usuario == null)
                throw new Exception("No hay una sesión activa");

            Turno turno = new Turno
            {
                IdVehiculo = vehiculo.IdVehiculo,
                IdServicio = ObtenerIdServicio(servicio),
                IdOperario = operador.IDOperador,
                IdUsuarioRegistro = usuario.IdUsuario,
                FechaHora = fechaHora,
                Precio = CalcularPrecio(vehiculo, servicio)
            };
            turno.MarcarAsignado(); // ya tiene operario desde el alta

            using (TurnoDAL dal = new TurnoDAL())
            {
                dal.Agregar(turno);
            }

            bitacoraBLL.Registrar(
                idUsuario: usuario.IdUsuario,
                accion: $"Alta de turno - Patente: {vehiculo.Patente}, Operario: {operador.Nombre}, Precio: {turno.Precio:N2}",
                modulo: "Turnos",
                criticidad: Criticidad.Media);
        }

        // Pendiente -> Asignado -> EnLavado -> LavadoTerminado -> Entregado
        public void AvanzarEstado(Turno turno)
        {
            if (turno == null)
                throw new Exception("Debes seleccionar un turno");

            EstadoTurno siguiente;
            switch (turno.Estado)
            {
                case EstadoTurno.Pendiente: siguiente = EstadoTurno.Asignado; break;
                case EstadoTurno.Asignado: siguiente = EstadoTurno.EnLavado; break;
                case EstadoTurno.EnLavado: siguiente = EstadoTurno.LavadoTerminado; break;
                case EstadoTurno.LavadoTerminado: siguiente = EstadoTurno.Entregado; break;
                default:
                    throw new Exception("El turno ya está entregado o cancelado");
            }

            using (TurnoDAL dal = new TurnoDAL())
            {
                dal.CambiarEstado(turno.IdTurno, siguiente);
            }

            bitacoraBLL.Registrar(
                idUsuario: SesionActual.Instancia.UsuarioLogueado?.IdUsuario,
                accion: $"Turno {turno.IdTurno} ({turno.Patente}): {turno.Estado} -> {siguiente}",
                modulo: "Turnos",
                criticidad: Criticidad.Baja);

            // Recién acá (ya guardado en BD) se notifica a los observadores
            AplicarEstadoYNotificar(turno, siguiente);
        }

        public void Cancelar(Turno turno)
        {
            if (turno == null)
                throw new Exception("Debes seleccionar un turno");
            if (turno.Estado == EstadoTurno.Entregado || turno.Estado == EstadoTurno.Cancelado)
                throw new Exception("El turno ya está entregado o cancelado");

            using (TurnoDAL dal = new TurnoDAL())
            {
                dal.CambiarEstado(turno.IdTurno, EstadoTurno.Cancelado);
            }

            bitacoraBLL.Registrar(
                idUsuario: SesionActual.Instancia.UsuarioLogueado?.IdUsuario,
                accion: $"Cancelación de turno {turno.IdTurno} ({turno.Patente})",
                modulo: "Turnos",
                criticidad: Criticidad.Media);

            AplicarEstadoYNotificar(turno, EstadoTurno.Cancelado);
        }

        private int ObtenerIdServicio(IComponenteServicio servicio)
        {
            if (servicio is PaqueteServicio paquete) return paquete.IdPaquete;
            if (servicio is ServiIndividual individual) return individual.IdServicio;
            throw new Exception("Tipo de servicio no reconocido");
        }
    }
}
