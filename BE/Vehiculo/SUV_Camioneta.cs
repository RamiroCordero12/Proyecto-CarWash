using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class SUV_Camioneta : Vehiculo
    {
        public override string Tipo
        {
            get { return "SUV_Camioneta"; }
        }
        public decimal RecargoChasis
        {
            get { return 150m; }
        }
        public bool LavadoChasisObligatorio
        {
            get { return true; }
        }
        public override decimal CalcularPrecioBase()
        {
            return 500M + RecargoChasis;
        }
        public override bool RequiereLavadoChasis()
        {
            return true;
        }
    }
}
