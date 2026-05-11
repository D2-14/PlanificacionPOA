using System.Collections.Generic;

namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ModificacionesPoa
    {
        public int Error { get; set; } = 0;
        public string Mensaje { get; set; } = string.Empty;
        public List<ClaseSeven> Listado { get; set; }
    }
}