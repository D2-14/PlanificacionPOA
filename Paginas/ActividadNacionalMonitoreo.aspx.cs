using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class ActividadNacionalMonitoreo : System.Web.UI.Page
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
            GridProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductos_NeedDataSource);
            GridProductos.ItemCommand += new GridCommandEventHandler(Seleccionar_Producto);
            GridProductos.ItemDataBound += GridProductos_ItemDataBound;
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            RegresarPantallaanterior_Mantenimiento.Click += new EventHandler(RegresarPantallaanterior_Mantenimiento_Click);
            FinalizarIngreso.Click += new EventHandler(FinalizarIngreso_Click);
            btnCerrarVentana.Click += new EventHandler(BtnCerrarVentana_Click);
            btnIrConfiguracion.Click += new EventHandler(BtnIrConfiguracion_Click);


        }
        protected void FinalizarIngreso_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo x = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 94).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                OpenWinwdows(confirmar, "330", "170", "Key5", "Información");
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tareas_Monitoreo_Departamentos.aspx");
        }
        protected void RegresarPantallaanterior_Mantenimiento_Click(object sender, EventArgs e)
        {

            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];
            Session["Id_POA_"] = DMI.Id_PoAnual;
            Session["Mes_"] = DMI.Id_Mes;
            Response.Redirect("SeguimientoPOA.aspx");
        }
        protected void VerificargRID()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 94).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
            GridProductos.Rebind();
            if (GridProductos.Items.Count != 0) { GridProductos.Visible = true; } else { GridProductos.Visible = false; }
        }
        protected void GridProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
         {
            try
            {
                DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];               
                string sqlstring = "Sp_VerificarEstadoObjetoMonitoreo " + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.Id_Mes;
                procesos.LlenarRadGrid(GridProductos, sqlstring);

                if (Session["Mantenimiento"] == "True")
                {
                    RegresarPantallaanterior.Visible = false;
                    FinalizarIngreso.Visible = false;

                    RegresarPantallaanterior_Mantenimiento.Visible = true;
                }
                else
                {
                    RegresarPantallaanterior.Visible = true;
                    FinalizarIngreso.Visible = true;

                    RegresarPantallaanterior_Mantenimiento.Visible = false;
                }
            }
            catch
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Seleccionar_Producto(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;           
            MonitoreoObjetos MO = new MonitoreoObjetos();
            string Estado;
            if (e.CommandName == "Select")
            {
                MO.Tipo = Convert.ToInt32(item.GetDataKeyValue("Tipo").ToString());
                MO.Correlativo = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                MO.Descripcion = item.GetDataKeyValue("Descripcion").ToString();
                MO.Id_Producto = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
                MO.Id_SubProducto = Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString());
                MO.Id_Actividad = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
               
                if (Session["Mantenimiento"] == "True")
                {
                    Estado = "Incompleto";
                    Session["infoNacionalMonitoreoIngresoMetas"] = MO;
                }
                else
                {
                Estado = item.GetDataKeyValue("Proceso").ToString();
                Session["infoNacionalMonitoreoIngresoMetas"] = MO;
                }


                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 94).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (Estado == "Incompleto")
                    {
                        Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 94).Url);
                    }
                }
            }
        }
        protected void GridProductos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["Proceso"];

                if (item.GetDataKeyValue("Proceso").ToString() == "Completo")
                {
                    cell1.BackColor = Color.Green;
                    cell1.ForeColor = Color.White;
                    cell1.Font.Bold = true;
                }
                else
                {
                    cell1.BackColor = Color.Red;
                    cell1.ForeColor = Color.White;
                    cell1.Font.Bold = true;
                }
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
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 93).Permiso != true)
                {
                    Response.Redirect("Portada.aspx");
                }
                VerificargRID();
            }
        }
        protected void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(confirmar, "Key5");
        }
        protected void BtnIrConfiguracion_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo x = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["infoNacionalMonitoreo"];
            if (x.Finalizar_IngresoMonitoreoNacional(DMI, ref er))
            {
                Response.Redirect("Tareas_Monitoreo_Departamentos.aspx");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
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