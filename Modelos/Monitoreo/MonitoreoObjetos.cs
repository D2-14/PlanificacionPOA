namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class MonitoreoObjetos
    {
        public int Tipo { get; set; } = 0; // 1 Producto, 2 Subproducto, 3 Actividad
        public int Correlativo { get; set; } = 0;
        public string Descripcion { get; set; } =string.Empty;
        public int Id_Producto { get; set; } = 0;
        public int Id_SubProducto { get; set; } = 0;
        public int  Id_Actividad { get; set; } = 0;
        public int Id_Poa { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
    }
}