namespace PlanificacionPOA.Modelos
{
    public class DatosTarea
    {
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Usuario { get; set; } = 0;       
        public int Id_Region { get; set; } = 0;
        public int Id_SubRegion { get; set; } = 0;
        public string Instrucciones { get; set; } = string.Empty;
        public string NombrePoa { get; set; } = string.Empty;
        public string DescripcionSubregion { get; set; } = string.Empty; 
        public string FechaEntrega { get; set; } = string.Empty;
        public int TipoAsignacion { get; set; } = 0;
        public int NoReprogramacion { get; set; } = 0;
        public int IdMensaje { get; set; } = 0;
        public int Op   {get; set; } = 0;
        public int dependecia { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_SubComponente { get; set; } = 0;
    }
}