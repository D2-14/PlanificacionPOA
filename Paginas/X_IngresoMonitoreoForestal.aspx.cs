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
    public partial class X_IngresoMonitoreoForestal : System.Web.UI.Page
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 76).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
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
                t1.Visible = false;
                t2.Visible = false;
                t3.Visible = false;
                t4.Visible = false;
                t5.Visible = false;
                t6.Visible = false;
                t7.Visible = false;
                t8.Visible = false;
                t9.Visible = false;
                Coordenada.Visible = false;
                observa.Visible = false;
                fechat1.Visible = false;
                fechat2.Visible = false;
                tmes.Visible = false;
                Guardar.Visible = false;
                Label9.Visible = true;
                cboMunicipio.Visible = true;
                if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || 
                    (Producto == 131) || (Producto == 132) || (Producto == 133) || (Producto == 124)) 
                {
                    txtum2.Text = "0";
                    txtum2.ReadOnly = true;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    tmes.Visible = true;
                    Label9.Visible = false;
                    cboMunicipio.Visible = false;
                    procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    Guardar.Visible = true;
                    observa.Visible = true;
                }
                if ((Producto == 123) || (Producto == 134)) 
                {
                    observa.Visible = true;
                    fechat1.Visible = true;
                    fechat2.Visible = true;
                    LbltituloFecha.Text = "Fecha de Evaluación / Monitoreo";
                    lbledad.Text = "Edad";
                    lblInforme.Text = "Número de Informe";
                    lblfase.Text = "Fase Evaluada:";
                    t1.Visible = true;
                    t2.Visible = true;
                    t3.Visible = true;
                    t4.Visible = true;
                    t5.Visible = true;
                    t6.Visible = true;
                    t7.Visible = true;
                    t8.Visible = false;
                    t9.Visible = false;
                    Coordenada.Visible = false;                                                            
                    tmes.Visible = false;                   
                    procesos.LLenarComboT(cboTipoGarantia, "SELECT Id_Garantias Id,Descripcion FROM Tipo_Garantia_Monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ( (Producto == 142) ||
                     (Producto == 144) || (Producto == 145) || (Producto == 146))
                {
                    observa.Visible = true;
                    fechat1.Visible = true;
                    fechat2.Visible = true;
                    LbltituloFecha.Text = "Fecha de Monitoreo";
                    lbledad.Text = "Edad de plantación";
                    lblInforme.Text = "Número de Informe / Resolución";
                    t1.Visible = true;
                    t2.Visible = false;
                    t3.Visible = false;
                    t4.Visible = true;
                    t5.Visible = false;
                    t6.Visible = false;
                    t7.Visible = true;
                    t8.Visible = false;
                    t9.Visible = true;
                    Coordenada.Visible = false;
                    tmes.Visible = false;
                    Guardar.Visible = true;
                }

                if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) ||(Producto == 139) || (Producto == 143)|| (Producto == 140)|| (Producto == 272))
                {
                    observa.Visible = true;
                    fechat1.Visible = true;
                    fechat2.Visible = true;
                    LbltituloFecha.Text = "Fecha de Monitoreo";
                    lbledad.Text = "Edad de plantación";
                    lblInforme.Text = "Número de Informe / Resolución";
                    t1.Visible = true;
                    t2.Visible = false;
                    t3.Visible = false;
                    t4.Visible = false;
                    t5.Visible = false;
                    t6.Visible = false;
                    t7.Visible = false;
                    t8.Visible = false;
                    t9.Visible = false;
                    Coordenada.Visible = false;
                    tmes.Visible = false;
                    Guardar.Visible = true;
                }
                //if ((Producto == 139) || (Producto == 140))
                //{
                //    observa.Visible = true;
                //    fechat1.Visible = true;
                //    fechat2.Visible = true;
                //    LbltituloFecha.Text = "Fecha de Evaluación";
                //    lblInforme.Text = "Número de Informe";
                //    t1.Visible = true;
                //    t2.Visible = false;
                //    t3.Visible = false;
                //    t4.Visible = false;
                //    t5.Visible = false;
                //    t6.Visible = false;
                //    t7.Visible = true;
                //    t8.Visible = true;
                //    t9.Visible = true;
                //    Coordenada.Visible = true;
                //    tmes.Visible = false;
                //    procesos.LLenarComboT(cboEspecie, "SELECT Id_Especie Id,Codigo_Especie Descripcion FROM Especies_Monitoreo WHERE Estado=1;", "Descripcion", "Id", true);
                //    Guardar.Visible = true;
                //}
                if ((Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || (Producto == 159) ||
                   (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || (Producto == 152) || 
                   (Producto == 153)|| 
                    (Producto == 252) || (Producto == 287))
                {
                    observa.Visible = true;
                    fechat1.Visible = true;
                    fechat2.Visible = true;
                    LbltituloFecha.Text = "Fecha de Evaluación";
                    lblInforme.Text = "Número de Boleta";
                    lblfase.Text = "Fase:";
                    t1.Visible = false;
                    t2.Visible = false;
                    t3.Visible = false;
                    t4.Visible = false;
                    t5.Visible = false;
                    t6.Visible = false;
                    t7.Visible = true;
                    t8.Visible = false;
                    t9.Visible = false;
                    Coordenada.Visible = false;
                    tmes.Visible = false;
                    Guardar.Visible = true;
                }

                if ((Producto == 307)|| (Producto == 308)||(Producto==309) || (Producto == 310)|| (Producto == 320)|| (Producto == 321)|| (Producto == 322)|| (Producto == 323))
                {
                    fechat1.Visible = true;
                    fechat2.Visible = true;
                    Guardar.Visible = true;
                    observa.Visible = true;
                }
                //if ((Producto == 272) )
                //{
                //    observa.Visible = true;
                //    fechat1.Visible = true;
                //    fechat2.Visible = true;
                //    LbltituloFecha.Text = "Fecha de Evaluación";
                //    lblInforme.Text = "Número de Informe";
                //    lblfase.Text = "Fase:";
                //    t1.Visible = true;
                //    t2.Visible = false;
                //    t3.Visible = false;
                //    t4.Visible = false;
                //    t5.Visible = false;
                //    t6.Visible = false;
                //    t7.Visible = false;
                //    t8.Visible = false;
                //    t9.Visible = false;
                //    Coordenada.Visible = false;
                //    tmes.Visible = false;
                //    Guardar.Visible = true;
                //}
                    VerificarGrid();
                LimpiarArchivo();
            }
        }
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            cboDepartamento.ClearSelection();
            cboMunicipio.ClearSelection();
            txtFecha.Clear();
            GrdProductos.Visible = true;
            subcomp.Visible = true;
            Informacion.Visible = false;
            cboMunicipio.Items.Clear();
            txtObservaciones.Text = string.Empty;                        
            txtExpediente.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtnfaseEvaluada.Text = string.Empty;
            txtEdad.Text = string.Empty;
            txtEstatus.Text = string.Empty;
            cboTipoGarantia.ClearSelection();
            txtNumeroInforme.Text = string.Empty;
            cboEspecie.ClearSelection();
            txtVolumen.Text = string.Empty;
            txtX.Text = string.Empty;
            txtY.Text = string.Empty;
            cboMesIngreso.ClearSelection();
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
                 string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 5 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                              + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;
                procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);

            }
            else
            {
                string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 5 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
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
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoMonitoreo(Producto, 1);
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }       
        private void Limpiar() 
        {
            txtExpediente.Text = string.Empty;
            txtnfaseEvaluada.Text = string.Empty;
            txtNumeroInforme.Text = string.Empty;
            cboEspecie.ClearSelection();
            txtVolumen.Text = string.Empty;
            txtX.Text = string.Empty;
            txtY.Text = string.Empty;
            txtEdad.Text = string.Empty;
            cboTipoGarantia.ClearSelection();
            txtEstado.Text = string.Empty;
            txtEstatus.Text = string.Empty;
            txtObservaciones.Text = string.Empty;                                                                                
        }
        private void VerificarGrid() 
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
        protected void LimpiarArchivo()
        {
            RadAsyncUpload Arch = new RadAsyncUpload();
            Lblarchivo.Text = string.Empty;
            RadDocumentoVerificacion.Dispose();
            Session["CargaDocumento"] = Arch;
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoMonitoreoIngreso Generico = new EncabezadoMonitoreoIngreso();
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
            Generico.Noexpediente = txtExpediente.Text.ToString();
            Generico.Fase = txtnfaseEvaluada.Text.ToString();
            Generico.NoInforme = txtNumeroInforme.Text.ToString();            
            Generico.Id_Especie = procesos.IntNULLCombo(cboEspecie);
            Generico.Volumen = procesos.DecimalRadNumericTextBox(txtVolumen);
            Generico.CoordenadaX = procesos.STRRadNumericTextBox(txtX);
            Generico.CoordenadaY = procesos.STRRadNumericTextBox(txtY);
            Generico.Edad = procesos.STRRadNumericTextBox(txtEdad); 
            Generico.Id_Garantia = procesos.IntNULLCombo(cboTipoGarantia);
            Generico.Estado = txtEstado.Text.ToString();
            Generico.Estatus = txtEstatus.Text.ToString();
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];

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


            v = Validar.Campos_Obligatorio_MonitoreoForestal(Generico, RadDocumentoVerificacion, Mantenimiento);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProductoAPI = new XmlDocument();
                int Producto = DMI.Id_ProductoVerificable;
                if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || (Producto == 131) ||
                    (Producto == 132) || (Producto == 133) || (Producto == 124)) 
                {
                    Generico.MedioDeVerificacion = string.Empty;
                    Edapi.Month = Generico.Id_Mes;
                    Edapi.Year = mapi.VerificarAnio(DMI.Id_PoAnual);
                    DescripcionProductoAPI = mapi.ObligacionesForestales(Edapi);
                }
                else
                {

              
                    DA = Mim.SubirPDF(DMI, RadDocumentoVerificacion,FechaHora);
                    Generico.MedioDeVerificacion = DA.Medio_Local;
                }

                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoMonitoreoForestal(Generico);
                if (Mim.GuardarItemEncabezadoApi(2, DMI, DescripcionProducto, DescripcionProductoAPI, ref er))
                {
                   if ((Producto != 126) || (Producto != 127) || (Producto != 128) || (Producto != 129) || (Producto != 130) || (Producto != 131) ||
                    (Producto != 132) || (Producto != 133) || (Producto != 124)) 
                    {
                        foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                        {
                            //f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                            f.SaveAs(DA.Medio_Subir, true);
                        }
                    }
                    Limpiar();
                    Limpiar_IngresoUM();
                    LimpiarArchivo();
                    VerificarGrid();
                }
                else 
                {
                    MensajePantalla(er.Descripcion.ToString());
                }

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
                if (Mim.Eliminacion_Producto(5, edm, ref er))
                {
                    VerificarGrid();
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
              int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
            if(Llave == 0) 
            {
                T1s.Visible = false;
                T2s.Visible = false;
                T3s.Visible = false;
                T4s.Visible = false;
                T5s.Visible = false;
                T6s.Visible = false;
                T7s.Visible = false;
                T8s.Visible = false;
                T9s.Visible = false;
                T10s.Visible = false;
                T11s.Visible = false;
                T12s.Visible = false;
                T13s.Visible = false;
                Lblobservas.Text = item.GetDataKeyValue("Observaciones").ToString();
                if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || (Producto == 131) ||
                    (Producto == 132) || (Producto == 133) || (Producto == 124))
                {
                    T1s.Visible = false;
                    T2s.Visible = true;
                    T3s.Visible = true;
                    T4s.Visible = true;
                    T5s.Visible = false;
                    T6s.Visible = false;
                    T7s.Visible = false;
                    T8s.Visible = false;
                    T9s.Visible = true;
                    T10s.Visible = true;
                    T11s.Visible = false;
                    T12s.Visible = false;
                    T13s.Visible = false;
                    lblNoExpediente.Text = item.GetDataKeyValue("Noexpediente").ToString();
                    lblinformes.Text = item.GetDataKeyValue("NoInforme").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("NoResolucion").ToString();
                    lblGarantias.Text = item.GetDataKeyValue("Garantia").ToString();                   
                }
                if ((Producto == 123) || (Producto == 134))
                {
                    T1s.Visible = true;
                    tituloFecha.Text = "Fecha de Evaluación / Monitoreo:";
                    T2s.Visible = true;
                    T3s.Visible = false;
                    T4s.Visible = true;
                    T5s.Visible = true;
                    T6s.Visible = true;
                    titulofase.Text = "Fase Evaluada:";
                    T7s.Visible = true;
                    T8s.Visible = true;
                    tituloEdad.Text = "Edad:";
                    T9s.Visible = true;
                    T10s.Visible = true;
                    tituloInforme.Text = "Número de Informe:";
                    T11s.Visible = false;
                    T12s.Visible = false;
                    T13s.Visible = false;
                    lblFecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("Noexpediente").ToString();
                    lblestado.Text = item.GetDataKeyValue("Estado").ToString();
                    lblfases.Text = item.GetDataKeyValue("Fase").ToString();
                    lblEstatus.Text = item.GetDataKeyValue("Estatus").ToString();
                    Lbledades.Text = item.GetDataKeyValue("Edad").ToString();
                    lblGarantias.Text = item.GetDataKeyValue("Garantia").ToString();
                    lblinformes.Text = item.GetDataKeyValue("NoInforme").ToString();                                                                              
                }
                if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 142) || (Producto == 143) ||
                    (Producto == 144) || (Producto == 145) || (Producto == 146))
                {
                    T1s.Visible = true;
                    tituloFecha.Text = "Fecha de Monitoreo:";
                    T2s.Visible =true;
                    T3s.Visible = false;
                    T4s.Visible = true;
                    T5s.Visible = false;
                    T6s.Visible = false;
                    T7s.Visible = false;
                    T8s.Visible = true;
                    tituloEdad.Text = "Edad de Plantación:";
                    T9s.Visible = false;
                    T10s.Visible = true;
                    tituloInforme.Text = "Número de Informe / Resolución:";
                    T11s.Visible = true;
                    T12s.Visible = false;
                    T13s.Visible = false;
                    lblFecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("Noexpediente").ToString();
                    Lbledades.Text = item.GetDataKeyValue("Edad").ToString();
                    lblinformes.Text = item.GetDataKeyValue("NoInforme").ToString();
                    lblVolumen.Text = item.GetDataKeyValue("Volumen").ToString();                 
                }
                if ((Producto == 139) || (Producto == 140))
                {                   
                    T1s.Visible = true;
                    tituloFecha.Text = "Fecha de Evaluación:";
                    T2s.Visible = true;
                    T3s.Visible = false;
                    T4s.Visible = true;
                    T5s.Visible = false;
                    T6s.Visible = false;
                    T7s.Visible = false;
                    T8s.Visible = false;
                    T9s.Visible = false;
                    T10s.Visible = true;
                    tituloInforme.Text = "Número de Informe:";
                    T11s.Visible = true;
                    T12s.Visible = true;
                    T13s.Visible = true;
                    lblNoExpediente.Text = item.GetDataKeyValue("Noexpediente").ToString();
                    lblFecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblEspecie.Text = item.GetDataKeyValue("Especie").ToString();
                    lblVolumen.Text = item.GetDataKeyValue("Volumen").ToString();
                    lblcx.Text = item.GetDataKeyValue("CoordenadaX").ToString();
                    lblcy.Text = item.GetDataKeyValue("CoordenadaY").ToString();
                    lblinformes.Text = item.GetDataKeyValue("NoInforme").ToString();                  
                }
                if ((Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || (Producto == 159) ||
                   (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || (Producto == 152) ||
                   (Producto == 153))
                {
                    T1s.Visible = true;
                    tituloFecha.Text = "Fecha de Evaluación:";
                    T2s.Visible = true;
                    T3s.Visible = false;
                    T4s.Visible = true;
                    T5s.Visible = false;
                    T6s.Visible = true;
                    titulofase.Text = "Fase:";
                    T7s.Visible = false;
                    T8s.Visible = false;
                    T9s.Visible = false;
                    T10s.Visible = true;
                    tituloInforme.Text = "Número de Informe:";
                    T11s.Visible = false;
                    T12s.Visible = false;
                    T13s.Visible = false;
                    lblFecha.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblNoExpediente.Text = item.GetDataKeyValue("Noexpediente").ToString();
                    lblfases.Text = item.GetDataKeyValue("Fase").ToString();
                    lblinformes.Text = item.GetDataKeyValue("NoInforme").ToString();                    
                }
                OpenWinwdows(VerDatosExtra, "520", "650", "Key", "Información Adicional del Ingresos");
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