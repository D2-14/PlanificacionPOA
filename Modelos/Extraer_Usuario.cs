namespace PlanificacionPOA.Modelos
{
    public class Extraer_Usuario
    {
        public string id_usuario { get; set; } = string.Empty;
        public string Id_Tipoperfil { get; set; } = string.Empty;
        public string nombreusuario { get; set; } = string.Empty;
        public string id_region { get; set; } = string.Empty;
        public string id_subregion { get; set; } = string.Empty;
        public string DescripcionPerfil { get; set; } = string.Empty;
        public int Cambios { get; set; } = 0;
        public int ErrorCodigo { get; set; } = 0;
        public string Descripcion { get; set; } = string.Empty;
    }
}