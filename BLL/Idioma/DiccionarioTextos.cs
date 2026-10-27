using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace BLL.Idioma
{
    public class DiccionarioTextos
    {
        private static readonly Regex _sufijoCU = new Regex(@"\s*\(CU[^)]*\)\s*$", RegexOptions.Compiled);
        private static readonly Regex _prefijoCU = new Regex(@"^CU\d+:\s*", RegexOptions.Compiled);

        private static readonly Dictionary<string, string> EN =
            new Dictionary<string, string>(StringComparer.Ordinal)
        {
            // ---- Títulos de formularios ----
            { "AquaWash - Copia de Seguridad y Restauración", "AquaWash - Backup and Restore" },
            { "AquaWash - Gestión de Seguridad y Roles", "AquaWash - Security and Roles Management" },
            { "AquaWash - Gestión de Turnos", "AquaWash - Appointment Management" },
            { "AquaWash - Gestión de Usuarios", "AquaWash - User Management" },
            { "AquaWash Pro — Panel Principal", "AquaWash Pro — Main Panel" },
            { "Gestión de Clientes", "Customer Management" },
            { "Gestión de Vehículos", "Vehicle Management" },
            { "Gestión de Operarios", "Operator Management" },
            { "Gestión de Turnos", "Appointment Management" },
            { "Gestión de Usuarios", "User Management" },
            { "Gestión de Servicios de Lavado", "Wash Service Management" },
            { "Servicios de Lavado", "Wash Services" },
            { "Consultas de Clientes", "Customer Inquiries" },
            { "Registro de Bitácora", "Audit Log" },
            { "Bitácora del Sistema", "System Audit Log" },
            { "Estadísticas y Reportes", "Statistics and Reports" },
            { "Estadísticas y Reportes — AquaWash", "Statistics and Reports — AquaWash" },
            { "Tablero de Entregas", "Delivery Board" },
            { "Seguridad: Roles y Permisos (Composite)", "Security: Roles and Permissions (Composite)" },
            { "Base de Datos: Copia y Restauración", "Database: Backup and Restore" },
            { "INICIAR SESIÓN", "LOG IN" },
            { "AQUA WASH", "AQUA WASH" },
            { "Sistema de Gestión", "Management System" },
            { "Panel de Control", "Control Panel" },
            { "CarWash Pro v1.0", "CarWash Pro v1.0" },

            // ---- Subtítulos ----
            { "Administración de Roles (CU13), Hojas/Familias (CU14) y Asignaciones (CU15)", "Roles (CU13), Leaves/Families (CU14) and Assignments (CU15) administration" },
            { "Administración de cuentas de acceso, credenciales y asignación de roles", "Access account, credentials and role assignment administration" },
            { "Facturación acumulada por día y servicios más contratados en el mes", "Daily accumulated revenue and most hired services of the month" },
            { "Historial de eventos del sistema", "System event history" },
            { "Monitoreo en tiempo real de vehículos listos para entrega", "Real-time monitoring of vehicles ready for delivery" },
            { "Respaldo y recuperación de CarWashDB con auditoría en Bitácora", "CarWashDB backup and recovery with audit log tracking" },
            { "Listo para operaciones.", "Ready for operations." },

            // ---- Secciones / grupos ----
            { "Datos del Cliente", "Customer Data" },
            { "Datos del Operario", "Operator Data" },
            { "Datos del Turno", "Appointment Data" },
            { "Datos del Usuario", "User Data" },
            { "Datos del Vehículo", "Vehicle Data" },
            { "Clientes Registrados", "Registered Customers" },
            { "Turnos Registrados", "Registered Appointments" },
            { "Filtros de búsqueda", "Search filters" },
            { "Filtrar Turnos", "Filter Appointments" },
            { "Catálogo de Roles", "Role Catalog" },
            { "Grupos de Permisos (Familia)", "Permission Groups (Family)" },
            { "Permisos Individuales (Hoja)", "Individual Permissions (Leaf)" },
            { "Gestión de Familias y Hojas", "Families and Leaves Management" },
            { "Roles y Permisos Asignados", "Assigned Roles and Permissions" },
            { "Roles y Permisos", "Roles and Permissions" },
            { "Configurar Permisos del Rol Seleccionado", "Configure Selected Role Permissions" },
            { "Componer Familia Seleccionada", "Compose Selected Family" },
            { "Jerarquía Composite del Rol:", "Role Composite Hierarchy:" },
            { "Familias de Permisos Asignadas:", "Assigned Permission Families:" },
            { "Hojas Sueltas (Permisos Directos del Rol):", "Loose Leaves (Direct Role Permissions):" },
            { "Hojas (Permisos) contenidas:", "Contained Leaves (Permissions):" },
            { "Subfamilias contenidas:", "Contained subfamilies:" },
            { "Detalles de Entrega", "Delivery Details" },
            { "Período de análisis:", "Analysis period:" },
            { "Facturación Acumulada por Día", "Accumulated Revenue per Day" },
            { "Servicios Más Contratados en el Mes", "Most Hired Services of the Month" },
            { "Servicios y combos existentes", "Existing services and combos" },
            { "Servicios que incluye", "Included services" },
            { "Nuevo Servicio de Lavado", "New Wash Service" },
            { "Nuevo Combo", "New Combo" },
            { "Buscar cliente (DNI, nombre o apellido)", "Search customer (ID, first or last name)" },
            { "Crear Familia", "Create Family" },
            { "Crear Hoja", "Create Leaf" },
            { "Crear Rol", "Create Role" },
            { "Crear Usuario", "Create User" },

            // ---- Etiquetas de campos ----
            { "Apellido", "Last name" }, { "Apellido:", "Last name:" },
            { "Nombre", "Name" }, { "Nombre:", "Name:" },
            { "Nombre de Usuario:", "Username:" },
            { "Nombre de la Familia:", "Family name:" },
            { "Nombre del Permiso:", "Permission name:" },
            { "Nombre del Rol:", "Role name:" },
            { "Nombre del combo", "Combo name" },
            { "Nombre del servicio", "Service name" },
            { "Nombre y Apellido", "Full name" },
            { "Contraseña", "Password" }, { "Contraseña:", "Password:" },
            { "Correo Electrónico:", "Email:" },
            { "Descripción:", "Description:" },
            { "Rol Asignado:", "Assigned role:" },
            { "Rol", "Role" },
            { "Usuario", "User" },
            { "DNI", "ID number" },
            { "DNI del Cliente", "Customer ID number" },
            { "Filtrar por DNI cliente:", "Filter by customer ID:" },
            { "Teléfono", "Phone" },
            { "Patente", "License plate" },
            { "Patente de Vehículo:", "Vehicle license plate:" },
            { "Marca", "Brand" }, { "Modelo", "Model" }, { "Color", "Color" },
            { "Comisión (%)", "Commission (%)" },
            { "Precio", "Price" }, { "Precio final", "Final price" },
            { "Estado", "Status" },
            { "Estado de Turno:", "Appointment status:" },
            { "Fecha y hora", "Date and time" },
            { "Vehículo del cliente", "Customer's vehicle" },
            { "Servicio / Combo", "Service / Combo" },
            { "Servicio", "Service" },
            { "Operario", "Operator" },
            { "Criticidad", "Severity" },
            { "Módulo", "Module" },
            { "Desde", "From" }, { "Hasta", "To" },
            { "Mes:", "Month:" }, { "Año:", "Year:" },
            { "Seleccioná un vehículo", "Select a vehicle" },
            { "Seleccioná un vehículo de la grilla", "Select a vehicle from the grid" },
            { "Ruta de archivo de destino:", "Destination file path:" },
            { "Archivo (.bak) a restaurar:", "Backup file (.bak) to restore:" },
            { "* En modificaciones, dejar en blanco para conservar la actual.", "* When modifying, leave blank to keep the current one." },
            { "ID", "ID" }, { "Email", "Email" },

            // ---- Indicadores ----
            { "CLIENTE", "CUSTOMER" }, { "VEHÍCULO", "VEHICLE" }, { "SERVICIO", "SERVICE" },
            { "TELÉFONO", "PHONE" },
            { "FACTURACIÓN DEL MES", "MONTHLY REVENUE" },
            { "SERVICIOS REALIZADOS", "SERVICES PERFORMED" },
            { "TICKET PROMEDIO", "AVERAGE TICKET" },
            { "Listos para entrega", "Ready for delivery" },
            { "No hay vehículos esperando entrega", "No vehicles waiting for delivery" },
            { "Total", "Total" },
            { "Total de usuarios", "Total users" },
            { "Total de usuarios registrados", "Total registered users" },
            { "turnos", "appointments" },
            { "veh.", "veh." },

            // ---- Botones ----
            { "Agregar", "Add" }, { "Modificar", "Modify" }, { "Eliminar", "Delete" },
            { "Limpiar", "Clear" }, { "Buscar", "Search" },
            { "Buscar / Filtrar", "Search / Filter" },
            { "Ver Todos", "Show All" },
            { "Limpiar Selección", "Clear Selection" },
            { "Registrar turno", "Register appointment" },
            { "Avanzar estado", "Advance status" },
            { "Cancelar turno", "Cancel appointment" },
            { "Eliminar selección", "Delete selection" },
            { "Agregar Combo", "Add Combo" },
            { "Agregar Servicio", "Add Service" },
            { "Eliminar Rol", "Delete Role" },
            { "Actualizar Tablero", "Refresh Board" },
            { "Confirmar Entrega", "Confirm Delivery" },
            { "Vehículo listo", "Vehicle ready" },
            { "Mes Actual", "Current Month" },
            { "Actualizar Gráficos", "Update Charts" },
            { "Generar Backup Ahora", "Generate Backup Now" },
            { "Restaurar Base de Datos", "Restore Database" },
            { "Guardar Contenido de Familia", "Save Family Content" },
            { "Guardar Permisos del Rol", "Save Role Permissions" },
            { "Examinar...", "Browse..." },
            { "Seleccionar...", "Select..." },
            { "Idioma:", "Language:" },

            // ---- Textos largos de Backup ----
            { "Generar Copia de Seguridad", "Generate Backup" },
            { "Restaurar Copia de Seguridad", "Restore Backup" },
            { "Crea un archivo (.bak) con todos los clientes, vehículos, servicios, turnos, usuarios y bitácora actuales.", "Creates a (.bak) file with all current customers, vehicles, services, appointments, users and audit log." },
            { "Restaura la base de datos CarWashDB completa desde un archivo previo de copia de seguridad (.bak).", "Restores the full CarWashDB database from a previous backup file (.bak)." },
            { "¡ADVERTENCIA CRÍTICA! Esta acción reemplazará permanentemente los datos actuales con la copia seleccionada.", "CRITICAL WARNING! This action will permanently replace the current data with the selected backup." },

            // ---- Estados de turno (texto, no enum) ----
            { "Pendiente", "Pending" }, { "Asignado", "Assigned" }, { "En Lavado", "In Washing" },
            { "Lavado Terminado", "Washing Finished" }, { "Entregado", "Delivered" }, { "Cancelado", "Cancelled" }
        };

        // Devuelve el texto en inglés; si no está en el diccionario devuelve el original sin tocar.
        public static string Traducir(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return texto;

            // Separar prefijo (emojis / símbolos / espacios) y sufijo (espacios) para conservarlos
            int ini = 0;
            while (ini < texto.Length && !char.IsLetterOrDigit(texto[ini]) && texto[ini] != '¡' && texto[ini] != '¿') ini++;
            if (ini >= texto.Length) return texto;
            int fin = texto.Length;
            while (fin > ini && char.IsWhiteSpace(texto[fin - 1])) fin--;

            string prefijo = texto.Substring(0, ini);
            string nucleo = texto.Substring(ini, fin - ini);
            string sufijo = texto.Substring(fin);

            // "CU08" es referencia del documento: se separa, se traduce lo demás y se vuelve a pegar
            string marcaCU = "";
            Match mSufijo = _sufijoCU.Match(nucleo);
            if (mSufijo.Success) { marcaCU = mSufijo.Value.TrimEnd(); nucleo = nucleo.Substring(0, mSufijo.Index); }
            string prefCU = "";
            Match mPref = _prefijoCU.Match(nucleo);
            if (mPref.Success) { prefCU = mPref.Value; nucleo = nucleo.Substring(mPref.Length); }

            string trad;
            if (EN.TryGetValue(nucleo, out trad))
                return prefijo + prefCU + trad + marcaCU + sufijo;

            // "Listos para entrega: 3" -> traduce solo lo que está antes de los dos puntos
            int dp = nucleo.IndexOf(':');
            if (dp > 0 && EN.TryGetValue(nucleo.Substring(0, dp), out trad))
                return prefijo + prefCU + trad + nucleo.Substring(dp) + marcaCU + sufijo;

            // "5 turnos" / "3 veh." -> traduce lo que está después del número
            Match mNum = Regex.Match(nucleo, @"^(\d+)\s+(.+)$");
            if (mNum.Success && EN.TryGetValue(mNum.Groups[2].Value, out trad))
                return prefijo + mNum.Groups[1].Value + " " + trad + sufijo;

            return texto;
        }
    }
}
