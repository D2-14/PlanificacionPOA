using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class RevisionDeMetasNacionales : System.Web.UI.Page
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
        protected void RadSearchBoxActividad_Search(object sender, SearchBoxEventArgs e)
        {
            string supplierID;

            if (e.Text != string.Empty)
            {
                supplierID = e.Value;
            }
            else
            {
                supplierID = string.Empty;
            }

            Session["CadenaBusqueda"] = supplierID;
            VerificargRIDActividades();
        }
        protected void VerificargRIDActividades()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0)
            {
                GdrDatosdeActividades.Visible = true;             
            }
            else
            {               
                GdrDatosdeActividades.Visible = false;
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            ApartadodeMetas.Visible = false;
            GRDSubregiones.Visible = true;
            GRDSubregiones.Rebind();
            VerificargRID();
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_Nacional " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";
            procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
        }
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + ";";
           procesos.LlenarRadGrid(GridUnidades, CadenaSql);
        }
        private void GdrDatosdeActividades_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrDatosdeActividades.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_producto"].Text == gridDataItem3["Id_producto"].Text)
                    {
                        gridDataItem2["DescripcionProducto"].RowSpan = gridDataItem3["DescripcionProducto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionProducto"].RowSpan + 1;
                        gridDataItem3["DescripcionProducto"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubProducto"].Text != "1")
                    {
                        if (gridDataItem2["Id_SubProducto"].Text == gridDataItem3["Id_SubProducto"].Text)
                        {
                            gridDataItem2["DescripcionSubProducto"].RowSpan = gridDataItem3["DescripcionSubProducto"].RowSpan < 2
                            ? 2
                            : gridDataItem3["DescripcionSubProducto"].RowSpan + 1;
                            gridDataItem3["DescripcionSubProducto"].Visible = false;
                        }
                    }
                }
            }
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {                      
            GridDataItem item = e.Item as GridDataItem;
            Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
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
                MensajePantalla("- No Ingresado Información a esta Actividad -");
                GridUnidades.Visible = false;
            }
        }
        protected string LlenarBusqueda()
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string stringslq = string.Empty;

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",1";
            }
            return stringslq;
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
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajeObserva, "Key1");
        }
        protected void CerrarVentanaDenegar_Click(object sender, EventArgs e)
        {
            txtmensajeDenegado.Text = string.Empty;
            CloseWinwdows(DenegarMetas, "Key3");
        }
        protected void CerrarVentanaTarea_Click(object sender, EventArgs e)
        {
            CloseWinwdows(FinalizarTareaVentana, "Key4");
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
                if (x.Denegar_tareaDepartamento(Dt, ref er))
                {
                    txtmensajeDenegado.Text = string.Empty;
                    VerificargRID();
                    CloseWinwdows(DenegarMetas, "Key3");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void FinalizarIngreso_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            DatosTarea Dt = (DatosTarea)Session["info5"];            
            Dt.Instrucciones = txtmensaje.Text.Trim();
            Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            if ((Dt.Instrucciones == string.Empty) || (Dt.Instrucciones.Length == 0))
            {
                MensajePantalla("Debe ingresar las observaciones");
            }
            else
            {
                if (x.Enviar_JefePlanificacion(Dt, ref er))
                {
                    VerificargRID();
                    txtmensaje.Text = string.Empty;
                    CloseWinwdows(FinalizarTareaVentana, "Key4");
                    MensajePantalla("Se envio la tarea al Jefe de planificación");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Inicializacion_Objetos()
        {
            GRDSubregiones.NeedDataSource += new GridNeedDataSourceEventHandler(GRDSubregiones_NeedDataSource);
            GRDSubregiones.PreRender += new EventHandler(GRDSubregiones_PreRender);
            GRDSubregiones.ItemCommand += new GridCommandEventHandler(Seleccionar_SubregionTarea);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
            btnDenegar.Click += new EventHandler(BtnDenegar_Click);
            CerrarVentanaDenegar.Click += new EventHandler(CerrarVentanaDenegar_Click);
            CerrarVentanaTarea.Click += new EventHandler(CerrarVentanaTarea_Click);
            FinalizarIngreso.Click += new EventHandler(FinalizarIngreso_Click);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);            
            GdrDatosdeActividades.PreRender += new EventHandler(GdrDatosdeActividades_PreRender);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            VerificarCambios.Click += new EventHandler(VerificarCambios_Click);
        }
        protected string Grid(int op)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT rmdn.Id_PoAnual,rmdn.IdMensaje,rmdn.Id_Region,rmdn.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                              "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), rmdn.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), rmdn.FechaDeEntrega, 103) FechaDeEntrega," +
                              "rmdn.EstadoDeAsignacion,r.Nombre_Region,SR.Subregion Nombre_SubRegion, rmdn.Observaciones AS Instrucciones,rmdn.Asignado,rmdn.TipoAsignacion," +
                              "isnull(rmdn.NoReprogramacion, 0) NoReprogramacion " +
                              "FROM RevisiondeMetasDirectoresNacionales rmdn INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = rmdn.Id_PoAnual " +
                              "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = rmdn.IdMensaje INNER JOIN Region r ON r.Id_Region = rmdn.Id_Region " +
                              "INNER JOIN Subregion sr ON SR.Id_Subregion = rmdn.Id_Subregion WHERE rmdn.EstadoDeAsignacion = 1 AND ISNULL(Asignado,0) = 0 ";

            if (op == 1)
            {
                CadenaSQL += "AND rmdn.Id_Region =" + Users.id_region + " ORDER BY  r.Id_Region,SR.Id_Subregion;";
            }
            else
            {
                CadenaSQL += "ORDER BY  r.Id_Region,SR.Id_Subregion;";
            }
            return CadenaSQL;
        }
        protected void GRDSubregiones_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            int Op;
            UsuarioValida Us = (UsuarioValida)Session["DataUser"];
            if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 86).Permiso == true) || (Us.Id_Tipoperfil == 1))
            {
                Op = 0;
            }
            else
            {
                Op = 1;
            }
            procesos.LlenarRadGrid(GRDSubregiones, Grid(Op));
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
        protected void Seleccionar_SubregionTarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosTarea dt = new DatosTarea();           
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();

            if (e.CommandName == "Select")
            {
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.NombrePoa = item.GetDataKeyValue("POA").ToString();
                
                T01.Text = dt.NombrePoa;
                T02.Text = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                dt.DescripcionSubregion = item.GetDataKeyValue("Nombre_SubRegion").ToString();
                dt.dependecia = 3; 
                Session["info5"] = dt;
                ApartadodeMetas.Visible = true;
                GRDSubregiones.Visible = false;
                Session["CadenaBusqueda"] = string.Empty;
                VerificargRIDActividades();

                if (M.VerificarModificacionesNacionales(dt) == true)
                {
                    VerificarCambios.Visible = true;
                    Session["info85"] = dt;
                }
                else
                {
                   VerificarCambios.Visible = false;
                }              
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajeObserva, "500", "390", "Key1", "Observaciones del Departamento");
            }
            if (e.CommandName == "Select2")
            {
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());

                Session["info5"] = dt;
                OpenWinwdows(FinalizarTareaVentana, "500", "390", "Key2", "Enviar POA al Jefe de Planificación");               
            }
            if (e.CommandName == "Select3")
            {
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                dt.FechaEntrega = item.GetDataKeyValue("FechaDeEntrega").ToString();
                dt.TipoAsignacion = Convert.ToInt32(item.GetDataKeyValue("TipoAsignacion").ToString());
                dt.NoReprogramacion = Convert.ToInt32(item.GetDataKeyValue("NoReprogramacion").ToString());
                Session["info5"] = dt;

               OpenWinwdows(DenegarMetas, "500", "390", "Key3", "Denegación de Metas");
            }
            if (e.CommandName == "Select4")
            {
                dt.Op = 1;
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Session["info50"] = dt;

                Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            procesos.LLenarBusquedaT(RadSearchBoxActividad, LlenarBusqueda(), "Descripcion", "Id", true);
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VerificargRID();               
                DatosTarea dt = new DatosTarea();
                Session["info5"] = dt;
                Session["d10"] = 0;
                Session["d1"] = 0;
            }
        }
        protected void VerificarCambios_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModificacionesPOANacional.aspx");
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