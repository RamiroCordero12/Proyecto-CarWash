using System;
using System.Collections.Generic;
using CarWash.BE;
using DAL;

namespace BLL
{
    public class EstadisticaBLL
    {
        public List<EstadisticaFacturacionDiaria> ListarFacturacionPorDia(DateTime fechaDesde, DateTime fechaHasta)
        {
            if (fechaDesde > fechaHasta)
                throw new Exception("La fecha desde no puede ser posterior a la fecha hasta");

            using (EstadisticaDAL dal = new EstadisticaDAL())
            {
                return dal.ListarFacturacionPorDia(fechaDesde, fechaHasta);
            }
        }

        public List<EstadisticaServicioMes> ListarServiciosMasContratados(int mes, int anio)
        {
            if (mes < 1 || mes > 12)
                throw new Exception("El mes debe ser un valor entre 1 y 12");
            if (anio < 2000 || anio > 2100)
                throw new Exception("El año indicado no es válido");

            using (EstadisticaDAL dal = new EstadisticaDAL())
            {
                return dal.ListarServiciosMasContratados(mes, anio);
            }
        }

        public void ObtenerResumenMes(int mes, int anio, out decimal totalFacturado, out int totalTurnos, out decimal promedioTicket)
        {
            using (EstadisticaDAL dal = new EstadisticaDAL())
            {
                dal.ObtenerResumenMes(mes, anio, out totalFacturado, out totalTurnos, out promedioTicket);
            }
        }
    }
}
