using CarWash.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class Alertaentregabll
    {
        public List<Alertaentrega> ListarPendientes()
        {
            using (AlertaEntregaDAL dal = new AlertaEntregaDAL())
            {
                return dal.ListarPendientes();
            }
        }
    }
}
