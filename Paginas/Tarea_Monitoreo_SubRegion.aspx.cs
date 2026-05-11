using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;
using System.Linq;

namespace PlanificacionPOA.Paginas
{
    public partial class Tarea_Monitoreo_SubRegion : System.Web.UI.Page
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
            GridTareaP.PreRender += new EventHandler(GridTareaP_PreRender);
            GridTareaP.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
        }
        protected string Grid(int op)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT asrm.Id_PoAnual,asrm.IdMensaje,asrm.Id_Region,asrm.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                              "mt.DescripcionMensaje Etapa,CONVERT(VARCHAR(12), asrm.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), asrm.Fecha_Inicio, 103) Fecha_Inicio," +
                              "CONVERT(VARCHAR(12), asrm.Fecha_Final, 103) Fecha_Final,asrm.EstadoDeAsignacion,r.Nombre_Region,sr.Subregion,asrm.Instrucciones,asrm.Id_Mes,m.Descripcion_Mes mes " +
                              "FROM AsignacionSubRegion_Monitoreo asrm INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = asrm.Id_PoAnual INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = asrm.IdMensaje " +
                              "INNER JOIN Region r ON r.Id_Region = asrm.Id_Region INNER JOIN Subregion sr ON sr.Id_Subregion = asrm.Id_Subregion AND sr.Id_Region = r.Id_Region " +
                              "INNER JOIN Meses m ON m.Id_meses = asrm.Id_Mes WHERE asrm.EstadoDeAsignacion = 1 ";                
            if (op == 0 )
            {
                CadenaSQL += " AND asrm.Id_Subregion =" + Users.id_subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
            }
            else if (op == 1)
            {
                CadenaSQL += " AND asrm.Id_Region =" + Users.id_region + " ORDER BY r.Id_Region,SR.Id_Subregion;";
            }
            else if (op == 2)
            {
                CadenaSQL += " ORDER BY r.Id_Region,SR.Id_Subregion;";
            }         
            
            return CadenaSQL;
        }
        protected void GridTareaP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string[] perfilesDelegados = {"15","16","17","18","19","20","21","22","23"};

            int Op = 0;
            UsuarioValida us = (UsuarioValida)Session["DataUser"];
            if  (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 86).Permiso == true)
            {
                Op = 1;
            }
            else if (us.Id_Tipoperfil == 1)
            {
                Op = 2;
            }
            else if (us.Id_Tipoperfil == 15)
            {
                Op = 1;
            }
           
            //crejopachi se utiliza la libreria using System.Linq; para usar los "contains"
            else if (perfilesDelegados.Contains(us.Id_Tipoperfil.ToString()))
            {
                Op = 1;
            }
            procesos.LlenarRadGrid(GridTareaP, Grid(Op));
        }
        private void GridTareaP_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridTareaP.Items)
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
                    if (gridDataItem2["Id_PoAnual"].Text == gridDataItem3["Id_PoAnual"].Text)
                    {
                        gridDataItem2["POA"].RowSpan = gridDataItem3["POA"].RowSpan < 2
                        ? 2
                        : gridDataItem3["POA"].RowSpan + 1;
                        gridDataItem3["POA"].Visible = false;
                    }                    
                }
            }
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajePla, "Key1");
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
        protected void VerificargRID()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 64).Permiso != true)
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
                Respuesta.Visible = true;
            }
        }
        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas();

            if (e.CommandName == "Select")
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
                DMI.Nombre_SubRegion = item.GetDataKeyValue("Subregion").ToString();

                Session["Mantenimiento"] = "False";
                Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
                Response.Redirect("Componentes_Monitoreo.aspx");                
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Instrucciones del Regional");
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