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
    public partial class X_IngresoMangle : System.Web.UI.Page
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
                
                Guardar.Visible = false;
                if ((Producto == 120) || (Producto == 121)) 
                {
                    Guardar.Visible = true;
                    IListadoSurvey.Visible = true;
                }               
                else
                {
                    IListadoSurvey.Visible = false;
                }

                RecargarGrid();
                LimpiarArchivo();
            }
        }
        public Validar_Data Verificar_VaciosSalida()
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();

            if (Mim.Validad_Llenado_detalle(1, DMI) == false)
            {
                v.Verificar = true; v.Mensaje += "Debe de Ingresar Información Comunidad Linguistica.<br/>";
            }
            if (Mim.Validad_Llenado_detalle(2, DMI) == false)
            {
                v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Grupo Etario.<br/>";
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
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 18 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
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
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoMangle(Producto, 1);
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoMangle(Producto, 1);
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
           
            CboComunidad.TextChanged += new EventHandler(CboComunidad_TextChanged);
            BtnRegresarModulo1.Click += new EventHandler(BtnRegresarModulo1_Click);
            BtnGuardarTipoActor.Click += new EventHandler(BtnGuardarTipoActor_Click);
            GrdActores.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdActores);
            GrdActores.NeedDataSource += new GridNeedDataSourceEventHandler(GrdActores_NeedDataSource);
            GrdActores.PreRender += new EventHandler(GrdActores_PreRender);

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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 75).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoMangle Generico = new EncabezadoMangle();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejarApi mapi = new ManejarApi();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Medios DA = new Medios();           
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
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];


            if ((Generico.Id_ProductoVerificable == 121)&& (Generico.Id_ProductoVerificable == 120))
            {
                Generico.Survey = "";
            }
            else
            {

                Generico.Survey = cboListadoSurv.SelectedValue;
            }

            string Mantenimiento;
            if (Session["Mantenimiento"] == "True")
            {
                Mantenimiento = "True";
            }
            else
            {
                Mantenimiento = "False";
            }

            v = Validar.Campos_Obligatorio_Mangle(Generico, RadDocumentoVerificacion, DMI,Mantenimiento);
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
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoMangle(Generico);
                
                //if (Mim.GuardarItemEncabezado(4, DMI, DescripcionProducto, ref er))
                if (Mim.GuardarItemEncabezado(18, DMI, DescripcionProducto, ref er))
                {
                    foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                    {

                        //f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                        f.SaveAs(DA.Medio_Subir, true);
                    }
                    Limpiar_IngresoUM();
                    RecargarGrid();
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
                if (Mim.Eliminacion_Producto(6, edm, ref er))
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
            
            //string Survey = item.GetDataKeyValue("Survey").ToString();

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
                ActoresTipos.Visible = true;
                procesos.LLenarComboT(CboComunidad, "SELECT Id_Comunidad Id,Descripcion FROM Comunidad_Linguistica_monitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarActores();
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
            if (e.CommandName == "Delete") { Llave = 1; }

              if (Llave == 0)
              {
                                  
                  LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();                  
                  OpenWinwdows(VerDatosExtra, "520", "400", "Key", "Información Adicional del Ingresos");
              }
        }
        
        protected void Limpiar()
        {
            cboMunicipio.ClearSelection();
            txtObservaciones.Text = string.Empty;
            txtFecha.Clear();                      
        }
        private void RecargarActores()
        {
            GrdActores.Rebind();
            if (GrdActores.Items.Count == 0)
            {
                GrdActores.Visible = false;
            }
            else
            {
                GrdActores.Visible = true;
            }
        }
        private void RecargaPertenencia()
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
        private void CboComunidad_TextChanged(object sender, EventArgs e)
        {
            txtNumeroPersonasL.ReadOnly = false;
            txtNumeroPersonasL.Text = string.Empty;
        }
        protected void BtnRegresarModulo1_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalidaDetalle(5);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                Encabezado.Visible = true;
                GrdIngresoEncabezado.Visible = true;
                ActoresTipos.Visible = false;               
                CboComunidad.ClearSelection();
                txtNumeroPersonasL.Text = string.Empty;
                txtNumeroPersonasL.ReadOnly = true;
            }
        }
        protected void BtnGuardarTipoActor_Click(object sender, EventArgs e)
        {
            Fortalecimiento1 Generico = new Fortalecimiento1();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ValidarCamposObligatoriosMonitoreo X = new ValidarCamposObligatoriosMonitoreo();
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
            Generico.Id_Comunidad = procesos.IntNULLCombo(CboComunidad);
            Generico.NumeroPersonas = procesos.STRRadNumericTextBox(txtNumeroPersonasL);

            v = X.Verificar_VaciosActores(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoFortalecimiento1(Generico);
                if (Mim.GuardarItemDetalle(7, DMI, DescripcionProducto, ref er))
                {
                    RecargarActores();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Eliminar_ItemsGrdActores(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(7, edm, ref er))
            {
                RecargarActores();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void GrdActores_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 7 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdActores, CadenaSql);
        }
        private void GrdActores_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdActores.Items)
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
        private void CboGrupoEtario_TextChanged(object sender, EventArgs e)
        {
            txtNumeroPersonasEtario.ReadOnly = false;
            txtNumeroPersonasEtario.Text = string.Empty;
        }
        protected void BtnRegresarModulo2_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalidaDetalle(2);
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
                if (Mim.GuardarItemDetalle(6, DMI, DescripcionProducto, ref er))
                {
                    RecargaPertenencia();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void GrdPertencia_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 6 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPertencia, CadenaSql);
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

            if (Mim.Eliminacion_DatosExtra(6, edm, ref er))
            {
                RecargaPertenencia();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        public Validar_Data Verificar_VaciosSalidaDetalle(int ID)
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            int Cantidad = Mim.Validad_Llenado_detalleCantidad(ID, DMI, Convert.ToInt32(Session["Padre"].ToString()));

            if (Cantidad != 0)
            {
                v.Verificar = true; v.Mensaje += "La Cantidad de Personas Debe ser " + Cantidad + ".<br/>";
            }
            return v;
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