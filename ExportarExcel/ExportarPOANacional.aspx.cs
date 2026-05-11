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
    public partial class ExportarPOANacional : System.Web.UI.Page
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
        protected void GdrConfiguracion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {


            DatosTarea Dt; 
            Dt = (DatosTarea)Session["info50"];           
            procesos.LlenarRadGrid(GdrConfiguracion, "EXEC Sp_obtener_data_Actividad_NacionalPoaExcel " + 
                Dt.Op.ToString() +","+ Dt.Id_PoAnual.ToString() + ","+Dt.Id_Region.ToString() +","+ Dt.Id_SubRegion.ToString() + ";");

            
              }
            catch (Exception ex)
            {
                string mensaje =
                    "Mensaje: " + ex.Message + "\n" +
                    "Origen: " + ex.Source + "\n" +
                    "StackTrace: " + ex.StackTrace;

                // Mostrar o loguear
                throw new Exception(mensaje);
    }
}
        private void GdrConfiguracion_PreRender(object sender, EventArgs e)
        {

            try
            {



                foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrConfiguracion.Items)
                {
                    GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                    for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                    {
                        GridDataItem gridDataItem2 = ownerTableView.Items[index];
                        GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                        if (gridDataItem2["IdObjetivo"].Text == gridDataItem3["IdObjetivo"].Text)
                        {
                            gridDataItem2["Objetivo"].RowSpan = gridDataItem3["Objetivo"].RowSpan < 2
                            ? 2
                            : gridDataItem3["Objetivo"].RowSpan + 1;
                            gridDataItem3["Objetivo"].Visible = false;
                        }
                        if (gridDataItem2["IdResultado"].Text == gridDataItem3["IdResultado"].Text)
                        {
                            gridDataItem2["Resultado"].RowSpan = gridDataItem3["Resultado"].RowSpan < 2
                            ? 2
                            : gridDataItem3["Resultado"].RowSpan + 1;
                            gridDataItem3["Resultado"].Visible = false;
                        }
                        if (gridDataItem2["IdIndicadores"].Text == gridDataItem3["IdIndicadores"].Text)
                        {
                            gridDataItem2["Indicadores"].RowSpan = gridDataItem3["Indicadores"].RowSpan < 2
                            ? 2
                            : gridDataItem3["Indicadores"].RowSpan + 1;
                            gridDataItem3["Indicadores"].Visible = false;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string mensaje =
                    "Mensaje: " + ex.Message + "\n" +
                    "Origen: " + ex.Source + "\n" +
                    "StackTrace: " + ex.StackTrace;

                // Mostrar o loguear
                throw new Exception(mensaje);
            }
        }
        protected void GdrConfiguracion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            { 
            if (e.Item is GridDataItem)
            {               
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["Descripcion"];                

                if (Convert.ToInt32(item.GetDataKeyValue("Tipo").ToString()) == 1)
                {
                    cell1.BackColor = Color.LightGreen;
                    cell1.Font.Bold = true;                   
                }
                 if (Convert.ToInt32(item.GetDataKeyValue("Tipo").ToString()) == 2)
                {
                    cell1.BackColor = Color.LightBlue;
                    cell1.Font.Bold = true;
                }
                 TableCell cell2 = item["DescripcionUM1"];
                TableCell cell3 = item["DescripcionUM2"];
                TableCell cell4 = item["DescripcionUM3"];
                if (Convert.ToInt32(item.GetDataKeyValue("Id_RedProgramatica").ToString()) == 1)
                {
                    cell2.BackColor = Color.LightSkyBlue;
                    cell2.Font.Bold = true;
                    cell3.BackColor = Color.LightSkyBlue;
                    cell3.Font.Bold = true;
                    cell4.BackColor = Color.LightSkyBlue;
                    cell4.Font.Bold = true;
                }
            }
                

                }
            catch (Exception ex)
              {
                string mensaje =
                    "Mensaje: " + ex.Message + "\n" +
                    "Origen: " + ex.Source + "\n" +
                    "StackTrace: " + ex.StackTrace;

                // Mostrar o loguear
                throw new Exception(mensaje);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GdrConfiguracion.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);       
            GdrConfiguracion.ItemDataBound += GdrConfiguracion_ItemDataBound;
            GdrConfiguracion.PreRender += new EventHandler(GdrConfiguracion_PreRender);
            try
            {
            ExportarEXCEL();
            }
            catch (Exception ex)
            {
                string mensaje =
                    "Mensaje: " + ex.Message + "\n" +
                    "Origen: " + ex.Source + "\n" +
                    "StackTrace: " + ex.StackTrace;

                // Mostrar o loguear
                throw new Exception(mensaje);
            }
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
                Datos = d.DatospoatituloNacional(Dt);
                string Region = Datos.Tables[0].Rows[0]["Region"].ToString();
                string Subregion = Datos.Tables[0].Rows[0]["Subregion"].ToString();
                string Regional = Datos.Tables[0].Rows[0]["Subregional"].ToString();
                Titulo = "POA Nacional " + Subregion;

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>PLAN OPERATIVO ANUAL " + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN NACIONAL:&nbsp;&nbsp;&nbsp;&nbsp;" + Region + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DEPARTAMENTO/UNIDAD DE APOYO:&nbsp;&nbsp;&nbsp;&nbsp;" + Subregion + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>JEFE:&nbsp;&nbsp;&nbsp;&nbsp; " + Regional + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>";

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
    }
}