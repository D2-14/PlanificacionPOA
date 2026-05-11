namespace PlanificacionPOA.Modelos
{
    public class Correo_Data
    {
        public string Destinatario { get; set; } = string.Empty; 
        public string Sistema { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Subregion { get; set; } = 0;
    }
}