namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoRNF
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
        public int Id_UM2 { get; set; } = 0;
        public int Id_UM3 { get; set; } = 0;
        public decimal ValorUM1 { get; set; } = 0;
        public decimal ValorUM2 { get; set; } = 0;
        public decimal ValorUM3 { get; set; } = 0;
        public string MedioDeVerificacion { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public int Id_usu { get; set; } = 0;
        public string NoRegistro { get; set; } = string.Empty;
        public string NoExpediente { get; set; } = string.Empty;
        public int TipoRegistroId { get; set; } = 0;
        public int IdDivisionProducto { get; set; } = 0;
        public string TipoRegistro { get; set; } = string.Empty;
        public int IdEstadoRNF { get; set; } = 0;
        public string CategoriaRNF { get; set; } = string.Empty;
        public string SubcategoriaRNF { get; set; } = string.Empty;
        public string Especificaciones { get; set; } = string.Empty;
        public int IdTipoDenegacion { get; set; } = 0;
    }
}