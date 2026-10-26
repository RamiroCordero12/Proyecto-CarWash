using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Idioma
{
    public class IdiomaManager
    {
        private static IdiomaManager _instancia;
        private static readonly object _lock = new object();

        private readonly List<IIdiomaObserver> _observadores = new List<IIdiomaObserver>();
        private readonly RegistroBitacoraBLL _bitacoraBLL = new RegistroBitacoraBLL();

        public string IdiomaActual { get; private set; } = "ES";

        private readonly Dictionary<string, Dictionary<string, string>> _diccionarios =
            new Dictionary<string, Dictionary<string, string>>(StringComparer.OrdinalIgnoreCase);

        private IdiomaManager()
        {
            InicializarDiccionarios();
        }

        public static IdiomaManager Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new IdiomaManager();
                    return _instancia;
                }
            }
        }

        #region Observer Pattern

        public void Suscribir(IIdiomaObserver observer)
        {
            if (observer != null && !_observadores.Contains(observer))
            {
                _observadores.Add(observer);
            }
        }

        public void Desuscribir(IIdiomaObserver observer)
        {
            if (observer != null)
            {
                _observadores.Remove(observer);
            }
        }

        public void Notificar()
        {
            // Crear una copia para evitar problemas de concurrencia al iterar
            var lista = _observadores.ToList();
            foreach (var obs in lista)
            {
                try
                {
                    obs.ActualizarIdioma();
                }
                catch
                {
                    // Si un formulario fue cerrado o tuvo error al actualizarse, continuar con los demás
                }
            }
        }

        #endregion

        public void CambiarIdioma(string codigoIdioma)
        {
            if (string.IsNullOrWhiteSpace(codigoIdioma)) return;

            string nuevo = codigoIdioma.Trim().ToUpperInvariant();
            if (nuevo != "ES" && nuevo != "EN")
                throw new ArgumentException("Idioma no soportado. Debe ser 'ES' o 'EN'.");

            if (IdiomaActual.Equals(nuevo, StringComparison.OrdinalIgnoreCase))
                return;

            IdiomaActual = nuevo;

            try
            {
                int? idUsuario = SesionActual.Instancia?.UsuarioLogueado?.IdUsuario;
                _bitacoraBLL.Registrar(
                    idUsuario: idUsuario,
                    accion: $"Cambio de idioma de la interfaz a: {nuevo}",
                    modulo: "Configuracion",
                    criticidad: Criticidad.Baja);
            }
            catch { }

            Notificar();
        }

        public string Traducir(string clave, string fallback = null)
        {
            if (string.IsNullOrEmpty(clave)) return fallback ?? "";

            if (_diccionarios.TryGetValue(IdiomaActual, out var dict) &&
                dict.TryGetValue(clave, out var traduccion))
            {
                return traduccion;
            }

            // Fallback a español si no está en inglés
            if (_diccionarios.TryGetValue("ES", out var dictES) &&
                dictES.TryGetValue(clave, out var traduccionES))
            {
                return traduccionES;
            }

            return fallback ?? clave;
        }

        private void InicializarDiccionarios()
        {
            var es = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Menú Principal
                { "MenuClientes", "  👤  Clientes" },
                { "MenuVehiculos", "  🚗  Vehículos" },
                { "MenuServicios", "  🧽  Servicios y Combos" },
                { "MenuConsultas", "  🔍  Consultas" },
                { "MenuBitacora", "  📋  Bitácora" },
                { "MenuOperarios", "  👷  Operarios" },
                { "MenuTurnos", "  📅  Turnos" },
                { "MenuTablero", "  🚗  Tablero Entregas" },
                { "MenuEstadisticas", "  📊  Estadísticas" },
                { "MenuUsuarios", "  👥  Usuarios" },
                { "MenuRoles", "  🛡️  Roles y Permisos" },
                { "MenuBackup", "  💾  Backup / Restore" },
                { "MenuLogout", "  🚪  Cerrar Sesión" },
                { "PanelControl", "Panel de Control" },
                { "Idioma", "Idioma:" },

                // Acciones generales
                { "BtnAgregar", "Agregar" },
                { "BtnModificar", "Modificar" },
                { "BtnEliminar", "Eliminar" },
                { "BtnLimpiar", "Limpiar" },
                { "BtnBuscar", "Buscar" },
                { "BtnGuardar", "Guardar" },
                { "BtnCancelar", "Cancelar" },
                { "ConfirmarCerrarSesion", "¿Seguro que querés cerrar sesión?" },
                { "TituloCerrarSesion", "Cerrar sesión" },

                // Estados Turnos
                { "EstadoPendiente", "Pendiente" },
                { "EstadoAsignado", "Asignado" },
                { "EstadoEnLavado", "En Lavado" },
                { "EstadoLavadoTerminado", "Lavado Terminado" },
                { "EstadoEntregado", "Entregado" },
                { "EstadoCancelado", "Cancelado" }
            };

            var en = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                // Main Menu
                { "MenuClientes", "  👤  Customers" },
                { "MenuVehiculos", "  🚗  Vehicles" },
                { "MenuServicios", "  🧽  Wash Services" },
                { "MenuConsultas", "  🔍  Inquiries" },
                { "MenuBitacora", "  📋  Audit Log" },
                { "MenuOperarios", "  👷  Operators" },
                { "MenuTurnos", "  📅  Appointments" },
                { "MenuTablero", "  🚗  Delivery Board" },
                { "MenuEstadisticas", "  📊  Statistics" },
                { "MenuUsuarios", "  👥  Users" },
                { "MenuRoles", "  🛡️  Roles & Permissions" },
                { "MenuBackup", "  💾  Backup / Restore" },
                { "MenuLogout", "  🚪  Log Out" },
                { "PanelControl", "Control Panel" },
                { "Idioma", "Language:" },

                // General Actions
                { "BtnAgregar", "Add" },
                { "BtnModificar", "Modify" },
                { "BtnEliminar", "Delete" },
                { "BtnLimpiar", "Clear" },
                { "BtnBuscar", "Search" },
                { "BtnGuardar", "Save" },
                { "BtnCancelar", "Cancel" },
                { "ConfirmarCerrarSesion", "Are you sure you want to log out?" },
                { "TituloCerrarSesion", "Log Out" },

                // Appointment States
                { "EstadoPendiente", "Pending" },
                { "EstadoAsignado", "Assigned" },
                { "EstadoEnLavado", "In Washing" },
                { "EstadoLavadoTerminado", "Washing Finished" },
                { "EstadoEntregado", "Delivered" },
                { "EstadoCancelado", "Cancelled" }
            };

            _diccionarios["ES"] = es;
            _diccionarios["EN"] = en;
        }
    }
}
