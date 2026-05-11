
using System.Xml;

namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ResultadoConsumoFamiliar
    {
        public XmlDocument Aprobado { get; set; }
        public XmlDocument Denegado { get; set; }
    }
}