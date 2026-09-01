using CarWash.BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class PermisoBLL
    {
        private PermisoDAL dal = new PermisoDAL();

        // Arma el árbol completo de Familias (con sus Hojas y SubFamilias resueltas)
        public List<Familia> ConstruirArbolFamilias()
        {
            List<Familia> familias = dal.ListarFamilias();
            List<Hoja> hojas = dal.ListarHojas();
            var patFam = dal.ListarPatFam();
            var famFam = dal.ListarFamFam();

            Dictionary<int, Familia> mapaFamilias = familias.ToDictionary(f => f.CodFam);
            Dictionary<int, Hoja> mapaHojas = hojas.ToDictionary(h => h.CodHoja);

            // Cuelgo las hojas sueltas de cada familia
            foreach (var (codFam, codHoja) in patFam)
            {
                if (mapaFamilias.TryGetValue(codFam, out var familia) &&
                    mapaHojas.TryGetValue(codHoja, out var hoja))
                {
                    familia.Hojas.Add(hoja);
                }
            }

            // Cuelgo las subfamilias (composición recursiva)
            foreach (var (codPadre, codHijo) in famFam)
            {
                if (mapaFamilias.TryGetValue(codPadre, out var padre) &&
                    mapaFamilias.TryGetValue(codHijo, out var hijo))
                {
                    padre.SubFamilias.Add(hijo);
                }
            }

            return familias;
        }

        // El corazón del Composite: recorre recursivamente una Familia
        // buscando si contiene (directa o indirectamente) una Hoja dada.
        public bool FamiliaContieneHoja(Familia familia, int codHoja)
        {
            if (familia.Hojas.Any(h => h.CodHoja == codHoja))
                return true;

            foreach (var sub in familia.SubFamilias)
            {
                if (FamiliaContieneHoja(sub, codHoja))
                    return true;
            }

            return false;
        }

        // Verifica si un Rol (familias + hojas sueltas asignadas) tiene un permiso puntual
        public bool RolTienePermiso(Rol rol, int codHoja)
        {
            if (rol.HojasSueltas.Any(h => h.CodHoja == codHoja))
                return true;

            foreach (var familia in rol.Familias)
            {
                if (FamiliaContieneHoja(familia, codHoja))
                    return true;
            }

            return false;
        }

        // Carga un Rol completo (con familias/hojas resueltas contra el árbol)
        public Rol CargarRolCompleto(int codRol, string nombreRol, List<Familia> arbolCompleto)
        {
            var codFamsDelRol = dal.ListarFamiliasDeRol(codRol);
            var codHojasDelRol = dal.ListarHojasDeRol(codRol);
            var todasLasHojas = dal.ListarHojas();

            var rol = new Rol { CodRol = codRol, NombreRol = nombreRol };

            rol.Familias = arbolCompleto
                .Where(f => codFamsDelRol.Contains(f.CodFam))
                .ToList();

            rol.HojasSueltas = todasLasHojas
                .Where(h => codHojasDelRol.Contains(h.CodHoja))
                .ToList();

            return rol;
        }

    }
}
