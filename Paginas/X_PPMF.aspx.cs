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
    public partial class X_PPMF : System.Web.UI.Page
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

                Resp1.Visible = false;
                Resp2.Visible = false;
                Resp3.Visible = false;
                Resp4.Visible = false;
                Resp5.Visible = false;
                Resp5_1.Visible = false;
                Resp5_2.Visible = false;
                Guardar.Visible = false;
                if ((Producto == 181) || (Producto == 182) || (Producto == 183) || (Producto == 234))
                {
                    procesos.LLenarComboT(CboTipoBosque, "SELECT Id_Tipo_Bosque Id,Descripcion2 Descripcion FROM Tipo_Bosque WHERE Estado = 1;", "Descripcion", "Id", true);
                    Resp1.Visible = true;
                    Resp3.Visible = true;
                    Resp4.Visible = true;
                    Resp5.Visible = true;
                    Resp5_1.Visible = true;
                    Resp5_2.Visible = true;
                    Guardar.Visible = true;
                    Resp5.Visible = false;
                    Label23.Visible = false;
                    FechaPPM.Visible = false;
                }
                //if (Producto == 234)
                //{
                //    Resp5.Visible = true;
                //    Guardar.Visible = true;
                //}
                if (Producto == 235)
                {
                    Resp2.Visible = true;
                    Resp3.Visible = true;
                    Guardar.Visible = true;
                }
                RecargarGrid();
                LimpiarArchivo();
            }
        }        
        protected void Limpiars() 
        {
            CboTipoBosque.ClearSelection();
            txtUnidadMuestreo.Text = string.Empty;
            txtCoordenadaX.Text = string.Empty;
            txtCoordenadaY.Text = string.Empty;
            Fechaplnatacion.Clear();
            FechaPPM.Clear();
            txtNombresitio.Text = string.Empty;
            txtNoExperimento.Text = string.Empty;
            txtNoParcela.Text = string.Empty;
            txtNoMedcion.Text = string.Empty;
            txtReplanteo.Text = string.Empty;
            txtCodigoProyecto.Text = string.Empty;  
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
            Limpiars();
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
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 10 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;

            procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
        }
        protected void GrdIngresoEncabezado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;               
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 79).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoPPMF Generico = new EncabezadoPPMF();
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
            Generico.Id_TipoBosque = procesos.IntNULLCombo(CboTipoBosque);
            Generico.CoordenadaX = procesos.STRRadNumericTextBox(txtCoordenadaX);
            Generico.CoordenadaY = procesos.STRRadNumericTextBox(txtCoordenadaY);
            Generico.FechaPlantacion = procesos.Fechas(Fechaplnatacion);
            Generico.NoMedicion = procesos.STRRadNumericTextBox(txtNoMedcion); 
            Generico.FechaPPM = procesos.Fechas(FechaPPM);
            Generico.NombreSitio = txtNombresitio.Text.ToString();
            Generico.NoExperimento = procesos.STRRadNumericTextBox(txtNoExperimento);
            Generico.NoParcela = procesos.STRRadNumericTextBox(txtNoParcela);
            Generico.Replanteo = procesos.DecimalRadNumericTextBox(txtReplanteo);
            Generico.UnidadMuestreo = procesos.STRRadNumericTextBox(txtUnidadMuestreo);
            Generico.CodigoProyecto = txtCodigoProyecto.Text.ToString();

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

            v = Validar.Campos_Obligatorio_PPMF(Generico, RadDocumentoVerificacion, DMI, Mantenimiento);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                //CR  agregar fecha y hora para concatenarselo al nombre del documento que se va a subir
                string FechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");


                DA = Mim.SubirPDF(DMI, RadDocumentoVerificacion,FechaHora);
                Generico.MedioDeVerificacion = DA.Medio_Local;
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoPPMF(Generico);

                if (Mim.GuardarItemEncabezado(9, DMI, DescripcionProducto, ref er))
                {
                    foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                    {
                       // f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                        f.SaveAs(DA.Medio_Subir, true);
                    }
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    LimpiarArchivo();
                    cboMunicipio.ClearSelection();
                    txtObservaciones.Text = string.Empty;
                    txtFecha.Clear();
                    Limpiars();
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
                if (Mim.Eliminacion_Producto(11, edm, ref er))
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
                R1.Visible = false;
                R2.Visible = false;
                R3.Visible = false;
                R4.Visible = false;
                R5.Visible = false;
                R6.Visible = false;
                string Largo = "450";
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 181) || (Producto == 182) || (Producto == 183))
                {
                    R1.Visible = true;
                    R3.Visible = true;
                    R4.Visible = true;
                    R5.Visible = true;
                    R6.Visible = true;
                    Ltipobosque.Text = item.GetDataKeyValue("TipoBosque").ToString();
                    Lcoordenadax.Text = item.GetDataKeyValue("CoordenadaX").ToString();
                    Lcoordenaday.Text = item.GetDataKeyValue("CoordenadaY").ToString();
                    Lfechaplantacion.Text = item.GetDataKeyValue("FechaPlantacion").ToString();
                    LfechaPPM.Text = item.GetDataKeyValue("FechaPPM").ToString();
                    LNombresitio.Text = item.GetDataKeyValue("NombreSitio").ToString();
                    LNoExperimento.Text = item.GetDataKeyValue("NoExperimento").ToString();
                    LNoParcela.Text = item.GetDataKeyValue("NoParcela").ToString();
                    LNomedicion.Text = item.GetDataKeyValue("NoMedicion").ToString();
                    LcodigoProyecto.Text = item.GetDataKeyValue("CodigoProyecto").ToString();
                    LReplanteo.Text = item.GetDataKeyValue("Replanteo").ToString();
                    Largo = "500";
                }
                if (Producto == 234)
                {
                    R5.Visible = true;
                    LNombresitio.Text = item.GetDataKeyValue("NombreSitio").ToString();
                    LNoExperimento.Text = item.GetDataKeyValue("NoExperimento").ToString();
                    LNoParcela.Text = item.GetDataKeyValue("NoParcela").ToString();
                    LNomedicion.Text = item.GetDataKeyValue("NoMedicion").ToString();
                }
                if (Producto == 235) 
                {
                    R2.Visible = true;
                    R3.Visible = true;
                    LUnidadMuestreo.Text = item.GetDataKeyValue("UnidadMuestreo").ToString();
                    Lcoordenadax.Text = item.GetDataKeyValue("CoordenadaX").ToString();
                    Lcoordenaday.Text = item.GetDataKeyValue("CoordenadaY").ToString();
                }                    
                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
                OpenWinwdows(VerDatosExtra, "520", Largo, "Key", "Información Adicional del Ingresos");
            }
        }
        protected void Limpiar()
        {
            cboMunicipio.ClearSelection();
            txtObservaciones.Text = string.Empty;
            txtFecha.Clear();
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