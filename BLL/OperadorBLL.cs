using BLL.Bitacora;
using CarWash.BE.Bitacora;
using CarWash.BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OperadorBLL : IABM<Operador, int>
    {
        private OperadorDAL dal = new OperadorDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        public void Agregar(Operador operador)
        {
            Validar(operador);

            dal.Agregar(operador);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Alta de operador - {operador.Nombre} ({operador.PorcentajeComision}%)",
                modulo: "Operarios",
                criticidad: Criticidad.Media);
        }

        public void Modificar(Operador operador)
        {
            if (operador.IDOperador <= 0)
                throw new Exception("Debes seleccionar un operador para modificar");

            Validar(operador);

            dal.Modificar(operador);

            // Cambiar una comisión es un cambio económico: criticidad Alta
            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Modificación de operador - Id: {operador.IDOperador} ({operador.Nombre}, {operador.PorcentajeComision}%)",
                modulo: "Operarios",
                criticidad: Criticidad.Alta);
        }

        public void Eliminar(int idOperador)
        {
            if (idOperador <= 0)
                throw new Exception("Debes seleccionar un operador");

            dal.Eliminar(idOperador);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Eliminación de operador - Id: {idOperador}",
                modulo: "Operarios",
                criticidad: Criticidad.Alta);
        }

        public List<Operador> Listar()
        {
            return dal.Listar();
        }

        private void Validar(Operador operador)
        {
            if (string.IsNullOrWhiteSpace(operador.Nombre))
                throw new Exception("Debes ingresar el nombre del operador");

            if (operador.PorcentajeComision < 0 || operador.PorcentajeComision > 100)
                throw new Exception("La comisión debe estar entre 0 y 100");
        }

        private int? UsuarioActualId()
        {
            return SesionActual.Instancia.UsuarioLogueado?.IdUsuario;
        }
    }
}
