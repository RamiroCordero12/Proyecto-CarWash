using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Alertaentrega
    {
        public int IdAlerta { get; set; }
        public int IdTurno { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }
        public string NombreCliente { get; set; }
        public string Telefono { get; set; }
        public string NombreServicio { get; set; }
        public string NombreOperador { get; set; }
        public DateTime FechaCompletado { get; set; }
    }
}
