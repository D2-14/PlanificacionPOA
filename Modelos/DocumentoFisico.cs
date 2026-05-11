namespace PlanificacionPOA.Modelos
{
    public class DocumentoFisico
    {
        public string Enlace_del_Documento { get; set; } = string.Empty; 
        public string Descripcion { get; set; } = string.Empty;
        public string NombreArchivo { get; set; } = string.Empty;
        public int Id_Usuario { get; set; } = 0;
    }
}