using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE.Bitacora;
using DAL;
using DAL.Bitacora;

namespace BLL.Bitacora
{
    public class RegistroBitacoraBLL
    {

        private RegistroBitacoraDAL dal = new RegistroBitacoraDAL();
        public void Registrar(int? idUsuario, string accion, string modulo, Criticidad criticidad)
        {
            dal.Registrar(idUsuario, accion, modulo, criticidad);
        }

        public List<RegistroBitacoraBE> Listar()
        {
            return dal.Listar();
        }

        // Filtro combinado — LINQ/Lambda tal como pide RFC-03.
        // Todos los parámetros son opcionales (null = no filtrar por ese campo).
        public List<RegistroBitacoraBE> Filtrar(
            string nombreUsuario = null,
            DateTime? desde = null,
            DateTime? hasta = null,
            Criticidad? criticidad = null,
            string modulo = null)
        {
            var todos = dal.Listar();

            var query = todos.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(nombreUsuario))
            query = query.Where(r => r.NombreUsuario
                .IndexOf(nombreUsuario, StringComparison.OrdinalIgnoreCase) >= 0);

            if (desde.HasValue)
            query = query.Where(r => r.FechaHora.Date >= desde.Value.Date);

            if (hasta.HasValue)
            query = query.Where(r => r.FechaHora.Date <= hasta.Value.Date);

            if (criticidad.HasValue)
            query = query.Where(r => r.Criticidad == criticidad.Value);

            if (!string.IsNullOrWhiteSpace(modulo))
            query = query.Where(r => r.Modulo
                .IndexOf(modulo, StringComparison.OrdinalIgnoreCase) >= 0);

            return query.OrderByDescending(r => r.FechaHora).ToList();
        }
    }
}
