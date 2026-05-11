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
    public partial class IngresodeMetasDSR : System.Web.UI.Page
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
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tareas_SubRegional.aspx");
        }
        protected void FinalizarIngresosActividades_Click(object sender, EventArgs e)
        {
            OpenWinwdows(FinalizarTareaVentana, "500", "390", "Key3", "Finalizar Tarea de Ingreso de Metas");
        }
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            Users = (UsuarioValida)Session["DataUser"];
            string strsub;
            //Bloqueo de componentes para ingreso de metas
            //if ((CboComponente.SelectedItem.Value != "14") && (CboComponente.SelectedItem.Value != "16"))
            if (CboComponente.SelectedItem.Value == "-5000")
            {
                MensajePantalla("Componente Inactivo:");
            }
            else
            {
                if (Users.Id_Tipoperfil == 19)
                {
                    //strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ","+ CboComponente.SelectedItem.Value + ",2,NULL," + Users.Id_Tipoperfil;  
                    strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2,NULL";
                }
                else
                {

                    strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";
                }
                CboSubcomponente.ClearSelection();
                VerificargRID();
                procesos.LLenarComboT(CboSubcomponente, strsub, "Descripcion", "Id", true);

            }
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {

            //if ((CboSubcomponente.SelectedValue != "20") &&(CboComponente.SelectedValue=="12"))
            if (CboSubcomponente.SelectedValue == "-5000") 
            {
                MensajePantalla("SubComponente Inactivo:");
            }              
            else
            {

            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();            
            DatosTarea Dt = (DatosTarea)Session["info2"];
            Ris.Id_PoAnual = Dt.Id_PoAnual;
            Ris.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente));
            Ris.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente));
            Ris.Id_SubRegion = Dt.Id_SubRegion;
            Session["CargarMetasValor"] = Ris;
            VerificargRID();
            }
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
            DatosTarea Dt = (DatosTarea)Session["info2"];
            if ((Ris.Id_Componente != 0) && (Ris.Id_SubComponente != 0))
            {
                Respuesta.Visible = false;
                string CadenaSql = "EXEC Sp_obtener_data_Actividad_Subregional " + Ris.Id_PoAnual + "," +Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_SubRegion +","+
                                    Dt.TipoAsignacion + ";";
                procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
            }
            else 
            {
                Respuesta.Visible = true;
            }
        }
        protected void Inicializacion_Objetos()
        {
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.ItemDataBound += GdrDatosdeActividades_ItemDataBound;
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            FinalizarIngresosActividades.Click += new EventHandler(FinalizarIngresosActividades_Click);
            CerrarVentanaTarea.Click += new EventHandler(CerrarVentanaTarea_Click);
            FinalizarIngreso.Click += new EventHandler(FinalizarIngreso_Click);
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
        }
        protected void CargarData() 
        {
            Users = (UsuarioValida)Session["DataUser"];
            DatosTarea Dt = (DatosTarea)Session["info2"];
            T01.Text = Dt.NombrePoa;
            //string stringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1," + Dt.Id_SubRegion +"," + Users.Id_Tipoperfil + ";";
            string stringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1," + Dt.Id_SubRegion +";";
            procesos.LLenarComboT(CboComponente, stringComando, "Descripcion", "Id", true);
        }
        protected void Regreso_informacion()
        {
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
            CboComponente.SelectedValue = Ris.Id_Componente.ToString();
            string Strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente.SelectedItem.Value + " ORDER BY id;";
            procesos.LLenarComboT(CboSubcomponente, Strsub, "Descripcion", "Id", true);
            CboSubcomponente.SelectedValue = Ris.Id_SubComponente.ToString();
            GdrDatosdeActividades.Rebind(); 
        }
        protected void GdrDatosdeActividades_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["DescripcionProductoVeficable"];
                TableCell cell2 = item["DescripcionUM1"];
                TableCell cell3 = item["DescripcionUM2"];
                TableCell cell4 = item["DescripcionUM3"];
                
                if (Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString()) == 1)
                {
                    cell1.BackColor = Color.Aquamarine;
                    cell1.Font.Bold = true;
                    cell2.BackColor = Color.Aquamarine;
                    cell2.Font.Bold = true;
                    cell3.BackColor = Color.Aquamarine;
                    cell3.Font.Bold = true;
                    cell4.BackColor = Color.Aquamarine;
                    cell4.Font.Bold = true;                                      
                }
            }
        }
        protected void VerificargRID()
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
        protected void Normal_informacion() 
        {
            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
            Session["CargarMetasValor"] = Ris;
            CboSubcomponente.ClearSelection();
            CboComponente.ClearSelection();
            VerificargRID();
            Session["d1"] = 0;
            Session["d2"] = 0;
            Session["d3"] = 0;           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            Inicializacion_Objetos();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 30).Permiso != true)
                {
                    Response.Redirect("~/Login.aspx");
                }
                CargarData();
                if (Convert.ToInt32(Session["Validar"].ToString()) == 1) 
                {
                    Regreso_informacion();
                }
                else 
                {
                    Normal_informacion();
                }
            }
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();            
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;
            int Llave = 0;

            if (e.CommandName == "Select")
            {                
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 32).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {                   
                    Ris.Id_PoAnual = Dt.Id_PoAnual; 
                    Ris.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());
                    Ris.Id_SubComponente = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                    Ris.Id_SubRegion = Dt.Id_SubRegion;
                    Ris.RedProgramatica = Convert.ToInt32(item.GetDataKeyValue("Id_MetasRedProgramatica").ToString());
                    Ris.NoPlanificable = Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString());
                    Ris.Actividad = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                    Ris.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                    Ris.DUM1 = item.GetDataKeyValue("DescripcionUM1").ToString();
                    Ris.DUM2 = item.GetDataKeyValue("DescripcionUM2").ToString();
                    Ris.DUM3 = item.GetDataKeyValue("DescripcionUM3").ToString();
                    Ris.idDUM1 = Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString());
                    Ris.idDUM2 = Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString());
                    Ris.idDUM3 = Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString());
                    Ris.TipoAsignacion = Dt.TipoAsignacion;                    

                    if (Ris.NoPlanificable != 0)
                    {
                        Llave = 1;
                        MensajePantalla("No se ingresan valores porque es una actividad No planificable");
                    }
                    else
                    {
                        Session["CargarMetasValor"] = Ris;
                        Session["Destino"] = 1;
                        Response.Redirect("IngresoMetasValoresSR.aspx");
                    }
                }
            }
            /*Abrir la ventana*/
            if (Llave == 0)
            {
                Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());
                Session["d2"] = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Session["d3"] = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                VerificargRIDVentana();
            }
        }
        protected void CerrarVentanaTarea_Click(object sender, EventArgs e)
        {
            CloseWinwdows(FinalizarTareaVentana, "Key3");
        }
        protected void FinalizarIngreso_Click(object sender, EventArgs e) 
        {            
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info2"];
            Dt.Instrucciones = txtmensaje.Text.Trim();
            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());  

            if ((Dt.Instrucciones == string.Empty) || (Dt.Instrucciones.Length == 0))
            {
                MensajePantalla("Debe ingresar las observaciones");
            }
            else
            {
                if (x.Enviar_tareaRegion(Dt, ref er))
                {
                    txtmensaje.Text = string.Empty;
                    CloseWinwdows(FinalizarTareaVentana, "Key3");
                    Response.Redirect("Tareas_SubRegional.aspx");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
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
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {                        
            DatosTarea Dt = (DatosTarea)Session["info2"];           
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 + "," +
                               + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString()  + "," + Session["d2"].ToString() + "," + Session["d3"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);            
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
    }
}