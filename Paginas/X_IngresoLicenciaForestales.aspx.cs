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
    public partial class X_IngresoLincenciaForestales : System.Web.UI.Page
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
        private void CboDepartamento_TextChanged(object sender, EventArgs e)
        {
            cboMunicipio.ClearSelection();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
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
                observa.Visible = true;
                t1.Visible = false;
                t2.Visible = false;
                tmes.Visible = false;
                Resp0.Visible = false;
                Resp1.Visible = false;
                Resp2.Visible = false;
                Resp3.Visible = false;
                Resp4.Visible = false;
                Resp5.Visible = false;
                Guardar.Visible = false; 

                if (Producto == 104) 
                {
                    observa.Visible = true; 
                    t1.Visible = false;
                    t2.Visible = false;
                    tmes.Visible = true;
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    Guardar.Visible = true;
                }
                if (Producto == 113)
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp0.Visible = true;
                    Resp1.Visible = true;
                    lbltituloresol.Text = "Número de Resolución";
                    procesos.LLenarComboT(CboTipoModificacion, "SELECT Id_TipoDeModificacion Id,Descripcion_Control Descripcion FROM Tipo_ModificacionLicencia", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 105)
                {
                    observa.Visible = true;
                    t1.Visible = false;
                    t2.Visible = false;
                    tmes.Visible = true;
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    Guardar.Visible = true;
                }
                if ((Producto == 108) || (Producto == 111) || (Producto == 110) || 
                    (Producto == 107) || (Producto == 109) || (Producto == 112)) 
                {
                    observa.Visible = true;
                    t1.Visible = false;
                    t2.Visible = false;                   
                    tmes.Visible = true;
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    Guardar.Visible = true;
                }
                if ((Producto == 253) || (Producto == 254))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp0.Visible = true;
                    Resp2.Visible = true;
                    Resp5.Visible = true;
                    lbltituloresol.Text = "Número de Informe Trimestral";
                    procesos.LLenarComboT(CboTipoBosque, "SELECT Id_Tipo_Bosque Id,Descripcion FROM Tipo_Bosque WHERE Estado = 1 AND Licencia = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(cboTratamiento, "SELECT Id_Tratamiento Id,Descripcion FROM Tipo_Tratamiento WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 259) || (Producto == 261)|| (Producto == 270)|| (Producto == 270)|| (Producto == 306))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp4.Visible = true;
                    Resp0.Visible = true;
                    Label30.Visible = false;
                    Label31.Visible = false;
                    txtEspecie.Visible = false;
                    cboTratamiento.Visible = false;
                    lbltituloresol.Text = "Número de Resolución";
                    procesos.LLenarComboT(cboTratamiento, "SELECT Id_Tratamiento Id,Descripcion FROM Tipo_Tratamiento WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 106) || (Producto == 114) || 
                 (Producto == 115) || (Producto == 116)|| (Producto == 257)|| (Producto == 258)|| (Producto == 268)|| (Producto == 269)|| (Producto == 271))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp0.Visible = true;
                    Resp2.Visible = true;
                    Resp3.Visible = true;
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    lbltituloresol.Text = "Número de Resolución";
                    procesos.LLenarComboT(CboTipoBosque, "SELECT Id_Tipo_Bosque Id,Descripcion FROM Tipo_Bosque WHERE Estado = 1 AND Licencia = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboTipoLicencia, "SELECT Id_Tipo_Licencia Id,Descripcion FROM Tipo_LicenciaForestalManejo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 117) || (Producto == 118) ||
                    (Producto == 119) || (Producto == 249))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp0.Visible = true;
                    lbltituloresol.Text = "Número de Resolución/de Dictamen";
                    Guardar.Visible = true;
                }
                if (Producto == 305)
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    Resp0.Visible = false;
                    Resp2.Visible = false;
                    Resp3.Visible = false;
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    
                    Guardar.Visible = true;
                }
                RecargarGrid();
                LimpiarArchivo();
            }
        }
        protected void Limp() 
        {
            txtnoResolucion.Text = string.Empty;
            txtExpediente.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            cboMunicipio.ClearSelection();
            CboTipoModificacion.ClearSelection();
            CboTipoLicencia.ClearSelection();
            CboTipoBosque.ClearSelection();
            txtFecha.Clear();
        }
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            Limp();
            cboDepartamento.ClearSelection();            
            GrdProductos.Visible = true;
            subcomp.Visible = true;
            Informacion.Visible = false;
            cboMunicipio.Items.Clear();                        
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


            if (cboMesIngreso.SelectedIndex < 0)
            {
                 string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 16 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                     + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;
                procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);

            }
            else
            {
                string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 16 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                 + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + cboMesIngreso.SelectedValue;
                procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
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
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoLicencia(Producto, 1);
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
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
            Guardar.Click += new EventHandler(Guardar_Click);
            GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);
            GrdIngresoEncabezado.DeleteCommand += new GridCommandEventHandler(Eliminar_Items);
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos,74).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoLicenciaForestal Generico = new EncabezadoLicenciaForestal();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejarApi mapi = new ManejarApi();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Medios DA = new Medios();
            EnvioDatosApi Edapi = new EnvioDatosApi();
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Departamento = procesos.IntNULLCombo(cboDepartamento);
            Generico.Id_Municipio = procesos.IntNULLCombo(cboMunicipio);
            Generico.Id_Mes = Mim.ValorDelMes(cboMesIngreso, DMI.Id_Mes);
            Generico.Id_UM1 = DMI.Id_UM1;
            Generico.Id_UM2 = DMI.Id_UM2;
            Generico.Id_UM3 = DMI.Id_UM3;
            Generico.ValorUM1 = procesos.DecimalRadNumericTextBox(txtum1);
            Generico.ValorUM2 = procesos.DecimalRadNumericTextBox(txtum2);
            Generico.ValorUM3 = procesos.DecimalRadNumericTextBox(txtum3);
            Generico.Fecha = procesos.Fechas(txtFecha);
            Generico.Observaciones = txtObservaciones.Text.ToString();
            Generico.Id_usu = DMI.Id_Usuario;
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];
            Generico.NoExpediente = txtExpediente.Text.ToString();  
            Generico.NoResolucionInformePOATrimestral = txtnoResolucion.Text.ToString();
            Generico.Id_TipoDeModificacion = procesos.IntNULLCombo(CboTipoModificacion);
            Generico.Id_TipoLicencia = procesos.IntNULLCombo(CboTipoLicencia);
            Generico.Id_TipoDeBosque = procesos.IntNULLCombo(CboTipoBosque);
            Generico.NoLicencia = txtlicencia.Text.ToString();
            Generico.Hectarias = procesos.DecimalRadNumericTextBox(txtHectaria);
            Generico.Titular = txtTitular.Text.ToString();
            Generico.NoTelefono = procesos.STRRadNumericTextBox(txtNoTitular);
            Generico.CoordenadaX = procesos.DecimalRadNumericTextBox(txtCoordenadaX);
            Generico.CoordenadaY = procesos.DecimalRadNumericTextBox(txtCoordenadaY);
            Generico.Especie = txtEspecie.Text.ToString();
            Generico.Elaborador = txtElaborador.Text.ToString();
            Generico.NoTelefonoElabora = procesos.STRRadNumericTextBox(txtNoElaborador);
            Generico.Id_Tratamiento = procesos.IntNULLCombo(cboTratamiento);

            //CR  agregar fecha y hora para concatenarselo al nombre del documento que se va a subir
            string FechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            

            string Mantenimiento;
            if (Session["Mantenimiento"] == "True")
            {
                Mantenimiento = "True";
            }
            else
            {
                Mantenimiento = "False";
            }


            v = Validar.Campos_Obligatorio_Licencia(Generico, RadDocumentoVerificacion, Mantenimiento);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProductoAPI = new XmlDocument();
                int Producto = DMI.Id_ProductoVerificable;
                if ((Producto == 104) || (Producto == 108) || (Producto == 111) ||
                    (Producto == 110) || (Producto == 107) || (Producto == 109) ||
                    (Producto == 112) || (Producto == 105)) 
                {
                    Generico.MedioDeVerificacion = string.Empty;
                    Edapi.Month = Generico.Id_Mes;
                    Edapi.Year = mapi.VerificarAnio(DMI.Id_PoAnual);

                    if(Producto == 104) 
                    {
                        DescripcionProductoAPI = mapi.ModificacionPOA(Edapi);
                    }
                    if (Producto == 105)
                    {
                        DescripcionProductoAPI = mapi.PlanesOperativos(Edapi);
                    }
                    if ((Producto == 108) || (Producto == 111) || (Producto == 110) || 
                        (Producto == 107) || (Producto == 109) || (Producto == 112)) 
                    {
                        DescripcionProductoAPI = mapi.LicenciasForestal(Edapi);
                    }
                }
                else
                {

                   

                    DA = Mim.SubirPDF(DMI, RadDocumentoVerificacion,FechaHora);
                    Generico.MedioDeVerificacion = DA.Medio_Local;
                }
                                
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoLicencia(Generico);
                if (Mim.GuardarItemEncabezadoApi(6, DMI, DescripcionProducto, DescripcionProductoAPI, ref er))
                {
                    if ((Producto != 104) || (Producto != 108) || (Producto != 111) ||
                        (Producto != 110) || (Producto != 107) || (Producto != 109) ||
                        (Producto != 112) || (Producto != 105))
                    {
                        foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                        {

                            //f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                            f.SaveAs(DA.Medio_Subir, true);
                        }
                    }
                    
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    LimpiarArchivo();
                    Limp();
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
                GrdIngresoEncabezado.Visible = true;
            
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
                if (Mim.Eliminacion_Producto(17, edm, ref er))
                {
                    RecargarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
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

            if (e.CommandName == "Delete") { Llave = 1; }

            if (Llave == 0)
            {
                x1.Visible = false;
                x2.Visible = false;
                x3.Visible = false;
                x4.Visible = false;
                x5.Visible = false;
                x6.Visible = false;
                x7.Visible = false;
                Table1.Visible = false;
                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();                
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 104)
                {
                    x1.Visible = true;                   
                    lblfecha.Text  = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text  = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text  = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución:";                   
                }
                if (Producto == 113)
                {
                    x1.Visible = true;
                    x2.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución:";
                    Lbltipomodifica.Text = item.GetDataKeyValue("TipoDeModificacion").ToString();
                    Table1.Visible = true;
                }
                if (Producto == 105)
                {
                    x3.Visible = true;
                    x4.Visible = true;
                    x1.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Resolución de POA:";
                    Lbltipolicencia.Text  = item.GetDataKeyValue("TipoLicencia").ToString();
                    Lbltipobosque.Text = item.GetDataKeyValue("TipoDeBosque").ToString();

                }
                if ((Producto == 108) || (Producto == 111) || (Producto == 110) ||
                    (Producto == 107) || (Producto == 109) || (Producto == 112))
                {
                    x1.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución:";                   
                }
                if ((Producto == 253) || (Producto == 254))
                {
                    Table1.Visible = true;
                    x1.Visible = true;
                    x5.Visible = true;
                    x4.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Informe Trimestral:";
                    Lbltipobosque.Text = item.GetDataKeyValue("TipoDeBosque").ToString();
                    Lbllicencia.Text = item.GetDataKeyValue("NoLicencia").ToString();
                    LblHectaria.Text = item.GetDataKeyValue("Hectarias").ToString();
                }
                if ((Producto == 259) || (Producto == 261))
                {
                    Table1.Visible = true;
                    x1.Visible = true;
                    x6.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución:";
                    Lbltitular.Text = item.GetDataKeyValue("Titular").ToString();
                    Lblnotitular.Text = item.GetDataKeyValue("NoTelefono").ToString();
                    LblElaborador.Text = item.GetDataKeyValue("Elaborador").ToString();
                    LblnoElaborador.Text = item.GetDataKeyValue("NoTelefonoElabora").ToString();
                    Lblespecie.Text = item.GetDataKeyValue("Especie").ToString();
                    Lbltratamiento.Text = item.GetDataKeyValue("Tratamiento").ToString();
                    LblCoordenadax.Text = item.GetDataKeyValue("CoordenadaX").ToString();
                    LblCoordenadaY.Text = item.GetDataKeyValue("CoordenadaY").ToString();
                }
                if ((Producto == 106) || (Producto == 114) ||
                 (Producto == 115) || (Producto == 116))
                {
                    x3.Visible = true;
                    x4.Visible = true;
                    Table1.Visible = true;
                    x1.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución:";
                    Lbltipolicencia.Text = item.GetDataKeyValue("TipoLicencia").ToString();
                    Lbltipobosque.Text = item.GetDataKeyValue("TipoDeBosque").ToString();
                }
                if ((Producto == 117) || (Producto == 118) ||
                    (Producto == 119) || (Producto == 249))
                {
                    Table1.Visible = true;
                    x1.Visible = true;
                    lblfecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    lbltitulo.Text = "Número de Resolución/ de Dictamen:";
                }
                OpenWinwdows(VerDatosExtra, "520", "600", "Key", "Información Adicional del Ingresos");
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