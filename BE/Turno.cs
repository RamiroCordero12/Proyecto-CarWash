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

        public int IdCliente { get; set; }

        public int IdVehiculo { get; set; }

        public int? IdOperador { get; set; }

        public DateTime FechaHora { get; set; }

        public decimal MontoTotal { get; set; }

        public Cliente Cliente { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public Operador Operador { get; set; }

        public List<IComponenteServicio> Servicios { get; set; }

        public EstadoTurno Estado
        {
            get { return _estado; }
            set
            {
                if (_estado != value)
                {
                    _estado = value;

                    OnPropertyChanged();

                    EstadoChanged?.Invoke(
                        this,
                        new TurnoEventArgs(this));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<TurnoEventArgs> EstadoChanged;

        public Turno()
        {
            Servicios = new List<IComponenteServicio>();
            Estado = EstadoTurno.Pendiente;
        }

        public void MarcarAsignado()
        {
            Estado = EstadoTurno.Asignado;
        }

        public void MarcarEnLavado()
        {
            Estado = EstadoTurno.EnLavado;
        }

        public void MarcarLavadoTerminado()
        {
            Estado = EstadoTurno.LavadoTerminado;
        }

        public void MarcarEntregado()
        {
            Estado = EstadoTurno.Entregado;
        }

        public void Cancelar()
        {
            Estado = EstadoTurno.Cancelado;
        }

        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }

        public decimal CalcularTotalServicios()
        {
            decimal total = 0;

            foreach (IComponenteServicio servicio in Servicios)
            {
                total += servicio.ObtenerPrecio();
            }

            return total;
        }

        public override string ToString()
        {
            string patente = Vehiculo != null
                ? Vehiculo.Patente
                : IdVehiculo.ToString();

            return $"{IdTurno} - {patente} - {FechaHora:dd/MM/yyyy HH:mm}";
        }
    }
}
