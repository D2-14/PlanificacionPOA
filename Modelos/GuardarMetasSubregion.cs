namespace PlanificacionPOA.Modelos
{
    public class GuardarMetasSubregion
    {
		public int Op { get; set; } = 0;
		public int Id_PoAnual { get; set; } = 0;
		public int Id_Subregion { get; set; } = 0;
		public int Id_Componente { get; set; } = 0;
		public int Id_SubComponente { get; set; } = 0;
		public int Id_ProductoVeficable{ get; set; } = 0;
		public int Id_Usuario{ get; set; } = 0;
		public int Id_Mes { get; set; } = 0;
		public decimal UM1 { get; set; } = 0;
		public decimal UM2 { get; set; } = 0;
		public decimal UM3 { get; set; } = 0;
		public int TipoAsignacion { get; set; } = 0;
	}
}