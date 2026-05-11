namespace PlanificacionPOA.Modelos
{
    public class ArchivosParaCarga
    {
        public bool Existe { get; set; } = false;
        public string Nombre { get; set; } = string.Empty;
        public int bytes { get; set; } = 0;
        public string EnlaceDeGuardado { get; set; } = string.Empty; 
        public string ExtensionArchivo { get; set; } = string.Empty;
    }
}