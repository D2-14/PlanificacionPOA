using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class MantenimientoPOAs : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public RadTab Pest2 = new RadTab();
        public RadTab Pest1 = new RadTab();     
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 400, 180, "Alerta", null);
                return;
            }
        }
        protected void Inicializacion_Objetos()
        {                            
            RadRegion.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegion.ItemCommand += new GridCommandEventHandler(RadRegion_ItemCommand);
            RadRegion.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);
            RadRegion.ItemDataBound += RadRegion_ItemDataBound;

            TareasFueraTiempo.NeedDataSource += new GridNeedDataSourceEventHandler(TareasFueraTiempo_NeedDataSource);           
            TareasFueraTiempo.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
            TareasFueraTiempoNacional.NeedDataSource += new GridNeedDataSourceEventHandler(TareasFueraTiempoNacional_NeedDataSource);
            TareasFueraTiempoNacional.ItemCommand += new GridCommandEventHandler(Seleccionar_TareaNacional);
            cerrarVentanaActivar.Click += new EventHandler(cerrarVentanaActivar_Click);

            CerrarVentanaTarea.Click += new EventHandler(CerrarVentanaTarea_Click);
            IniciarTarea.Click += new EventHandler(IniciarTarea_Click);

            CerrarVentanaTareanacionalEdicion.Click += new EventHandler(CerrarVentanaTareanacionalEdicion_Click);
            IniciarTareaNacionalEdicion.Click += new EventHandler(IniciarTareaNacionalEdicion_Click);
            /*Nacionales*/
            GRDNacionales.NeedDataSource += new GridNeedDataSourceEventHandler(GRDNacionales_NeedDataSource);
            GRDNacionales.ItemCommand += new GridCommandEventHandler(GRDNacionales_ItemCommand);
            GRDNacionales.DetailTableDataBind += new GridDetailTableDataBindEventHandler(GRDNacionales_DetailTableDataBind);
            GRDNacionales.ItemDataBound += GRDNacionales_ItemDataBound;

            SalirConfiguracionUM.Click += new EventHandler(SalirConfiguracionUM_Click);            
            RadActividadesUM.NeedDataSource += new GridNeedDataSourceEventHandler(RadActividadesUM_NeedDataSource);
            RadActividadesUM.PreRender += new EventHandler(RadActividadesUM_PreRender);
            RadActividadesUM.ItemCommand += new GridCommandEventHandler(RadActividadesUM_Actividad);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            btnCancelarconfiguarcionUM.Click += new EventHandler(btnCancelarconfiguarcionUM_Click);
            btnGuardarConfiguracionUM.Click += new EventHandler(btnGuardarConfiguracionUM_Click);
        }
        protected void SalirConfiguracionUM_Click(object sender, EventArgs e)
        {
            Titulo1.Visible = true;
            Nacionales.Visible = true;
            ConfigurarUM.Visible = false;
            Pest1 = ControladorTAb.FindTabByText("Poa Regional");
            Pest1.Visible = true;
        }
        protected void TareasFueraTiempo_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string Cadena = "EXEC Sp_Revision_TareasFueraTiempo "+ Dt.Id_PoAnual.ToString() +", "+ Dt.Id_Region.ToString() +","+ Dt.Id_SubRegion.ToString() +";";   
            procesos.LlenarRadGrid(TareasFueraTiempo,Cadena);
        }
        protected string ComboNacional()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 1;";
        }
        protected string Combo() 
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 2;";
        }
        protected void Poas_ItemsRequested2(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combo(), "Descripcion", "Id", true);
        }
        protected void LlenadoCombos() 
        {                                        
            procesos.LLenarComboT(CboUnidadMedidaEvaludada, "SELECT IdTipoUnidad AS id,DescripcionExtra AS Descripcion FROM Tipo_UnidadMedida", "Descripcion", "Id", true);
        }                      
        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {                       
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();            
            int Id;
            string Fechaextra; 

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")/*Activar y desactivar poas*/
            {
                DatosTarea Dt = (DatosTarea)Session["info2"];
                Id = Convert.ToInt32(item.GetDataKeyValue("Id").ToString());
                RadDatePicker Fecha = (RadDatePicker)item.FindControl("txtFechaEntrega");  
                Fechaextra = procesos.Fechas(Fecha);

                if (Fechaextra == string.Empty)
                {
                    MensajePantalla("Debe Ingresar la fecha");
                }
                else 
                {
                    if (x.ActivacióndeMetas(Dt,Id,Fechaextra, ref er))
                    {
                        MensajePantalla("Se Activaron las tareas pendientes");
                        TareasFueraTiempo.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void VerificargRIDT()
        {
            TareasFueraTiempo.Rebind();
            if (TareasFueraTiempo.Items.Count != 0)
            {
                TareasFueraTiempo.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                TareasFueraTiempo.Visible = false;
                Respuesta.Visible = true;
            }
        } 
        protected void PermisoInicio() 
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            PermisosPermitidos = PermisosUsuario.Permisos(Convert.ToInt32(Session["Usuario"].ToString()));
            Pest2 = ControladorTAb.FindTabByText("Poa Nacional");
            Pest2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,55).Permiso;
           
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 38).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Tabs() 
        {
            if (Convert.ToInt32(Session["ValorDevuelta"].ToString()) == 1)
            {
                ControladorTAb.Tabs[1].Selected = true;
                RadPageView pageview = (RadPageView)Paginas.FindPageViewByID("Nacional");
                pageview.Selected = true;
            }
            Session["ValorDevuelta"] = 0;
            EdicionManualNacional.Visible = false;
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            procesos.LLenarBusquedaT(RadSearchBoxActividad, LlenarBusqueda(), "Descripcion", "Id", true);
            procesos.LLenarBusquedaT(BusquedaEdicion, LlenarBusquedaEdicion(), "Descripcion", "Id", true);
            Inicializacion_Objetos();
            Inicializacion_Objetos2();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                DatosTarea dt = new DatosTarea();
                Session["info200"] = dt;
                Session["CargarMetasValor"] = Ris;
                Session["d1"] = 0;
                Session["info2"] = dt;
                Session["EnviadoTarea"] = 0;
                LlenadoCombos();
                PermisoInicio();
                ConfigurarUM.Visible = false;
                Session["CadenaBusqueda"] = string.Empty;
                VerificargRIDActividades();
                Tabs();
            }
        }
        protected void IniciarTarea_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea dt;
            dt = (DatosTarea)Session["info2"];
            dt.Instrucciones = txtmensaje.Text.Trim();
            dt.FechaEntrega = procesos.Fechas(txtFechaEntrega);

            if (dt.Instrucciones == string.Empty)
            {
                MensajePantalla("No a ingresado las instrucciones para el llenado del poa");
            }
            else
            {
                if (x.Inicializar_TareaPoaSubregionalEdicion(dt, ref er))
                {
                    MensajePantalla("Se inicio la tarea de edición Correctamente...");
                    txtmensaje.Text = string.Empty;
                    Session["EnviadoTarea"] = 1;
                    CloseWinwdows(InicioTarea, "Key");
                }
                else
                {
                    Session["EnviadoTarea"] = 0;
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(ActivacionTareas, "Key1");
        }
        protected void CerrarVentanaTarea_Click(object sender, EventArgs e)
        {
            txtmensaje.Text = string.Empty;
            CloseWinwdows(InicioTarea, "Key");
        }
        /*ventanas*/
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
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
        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
        /*seleccion de actividades para edicion*/
        protected void Inicializacion_Objetos2() 
        {
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.ItemDataBound += GdrDatosdeActividades_ItemDataBound;
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);            
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            btnenviar.Click += new EventHandler(Btnenviar_Click);

            GrdEdicionNacional.NeedDataSource += new GridNeedDataSourceEventHandler(GrdEdicionNacional_NeedDataSource);
            GrdEdicionNacional.PreRender += new EventHandler(GrdEdicionNacional_PreRender);
            GrdEdicionNacional.ItemCommand += new GridCommandEventHandler(Seleccionar_ActividadGrdEdicionNacional);                     
            RegresarMantenimiento.Click += new EventHandler(RegresarMantenimiento_Click);
            EdicionActividadesNacionalesEnviar.Click += new EventHandler(EdicionActividadesNacionalesEnviar_Click);
        }
        protected void Btnenviar_Click(object sender, EventArgs e)
        {           
            OpenWinwdows(InicioTarea, "500", "400", "Key", "Iniciar Tarea Edición");           
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {
            ItemEdit Actividad = new ItemEdit();         
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();

            if (e.CommandName == "Select")
            {                                                           
                Actividad.Id_Poa = Dt.Id_PoAnual;
                Actividad.Id_SubRegion = Dt.Id_SubRegion;
                Actividad.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());

                if (Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString()) == 0)
                {
                    if (x.AgregarActividadesEditar(Actividad,1, ref er))
                    {
                        MensajePantalla("Se Agrego..");
                        GdrDatosdeActividades.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }                  
                }
                else
                {
                    MensajePantalla("Es una Actividad No Planificable, NO es necesario editarla");
                }
            }
            if (e.CommandName == "Select1")
            {
                Actividad.Id_Poa = Dt.Id_PoAnual;
                Actividad.Id_SubRegion = Dt.Id_SubRegion;
                Actividad.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());

                if (item.GetDataKeyValue("Agregado").ToString() == "Agregado")
                {
                    if (x.AgregarActividadesEditar(Actividad, 2, ref er))
                    {
                        MensajePantalla("Se elimino...");
                        GdrDatosdeActividades.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void CargarData()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            T01.Text = Dt.NombrePoa;
            T02.Text = Dt.DescripcionSubregion;
            string StringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1;";
            procesos.LLenarComboT(CboComponente, StringComando, "Descripcion", "Id", true);
        }
        protected void VerificargRID2()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0)
            {
                GdrDatosdeActividades.Visible = true;
            }
            else
            {
                GdrDatosdeActividades.Visible = false;
            }
        }
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string Strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";
            CboSubcomponente.ClearSelection();
            VerificargRID2();
            procesos.LLenarComboT(CboSubcomponente, Strsub, "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];        
            Ris.Id_PoAnual = Dt.Id_PoAnual;
            Ris.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente));
            Ris.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente));
            Ris.Id_SubRegion = Dt.Id_SubRegion;
            Session["CargarMetasValor"] = Ris;
            VerificargRID2();
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(Session["EnviadoTarea"].ToString()) == 0) 
            {
                Mensajes_Error_BDD er = new Mensajes_Error_BDD();
                Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
                ItemEdit Actividad = new ItemEdit();
                DatosTarea Dt = (DatosTarea)Session["info2"];

                Actividad.Id_Poa = Dt.Id_PoAnual;
                Actividad.Id_SubRegion = Dt.Id_SubRegion;

                if (x.AgregarActividadesEditar(Actividad, 3, ref er))
                {                    
                    GdrDatosdeActividades.Rebind();
                }                
            }
            SeleccionITEM.Visible = false;
            Titulo1.Visible = true;
            CboComponente.ClearSelection();
            CboSubcomponente.ClearSelection();
            txtmensaje.Text = string.Empty;
            txtFechaEntrega.SelectedDate = DateTime.Now.Date;
            VerificargRID2();
        }       
        protected void GdrDatosdeActividades_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["DescripcionProductoVeficable"];
                
                if (Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString()) == 1)
                {
                    cell1.BackColor = Color.Aquamarine;
                    cell1.Font.Bold = true;                                     
                }
            }
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {                        
            RegresoInformacionSubregional Ris =(RegresoInformacionSubregional)Session["CargarMetasValor"];
            procesos.LlenarRadGrid(GdrDatosdeActividades,"EXEC Sp_obtener_data_Actividad_SubregionalEdit " + Ris.Id_PoAnual + "," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_SubRegion + ";");
        }        
        /*Reprogramacion*/
        protected void RadRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                string cadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1";
                procesos.LlenarRadGrid(RadRegion, cadenaSQl);
            }
        }
        protected void RadRegion_DetailTableDataBind(object source,GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 and Codigo_SubRegion >= 1 AND ISNULL(Nacional,0) <> 1  AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();                        
                        procesos.LlenarRadGrid(RadRegion, CadenaString);
                        break;
                    }
            }
        }
        protected void RadRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();            
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");

            if (e.CommandName == "Select")
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 42).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    comboBox.DataBind();
                    string Valor = comboBox.SelectedValue;
                    if (Valor == string.Empty)
                    {
                        Dt.Id_PoAnual = 0;
                    }
                    else
                    {
                        Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                    }
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA a editar Actividades");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text;
                            Dt.FechaEntrega = procesos.Fechas(txtFechaEntrega);
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        if (M.VerificarCarga2(Dt) == true)
                        {
                            Session["info2"] = Dt;
                            SeleccionITEM.Visible = true;
                            Titulo1.Visible = false;                            
                            CargarData();
                            VerificargRID2();
                            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
                            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
                            ItemEdit Actividad = new ItemEdit();                           
                            Actividad.Id_Poa = Dt.Id_PoAnual;
                            Actividad.Id_SubRegion = Dt.Id_SubRegion;

                            if (x.AgregarActividadesEditar(Actividad, 3, ref er))
                            {
                                GdrDatosdeActividades.Rebind();
                            }                           
                        }
                        else
                        {
                            MensajePantalla("Esta Subregión el poa no ha sido aprobado por el jefe de planificacion");
                        }                        
                    }
                }
            }
            if (e.CommandName == "Select1")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 43).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text; 
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        if (M.VerificarCarga(Dt) == true)
                        {
                            Session["info2"] = Dt;
                            Response.Redirect("EdicionDeMetasDSR.aspx");
                        }
                        else
                        {
                            MensajePantalla("Esta Subregión No tiene POA ingresado Todavia");
                        }
                    }
                }
            }
            if (e.CommandName == "Select2")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 44).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text; 
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        Session["info2"] = Dt;
                        VerificargRIDT();
                        OpenWinwdows(ActivacionTareas, "600", "420", "Key1", "Activación de Tareas");
                    }
                }
            }
            if (e.CommandName == "Select3")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    Session["info50"] = Dt;
                    Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarExcelPOA.aspx", "200", "200", "key5", "Exportar a excel POA");
                   // Exportar_Excel(ExportarEx, "../ExportarExcel/ExcelPOARegionalVariado.aspx", "200", "200", "key20", "Exportar a excel POA");
                }
            }
            if (e.CommandName == "Select4")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCargaModificaciones(Dt) == true)
                    {
                        Session["info85"] = Dt;
                        Response.Redirect("ModificacionesPOA.aspx");
                    }
                    else 
                    {
                        MensajePantalla("No tiene Modificaciones actualmente este Poa de la subregion");
                    }
                }
            }
        }
        /*Nacionales*/
        protected void GRDNacionales_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {                
                string CadenaSQl;

                //"and Id_Region IN(81, 140, 142, 92, 135, 136, 138, 137, 143, 90, 91, 82, 20,144,145,12,13,14,16,17,18,19,20,22) order by  r.Nombre_Region; ";
                CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                                "and Id_Region IN(81, 140, 142, 92, 135, 136, 138, 137, 143, 90, 91, 82, 20,12,13,14,16,17,18,19,20,22,147) order by  r.Nombre_Region; ";
                procesos.LlenarRadGrid(GRDNacionales, CadenaSQl);
            }
        }
        protected void GRDNacionales_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        int Region = Convert.ToInt32(dataItem.GetDataKeyValue("Id_Region").ToString());                         
                        if(Region == 13)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(76,77,78,508,94);";
                        }
                        else if (Region == 12)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(96,516);";
                        }
                        else if (Region == 14)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(95,509,502);";
                        }
                        else if(Region == 16) 
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(88,97,510);";
                        }
                        else if (Region == 17)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(99,511);";
                        }
                        else if (Region == 18)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(102,512,500);";
                        }
                        else if (Region == 19)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(101,513);";
                        }
                        else if(Region == 20)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(141,100,514);";
                        }
                        else if (Region == 22)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(144,515,501,504);";
                        }
                        else if (Region == 147)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(507,521,518);";
                        }
                        else 
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + " ORDER BY Subregion";
                        }                        
                        procesos.LlenarRadGrid(GRDNacionales, CadenaString);
                        break;
                    }
            }
        }       
        protected void GRDNacionales_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");

            if (e.CommandName == "Select")
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 56).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    comboBox.DataBind();
                    string Valor = comboBox.SelectedValue;
                    if (Valor == string.Empty)
                    {
                        Dt.Id_PoAnual = 0;
                    }
                    else
                    {
                        Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                    }
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA a editar Actividades");
                    }
                    else
                    {
                         if (e.Item.OwnerTableView.Name == "SubRegion")
                         {
                             Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                             Dt.NombrePoa = comboBox.Text;
                             Dt.FechaEntrega = procesos.Fechas(txtFechaEntrega);
                             Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                             Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                             Dt.DescripcionSubregion = item["Subregion"].Text;
                         }
                         if (M.VerificarCargaNacional(Dt) == true)
                         {
                             Session["info2"] = Dt;
                            EdicionManualNacional.Visible = true;                            
                            CargarDataEdicion();
                            VerificargRIDEdicionNacional();
                            Pest1 = ControladorTAb.FindTabByText("Poa Regional");
                            Pest1.Visible = false;
                            Nacionales.Visible = false;
                            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
                            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
                            ItemEdit Actividad = new ItemEdit();                            
                            Actividad.Id_Poa = Dt.Id_PoAnual;
                            Actividad.Id_SubRegion = Dt.Id_SubRegion;

                            if (x.AgregarActividadesEditarNacionalES(Actividad, 3, ref er))
                            {
                                GrdEdicionNacional.Rebind();
                            }
                         }
                         else
                         {
                             MensajePantalla("El POA no ha sido aprobado por el jefe de planificacion");
                         }
                    }
                }
            }
            if (e.CommandName == "Select1")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA");
                    }
                    else
                    {
                           if (e.Item.OwnerTableView.Name == "SubRegion")
                           {
                               Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                               Dt.NombrePoa = comboBox.Text;
                               Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                               Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                               Dt.DescripcionSubregion = item["Subregion"].Text;
                               Dt.TipoAsignacion = 0;
                           }
                           if (M.VerificarCargaNacional(Dt) == true)
                           {
                               Session["info2"] = Dt;
                               Response.Redirect("EdicionDeMetasDSRNacional.aspx");
                           }
                           else
                           {
                               MensajePantalla("Esta Subregión No tiene POA ingresado Todavia");
                           }
                    }
                }
            }
            if (e.CommandName == "Select2")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 55).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text;
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        Session["info2"] = Dt;
                        VerificargRIDT1();
                        OpenWinwdows(ActivacionTareasNacionales, "600", "420", "Key1", "Activación de Tareas Nacionales");
                    }
                }
            }
            //Columna para Descargar POA
            if (e.CommandName == "Select3")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Op = 2;
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCargaNacional(Dt) == true)
                    {
                        Session["info50"] = Dt;
                        Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
                        //Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional_Cuatrimestre.aspx", "200", "200", "key5", "Exportar a excel POA");
                    }
                    else 
                    {
                        MensajePantalla("No tiene datos en el poa");
                    }
                }
            }
            if (e.CommandName == "Select4")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                        Dt.dependecia = 1;
                    }
                    if (M.VerificarModificacionesNacionales(Dt) == true)
                    {
                        Session["info85"] = Dt;
                        Response.Redirect("ModificacionesPOANacional.aspx");
                    }
                    else
                    {
                        MensajePantalla("No tiene Modificaciones actualmente este Poa");
                    }
                }
            }
            if (e.CommandName == "Select5")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 59).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text;
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        Session["info200"] = Dt;
                        Response.Redirect("CatalogoPoaNacionalPlanificacion.aspx");
                    }
                }
            }
            if (e.CommandName == "Select6")
            {                
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }                               
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 60).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text;
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                        }
                        if (M.VerificarCargaNacional(Dt) == true)
                        {
                            tituloum.Text = Dt.NombrePoa;
                            titulosub.Text = Dt.DescripcionSubregion;
                            Session["info200"] = Dt;
                            Titulo1.Visible = false;
                            Nacionales.Visible = false;
                            ConfigurarUM.Visible = true;
                            Pest1 = ControladorTAb.FindTabByText("Poa Regional");
                            Pest1.Visible = false;                           
                            VerificargRIDActividades();
                        }
                        else 
                        {
                            MensajePantalla("No tiene datos en el poa");
                        }
                    }
                }
            }
            if (e.CommandName == "Select7")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Dt.Id_PoAnual == 0)
                    {
                        MensajePantalla("No Seleccionado el POA");
                    }
                    else
                    {
                        if (e.Item.OwnerTableView.Name == "SubRegion")
                        {
                            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                            Dt.NombrePoa = comboBox.Text;
                            Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                            Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                            Dt.DescripcionSubregion = item["Subregion"].Text;
                            Dt.TipoAsignacion = 0;
                        }
                        if (M.VerificarCargaNacional(Dt) == true)
                        {
                            Session["info2"] = Dt;
                            Response.Redirect("AgregarPSAPOA.aspx");
                        }
                        else
                        {
                            MensajePantalla("No tiene POA ingresado Todavia");
                        }
                    }
                }
            }
        }
        protected void BusquedaEdicion_Search(object sender, SearchBoxEventArgs e)
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
            VerificargRIDEdicionNacional();
        }
        protected string LlenarBusquedaEdicion()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string stringslq = string.Empty;

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",1";
            }
            return stringslq;
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
            DatosTarea Dt = (DatosTarea)Session["info200"];
            string stringslq = string.Empty;

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",1";
            }
            return stringslq;
        }
        protected void VerificargRIDActividades()
        {
            RadActividadesUM.Rebind();
            if (RadActividadesUM.Items.Count != 0)
            {
                RadActividadesUM.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                Respuesta.Visible = true;
                RadActividadesUM.Visible = false;
            }
        }
        protected void RadActividadesUM_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info200"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_Nacional " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";
            procesos.LlenarRadGrid(RadActividadesUM, CadenaSql);
        }
        private void RadActividadesUM_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.RadActividadesUM.Items)
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
        protected void RadActividadesUM_Actividad(object sender, GridCommandEventArgs e)
        {
            InformacionActividadesNacionales Ian = new InformacionActividadesNacionales();
            DatosTarea Dt = (DatosTarea)Session["info200"];
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

                if (Ian.Id_Unidad_Evaluada != 0)
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
                OpenWinwdows(ConfiguracionUMNacional, "500", "600", "Key10", "Configuración UM");
            }
            /*Abrir la ventana*/
            if (Llave == 0)
            {
                Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                VerificargRIDVentana();
            }
        }
        protected void btnCancelarconfiguarcionUM_Click(object sender, EventArgs e)
        {
            CboUnidadMedidaEvaludada.ClearSelection();
            CloseWinwdows(ConfiguracionUMNacional, "Key10");
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
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info200"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
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
                RadActividadesUM.Rebind();
                CloseWinwdows(ConfiguracionUMNacional, "Key10");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Poas_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, ComboNacional(), "Descripcion", "Id", true);          
        }
        protected void cerrarVentanaActivar_Click(object sender, EventArgs e)
        {
            CloseWinwdows(ActivacionTareasNacionales, "Key1");
        }
        protected void TareasFueraTiempoNacional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string Cadena = "EXEC Sp_Revision_TareasFueraTiempoNacional " + Dt.Id_PoAnual.ToString() + ", " + Dt.Id_Region.ToString() + "," + Dt.Id_SubRegion.ToString() + ";";
            procesos.LlenarRadGrid(TareasFueraTiempoNacional, Cadena);
        }
        protected void Seleccionar_TareaNacional(object sender, GridCommandEventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            int Id;
            string Fechaextra;

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")/*Activar y desactivar poas*/
            {
                DatosTarea Dt = (DatosTarea)Session["info2"];
                Id = Convert.ToInt32(item.GetDataKeyValue("Id").ToString());
                RadDatePicker Fecha = (RadDatePicker)item.FindControl("txtFechaEntrega");
                Fechaextra = procesos.Fechas(Fecha);

                if (Fechaextra == string.Empty)
                {
                    MensajePantalla("Debe Ingresar la fecha");
                }
                else
                {
                    if (x.ActivacióndeMetasNacionales(Dt, Id, Fechaextra, ref er))
                    {
                        MensajePantalla("Se Activaron las tareas pendientes");
                        TareasFueraTiempo.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void VerificargRIDT1()
        {
            TareasFueraTiempoNacional.Rebind();
            if (TareasFueraTiempoNacional.Items.Count != 0)
            {
                TareasFueraTiempoNacional.Visible = true;
                respuesta123.Visible = false;
            }
            else
            {
                TareasFueraTiempoNacional.Visible = false;
                respuesta123.Visible = true;
            }
        }
        protected bool Direcciones(int Codigo) 
        {
            bool dato = false;
            if (Codigo == 305) { dato = true; }
            if (Codigo == 410) { dato = true; }
            if (Codigo == 466) { dato = true; }
            if (Codigo == 409) { dato = true; }
            if (Codigo == 411) { dato = true; }
            if (Codigo == 412) { dato = true; }
            if (Codigo == 458) { dato = true; }
            if (Codigo == 497) { dato = true; }
            if (Codigo == 498) { dato = true; }

            return dato;
        } 
        protected void GRDNacionales_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int Codigo;
            if (e.Item is GridDataItem)
            {
                GridDataItem item;
                item = e.Item as GridDataItem;
                if (e.Item.OwnerTableView.Name == "SubRegion")
                {
                    Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());                     
                    if (Direcciones(Codigo) == true)
                    {
                        ((ImageButton)item["BotonA"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonB"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonE"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonF"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonG"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonQ"].Controls[0]).Visible = false;
                    }
                    else 
                    {
                        ((ImageButton)item["BotonA"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonB"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonE"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonF"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonG"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonQ"].Controls[0]).Visible = true;
                    } 
                }
            }               
        }
        protected bool Regiones(int Codigo)
        {
            bool dato = false;
            if (Codigo == 94) { dato = true; }
            if (Codigo == 95) { dato = true; }
            if (Codigo == 96) { dato = true; }
            if (Codigo == 97) { dato = true; }
            if (Codigo == 99) { dato = true; }
            if (Codigo == 100) { dato = true; }
            if (Codigo == 101) { dato = true; }
            if (Codigo == 102) { dato = true; }
            if (Codigo == 144) { dato = true; }

            return dato;
        }
        protected void RadRegion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int Codigo;
            if (e.Item is GridDataItem)
            {
                GridDataItem item;
                item = e.Item as GridDataItem;
                if (e.Item.OwnerTableView.Name == "SubRegion")
                {
                    Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    if (Regiones(Codigo) == true)
                    {
                        ((ImageButton)item["BotonA"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonB"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonE"].Controls[0]).Visible = false;                      
                    }
                    else
                    {
                        ((ImageButton)item["BotonA"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonB"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonE"].Controls[0]).Visible = true;                        
                    }
                }
            }
        }
        private void GrdEdicionNacional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdEdicionNacional.Items)
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
        protected void GrdEdicionNacional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            procesos.LlenarRadGrid(GrdEdicionNacional, "EXEC Sp_obtener_data_Actividad_NacionalEdit " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.Id_Region + ",'" + Session["CadenaBusqueda"].ToString() + "';");
        }
        protected void CargarDataEdicion()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            tituloedicion1.Text = Dt.NombrePoa;
            tituloedicion2.Text = Dt.DescripcionSubregion;          
        }
        protected void VerificargRIDEdicionNacional()
        {
            GrdEdicionNacional.Rebind();
            if (GrdEdicionNacional.Items.Count != 0)
            {
                GrdEdicionNacional.Visible = true;
            }
            else
            {
                GrdEdicionNacional.Visible = false;
            }
        }
        protected void Seleccionar_ActividadGrdEdicionNacional(object sender, GridCommandEventArgs e)
        {
            ItemEdit Actividad = new ItemEdit();
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();

            if (e.CommandName == "Select")
            {
                Actividad.Id_Poa = Dt.Id_PoAnual;
                Actividad.Id_SubRegion = Dt.Id_SubRegion;                
                Actividad.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());

                if (x.AgregarActividadesEditarNacionalES(Actividad, 1, ref er))
                {                
                    GrdEdicionNacional.Rebind();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Actividad.Id_Poa = Dt.Id_PoAnual;
                Actividad.Id_SubRegion = Dt.Id_SubRegion;
                Actividad.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());

                if (item.GetDataKeyValue("Agregado").ToString() == "Agregado")
                {
                    if (x.AgregarActividadesEditarNacionalES(Actividad, 2, ref er))
                    {                        
                        GrdEdicionNacional.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void RegresarMantenimiento_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            ItemEdit Actividad = new ItemEdit();
            DatosTarea Dt = (DatosTarea)Session["info2"];

            Actividad.Id_Poa = Dt.Id_PoAnual;
            Actividad.Id_SubRegion = Dt.Id_SubRegion;

            if (x.AgregarActividadesEditarNacionalES(Actividad, 3, ref er))
            {
                GrdEdicionNacional.Rebind();
            }                                  
            FechaEdicionNacional.SelectedDate = DateTime.Now.Date;
            DescripcionMensaje.Text = string.Empty;
            EdicionManualNacional.Visible = false;
            CargarDataEdicion();
            VerificargRIDEdicionNacional();
            Pest1 = ControladorTAb.FindTabByText("Poa Regional");
            Pest1.Visible = true;
            Nacionales.Visible = true;
        }
        protected void EdicionActividadesNacionalesEnviar_Click(object sender, EventArgs e)
        {
            OpenWinwdows(InicioTareaNacional, "500", "400", "Key", "Iniciar Tarea Nacional de Edición ");
        }
        protected void CerrarVentanaTareanacionalEdicion_Click(object sender, EventArgs e)
        {
            FechaEdicionNacional.SelectedDate = DateTime.Now.Date;
            txtmensaje.Text = string.Empty;
            CloseWinwdows(InicioTareaNacional, "Key");
        }
        protected void IniciarTareaNacionalEdicion_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea dt;
            dt = (DatosTarea)Session["info2"];
            dt.Instrucciones = DescripcionMensaje.Text.Trim();
            dt.FechaEntrega = procesos.Fechas(FechaEdicionNacional);

            if (dt.Instrucciones == string.Empty)
            {
                MensajePantalla("No a ingresado las instrucciones para el llenado del poa");
            }
            else
            {
                if (x.Inicializar_TareaPoaNacionalEdicion(dt, ref er))
                {
                    MensajePantalla("Se inicio la tarea de edición Correctamente...");
                    DescripcionMensaje.Text = string.Empty;
                    FechaEdicionNacional.SelectedDate = DateTime.Now.Date;                    
                    CloseWinwdows(InicioTareaNacional, "Key");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
    }
}