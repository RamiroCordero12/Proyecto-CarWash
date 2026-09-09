using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWash.BE;

namespace MPP
{
    public static class ServicioLavadoMPP
    {
        // Fila cruda de ServicioLavado, sin resolver todavía el Composite.
        // Vive acá porque es responsabilidad de MPP transcribir filas de BD.
        public class FilaServicio
        {
            public int IdServicio { get; set; }
            public string Nombre { get; set; }
            public decimal PrecioBase { get; set; }
            public bool EsCombo { get; set; }
        }

        // Arma el árbol completo del Composite a partir de:
        // - filas: todas las filas de ServicioLavado (hojas y combos, sin resolver)
        // - jerarquia: relaciones (IdCombo, IdServicio) de LavadoJerarquia
        public static List<IComponenteServicio> ArmarArbol(
            List<FilaServicio> filas,
            List<(int IdCombo, int IdServicio)> jerarquia)
        {
            var mapaComponentes = new Dictionary<int, IComponenteServicio>();

            foreach (var fila in filas)
            {
                if (fila.EsCombo)
                {
                    mapaComponentes[fila.IdServicio] = new PaqueteServicio
                    {
                        IdPaquete = fila.IdServicio,
                        Nombre = fila.Nombre,
                        PrecioFinal = fila.PrecioBase // Opción B: precio ya fijado
                    };
                }
                else
                {
                    mapaComponentes[fila.IdServicio] = new ServiIndividual
                    {
                        IdServicio = fila.IdServicio,
                        Nombre = fila.Nombre,
                        Precio = fila.PrecioBase
                    };
                }
            }

            foreach (var (idCombo, idServicio) in jerarquia)
            {
                if (mapaComponentes.TryGetValue(idCombo, out var combo) &&
                    combo is PaqueteServicio paquete &&
                    mapaComponentes.TryGetValue(idServicio, out var componente))
                {
                    paquete.Agregar(componente);
                }
            }

            var idsQueSonComponentes = jerarquia.Select(j => j.IdServicio).ToHashSet();

            return mapaComponentes
                .Where(kv => !idsQueSonComponentes.Contains(kv.Key))
                .Select(kv => kv.Value)
                .ToList();
        }

        // Mapea una sola fila de reader a FilaServicio (transcripción pura,
        // esto es lo que MPP hace de verdad: tupla -> objeto)
        public static FilaServicio MapearFilaDesdeReader(System.Data.SqlClient.SqlDataReader reader)
        {
            return new FilaServicio
            {
                IdServicio = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                PrecioBase = reader.GetDecimal(2),
                EsCombo = reader.GetBoolean(3)
            };
        }
    }
}