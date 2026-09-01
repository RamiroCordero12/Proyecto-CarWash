using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class PaqueteServicio : IComponenteServicio
    {
        public int IdPaquete { get; set; }
        public string Nombre { get; set; }
        public decimal DescuentoPorcetanje { get; set; }
        public decimal PrecioFinal { get; set; }
        public List<IComponenteServicio> Componentes { get; set; }

        public PaqueteServicio()
        {
            Componentes = new List<IComponenteServicio>();
        }

        public void Agregar(IComponenteServicio componente)
        {
            if (componente != null)
            {
                Componentes.Add(componente);
            }
        }

        public void Quitar(IComponenteServicio componente)
        {
            if(componente != null)
            {
                Componentes.Remove(componente);

            }
        }

        public decimal ObtenerPrecioSinDescuento()
        {
            return Componentes.Sum(
                componente => componente.ObtenerPrecio());
        }

        public decimal ObtenerPrecio()
        {
            decimal subtotal = ObtenerPrecioSinDescuento();

            decimal descuento = subtotal * (DescuentoPorcetanje / 100m);

            PrecioFinal = subtotal - descuento;

            return PrecioFinal;
        }

        public string ObtenerDescripcion()
        {

            return string.Join(
                ", ",
                Componentes.Select(
                    componente => componente.ObtenerDescripcion()));
        }
        public override string ToString()
        {
            return $"{Nombre} - ${ObtenerPrecio():N2}";
        }
    }
}
