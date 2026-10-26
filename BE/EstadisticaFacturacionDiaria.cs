using System;

namespace CarWash.BE
{
    public class EstadisticaFacturacionDiaria
    {
        public DateTime Fecha { get; set; }
        public decimal TotalFacturado { get; set; }
        public int CantidadTurnos { get; set; }
    }
}
