using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Web.UI;
using System.Data;
using System.Xml;
using System.IO;

namespace PlanificacionPOA.Paginas
{
    public partial class Y_Nacionales : System.Web.UI.Page
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
            MonitoreoObjetos MO = (MonitoreoObjetos)Session["infoNacionalMonitoreoIngresoMetas"];
            string Cadena = string.Empty; 
            if (MO.Tipo == 1) { Cadena = "del Producto"; }
            if (MO.Tipo == 2) { Cadena = "del Subproducto"; }
            if (MO.Tipo == 3) { Cadena = "de la Actividad"; }
            lblConfirm.Text = "Desea Finalizar el ingreso " + Cadena;
            OpenWinwdows(confirmar, "330", "170", "Key5", "Información");
        }
        protected void BtnIrConfiguracion_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            MonitoreoObjetos MO = (MonitoreoObjetos)Session["infoNacionalMonitoreoIngresoMetas"];
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];

            if (Mim.FinalizarIngresoDeObjetosNacionales(DMI,MO.Correlativo, ref er))
            {
                Response.Redirect("ActividadNacionalMonitoreo.aspx");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActividadNacionalMonitoreo.aspx");
        }
        protected void Inicializacion_Objetos() 
        {
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            btnFinalizarIngreso.Click += new EventHandler(BtnFinalizarIngreso_Click);
            CerraVentana.Click += new EventHandler(CerraVentana_Click);
            btnCerrarVentana.Click += new EventHandler(BtnCerrarVentana_Click);
            btnIrConfiguracion.Click += new EventHandler(BtnIrConfiguracion_Click);
            CancelarIngreso.Click += new EventHandler(CancelarIngreso_Click);
            Guardar.Click += new EventHandler(Guardar_Click);
            RadDocumentoVerificacion.FileUploaded += new FileUploadedEventHandler(RadDocumentoVerificacion_FileUploaded);
            GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdIngresoEncabezado.DeleteCommand += new GridCommandEventHandler(Eliminar_Items);
            GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);            
        }
        protected void FillCampos() 
        {
            string Cadena;

           
                ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            MonitoreoObjetos MO =(MonitoreoObjetos)Session["infoNacionalMonitoreoIngresoMetas"];
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];

            lblPoa.Text = DMI.NombrePOA;            
            lblObjeto.Text = MO.Descripcion; 
            lbsubregion.Text = DMI.Nombre_SubRegion;
            Lblmes.Text = DMI.Descripcion_mes;
            lbsubregion.Text = DMI.Nombre_SubRegion;
            lblregion.Text = DMI.Nombre_Region;

            //GrdProductos.Visible = false;
            Cadena = "Sp_obtener_data_Actividad_Nacional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + MO.Correlativo;
            DataSet Datos = procesos.obtenerDataSetCodigo(Cadena, "Tabla");

            DMI.Id_UM1 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM1"].ToString());
            DMI.Id_UM2 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM2"].ToString());
            DMI.Id_UM3 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM3"].ToString());
            Session["infoNacionalMonitoreo"] = DMI;

            LblUM1.Text = "UM1 " + Datos.Tables[0].Rows[0]["DescripcionUM1"].ToString();
            trum1.Visible = vp.ValidarCamposUMNacional(DMI.Id_UM1, 1).ExpresionBool;
            txtum1.Text = vp.ValidarCamposUMNacional(DMI.Id_UM1, 2).ExpresionNumber;
            txtum1.ReadOnly = vp.ValidarCamposUMNacional(DMI.Id_UM1, 2).ExpresionBool;

            LblUM2.Text = "UM2 " + Datos.Tables[0].Rows[0]["DescripcionUM2"].ToString();
            trum2.Visible = vp.ValidarCamposUMNacional(DMI.Id_UM2, 1).ExpresionBool;
            txtum2.Text = vp.ValidarCamposUMNacional(DMI.Id_UM2, 2).ExpresionNumber;
            txtum2.ReadOnly = vp.ValidarCamposUMNacional(DMI.Id_UM2, 2).ExpresionBool;

            LblUM3.Text = "UM3 " + Datos.Tables[0].Rows[0]["DescripcionUM3"].ToString();
            trum3.Visible = vp.ValidarCamposUMNacional(DMI.Id_UM3, 1).ExpresionBool;
            txtum3.Text = vp.ValidarCamposUMNacional(DMI.Id_UM3, 2).ExpresionNumber;
            txtum3.ReadOnly = vp.ValidarCamposUMNacional(DMI.Id_UM3, 2).ExpresionBool;

            RecargarGrid();
            LimpiarArchivo();
        }
        protected void RadDocumentoVerificacion_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            Session["CargaDocumento"] = RadDocumentoVerificacion;
            Lblarchivo.Text = @"Archivo Esta Precargado";
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 94).Permiso != true)
                {
                    Response.Redirect("ActividadNacionalMonitoreo.aspx");
                }
                FillCampos();
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

                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
                OpenWinwdows(VerDatosExtra, "520", "400", "Key", "Información Adicional del Ingresos");
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

            if (Mim.Eliminar_MedioVerificacionFisico(item.GetDataKeyValue("MedioDeVerificacion").ToString()) == false)
            {
                if (Mim.Eliminacion_ProductoNacional(edm, ref er))
                {
                    RecargarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void GrdIngresoEncabezado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];
            MonitoreoObjetos MO = (MonitoreoObjetos)Session["infoNacionalMonitoreoIngresoMetas"];
            string CadenaSql = "Sp_obtener_data_GridProductosNacionalesMonitoreo " + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + MO.Correlativo + "," + DMI.Id_Mes;

            procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
        }
        protected void GrdIngresoEncabezado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;               
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoNacionalGeneral Generico = new EncabezadoNacionalGeneral();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Medios DA;
            Validar_Data v;
            MonitoreoObjetos MO = (MonitoreoObjetos)Session["infoNacionalMonitoreoIngresoMetas"];
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];

            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Tipo = MO.Tipo;
            Generico.Correlativo_Configuracion = MO.Correlativo;
            Generico.Id_Producto = MO.Id_Producto;
            Generico.Id_SubProducto = MO.Id_SubProducto;
            Generico.Id_Actividad = MO.Id_Actividad;
            Generico.Id_Subregion = DMI.Id_Subregion;
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
            

            v = Validar.Campos_Obligatorio_Nacionales(Generico, RadDocumentoVerificacion, DMI, Mantenimiento);
            
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                //CR  agregar fecha y hora para concatenarselo al nombre del documento que se va a subir
                string FechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                DA = Mim.SubirPDFNacional(DMI,MO.Correlativo, RadDocumentoVerificacion,FechaHora);
                Generico.MedioDeVerificacion = DA.Medio_Local;
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoNacional(Generico);

                if (Mim.GuardarItemEncabezadoNacional(DMI,MO.Correlativo, DescripcionProducto, ref er))
                {
                    foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                    {
                        
                      
                           // f.SaveAs(DA.Medio_Subir.Replace(".", $"{FechaHora}."), true);

                        f.SaveAs(DA.Medio_Subir, true);
                    }
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    LimpiarArchivo();                   
                    txtObservaciones.Text = string.Empty;
                    txtFecha.Clear();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        private void Limpiar_IngresoUM()
        {           
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();

            if (xdata.Tipo_conteoNacional(DMI.Id_UM1) != 1)
            {
                txtum1.Text = string.Empty;
            }
            if (xdata.Tipo_conteoNacional(DMI.Id_UM2) != 1)
            {
                txtum2.Text = string.Empty;
            }
            if (xdata.Tipo_conteoNacional(DMI.Id_UM3) != 1)
            {
                txtum3.Text = string.Empty;
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
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            Limpiar_IngresoUM();
            txtFecha.Clear();            
            txtObservaciones.Text = string.Empty;
            RadAsyncUpload Arch = new RadAsyncUpload();
            Lblarchivo.Text = string.Empty;
            RadDocumentoVerificacion.Dispose();
            Session["CargaDocumento"] = Arch;
        }
        protected void CerraVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(visualizar, "Key");
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