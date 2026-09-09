using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE.Bitacora;
using CarWash.BE;
using DAL;
using BLL.Bitacora;

namespace BLL
{
    public class ServicioLavadoBLL
    {
        private ServicioLavadoDAL dal = new ServicioLavadoDAL();
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        public List<IComponenteServicio> Listar()
        {
            return dal.ListarArbol();
        }

        public List<ServiIndividual> ListarServiciosIndividuales()
        {
            return dal.ListarServiciosIndividuales();
        }

        public void AgregarServicioIndividual(string nombre, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debes ingresar un nombre para el servicio");
            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a cero");

            dal.AgregarServicioIndividual(nombre, precio);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Alta de servicio individual - {nombre}",
                modulo: "ServiciosLavado",
                criticidad: Criticidad.Media);
        }

        public void CrearCombo(string nombre, decimal precioFinal, List<int> idsComponentes)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("Debes ingresar un nombre para el combo");
            if (precioFinal <= 0)
                throw new Exception("El precio del combo debe ser mayor a cero");
            if (idsComponentes == null || idsComponentes.Count < 2)
                throw new Exception("Un combo debe tener al menos 2 servicios individuales");

            int idCombo = dal.AgregarCombo(nombre, precioFinal);

            foreach (int idComponente in idsComponentes)
            {
                dal.AgregarComponenteACombo(idCombo, idComponente);
            }

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Alta de combo - {nombre} ({idsComponentes.Count} servicios)",
                modulo: "ServiciosLavado",
                criticidad: Criticidad.Media);
        }

        public void Eliminar(int idServicio)
        {
            dal.Eliminar(idServicio);

            bitacoraBLL.Registrar(
                idUsuario: UsuarioActualId(),
                accion: $"Eliminación de servicio/combo - Id: {idServicio}",
                modulo: "ServiciosLavado",
                criticidad: Criticidad.Alta);
        }

        private int? UsuarioActualId()
        {
            return SesionActual.Instancia.UsuarioLogueado?.IdUsuario;
        }
    }
}
