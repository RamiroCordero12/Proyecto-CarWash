using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Operador
    {
        public int IDOperador { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public decimal PorcentajeComision { get; set; }
        public EstadoOperador Estado { get; set; }
        public List<Turno> Turnos { get; set; }

        public Operador()
        {
            Turnos = new List<Turno>();
            Estado = EstadoOperador.Activo;
        }
        public decimal CalcularComisio(decimal monto)
        {
            return monto * (PorcentajeComision / 100m);
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
