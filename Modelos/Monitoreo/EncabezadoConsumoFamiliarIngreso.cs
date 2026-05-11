namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoConsumoFamiliarIngreso
    {
        public int Correlativo { get; set; } = 0;
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_Subcomponente { get; set; } = 0;
        public int Id_ProductoVerificable { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Id_Departamento { get; set; } = 0;
        public int Id_Municipio { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;
        public int Id_UM1 { get; set; } = 0;
        public int Id_UM2 { get; set; } = 0;//Volumen
        public int Id_UM3 { get; set; } = 0;
        public decimal ValorUM1 { get; set; } = 0;
        public decimal ValorUM2 { get; set; } = 0;
        public decimal ValorUM3 { get; set; } = 0;
        public string MedioDeVerificacion { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;//FechaAprobacion
        public string Observaciones { get; set; } = string.Empty;
        public int Id_usu { get; set; } = 0;
        public string Expediente { get; set; } = string.Empty;
        public string Resolucion { get; set; } = string.Empty;      
        public string DictamenTecnico { get; set; } = string.Empty;
        public string NombreCientifico { get; set; } = string.Empty;
        public string CodigoMirasil { get; set; } = string.Empty;
        public decimal Troza { get; set; } = 0;
        public decimal Lenia { get; set; } = 0;
        public int TotalDeArboles { get; set; } = 0;
        public int Municipal { get; set; } = 0;
    }
}