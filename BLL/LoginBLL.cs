using CarWash.BE;
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

        public Usuario IniciarSesion(string nombreUsuario, string contrasenaPlana)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new Exception("Debes ingresar el usuario");
            if (string.IsNullOrWhiteSpace(contrasenaPlana))
                throw new Exception("Debes ingresar la contraseña");

            string hash = HashSHA256(contrasenaPlana);

            Usuario usuario = dal.ValidarCredenciales(nombreUsuario, hash);

            if (usuario == null)
                throw new Exception("Usuario o contraseña incorrectos");

            // Arma el árbol completo y resuelve el Rol de este usuario contra él
            var arbolFamilias = permisoBLL.ConstruirArbolFamilias();
            string nombreRol = dal.ObtenerNombreRol(usuario.CodRol);
            Rol rolCompleto = permisoBLL.CargarRolCompleto(usuario.CodRol, nombreRol, arbolFamilias);

            usuario.Rol = rolCompleto;

            // Acá se puebla el Singleton
            SesionActual.Instancia.IniciarSesion(usuario, rolCompleto);

            // TODO Fase 3: registrar en Bitácora (login exitoso)

            return usuario;
        }

        public void CerrarSesion()
        {
            // TODO Fase 3: registrar en Bitácora (logout)
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
