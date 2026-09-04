using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;
using System.Data;
using DAL;
using CarWash.BE.Bitacora;
using BLL.Bitacora;

namespace BLL
{
    public class ClienteBLL : IABM<Cliente, string>
    {
        private ClienteDAL dal = new ClienteDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        public void Agregar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.DNI))
                throw new Exception("Debes ingresar el DNI");
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new Exception("Debes ingresar un nombre");

            dal.Agregar(cliente);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Alta de cliente - DNI: {cliente.DNI} ({cliente.Nombre} {cliente.Apellido})",
                modulo: "Clientes",
                criticidad: Criticidad.Media);
        }

        public void Eliminar(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new Exception("Debes seleccionar un cliente");

            dal.Eliminar(dni);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Eliminación de cliente - DNI: {dni}",
                modulo: "Clientes",
                criticidad: Criticidad.Alta); // eliminar datos = Alta, según RNF-06
        }

        public void Modificar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.DNI))
                throw new Exception("Debes seleccionar un cliente para modificar");

            dal.Modificar(cliente);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Modificación de cliente - DNI: {cliente.DNI}",
                modulo: "Clientes",
                criticidad: Criticidad.Media);
        }

        public List<Cliente> Listar()
        {
            return dal.Listar();
        }

        public DataSet ListarDataSet()
        {
            return dal.ListarDataSet();
        }

        public DataTable BuscarPorApellido(DataSet ds, string apellido)
        {
            return dal.BuscarPorApellido(ds, apellido);
        }

        // Devuelve el Id del usuario logueado, o null si por algún motivo
        // se llama sin sesión activa (no debería pasar en producción,
        // pero evita un NullReferenceException si algún día hay un test
        // que llama a ClienteBLL sin pasar por FormLogin)
        private int? UsuarioActualId()
        {
            return SesionActual.Instancia.UsuarioLogueado?.IdUsuario;
        }
    }
}
