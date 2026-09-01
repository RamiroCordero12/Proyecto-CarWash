using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; } // hash SHA-256
        public int CodRol { get; set; }
        public Rol Rol { get; set; }

        public override string ToString() => $"{NombreUsuario} ({NombreCompleto})";

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }

}
