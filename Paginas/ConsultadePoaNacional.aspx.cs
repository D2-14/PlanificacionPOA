using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class ConsultadePoaNacional : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 400, 180, "Alerta", null);
                return;
            }
        }
        protected void Inicializacion_Objetos()
        {
            RadRegion.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegion.ItemCommand += new GridCommandEventHandler(RadRegion_ItemCommand);
            RadRegion.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.PreRender += new EventHandler(GdrDatosdeActividades_PreRender);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            /*Monitoreo*/
            RadRegion2.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegion2.ItemCommand += new GridCommandEventHandler(RadRegion2_ItemCommand);
            RadRegion2.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);
            GdrDatosdeActividades2.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades2_NeedDataSource);           
            GdrDatosdeActividades2.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad2);
            RegresarPantallaanterior2.Click += new EventHandler(RegresarPantallaanterior2_Click);
            /*encabezado*/
            GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);            
            GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);
            RegresarPantallaanterior3.Click += new EventHandler(RegresarPantallaanterior3_Click);

            
        }
        protected string Combo()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 1;";
        }               
        protected void Poas_ItemsRequested2(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combo(), "Descripcion", "Id", true);
        }
        protected void RadRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                UsuarioValida Us = (UsuarioValida)Session["DataUser"];
                string CadenaSQl;

                if ((Us.Id_Tipoperfil == 6) || (Us.Id_Tipoperfil == 8) || (Us.Id_Tipoperfil == 27) || (Us.Id_Tipoperfil == 4) || (Us.Id_Tipoperfil == 14)|| (Us.Id_Tipoperfil == 22))
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                        "/*and Id_Region in ( 81, 140, 142, 92, 135, 136, 138, 137, 143, 90, 91, 82,12,13,14,16,17,18,19,20,22)*/" +
                        " and r.Id_Region =" + Us.id_region + " order by  r.Nombre_Region;";
                }
                else
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 "+
                                "and Id_Region IN(12,81, 140,19, 142, 92, 135, 136, 138, 137, 143,147, 90, 91, 82, 13, 16,17, 20,22,18,14) order by  r.Nombre_Region; ";
                }
                procesos.LlenarRadGrid(RadRegion, CadenaSQl);
                procesos.LlenarRadGrid(RadRegion2, CadenaSQl);
            }
        }
        protected void RadRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1"+
                                 "/*AND ISNULL(Dato_Extra,0) != 1*/ " +
                                 "AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        UsuarioValida Us = (UsuarioValida)Session["DataUser"];

                        if ((Us.Id_Tipoperfil == 7) || (Us.Id_Tipoperfil == 8) || (Us.Id_Tipoperfil == 14))
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion =" + Us.id_subregion + ";";
                        }
                        else
                        {
                            int Region = Convert.ToInt32(dataItem.GetDataKeyValue("Id_Region").ToString());
                            if (Region == 13)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(76,78,94,508);";
                            }
                            else if (Region == 16)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(88,97,510);";
                            }
                            else if (Region == 12)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(516);";
                            }
                            else if (Region == 20)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(141,100,514);";
                            }
                            else if (Region == 14)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(95,502,509);";
                            }
                            else if (Region == 17)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(99,511);";
                            }
                            else if (Region == 18)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(102,500,512);";
                            }
                            else if (Region == 19) // Región VII-Noroccidente
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(101,513);";
                            }
                            else if (Region == 22)
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(144,501,504,515);";
                            }
                            else if (Region == 147)  // Region X
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(518,507,521);";
                            }
                            else if (Region == 81)  // Recursos Humanos
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(496,393,405);";
                            }
                            else if (Region == 92)  // Direccion de Desarrollo Forestal
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(409);";
                            }
                            else if (Region == 135)  // Direccion de Industria y Comercio
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(411);";
                            }
                            else if (Region == 136)  // Direccion de Manejo y Restauracion de Bosques
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(412);";
                            }
                            else if (Region == 137)  // Coordinacion tecnica nacional
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(497);";
                            }
                            else if (Region == 138)  // Planificación
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(458);";
                            }
                            else if (Region == 140)  // Dirección Administrativa Financiera
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(410);";
                            }
                            else if (Region == 142)  // Direccion de Coordinacion y Cooperacion sectorial
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(466);";
                            }
                            else if (Region == 143)  // Dirección de Asuntos Juridicos
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(498);";
                            }
                            else
                            {
                                CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();
                            }
                        }
                        procesos.LlenarRadGrid(RadRegion, CadenaString);
                        procesos.LlenarRadGrid(RadRegion2, CadenaString);
                        break;
                    }
            }
        }
        protected void RadRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");

            if (e.CommandName == "Select")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                        T01.Text = Dt.NombrePoa;
                        T02.Text = Dt.DescripcionSubregion;
                    }
                    if (M.VerificarCargaNacional(Dt) == true)
                    {
                        Session["info2"] = Dt;
                        Regiones.Visible = false;
                        poas.Visible = true;
                        VerificargRIDActividades();
                    }
                    else
                    {
                        MensajePantalla("No se le a aprobado el poa Todavia");
                    }
                }
            }
            if (e.CommandName == "Select1")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Op = 2; 
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCargaNacional(Dt) == true)
                    {
                        Session["info50"] = Dt;
                        Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
                    }
                    else
                    {
                        MensajePantalla("No se le a aprobado el poa Todavia");
                    }
                }
            }
        }
        protected void RadRegion2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();          
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            string Mes = string.Empty;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");
            RadComboBox comboBox2 = (RadComboBox)item.FindControl("Mes");

            if (e.CommandName == "Select")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                comboBox2.DataBind();
                string Valor2 = comboBox2.SelectedValue;
                if (Valor2 == string.Empty)
                {
                    Dt.Id_Mes = 0;
                }
                else
                {
                    Dt.Id_Mes = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    Mes = comboBox2.Text;
                }

                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else if (Dt.Id_Mes == 0)
                {
                    MensajePantalla("No Seleccionado el Mes de Consulta");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                        Tit01.Text = Dt.NombrePoa;
                        Tit02.Text = Dt.DescripcionSubregion;
                        Tit03.Text = "Mes de Ejecución " + Mes;
                    }
                    if (M.VerificarCargaNacional2(Dt) == true)
                    {
                        Session["info2"] = Dt;
                        NacionalMonitoreo.Visible = false;
                        poasNacional.Visible = true;
                        VerificargRIDActividades2();
                    }
                    else
                    {
                        MensajePantalla("No tiene ejecucion ingresada");
                    }
                }
            }
            if (e.CommandName == "Select1")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Op = 2;
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCargaNacional(Dt) == true)
                    {
                        Session["info50"] = Dt;
                        Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
                    }
                    else
                    {
                        MensajePantalla("No se le a aprobado el poa Todavia");
                    }
                }
            }
        }
        protected string ComboMes()
        {
            return "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses;";
        }
        protected void Poas_ItemsRequested1(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, ComboMes(), "Descripcion", "Id", true);
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
        protected void RadSearchBoxActividad2_Search(object sender, SearchBoxEventArgs e)
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
            VerificargRIDActividades2();
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
        protected void VerificargRIDActividades2()
        {
            GdrDatosdeActividades2.Rebind();
            if (GdrDatosdeActividades2.Items.Count != 0)
            {
                GdrDatosdeActividades2.Visible = true;
            }
            else
            {
                GdrDatosdeActividades2.Visible = false;
            }
        }
        protected string LlenarBusqueda()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string stringslq = string.Empty;

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",2"+ "," + Dt.Id_PoAnual;
            }
            return stringslq;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            procesos.LLenarBusquedaT(RadSearchBoxActividad, LlenarBusqueda(), "Descripcion", "Id", true);
            procesos.LLenarBusquedaT(RadSearchBoxActividad2, LlenarBusqueda(), "Descripcion", "Id", true);
            Inicializacion_Objetos();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                DatosTarea dt = new DatosTarea();
                Session["CadenaBusqueda"] = string.Empty;
                Session["d10"] = 0;
                Session["info2"] = dt;
                Session["d1"] = 0;                    
                poas.Visible = false;                            
            }

            CerraVentana.Click += new EventHandler(CerrarVentana_Click);
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_Nacional " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";
            procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
            procesos.LlenarRadGrid(GdrDatosdeActividades2, CadenaSql);
        }
        protected void GdrDatosdeActividades2_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_NacionalConsulta " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";           
            procesos.LlenarRadGrid(GdrDatosdeActividades2, CadenaSql);
        }
        protected void GrdIngresoEncabezado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "Sp_obtener_data_GridProductosNacionalesMonitoreo " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Convert.ToInt32(Session["d1"].ToString()) + "," + Dt.Id_Mes;
            procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
        }
        protected void Seleccionar_Actividad2(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
                      
            if (e.CommandName == "Select") 
            {               
                Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                VerificarDetalle();
            }                            
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {              
            GridDataItem item = e.Item as GridDataItem;
            Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
            VerificargRIDVentana();
        }
        protected void RegresarPantallaanterior3_Click(object sender, EventArgs e)
        {
            GrdIngresoEncabezado.Visible = false;
            DetalleIngreso.Visible = false;
            poasNacional.Visible = true;
        }
        protected void VerificarDetalle()
        {
            GrdIngresoEncabezado.Rebind();
            if (GrdIngresoEncabezado.Items.Count != 0)
            {               
                GrdIngresoEncabezado.Visible = true;
                DetalleIngreso.Visible = true;
                poasNacional.Visible = false;
            }
            else
            {
                MensajePantalla("- No Tiene Información Ingresada -");
                GrdIngresoEncabezado.Visible = false;
                DetalleIngreso.Visible = false;
                poasNacional.Visible = true;
            }        
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
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
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
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Regiones.Visible = true;
            poas.Visible = false;          
        }
        protected void RegresarPantallaanterior2_Click(object sender, EventArgs e)
        {
            NacionalMonitoreo.Visible = true;
            poasNacional.Visible = false;
        }
        protected void GrdIngresoEncabezado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMNacional(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void Seleccionar_Items(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }            
            if (Llave == 0)
            {

                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
                OpenWinwdows(VerDatosExtra, "520", "400", "Key", "Información Adicional del Ingresos");
            }
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {

            CloseWinwdows(visualizar, "Key");
        }


        /*Ventanas*/
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
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