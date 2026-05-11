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
    public partial class Tareas_Jefe_Planificacion : System.Web.UI.Page
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
        protected void GdrDatosdeActividades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info5"];
            if ((procesos.IntNULLCombo(CboComponente) != 0) && (procesos.IntNULLCombo(CboSubcomponente) != 0))
            {
                Respuesta2.Visible = false;
                string CadenaSql = "EXEC Sp_obtener_data_Actividad_Subregional " + Dt.Id_PoAnual + "," + procesos.IntNULLCombo(CboComponente) + ","
                                    + procesos.IntNULLCombo(CboSubcomponente) + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ";";
                procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
            }
            else
            {
                Respuesta2.Visible = true;
            }
        }
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";
            CboSubcomponente.ClearSelection();
            VerificargRID2();
            procesos.LLenarComboT(CboSubcomponente, strsub, "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();            
            DatosTarea Dt = (DatosTarea)Session["info5"];
            Ris.Id_PoAnual = Dt.Id_PoAnual;
            Ris.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente));
            Ris.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente));
            Ris.Id_SubRegion = Dt.Id_SubRegion;

            VerificargRID2();
        }
        protected void Inicializacion_Objetos()
        {
            GRDSubregiones.NeedDataSource += new GridNeedDataSourceEventHandler(GRDSubregiones_NeedDataSource);
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.ItemDataBound += GdrDatosdeActividades_ItemDataBound;
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            GRDSubregiones.ItemCommand += new GridCommandEventHandler(Seleccionar_SubregionTarea);
            GRDSubregiones.PreRender += new EventHandler(GRDSubregiones_PreRender);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            CerrarVentanaDenegar.Click += new EventHandler(CerrarVentanaDenegar_Click);
            btnDenegar.Click += new EventHandler(BtnDenegar_Click);
            btncerrarVentanaMetas.Click += new EventHandler(BtncerrarVentanaMetas_Click);
            btnaprobarmetas.Click += new EventHandler(Btnaprobarmetas_Click);
        }
        protected void GRDSubregiones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            procesos.LlenarRadGrid(GRDSubregiones, Grid());
        }
        protected string Grid()
        {               
            string CadenaSQL = "SELECT ajp.Id_PoAnual,ajp.IdMensaje,ajp.Id_Region,ajp.Id_Subregion," +
                        "UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA,mt.DescripcionMensaje Etapa," +
                        "CONVERT(VARCHAR(12), ajp.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), ajp.FechaDeEntrega, 103) FechaDeEntrega," +
                        "ajp.EstadoDeAsignacion,r.Nombre_Region,SR.Subregion Nombre_SubRegion, ajp.Instrucciones,ajp.TipoAsignacion,isnull(ajp.NoReprogramacion,0) NoReprogramacion " +
                        "FROM AsignacionJefePlanificacion ajp INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = ajp.Id_PoAnual " +
                        "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = ajp.IdMensaje INNER JOIN Region r ON r.Id_Region = ajp.Id_Region " +
                        "INNER JOIN Subregion sr ON SR.Id_Subregion = ajp.Id_Subregion WHERE ajp.EstadoDeAsignacion = 1 ORDER BY r.Id_Region,SR.Id_Subregion;";
            return CadenaSQL;
        }
        protected void VerificargRID()
        {
            GRDSubregiones.Rebind();
            if (GRDSubregiones.Items.Count != 0)
            {
                GRDSubregiones.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                GRDSubregiones.Visible = false;
                Respuesta.Visible = true;
            }
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
        protected void VerificargRID2()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0) { GdrDatosdeActividades.Visible = true; } else { GdrDatosdeActividades.Visible = false; }
        }
        protected void Seleccionar_SubregionTarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosTarea Dt = new DatosTarea();
            Datos_AprobacionPoa co = new Datos_AprobacionPoa();

            if (e.CommandName == "Select")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.NombrePoa = item.GetDataKeyValue("POA").ToString();
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());

                string StringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1;";
                procesos.LLenarComboT(CboComponente, StringComando, "Descripcion", "Id", true);
                T01.Text = Dt.NombrePoa;
                T02.Text = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                Session["info5"] = Dt;
                ApartadodeMetas.Visible = true;
                GRDSubregiones.Visible = false;
                CboComponente.ClearSelection();
                CboSubcomponente.ClearSelection();
                VerificargRID2();
            }
            if (e.CommandName == "Select2")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());

                co.NombrePoa = item.GetDataKeyValue("POA").ToString();
                co.DescripcionSubregion = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                co.SubRegion = Dt.Id_SubRegion;

                Session["Correo"] = co; 
                Session["info51"] = Dt;
                OpenWinwdows(AprobarPOA, "500", "390", "Key3", "Aprobar el POA");                
            }
            if (e.CommandName == "Select3")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                Dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                Dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());

                Session["info5"] = Dt;
                OpenWinwdows(DenegarMetas, "500", "390", "Key3", "Observacion de Metas");
            }
            if (e.CommandName == "Select4")
            {
                Dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Session["info50"] = Dt;

                Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarExcelPOA.aspx", "200", "200", "key5", "Exportar a excel POA");
            }
        }
        protected void BtnDenegar_Click(object sender, EventArgs e)
        {            
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info5"];
            Dt.Instrucciones = txtmensajeDenegado.Text.Trim();

            if ((Dt.Instrucciones == string.Empty) || (Dt.Instrucciones.Length == 0))
            {
                MensajePantalla("Debe ingresar las observaciones de la denegación de metas");
            }
            else
            {
                if (x.Denegar_tareaARegiondelJefe(Dt, ref er))
                {
                    txtmensajeDenegado.Text = string.Empty;
                    VerificargRID();
                    Session["CambiosIngreso"] = 1;
                    CloseWinwdows(DenegarMetas, "Key3");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void CerrarVentanaDenegar_Click(object sender, EventArgs e)
        {
            txtmensajeDenegado.Text = string.Empty;
            CloseWinwdows(DenegarMetas, "Key3");
        }
        protected void Btnaprobarmetas_Click(object sender, EventArgs e)
        {
            Entrada_Sistema es = new Entrada_Sistema();
            Envio_Correos Correo = new Envio_Correos();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info51"];
            Datos_AprobacionPoa co =(Datos_AprobacionPoa)Session["Correo"];
            Dt.Instrucciones = txtAprobacionpoa.Text.Trim();
            co.Instrucciones = Dt.Instrucciones;

            if (x.Aprobar_tareaJefePlanificacion(Dt, ref er))
            {
                try
                {
                    co.Destinatario = es.ExtraerCorreo(co.SubRegion);
                    if (Correo.Enviar_Correo_Aprobado(co)){ }
                }
                catch{ }
                txtAprobacionpoa.Text = string.Empty;
                CloseWinwdows(AprobarPOA, "Key4");
                VerificargRID();
                MensajePantalla("Se aprobo la tarea del POA de la subregion");
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }           
        }
        protected void BtncerrarVentanaMetas_Click(object sender, EventArgs e)
        {
            txtAprobacionpoa.Text = string.Empty;
            CloseWinwdows(DenegarMetas, "Key4");
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            ApartadodeMetas.Visible = false;
            GRDSubregiones.Visible = true;
            GRDSubregiones.Rebind();
            CboComponente.ClearSelection();
            CboSubcomponente.ClearSelection();
            VerificargRID();
            VerificargRID2();
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 34).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
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
                VericarPermiso();
                VerificargRID();
                VerificargRID2();
                DatosTarea dt = new DatosTarea();
                Session["info5"] = dt;
                Session["d10"] = 0;
            }
        }
        private void GRDSubregiones_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GRDSubregiones.Items)
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
                    if (gridDataItem2["IdMensaje"].Text == gridDataItem3["IdMensaje"].Text)
                    {
                        gridDataItem2["Etapa"].RowSpan = gridDataItem3["Etapa"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Etapa"].RowSpan + 1;
                        gridDataItem3["Etapa"].Visible = false;
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
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            /*Abrir la ventana*/
            Session["d10"] = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
            VerificargRIDVentana();
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
                MensajePantalla("- No Tiene Información esta Actividad -");
                GridUnidades.Visible = false;
            }
        }
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];

            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 + "," +
                               + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + procesos.IntNULLCombo(CboComponente) + "," + procesos.IntNULLCombo(CboSubcomponente) + "," + Session["d10"].ToString() + ";";
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
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
    }
}