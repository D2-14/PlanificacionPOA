namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoFiscalizacionIngreso
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
        /*extras*/
        public int Id_TipoDeRegistro { get; set; } = 0;
        public string NumeroDeRegistro { get; set; } = string.Empty;
        public string ErroresAnomalias { get; set; } = string.Empty;
        public int Id_ReactivaSeinef { get; set; } = 0;
        public int Id_TipoDeActa { get; set; } = 0;
        public string Tipo_Producto { get; set; } = string.Empty;
        public int Id_Especie { get; set; } = 0;
        public int Id_Pais { get; set; } = 0;
        public int Id_Estado { get; set; } = 0;
        public int Id_TipoAccion { get; set; } = 0;
        public int Id_TipoIncumplimiento { get; set; } = 0;
        public int Id_TipoCobertura { get; set; } = 0;
        public int Id_ExistenciaCobertura { get; set; } = 0;
        public string NombreEmpresa { get; set; } = string.Empty;
        public string RegistroExim { get; set; } = string.Empty;

    }
}