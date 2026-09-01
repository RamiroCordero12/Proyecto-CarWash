using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Hoja
    {
        public int CodHoja { get; set; }
        public string NombreHoja { get; set; }
        public string DescHoja { get; set; }

        public override string ToString() => NombreHoja;
    }
}
