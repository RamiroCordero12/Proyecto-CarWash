using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public abstract class Vehiculo : IComparable<Vehiculo>, ICloneable
    {
        public int IdVehiculo { get; set; }

        public int DNI { get; set; }

        public string Patente { get; set; }

        public string Marca { get; set; }

        public string Color { get; set; }

        public abstract string Tipo { get; }

        public virtual decimal CalcularPrecioBase()
        {
            return 500m;
        }

        public virtual bool RequiereLavadoChasis()
        {
            return false;
        }

        public int CompareTo(Vehiculo other)
        {
            if (other == null)
                return 1;

            return string.Compare(
                Patente,
                other.Patente,
                StringComparison.OrdinalIgnoreCase);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{Patente} - {Marca} - {Tipo}";
        }
    }
}
