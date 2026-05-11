namespace PlanificacionPOA.Modelos
{
    public class Usuario_Manipulacion
    {
        public string Usuario { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Tperfil { get; set; } = 0;
        public int IdUsuario { get; set; } = 0;
        public int Opcion { get; set; } = 0;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string DPI { get; set; } = string.Empty;
        public string Respuesta { get; set; } = string.Empty;
        public bool CodigoResulta { get; set; } = false;
        public int Region { get; set; } = 0;
        public int Subregion { get; set; } = 0;
        public int Puesto { get; set; } = 0;
        public int Usuarioqcambio { get; set; } = 0;
    }
}