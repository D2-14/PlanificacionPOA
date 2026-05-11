using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Portada : System.Web.UI.Page
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
        protected void RadImagen_NeedDataSource(object sender, ImageGalleryNeedDataSourceEventArgs e)
        {
            ConectarBDD Grabar = new ConectarBDD();
            SqlCommand iComandos = new SqlCommand();
            string Cadena = "SELECT Urlimagen,Descripcion,Titulo FROM ImagenesPortada WHERE Estado = 1;";
            DataSet DatosImagenes = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            RadImagen.DataSource = DatosImagenes;
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageBNotifica.Click += ImageBNotifica_Click;
            GridNotificacion.NeedDataSource += new GridNeedDataSourceEventHandler(GridNotificacion_NeedDataSource);
            GridNotificacion.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {               
                Session["Permisos_SistemaP"] = PermisosUsuario.Permisos(Convert.ToInt32(Session["Usuario"].ToString()));
                Mensajes();              
            }
        }
        protected void Mensajes() 
        {                                  
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_SistemaP"];
            Manipulacion_de_Tareas t = new Manipulacion_de_Tareas();            
            DiasPendiente Dp = t.TiempoIngreso((UsuarioValida)Session["DataUser"]);
            
            if (Dp.Resulta == true)
            {
                MensajeDias.Text = Dp.Mensaje;
                Ver_Tareas(FaltanDias, "Notificaciones_Tareas.aspx", "600", "500", "key", "Mensaje");
            }
            else
            {               
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 25).Permiso == true)
                {
                    if (t.Pendientes((UsuarioValida)Session["DataUser"]) == true)
                    {
                        Ver_Tareas(VentanaDeNotificacion, "Notificaciones_Tareas.aspx", "600", "500", "key", "Tareas Pendientes del Usuario");
                    }                            
                }
                else
                {
                    Pendiente.Visible = false;                   
                }
            }
            string Nombre = t.Testigo_notificacion((UsuarioValida)Session["DataUser"]);
            if (Nombre != string.Empty)
            {
                Pendiente.Visible = true;
                ImageBNotifica.ImageUrl = "../Imagenes/Messages/" + Nombre;
            }
            else
            {
                Pendiente.Visible = false;
            }
        }
       
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {                                            
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_SistemaP"];
            Manipulacion_de_Tareas t = new Manipulacion_de_Tareas();
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 25).Permiso == true)
            {
                if (t.Pendientes((UsuarioValida)Session["DataUser"]) == true)
                {
                    Ver_Tareas(VentanaDeNotificacion, "Notificaciones_Tareas.aspx", "600", "500", "key", "Tareas Pendientes del Usuario");
                }               
            }
            else
            {
                Pendiente.Visible = false;
            }
            CloseWinwdows(FaltanDias, "Key3");
        }
        protected void ImageBNotifica_Click(object sender, EventArgs e) 
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_SistemaP"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 25).Permiso != true)
            {
                Pendiente.Visible = false;
            }
            else
            {
                Pendiente.Visible = true;
                Ver_Tareas(VentanaDeNotificacion, "Notificaciones_Tareas.aspx", "600", "500", "key", "Tareas Pendientes del Usuario");
            }
        }
        /*Ventana*/
        protected void Ver_Tareas(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
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
        /*Notificaciones*/
        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {          
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            int permiso;
            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                permiso = Convert.ToInt32(item.GetDataKeyValue("Permiso").ToString()); 
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, permiso).Permiso == true)
                {
                    string Url = item.GetDataKeyValue("Urls").ToString();
                    Response.Redirect(Url);
                }
                else
                {
                    MensajePantalla("no tiene Permisos.......");
                }
            }
            permiso = Convert.ToInt32(item.GetDataKeyValue("Permiso").ToString());
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, permiso).Permiso == true)
            {
                string Url = item.GetDataKeyValue("Urls").ToString();
                Response.Redirect(Url);
            }
            else
            {
                MensajePantalla("no tiene Permisos.......");
            }
        }
        protected void GridNotificacion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string Nombre;
            Manipulacion_de_Tareas t = new Manipulacion_de_Tareas();
            Nombre = t.Testigo_notificacion((UsuarioValida)Session["DataUser"]);

            if (Nombre != string.Empty)
            {
                DataSet Datos = t.Obtener_Tareas((UsuarioValida)Session["DataUser"]);
                if ((Datos.Tables[2] != null) && (Datos.Tables[2].Rows.Count > 0))
                {
                    GridNotificacion.Visible = true;
                    GridNotificacion.DataSource = Datos.Tables[2];
                }
                else
                {
                    GridNotificacion.Visible = false;
                }
            }
            else
            {
                GridNotificacion.Visible = false;
            }
        }
    }
}