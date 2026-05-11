namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoMonitoreoIngreso
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
        public string  Noexpediente { get; set; } = string.Empty;
        public string Fase { get; set; } = string.Empty;
        public string NoInforme { get; set; } = string.Empty;
        public string NoResolucion { get; set; } = string.Empty;
        public int Id_Especie { get; set; } = 0;
        public decimal Volumen { get; set; } = 0;
        public int CoordenadaX { get; set; } = 0;
        public int CoordenadaY { get; set; } = 0;      
        public int Id_Garantia { get; set; } = 0;
        public int Edad { get; set; } = 0;
        public string Estado { get; set; } = string.Empty;     
        public string Estatus { get; set; } = string.Empty;
        public int Id_Evento { get; set; } = 0;
        public string Survey { get; set; } = string.Empty;
    }
}