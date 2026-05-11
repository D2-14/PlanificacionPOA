namespace PlanificacionPOA.Modelos
{
    public class ProductoRegional
    {
        public int Id_Componente { get; set; } = 0;
        public string DescripcionComponente { get; set; } = string.Empty;
        public int Id_SubComponente { get; set; } = 0;
        public string DescripcionSubComponente { get; set; } = string.Empty;
        public int Id_ProductoVeficable { get; set; } = 0;
        public string DescripcionProductoVeficable { get; set; } = string.Empty;
        public int Id_MetasRedProgramatica { get; set; } = 0;
        public int Id_NoPlanificable { get; set; } = 0;
        public int Id_UM1 { get; set; } = 0;
        public string DescripcionUM1 { get; set; } = string.Empty;
        public int Id_UM2 { get; set; } = 0;
        public string DescripcionUM2 { get; set; } = string.Empty;
        public int Id_UM3 { get; set; } = 0;
        public string DescripcionUM3 { get; set; } = string.Empty;
        public int Id_UnidadMedida { get; set; } = 0;
        public string DescripcionUnidadMedida { get; set; } = string.Empty;
        public string MedioDeVerificacion { get; set; } = string.Empty;
        public string DireccionMedioVerificacion { get; set; } = string.Empty;
        public int Id_Usuario { get; set; } = 0;
        public int anioPoa { get; set; } = 0;
        public int Id_PoAnual  { get; set; } = 0;
        public int CorrelativoC { get; set; } = 0;
        public int CorrelativoSC { get; set; } = 0;
        public int CorrelativoPC { get; set; } = 0;
    }
}