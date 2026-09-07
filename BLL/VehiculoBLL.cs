using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
using DAL;

namespace BLL
{
    public class VehiculoBLL : IABM<Vehiculo, int>
    {
        private VehiculoDAL dal = new VehiculoDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        // Regex simple de patente argentina: acepta formato viejo (ABC123)
        // y nuevo (AB123CD). Ajustá según lo que pida tu pliego/docente si
        // hay un formato específico exigido.
        private static readonly Regex PatenteRegex =
            new Regex(@"^([A-Za-z]{3}\d{3}|[A-Za-z]{2}\d{3}[A-Za-z]{2})$");

        public void Agregar(Vehiculo vehiculo)
        {
            ValidarVehiculo(vehiculo);

            dal.Agregar(vehiculo);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Alta de vehículo - Patente: {vehiculo.Patente} ({vehiculo.Tipo})",
                modulo: "Vehiculos",
                criticidad: Criticidad.Media);
        }

        public void Eliminar(int idVehiculo)
        {
            if (idVehiculo <= 0)
                throw new Exception("Debes seleccionar un vehículo");

            dal.Eliminar(idVehiculo);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Eliminación de vehículo - Id: {idVehiculo}",
                modulo: "Vehiculos",
                criticidad: Criticidad.Alta);
        }

        public void Modificar(Vehiculo vehiculo)
        {
            if (vehiculo.IdVehiculo <= 0)
                throw new Exception("Debes seleccionar un vehículo para modificar");

            ValidarVehiculo(vehiculo);

            dal.Modificar(vehiculo);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Modificación de vehículo - Id: {vehiculo.IdVehiculo}",
                modulo: "Vehiculos",
                criticidad: Criticidad.Media);
        }

        public List<Vehiculo> Listar()
        {
            return dal.Listar();
        }

        public List<Vehiculo> ListarPorCliente(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("Debes indicar el DNI del cliente");

            return dal.ListarPorCliente(dni);
        }

        // Fábrica simple según el tipo elegido en el combo de la UI.
        // Vive acá (BLL) porque es a la única capa además del MPP que
        // le interesa "de qué tipo armar el objeto antes de guardar".
        public Vehiculo CrearPorTipo(string tipo)
        {
            switch (tipo)
            {
                case "Sedan":
                    return new Sedan();

                case "SUV_Camioneta":
                    return new SUV_Camioneta();

                default:
                    throw new Exception("Debes seleccionar un tipo de vehículo válido");
            }
        }

        private void ValidarVehiculo(Vehiculo vehiculo)
        {
            if (string.IsNullOrWhiteSpace(vehiculo.Patente))
                throw new Exception("Debes ingresar la patente");

            if (!PatenteRegex.IsMatch(vehiculo.Patente.Trim()))
                throw new Exception("El formato de patente no es válido");

            if (vehiculo.DNI <= 0)
                throw new Exception("Debes indicar el DNI del cliente dueño del vehículo");

            if (string.IsNullOrWhiteSpace(vehiculo.Marca))
                throw new Exception("Debes ingresar la marca");
        }

        private int? UsuarioActualId()
        {
            return SesionActual.Instancia.UsuarioLogueado?.IdUsuario;
        }
    }
}
