using BLL.Bitacora;
using CarWash.BE;
using CarWash.BE.Bitacora;
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
        private RegistroBitacoraBLL bitacoraBLL = new RegistroBitacoraBLL();

        private int? ObtenerIdUsuarioActual()
        {
            return SesionActual.Instancia?.UsuarioLogueado?.IdUsuario;
        }

        #region Composite & Resolución de Permisos

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

        public bool RolTienePermisoPorNombre(Rol rol, string nombreHoja)
        {
            if (rol == null) return false;
            var hojas = dal.ListarHojas();
            var hoja = hojas.FirstOrDefault(h => h.NombreHoja.Equals(nombreHoja, StringComparison.OrdinalIgnoreCase));
            if (hoja == null) return false;
            return RolTienePermiso(rol, hoja.CodHoja);
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

        #endregion

        #region CU13 - Roles ABM

        public List<Rol> ListarRoles()
        {
            return dal.ListarRoles();
        }

        public Rol ObtenerRolPorId(int codRol)
        {
            return dal.ObtenerRolPorId(codRol);
        }

        public int CrearRol(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException(nameof(rol));
            if (string.IsNullOrWhiteSpace(rol.NombreRol))
                throw new Exception("El nombre del rol no puede estar vacío.");

            rol.NombreRol = rol.NombreRol.Trim();
            if (dal.ExisteNombreRol(rol.NombreRol))
                throw new Exception($"Ya existe un rol con el nombre '{rol.NombreRol}'.");

            int id = dal.CrearRol(rol);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Alta de rol: {rol.NombreRol} (ID {id})",
                modulo: "Roles",
                criticidad: Criticidad.Media);

            return id;
        }

        public void ModificarRol(Rol rol)
        {
            if (rol == null) throw new ArgumentNullException(nameof(rol));
            if (rol.CodRol <= 0) throw new Exception("ID de rol inválido.");
            if (string.IsNullOrWhiteSpace(rol.NombreRol))
                throw new Exception("El nombre del rol no puede estar vacío.");

            rol.NombreRol = rol.NombreRol.Trim();
            if (dal.ExisteNombreRol(rol.NombreRol, rol.CodRol))
                throw new Exception($"Ya existe otro rol con el nombre '{rol.NombreRol}'.");

            dal.ModificarRol(rol);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Modificación de rol: {rol.NombreRol} (ID {rol.CodRol})",
                modulo: "Roles",
                criticidad: Criticidad.Alta);
        }

        public void EliminarRol(int codRol, string nombreRol)
        {
            if (codRol <= 0) throw new Exception("ID de rol inválido.");
            dal.EliminarRol(codRol);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Eliminación de rol: {nombreRol} (ID {codRol})",
                modulo: "Roles",
                criticidad: Criticidad.Alta);
        }

        #endregion

        #region CU14 - Hojas y Familias ABM

        public List<Hoja> ListarHojas() => dal.ListarHojas();
        public List<Familia> ListarFamilias() => dal.ListarFamilias();

        public int CrearHoja(Hoja hoja)
        {
            if (hoja == null) throw new ArgumentNullException(nameof(hoja));
            if (string.IsNullOrWhiteSpace(hoja.NombreHoja))
                throw new Exception("El nombre del permiso individual no puede estar vacío.");

            hoja.NombreHoja = hoja.NombreHoja.Trim();
            if (dal.ExisteNombreHoja(hoja.NombreHoja))
                throw new Exception($"Ya existe un permiso con el nombre '{hoja.NombreHoja}'.");

            int id = dal.CrearHoja(hoja);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Alta de permiso (Hoja): {hoja.NombreHoja} (ID {id})",
                modulo: "Seguridad",
                criticidad: Criticidad.Media);

            return id;
        }

        public void ModificarHoja(Hoja hoja)
        {
            if (hoja == null) throw new ArgumentNullException(nameof(hoja));
            if (hoja.CodHoja <= 0) throw new Exception("ID de permiso inválido.");
            if (string.IsNullOrWhiteSpace(hoja.NombreHoja))
                throw new Exception("El nombre del permiso no puede estar vacío.");

            hoja.NombreHoja = hoja.NombreHoja.Trim();
            if (dal.ExisteNombreHoja(hoja.NombreHoja, hoja.CodHoja))
                throw new Exception($"Ya existe otro permiso con el nombre '{hoja.NombreHoja}'.");

            dal.ModificarHoja(hoja);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Modificación de permiso (Hoja): {hoja.NombreHoja} (ID {hoja.CodHoja})",
                modulo: "Seguridad",
                criticidad: Criticidad.Alta);
        }

        public void EliminarHoja(int codHoja, string nombreHoja)
        {
            if (codHoja <= 0) throw new Exception("ID de permiso inválido.");
            dal.EliminarHoja(codHoja);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Eliminación de permiso (Hoja): {nombreHoja} (ID {codHoja})",
                modulo: "Seguridad",
                criticidad: Criticidad.Alta);
        }

        public int CrearFamilia(Familia fam)
        {
            if (fam == null) throw new ArgumentNullException(nameof(fam));
            if (string.IsNullOrWhiteSpace(fam.NombreFamilia))
                throw new Exception("El nombre de la familia no puede estar vacío.");

            fam.NombreFamilia = fam.NombreFamilia.Trim();
            if (dal.ExisteNombreFamilia(fam.NombreFamilia))
                throw new Exception($"Ya existe una familia de permisos con el nombre '{fam.NombreFamilia}'.");

            int id = dal.CrearFamilia(fam);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Alta de Familia de permisos: {fam.NombreFamilia} (ID {id})",
                modulo: "Seguridad",
                criticidad: Criticidad.Media);

            return id;
        }

        public void ModificarFamilia(Familia fam)
        {
            if (fam == null) throw new ArgumentNullException(nameof(fam));
            if (fam.CodFam <= 0) throw new Exception("ID de familia inválido.");
            if (string.IsNullOrWhiteSpace(fam.NombreFamilia))
                throw new Exception("El nombre de la familia no puede estar vacío.");

            fam.NombreFamilia = fam.NombreFamilia.Trim();
            if (dal.ExisteNombreFamilia(fam.NombreFamilia, fam.CodFam))
                throw new Exception($"Ya existe otra familia con el nombre '{fam.NombreFamilia}'.");

            dal.ModificarFamilia(fam);
            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Modificación de Familia de permisos: {fam.NombreFamilia} (ID {fam.CodFam})",
                modulo: "Seguridad",
                criticidad: Criticidad.Alta);
        }

        public void EliminarFamilia(int codFam, string nombreFamilia)
        {
            if (codFam <= 0) throw new Exception("ID de familia inválido.");
            dal.EliminarFamilia(codFam);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Eliminación de Familia de permisos: {nombreFamilia} (ID {codFam})",
                modulo: "Seguridad",
                criticidad: Criticidad.Alta);
        }

        #endregion

        #region CU15 - Asignaciones Composite

        public List<int> ListarFamiliasDeRol(int codRol) => dal.ListarFamiliasDeRol(codRol);
        public List<int> ListarHojasDeRol(int codRol) => dal.ListarHojasDeRol(codRol);
        public List<(int CodFam, int CodHoja)> ListarPatFam() => dal.ListarPatFam();
        public List<(int CodFamPadre, int CodFamHijo)> ListarFamFam() => dal.ListarFamFam();

        public void GuardarPermisosRol(int codRol, string nombreRol, List<int> codFamilias, List<int> codHojas)
        {
            if (codRol <= 0) throw new Exception("ID de rol inválido.");
            dal.GuardarPermisosRol(codRol, codFamilias, codHojas);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Actualización de permisos del Rol '{nombreRol}' (ID {codRol}): {codFamilias?.Count ?? 0} familias, {codHojas?.Count ?? 0} hojas sueltas",
                modulo: "Roles",
                criticidad: Criticidad.Alta);
        }

        public void GuardarContenidoFamilia(int codFamPadre, string nombreFamilia, List<int> codSubfamilias, List<int> codHojas)
        {
            if (codFamPadre <= 0) throw new Exception("ID de familia inválido.");

            // Validar que no contenga ciclos
            if (codSubfamilias != null)
            {
                if (codSubfamilias.Contains(codFamPadre))
                    throw new Exception("Una familia no puede ser hija de sí misma.");

                var relacionesExistentes = dal.ListarFamFam().Where(r => r.CodFamPadre != codFamPadre).ToList();
                foreach (int hijo in codSubfamilias)
                {
                    if (TieneCicloRecursivo(hijo, codFamPadre, relacionesExistentes))
                        throw new Exception($"Asignar la subfamilia ID {hijo} crearía una referencia circular en la jerarquía.");
                }
            }

            dal.GuardarContenidoFamilia(codFamPadre, codSubfamilias, codHojas);

            bitacoraBLL.Registrar(
                idUsuario: ObtenerIdUsuarioActual(),
                accion: $"Actualización de contenido de Familia '{nombreFamilia}' (ID {codFamPadre}): {codSubfamilias?.Count ?? 0} subfamilias, {codHojas?.Count ?? 0} hojas",
                modulo: "Seguridad",
                criticidad: Criticidad.Alta);
        }

        private bool TieneCicloRecursivo(int origen, int destino, List<(int CodFamPadre, int CodFamHijo)> relaciones)
        {
            if (origen == destino) return true;
            foreach (var rel in relaciones.Where(r => r.CodFamPadre == origen))
            {
                if (TieneCicloRecursivo(rel.CodFamHijo, destino, relaciones))
                    return true;
            }
            return false;
        }

        #endregion
    }
}
