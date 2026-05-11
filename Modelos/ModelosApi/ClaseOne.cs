namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ClaseOne
    {
        public int No { get; set; } = 0;
        public int IdRegion { get; set; } = 0;
        public string Region { get; set; } = string.Empty;
        public int IdSubregion { get; set; } = 0;
        public string Subregion { get; set; } = string.Empty;
        public int IdDepartamento { get; set; } = 0;
        public string Departamento { get; set; } = string.Empty;
        public int IdMunicipio { get; set; } = 0;      
        public string Municipio { get; set; } = string.Empty;
        public string Expediente { get; set; } = string.Empty;      
        public string Resolucion { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty; 
        public string Propietario { get; set; } = string.Empty;
        public int IdModalidad { get; set; } = 0;
        public string Modalidad { get; set; } = string.Empty;
        public decimal Area { get; set; } = 0;
    }
}