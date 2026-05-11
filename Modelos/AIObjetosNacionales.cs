namespace PlanificacionPOA.Modelos
{
    public class AIObjetosNacionales
    {
        public int Opcion { get; set; } = 0;
        public int Id_Usuario { get; set; } = 0;
        public int Id_producto { get; set; } = 0;
        public int IdObjetivo { get; set; } = 0;
        public int IdResultado { get; set; } = 0;
        public int IdIndicadores { get; set; } = 0;
        public string Descripcion_Producto { get; set; } = string.Empty; 
        public int Id_Region { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Estado_Producto { get; set; } = 0;
        public int Idobjeto { get; set; } = 0;
        public int CorrelativoPSA { get; set; } = 0;
        public string Descripcion_Correlativo { get; set; } = string.Empty;
    }
}