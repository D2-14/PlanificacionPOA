namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoProteccionForestal
    {
        public int Correlativo { get; set; } = 0;
        public int Id_PoAnual { get; set; } = 0;
        public int Id_Componente { get; set; } = 0;
        public int Id_Subcomponente { get; set; } = 0;
        public int Id_ProductoVerificable { get; set; } = 0;
        public int Id_Subregion { get; set; } = 0;
        public int Id_Departamento { get; set; } = 0;
        public int Id_Municipio { get; set; } = 0;
        public int Id_Mes { get; set; } = 0;
        public int Id_UM1 { get; set; } = 0;
        public int Id_UM2 { get; set; } = 0;
        public int Id_UM3 { get; set; } = 0;
        public decimal ValorUM1 { get; set; } = 0;
        public decimal ValorUM2 { get; set; } = 0;
        public decimal ValorUM3 { get; set; } = 0;
        public string MedioDeVerificacion { get; set; } = string.Empty;
        public string Fecha { get; set; } = string.Empty;
        public string Observaciones { get; set; } = string.Empty;
        public int Id_usu { get; set; } = 0;
        /*extra*/
        public string NoExpediente { get; set; } = string.Empty;
        public string AgenteCausal { get; set; } = string.Empty;
        public string NombreTitular { get; set; } = string.Empty;
        public decimal Hectarias { get; set; } = 0;
        public int CoordenadaX { get; set; } = 0;
        public int CoordenadaY { get; set; } = 0;
        public string NombreContacto { get; set; } = string.Empty;
        public int NumeroTelefono { get; set; } = 0;
        public int Id_EquipoProteccion { get; set; } = 0;
        public int Id_tipoAreaBM { get; set; } = 0;
        public int Id_AreaBM { get; set; } = 0;
        public int Id_fase { get; set; } = 0;
        public int Id_TipoEscenario { get; set; } = 0;       
        public string NumeroMuestra { get; set; } = string.Empty;
        public int Id_Tipo_Bosque { get; set; } = 0;
        public int Id_Tipo_Incendio { get; set; } = 0;
        public int Id_Tipo_Administracion { get; set; } = 0;
    }
}