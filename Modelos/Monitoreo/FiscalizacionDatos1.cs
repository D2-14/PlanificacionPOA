namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class FiscalizacionDatos1
    {
        public int CorrelativoPadre { get; set; } = 0;
        public int CorrelativoHijo { get; set; } = 0;
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_Subcomponente { get; set; } = 0;
        public int Id_ProductoVerificable { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;
        public string Maquinaria { get; set; } = string.Empty;
        public int Id_Especie { get; set; } = 0;        
        public decimal PorcentajeMaderaAserrada { get; set; } = 0;
        public decimal PorcentajeLepa { get; set; } = 0;
        public decimal PorcentajeAserrio { get; set; } = 0;
        public decimal PorcentajeOtro { get; set; } = 0;
    }
}