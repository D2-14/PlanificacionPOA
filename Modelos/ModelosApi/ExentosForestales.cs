using System.Collections.Generic;

namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ExentosForestales
    {
        public int Error { get; set; } = 0;
        public string Mensaje { get; set; } = string.Empty;
        public List<ClaseFive> Listado { get; set; }
    }
}