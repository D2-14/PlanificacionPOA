namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoCulturaForestal
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
        public int Id_TipoEvento { get; set; } = 0;
        public string NombreEvento { get; set; } = string.Empty;
        public string TemaONombreEntidad { get; set; } = string.Empty;
        public int Id_Campania { get; set; } = 0;
        public string MediosParticipantes { get; set; } = string.Empty;
        public int Id_TemaAtendido { get; set; } = 0;
        public string NombredelMaterial { get; set; } = string.Empty;      
        public string NombreMediosComunicacion { get; set; } = string.Empty;
        public string TemaAbordado { get; set; } = string.Empty;              
        public string PeriodoPublicidadInicio { get; set; } = string.Empty;
        public string PeriodoPublicidadFinal { get; set; } = string.Empty;
        public int Id_TipoApoyo { get; set; } = 0;
        public string NombreEntidad { get; set; } = string.Empty;      
                        
    }
}