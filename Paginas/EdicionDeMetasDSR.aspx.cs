using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class EdicionDeMetasDSR : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD(); 
        public RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
        protected void Inicializacion_Objetos()
        {
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.ItemDataBound += GdrDatosdeActividades_ItemDataBound;           
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);                       
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            CerrarMetasEdicion.Click += new EventHandler(CerrarMetasEdicion_Click);
            /*edicion de valores de metas*/
            GridUnidadesEdicion.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidadesEdicion_NeedDataSource);
            RadCuatrimestre.NeedDataSource += new GridNeedDataSourceEventHandler(RadCuatrimestre_NeedDataSource);
            GridUnidadesEdicion.ItemCommand += new GridCommandEventHandler(Seleccionar_Meses);
            GuardarMetas.Click += new EventHandler(GuardarMetas_Click);            
            CancelarEdición.Click += new EventHandler(CancelarEdición_Click);
        }
        protected void RadCuatrimestre_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 2 + "," +
                               +Ris.Id_PoAnual + "," + Ris.Id_SubRegion + "," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_ProductoVeficable + ";";
            procesos.LlenarRadGrid(RadCuatrimestre, CadenaSql);
        }
        protected void GridUnidadesEdicion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 + "," +
                               +Ris.Id_PoAnual + "," + Ris.Id_SubRegion + "," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_ProductoVeficable + ";";
            procesos.LlenarRadGrid(GridUnidadesEdicion, CadenaSql);
        }
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];

           string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + "," + Session["d2"].ToString() + "," + Session["d3"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
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
        private void LimpiarCampos()
        {
            txtum1.Text = string.Empty;
            txtum2.Text = string.Empty;
            txtum3.Text = string.Empty;
            LblMes.Text = string.Empty;
            txtum1.ReadOnly = true;
            txtum2.ReadOnly = true;
            txtum3.ReadOnly = true;
        }
        protected void ShowHide(int op) 
        {
            if (op == 0)
            {
                GridSeleccionActividades.Visible = false;
                Encabezado.Visible = false;
                RegresarPantallaanterior.Visible = false;
                EdicionValoresMetas.Visible = true; 
            }
            else 
            {
                GridSeleccionActividades.Visible = true;
                Encabezado.Visible = true;
                RegresarPantallaanterior.Visible = true;
                EdicionValoresMetas.Visible = false;
            }
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {                                   
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;
            int valor = 0;

            if (e.CommandName == "Select")
            {
                valor = 1;
                Ris.Id_PoAnual = Dt.Id_PoAnual;
                Ris.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());
                Ris.Id_SubComponente = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Ris.Id_SubRegion = Dt.Id_SubRegion;
                Ris.RedProgramatica = Convert.ToInt32(item.GetDataKeyValue("Id_MetasRedProgramatica").ToString());
                Ris.NoPlanificable = Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString());
                Ris.Actividad = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                Ris.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                Ris.DUM1 = item.GetDataKeyValue("DescripcionUM1").ToString();
                Ris.DUM2 = item.GetDataKeyValue("DescripcionUM2").ToString();
                Ris.DUM3 = item.GetDataKeyValue("DescripcionUM3").ToString();
                Ris.idDUM1 = Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString());
                Ris.idDUM2 = Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString());
                Ris.idDUM3 = Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString());

                if (Ris.NoPlanificable == 0)
                {
                    Session["CargarMetasValor"] = Ris;
                    ShowHide(0);
                    FillEdition();
                    VerificargRID2();
                }
                else 
                {
                    MensajePantalla("Es una Actividad No Planificable, NO es necesario que tenga datos");
                }
            }
            /*Abrir la ventana*/
            if (valor == 0)
            {
                Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());
                Session["d2"] = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Session["d3"] = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                VerificargRIDVentana();
            }
        }
        protected void Seleccionar_Meses(object sender, GridCommandEventArgs e)
        {                        
            Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
            GridDataItem item = e.Item as GridDataItem;          
            ManipulacionIngresoValoresMetas x1 = new ManipulacionIngresoValoresMetas();

            if (e.CommandName == "Select")
            {                               
                if (Ris.NoPlanificable == 0)
                {
                    LblMes.Text = x1.Mes(Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString()));
                    txtum1.Text = item.GetDataKeyValue("Meta_UM1").ToString();
                    txtum2.Text = item.GetDataKeyValue("Meta_UM2").ToString();
                    txtum3.Text = item.GetDataKeyValue("Meta_UM3").ToString();
                    Session["Idmes"] = Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString());
                    
                    txtum1.ReadOnly = Valor(Ris.idDUM1);
                    txtum2.ReadOnly = Valor(Ris.idDUM2);
                    txtum3.ReadOnly = Valor(Ris.idDUM3);

                    GuardarMetas.Enabled = true;
                    GridUnidadesEdicion.MasterTableView.GetColumn("BotonA").Display = false;
                    CancelarEdición.Visible = true;
                }
                else
                {
                    MensajePantalla("No se ingresan valores porque es una actividad No planificable");
                }                
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
        protected void GdrDatosdeActividades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
            DatosTarea Dt = (DatosTarea)Session["info2"];
            if ((Ris.Id_Componente != 0) && (Ris.Id_SubComponente != 0))
            {
                Respuesta.Visible = false;
                string CadenaSql = "EXEC Sp_obtener_data_Actividad_Subregional " + Ris.Id_PoAnual + "," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_SubRegion + "," +
                                    Dt.TipoAsignacion + ";";
                procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
            }
            else
            {
                Respuesta.Visible = true;
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoPOAs.aspx");
        }
        protected void CerrarMetasEdicion_Click(object sender, EventArgs e)
        {           
            ShowHide(1);          
            LimpiarCampos();                     
            VerificargRID();
            FillEdition();
            if (GridUnidadesEdicion.Items.Count != 0) { GridUnidadesEdicion.MasterTableView.GetColumn("BotonA").Display = true; }            
        }
        protected void VerificargRID()
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
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {                      
            DatosTarea Dt = (DatosTarea)Session["info2"];           
            string Strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";           
            CboSubcomponente.ClearSelection();
            VerificargRID();
            procesos.LLenarComboT(CboSubcomponente, Strsub, "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {                        
            DatosTarea Dt = (DatosTarea)Session["info2"];
            Ris.Id_PoAnual = Dt.Id_PoAnual;
            Ris.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente));
            Ris.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente));
            Ris.Id_SubRegion = Dt.Id_SubRegion;
            Session["CargarMetasValor"] = Ris;
            VerificargRID();
        }
        protected void CargarData()
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];
                                        
            T01.Text = Dt.NombrePoa; 
            T02.Text = Dt.DescripcionSubregion; 
            string StringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1,0;";
            procesos.LLenarComboT(CboComponente, StringComando, "Descripcion", "Id", true);            
        }
        protected void Normal_informacion()
        {
            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
            Session["CargarMetasValor"] = Ris;
            CboSubcomponente.ClearSelection();
            CboComponente.ClearSelection();
            VerificargRID();
            Session["d1"] = 0;
            Session["d2"] = 0;
            Session["d3"] = 0;
            VerificargRID2();
        }
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        private bool Valor(int op)
        {
            bool v = true;
            if (op != 0) { return false; }

            return v;
        }
        private bool Valor2(int op)
        {
            bool v = false;
            if (op != 0) { return true; }

            return v;
        }
        protected void VerificargRID2()
        {
            GridUnidadesEdicion.Rebind();
            RadCuatrimestre.Rebind();
            if (GridUnidadesEdicion.Items.Count != 0)
            {
                GridUnidadesEdicion.Visible = true;
                RadCuatrimestre.Visible = true;
                resp.Visible = false;
            }
            else
            {
                GridUnidadesEdicion.Visible = false;
                RadCuatrimestre.Visible = false;
                resp.Visible = true;
            }
        }
        protected void FillEdition()
        {           
            Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            if (Ris.RedProgramatica == 1)
            {
                MensajeTipo.Visible = true;
            }
            else
            {
                MensajeTipo.Visible = false;
            }
            txtum1.ReadOnly = true;
            txtum2.ReadOnly = true;
            txtum3.ReadOnly = true;

            LblUM1.Text = Ris.DUM1;
            LblUM2.Text = Ris.DUM2;
            LblUM3.Text = Ris.DUM3;
            LblMes.Text = string.Empty;

            RUM1.Visible = Valor2(Ris.idDUM1);
            RUM2.Visible = Valor2(Ris.idDUM2);
            RUM3.Visible = Valor2(Ris.idDUM3);

            lblActividad.Text = Ris.Actividad;           
            GuardarMetas.Enabled = false;
            CancelarEdición.Visible = false;
        }
        protected void GuardarMetas_Click(object sender, EventArgs e)
        {
            GuardarMetasSubregion gms = new GuardarMetasSubregion();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();                       
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            RegresoInformacionSubregional Ris =(RegresoInformacionSubregional)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ris.Id_PoAnual;
            gms.Id_Subregion = Ris.Id_SubRegion;
            gms.Id_Componente = Ris.Id_Componente;
            gms.Id_SubComponente = Ris.Id_SubComponente;
            gms.Id_ProductoVeficable = Ris.Id_ProductoVeficable;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
            gms.Id_Mes = Convert.ToInt32(Session["Idmes"].ToString());
            gms.UM1 = procesos.DecimalRadNumericTextBox(txtum1);
            gms.UM2 = procesos.DecimalRadNumericTextBox(txtum2);
            gms.UM3 = procesos.DecimalRadNumericTextBox(txtum3);

            if (x.Edicion_de_ValoresMetas(gms, ref er))
            {
                MensajePantalla("Se ha agregado el valor Correctamente...");
                GuardarMetas.Enabled = false;
                LimpiarCampos();
                CancelarEdición.Visible = false;
                GridUnidadesEdicion.MasterTableView.GetColumn("BotonA").Display = true;
                VerificargRID2(); 
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void CancelarEdición_Click(object sender, EventArgs e)
        {
            CancelarEdición.Visible = false;
            GridUnidadesEdicion.MasterTableView.GetColumn("BotonA").Display = true;
            GuardarMetas.Enabled = false;
            LimpiarCampos();
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
              CargarData();             
             Normal_informacion();             
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