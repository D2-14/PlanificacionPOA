namespace PlanificacionPOA.Modelos
{
    public class Tarea
    {
        public int Id_PoAnual { get; set; } = 0;
        public string FechaDeEntrega { get; set; } = string.Empty;
        public string Instrucciones { get; set; } = string.Empty;
        public int Id_Usuario { get; set; } = 0; 
    }
}