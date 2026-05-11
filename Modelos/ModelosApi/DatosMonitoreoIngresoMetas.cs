namespace PlanificacionPOA.Modelos.ModelosApi
{
    public class DatosMonitoreoIngresoMetas
    {
        public int Id_PoAnual { get; set; } = 0;
        public string NombrePOA { get; set; } = string.Empty;
        public int Id_Region { get; set; } = 0;
        public string Nombre_Region { get; set; } = string.Empty;
        public int Id_Subregion { get; set; } = 0;
        public string Nombre_SubRegion { get; set; } = string.Empty;
        public int IdComponente { get; set; } = 0;
        public string Descripcion_Componente { get; set; } = string.Empty;
        public int Id_SubComponente { get; set; } = 0;
        public int Id_ProductoVerificable { get; set; } = 0;
        public string Descripcion_ProductoVerificable { get; set; } = string.Empty;
        public int Id_Mes { get; set; } = 0;
        public string Descripcion_mes { get; set; } = string.Empty;
        public int Id_Usuario { get; set; } = 0;
        public string Fecha_Inicio { get; set; } = string.Empty;
        public string Fecha_Final { get; set; } = string.Empty;
        public int Id_Mensaje { get; set; } = 0;
        public string Instrucciones { get; set; } = string.Empty;
        public int Id_UM1 { get; set; } = 0;
        public int Id_UM2 { get; set; } = 0;
        public int Id_UM3 { get; set; } = 0;

    }
}