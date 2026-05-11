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
    public partial class Tarea_Monitoreo : System.Web.UI.Page
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
        protected void Inicializacion_Objetos()
        {
            GridPOASSistema.NeedDataSource += new GridNeedDataSourceEventHandler(GridPOASSistema_NeedDataSource);
            GridPOASSistema.ItemCommand += new GridCommandEventHandler(Seleccionar_POA);
            TaresEnviadas.NeedDataSource += new GridNeedDataSourceEventHandler(TaresEnviadas_NeedDataSource);
            TaresEnviadas.ItemDataBound += TaresEnviadas_ItemDataBound;
            CancelarTarea.Click += new EventHandler(CancelarTarea_Click);           
            GuardarTarea.Click += new EventHandler(GuardarTarea_Click);
        }
        protected void TaresEnviadas_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["Estado"];
               
                if (item.GetDataKeyValue("Estado").ToString() =="En Progreso")
                {
                    cell1.BackColor = Color.Red;
                    cell1.ForeColor = Color.White;                                       
                }
            }
        }
        protected void VerificargRID()
        {            
            GridPOASSistema.Rebind();
            if (GridPOASSistema.Items.Count != 0) { GridPOASSistema.Visible = true; } else { GridPOASSistema.Visible = false; }           
        }        
        protected void Fillcombo(int Poa)
        {
            //string Dato = "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses m  WHERE Id_meses NOT IN(SELECT Id_Mes FROM Envio_Tarea_Monitoreo WHERE Id_PoAnual =" + Poa + ");";
            string Dato = "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses m";
            procesos.LLenarComboT(CboMeses, Dato, "Descripcion", "Id", true);
        }
        protected void TaresEnviadas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(TaresEnviadas,"SELECT m.Id_meses, m.Descripcion_Mes,(CASE "+
                                                 "WHEN ISNULL(etm.Estado_Tarea, 0) = 0 THEN 'Sin Iniciar' "+
                                                 "WHEN ISNULL(etm.Estado_Tarea, 0) = 1 THEN 'En Progreso' "+
                                                 "WHEN ISNULL(etm.Estado_Tarea, 0) = 2 THEN 'FInalizado ' END) Estado,"+ 
		                                         "ISNULL(CAST(convert(VARCHAR(12), etm.Fecha_Inicio, 103) AS NVARCHAR(MAX)), '') FechaInicial,"+
		                                         "ISNULL(CAST(convert(VARCHAR(12), etm.Fecha_Final, 103) AS NVARCHAR(MAX)), '') FechaInicial,"+
                                                  "ISNULL(CAST(convert(VARCHAR(12), etm.FechaDeCreacion, 103) AS NVARCHAR(MAX)), '') FechaEnvio " +
                                                 "FROM Meses m LEFT JOIN Envio_Tarea_Monitoreo etm ON m.Id_meses = etm.Id_Mes  AND etm.Id_PoAnual = " + Convert.ToInt32(Session["POA"].ToString()) + ";");
        }
        protected void GridPOASSistema_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridPOASSistema, "SELECT pc.Id_PoAnual,pc.Id_Poa,tp.Descripcion_POA POA,pc.Descripcion_POA,pc.Anio_Correspondiente Anio,pc.Estado_PoAnual,IniciarTarea " +                                                                                                       
                                                    "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp. Id_Poa WHERE pc.IniciarTarea = 1;");
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 62).Permiso != true)
                {
                    Response.Redirect("Portada.aspx");
                }                
                VerificargRID();
                Session["POA"] = 0;
                Session["llave"] = 0;
            }
        }
        protected void Seleccionar_POA(object sender, GridCommandEventArgs e)
        {                                       
            GridDataItem item = e.Item as GridDataItem;
             if (e.CommandName == "Select")
             {
                 Session["CodigoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());                
                 Fillcombo(Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString()));
                 OpenWinwdows(InicioTareas, "500", "480", "Key", "Inicio de Tarea");
                 Session["llave"] = 1;
             }  
            /*Abrir la ventana*/
            if (Session["llave"].ToString() == "0")
            {
                Session["POA"] = Convert.ToInt32(Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString()));
                VerificargRIDVentana();
            }
            Session["llave"] = 0;
        }
        protected void VerificargRIDVentana()
        {
            TaresEnviadas.Rebind();
            OpenWinwdows(VerTareasEnviadas, "500", "500", "Key", "Visualización de Tareas Enviadas");
            
        }
        protected void CancelarTarea_Click(object sender, EventArgs e)
        {
            txtInstrucciones.Text = string.Empty;            
            txtFechaFinal.Clear();
            CboMeses.ClearSelection(); 
            CloseWinwdows(InicioTareas, "Key");
        }
        protected Validar_Data Validar_Tarea(TMonitoreo d)
        {
            Validar_Data V = new Validar_Data();

            if (d.Id_Mes == 0) { V.Verificar = true; V.Mensaje += "No ha seleccionado el mes de la tarea de ingreso.</br>"; }           
            if (d.FechaDeFinal == string.Empty) { V.Verificar = true; V.Mensaje += "No ha ingresado la fecha de Finalización.</br>"; }
            if (d.Instrucciones == string.Empty) { V.Verificar = true; V.Mensaje += "No ha Ingresado las instrucciones.</br>"; }
            
            return V;
        }
        protected void GuardarTarea_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();
            TMonitoreo Ai = new TMonitoreo();
            Validar_Data V;
           
            Ai.FechaDeFinal = procesos.Fechas(txtFechaFinal);
            Ai.Id_Mes = procesos.IntNULLCombo(CboMeses); 
            Ai.Instrucciones = txtInstrucciones.Text.Trim();
            Ai.Id_PoAnual = Convert.ToInt32(Session["CodigoPoa"].ToString());
            Ai.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            V = Validar_Tarea(Ai);
            if (V.Verificar)
            {
                MensajePantalla(V.Mensaje);
            }
            else
            {
                if (x.Enviar_Tarea_Monitoreo(Ai, ref er))
                {
                    MensajePantalla("Se Envio la Tarea Exitosamente...");
                    txtInstrucciones.Text = string.Empty;                   
                    txtFechaFinal.Clear();
                    CboMeses.ClearSelection();
                    CloseWinwdows(InicioTareas, "Key");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
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
    }
}