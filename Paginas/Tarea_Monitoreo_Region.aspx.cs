using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Tarea_Monitoreo_Region : System.Web.UI.Page
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
        protected string Grid(int op)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT arm.Id_PoAnual,arm.IdMensaje,arm.Id_Region,arm.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA,"+
                               "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), arm.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), arm.Fecha_Inicio, 103) Fecha_Inicio,"+
							   "CONVERT(VARCHAR(12), arm.Fecha_Final, 103) Fecha_Final,arm.EstadoDeAsignacion,r.Nombre_Region,arm.Instrucciones,arm.Asignado,arm.Id_Mes,m.Descripcion_Mes mes "+
                               "FROM AsignacionRegion_Monitoreo arm INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = arm.Id_PoAnual INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = arm.IdMensaje "+
                               "INNER JOIN Region r ON r.Id_Region = arm.Id_Region INNER JOIN Meses m ON m.Id_meses = arm.Id_Mes WHERE arm.EstadoDeAsignacion = 1 AND arm.Asignado = 0 ";
            if (op == 1)
            {
                CadenaSQL += "AND arm.Id_Region =" + Users.id_region;
            }
            return CadenaSQL;
        }
        protected void GridTareaP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int Op;
            UsuarioValida us = (UsuarioValida)Session["DataUser"];
            if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 86).Permiso == true) || (us.Id_Tipoperfil == 1))
            {
                Op = 0;
            }
            else
            {
                Op = 1;
            }
            procesos.LlenarRadGrid(GridTareaP, Grid(Op));
        }
        protected void VerificargRID()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 63).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
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
        protected void Inicializacion_Objetos()
        {
            GridTareaP.NeedDataSource += new GridNeedDataSourceEventHandler(GridTareaP_NeedDataSource);
            GridTareaP.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            CerrarVentanaTarea.Click += new EventHandler(CerrarVentanaTarea_Click);
            IniciarTarea.Click += new EventHandler(IniciarTarea_Click);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
        }
        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas(); 

            if (e.CommandName == "Select")
            {
                if (Convert.ToInt32(item.GetDataKeyValue("Asignado").ToString()) == 0)
                {
                    DMI.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                    DMI.NombrePOA = item.GetDataKeyValue("POA").ToString();
                    DMI.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    DMI.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    DMI.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                    DMI.Fecha_Inicio = item.GetDataKeyValue("Fecha_Inicio").ToString();
                    DMI.Fecha_Final = item.GetDataKeyValue("Fecha_Final").ToString();
                    DMI.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
                    DMI.Descripcion_mes = item.GetDataKeyValue("mes").ToString();
                    DMI.Id_Mensaje = Convert.ToInt32(item.GetDataKeyValue("IdMensaje").ToString());

                    Session["info"] = DMI;
                    
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
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Instrucciones de Monitoreo y Seguimiento");
            }
        }
        protected void IniciarTarea_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosMonitoreoIngresoMetas dt;
            dt = (DatosMonitoreoIngresoMetas)Session["info"];
            dt.Instrucciones = txtmensaje.Text.Trim();

            if (dt.Instrucciones == string.Empty)
            {
                MensajePantalla("No a ingresado las instrucciones para el llenado del poa");
            }
            else
            {
                if (x.Inicializar_TareaPoaSubregionalMonitoreo(dt, ref er))
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