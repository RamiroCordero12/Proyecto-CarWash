using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Sedan : Vehiculo
    {
        public override string Tipo
        {
            get { return "Sedan"; }
        }
        public override decimal CalcularPrecioBase()
        {
            return 500m;
        }
        public override bool RequiereLavadoChasis()
        {
            return false;
        }
    }
}
