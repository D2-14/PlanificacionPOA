namespace PlanificacionPOA.Modelos
{
    public class RegresoInformacionSubregional
    {
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_SubComponente { get; set; } = 0;
        public int Id_SubRegion { get; set; } = 0;
        public int Id_ProductoVeficable { get; set; } = 0;
        public int RedProgramatica { get; set; } = 0;
        public int NoPlanificable { get; set; } = 0;
        public string Actividad { get; set; } = string.Empty; 
        public string DUM1 { get; set; } = string.Empty;
        public string DUM2 { get; set; } = string.Empty;
        public string DUM3 { get; set; } = string.Empty;
        public int idDUM1 { get; set; } = 0;
        public int idDUM2 { get; set; } = 0;
        public int idDUM3 { get; set; } = 0;
        public int TipoAsignacion { get; set; } = 0;
    }
}