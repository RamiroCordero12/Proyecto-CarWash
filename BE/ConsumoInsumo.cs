using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class ConsumoInsumo
    {
        public int IdConsumo { get; set; }
        public int IdTurno { get; set; }
        public int IdInsumo { get; set; }
        public decimal Cantidad { get; set; }
        public Turno Turno { get; set; }
        public Insumo Insumo { get; set; }
    }
}
