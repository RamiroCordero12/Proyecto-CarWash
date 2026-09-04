using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginBLL
    {
        private UsuarioDAL dal = new UsuarioDAL();
        private PermisoBLL permisoBLL = new PermisoBLL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        public Usuario IniciarSesion(string nombreUsuario, string contrasenaPlana)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new Exception("Debes ingresar el usuario");
            if (string.IsNullOrWhiteSpace(contrasenaPlana))
                throw new Exception("Debes ingresar la contraseña");

            string hash = HashSHA256(contrasenaPlana);
            Usuario usuario = dal.ValidarCredenciales(nombreUsuario, hash);

            if (usuario == null)
            {
                // Login fallido: criticidad Alta, sin IdUsuario válido conocido
                bitacoraBLL.Registrar(
                    idUsuario: null, // ver nota sobre FK nullable más abajo
                    accion: $"Intento de login fallido - usuario ingresado: {nombreUsuario}",
                    modulo: "Login",
                    criticidad: Criticidad.Alta);

                throw new Exception("Usuario o contraseña incorrectos");
            }

            var arbolFamilias = permisoBLL.ConstruirArbolFamilias();
            string nombreRol = dal.ObtenerNombreRol(usuario.CodRol);
            Rol rolCompleto = permisoBLL.CargarRolCompleto(usuario.CodRol, nombreRol, arbolFamilias);
            usuario.Rol = rolCompleto;

            SesionActual.Instancia.IniciarSesion(usuario, rolCompleto);

            bitacoraBLL.Registrar(
                idUsuario: usuario.IdUsuario,
                accion: "Inicio de sesión exitoso",
                modulo: "Login",
                criticidad: Criticidad.Media);

            return usuario;
        }

        public void CerrarSesion()
        {
            var usuarioActual = SesionActual.Instancia.UsuarioLogueado;

            if (usuarioActual != null)
            {
                bitacoraBLL.Registrar(
                    idUsuario: usuarioActual.IdUsuario,
                    accion: "Cierre de sesión",
                    modulo: "Login",
                    criticidad: Criticidad.Baja);
            }

            SesionActual.Instancia.CerrarSesion();
        }

        private string HashSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }


    }
}
