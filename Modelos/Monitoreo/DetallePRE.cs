namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class DetallePRE
    {
        public int CorrelativoPadre { get; set; } = 0;
        public int CorrelativoHijo { get; set; } = 0;
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_Subcomponente { get; set; } = 0;
        public int Id_ProductoVerificable { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;
        public int Id_Modalidad { get; set; } = 0;
        public decimal Area { get; set; } = 0;
    }
}