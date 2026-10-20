using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CarWash.BE
{
    public class Turno : INotifyPropertyChanged
    {
        private EstadoTurno _estado;

        public int IdTurno { get; set; }
        public int IdVehiculo { get; set; }
        public int IdServicio { get; set; }
        public int IdOperario { get; set; }
        public int IdUsuarioRegistro { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Precio { get; set; }

        // Datos para mostrar en la grilla (vienen del JOIN)
        public string Patente { get; set; }
        public string NombreServicio { get; set; }
        public string NombreOperador { get; set; }

        public EstadoTurno Estado
        {
            get { return _estado; }
            set
            {
                if (_estado != value)
                {
                    _estado = value;
                    OnPropertyChanged();
                    EstadoChanged?.Invoke(this, new TurnoEventArgs(this));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<TurnoEventArgs> EstadoChanged;

        public Turno()
        {
            Estado = EstadoTurno.Pendiente;
        }

        public void MarcarAsignado() { Estado = EstadoTurno.Asignado; }
        public void MarcarEnLavado() { Estado = EstadoTurno.EnLavado; }
        public void MarcarLavadoTerminado() { Estado = EstadoTurno.LavadoTerminado; }
        public void MarcarEntregado() { Estado = EstadoTurno.Entregado; }
        public void Cancelar() { Estado = EstadoTurno.Cancelado; }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"{IdTurno} - {Patente} - {FechaHora:dd/MM/yyyy HH:mm}";
        }
    }
}
