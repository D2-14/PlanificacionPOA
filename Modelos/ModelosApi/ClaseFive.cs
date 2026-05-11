namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ClaseFive
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
        public int IdActividadPOA { get; set; } = 0;
        public string ActividadPoa  { get; set; } = string.Empty;                                        
        public string Expediente { get; set; } = string.Empty;
        public string Resolucion { get; set; } = string.Empty;
        public string FechaResolucion { get; set; } = string.Empty;       
        public decimal Volumen { get; set; } = 0;
        public decimal Area { get; set; } = 0;        
        public string NoRNF { get; set; } = string.Empty;                
    }
}