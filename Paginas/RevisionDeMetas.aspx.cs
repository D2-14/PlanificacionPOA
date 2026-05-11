using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class RevisionDeMetas : System.Web.UI.Page
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
                                    + procesos.IntNULLCombo(CboSubcomponente) + "," + Dt.Id_SubRegion + ";";
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
            string Strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";           
            CboSubcomponente.ClearSelection();
            VerificargRID2();
            procesos.LLenarComboT(CboSubcomponente, Strsub, "Descripcion", "Id", true);
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
        protected void VerificarCambios_Click(object sender, EventArgs e)
        {
            VerificargRID3();
        }
        protected void VerificargRID3()
        {
            GdrCambios.Rebind();
            if (GdrCambios.Items.Count != 0)
            {
                CambiosPOA.Visible = true;
                VerificarCambios.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Show();", true);
            }
            else
            {
                VerificarCambios.Visible = false;
                CambiosPOA.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
            }
        }
        protected void VerificargRID4()
        {
            GdrCambios.Rebind();
            if (GdrCambios.Items.Count != 0)
            {
                VerificarCambios.Visible = true;
            }
            else
            {
                VerificarCambios.Visible = false;
                CambiosPOA.Visible = false;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
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
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            VerificarCambios.Click += new EventHandler(VerificarCambios_Click);
            CerrarVentanaDenegar.Click += new EventHandler(CerrarVentanaDenegar_Click);
            btnDenegar.Click += new EventHandler(BtnDenegar_Click);
            btncerrar.Click += new EventHandler(Btncerrar_Click);
            GdrCambios.NeedDataSource += new GridNeedDataSourceEventHandler(GdrCambios_NeedDataSource);
            GdrCambios.PreRender += new EventHandler(GdrCambios_PreRender);
            btnXLS.Click += new EventHandler(Btnxls_Click);
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
        protected string Grid(int op)
        {
            Users = (UsuarioValida)Session["DataUser"];            
            string CadenaSQL = "SELECT rmr.Id_PoAnual,rmr.IdMensaje,rmr.Id_Region,rmr.Id_Subregion,UPPER(pc.Descripcion_POA + ' ' + CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                        "mt.DescripcionMensaje Etapa,CONVERT(VARCHAR(12), rmr.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), rmr.FechaDeEntrega, 103) FechaDeEntrega," +
                        "rmr.EstadoDeAsignacion,r.Nombre_Region,SR.Subregion Nombre_SubRegion, rmr.Observaciones AS Instrucciones,rmr.Asignado,rmr.TipoAsignacion,isnull(rmr.NoReprogramacion,0) NoReprogramacion " +
                        "FROM RevisiondeMetasRegion rmr INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = rmr.Id_PoAnual INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = rmr.IdMensaje " +
                        "INNER JOIN Region r ON r.Id_Region = rmr.Id_Region INNER JOIN Subregion sr ON SR.Id_Subregion = rmr.Id_Subregion " +
                        "WHERE rmr.EstadoDeAsignacion = 1 AND ISNULL(Asignado,0) = 0 ";
            if (op == 1)
            {
                CadenaSQL += "AND rmr.Id_Region =" + Users.id_region + " ORDER BY  r.Id_Region,SR.Id_Subregion;";
            }
            else 
            {
                CadenaSQL += "ORDER BY  r.Id_Region,SR.Id_Subregion;";
            }
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
        protected void VerificargRID2() 
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0) { GdrDatosdeActividades.Visible = true; } else { GdrDatosdeActividades.Visible = false; }
        }
        protected void Btncerrar_Click(object sender, EventArgs e)
        {
            CambiosPOA.Visible = false;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
        }
        protected void Seleccionar_SubregionTarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosTarea dt = new DatosTarea();
            Manipulacion_de_Tareas x = new Manipulacion_de_Tareas();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (e.CommandName == "Select")
            {                
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.NombrePoa = item.GetDataKeyValue("POA").ToString();               

                string stringComando = "EXEC Sp_obtenerComboIngresoDSR " + dt.Id_PoAnual + ",0,1,"+dt.Id_SubRegion +";";
                procesos.LLenarComboT(CboComponente, stringComando, "Descripcion", "Id", true);
                T01.Text = dt.NombrePoa;
                T02.Text =item.GetDataKeyValue("Nombre_SubRegion").ToString() ;
                Session["info5"] = dt;
                ApartadodeMetas.Visible = true;
                GRDSubregiones.Visible = false;
                CboComponente.ClearSelection();
                CboSubcomponente.ClearSelection();
                VerificargRID2();
                VerificargRID4();
            }
            if (e.CommandName == "Select1")
            {
                txtInstruccion.Text = item.GetDataKeyValue("Instrucciones").ToString();
                OpenWinwdows(MensajeObserva, "500", "390", "Key1", "Observaciones de la Subregion");
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

                if (x.Enviar_tareaPlanificador(dt, ref er))
                {
                    VerificargRID();
                    Session["CambiosIngreso"] = 0;
                    MensajePantalla("Se envio la tarea al encargado de planificación");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
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
                dt.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                Session["info50"] = dt;

                Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarExcelPOA.aspx", "200", "200", "key5", "Exportar a excel POA");
            }
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
                if (x.Denegar_tareaSubregion(Dt, ref er))
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
        protected void CerrarVentanaDenegar_Click(object sender, EventArgs e) 
        {
            txtmensajeDenegado.Text = string.Empty;
            CloseWinwdows(DenegarMetas, "Key3");
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            ApartadodeMetas.Visible = false;
            GRDSubregiones.Visible = true;
            GRDSubregiones.Rebind();
            CboComponente.ClearSelection();
            CboSubcomponente.ClearSelection();
            VerificargRID2();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
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
                VerificargRID2();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
                DatosTarea dt = new DatosTarea();
                Session["info5"] = dt;
                Session["d10"] = 0;
            }
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajeObserva, "Key1");
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
        private void GdrCambios_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrCambios.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["IdComponente"].Text == gridDataItem3["IdComponente"].Text)
                    {
                        gridDataItem2["Componente"].RowSpan = gridDataItem3["Componente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Componente"].RowSpan + 1;
                        gridDataItem3["Componente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["Subcomponente"].RowSpan = gridDataItem3["Subcomponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Subcomponente"].RowSpan + 1;
                        gridDataItem3["Subcomponente"].Visible = false;
                    }
                }
            }
        }
        protected void GdrCambios_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info5"];
            string CadenaSql = "EXEC Sp_obtenerDatosDeCambios " + Dt.Id_PoAnual.ToString() + "," + Dt.Id_SubRegion.ToString() + ",1;";
            procesos.LlenarRadGrid(GdrCambios, CadenaSql);
        }
        protected void Btnxls_Click(object sender, EventArgs e)
        {
            string Titulo;
            string Titulos;
            DatosTarea dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            DataSet Datos;
            try
            {
                dt = (DatosTarea)Session["info5"];
                Datos = d.Datospoatitulo(dt);
                string Region = Datos.Tables[0].Rows[0]["Region"].ToString();
                string Subregion = Datos.Tables[0].Rows[0]["Subregion"].ToString();
                string Regional = Datos.Tables[0].Rows[0]["Subregional"].ToString();
                Titulo = "Correcciones POA Subregion " + Subregion;

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>CORRECCIONES AL PLAN OPERATIVO ANUAL " + d.Aniopoa(dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN REGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Region + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN SUBREGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Subregion + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>Director Subregional&nbsp;&nbsp;&nbsp;&nbsp; " + Regional + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:justify;'>OBJETIVO GENERAL: Promover el desarrollo forestal del país y contribuir al desarrollo rural integral, a través del fomento al manejo sostenible y" +
                           "restauración<br/>de los bosques y tierras forestales, el fortalecimiento de la gobernanza forestal y la vinculación bosque industria mercado.<br/><br/></div>";

                GdrCambios.ExportSettings.Excel.Format = (GridExcelExportFormat)Enum.Parse(typeof(GridExcelExportFormat), "Html");
                GdrCambios.MasterTableView.Caption = Titulos;
                GdrCambios.AllowSorting = false;
                GdrCambios.AllowFilteringByColumn = false;
                GdrCambios.ExportSettings.ExportOnlyData = false;
                GdrCambios.ExportSettings.IgnorePaging = true;
                GdrCambios.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd/MM/yyyy");
                GdrCambios.ExportSettings.OpenInNewWindow = true;
                GdrCambios.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
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