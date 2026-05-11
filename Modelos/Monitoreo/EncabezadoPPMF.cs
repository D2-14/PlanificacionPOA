namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoPPMF
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
        /*extra*/
        public int Id_TipoBosque { get; set; } = 0;
        public int CoordenadaX { get; set; } = 0;
        public int CoordenadaY { get; set; } = 0;
        public string FechaPlantacion { get; set; } = string.Empty;
        public int NoMedicion { get; set; } = 0;
        public string FechaPPM { get; set; } = string.Empty;
        public string NombreSitio { get; set; } = string.Empty;
        public int NoExperimento { get; set; } = 0;
        public int NoParcela { get; set; } = 0;       
        public decimal Replanteo { get; set; } = 0;
        public int UnidadMuestreo { get; set; } = 0;
        public string CodigoProyecto { get; set; } = string.Empty; 
    }
}