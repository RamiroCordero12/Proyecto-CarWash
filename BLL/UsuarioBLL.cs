using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL dal = new UsuarioDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        private int? ObtenerIdUsuarioActual()
        {
            return SesionActual.Instancia?.UsuarioLogueado?.IdUsuario;
        }

        public List<Usuario> Listar()
        {
            return dal.Listar();
        }

        public Usuario ObtenerPorId(int idUsuario)
        {
            if (idUsuario <= 0) return null;
            return dal.ObtenerPorId(idUsuario);
        }

        public int Agregar(Usuario usuario, string contrasenaPlana)
        {
            ValidarDatosUsuario(usuario);

            if (string.IsNullOrWhiteSpace(contrasenaPlana))
                throw new Exception("Debes ingresar una contraseña para el nuevo usuario.");

            if (contrasenaPlana.Length < 4)
                throw new Exception("La contraseña debe tener al menos 4 caracteres.");

            if (dal.ExisteNombreUsuario(usuario.NombreUsuario))
                throw new Exception($"El nombre de usuario '{usuario.NombreUsuario}' ya se encuentra registrado.");

            usuario.Contrasena = HashSHA256(contrasenaPlana);

            int id = dal.Agregar(usuario);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Alta de usuario: {usuario.NombreUsuario} ({usuario.NombreCompleto}) - ID {id}",
                modulo: "Usuarios",
                criticidad: Criticidad.Media);

            return id;
        }

        public void Modificar(Usuario usuario, string nuevaContrasenaPlana = null)
        {
            if (usuario.IdUsuario <= 0)
                throw new Exception("ID de usuario inválido.");

            ValidarDatosUsuario(usuario);

            if (dal.ExisteNombreUsuario(usuario.NombreUsuario, usuario.IdUsuario))
                throw new Exception($"El nombre de usuario '{usuario.NombreUsuario}' ya está en uso por otro usuario.");

            bool cambiarPass = !string.IsNullOrWhiteSpace(nuevaContrasenaPlana);
            if (cambiarPass)
            {
                if (nuevaContrasenaPlana.Length < 4)
                    throw new Exception("La nueva contraseña debe tener al menos 4 caracteres.");
                usuario.Contrasena = HashSHA256(nuevaContrasenaPlana);
            }

            dal.Modificar(usuario, actualizarContrasena: cambiarPass);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Modificación de usuario: {usuario.NombreUsuario} (ID {usuario.IdUsuario})" + (cambiarPass ? " [contraseña actualizada]" : ""),
                modulo: "Usuarios",
                criticidad: Criticidad.Alta);
        }

        public void Eliminar(int idUsuario, string nombreUsuario)
        {
            if (idUsuario <= 0)
                throw new Exception("ID de usuario inválido.");

            if (SesionActual.Instancia?.UsuarioLogueado != null &&
                SesionActual.Instancia.UsuarioLogueado.IdUsuario == idUsuario)
            {
                throw new Exception("No puedes eliminar al usuario con el que te encuentras logueado actualmente.");
            }

            dal.Eliminar(idUsuario);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Eliminación de usuario: {nombreUsuario} (ID {idUsuario})",
                modulo: "Usuarios",
                criticidad: Criticidad.Alta);
        }

        private void ValidarDatosUsuario(Usuario u)
        {
            if (u == null) throw new ArgumentNullException(nameof(u));

            if (string.IsNullOrWhiteSpace(u.Nombre))
                throw new Exception("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(u.Apellido))
                throw new Exception("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(u.NombreUsuario))
                throw new Exception("El nombre de usuario es obligatorio.");

            u.Nombre = u.Nombre.Trim();
            u.Apellido = u.Apellido.Trim();
            u.NombreUsuario = u.NombreUsuario.Trim();

            if (u.CodRol <= 0)
                throw new Exception("Debes seleccionar un rol para el usuario.");

            if (!string.IsNullOrWhiteSpace(u.Email))
            {
                u.Email = u.Email.Trim();
                if (!Regex.IsMatch(u.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new Exception("El formato del correo electrónico no es válido.");
            }
        }

        public string HashSHA256(string texto)
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
