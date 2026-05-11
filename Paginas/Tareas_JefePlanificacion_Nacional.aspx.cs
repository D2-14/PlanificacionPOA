using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Tareas_JefePlanificacion_Nacional : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public UsuarioValida Users = new UsuarioValida();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void RadSearchBoxActividad_Search(object sender, SearchBoxEventArgs e)
        {
            string supplierID = string.Empty;

            if (e.Text != string.Empty)
            {
                supplierID = e.Value;
            }
            else
            {
                supplierID = string.Empty;
            }

            Session["CadenaBusqueda"] = supplierID;
            VerificargRIDActividades();
        }
        protected string LlenarBusqueda()
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string stringslq = string.Empty; 

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",1";
            }
            return stringslq;            
        }
        protected void GRDSubregiones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GRDSubregiones, Grid());
        }
        protected void CerrarVentanaMensaje_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajeDUP, "Key6");
        }
        protected void btncerrarVentanaMetas_Click(object sender, EventArgs e)
        {
            txtAprobacionpoa.Text = string.Empty;
            CloseWinwdows(AprobarPOA, "Key2");
        }
        protected void CerrarVentanaDenegar_Click(object sender, EventArgs e)
        {
            txtmensajeDenegado.Text = string.Empty;
            chkRedProgramatica.Checked = false;
            CloseWinwdows(DenegarMetas, "Key3");
        }
        protected void btnCancelarconfiguarcionUM_Click(object sender, EventArgs e) 
        {
            CboUnidadMedidaEvaludada.ClearSelection();
            CloseWinwdows(ConfigurarUM, "Key10");
        }
        protected void Btnaprobarmetas_Click(object sender, EventArgs e)
        {
            Entrada_Sistema es = new Entrada_Sistema();
            Envio_Correos Correo = new Envio_Correos();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info51"];
            Datos_AprobacionPoa co = (Datos_AprobacionPoa)Session["Correo"];
            Dt.Instrucciones = txtAprobacionpoa.Text.Trim();
            co.Instrucciones = Dt.Instrucciones;

            if (x.Aprobar_tareaJefePlanificacionNacional(Dt, ref er))
            {
                txtAprobacionpoa.Text = string.Empty;
                CloseWinwdows(AprobarPOA, "Key4");
                VerificargRID();

                if (Dt.TipoAsignacion == 1)
                {
                    MensajePantalla("Se aprobo la tarea del POA del Departamento, Unidad, Parque Nacional");
                    try
                    {
                        co.Destinatario = es.ExtraerCorreo(co.SubRegion);
                        if (Correo.Enviar_Correo_Aprobado(co)) { }
                    }
                    catch { }
                }
                else 
                {
                    MensajePantalla("Se Revisaron las ediciones al POA del Departamento, Unidad, Parque Nacional");
                }               
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void BtnDenegar_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info5"];
            Dt.Instrucciones = txtmensajeDenegado.Text.Trim();

            if ((Dt.Instrucciones == string.Empty) || (Dt.Instrucciones.Length == 0))
            {
                MensajePantalla("Debe ingresar las observaciones de la denegación de metas");
            }
            else
            {
                if (x.Denegar_tareaAJefePlanificacionNacional(Dt, ref er))
                {
                    txtmensajeDenegado.Text = string.Empty;
                    VerificargRID();
                    Session["CambiosIngreso"] = 1;
                    CloseWinwdows(DenegarMetas, "Key3");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            ApartadodeMetas.Visible = false;
            GRDSubregiones.Visible = true;
            GRDSubregiones.Rebind();            
            VerificargRID();           
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_Nacional " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";
            procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
        }
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
        }
        private void GdrDatosdeActividades_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrDatosdeActividades.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_producto"].Text == gridDataItem3["Id_producto"].Text)
                    {
                        gridDataItem2["DescripcionProducto"].RowSpan = gridDataItem3["DescripcionProducto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionProducto"].RowSpan + 1;
                        gridDataItem3["DescripcionProducto"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubProducto"].Text != "1")
                    {
                        if (gridDataItem2["Id_SubProducto"].Text == gridDataItem3["Id_SubProducto"].Text)
                        {
                            gridDataItem2["DescripcionSubProducto"].RowSpan = gridDataItem3["DescripcionSubProducto"].RowSpan < 2
                            ? 2
                            : gridDataItem3["DescripcionSubProducto"].RowSpan + 1;
                            gridDataItem3["DescripcionSubProducto"].Visible = false;
                        }
                    }
                }
            }
        }
        protected int VerificarCheck()
        {
            int Valor = 0;

            if (chkRedProgramatica.Checked == true)
            {
                Valor = 1;
            }
            else
            {
                Valor = 0;
            }
            return Valor;
        }
        private bool Valor2(int op)
        {
            bool v = false;
            if (op != 0) { return true; }

            return v;
        }
       protected void btnGuardarConfiguracionUM_Click(object sender, EventArgs e)
       {
            GuardaMetasNacional gms = new GuardaMetasNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ian.Id_PoAnual;
            gms.Id_SubRegion = Ian.Id_SubRegion;
            gms.Correlativo_Configuracion = Ian.Correlativo_Configuracion;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
            gms.RedProgramatica = VerificarCheck();
            gms.Id_Unidad_Evaluada = procesos.IntNULLCombo(CboUnidadMedidaEvaludada); 

            if (x.ConfiguracionUMMetasNacionales(gms, ref er))
            {
                MensajePantalla("Se ha agregado el valor Correctamente...");
                chkRedProgramatica.Checked = false;
                CboUnidadMedidaEvaludada.ClearSelection();
                GdrDatosdeActividades.Rebind();
                CloseWinwdows(ConfigurarUM, "Key10");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }          
       }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {           
            InformacionActividadesNacionales Ian = new InformacionActividadesNacionales();
            DatosTarea Dt = (DatosTarea)Session["info5"];
            GridDataItem item = e.Item as GridDataItem;
            int Llave = 0;

            if (e.CommandName == "Select")
            {
                Ian.Id_PoAnual = Dt.Id_PoAnual;
                Ian.Correlativo_Configuracion = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                Ian.Id_Producto = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
                Ian.Id_SubProducto = Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString());
                Ian.Id_Actividad = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
                Ian.Id_SubRegion = Dt.Id_SubRegion;
                Ian.RedProgramatica = Convert.ToInt32(item.GetDataKeyValue("Id_MetasRedProgramatica").ToString()); 
                Ian.Id_Unidad_Evaluada = Convert.ToInt32(item.GetDataKeyValue("Id_Unidad_Evaluada").ToString());
                Ian.DescripcionProducto = item.GetDataKeyValue("DescripcionProducto").ToString();
                Ian.DescripcionSubProducto = item.GetDataKeyValue("DescripcionSubProducto").ToString();
                Ian.DescripcionActividad = item.GetDataKeyValue("DescripcionActividad").ToString();
                Ian.DUM1 = item.GetDataKeyValue("DescripcionUM1").ToString();
                Ian.DUM2 = item.GetDataKeyValue("DescripcionUM2").ToString();
                Ian.DUM3 = item.GetDataKeyValue("DescripcionUM3").ToString();
                Ian.idDUM1 = Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString());
                Ian.idDUM2 = Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString());
                Ian.idDUM3 = Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString());
                Ian.TipoAsignacion = Dt.TipoAsignacion;
                RUM1.Visible = Valor2(Ian.idDUM1);
                RUM1T.Visible = Valor2(Ian.idDUM1);
                RUM2.Visible = Valor2(Ian.idDUM2);
                RUM2T.Visible = Valor2(Ian.idDUM2);
                RUM3.Visible = Valor2(Ian.idDUM3);
                RUM3T.Visible = Valor2(Ian.idDUM3);

                if(Ian.Id_Unidad_Evaluada != 0) 
                {
                    CboUnidadMedidaEvaludada.SelectedValue = Ian.Id_Unidad_Evaluada.ToString();
                }
                if (Ian.RedProgramatica == 1)
                {
                    chkRedProgramatica.Checked = true;
                }
                else
                {
                    chkRedProgramatica.Checked = false;
                }

                if (Ian.Id_SubProducto == 1)
                {
                    subProdlbl.Visible = false;
                }
                else
                {
                    subProdlbl.Visible = true;
                }
                if (Ian.Id_Actividad == 1)
                {
                    Actividadlbl.Visible = false;
                }
                else
                {
                    Actividadlbl.Visible = true;
                }

                lblActividad.Text = Ian.DescripcionActividad;
                lblProducto.Text = Ian.DescripcionProducto;
                lblSubproducto.Text = Ian.DescripcionSubProducto;
                LblUM1.Text = Ian.DUM1;
                LblUM2.Text = Ian.DUM2;
                LblUM3.Text = Ian.DUM3;

                Llave = 1;
                Session["CargarMetasValor"] = Ian;
                OpenWinwdows(ConfigurarUM, "500", "600", "Key10", "Configuración UM");                
            }
            /*Abrir la ventana*/
            if (Llave == 0)
            {
                Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                VerificargRIDVentana();
            }
        }
        protected void VerificargRIDVentana()
        {
            GridUnidades.Rebind();
            if (GridUnidades.Items.Count != 0)
            {
                OpenWinwdows(VerIngresos, "500", "520", "Key", "Visualización de ingreso de Metas");
                GridUnidades.Visible = true;
            }
            else
            {
                MensajePantalla("- No Ingresado Información a esta Actividad -");
                GridUnidades.Visible = false;
            }
        }
        protected void VerificargRID()
        {
            GRDSubregiones.Rebind();
            if (GRDSubregiones.Items.Count != 0)
            {
                GRDSubregiones.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                GRDSubregiones.Visible = false;
                Respuesta.Visible = true;
            }
        }
        protected void VerificargRIDActividades()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0)
            {
                GdrDatosdeActividades.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                Respuesta.Visible = true;
                GdrDatosdeActividades.Visible = false;
            }
        }
        private void GRDSubregiones_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GRDSubregiones.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Region"].Text == gridDataItem3["Id_Region"].Text)
                    {
                        gridDataItem2["Nombre_Region"].RowSpan = gridDataItem3["Nombre_Region"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Nombre_Region"].RowSpan + 1;
                        gridDataItem3["Nombre_Region"].Visible = false;
                    }
                    if (gridDataItem2["IdMensaje"].Text == gridDataItem3["IdMensaje"].Text)
                    {
                        gridDataItem2["Etapa"].RowSpan = gridDataItem3["Etapa"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Etapa"].RowSpan + 1;
                        gridDataItem3["Etapa"].Visible = false;
                    }
                    if (gridDataItem2["Id_PoAnual"].Text == gridDataItem3["Id_PoAnual"].Text)
                    {
                        gridDataItem2["POA"].RowSpan = gridDataItem3["POA"].RowSpan < 2
                        ? 2
                        : gridDataItem3["POA"].RowSpan + 1;
                        gridDataItem3["POA"].Visible = false;
                    }
                    if (gridDataItem2["FechaDeEntrega"].Text == gridDataItem3["FechaDeEntrega"].Text)
                    {
                        gridDataItem2["FechaDeEntrega"].RowSpan = gridDataItem3["FechaDeEntrega"].RowSpan < 2
                        ? 2
                        : gridDataItem3["FechaDeEntrega"].RowSpan + 1;
                        gridDataItem3["FechaDeEntrega"].Visible = false;
                    }
                }
            }
        }
        protected void Seleccionar_SubregionTarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            Datos_AprobacionPoa co = new Datos_AprobacionPoa();

            if (e.CommandName == "Select")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.NombrePoa = item.GetDataKeyValue("POA").ToString();
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                Dt.dependecia = 2;
                T01.Text = Dt.NombrePoa;
                T02.Text = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                Dt.DescripcionSubregion = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                Session["info5"] = Dt;
                ApartadodeMetas.Visible = true;
                GRDSubregiones.Visible = false;
                VerificargRIDActividades();

                if (M.VerificarModificacionesNacionales(Dt) == true)
                {
                    VerificarCambios.Visible = true;
                    Session["info85"] = Dt;                   
                }
                else
                {
                  VerificarCambios.Visible = false;
                }              
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajeDUP, "500", "380", "Key6", "Mensajes");
            }
            if (e.CommandName == "Select2")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
               
                co.NombrePoa = item.GetDataKeyValue("POA").ToString();
                co.DescripcionSubregion = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                co.SubRegion = Dt.Id_SubRegion;

                Session["info51"] = Dt;
                Session["Correo"] = co;
                OpenWinwdows(AprobarPOA, "500", "390", "Key2", "Aprobar el POA");
            }
            if (e.CommandName == "Select3")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                Dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());

                Session["info5"] = Dt;
                OpenWinwdows(DenegarMetas, "500", "390", "Key3", "Observacion de Metas");
            }
            if (e.CommandName == "Select4")
            {
                Dt.Op = 1;
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Session["info50"] = Dt;
               
                 Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
            }
        }
        protected string Grid()
        {
            string CadenaSQL = "SELECT apn.Id_PoAnual,apn.IdMensaje,apn.Id_Region,apn.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA,"+
                               "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), apn.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), apn.FechaDeEntrega, 103) FechaDeEntrega,"+
                               "apn.EstadoDeAsignacion,r.Nombre_Region,SR.Subregion Nombre_SubRegion,apn.Instrucciones,apn.TipoAsignacion,isnull(apn.NoReprogramacion, 0) NoReprogramacion "+
                               "FROM AsignacionJefePlanificacionNacional apn INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = apn.Id_PoAnual INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = apn.IdMensaje "+
                               "INNER JOIN Region r ON r.Id_Region = apn.Id_Region INNER JOIN Subregion sr ON SR.Id_Subregion = apn.Id_Subregion "+
                               "WHERE apn.EstadoDeAsignacion = 1 ORDER BY r.Id_Region,SR.Id_Subregion;";
            return CadenaSQL;
        }
        protected void Inicializacion_Objetos()
        {
            GRDSubregiones.NeedDataSource += new GridNeedDataSourceEventHandler(GRDSubregiones_NeedDataSource);
            GRDSubregiones.PreRender += new EventHandler(GRDSubregiones_PreRender);
            GRDSubregiones.ItemCommand += new GridCommandEventHandler(Seleccionar_SubregionTarea);
            CerrarVentanaMensaje.Click += new EventHandler(CerrarVentanaMensaje_Click);
            btncerrarVentanaMetas.Click += new EventHandler(btncerrarVentanaMetas_Click);
            CerrarVentanaDenegar.Click += new EventHandler(CerrarVentanaDenegar_Click);
            btnaprobarmetas.Click += new EventHandler(Btnaprobarmetas_Click);
            btnDenegar.Click += new EventHandler(BtnDenegar_Click);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.PreRender += new EventHandler(GdrDatosdeActividades_PreRender);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            btnCancelarconfiguarcionUM.Click += new EventHandler(btnCancelarconfiguarcionUM_Click);
            btnGuardarConfiguracionUM.Click += new EventHandler(btnGuardarConfiguracionUM_Click);
            VerificarCambios.Click += new EventHandler(VerificarCambios_Click);
        }
        protected void VerificarCambios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificacionesPOANacional.aspx");
        }
        protected void Iniciar() 
        {
            VerificargRID();
            DatosTarea dt = new DatosTarea();
            Session["info5"] = dt;
            Session["d10"] = 0;
            Session["d1"] = 0;
            Session["CadenaBusqueda"] = string.Empty;
            procesos.LLenarComboT(CboUnidadMedidaEvaludada, "SELECT IdTipoUnidad AS id,DescripcionExtra AS Descripcion FROM Tipo_UnidadMedida", "Descripcion", "Id", true);
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 48).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            procesos.LLenarBusquedaT(RadSearchBoxActividad, LlenarBusqueda(), "Descripcion", "Id", true);
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VericarPermiso();
                Iniciar();
            }            
        }
        /*ventanas*/
        protected void CloseWinwdows(RadWindow Ventana, string Llave)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").close();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }        
    }
}