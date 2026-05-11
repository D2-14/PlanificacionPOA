namespace PlanificacionPOA.Modelos
{
    public class InformacionActividadesNacionales
    {
        public int Id_PoAnual { get; set; } = 0;
        public int Correlativo_Configuracion { get; set; } = 0;
        public int Id_Producto { get; set; } = 0;
        public int Id_SubProducto { get; set; } = 0;
        public int Id_Actividad { get; set; } = 0;
        public int Id_SubRegion { get; set; } = 0;
        public int RedProgramatica { get; set; } = 0;
        public int Id_Unidad_Evaluada { get; set; } = 0;
        public string DescripcionProducto { get; set; } = string.Empty;
        public string DescripcionSubProducto { get; set; } = string.Empty;
        public string DescripcionActividad { get; set; } = string.Empty;
        public string DUM1 { get; set; } = string.Empty;
        public string DUM2 { get; set; } = string.Empty;
        public string DUM3 { get; set; } = string.Empty;
        public int idDUM1 { get; set; } = 0;
        public int idDUM2 { get; set; } = 0;
        public int idDUM3 { get; set; } = 0;
        public int TipoAsignacion { get; set; } = 0;        
    }
}