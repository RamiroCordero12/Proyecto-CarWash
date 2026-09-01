using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Cliente
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }

        //Nada más. Sin lógica, sin interfaces, sin comportamiento.
        //Es solo el contenedor de datos que viaja entre capas.
    }
}
