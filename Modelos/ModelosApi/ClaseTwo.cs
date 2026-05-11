
namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class ClaseTwo
    {
        public int No { get; set; } = 0;
        public int Id_Region { get; set; } = 0;
        public int subregionId { get; set; } = 0;
        public int DepartamentoId { get; set; } = 0;
        public int MunicipioId { get; set; } = 0;
        public int TipoRegistroId { get; set; } = 0;
        public string Departamento { get; set; } = string.Empty;
        public string Municipio { get; set; } = string.Empty;
        public string No_Registro { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string Subregion { get; set; } = string.Empty;
        public string TipoRegistro { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public int Id_Estado { get; set; } = 0;
        public string Fecha { get; set; } = string.Empty;
        public string NoExpediente { get; set; } = string.Empty;
        public int IdDivisionProducto { get; set; } = 0;
    }
}