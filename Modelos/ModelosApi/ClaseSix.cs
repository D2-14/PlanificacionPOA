namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ClaseSix
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
        public string ResolucionPOA { get; set; } = string.Empty;
        public string ResolucionAprobacion { get; set; } = string.Empty;
        public string FechaAprobacion { get; set; } = string.Empty;
        public string Titular { get; set; } = string.Empty;     
        public decimal Area { get; set; } = 0;
        public decimal volumen { get; set; } = 0;
        public int IdTipoLicencia { get; set; } = 0;
        public string TipoLicencia { get; set; } = string.Empty;
        public int IdTipoBosque { get; set; } = 0;
        public string TipoBosque { get; set; } = string.Empty;
    }
}