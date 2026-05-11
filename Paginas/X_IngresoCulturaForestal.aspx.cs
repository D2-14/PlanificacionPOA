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
    public partial class X_IngresoCulturaForestal : System.Web.UI.Page
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
                Resp6.Visible = false;
                Resp7.Visible = false;
                Guardar.Visible = false;
                if (Producto == 45)
                {
                    Resp7.Visible = false;
                    Resp5.Visible = false;
                    Resp6.Visible = false;                   
                    LblNombreTema.Text = "Tema";                    
                    procesos.LLenarComboT(CboTipoEvento, "SELECT Id_TipoEvento Id,Descripcion FROM Tipo_Evento WHERE Estado = 1 AND Id_Tipo = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboCampania, "SELECT Id_Campania Id,Descripcion FROM CampaniaCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 35)
                {
                    Resp3.Visible = true;
                    procesos.LLenarComboT(CboTemaAtendido, "SELECT Id_TemaAtendido Id,Descripcion FROM TemaAtendidoCF WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 36)||(Producto == 37)||(Producto == 324))
                {
                    Resp7.Visible = false;
                    Resp5.Visible = false;
                    Resp6.Visible = false;
                    Resp3.Visible = false;
                    Resp2.Visible = false;
                    Guardar.Visible = true;
                }
                if (Producto == 38)
                {
                    Resp2.Visible = true;
                    Guardar.Visible = true;
                }
                if ((Producto == 39) || (Producto == 40))
                {
                    Resp5.Visible = true;
                    Resp6.Visible = true;                   
                    LblNombreTema.Text = "Tema";
                    procesos.LLenarComboT(CboTipoEvento, "SELECT Id_TipoEvento Id,Descripcion FROM Tipo_Evento WHERE Estado = 1 AND Id_Tipo = 2;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboCampania, "SELECT Id_Campania Id,Descripcion FROM CampaniaCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 41)
                {
                    Resp4.Visible = true;
                    Guardar.Visible = true;
                }
                if (Producto == 42)
                {
                    Resp1.Visible = true;
                    Resp6.Visible = true;                   
                    LblNombreTema.Text = "Tema";
                    procesos.LLenarComboT(CboTipoApoyo, "SELECT Id_TipoApoyo Id,Descripcion FROM TipoDeAproyoCF WHERE Estado = 1;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(CboCampania, "SELECT Id_Campania Id,Descripcion FROM CampaniaCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if (Producto == 43) 
                {
                    Guardar.Visible = true;
                }
                if (Producto == 44)
                {
                    Resp6.Visible = true;                   
                    LblNombreTema.Text = "Nombre de la Entidad con la"+ Environment.NewLine + "que se Realizo el Acuerdo";
                    procesos.LLenarComboT(CboCampania, "SELECT Id_Campania Id,Descripcion FROM CampaniaCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }                
                RecargarGrid();
                LimpiarArchivo();
            }
        }
        protected void Limpiars()
        {            
            txtNombreEvento.Text = string.Empty;
            CboTipoEvento.ClearSelection();
            CboCampania.ClearSelection();
            txttema.Text = string.Empty;
            txtmedioParticipante.Text = string.Empty;
            txtNombreMaterial.Text = string.Empty;
            txtnombreMeioComunicacion.Text = string.Empty;
            txtTemaAbordado.Text = string.Empty;
            CboTemaAtendido.ClearSelection();
            txtFechaInicio.Clear();
            txtFechaFinal.Clear();
            CboTipoApoyo.ClearSelection();
            txtnombreEntidad.Text = string.Empty;
            txtmedioParticipante.Text = string.Empty;
        }
        public Validar_Data Verificar_VaciosSalida()
        {
            Validar_Data v = new Validar_Data();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            int Producto = DMI.Id_ProductoVerificable;

            if ((Producto == 35) || (Producto == 45))
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
            if(Producto == 37) 
            {
                if (Mim.Validad_Llenado_detalle(3, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Número de Notas.<br/>";
                }
            }
            if (Producto == 38) 
            {
                if (Mim.Validad_Llenado_detalle(5, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información al Publico que va dirigido.<br/>";
                }
                if (Mim.Validad_Llenado_detalle(6, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información del tipo material utilizado.<br/>";
                }
            }
            if (Producto == 42)
            {
                if (Mim.Validad_Llenado_detalle(4, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información en Publicidad.<br/>";
                }
            }
            if (Producto == 43) 
            {
                if (Mim.Validad_Llenado_detalle(7, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información a la campaña de comunicación.<br/>";
                }
                if (Mim.Validad_Llenado_detalle(8, DMI) == false)
                {
                    v.Verificar = true; v.Mensaje += "Debe de Ingresar Información del tipo de notas.<br/>";
                }
            }
             return v;
        }
        private void Vacio() 
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
        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            int Producto = DMI.Id_ProductoVerificable;                   
            if((Producto == 35) || (Producto == 45) || (Producto == 37) || 
               (Producto == 38) || (Producto == 42) || (Producto == 43))
            {
                Validar_Data v;
                v = Verificar_VaciosSalida();
                if (v.Verificar)
                {
                    MensajePantalla(v.Mensaje);
                }
                else
                {
                    Vacio();
                }
            }
            else 
            {
                Vacio();
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
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 13 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
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
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonB").Display = VPC.ShowHideProductoCulturaForestal(Producto, 1);//Comunida Linguistica
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoCulturaForestal(Producto, 1);//Grupo Etario
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoCulturaForestal(Producto, 2);//Notas
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonE").Display = VPC.ShowHideProductoCulturaForestal(Producto, 4);//tipo de publicidad
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonF").Display = VPC.ShowHideProductoCulturaForestal(Producto, 3);//publico
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonG").Display = VPC.ShowHideProductoCulturaForestal(Producto, 3);//material
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonH").Display = VPC.ShowHideProductoCulturaForestal(Producto, 5);//Campaña
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonI").Display = VPC.ShowHideProductoCulturaForestal(Producto, 5);//tipo de notas
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
            RadDocumentoVerificacion.FileUploaded += new FileUploadedEventHandler(RadDocumentoVerificacion_FileUploaded);
            /**/
            CboNotas.TextChanged += new EventHandler(CboNotas_TextChanged);
            BtnRegresarModulo3.Click += new EventHandler(BtnRegresarModulo3_Click);
            BtnGuardarNotas.Click += new EventHandler(BtnGuardarNotas_Click);
            GrdNotas.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdNotas);
            GrdNotas.NeedDataSource += new GridNeedDataSourceEventHandler(GrdNotas_NeedDataSource);
            GrdNotas.PreRender += new EventHandler(GrdNotas_PreRender);
            /**/
            CboPublicidad.TextChanged += new EventHandler(CboPublicidad_TextChanged);
            BtnRegresarModulo4.Click += new EventHandler(BtnRegresarModulo4_Click);
            BtnGuardarPublicidad.Click += new EventHandler(BtnGuardarPublicidad_Click);
            GrdPublicidad.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdPublicidad);
            GrdPublicidad.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPublicidad_NeedDataSource);
            GrdPublicidad.PreRender += new EventHandler(GrdPublicidad_PreRender);
            /**/
            CboPublico.TextChanged += new EventHandler(CboPublico_TextChanged);
            BtnRegresarModulo5.Click += new EventHandler(BtnRegresarModulo5_Click);
            BtnGuardarPublico.Click += new EventHandler(BtnGuardarPublico_Click);
            GrdPublico.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdPublico);
            GrdPublico.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPublico_NeedDataSource);
            GrdPublico.PreRender += new EventHandler(GrdPublico_PreRender);
            /**/
            CboTipoMaterial.TextChanged += new EventHandler(CboTipoMaterial_TextChanged);
            CboMaterial.TextChanged += new EventHandler(CboMaterial_TextChanged);
            BtnRegresarModulo6.Click += new EventHandler(BtnRegresarModulo6_Click);
            BtnGuardarMaterial.Click += new EventHandler(BtnGuardarMaterial_Click);
            GrdMaterial.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdMaterial);
            GrdMaterial.NeedDataSource += new GridNeedDataSourceEventHandler(GrdMaterial_NeedDataSource);
            GrdMaterial.PreRender += new EventHandler(GrdMaterial_PreRender);
            /**/
            CboCampaniaPub.TextChanged += new EventHandler(CboCampaniaPub_TextChanged);
            BtnRegresarModulo7.Click += new EventHandler(BtnRegresarModulo7_Click);
            BtnGuardarCampania.Click += new EventHandler(BtnGuardarCampania_Click);
            GrdCampaniaPub.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdCampaniaPub);
            GrdCampaniaPub.NeedDataSource += new GridNeedDataSourceEventHandler(GrdCampaniaPub_NeedDataSource);
            GrdCampaniaPub.PreRender += new EventHandler(GrdCampaniaPub_PreRender);
            /**/
            CbotipoNotasPosiNega.TextChanged += new EventHandler(CbotipoNotasPosiNega_TextChanged);
            CboNotasPosiNega.TextChanged += new EventHandler(CboNotasPosiNega_TextChanged);
            BtnRegresarModulo8.Click += new EventHandler(BtnRegresarModulo8_Click);
            BtnGuardarNotasPosiNega.Click += new EventHandler(BtnGuardarNotasPosiNega_Click);
            GrdNotasPosiNega.DeleteCommand += new GridCommandEventHandler(Eliminar_ItemsGrdNotasPosiNega);
            GrdNotasPosiNega.NeedDataSource += new GridNeedDataSourceEventHandler(GrdNotasPosiNega_NeedDataSource);
            GrdNotasPosiNega.PreRender += new EventHandler(GrdNotasPosiNega_PreRender);
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 67).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoCulturaForestal Generico = new EncabezadoCulturaForestal();
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
            Generico.NombreEvento = txtNombreEvento.Text.ToString();                                             
            Generico.Id_TipoEvento = procesos.IntNULLCombo(CboTipoEvento);
            Generico.Id_Campania = procesos.IntNULLCombo(CboCampania);
            Generico.TemaONombreEntidad = txttema.Text.ToString();                        
            Generico.MediosParticipantes = txtmedioParticipante.Text.ToString();
            Generico.Id_TemaAtendido = procesos.IntNULLCombo(CboTemaAtendido);                       
            Generico.NombredelMaterial = txtNombreMaterial.Text.ToString();                                                                   
            Generico.NombreMediosComunicacion = txtnombreMeioComunicacion.Text.ToString();                        
            Generico.TemaAbordado = txtTemaAbordado.Text.ToString();           
            Generico.PeriodoPublicidadInicio = procesos.Fechas(txtFechaInicio);
            Generico.PeriodoPublicidadFinal= procesos.Fechas(txtFechaFinal);
            Generico.Id_TipoApoyo = procesos.IntNULLCombo(CboTipoApoyo);
            Generico.NombreEntidad = txtnombreEntidad.Text.ToString();                                                                           
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

            v = Validar.Campos_Obligatorio_CulturaForestal(Generico, RadDocumentoVerificacion, DMI,Mantenimiento);
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
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoEncabezadoCulturaForestal(Generico);

                if (Mim.GuardarItemEncabezado(11, DMI, DescripcionProducto, ref er))
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
                if (Mim.Eliminacion_Producto(14, edm, ref er))
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
            if (e.CommandName == "Select3")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                Notas.Visible = true;
                procesos.LLenarComboT(CboNotas, "SELECT Id_Notas Id,Descripcion FROM Tipo_Notas WHERE Estado = 1", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarNOtas();
                Llave = 1;
            }
            if (e.CommandName == "Select4")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                Publicidad.Visible = true;
                procesos.LLenarComboT(CboPublicidad, "SELECT Id_TipoPublicidad Id,Descripcion FROM Tipo_Publicidad WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarPublicidad();
                Llave = 1;
            }
            if (e.CommandName == "Select5")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                Publico.Visible = true;
                procesos.LLenarComboT(CboPublico, "SELECT Id_Publico Id,Descripcion FROM PublicoDirigidoCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarPublico();
                Llave = 1;
            }
            if (e.CommandName == "Select6")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                Material.Visible = true;
                procesos.LLenarComboT(CboTipoMaterial, "SELECT Id_TipoMaterial Id,Descripcion FROM Tipo_Material WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarMaterial();
                Llave = 1;
            }
            if (e.CommandName == "Select7")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                CampaniaPub.Visible = true;
                procesos.LLenarComboT(CboCampaniaPub, "SELECT Id_Campania Id,Descripcion FROM CampaniaCulturaF WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarCampania();
                Llave = 1;
            }
            if (e.CommandName == "Select8")
            {
                Encabezado.Visible = false;
                GrdIngresoEncabezado.Visible = false;
                NotasPosiNega.Visible = true;
                procesos.LLenarComboT(CbotipoNotasPosiNega, "SELECT Id_TipoNota Id,Descripcion FROM Tipo_Nota2 WHERE Estado = 1;", "Descripcion", "Id", true);
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                NotasPosiNegas();
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
                R7.Visible = false;               
                string Largo = "450";
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());             

                if (Producto == 45)
                {
                    R5.Visible = true;
                    R6.Visible = true;
                    R7.Visible = true;
                    Label39.Text = "Tema";
                    LtEvento.Text = item.GetDataKeyValue("TipoEvento").ToString();
                    LNomevento.Text = item.GetDataKeyValue("NombreEvento").ToString();
                    Ltema.Text = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    LtCamapnia.Text = item.GetDataKeyValue("Campania").ToString();
                    Lmparticipante.Text = item.GetDataKeyValue("MediosParticipantes").ToString();
                    Largo = "550";

                }
                if (Producto == 35)
                {
                    R3.Visible = true;
                    Ltatendido.Text = item.GetDataKeyValue("TemaAtendido").ToString();
                }               
                if (Producto == 38)
                {
                    R2.Visible = true;
                    Lnmaterial.Text = item.GetDataKeyValue("NombredelMaterial").ToString();
                }
                if ((Producto == 39) || (Producto == 40))
                {
                    R5.Visible = true;
                    R6.Visible = true;
                    Label39.Text = "Tema";
                    LtEvento.Text = item.GetDataKeyValue("TipoEvento").ToString();
                    LNomevento.Text = item.GetDataKeyValue("NombreEvento").ToString();
                    Ltema.Text = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    LtCamapnia.Text = item.GetDataKeyValue("Campania").ToString();
                    Largo = "550";
                }
                if (Producto == 41)
                {
                    R4.Visible = true;
                    LnombremedioC.Text = item.GetDataKeyValue("NombreMediosComunicacion").ToString();
                    LtemaAbordado.Text = item.GetDataKeyValue("TemaAbordado").ToString();
                }
                if (Producto == 42)
                {
                    R1.Visible = true;
                    R6.Visible = true;
                    Label39.Text = "Tema";
                    Lfinicio.Text = item.GetDataKeyValue("PeriodoPublicidadInicio").ToString();
                    Lffinal.Text = item.GetDataKeyValue("PeriodoPublicidadFinal").ToString();
                    Ltapoyo.Text = item.GetDataKeyValue("TipoApoyo").ToString();
                    Lnentidad.Text = item.GetDataKeyValue("NombreEntidad").ToString();
                    Ltema.Text = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    LtCamapnia.Text = item.GetDataKeyValue("Campania").ToString();
                    Largo = "550";
                }                                                                
                if (Producto == 44)
                {
                    R6.Visible = true;
                    Label39.Text = "Nombre de la Entidad con la" + Environment.NewLine + "que se Realizo el Acuerdo";
                    Ltema.Text = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    LtCamapnia.Text = item.GetDataKeyValue("Campania").ToString();
                    Largo = "500";
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
        /**/
        private void RecargarCampania()
        {
            GrdCampaniaPub.Rebind();
            if (GrdCampaniaPub.Items.Count == 0)
            {
                GrdCampaniaPub.Visible = false;
            }
            else
            {
                GrdCampaniaPub.Visible = true;
            }
        }
        private void RecargarMaterial()
        {
            GrdMaterial.Rebind();
            if (GrdMaterial.Items.Count == 0)
            {
                GrdMaterial.Visible = false;
            }
            else
            {
                GrdMaterial.Visible = true;
            }
        }
        private void RecargarPublico()
        {
            GrdPublico.Rebind();
            if (GrdPublico.Items.Count == 0)
            {
                GrdPublico.Visible = false;
            }
            else
            {
                GrdPublico.Visible = true;
            }
        }
        private void RecargarPublicidad()
        {
            GrdPublicidad.Rebind();
            if (GrdPublicidad.Items.Count == 0)
            {
                GrdPublicidad.Visible = false;
            }
            else
            {
                GrdPublicidad.Visible = true;
            }
        }
        private void RecargarNOtas()
        {
            GrdNotas.Rebind();
            if (GrdNotas.Items.Count == 0)
            {
                GrdNotas.Visible = false;
            }
            else
            {
                GrdNotas.Visible = true;
            }
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
        private void NotasPosiNegas()
        {
            GrdNotasPosiNega.Rebind();
            if (GrdNotasPosiNega.Items.Count == 0)
            {
                GrdNotasPosiNega.Visible = false;
            }
            else
            {
                GrdNotasPosiNega.Visible = true;
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
        private void CboNotasPosiNega_TextChanged(object sender, EventArgs e)
        {
            txtNotasPosiNega.Text = string.Empty;
            txtNotasPosiNega.ReadOnly = false;
        }
        private void CboMaterial_TextChanged(object sender, EventArgs e)
        {
            txtCantidadMaterial.Text = string.Empty;
            txtCantidadMaterial.ReadOnly = false;
        }
        private void CbotipoNotasPosiNega_TextChanged(object sender, EventArgs e)
        {
            txtNotasPosiNega.Text = string.Empty;
            txtNotasPosiNega.ReadOnly = true;
            CboNotasPosiNega.ClearSelection();
            CboNotasPosiNega.Enabled = true;
            lbtNotasPosiNega.Text = procesos.StrNULLCombo(CbotipoNotasPosiNega);
            string CadenaSQl = "SELECT Id_Nota Id,Descripcion FROM NotaCulturaF WHERE Estado = 1 AND Id_TipoNota = " + procesos.IntNULLCombo(CbotipoNotasPosiNega).ToString();
            procesos.LLenarComboT(CboNotasPosiNega, CadenaSQl, "Descripcion", "Id", true);
        }
        private void CboTipoMaterial_TextChanged(object sender, EventArgs e)
        {
            txtCantidadMaterial.Text = string.Empty;
            txtCantidadMaterial.ReadOnly = true;
            CboMaterial.ClearSelection();
            CboMaterial.Enabled = true;
            lbtituloMaterial.Text = procesos.StrNULLCombo(CboTipoMaterial); 
            string CadenaSQl = "SELECT Id_Material Id,Descripcion FROM MaterialCulturaF WHERE Estado = 1 AND Id_TipoMaterial = " + procesos.IntNULLCombo(CboTipoMaterial).ToString();
            procesos.LLenarComboT(CboMaterial, CadenaSQl, "Descripcion", "Id", true);            
        }
        private void CboCampaniaPub_TextChanged(object sender, EventArgs e)
        {
            txtCampaniaPub.ReadOnly = false;
            txtCampaniaPub.Text = string.Empty;
        }
        private void CboPublico_TextChanged(object sender, EventArgs e)
        {
            txtCantidadPublico.ReadOnly = false;
            txtCantidadPublico.Text = string.Empty;
        }
        private void CboPublicidad_TextChanged(object sender, EventArgs e)
        {
            txtCantidadPublicidad.ReadOnly = false;
            txtCantidadPublicidad.Text = string.Empty;
        }
        private void CboNotas_TextChanged(object sender, EventArgs e)
        {
            txtCantidadNotas.ReadOnly = false;
            txtCantidadNotas.Text = string.Empty;
        }
        private void CboComunidad_TextChanged(object sender, EventArgs e)
        {
            txtNumeroPersonasL.ReadOnly = false;
            txtNumeroPersonasL.Text = string.Empty;
        }
        private void Vaciar() 
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            ActoresTipos.Visible = false;
            CboComunidad.ClearSelection();
            txtNumeroPersonasL.Text = string.Empty;
            txtNumeroPersonasL.ReadOnly = true;
        }
        protected void BtnRegresarModulo8_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            NotasPosiNega.Visible = false;
            CbotipoNotasPosiNega.ClearSelection();
            CboNotasPosiNega.ClearSelection();
            CboNotasPosiNega.Enabled = false;
            txtNotasPosiNega.Text = string.Empty;
            txtNotasPosiNega.ReadOnly = true;
        }
        protected void BtnRegresarModulo6_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            Material.Visible = false;
            CboTipoMaterial.ClearSelection();
            CboMaterial.ClearSelection();
            CboMaterial.Enabled = false; 
            txtCantidadMaterial.Text = string.Empty;
            txtCantidadMaterial.ReadOnly = true;
        }
        protected void BtnRegresarModulo7_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            CampaniaPub.Visible = false;
            CboCampaniaPub.ClearSelection();
            txtCampaniaPub.Text = string.Empty;
            txtCampaniaPub.ReadOnly = true;
        }
        protected void BtnRegresarModulo5_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            Publico.Visible = false;
            CboPublico.ClearSelection();
            txtCantidadPublico.Text = string.Empty;
            txtCantidadPublico.ReadOnly = true;
        }
        protected void BtnRegresarModulo4_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            Publicidad.Visible = false;
            CboPublicidad.ClearSelection();
            txtCantidadPublicidad.Text = string.Empty;
            txtCantidadPublicidad.ReadOnly = true;
        }
        protected void BtnRegresarModulo3_Click(object sender, EventArgs e)
        {
            Encabezado.Visible = true;
            GrdIngresoEncabezado.Visible = true;
            Notas.Visible = false;
            CboNotas.ClearSelection();
            txtCantidadNotas.Text = string.Empty;
            txtCantidadNotas.ReadOnly = true;
        }
        protected void BtnRegresarModulo1_Click(object sender, EventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            int Producto = DMI.Id_ProductoVerificable;

            if (Producto == 35) 
            {
                Validar_Data v;
                v = Verificar_VaciosSalidaDetalle(5);
                if (v.Verificar)
                {
                    MensajePantalla(v.Mensaje);
                }
                else
                {
                    Vaciar();
                }
            }
            if (Producto == 45)
            {
                Vaciar();
            }            
        }
        protected void BtnGuardarCampania_Click(object sender, EventArgs e)
        {
            Detalle7CulturaForestal Generico = new Detalle7CulturaForestal();
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
            Generico.Id_Campania = procesos.IntNULLCombo(CboCampaniaPub);
            Generico.Cantidad = procesos.STRRadNumericTextBox(txtCampaniaPub);

            v = X.Verificar_PublicidadCF7(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal7(Generico);
                if (Mim.GuardarItemDetalle(13, DMI, DescripcionProducto, ref er))
                {
                    RecargarCampania();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void BtnGuardarNotasPosiNega_Click(object sender, EventArgs e)
        {
            Detalle8CulturaForestal Generico = new Detalle8CulturaForestal();
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
            Generico.Id_TipoNota = procesos.IntNULLCombo(CbotipoNotasPosiNega);
            Generico.Id_Nota  = procesos.IntNULLCombo(CboNotasPosiNega);
            Generico.Cantidad = procesos.STRRadNumericTextBox(txtNotasPosiNega);

            v = X.Verificar_PublicidadCF8(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal8(Generico);
                if (Mim.GuardarItemDetalle(14, DMI, DescripcionProducto, ref er))
                {
                    NotasPosiNegas();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void BtnGuardarMaterial_Click(object sender, EventArgs e)
        {
            Detalle6CulturaForestal Generico = new Detalle6CulturaForestal();
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
            Generico.Id_TipoMaterial = procesos.IntNULLCombo(CboTipoMaterial);
            Generico.Id_Material = procesos.IntNULLCombo(CboMaterial);
            Generico.Cantidad = procesos.STRRadNumericTextBox(txtCantidadMaterial);

            v = X.Verificar_PublicidadCF6(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal6(Generico);
                if (Mim.GuardarItemDetalle(12, DMI, DescripcionProducto, ref er))
                {
                    RecargarMaterial();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void BtnGuardarPublico_Click(object sender, EventArgs e)
        {
            Detalle5CulturaForestal Generico = new Detalle5CulturaForestal();
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
            Generico.Id_Publico= procesos.IntNULLCombo(CboPublico);
            Generico.Cantidad = procesos.STRRadNumericTextBox(txtCantidadPublico);

            v = X.Verificar_PublicidadCF5(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal5(Generico);
                if (Mim.GuardarItemDetalle(11, DMI, DescripcionProducto, ref er))
                {
                    RecargarPublico();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void BtnGuardarPublicidad_Click(object sender, EventArgs e)
        {
            Detalle4CulturaForestal Generico = new Detalle4CulturaForestal();
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
            Generico.Id_TipoPublicidad = procesos.IntNULLCombo(CboPublicidad);
            Generico.Cantidad = procesos.STRRadNumericTextBox(txtCantidadPublicidad);

            v = X.Verificar_PublicidadCF(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal4(Generico);
                if (Mim.GuardarItemDetalle(10, DMI, DescripcionProducto, ref er))
                {
                   RecargarPublicidad();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void BtnGuardarNotas_Click(object sender, EventArgs e)
        {
            Detalle3CulturaForestal Generico = new Detalle3CulturaForestal();
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
            Generico.Id_Notas = procesos.IntNULLCombo(CboNotas);
            Generico.NumeroNotas = procesos.STRRadNumericTextBox(txtCantidadNotas);

            v = X.Verificar_NotasCF(Generico);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoCulturaForestal3(Generico);
                if (Mim.GuardarItemDetalle(9, DMI, DescripcionProducto, ref er))
                {
                    RecargarNOtas();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
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
        protected void Eliminar_ItemsGrdCampaniaPub(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(13, edm, ref er))
            {
              RecargarCampania();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Eliminar_ItemsGrdNotasPosiNega(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(14, edm, ref er))
            {
                NotasPosiNegas();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Eliminar_ItemsGrdMaterial(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(12, edm, ref er))
            {
                RecargarMaterial();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Eliminar_ItemsGrdPublico(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(11, edm, ref er))
            {
                RecargarPublico();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Eliminar_ItemsGrdPublicidad(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(10, edm, ref er))
            {
               RecargarPublicidad();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Eliminar_ItemsGrdNotas(object source, GridCommandEventArgs e)
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

            if (Mim.Eliminacion_DatosExtra(9, edm, ref er))
            {
               RecargarNOtas();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void GrdNotasPosiNega_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 14 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdNotasPosiNega, CadenaSql);
        }
        protected void GrdMaterial_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 12 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdMaterial, CadenaSql);
        }
        protected void GrdCampaniaPub_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 13 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdCampaniaPub, CadenaSql);
        }
        protected void GrdPublico_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 11 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPublico, CadenaSql);
        }
        protected void GrdPublicidad_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 10 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPublicidad, CadenaSql);
        }
        protected void GrdNotas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 9 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdNotas, CadenaSql);
        }
        protected void GrdActores_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 7 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdActores, CadenaSql);
        }
        private void GrdNotas_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdNotas.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Notas"].Text == gridDataItem3["Id_Notas"].Text)
                    {
                        gridDataItem2["Notas"].RowSpan = gridDataItem3["Notas"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Notas"].RowSpan + 1;
                        gridDataItem3["Notas"].Visible = false;
                    }
                }
            }
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
        private void GrdNotasPosiNega_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdNotasPosiNega.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoNota"].Text == gridDataItem3["Id_TipoNota"].Text)
                    {
                        gridDataItem2["TipoNota"].RowSpan = gridDataItem3["TipoNota"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoNota"].RowSpan + 1;
                        gridDataItem3["TipoNota"].Visible = false;
                    }
                }
            }
        }
        private void GrdMaterial_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdMaterial.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoMaterial"].Text == gridDataItem3["Id_TipoMaterial"].Text)
                    {
                        gridDataItem2["TipoMaterial"].RowSpan = gridDataItem3["TipoMaterial"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoMaterial"].RowSpan + 1;
                        gridDataItem3["TipoMaterial"].Visible = false;
                    }
                }
            }
        }
        private void GrdCampaniaPub_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdCampaniaPub.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Campania"].Text == gridDataItem3["Id_Campania"].Text)
                    {
                        gridDataItem2["Campania"].RowSpan = gridDataItem3["Campania"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Campania"].RowSpan + 1;
                        gridDataItem3["Campania"].Visible = false;
                    }
                }
            }
        }
        private void GrdPublico_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPublico.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Publico"].Text == gridDataItem3["Id_Publico"].Text)
                    {
                        gridDataItem2["Publico"].RowSpan = gridDataItem3["Publico"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Publico"].RowSpan + 1;
                        gridDataItem3["Publico"].Visible = false;
                    }
                }
            }
        }
        private void GrdPublicidad_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPublicidad.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoPublicidad"].Text == gridDataItem3["Id_TipoPublicidad"].Text)
                    {
                        gridDataItem2["TipoPublicidad"].RowSpan = gridDataItem3["TipoPublicidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoPublicidad"].RowSpan + 1;
                        gridDataItem3["TipoPublicidad"].Visible = false;
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
        private void Vaciar2() 
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
        private void CboGrupoEtario_TextChanged(object sender, EventArgs e)
        {
            txtNumeroPersonasEtario.ReadOnly = false;
            txtNumeroPersonasEtario.Text = string.Empty;
        }
        protected void BtnRegresarModulo2_Click(object sender, EventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            int Producto = DMI.Id_ProductoVerificable;

            if (Producto == 35)
            {
                Validar_Data v;
                v = Verificar_VaciosSalidaDetalle(2);
                if (v.Verificar)
                {
                    MensajePantalla(v.Mensaje);
                }
                else
                {
                    Vaciar2();
                }
            }
            if (Producto == 45)
            {
                Vaciar2();
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