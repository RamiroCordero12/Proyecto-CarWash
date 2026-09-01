using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Insumo
    {

        public int IdInsumo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; } 
        public decimal Precio { get; set; }

        public bool StockBajo
        {
            get {  return Stock <= StockMinimo; }
        }
        public void Consumir(decimal cantidad)
        {
            if (cantidad <= 0)
                throw new System.ArgumentException(
                    "La cantidad debe ser mayor a cero");

            if (cantidad > Stock)
                throw new System.InvalidOperationException(
                    "No hay stock suficiente");

            Stock -= cantidad;
              
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nombre} - {Stock}";
        }
    }
}
