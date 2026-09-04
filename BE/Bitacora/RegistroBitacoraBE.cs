using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE.Bitacora
{
    public class RegistroBitacoraBE
    {
        //Esta clase representa un renglón de la bitácora — un evento.
        public int IdBitacora { get; set; }
        public int? IdUsuario { get; set; }
        public string NombreUsuario { get; set; } // para mostrar en grilla, viene de un JOIN
        public string Accion { get; set; }
        public DateTime FechaHora { get; set; }
        public string Modulo { get; set; }
        public Criticidad Criticidad { get; set; }

        public override string ToString() =>
            $"{FechaHora:dd/MM/yyyy HH:mm} - {NombreUsuario} - {Accion} ({Criticidad})";
    }
}
