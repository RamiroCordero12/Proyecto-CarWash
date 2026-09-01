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
        }

        public void CerrarSesion()
        {
            UsuarioLogueado = null;
            RolActivo = null;
        }

        public bool TienePermiso(int codHoja)
        {
            if (RolActivo == null) return false;

            var permisoBLL = new PermisoBLL();
            return permisoBLL.RolTienePermiso(RolActivo, codHoja);
        }
    }
}
