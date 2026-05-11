using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class AgregarPSAPOA : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void Inicializacion_Objetos() 
        {
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GridProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductos_NeedDataSource);
            GridProductos.DeleteCommand += new GridCommandEventHandler(Seleccionar_Items);
            GridProductosAproabados.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductosAproabados_NeedDataSource);
            GridProductosAproabados.DeleteCommand += new GridCommandEventHandler(Eliminar_Items);
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Session["ValorDevuelta"] = 1;
            Response.Redirect("MantenimientoPOAs.aspx");
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
            DatosTarea Dt = (DatosTarea)Session["info2"];
            T01.Text = Dt.NombrePoa;
            T02.Text = Dt.DescripcionSubregion;
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
                VericarPermiso();
            }
        }
        protected void GridProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DatosTarea Dt = (DatosTarea)Session["info2"];
                string sqlstring = "Sp_obtener_data_Actividad_NacionalAgregar " + 1 + "," + Dt.Id_PoAnual + "," + Dt.Id_SubRegion;
                procesos.LlenarRadGrid(GridProductos, sqlstring);
            }
            catch
            {               
            }
        }
        protected void GridProductosAproabados_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DatosTarea Dt =(DatosTarea)Session["info2"];
                string sqlstring = "Sp_obtener_data_Actividad_NacionalAgregar " + 2 + "," + Dt.Id_PoAnual + "," + Dt.Id_SubRegion;
                procesos.LlenarRadGrid(GridProductosAproabados, sqlstring);
            }
            catch
            {
            }
        }
        private void RecargarGrid2()
        {
            GridProductos.Rebind();
            if (GridProductos.Items.Count == 0)
            {
                GridProductos.Visible = false;
            }
            else
            {
                GridProductos.Visible = true;
            }
        }
        private void RecargarGrid()
        {
            GridProductosAproabados.Rebind();
            if (GridProductosAproabados.Items.Count == 0)
            {
                GridProductosAproabados.Visible = false;
            }
            else
            {
                GridProductosAproabados.Visible = true;
            }
        }
        protected void Eliminar_Items(object source, GridCommandEventArgs e)
        {

            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            MonitoreoObjetos mo = new MonitoreoObjetos();
            DatosTarea Dt = (DatosTarea)Session["info2"];

            mo.Tipo = Convert.ToInt32(item.GetDataKeyValue("Tipo").ToString());
            mo.Correlativo = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
            mo.Id_Producto = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
            mo.Id_SubProducto = Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString());
            mo.Id_Actividad = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
            mo.Id_Poa = Dt.Id_PoAnual;
            mo.Id_Subregion = Dt.Id_SubRegion;

            if (Mim.AgregarEliminar_ProductoPoa(2,mo, ref er))
            {
                RecargarGrid();              
                MensajePantalla("Se Elimino.......");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Seleccionar_Items(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            MonitoreoObjetos mo = new MonitoreoObjetos();
            DatosTarea Dt = (DatosTarea)Session["info2"];

            mo.Tipo = Convert.ToInt32(item.GetDataKeyValue("Tipo").ToString());
            mo.Correlativo = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
            mo.Id_Producto = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
            mo.Id_SubProducto = Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString());
            mo.Id_Actividad = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
            mo.Id_Poa = Dt.Id_PoAnual;
            mo.Id_Subregion = Dt.Id_SubRegion;

            if (Mim.AgregarEliminar_ProductoPoa(1, mo, ref er))
            {
                RecargarGrid();               
                MensajePantalla("Se agrego.......");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }       
    }
}