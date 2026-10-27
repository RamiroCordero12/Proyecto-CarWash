using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;                                   
namespace BLL
{
    public class SesionActual
    {
        private static SesionActual _instancia;
        private static readonly object _lock = new object();

        public Usuario UsuarioLogueado { get; private set; }
        public Rol RolActivo { get; private set; }

        // Cache nombre de hoja -> código, para no consultar la BD en cada pregunta de permiso
        private Dictionary<string, int> _hojasPorNombre;

        private SesionActual() { }

        public static SesionActual Instancia
        {
            get
            {
                lock (_lock)
                {
                    if (_instancia == null)
                        _instancia = new SesionActual();
                    return _instancia;
                }
            }
        }

        public void IniciarSesion(Usuario usuario, Rol rol)
        {
            UsuarioLogueado = usuario;
            RolActivo = rol;
            _hojasPorNombre = null;      // <-- NUEVA
        }

        public void CerrarSesion()
        {
            UsuarioLogueado = null;
            RolActivo = null;
            _hojasPorNombre = null;      // <-- NUEVA
        }

        public bool TienePermiso(int codHoja)
        {
            if (RolActivo == null) return false;

            var permisoBLL = new PermisoBLL();
            return permisoBLL.RolTienePermiso(RolActivo, codHoja);
        }

        // Pregunta por nombre de hoja ("Clientes", "Backup", ...): no depende de IDs hardcodeados
        public bool TienePermiso(string nombreHoja)
        {
            if (RolActivo == null || string.IsNullOrWhiteSpace(nombreHoja)) return false;
            if (_hojasPorNombre == null)
            {
                _hojasPorNombre = new PermisoBLL().ListarHojas()
                    .ToDictionary(h => h.NombreHoja, h => h.CodHoja, StringComparer.OrdinalIgnoreCase);
            }
            return _hojasPorNombre.TryGetValue(nombreHoja, out int cod) && TienePermiso(cod);
        }

        // Vuelve a leer de la BD los permisos del rol activo (por si se editó el rol desde Roles y Permisos)
        public void RecargarPermisos()
        {
            if (RolActivo == null) return;
            var permisoBLL = new PermisoBLL();
            var arbol = permisoBLL.ConstruirArbolFamilias();
            RolActivo = permisoBLL.CargarRolCompleto(RolActivo.CodRol, RolActivo.NombreRol, arbol);
            _hojasPorNombre = null;
        }
    }
}
