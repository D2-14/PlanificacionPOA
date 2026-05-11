namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoIndustriaComercio
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
        public int Id_Tema { get; set; } = 0;
        public string Tema_Especifico { get; set; } = string.Empty;
        public int Id_TipoRegistro { get; set; } = 0;
        public string NumeroRegistro { get; set; } = string.Empty;
        public int Id_TipoOrganizacion { get; set; } = 0;
        public string Tema_Organizacion { get; set; } = string.Empty;
        public int Id_TipoEmpresa { get; set; } = 0;
        public string Tema_Empresa { get; set; } = string.Empty;
        public string Producto_Recomendado { get; set; } = string.Empty;

    }
}