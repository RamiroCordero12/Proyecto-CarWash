using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Familia
    {
        public int CodFam { get; set; }
        public string NombreFamilia { get; set; }
        public string DescFamilia { get; set; }

        // Listas

        public List<Hoja> Hojas { get; set; }
        public List<Familia> SubFamilias { get; set; }

        public Familia()
        {
            Hojas = new List<Hoja>();
            SubFamilias = new List<Familia>();
        }

        public override string ToString() => NombreFamilia;
    }
}
