namespace PlanificacionPOA.Modelos
{
    public class Permisos_del_Sistema
    {
        public int Id_Menu { get; set; } = 0;
        public int Id_Padre { get; set; } = 0;
        public string Descripcion { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}