namespace PlanificacionPOA.Modelos
{
    public class TMonitoreo
    {
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;     
        public string FechaDeFinal { get; set; } = string.Empty;
        public string Instrucciones { get; set; } = string.Empty;
        public int Id_Usuario { get; set; } = 0;
    }
}