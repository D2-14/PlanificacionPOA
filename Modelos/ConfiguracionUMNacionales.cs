namespace PlanificacionPOA.Modelos
{
    public class ConfiguracionUMNacionales
    {
        public int Opcion { get; set; } = 0;
        public int Correlativo_Configuracion { get; set; } = 0;
        public int Id_Producto { get; set; } = 0;
        public string DescripcionProducto { get; set; } = string.Empty; 
        public int Id_SubProducto { get; set; } = 0;
        public string DescripcionSubProducto { get; set; } = string.Empty;
        public int Id_Actividad { get; set; } = 0;
        public string DescripcionActividad { get; set; } = string.Empty;
        public int Id_UM1 { get; set; } = 0;
        public string DescripcionUM1 { get; set; } = string.Empty;
        public int Id_UM2 { get; set; } = 0;
        public string DescripcionUM2 { get; set; } = string.Empty;
        public int Id_UM3 { get; set; } = 0;
        public string DescripcionUM3 { get; set; } = string.Empty;
        public string MedioDeVerificacion { get; set; } = string.Empty;
        public string DireccionMedioVerificacion { get; set; } = string.Empty;
        public int Id_Region { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Id_Usuario { get; set; } = 0;
        public int Id_Correlativo_Producto { get; set; } = 0;
        public int @Id_Correlativo_SubProducto { get; set; } = 0;
        public int @Id_Correlativo_Actividad { get; set; } = 0;
    }
}