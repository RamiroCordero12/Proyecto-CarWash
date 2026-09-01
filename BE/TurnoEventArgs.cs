using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class TurnoEventArgs : EventArgs
    {
        public Turno Turno { get; private set; }

        public TurnoEventArgs(Turno turno)
        {
            Turno = turno;
        }
    }
}
