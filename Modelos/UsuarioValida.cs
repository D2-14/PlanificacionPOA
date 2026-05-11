namespace PlanificacionPOA.Modelos
{
    public class UsuarioValida
    {
        public int id_usuario { get; set; } = 0;
        public int Id_Tipoperfil { get; set; } = 0;
        public int id_region { get; set; } = 0;
        public int id_subregion { get; set; } = 0;
        public string DescripcionPerfil { get; set; } = string.Empty;
    }
}