using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class ReprogramacionRegional : System.Web.UI.Page
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
            string CadenaSQL = "SELECT asr.Id_PoAnual,asr.IdMensaje,asr.Id_Region,asr.Id_Subregion," +
                        "UPPER(pc.Descripcion_POA +' '+CAST(pc.Anio_Correspondiente AS varchar)) POA,mt.DescripcionMensaje Etapa," +
                        "CONVERT(VARCHAR(12), asr.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), asr.FechaDeEntrega, 103) FechaDeEntrega," +
                        "asr.EstadoDeAsignacion,r.Nombre_Region,sr.Subregion,asr.Instrucciones,asr.TipoAsignacion,isnull(asr.NoReprogramacion,0) NoReprogramacion " +
                        "FROM AsignacionReprogramacionSubRegion asr INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = asr.Id_PoAnual " +
                        "INNER JOIN Mensaje_Tarea mt ON mt.Id_Mensaje = asr.IdMensaje INNER JOIN Region r ON r.Id_Region = asr.Id_Region " +
                        "INNER JOIN Subregion sr ON sr.Id_Subregion = asr.Id_Subregion AND sr.Id_Region = r.Id_Region " +
                        "WHERE asr.EstadoDeAsignacion = 1";

            if (op == 1)
            {
                CadenaSQL += " AND asr.Id_Subregion  =" + Users.id_subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
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
            if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 101).Permiso == true) || (us.Id_Tipoperfil == 1))
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
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosTarea dt = new DatosTarea();

            if (e.CommandName == "Select")
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 30).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                    dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    dt.NombrePoa = item.GetDataKeyValue("POA").ToString();
                    dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                    dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                    dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                    dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());

                    Session["info2"] = dt;
                   
                }
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Instrucciones del Regional");
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
                Respuesta.Visible = true;
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
                    if (gridDataItem2["FechaDeEntrega"].Text == gridDataItem3["FechaDeEntrega"].Text)
                    {
                        gridDataItem2["FechaDeEntrega"].RowSpan = gridDataItem3["FechaDeEntrega"].RowSpan < 2
                        ? 2
                        : gridDataItem3["FechaDeEntrega"].RowSpan + 1;
                        gridDataItem3["FechaDeEntrega"].Visible = false;
                    }
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