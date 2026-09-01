using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public enum EstadoTurno
    {
        Pendiente = 1,
        Asignado = 2,
        EnLavado = 3,
        LavadoTerminado = 4,
        Entregado = 5,
        Cancelado = 6
    }
}
