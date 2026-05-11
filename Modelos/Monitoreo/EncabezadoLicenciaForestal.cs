namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoLicenciaForestal
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
        /*datos extras*/
        public string NoExpediente { get; set; } = string.Empty;
        public string NoResolucionInformePOATrimestral { get; set; } = string.Empty;//Resolucion poa,No de resolucion,informe trimestral
        public int Id_TipoDeModificacion { get; set; } = 0;        
        public int Id_TipoLicencia { get; set; } = 0;
        public int Id_TipoDeBosque { get; set; } = 0;
        public string NoLicencia { get; set; } = string.Empty;
        public decimal Hectarias { get; set; } = 0;
        public string Titular { get; set; } = string.Empty;
        public int NoTelefono { get; set; } = 0;
        public decimal CoordenadaX { get; set; } = 0;
        public decimal CoordenadaY { get; set; } = 0;
        public string Especie { get; set; } = string.Empty;
        public string Elaborador { get; set; } = string.Empty;
        public int NoTelefonoElabora { get; set; } = 0;
        public int Id_Tratamiento { get; set; } = 0;
    }
}