namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class Consumo
    {
        public int No { get; set; }
        public int IdRegion { get; set; }
        public string Region { get; set; }
        public int IdSubregion { get; set; }
        public string Subregion { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdMunicipio { get; set; }
        public string Municipio { get; set; }
        public string DictamenTecnico { get; set; } = string.Empty;
        public int ConsumoId { get; set; } = 0;
        public string NombreCientifico { get; set; } = string.Empty;
        public string CodigoMirasil { get; set; } = string.Empty;
        public decimal Troza { get; set; } = 0;
        public decimal Lenia { get; set; } = 0;
        public decimal Volumen { get; set; } = 0;
        public int TotalDeArboles { get; set; } = 0;
        public string Expediente { get; set; } = string.Empty;
        public string Resolucion { get; set; } = string.Empty;
        public string FechaAprobacion { get; set; } = string.Empty;
        public int Municipal { get; set; } = 0;// 1 es municipal, 0 inab
    }
}