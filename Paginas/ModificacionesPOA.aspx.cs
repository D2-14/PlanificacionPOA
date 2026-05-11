using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class ModificacionesPOA : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 400, 180, "Alerta", null);
                return;
            }
        }
        protected void GdrCambios_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info85"];
            string CadenaSql = "EXEC Sp_obtenerDatosDeCambios " + Dt.Id_PoAnual.ToString() +","+ Dt.Id_SubRegion.ToString() + ",1;";            
            procesos.LlenarRadGrid(GdrCambios, CadenaSql);
        }
        protected void VerificargRID()
        {
            GdrCambios.Rebind();
            if (GdrCambios.Items.Count != 0)
            {
                GdrCambios.Visible = true;
                RespuestaAct.Visible = false;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Show();", true);
            }
            else
            {
                GdrCambios.Visible = false;
                RespuestaAct.Visible = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "Hide();", true);
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("MantenimientoPOAs.aspx");
        }
        protected void Inicializacion_Objetos()
        {
            GdrCambios.NeedDataSource += new GridNeedDataSourceEventHandler(GdrCambios_NeedDataSource);
            GdrCambios.PreRender += new EventHandler(GdrCambios_PreRender);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            btnXLS.Click += new EventHandler(Btnxls_Click);
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
                DatosTarea Dt = (DatosTarea)Session["info85"];
                T01.Text = Dt.NombrePoa;
                T02.Text = Dt.DescripcionSubregion;
                VerificargRID();
            }
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
        protected void Btnxls_Click(object sender, EventArgs e)
        {
            string Titulo;
            string Titulos;
            DatosTarea Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            DataSet Datos;

            try
            {
                Dt = (DatosTarea)Session["info85"];
                Datos = d.Datospoatitulo(Dt);
                string Region = Datos.Tables[0].Rows[0]["Region"].ToString();
                string Subregion = Datos.Tables[0].Rows[0]["Subregion"].ToString();
                string Regional = Datos.Tables[0].Rows[0]["Subregional"].ToString();
                Titulo = "Correcciones POA Subregion " + Subregion;

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>CORRECCIONES AL PLAN OPERATIVO ANUAL " + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN REGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Region + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN SUBREGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Subregion + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>Director Subregional&nbsp;&nbsp;&nbsp;&nbsp; " + Regional + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:justify;'>OBJETIVO GENERAL: Promover el desarrollo forestal del país y contribuir al desarrollo rural integral, a través del fomento al manejo sostenible y " +
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
    }
}