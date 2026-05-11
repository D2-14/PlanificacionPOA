using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Tareas_Regional : System.Web.UI.Page
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
        protected void Inicializacion_Objetos()
        {
            GridTareaP.NeedDataSource += new GridNeedDataSourceEventHandler(GridTareaP_NeedDataSource);
            GridTareaP.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            CerrarVentanaTarea.Click += new EventHandler(CerrarVentanaTarea_Click);
            IniciarTarea.Click += new EventHandler(IniciarTarea_Click);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
        }
        protected string Grid(int op) 
        {
            Users = (UsuarioValida)Session["DataUser"];           
            string CadenaSQL = "SELECT ar.Id_PoAnual,ar.IdMensaje,ar.Id_Region,ar.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                               "mt.DescripcionMensaje Etapa,CONVERT(VARCHAR(12), ar.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), ar.FechaDeEntrega, 103) FechaDeEntrega," +
                               "ar.EstadoDeAsignacion,	r.Nombre_Region,(SELECT Instrucciones  FROM MantenimientoPoa WHERE Id_PoAnual =ar.Id_PoAnual) Instrucciones,ar.Asignado,ar.TipoAsignacion," +
                               "Isnull(ar.NoReprogramacion,0) NoReprogramacion " +
                               "FROM AsignacionRegion ar INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = ar.Id_PoAnual " +
                               "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = ar.IdMensaje INNER JOIN Region r ON r.Id_Region = ar.Id_Region " +
                               "WHERE ar.EstadoDeAsignacion = 1 AND Asignado = 0 ";
            if (op == 1)
            {
                CadenaSQL += "AND ar.Id_Region ="+ Users.id_region;
            }
            return CadenaSQL;
        }

        protected void GridTareaP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int Op;
            UsuarioValida us = (UsuarioValida)Session["DataUser"];
            if((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 86).Permiso == true) || (us.Id_Tipoperfil == 1))
            {
                Op = 0;
            }
            else 
            {
                Op = 1;
            }
           procesos.LlenarRadGrid(GridTareaP, Grid(Op));
        }
        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {                       
            GridDataItem item = e.Item as GridDataItem;
            DatosTarea dt = new DatosTarea();

            if (e.CommandName == "Select")
            {
                if (Convert.ToInt32(item.GetDataKeyValue("Asignado").ToString()) == 0)
                {                    
                    dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                    dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                    dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                    dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                    dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());
                    dt.IdMensaje = Convert.ToInt32(item.GetDataKeyValue("IdMensaje").ToString());

                    Session["info"] = dt;
                    OpenWinwdows(InicioTarea, "500", "370", "Key", "Iniciar Tareas");
                }
                else 
                {
                    MensajePantalla("ya hizo el envio de tareas a las subregiones");
                }
            }
            if (e.CommandName == "Select1")
            {                
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Instrucciones de Planificación");
            }            
        }
        protected void VerificargRID()
        {
            GridTareaP.Rebind();
            if (GridTareaP.Items.Count != 0) 
            { 
                GridTareaP.Visible = true;
                Respuesta.Visible = false; 
            } 
            else 
            { 
                GridTareaP.Visible = false;
                Respuesta.Visible = true; ;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VerificargRID();
            }
        }
        protected void IniciarTarea_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea dt;
            dt =(DatosTarea)Session["info"];
            dt.Instrucciones = txtmensaje.Text.Trim();

            if (dt.Instrucciones == string.Empty)
            {
                MensajePantalla("No a ingresado las instrucciones para el llenado del poa");
            }
            else
            {
                if (x.Inicializar_TareaPoaSubregional(dt, ref er))
                {
                    MensajePantalla("Se inicio la tarea Correctamente...");
                    txtmensaje.Text = string.Empty;  
                    VerificargRID();
                    CloseWinwdows(InicioTarea, "Key");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }            
        }
        protected void CerrarVentanaTarea_Click(object sender, EventArgs e)
        {
            txtmensaje.Text = string.Empty; 
            CloseWinwdows(InicioTarea, "Key");
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajePla, "Key1");
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