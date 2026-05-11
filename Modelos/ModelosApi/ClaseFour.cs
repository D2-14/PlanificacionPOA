namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ClaseFour
    {
        public int No  { get; set; } = 0;
        public int IdRegion  { get; set; } = 0;
        public string Region { get; set; } = string.Empty;
        public int IdSubregion { get; set; } = 0;
        public string Subregion { get; set; } = string.Empty;
        public int IdDepartamento { get; set; } = 0;
        public string Departamento { get; set; } = string.Empty;
        public int IdMunicipio  { get; set; } = 0;
        public string Municipio { get; set; } = string.Empty;
        public string Expediente { get; set; } = string.Empty;
        public int IdtipoLicencia { get; set; } = 0;
        public string Tipolicencia { get; set; } = string.Empty;
        public string ResolucionAprobacion { get; set; } = string.Empty;
        public string FechaAprobacion { get; set; } = string.Empty;
        public string Titular { get; set; } = string.Empty;
        public int NoPoas { get; set; } = 0;
        public decimal AreaAprobada { get; set; } = 0;
        public decimal volumenAprobado { get; set; } = 0;
    }
}