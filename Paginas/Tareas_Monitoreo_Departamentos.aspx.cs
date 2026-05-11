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
    public partial class Tareas_Monitoreo_Departamentos : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public Manejo_De_Mantenimiento_PoaNacional MDMP = new Manejo_De_Mantenimiento_PoaNacional();
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
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
        }
        protected string Grid(int op)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT adup.Id_PoAnual,adup.IdMensaje,adup.Id_Region,adup.Id_Subregion,UPPER('POA NACIONAL ' +CAST(pc.Anio_Correspondiente AS varchar)) POA,"+
                               "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), adup.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), adup.Fecha_Final, 103) Fecha_Final," +
                               "adup.EstadoDeAsignacion,r.Nombre_Region,sr.Subregion,adup.Instrucciones,adup.Id_Mes,m.Descripcion_Mes mes FROM AsignacionDepartamentosUPMonitoreo adup "+
                               "INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = adup.Id_PoAnual "+
                               "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = adup.IdMensaje "+
                               "INNER JOIN Region r ON r.Id_Region = adup.Id_Region "+
                               "INNER JOIN Subregion sr ON sr.Id_Subregion = adup.Id_Subregion AND sr.Id_Region = r.Id_Region "+
                               "INNER JOIN Meses m ON m.Id_meses = adup.Id_Mes " +
                               "WHERE adup.EstadoDeAsignacion = 1 ";

            if (op == 1)
            {
                CadenaSQL += " AND adup.Id_Subregion  = " + Users.id_subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
            }
            else 
            {
               CadenaSQL += " ORDER BY r.Id_Region,SR.Id_Subregion;";
            }
            return CadenaSQL;
        }
        protected void GridTareaP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int Op;
            UsuarioValida us = (UsuarioValida)Session["DataUser"];
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 92).Permiso != true) && (us.Id_Tipoperfil == 1))
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
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (e.CommandName == "Select")
            {
                if(PermisosUsuario.Verifica_Permisos(PermisosPermitidos,93).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else 
                {
                    DMI.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                    DMI.NombrePOA = item.GetDataKeyValue("POA").ToString();
                    DMI.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    DMI.Nombre_Region = item.GetDataKeyValue("Nombre_Region").ToString();
                    DMI.Nombre_SubRegion = item.GetDataKeyValue("Subregion").ToString();
                    DMI.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    DMI.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());                   
                    DMI.Fecha_Final = item.GetDataKeyValue("Fecha_Final").ToString();
                    DMI.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
                    DMI.Descripcion_mes = item.GetDataKeyValue("mes").ToString();
                    DMI.Id_Mensaje = Convert.ToInt32(item.GetDataKeyValue("IdMensaje").ToString());
                   
                    if (MDMP.VerifcarDatosPoaNacional(DMI.Id_PoAnual, DMI.Id_Subregion) == true)
                    {
                       Session["Mantenimiento"] = "False";
                       Session["infoNacionalMonitoreo"] = DMI;                        
                        Response.Redirect("ActividadNacionalMonitoreo.aspx");
                    }
                    else
                    {
                        MensajePantalla("No Tiene un Poa Aprobado por Planificación");
                    }
                }
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Instrucciones de Monitoreo y Seguimiento");
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