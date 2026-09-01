using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;
using System.Data;
using DAL;

namespace BLL
{
    public class ClienteBLL : IABM<Cliente, string>
    {
        private ClienteDAL dal = new ClienteDAL();

        public void Agregar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.DNI))
                throw new System.Exception("Debes ingresar el DNI");
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new System.Exception("Debes ingresar un nombre");

            dal.Agregar(cliente);
        }

        public void Eliminar(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
                throw new System.Exception("Debes seleccionar un cliente");

            dal.Eliminar(dni);
        }

        public void Modificar(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.DNI))
                throw new System.Exception("Debes seleccionar un cliente para modificar");

            dal.Modificar(cliente);
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
    }
}
