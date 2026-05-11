namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoNacionalGeneral
    {
        public int Correlativo { get; set; } = 0;
        public int Id_PoAnual { get; set; } = 0;
        public int Tipo { get; set; } = 0;
        public int Correlativo_Configuracion { get; set; } = 0;
        public int Id_Producto { get; set; } = 0;
        public int Id_SubProducto { get; set; } = 0;
        public int Id_Actividad { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;       
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
    }
}