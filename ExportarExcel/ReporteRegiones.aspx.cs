using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Telerik.Web.UI.GridExcelBuilder;

namespace PlanificacionPOA.ExportarExcel
{
    public partial class ReporteRegiones : System.Web.UI.Page
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
            string Cadena;
            DatosReporte Dt = (DatosReporte)Session["info2"];

            Cadena = "EXEC Sp_obtener_data_Reportes_GeneralExcel "
                   + Dt.Id_Reporte + "," + Dt.Is_Sicoin + "," + Dt.Id_PoAnual.ToString() + "," + Dt.Id_Region + "," + Dt.Id_SubRegion.ToString() +","+ Dt.Id_Perfil +";";

            if (Dt.Id_Reporte == 1) 
            {
                if (Dt.Is_Sicoin == 1)
                {
                    procesos.LlenarRadGrid(GdrNacionalRED, Cadena);
                }
                else
                {
                    procesos.LlenarRadGrid(GdrNacional, Cadena);
                } 
            }
            if (Dt.Id_Reporte == 2) { procesos.LlenarRadGrid(GdrRegional, Cadena); }
            if (Dt.Id_Reporte == 3) { procesos.LlenarRadGrid(GdrSubRegional, Cadena); }            
            if (Dt.Id_Reporte == 4) { procesos.LlenarRadGrid(GdrSicoin, Cadena); }            
        }
        private void GdrNacional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrNacional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                }
            }
        }
        private void GdrNacionalRED_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrNacionalRED.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                }
            }
        }
        private void GdrRegional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrRegional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                }
            }
        }
        private void GdrSubRegional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrSubRegional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                }
            }
        }
        private void GdrSicoin_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrSicoin.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_SubComponente"].Text == gridDataItem3["Id_SubComponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }
                }
            }
        }        
        protected void Gdrgeneral_ItemDataBound(object sender, GridItemEventArgs e)
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
        protected void Iniciar() 
        {            
            GdrNacional.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrNacional.PreRender += new EventHandler(GdrNacional_PreRender);
            GdrNacional.ItemDataBound += Gdrgeneral_ItemDataBound;
            GdrNacionalRED.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrNacionalRED.PreRender += new EventHandler(GdrNacionalRED_PreRender);
            GdrNacionalRED.ItemDataBound += Gdrgeneral_ItemDataBound;
            GdrRegional.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrRegional.PreRender += new EventHandler(GdrRegional_PreRender);
            GdrRegional.ItemDataBound += Gdrgeneral_ItemDataBound;            
            GdrSubRegional.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrSubRegional.PreRender += new EventHandler(GdrSubRegional_PreRender);
            GdrSubRegional.ItemDataBound += Gdrgeneral_ItemDataBound;
            GdrSicoin.NeedDataSource += new GridNeedDataSourceEventHandler(GdrConfiguracion_NeedDataSource);
            GdrSicoin.PreRender += new EventHandler(GdrSicoin_PreRender);
            GdrSicoin.ItemDataBound += Gdrgeneral_ItemDataBound;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Iniciar();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                GdrNacionalRED.Visible = false;
                GdrNacional.Visible = false;
                GdrRegional.Visible = false;
                GdrSubRegional.Visible = false;
                GdrSicoin.Visible = false;
                DatosReporte Dt = (DatosReporte)Session["info2"];
                if (Dt.Id_Reporte == 1)
                {
                    if (Dt.Is_Sicoin == 1)
                    {
                        GdrNacionalRED.Visible = true;
                    }
                    else
                    {
                        GdrNacional.Visible = true;
                    }
                    ExportarEXCELNacional();
                }
                if (Dt.Id_Reporte == 2)
                {
                    GdrRegional.Visible = true;
                    ExportarEXCELRegional();
                }
                if (Dt.Id_Reporte == 3)
                {
                    GdrSubRegional.Visible = true;
                    ExportarEXCELSubRegional();
                }

                if (Dt.Id_Reporte == 4)
                {
                    GdrSicoin.Visible = true;
                    ExportarEXCELSicoin();
                }
            }
        }
        private void ExportarEXCELNacional()
        {
            string Titulo;
            string Titulos;
            DatosReporte Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            try
            {
                Dt = (DatosReporte)Session["info2"];
                if (Dt.Is_Sicoin == 1)
                {
                    Titulo = "Reporte Metas RED Nacional ";
                }
                else
                {
                    Titulo = "Reporte Nacional ";
                }

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>" + Titulo.ToString() + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>";


                if (Dt.Is_Sicoin == 1)
                {
                    GdrNacionalRED.MasterTableView.Caption = Titulos;
                    #region [ XSLX FORMAT ]
                    #endregion

                    GdrNacionalRED.AllowSorting = false;
                    GdrNacionalRED.ExportSettings.ExportOnlyData = false;
                    GdrNacionalRED.ExportSettings.IgnorePaging = true;
                    GdrNacionalRED.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                    GdrNacionalRED.ExportSettings.OpenInNewWindow = true;
                    GdrNacionalRED.MasterTableView.ExportToExcel();
                }
                else 
                {  

                    GdrNacional.MasterTableView.Caption = Titulos;
                    #region [ XSLX FORMAT ]
                    #endregion

                    GdrNacional.AllowSorting = false;
                    GdrNacional.ExportSettings.ExportOnlyData = false;
                    GdrNacional.ExportSettings.IgnorePaging = true;
                    GdrNacional.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                    GdrNacional.ExportSettings.OpenInNewWindow = true;
                    GdrNacional.MasterTableView.ExportToExcel();
                }
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
            }
        }
        private void ExportarEXCELRegional()
        {
            string Titulo;
            string Titulos;
            DatosReporte Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();           
            try
            {
                Dt = (DatosReporte)Session["info2"];                                
                if(Dt.Is_Sicoin == 1) 
                {
                    Titulo = "Reporte Metas RED Regional ";
                }
                else 
                {
                    Titulo = "Reporte Regional ";
                }
               
                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>"+Titulo.ToString() + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +                          
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>";

                GdrRegional.MasterTableView.Caption = Titulos;
                #region [ XSLX FORMAT ]
                #endregion

                GdrRegional.AllowSorting = false;
                GdrRegional.ExportSettings.ExportOnlyData = false;
                GdrRegional.ExportSettings.IgnorePaging = true;
                GdrRegional.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                GdrRegional.ExportSettings.OpenInNewWindow = true;
                GdrRegional.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
            }
        }
        private void ExportarEXCELSubRegional()
        {
            string Titulo;
            string Titulos;
            DatosReporte Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            try
            {
                Dt = (DatosReporte)Session["info2"];
                if (Dt.Is_Sicoin == 1)
                {
                    Titulo = "Reporte Metas RED SubRegional ";
                }
                else
                {
                    Titulo = "Reporte SubRegional ";
                }

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>" + Titulo.ToString() + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>";

                GdrSubRegional.MasterTableView.Caption = Titulos;
                #region [ XSLX FORMAT ]
                #endregion

                GdrSubRegional.AllowSorting = false;
                GdrSubRegional.ExportSettings.ExportOnlyData = false;
                GdrSubRegional.ExportSettings.IgnorePaging = true;
                GdrSubRegional.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                GdrSubRegional.ExportSettings.OpenInNewWindow = true;
                GdrSubRegional.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
            }
        }
        private void ExportarEXCELSicoin()
        {
            string Titulo;
            string Titulos;
            DatosReporte Dt;
            ManipulacionIngresoValoresMetas d = new ManipulacionIngresoValoresMetas();
            DataSet Datos;
            try
            {
                 Dt = (DatosReporte)Session["info2"];              
                Datos = d.DatospoatituloReporte(Dt);
                string Region = Datos.Tables[0].Rows[0]["Region"].ToString();
                string Subregion = Datos.Tables[0].Rows[0]["Subregion"].ToString();
                string Regional = Datos.Tables[0].Rows[0]["Subregional"].ToString();
                Titulo = "Reporte Metas RED de la " + Subregion;

                Titulos = "<div style='font-weight:bold;font-size:18;text-align:center;'>REPORTE METAS RED " + d.Aniopoa(Dt.Id_PoAnual) + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN REGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Region + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN SUBREGIONAL&nbsp;&nbsp;&nbsp;&nbsp;" + Subregion + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>Director Subregional&nbsp;&nbsp;&nbsp;&nbsp; " + Regional + "</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>INSTITUTO NACIONAL DE BOSQUES -INAB-</div>" +
                          "<div style='font-weight:bold;font-size:14;text-align:left;'>DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL <br/></div>";

                GdrSicoin.MasterTableView.Caption = Titulos;
                #region [ XSLX FORMAT ]
                #endregion

                GdrSicoin.AllowSorting = false;
                GdrSicoin.ExportSettings.ExportOnlyData = false;
                GdrSicoin.ExportSettings.IgnorePaging = true;
                GdrSicoin.ExportSettings.FileName = Titulo.ToString() + ' ' + DateTime.Now.ToString("dd-MM-yyyy");
                GdrSicoin.ExportSettings.OpenInNewWindow = true;
                GdrSicoin.MasterTableView.ExportToExcel();
            }
            catch (Exception ex)
            {
                MensajePantalla("ERROR en la Descarga" + ex.Message);
            }
        }

    }
}