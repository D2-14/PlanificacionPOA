using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.ExportarExcel
{
    public partial class ExcelPOARegionalVariado : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 330, 180, "Alerta", null);
                return;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GdrConfiguracion.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrConfiguracion.PreRender += new EventHandler(GdrConfiguracion_PreRender);
            GdrConfiguracion.ItemDataBound += GdrConfiguracion_ItemDataBound;
            ExportarEXCEL();
        }
        private void ExportarEXCEL()
        {
            string Titulo;
            string Titulos;
            DatosTarea Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            DataSet Datos;
            try
            {
                Dt = (DatosTarea)Session["info50"];
                Datos = d.Datospoatitulo(Dt);
                string Region = Datos.Tables[0].Rows[0]["Region"].ToString();
                string Subregion = Datos.Tables[0].Rows[0]["Subregion"].ToString();
                string Regional = Datos.Tables[0].Rows[0]["Subregional"].ToString();
                Titulo = "POA de la Subregion " + Subregion;

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>PLAN OPERATIVO ANUAL " + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN REGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Region + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN SUBREGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Subregion + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>Director Subregional&nbsp;&nbsp;&nbsp;&nbsp; " + Regional + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:justify;'>OBJETIVO GENERAL: Promover el desarrollo forestal del país y contribuir al desarrollo rural integral, a través del fomento al manejo sostenible y " +
                           "restauración<br/>de los bosques y tierras forestales, el fortalecimiento de la gobernanza forestal y la vinculación bosque industria mercado.<br/><br/></div>";

                GdrConfiguracion.MasterTableView.Caption = Titulos;
                #region [ XSLX FORMAT ]
                #endregion

                GdrConfiguracion.AllowSorting = false;
                GdrConfiguracion.ExportSettings.ExportOnlyData = false;
                GdrConfiguracion.ExportSettings.IgnorePaging = true;
                GdrConfiguracion.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                GdrConfiguracion.ExportSettings.OpenInNewWindow = true;
                GdrConfiguracion.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
            }
        }
        private void GdrConfiguracion_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrConfiguracion.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                }
            }
        }
        protected void GdrConfiguracion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["DescripcionProductoVeficable"];
                TableCell cell2 = item["DescripcionUM1"];
                TableCell cell3 = item["DescripcionUM2"];
                TableCell cell4 = item["DescripcionUM3"];
                TableCell cell5 = item["DescripcionUnidadMedida"];

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
                    cell5.BackColor = Color.Aquamarine;
                    cell5.Font.Bold = true;
                }
            }
        }
        protected void GdrConfiguracion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt;
            Dt = (DatosTarea)Session["info50"];
            procesos.LlenarRadGrid(GdrConfiguracion, "EXEC Sp_obtener_data_Actividad_SubregionalMensualExcel " + Dt.Id_PoAnual.ToString() + "," + Dt.Id_SubRegion.ToString() + ";");
        }
    }
}