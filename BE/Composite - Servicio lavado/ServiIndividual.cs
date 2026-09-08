using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class ServiIndividual : IComponenteServicio
    {
        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion   { get; set; }
        public decimal Precio { get; set; }

        public decimal ObtenerPrecio()
        {
            return Precio;
        }
        public string ObtenerDescripcion()
        {
            return Descripcion;
        }
        public override string ToString() => $"{IdServicio} - {Nombre} - {Descripcion} - {Precio}";
        
    }
}
