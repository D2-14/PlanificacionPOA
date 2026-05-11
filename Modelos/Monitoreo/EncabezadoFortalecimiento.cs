namespace PlanificacionPOA.Modelos.Monitoreo
{
    public class EncabezadoFortalecimiento
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
        public int Id_Puesto_Actvidad { get; set; } = 0;
        public string NombreActor{ get; set; } = string.Empty;
        public string TemaAtendido { get; set; } = string.Empty;
        public string AccionesSeguimiento { get; set; } = string.Empty;
        public string ComunidadOrganizacion { get; set; } = string.Empty;
        public string UbicacionOrganizacion { get; set; } = string.Empty;
        public string NombreDocumento { get; set; } = string.Empty;
        public int AnioVigenciaPolitica { get; set; } = 0;
        public int TipoActor { get; set; } = 0;
        public int Actores { get; set; } = 0;
    }
}
