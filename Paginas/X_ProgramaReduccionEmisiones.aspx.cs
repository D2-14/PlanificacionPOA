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
    public partial class X_ProgramaReduccionEmisiones : System.Web.UI.Page
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

                Filtro1.Visible = false;
                Guardar.Visible = false;
                if ((Producto == 239) || (Producto == 240) || (Producto == 241) || (Producto == 244) || 
                    (Producto == 245) || (Producto == 246) || (Producto == 247) || (Producto == 248))
                {
                    procesos.LLenarComboT(CboTipoProyecto, "SELECT Id_TipoProyecto Id,Descripcion FROM Tipo_ProyectoPRE WHERE Estado = 1;", "Descripcion", "Id", true);
                    Filtro1.Visible = true;
                    Guardar.Visible = true;
                }
                if ((Producto == 222) || (Producto == 242) || (Producto == 243) || 
                    (Producto == 221) || (Producto == 237) || (Producto == 238) 
                    ) 
                {
                   
                    Guardar.Visible = true;
                }

                if (//Componente PRE--
                    (Producto == 263) || (Producto == 264) || (Producto == 265) || (Producto == 266) || (Producto == 267))
                {
                    {
                        txtFechaResolucion.Visible = false;
                        Label41.Visible = false;
                        Guardar.Visible = true;
                    }
                }
                    RecargarGrid();
                LimpiarArchivo();
            }
        }
        protected void Limpiars()
        {
            CboTipoProyecto.ClearSelection();
            txtFechaResolucion.Clear();
            txtNoExpediente.Text = string.Empty;
            txtNoResolucion.Text = string.Empty;   
        }
        public Validar_Data Verificar_VaciosSalida()
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            
            if (Mim.Validad_Llenado_detalle(1, DMI) == false)
            {
                v.Verificar = true; v.Mensaje += "Debe de Ingresar Las Áreas Por Modalidad que Corresponda.<br/>";
            }
            return v;
        }
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {

            //********************************
            // Cristian Rejo - Comente esta validacion de areas ya que en su momento solicitaron no requerir dicho campo
            //**********************************

            //Validar_Data v;
            //v = Verificar_VaciosSalida();
            //if (v.Verificar)
            //{
            //    MensajePantalla(v.Mensaje);
            //}
            //else
            //{
            //    cboDepartamento.ClearSelection();
            //    cboMunicipio.ClearSelection();
            //    txtFecha.Clear();
            //    GrdProductos.Visible = true;
            //    subcomp.Visible = true;
            //    Informacion.Visible = false;
            //    cboMunicipio.Items.Clear();
            //    txtObservaciones.Text = string.Empty;
            //    Limpiars();
            //}

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
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 11 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
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

            CboModalidad.TextChanged += new EventHandler(CboModalidad_TextChanged);
            BtnRegresarModulo1.Click += new EventHandler(BtnRegresarModulo1_Click);
            BtnGuardarModalidad.Click += new EventHandler(BtnGuardarModalidad_Click);
            GrdModalidadArea.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdModalidadArea);
            GrdModalidadArea.NeedDataSource += new GridNeedDataSourceEventHandler(GrdModalidadArea_NeedDataSource);
            GrdModalidadArea.PreRender += new EventHandler(GrdModalidadArea_PreRender);
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 90).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoProgramaReduccionEmision Generico = new EncabezadoProgramaReduccionEmision();
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
            Generico.NoResolucion = txtNoResolucion.Text.ToString();
            Generico.NoExpediente = txtNoExpediente.Text.ToString(); 
            Generico.FechaResolucion = procesos.Fechas(txtFechaResolucion);
            Generico.Id_TipoProyecto = procesos.IntNULLCombo(CboTipoProyecto);
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


            v = Validar.Campos_Obligatorio_ProgarmaRE(Generico, RadDocumentoVerificacion, DMI, Mantenimiento);
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
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoProgramaRE(Generico);

                if (Mim.GuardarItemEncabezado(10, DMI, DescripcionProducto, ref er))
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
                if (Mim.Eliminacion_Producto(12, edm, ref er))
                {
                    RecargarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        private void RecargarModalidades()
        {
            GrdModalidadArea.Rebind();
            if (GrdModalidadArea.Items.Count == 0)
            {
                GrdModalidadArea.Visible = false;
            }
            else
            {
                GrdModalidadArea.Visible = true;
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
                AreaModalidad.Visible = true;
                procesos.LLenarComboT(CboModalidad, "SELECT Id_Modalidad Id,Descripcion  FROM Tipo_ModalidadPRE WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarModalidades();
                Llave = 1;
            }

            if (e.CommandName == "Delete") { Llave = 1; }

            if (Llave == 0)
            {
                R1.Visible = false;               
                string Largo = "450";
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 239) || (Producto == 240) || (Producto == 241) || (Producto == 244) ||
                    (Producto == 245) || (Producto == 246) || (Producto == 247) || (Producto == 248))
                {
                    R1.Visible = true;

                    LTipoProyecto.Text = item.GetDataKeyValue("TipoProyecto").ToString();                   
                    Largo = "500";
                }
                LNoResolucion.Text = item.GetDataKeyValue("NoResolucion").ToString();
                LFechaResolucion.Text = item.GetDataKeyValue("FechaResolucion").ToString();
                LNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
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
        /**/
        private void CboModalidad_TextChanged(object sender, EventArgs e)
        {
            txtAreaModalidad.ReadOnly = false;
            txtAreaModalidad.Text = string.Empty;
        }
        protected void GrdModalidadArea_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 8 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdModalidadArea, CadenaSql);
        }
        private void GrdModalidadArea_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdModalidadArea.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Modalidad"].Text == gridDataItem3["Id_Modalidad"].Text)
                    {
                        gridDataItem2["Modalidad"].RowSpan = gridDataItem3["Modalidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Modalidad"].RowSpan + 1;
                        gridDataItem3["Modalidad"].Visible = false;
                    }
                }
            }
        }
        public Validar_Data Verificar_VaciosSalidaDetalle(int ID)
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            decimal Cantidad = Mim.Validad_Llenado_detalleCantidadPRE(ID, DMI, Convert.ToInt32(Session["Padre"].ToString()));

            if (Cantidad != 0)
            {
                v.Verificar = true; v.Mensaje += "La Cantidad de Área Debe ser " + Cantidad + ".<br/>";
            }
            return v;
        }
        protected void BtnRegresarModulo1_Click(object sender, EventArgs e)
        {
            Validar_Data v;
            v = Verificar_VaciosSalidaDetalle(1);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {                                
                Encabezado.Visible = true;
                GrdIngresoEncabezado.Visible = true;
                AreaModalidad.Visible = false;
                CboModalidad.ClearSelection();
                txtAreaModalidad.Text = string.Empty;
                txtAreaModalidad.ReadOnly = true;
            }
        }
        protected void BtnGuardarModalidad_Click(object sender, EventArgs e)
        {
            DetallePRE Generico = new DetallePRE();
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
            Generico.Id_Modalidad  = procesos.IntNULLCombo(CboModalidad);
            Generico.Area  = procesos.DecimalRadNumericTextBox(txtAreaModalidad);

            v = X.Verificar_VaciosModalidadArea(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoProgramaRE(Generico);
                if (Mim.GuardarItemDetalle(8, DMI, DescripcionProducto, ref er))
                {
                    RecargarModalidades();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Eliminar_ItemsGrdModalidadArea(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(8, edm, ref er))
            {
                RecargarModalidades();
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