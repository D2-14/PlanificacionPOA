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
    public partial class X_ProteccionForestal : System.Web.UI.Page
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
        private void CboTipoABM_TextChanged(object sender, EventArgs e)
        {
            CboAreaBM.ClearSelection();
            lbltituloAreab.Text = procesos.StrNULLCombo(CboTipoABM);  
            procesos.LLenarComboT(CboAreaBM, "SELECT Id_AreaBM Id,Descripcion FROM Area_Bajo_Manejo WHERE Estado = 1 AND Id_tipoAreaBM = "+ procesos.IntNULLCombo(CboTipoABM), "Descripcion", "Id", true);
        }
        private void CboEscenario_TextChanged(object sender, EventArgs e)
        {
            int Valor = procesos.IntNULLCombo(CboEscenario);
            op1.Visible = false;
            op2.Visible = false;
            if ((Valor == 1)|| (Valor == 2) || (Valor == 3)) 
            {
                op1.Visible = true;             
            }
            else 
            {                
                op2.Visible = true;
            }
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
                I1.Visible = false;
                I2.Visible = false;
                I3.Visible = false;
                I4.Visible = false;
                I5.Visible = false;
                Guardar.Visible = false;

                if ((Producto == 207)||(Producto == 210))
                {
                    I5.Visible = true;
                    I6.Visible = false;  //Número Contacto y nombre contacto
                    LbltituloHectaria.Text = "Hectarías Saneadas";
                    Guardar.Visible = true;
                }
                if ((Producto == 205)||(Producto == 214))
                {
                    I6.Visible = false;  //Número Contacto y nombre contacto
                    I7.Visible = false;

                  
                    LbltituloHectaria.Text = "Hectarías a Sanear";
                    Guardar.Visible = true;
                }                
                if ((Producto == 208) )
                {
                   I4.Visible = false;
                    I6.Visible = true;  //Número Contacto y nombre contacto
                    I7.Visible = false;
                    procesos.LLenarComboT(CboEquipoP, "SELECT Id_Respuesta Id,Descripcion FROM Respuesta_Monitoreo  WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 215) )
                {
                   I4.Visible = false;
                    I6.Visible = true;  //Número Contacto y nombre contacto
                    I7.Visible = true;
                    procesos.LLenarComboT(CboEquipoP, "SELECT Id_Respuesta Id,Descripcion FROM Respuesta_Monitoreo  WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 209)
                {
                    I6.Visible = false;  //Número Contacto y nombre contacto
                    I7.Visible = false;
                    I3.Visible = true;
                    procesos.LLenarComboT(CboTipoABM, "SELECT Id_tipoAreaBM Id, Descripcion FROM Tipo_AreaBajoManejo  WHERE Estado = 1; ", "Descripcion", "Id", true);                  
                    procesos.LLenarComboT(CboFase, "SELECT Id_fase Id,Descripcion FROM FaseProyecto WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 236))
                {
                    I2.Visible = true;
                    procesos.LLenarComboT(CboEscenario, "SELECT Id_TipoEscenario Id,Descripcion FROM Tipo_Escenario WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 213)||(Producto == 211)||(Producto == 274))
                {
                    I5.Visible = false;
                    I2.Visible = false;
                    I6.Visible = false;  //Número Contacto y nombre contacto
                    procesos.LLenarComboT(CboEscenario, "SELECT Id_TipoEscenario Id,Descripcion FROM Tipo_Escenario WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 216)
                {
                    I6.Visible = false;  //Número Contacto y nombre contacto
                    I7.Visible = false;  
                    I1.Visible = true;
                    procesos.LLenarComboT(CboBosque, "SELECT Id_Tipo_Bosque Id,Descripcion FROM Tipo_Bosque WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboIncendio, "SELECT Id_Tipo_Incendio Id,Descripcion FROM Tipo_Incendio WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboAdministracion, "SELECT Id_Tipo_Administracion Id,Descripcion FROM Tipo_Administracion WHERE Estado = 1", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 205) || (Producto == 206) ||(Producto == 211) ||
                    (Producto == 214) || (Producto == 217)|| (Producto == 274))
                {
                    Guardar.Visible = true;
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

            if ((DMI.Id_ProductoVerificable == 208) || (DMI.Id_ProductoVerificable == 215))
            {
                if (Mim.Validad_Llenado_detalle(1, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información Comunidad Linguistica.<br/>";
                }
                if (Mim.Validad_Llenado_detalle(2, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Grupo Etario.<br/>";
                }
            }
            return v;
        }
        protected void Ini()
        {
            cboMunicipio.ClearSelection();
            cboMunicipio.ClearSelection();
            txtFecha.Clear();
            txtObservaciones.Text = string.Empty;
            op1.Visible = false;
            op2.Visible = false;
            CboBosque.ClearSelection();
            CboIncendio.ClearSelection();
            CboAdministracion.ClearSelection();
            CboEscenario.ClearSelection();
            txthectaria1.Text = string.Empty;
            txtAgenteCausal1.Text = string.Empty;
            NoMuestraRegionC.Text = string.Empty;
            CboTipoABM.ClearSelection();
            CboAreaBM.ClearSelection();
            CboFase.ClearSelection();
            txtCoordenadax.Text = string.Empty;
            txtCoordenaday.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txttelefono.Text = string.Empty;
            CboEquipoP.ClearSelection();
            txtNumeroExpediente.Text = string.Empty;
            txtAgenteCausal2.Text = string.Empty;
            txtnombreTitular.Text = string.Empty;
            txthectaria2.Text = string.Empty;           
        }
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            //Validar_Data v;
            //v = Verificar_VaciosSalida();
            //if (v.Verificar)
            //{
            //    MensajePantalla(v.Mensaje);
            //}
            //else
            //{
            //    cboDepartamento.ClearSelection();
            //    Ini();
            //    GrdProductos.Visible = true;
            //    subcomp.Visible = true;
            //    Informacion.Visible = false;
            //    cboMunicipio.Items.Clear();
            //}

            cboDepartamento.ClearSelection();
            Ini();
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
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 8 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
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
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoProteccionForestal(Producto, 1);
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoProteccionForestal(Producto, 1);
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
            CboEscenario.TextChanged += new EventHandler(CboEscenario_TextChanged);
            CboTipoABM.TextChanged += new EventHandler(CboTipoABM_TextChanged);

            /**/
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 81).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoProteccionForestal Generico = new EncabezadoProteccionForestal();
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
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];
            /**/
            Generico.NoExpediente = txtNumeroExpediente.Text.ToString();
            Generico.AgenteCausal = Validar.Agente_Causal(DMI.Id_ProductoVerificable, txtAgenteCausal1.Text.ToString(), txtAgenteCausal2.Text.ToString());
            Generico.NombreTitular = txtnombreTitular.Text.ToString();
            Generico.Hectarias = Validar.HectariaPF(DMI.Id_ProductoVerificable, procesos.DecimalRadNumericTextBox(txthectaria1), procesos.DecimalRadNumericTextBox(txthectaria2));
            Generico.CoordenadaX = procesos.STRRadNumericTextBox(txtCoordenadax);
            Generico.CoordenadaY = procesos.STRRadNumericTextBox(txtCoordenaday);
            Generico.NombreContacto = txtContacto.Text.ToString();
            Generico.NumeroTelefono = procesos.STRRadNumericTextBox(txttelefono);
            Generico.Id_EquipoProteccion = procesos.IntNULLCombo(CboEquipoP);
            Generico.Id_tipoAreaBM = procesos.IntNULLCombo(CboTipoABM);
            Generico.Id_AreaBM = procesos.IntNULLCombo(CboAreaBM);
            Generico.Id_fase = procesos.IntNULLCombo(CboFase);
            Generico.Id_TipoEscenario = procesos.IntNULLCombo(CboEscenario);
            Generico.NumeroMuestra = NoMuestraRegionC.Text.ToString();
            Generico.Id_Tipo_Bosque = procesos.IntNULLCombo(CboBosque);
            Generico.Id_Tipo_Incendio = procesos.IntNULLCombo(CboIncendio);
            Generico.Id_Tipo_Administracion = procesos.IntNULLCombo(CboAdministracion);


            string Mantenimiento;
            if (Session["Mantenimiento"] == "True")
            {
                Mantenimiento = "True";
            }
            else
            {
                Mantenimiento = "False";
            }


            v = Validar.Campos_Obligatorio_ProteccionForestal(Generico, RadDocumentoVerificacion, DMI, Mantenimiento);
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
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoProteccionForestal(Generico);
                if (Mim.GuardarItemEncabezado(7, DMI, DescripcionProducto, ref er))
                {
                    foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                    {
                        f.SaveAs(DA.Medio_Subir, true);
                        //f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                    }
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    LimpiarArchivo();
                    Ini();
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
                if (Mim.Eliminacion_Producto(9, edm, ref er))
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
                x1.Visible = false;
                x2.Visible = false;
                x3.Visible = false;
                x4.Visible = false;
                x5.Visible = false;
                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
                string Largo = "380";
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 210)
                {
                    x1.Visible = true;
                    LbltituloH.Text = "Hectarías Saneadas";
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblAgente1.Text = item.GetDataKeyValue("AgenteCausal").ToString();
                    lblTitular.Text = item.GetDataKeyValue("NombreTitular").ToString();
                    lblHectaria1.Text = item.GetDataKeyValue("Hectarias").ToString();
                    Largo = "450";
                }
                if (Producto == 207)
                {
                    x1.Visible = true;
                    LbltituloH.Text = "Hectarías a Sanear";
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblAgente1.Text = item.GetDataKeyValue("AgenteCausal").ToString();
                    lblTitular.Text = item.GetDataKeyValue("NombreTitular").ToString();
                    lblHectaria1.Text = item.GetDataKeyValue("Hectarias").ToString();
                    Largo = "450";
                }
                if ((Producto == 208) || (Producto == 215))
                {
                    x2.Visible = true;
                    lblCoordenadax.Text = item.GetDataKeyValue("CoordenadaX").ToString();
                    LbCoordenaday.Text = item.GetDataKeyValue("CoordenadaY").ToString();
                    lblNombreContacto.Text = item.GetDataKeyValue("NombreContacto").ToString();
                    lblNumeroTelefono.Text = item.GetDataKeyValue("NumeroTelefono").ToString();
                    LblequipoProteccion.Text = item.GetDataKeyValue("EquipoProteccion").ToString();
                    Largo = "450";
                }
                if (Producto == 209)
                {
                    x3.Visible = true;
                    LbltipoBM.Text = item.GetDataKeyValue("TipoAreaManejo").ToString();
                    Lbltitulotabm.Text = item.GetDataKeyValue("TipoAreaManejo").ToString();
                    lblareabm.Text = item.GetDataKeyValue("AreaBajoManejo").ToString();
                    lblFaseproyecto.Text = item.GetDataKeyValue("fase").ToString();
                    Largo = "450";
                }
                if ((Producto == 213) || (Producto == 236))
                {
                    x4.Visible = true;
                    lblescenario.Text = item.GetDataKeyValue("Escenario").ToString();
                    int Valor = Convert.ToInt32(item.GetDataKeyValue("Id_TipoEscenario").ToString());
                    if((Valor == 1)|| (Valor == 2)|| (Valor == 3))
                    {
                        lblHectaria2.Text = item.GetDataKeyValue("Hectarias").ToString();
                    }
                    else 
                    {
                        lblHectaria2.Text = "No Aplica";
                    }
                    LblAgente2.Text = item.GetDataKeyValue("AgenteCausal").ToString();
                    lblNomuestra.Text = item.GetDataKeyValue("NumeroMuestra").ToString();
                    Largo = "450";
                }
                if (Producto == 216)
                {
                    x5.Visible = true;
                    lblBosque.Text = item.GetDataKeyValue("Bosque").ToString();
                    lblincendio.Text = item.GetDataKeyValue("Incendio").ToString();
                    lbladministracion.Text = item.GetDataKeyValue("Administracion").ToString();
                    Largo = "450";
                }                
               OpenWinwdows(VerDatosExtra, "520", Largo, "Key", "Información Adicional del Ingresos");
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