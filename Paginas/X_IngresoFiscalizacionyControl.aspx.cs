using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Xml;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class X_IngresoFiscalizacionyControl : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();       
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(confirmar, "Key5");
        }
        protected void BtnFinalizarIngreso_Click(object sender, EventArgs e)
        {
            OpenWinwdows(confirmar, "330", "170", "Key5", "Información");
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Componentes_Monitoreo.aspx");
        }
        protected void BtnIrConfiguracion_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 85).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                if (Mim.FinalizarIngresoDeComponente(DMI, ref er))
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void CerraVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(visualizar, "Key");
        }
        protected string CadenaSql(int opcion, int Subcomponente)
        {
            ManejoInformacionMonitoreo X = new ManejoInformacionMonitoreo();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];  
            
            string Cadena = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                             X.ValorDeOpcion(3, Subcomponente, DMI.Id_SubComponente) + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + opcion;
            return Cadena;
        }
        private void CboTipoActa_TextChanged(object sender, EventArgs e) 
        {
            if(procesos.IntNULLCombo(CboTipoActa) == 1) 
            {
                tblErrorAnomalia.Visible = true;
            }
            else 
            {
                tblErrorAnomalia.Visible = false;
            }
        }
        private void CboDepartamento_TextChanged(object sender, EventArgs e)
        {            
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            cboMunicipio.ClearSelection();
            procesos.LLenarComboT(cboMunicipio, Mim.CadenaComboDeptoMuni(procesos.IntNULLCombo(cboDepartamento).ToString(), DMI.Id_Subregion.ToString(), 2), "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            DMI.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente);
            Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
            GrdProductos.Rebind();
        }
        protected void GrdProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            if (DMI.Id_SubComponente != 0)
            {
                GrdProductos.Visible = true;
                string CadenaSql = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                                    DMI.Id_SubComponente + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + 2;
                procesos.LlenarRadGrid(GrdProductos, CadenaSql);
            }
            else
            {
                GrdProductos.Visible = false;
            }
        }
        protected void Seleccionar_Productos(object sender, GridCommandEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            ConectarBDD Grabar = new ConectarBDD();
            GridDataItem item = e.Item as GridDataItem;
            string Cadena;
            int Producto;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
                    
            if (e.CommandName == "Select")
            {
                DMI.Id_ProductoVerificable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                DMI.Descripcion_ProductoVerificable = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                GrdProductos.Visible = false;
                subcomp.Visible = false;
                Informacion.Visible = true;
                txtSubcomponente.Text = procesos.StrNULLCombo(CboSubcomponente);
                ProductoV.Text = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                Cadena = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                                    DMI.Id_SubComponente + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + 3 + "," + Producto;
                DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

                DMI.Id_UM1 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM1"].ToString());
                DMI.Id_UM2 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM2"].ToString());
                DMI.Id_UM3 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM3"].ToString());

                Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;

                LblUM1.Text = "UM1 " + Datos.Tables[0].Rows[0]["DescripcionUM1"].ToString();
                trum1.Visible = vp.ValidarCamposUM(DMI.Id_UM1, 1).ExpresionBool;
                txtum1.Text = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionNumber;
                txtum1.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionBool;

                LblUM2.Text = "UM2 " + Datos.Tables[0].Rows[0]["DescripcionUM2"].ToString();
                trum2.Visible = vp.ValidarCamposUM(DMI.Id_UM2, 1).ExpresionBool;
                txtum2.Text = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionNumber;
                txtum2.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionBool;

                LblUM3.Text = "UM3 " + Datos.Tables[0].Rows[0]["DescripcionUM3"].ToString();
                trum3.Visible = vp.ValidarCamposUM(DMI.Id_UM3, 1).ExpresionBool;
                txtum3.Text = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionNumber;
                txtum3.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionBool;

                //Validar objetos visibles
                tblErrorAnomalia.Visible = false;
                tblRegistro.Visible = false;
                tblTipoActa.Visible = false;
                tblEmpresa.Visible = false;
                tblProductoEspecie.Visible = false;
                tblEstadoTipoAccion.Visible = false;
                TblEstado.Visible = false;
                tblSeRNAFActivado.Visible = false;
                tblEstadoTipoAccion.Visible = false;
                tblpais.Visible = false;
                tblexistenciacoberturaF.Visible = false;
                tblexistenciacoberturaF1.Visible = false;
                txttipoProducto.Visible = false;
                Label15.Visible = false;
                Guardar.Visible = false;

                if (DMI.Id_ProductoVerificable == 63)
                {
                    Guardar.Visible = true;
                }

                if (DMI.Id_ProductoVerificable == 52) 
                {
                    procesos.LLenarComboT(CboTipoRegistro, "SELECT Id_TipoRegistro Id,Descripcion2 Descripcion  FROM Tipo_Registro_Monitoreo WHERE Estado = 1 AND Id_TipoRegistro != 5;", "Descripcion", "Id", true);
                    tblRegistro.Visible = true;
                    Guardar.Visible = true;
                }
                if ((DMI.Id_ProductoVerificable == 51) || (DMI.Id_ProductoVerificable == 59) || (DMI.Id_ProductoVerificable == 60))
                {
                    tblRegistro.Visible = true;                    
                    procesos.LLenarComboT(CboTipoRegistro, "SELECT Id_TipoRegistro Id,Descripcion  FROM Tipo_Registro_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 54) 
                {
                    tblRegistro.Visible = true;
                    tblTipoActa.Visible = true;                    
                    Lbltitulo2.Text = "Descripción de Anomalía";
                    procesos.LLenarComboT(CboTipoRegistro, "SELECT Id_TipoRegistro Id,Descripcion  FROM Tipo_Registro_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboTipoActa, "SELECT Id_TipoActa Id,Descripcion FROM Tipo_Acta_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 55) 
                {                                        
                    tblEmpresa.Visible = true;
                    tblProductoEspecie.Visible = true;
                    txttipoProducto.Visible = true;
                    Label15.Visible = true;
                    tblpais.Visible = true;
                    procesos.LLenarComboT(cboEspecie, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboPais, "SELECT Id_Pais Id,Descripcion FROM Pais_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Label61.Text = "Nombre de la Empresa Exportadora";
                    Label62.Text = "Número de Registro del EXIM";
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 56)
                {
                    tblRegistro.Visible = true;                    
                    tblErrorAnomalia.Visible = true;                     
                    Lbltitulo2.Text = "Tipo de Error Registrado";
                    procesos.LLenarComboT(CboTipoRegistro, "SELECT Id_TipoRegistro Id,Descripcion  FROM Tipo_Registro_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 57) 
                {
                    TblEstado.Visible = false;
                    procesos.LLenarComboT(CboEstado, "SELECT Id_Estado Id,Descripcion  FROM Tipo_Estado_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboTipoAccion, "SELECT Id_Accion Id,Descripcion  FROM Tipo_Accion_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(cboTipoIncumplimiento, "SELECT Id_Incumplimiento Id,Descripcion FROM Tipo_Incumplimiento_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 58)
                {
                    tblRegistro.Visible = true;
                    tblSeRNAFActivado.Visible = true;                    
                    procesos.LLenarComboT(CboReactivaSeinef, "SELECT Id_Respuesta Id,Descripcion FROM Respuesta_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboTipoRegistro, "SELECT Id_TipoRegistro Id,Descripcion  FROM Tipo_Registro_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 53) 
                {
                    tblEstadoTipoAccion.Visible = true;
                    procesos.LLenarComboT(CboTipoAccion, "SELECT Id_Accion Id,Descripcion  FROM Tipo_Accion_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(cboTipoIncumplimiento, "SELECT Id_Incumplimiento Id,Descripcion FROM Tipo_Incumplimiento_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 61) 
                {
                    tblEmpresa.Visible = true;
                    Label61.Text = "Nombre Comercial";
                    Label62.Text = "Número del RNF";
                    Label15.Text = "Producto";
                    tblProductoEspecie.Visible = true;
                    txttipoProducto.Visible = true;
                    Label15.Visible = true;
                    procesos.LLenarComboT(cboEspecie, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((DMI.Id_ProductoVerificable == 62)|| (DMI.Id_ProductoVerificable==273)) 
                { 
                    Guardar.Visible = true; 
                }
                if (DMI.Id_ProductoVerificable == 64) 
                {
                    tblexistenciacoberturaF1.Visible = true;
                    procesos.LLenarComboT(CboExistenciaCobertura, "SELECT Id_Respuesta Id,Descripcion  FROM Respuesta_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 65) 
                {
                    tblexistenciacoberturaF.Visible = true;
                    procesos.LLenarComboT(CboTipoCoberturaForestal, "SELECT Id_CoberturaF Id,Descripcion FROM Cobertura_Forestal_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 66) 
                {
                    tblProductoEspecie.Visible = true;
                    txttipoProducto.Visible = true;
                    Label15.Visible = true;
                    Label15.Text = "Tipo de Producto";
                    procesos.LLenarComboT(cboEspecie, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (DMI.Id_ProductoVerificable == 67) 
                {
                    tblProductoEspecie.Visible = true;
                    txttipoProducto.Visible = false;
                    Label15.Visible = false;
                    procesos.LLenarComboT(cboEspecie, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }                  
                RecargarGrid();
                LimpiarArchivo();
            }
        }
        protected void Inicializar() 
        {
            CboTipoRegistro.ClearSelection();
            txtNumeroRegistro.Text = string.Empty;
            CboTipoActa.ClearSelection();
            txtErrorAnomalia.Text = string.Empty;
            CboReactivaSeinef.ClearSelection();
            txttipoProducto.Text = string.Empty;
            cboEspecie.ClearSelection();
            CboPais.ClearSelection();
            CboEstado.ClearSelection();
            CboTipoAccion.ClearSelection();
            cboTipoIncumplimiento.ClearSelection();
            CboExistenciaCobertura.ClearSelection();
            CboTipoCoberturaForestal.ClearSelection();                                                                                                                                            
             txtempresa.Text = string.Empty;
            txtNumeroExim.Text = string.Empty;
        }
        protected void Ocultar() 
        {
            tblErrorAnomalia.Visible = false;
            tblRegistro.Visible = false;
            tblTipoActa.Visible = false;
            tblEmpresa.Visible = false;
            tblProductoEspecie.Visible = false;
            tblEstadoTipoAccion.Visible = false;
            TblEstado.Visible = false;
            tblSeRNAFActivado.Visible = false;
            tblEstadoTipoAccion.Visible = false;
            tblpais.Visible = false;
            tblexistenciacoberturaF.Visible = false;
            tblexistenciacoberturaF1.Visible = false;
            Inicializar();            
        }
        public Validar_Data Verificar_VaciosSalida()
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();           

            if (VPC.ShowHideProductoFisca(DMI.Id_ProductoVerificable,1) == true)
            {
                if (Mim.Validad_Llenado_detalle(1, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Rendimiento.<br/>";
                }
            }
            if (VPC.ShowHideProductoFisca(DMI.Id_ProductoVerificable,2) == true)
            {
                if (Mim.Validad_Llenado_detalle(2, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Comunidad Lenguistica.<br/>";
                }
                if (Mim.Validad_Llenado_detalle(3, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Grupo Etario.<br/>";
                }
            }                        
            return v;
        }
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalida();
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                cboDepartamento.ClearSelection();
                cboMunicipio.ClearSelection();
                txtFecha.Clear();
                GrdProductos.Visible = true;
                subcomp.Visible = true;
                Informacion.Visible = false;
                cboMunicipio.Items.Clear();
                txtObservaciones.Text = string.Empty;
                Ocultar();
            }
        }
        protected void FillCampos()
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            lblPoa.Text = DMI.NombrePOA;
            lblComponente.Text = DMI.Descripcion_Componente;
            lbsubregion.Text = DMI.Nombre_SubRegion;
            Lblmes.Text = DMI.Descripcion_mes;
            DMI.Id_SubComponente = 0;          
            procesos.LLenarComboT(CboSubcomponente, CadenaSql(1, 0), "Descripcion", "Id", true);
            CboSubcomponente.SelectedIndex = 0;
            DMI.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente);           
            GrdProductos.Rebind();
            Informacion.Visible = false;
            subcomp.Visible = true;
            procesos.LLenarComboT(cboDepartamento, Mim.CadenaComboDeptoMuni("", DMI.Id_Subregion.ToString(), 1), "Descripcion", "Id", true);
            Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
        }
        protected void GrdIngresoEncabezado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 2 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;

            procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
        }
        protected void Inicializacion_Objetos()
        {
            btnCerrarVentana.Click += new EventHandler(BtnCerrarVentana_Click);
            btnIrConfiguracion.Click += new EventHandler(BtnIrConfiguracion_Click);
            CerraVentana.Click += new EventHandler(CerraVentana_Click);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            btnFinalizarIngreso.Click += new EventHandler(BtnFinalizarIngreso_Click);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GrdProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GrdProductos_NeedDataSource);
            GrdProductos.ItemCommand += new GridCommandEventHandler(Seleccionar_Productos);
            CancelarIngreso.Click += new EventHandler(CancelarIngreso_Click);
            cboDepartamento.TextChanged += new EventHandler(CboDepartamento_TextChanged);
            CboTipoActa.TextChanged += new EventHandler(CboTipoActa_TextChanged);
            Guardar.Click += new EventHandler(Guardar_Click);
            GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);
            GrdIngresoEncabezado.DeleteCommand += new GridCommandEventHandler(Eliminar_Items);                       
            /*Extra*/
            BtnRegresarModulo1.Click += new EventHandler(BtnRegresarModulo1_Click);
            BtnGuardarRendimiento.Click += new EventHandler(BtnGuardarRendimiento_Click);
            GrdRendimiento.NeedDataSource += new GridNeedDataSourceEventHandler(GrdRendimiento_NeedDataSource);
            GrdRendimiento.PreRender += new EventHandler(GrdRendimiento_PreRender);
            GrdRendimiento.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdRendimiento);

            BtnRegresarModulo3.Click += new EventHandler(BtnRegresarModulo3_Click);
            CboComunidadL.TextChanged += new EventHandler(CboComunidadL_TextChanged);
            BtnGuardarComunidadL.Click += new EventHandler(BtnGuardarComunidadL_Click);
            GrdComunidadL.NeedDataSource += new GridNeedDataSourceEventHandler(GrdComunidadL_NeedDataSource);
            GrdComunidadL.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdComunidadL);
            GrdComunidadL.PreRender += new EventHandler(GrdComunidadL_PreRender);

            BtnRegresarModulo2.Click += new EventHandler(BtnRegresarModulo2_Click);
            CboGrupoEtario.TextChanged += new EventHandler(CboGrupoEtario_TextChanged);
            BtnGuardarGrupoEtario.Click += new EventHandler(BtnGuardarGrupoEtario_Click);
            GrdPertencia.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPertencia_NeedDataSource);
            GrdPertencia.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdPertencia);
            GrdPertencia.PreRender += new EventHandler(GrdPertencia_PreRender);
            RadDocumentoVerificacion.FileUploaded += new FileUploadedEventHandler(RadDocumentoVerificacion_FileUploaded);
        }
        protected void RadDocumentoVerificacion_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            Session["CargaDocumento"] = RadDocumentoVerificacion;
            Lblarchivo.Text = @"Archivo Esta Precargado";
        }
        private void Limpiar_IngresoUM()
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();

            if (xdata.Tipo_conteo(DMI.Id_UM1) != 1)
            {
                txtum1.Text = string.Empty;
            }
            if (xdata.Tipo_conteo(DMI.Id_UM2) != 1)
            {
                txtum2.Text = string.Empty;
            }
            if (xdata.Tipo_conteo(DMI.Id_UM3) != 1)
            {
                txtum3.Text = string.Empty;
            }
        }       
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoFiscalizacionIngreso Generico = new EncabezadoFiscalizacionIngreso();           
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Medios DA;
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
           
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Departamento = procesos.IntNULLCombo(cboDepartamento);
            Generico.Id_Municipio = procesos.IntNULLCombo(cboMunicipio);
            Generico.Id_Mes = DMI.Id_Mes;
            Generico.Id_UM1 = DMI.Id_UM1;
            Generico.Id_UM2 = DMI.Id_UM2;
            Generico.Id_UM3 = DMI.Id_UM3;
            Generico.ValorUM1 = procesos.DecimalRadNumericTextBox(txtum1);
            Generico.ValorUM2 = procesos.DecimalRadNumericTextBox(txtum2);
            Generico.ValorUM3 = procesos.DecimalRadNumericTextBox(txtum3);
            Generico.Fecha = procesos.Fechas(txtFecha);
            Generico.Observaciones = txtObservaciones.Text.ToString();
            Generico.Id_usu = DMI.Id_Usuario;
            /*extra*/
            Generico.Id_TipoDeRegistro = procesos.IntNULLCombo(CboTipoRegistro);
            Generico.NumeroDeRegistro = txtNumeroRegistro.Text.ToUpper().ToString();  
            Generico.ErroresAnomalias = txtErrorAnomalia.Text.ToString();
            Generico.Id_ReactivaSeinef = procesos.IntNULLCombo(CboReactivaSeinef);
            Generico.Id_TipoDeActa = procesos.IntNULLCombo(CboTipoActa);
            Generico.Tipo_Producto = txttipoProducto.Text.ToString();
            Generico.Id_Especie = procesos.IntNULLCombo(cboEspecie);
            Generico.Id_Pais = procesos.IntNULLCombo(CboPais);
            Generico.Id_Estado = procesos.IntNULLCombo(CboEstado);
            Generico.Id_TipoAccion = procesos.IntNULLCombo(CboTipoAccion);
            Generico.Id_TipoIncumplimiento = procesos.IntNULLCombo(cboTipoIncumplimiento);
            Generico.Id_ExistenciaCobertura = procesos.IntNULLCombo(CboExistenciaCobertura);
            Generico.Id_TipoCobertura = procesos.IntNULLCombo(CboTipoCoberturaForestal);
            Generico.NombreEmpresa = txtempresa.Text.ToString();
            Generico.RegistroExim = txtNumeroExim.Text.ToString();  
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];

            string Mantenimiento;
            if (Session["Mantenimiento"] == "True")
            {
                Mantenimiento = "True";
            }
            else
            {
                Mantenimiento = "False";
            }

            v = Validar.Campos_Obligatorio_FiscalizacionyControl(Generico, RadDocumentoVerificacion, DMI, Mantenimiento);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                //CR  agregar fecha y hora para concatenarselo al nombre del documento que se va a subir
                string FechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                DA = Mim.SubirPDF(DMI, RadDocumentoVerificacion, FechaHora);
                Generico.MedioDeVerificacion = DA.Medio_Local;
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoFicalizacion(Generico);

                if (Mim.GuardarItemEncabezado(2,DMI, DescripcionProducto, ref er))
                {
                     foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                     {

                       // f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);

                        f.SaveAs(DA.Medio_Subir, true);


                     }
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    Inicializar();
                    LimpiarArchivo();
                    cboMunicipio.ClearSelection();
                    txtObservaciones.Text = string.Empty;
                    txtFecha.Clear();
                }
                else
                {
                   MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void LimpiarArchivo()
        {
            RadAsyncUpload Arch = new RadAsyncUpload();
            Lblarchivo.Text = string.Empty;
            RadDocumentoVerificacion.Dispose();
            Session["CargaDocumento"] = Arch;
        }
        private void RecargarGrid()
        {
            GrdIngresoEncabezado.Rebind();
            if (GrdIngresoEncabezado.Items.Count == 0)
            {
                GrdIngresoEncabezado.Visible = false;
            }
            else
            {
                GrdIngresoEncabezado.Visible = true;
            }
        }
        protected void Eliminar_Items(object source, GridCommandEventArgs e)
        {

            GridDataItem item = e.Item as GridDataItem;
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            EliminacionDatoMonitoreo edm = new EliminacionDatoMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();

            edm.Correlativo = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
            edm.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
            edm.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
            edm.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
            edm.Id_usu = Convert.ToInt32(Session["Usuario"].ToString());
            edm.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());            
                                       
            if (Mim.Eliminar_MedioVerificacionFisico(item.GetDataKeyValue("MedioDeVerificacion").ToString()) == false)
            {
                if (Mim.Eliminacion_Producto(2,edm, ref er))
                {
                    RecargarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }                               
        }
        protected void GrdIngresoEncabezado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;                               
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;                
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;                
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonB").Display = VPC.ShowHideProductoFisca(Producto,1);                
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoFisca(Producto,2);
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoFisca(Producto,2);
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void Seleccionar_Items(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;               
            }
            if (e.CommandName == "Select1")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                DRendimiento.Visible = true;
                procesos.LLenarComboT(CboEspecieDetalle, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargaRendimiento();
                Llave = 1;                
            }
            if (e.CommandName == "Select2")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                Etario.Visible = true;
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                procesos.LLenarComboT(CboGenero, "SELECT Id_Genero Id,Descripcion FROM Genero_monitoreo WHERE Estado =1;", "Descripcion", "Id", true);
                procesos.LLenarComboT(CboPertenecia, "SELECT Id_pertenencia Id,Descripcion FROM Pertencia_Monitoreo WHERE Estado =1;", "Descripcion", "Id", true);
                procesos.LLenarComboT(CboGrupoEtario, "SELECT Id_GrupoEtario Id,Descripcion FROM Grupo_Etario_Monitoreo WHERE Estado =1;", "Descripcion", "Id", true);
                RecargaPertenencia();
                Llave = 1;
            }
            if (e.CommandName == "Select3")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                ComunidadL.Visible = true;
                procesos.LLenarComboT(CboComunidadL, "SELECT Id_Comunidad Id, Descripcion FROM Comunidad_Linguistica_monitoreo WHERE Estado = 1; ", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Comunidad();
                Llave = 1;
            }
            if (e.CommandName == "Delete") { Llave = 1; }
            
            if (Llave == 0)
            {
                tblEspecie.Visible = false;
                tblRegistros.Visible = false;
                tblTipoActas.Visible = false;
                tblempresas.Visible = false;
                tblEspecie.Visible = false;
                tbltipoProducto.Visible = false;
                tblpaisdestino.Visible = false;
                tblanomalias.Visible = false;
                tblsernaf.Visible = false;
                tblAccion.Visible = false;
                tblIncumplimiento.Visible = false;
                tblEstados.Visible = false;
                tbltipocobertura.Visible = false;
                tblexistenciaForestal.Visible = false;

                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());                          
                TblFechas.Visible = true;               
                tblObervaciones.Visible = true;
                LObservas.Text = item.GetDataKeyValue("Observaciones").ToString();
                Lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                if (Producto == 52)
                {                    
                    LblRegistro.Text = item.GetDataKeyValue("Registro2").ToString();
                    lblNumeroRegistro.Text = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                }
                if ((Producto == 51) || (Producto == 53) || (Producto == 60))
                {
                    tblRegistros.Visible = true;
                    LblRegistro.Text = item.GetDataKeyValue("Registro").ToString();
                    lblNumeroRegistro.Text = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                }
                if (Producto == 54)
                {                    
                    tblRegistros.Visible = true;
                    tblTipoActas.Visible = true;                   
                    LblRegistro.Text = item.GetDataKeyValue("Registro").ToString();
                    lblNumeroRegistro.Text = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    LblActa.Text = item.GetDataKeyValue("Acta").ToString();
                    
                    if(item.GetDataKeyValue("Acta").ToString() == "Con Anomalia") 
                    {
                        Label42.Text = "Descripción de Anomalia:";
                        tblanomalias.Visible = true;
                        LblAnomalia.Text = item.GetDataKeyValue("ErroresAnomalias").ToString();
                    }                    
                }
                if (Producto == 55)
                {
                    tblempresas.Visible = true;
                    tblEspecie.Visible = true;
                    tbltipoProducto.Visible = true;
                    tblpaisdestino.Visible = true;
                    Label63.Text = "Nombre Empresa Exportadora:";
                    Label64.Text = "Número de Registro del Exim:";
                    Label43.Text = "Tipo de Producto:";
                    LblEmpresa.Text = item.GetDataKeyValue("NombreEmpresa").ToString();
                    Lbleximnumero.Text = item.GetDataKeyValue("RegistroExim").ToString();
                    LblEspecie.Text = item.GetDataKeyValue("Especie").ToString();
                    LblProducto.Text = item.GetDataKeyValue("Tipo_Producto").ToString();
                    Lblpais.Text = item.GetDataKeyValue("Pais").ToString();
                }
                if (Producto == 56)
                {
                    tblRegistros.Visible = true;
                    tblanomalias.Visible = true;
                    LblRegistro.Text = item.GetDataKeyValue("Registro").ToString();
                    lblNumeroRegistro.Text = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    Label42.Text = "Tipo de Error Registrado:";                   
                    LblAnomalia.Text = item.GetDataKeyValue("ErroresAnomalias").ToString();
                }
                if (Producto == 57)
                {
                    tblEstados.Visible = true;
                    LblEstado.Text = item.GetDataKeyValue("Estado").ToString();
                }
                if (Producto == 58)
                {
                    tblRegistros.Visible = true;
                    tblsernaf.Visible = true;
                    LblRegistro.Text = item.GetDataKeyValue("Registro").ToString();
                    lblNumeroRegistro.Text = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    LblSeinef.Text = item.GetDataKeyValue("Seinef").ToString();
                }
                if (Producto == 59)
                {
                    tblAccion.Visible = true;
                    tblIncumplimiento.Visible = true;
                    LblAccion.Text = item.GetDataKeyValue("Accion").ToString();
                    LblIncumplimiento.Text = item.GetDataKeyValue("Incumplimiento").ToString();
                }
                if (Producto == 61)
                {
                    tblempresas.Visible = true;
                    tblEspecie.Visible = true;
                    tbltipoProducto.Visible = true;
                    Label63.Text = "Nombre Comercial:";
                    Label64.Text = "Número del RNF:";
                    Label43.Text = "Producto:";
                    LblEmpresa.Text = item.GetDataKeyValue("NombreEmpresa").ToString();
                    Lbleximnumero.Text = item.GetDataKeyValue("RegistroExim").ToString();
                    LblEspecie.Text = item.GetDataKeyValue("Especie").ToString();
                    LblProducto.Text = item.GetDataKeyValue("Tipo_Producto").ToString();
                }
                if (Producto == 62) { }
                if (Producto == 64)
                {
                    tblexistenciaForestal.Visible = true;
                    LblExistenciaCF.Text = item.GetDataKeyValue("Existencia").ToString();
                }
                if (Producto == 65)
                {
                    tbltipocobertura.Visible = true;
                    LblCoberturaF.Text = item.GetDataKeyValue("Cobertura").ToString();
                }
                if (Producto == 66)
                {
                    tblEspecie.Visible = true;
                    tbltipoProducto.Visible = true;
                    Label43.Text = "Tipo de Producto:";
                    LblEspecie.Text = item.GetDataKeyValue("Especie").ToString();
                    LblProducto.Text = item.GetDataKeyValue("Tipo_Producto").ToString();
                }
                if (Producto == 67)
                {
                    tblEspecie.Visible = true;
                    LblEspecie.Text = item.GetDataKeyValue("Especie").ToString();
                }
                OpenWinwdows(VerDatosExtra, "520", "550", "Key", "Información Adicional del Ingresos");
            }            
        }
        protected void Comunidad() 
        {
            GrdComunidadL.Rebind();
            if (GrdComunidadL.Items.Count == 0)
            {
                GrdComunidadL.Visible = false;
            }
            else
            {
                GrdComunidadL.Visible = true;
            }
        }
        protected void RecargaPertenencia() 
        {
            GrdPertencia.Rebind();
            if (GrdPertencia.Items.Count == 0)
            {
                GrdPertencia.Visible = false;
            }
            else
            {
                GrdPertencia.Visible = true;
            }
        }
        protected void RecargaRendimiento() 
        {
            GrdRendimiento.Rebind();
            if (GrdRendimiento.Items.Count == 0)
            {
                GrdRendimiento.Visible = false;
            }
            else
            {
                GrdRendimiento.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            Inicializacion_Objetos();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 70).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();                
            }
        }
        protected void GrdRendimiento_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 3 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdRendimiento, CadenaSql);
        }
        private void GrdRendimiento_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdRendimiento.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Especie"].Text == gridDataItem3["Id_Especie"].Text)
                    {
                        gridDataItem2["Especie"].RowSpan = gridDataItem3["Especie"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Especie"].RowSpan + 1;
                        gridDataItem3["Especie"].Visible = false;
                    }
                    if (gridDataItem2["Maquinaria"].Text == gridDataItem3["Maquinaria"].Text)
                    {
                        gridDataItem2["Maquinaria"].RowSpan = gridDataItem3["Maquinaria"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Maquinaria"].RowSpan + 1;
                        gridDataItem3["Maquinaria"].Visible = false;
                    }                    
                }
            }
        }
        protected void BtnRegresarModulo1_Click(object sender, EventArgs e) 
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            DRendimiento.Visible = false;
            CboEspecieDetalle.ClearSelection();
            txtMaquinaria.Text = string.Empty;
            txtMadera.Text = string.Empty;
            txtLepa.Text = string.Empty;
            txtAserrio.Text = string.Empty;
            txtOtro.Text = string.Empty;
        }        
        protected void BtnGuardarRendimiento_Click(object sender, EventArgs e)
        {
            FiscalizacionDatos1 Generico = new FiscalizacionDatos1();
            ValidarCamposObligatoriosMonitoreo X = new ValidarCamposObligatoriosMonitoreo();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            Generico.CorrelativoPadre = Convert.ToInt32(Session["Padre"].ToString());
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Mes = DMI.Id_Mes;            
            Generico.Maquinaria = txtMaquinaria.Text.ToString().ToUpper(); 
            Generico.Id_Especie = procesos.IntNULLCombo(CboEspecieDetalle);
            Generico.PorcentajeMaderaAserrada = procesos.DecimalRadNumericTextBox(txtMadera);
            Generico.PorcentajeLepa = procesos.DecimalRadNumericTextBox(txtLepa);
            Generico.PorcentajeAserrio = procesos.DecimalRadNumericTextBox(txtAserrio);
            Generico.PorcentajeOtro = procesos.DecimalRadNumericTextBox(txtOtro);

            v = X.Verificar_VaciosRendimiento(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoFiscalizacionDatos1(Generico);
                if (Mim.GuardarItemDetalle(3, DMI, DescripcionProducto, ref er))
                {
                    RecargaRendimiento();
                    txtMadera.Text = string.Empty; 
                    txtLepa.Text = string.Empty;
                    txtAserrio.Text = string.Empty;
                    txtOtro.Text = string.Empty;
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Eliminar_ItemsGrdRendimiento(object source, GridCommandEventArgs e)
        {

            GridDataItem item = e.Item as GridDataItem;
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            EliminacionDatoMonitoreo edm = new EliminacionDatoMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            edm.Correlativo = Convert.ToInt32(item.GetDataKeyValue("CorrelativoHijo").ToString());
            edm.Id_PoAnual = DMI.Id_PoAnual;
            edm.Id_Subregion = DMI.Id_Subregion;
            edm.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
            edm.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());

            if (Mim.Eliminacion_DatosExtra(3, edm, ref er))
            {
                RecargaRendimiento();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }            
        }
        /**/
        private void CboComunidadL_TextChanged(object sender, EventArgs e)
        {
            TxtNumeroPersonasComunidad.ReadOnly = false;
            TxtNumeroPersonasComunidad.Text = string.Empty;
        }
        protected void BtnRegresarModulo3_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalidaDetalle(4);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                Encabezado.Visible = true;
                GrdIngresoEncabezado.Visible = true;
                ComunidadL.Visible = false;
                CboComunidadL.ClearSelection();
                TxtNumeroPersonasComunidad.Text = string.Empty;
                TxtNumeroPersonasComunidad.ReadOnly = true;
            }           
        }       
        protected void BtnGuardarComunidadL_Click(object sender, EventArgs e)
        {
            FiscalizacionDatos2 Generico = new FiscalizacionDatos2();
            ValidarCamposObligatoriosMonitoreo X = new ValidarCamposObligatoriosMonitoreo();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            Generico.CorrelativoPadre = Convert.ToInt32(Session["Padre"].ToString());
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Mes = DMI.Id_Mes;
            Generico.Id_Comunidad = procesos.IntNULLCombo(CboComunidadL);            
            Generico.NumeroPersonas = procesos.STRRadNumericTextBox(TxtNumeroPersonasComunidad);

            v = X.Verificar_VaciosComunidadL(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoFiscalizacionDatos2(Generico);
                if (Mim.GuardarItemDetalle(5, DMI, DescripcionProducto, ref er))
                {
                    Comunidad();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void GrdComunidadL_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 5 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdComunidadL, CadenaSql);
        }
        protected void Eliminar_ItemsGrdComunidadL(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            EliminacionDatoMonitoreo edm = new EliminacionDatoMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            edm.Correlativo = Convert.ToInt32(item.GetDataKeyValue("CorrelativoHijo").ToString());
            edm.Id_PoAnual = DMI.Id_PoAnual;
            edm.Id_Subregion = DMI.Id_Subregion;
            edm.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
            edm.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());

            if (Mim.Eliminacion_DatosExtra(5, edm, ref er))
            {
                Comunidad();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }            
        }
        private void GrdComunidadL_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdComunidadL.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Comunidad"].Text == gridDataItem3["Id_Comunidad"].Text)
                    {
                        gridDataItem2["Comunidad"].RowSpan = gridDataItem3["Comunidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Comunidad"].RowSpan + 1;
                        gridDataItem3["Comunidad"].Visible = false;
                    }                   
                }
            }
        }
        /**/
        public Validar_Data Verificar_VaciosSalidaDetalle(int ID)
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            int Cantidad = Mim.Validad_Llenado_detalleCantidad(ID, DMI,Convert.ToInt32(Session["Padre"].ToString()));

            if (Cantidad != 0)
            {
                v.Verificar = true; v.Mensaje += "La Cantidad de Personas Debe ser " + Cantidad + ".<br/>";
            }
            return v;
        }
        private void CboGrupoEtario_TextChanged(object sender, EventArgs e)
        {
            txtNumeroPersonasEtario.ReadOnly = false;
            txtNumeroPersonasEtario.Text = string.Empty;
        }
        protected void BtnRegresarModulo2_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalidaDetalle(3);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                Encabezado.Visible = true;
                GrdIngresoEncabezado.Visible = true;
                Etario.Visible = false;
                CboGenero.ClearSelection();
                CboPertenecia.ClearSelection();
                CboGrupoEtario.ClearSelection();
                txtNumeroPersonasEtario.Text = string.Empty;
                txtNumeroPersonasEtario.ReadOnly = true;
            }            
        }
        protected void GrdPertencia_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 4 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPertencia, CadenaSql);
        }
        private void GrdPertencia_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPertencia.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Genero"].Text == gridDataItem3["Id_Genero"].Text)
                    {
                        gridDataItem2["Sexo"].RowSpan = gridDataItem3["Sexo"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Sexo"].RowSpan + 1;
                        gridDataItem3["Sexo"].Visible = false;
                    }

                    if (gridDataItem2["Id_pertenencia"].Text == gridDataItem3["Id_pertenencia"].Text)
                    {
                        gridDataItem2["Pertenecia"].RowSpan = gridDataItem3["Pertenecia"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Pertenecia"].RowSpan + 1;
                        gridDataItem3["Pertenecia"].Visible = false;
                    }
                    if (gridDataItem2["Id_GrupoEtario"].Text == gridDataItem3["Id_GrupoEtario"].Text)
                    {
                        gridDataItem2["Etario"].RowSpan = gridDataItem3["Etario"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Etario"].RowSpan + 1;
                        gridDataItem3["Etario"].Visible = false;
                    }
                }
            }
        }        
        protected void BtnGuardarGrupoEtario_Click(object sender, EventArgs e)
        {
            CapacitacionDatos2 Generico = new CapacitacionDatos2();
            ValidarCamposObligatoriosMonitoreo X = new ValidarCamposObligatoriosMonitoreo();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            Generico.CorrelativoPadre = Convert.ToInt32(Session["Padre"].ToString());
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Mes = DMI.Id_Mes;
            Generico.Id_Genero = procesos.IntNULLCombo(CboGenero);
            Generico.Id_pertenencia = procesos.IntNULLCombo(CboPertenecia);
            Generico.Id_GrupoEtario = procesos.IntNULLCombo(CboGrupoEtario);
            Generico.NumeroPersonaEtario = procesos.STRRadNumericTextBox(txtNumeroPersonasEtario);

            v = X.Verificar_VaciosD2(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCapacitacionD2(Generico);
                if (Mim.GuardarItemDetalle(4, DMI, DescripcionProducto, ref er))
                {
                    RecargaPertenencia();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Eliminar_ItemsGrdPertencia(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            EliminacionDatoMonitoreo edm = new EliminacionDatoMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            edm.Correlativo = Convert.ToInt32(item.GetDataKeyValue("CorrelativoHijo").ToString());
            edm.Id_PoAnual = DMI.Id_PoAnual;
            edm.Id_Subregion = DMI.Id_Subregion;
            edm.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
            edm.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());

            if (Mim.Eliminacion_DatosExtra(4, edm, ref er))
            {
                RecargaPertenencia();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }            
        }
        /*manejo de ventanas*/
        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
        protected void CloseWinwdows(RadWindow Ventana, string Llave)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").close();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
    }
}