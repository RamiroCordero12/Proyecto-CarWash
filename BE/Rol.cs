using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Rol
    {
        public int CodRol { get; set; }
        public string NombreRol { get; set; }
        public string DescRol { get; set; }
        

        public List<Familia> Familias { get; set; }
        public List<Hoja> HojasSueltas { get; set; }

        public Rol()
        {
            Familias = new List<Familia>();
            HojasSueltas = new List<Hoja>();
        }
        public override string ToString() => NombreRol;
    }
}
