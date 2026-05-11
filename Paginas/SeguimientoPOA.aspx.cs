
using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
namespace PlanificacionPOA.Paginas
{
    public partial class SeguimientoPOA : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public UsuarioValida Users = new UsuarioValida();
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

          //  CerraVentana.Click += new EventHandler(CerrarVentana_Click);
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

            GridTareaP.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea);
            GridTareaP_regiones.ItemCommand += new GridCommandEventHandler(Seleccionar_Tarea_regiones);

            //RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            ///*Monitoreo*/
            RdRegion.NeedDataSource += new GridNeedDataSourceEventHandler(RdRegion_NeedDataSource);
            RdRegion.ItemCommand += new GridCommandEventHandler(RdRegion_ItemCommand);
            RdRegion.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RdRegion_DetailTableDataBind);


            btnRegresar.Click += new EventHandler(btnRegresar_Click);


            

            //GdrDatosdeActividades2.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades2_NeedDataSource);
            //GdrDatosdeActividades2.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad2);
            //RegresarPantallaanterior2.Click += new EventHandler(RegresarPantallaanterior2_Click);
            ///*encabezado*/
            //GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            //GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            //GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);
            //RegresarPantallaanterior3.Click += new EventHandler(RegresarPantallaanterior3_Click);


        }




        protected void btnRegresar_Click(object sender, EventArgs e)
        {
           

        }


        protected void RdRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                UsuarioValida Us = (UsuarioValida)Session["DataUser"];
                string CadenaSQl;

                if ((Us.Id_Tipoperfil == 5) || (Us.Id_Tipoperfil == 7))
                {
                    Region_.Visible = true;
                    Opcion1.Visible = true;
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1 and r.Id_Region =" + Us.id_region + ";";
                }
                else if ((Us.Id_Tipoperfil == 4))
                {
                    Region_.Visible = false;
                    Opcion1.Visible = true;

                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1 and r.Id_Region =" + Us.id_region + ";";
                }
                else
                {
                    Region_.Visible = true;
                    Opcion1.Visible = true;
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1;";
                }
                procesos.LlenarRadGrid(RdRegion, CadenaSQl);
             
            }
        }


        protected void RdRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 //"WHERE Id_Estado_Subregion = 1 and Codigo_SubRegion >= 1 and Codigo_SubRegion != 99 AND Id_Region = ";
                                 "WHERE Id_Subregion in (470, 103, 104, 105, 106, 107, 108, 143, 110, 111, 112, 113, 114, 115, 471, 145, 146, 147, 148, 120, 121, 122, 123, 124, 125, 150, 126, 127, 128, 129, 130, 131, 132, 133, 134, 505, 520, 519, 506) AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        UsuarioValida Us = (UsuarioValida)Session["DataUser"];

                        if (Us.Id_Tipoperfil == 7)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion =" + Us.id_subregion + ";";
                        }
                        else
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();
                        }
                        procesos.LlenarRadGrid(RdRegion, CadenaString);
                   
                        break;
                    }
            }
        }

        protected void RdRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {

            ConectarBDD procesos = new ConectarBDD();
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
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
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    int mesActual = DateTime.Now.Month;

                    if (Convert.ToInt32(comboBox2.SelectedValue.ToString()) > 0)
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
                            Session["Id_POA"] = Convert.ToInt32(comboBox.SelectedValue.ToString());
                            Session["Mes"] = Convert.ToInt32(comboBox2.SelectedValue.ToString());



                            //Parametros del procedimiento
                            procesos.AgregarParametro("@Id_Poa", SqlDbType.Int, Dt.Id_PoAnual);
                            procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Dt.Id_Usuario);
                            procesos.AgregarParametro("@Id_Region", SqlDbType.Int, Dt.Id_Region);
                            procesos.AgregarParametro("@Id_Subregion", SqlDbType.Int, Dt.Id_SubRegion);
                            procesos.AgregarParametro("@Mes", SqlDbType.Int, comboBox2.SelectedValue);

                            procesos.Execute("Sp_In_MantenimientoMes_Regiones");

                        }


                        //if (M.VerificarCargaNacional(Dt) == true)
                        //{
                            Session["info2"] = Dt;
                            Regiones.Visible = false;
                            poas.Visible = false;
                            VerificargRIDActividades();

                            CargarDatos_regiones(Dt.Id_SubRegion);


                         Tareas_Regiones.Visible = true;
                        //}
                        //else
                        //{
                        //    MensajePantalla("No se le a aprobado el poa Todavia");
                        //}

                    }
                    else
                    {
                        MensajePantalla("Mes invalido.");

                    }

                }
            }
        }

        protected void GdrDatosdeActividades_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "EXEC Sp_obtener_data_Actividad_Nacional " + Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Dt.TipoAsignacion + ",'" + Session["CadenaBusqueda"].ToString() + "';";
            procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);

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
        protected string LlenarBusqueda()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string stringslq = string.Empty;

            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",2" + "," + Dt.Id_PoAnual;
            }
            return stringslq;
        }

        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 400, 180, "Alerta", null);
                return;
            }
        }

        protected void RadRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                UsuarioValida Us = (UsuarioValida)Session["DataUser"];
                string CadenaSQl;

                if ((Us.Id_Tipoperfil == 6)  || (Us.Id_Tipoperfil == 4) || (Us.Id_Tipoperfil == 14))
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                        "and Id_Region IN(81, 140, 142, 92, 135, 136, 138, 137, 143, 90, 91, 82, 13, 16, 20) and r.Id_Region =" + Us.id_region + " order by  r.Nombre_Region;";
                }
                else
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                                "and Id_Region IN(81, 140, 142, 92, 135, 136, 138, 137, 143, 90, 91, 82, 12, 13, 14, 16, 17, 20,22,18, 19, 147) order by  r.Nombre_Region; ";
                }



            




                procesos.LlenarRadGrid(RadRegion, CadenaSQl);
                //procesos.LlenarRadGrid(RadRegion2, CadenaSQl);
            }
        }

        //protected void RadRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        //{
        //    GridDataItem dataItem = e.DetailTableView.ParentItem;
        //    string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
        //                         "WHERE Id_Estado_Subregion = 1 AND ISNULL(Dato_Extra,0) != 1 AND Id_Region = ";
        //    switch (e.DetailTableView.Name)
        //    {
        //        case "SubRegion":
        //            {
        //                UsuarioValida Us = (UsuarioValida)Session["DataUser"];

        //                if (Us.Id_Tipoperfil == 8)
        //                {
        //                    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();
        //                }

        //                //if ((Us.Id_Tipoperfil == 7) || (Us.Id_Tipoperfil == 8) || (Us.Id_Tipoperfil == 14))
        //                //{
        //                //    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion =" + Us.id_subregion + ";";
        //                //}
        //                //else
        //                //{
        //                //    int Region = Convert.ToInt32(dataItem.GetDataKeyValue("Id_Region").ToString());
        //                //    if (Region == 13)
        //                //    {
        //                //        CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(76,78);";
        //                //    }
        //                //    else if (Region == 16)
        //                //    {
        //                //        CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(88);";
        //                //    }
        //                //    else if (Region == 20)
        //                //    {
        //                //        CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(141);";
        //                //    }
        //                //    else
        //                //    {
        //                //        CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();
        //                //    }
        //                //}
        //                procesos.LlenarRadGrid(RadRegion, CadenaString);
        //                //procesos.LlenarRadGrid(RadRegion2, CadenaString);
        //                break;
        //            }
        //    }
        //}


        protected void RadRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        int Region = Convert.ToInt32(dataItem.GetDataKeyValue("Id_Region").ToString());

                        RadTab ValorTab = ControladorTAb.SelectedTab;

                            if (ValorTab.SelectedIndex==0 || ValorTab.SelectedIndex == -1)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion not in(470, 103, 104, 105, 106, 107, 108, 143, 110, 111, 112, 113, 114, 115, 471, 145, 146, 147, 148, 120, 121, 122, 123, 124, 125, 150, 126, 127, 128, 129, 130, 131, 132, 133, 134, 505, 520, 519, 506);";
                        }
                            else
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(470, 103, 104, 105, 106, 107, 108, 143, 110, 111, 112, 113, 114, 115, 471, 145, 146, 147, 148, 120, 121, 122, 123, 124, 125, 150, 126, 127, 128, 129, 130, 131, 132, 133, 134, 505, 520, 519, 506);";
                        }

                        //if (Region == 13)
                        //{
                        //    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(76,78);";
                        //}
                        //else if (Region == 16)
                        //{
                        //    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(88, 97, 483, 510);";
                        //}
                        //else if (Region == 20)
                        //{
                        //    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(141);";
                        //}
                        //else
                        //{
                        //    CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + " ORDER BY Subregion";
                        //}
                        procesos.LlenarRadGrid(RadRegion, CadenaString);
                        break;
                    }
            }
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

        protected void RadRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            ConectarBDD procesos = new ConectarBDD();
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
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    int mesActual = DateTime.Now.Month;
                    if (Convert.ToInt32(comboBox2.SelectedValue.ToString()) <= mesActual)
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
                        Session["Id_POA"]= Convert.ToInt32(comboBox.SelectedValue.ToString());
                        Session["Mes"]= Convert.ToInt32(comboBox2.SelectedValue.ToString());

                  

                        //Parametros del procedimiento
                        procesos.AgregarParametro("@Id_Poa", SqlDbType.Int, Dt.Id_PoAnual);
                        procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Dt.Id_Usuario);
                        procesos.AgregarParametro("@Id_Region", SqlDbType.Int, Dt.Id_Region);
                        procesos.AgregarParametro("@Id_Subregion", SqlDbType.Int, Dt.Id_SubRegion);
                        procesos.AgregarParametro("@Mes", SqlDbType.Int, comboBox2.SelectedValue);

                            procesos.Execute("Sp_In_MantenimientoMes");
                       
                    }

                    if (M.VerificarCargaNacional(Dt) == true)
                    {
                        Session["info2"] = Dt;
                        Nacionales.Visible = false;
                        poas.Visible = false;
                        VerificargRIDActividades();

                        CargarDatos(Dt.Id_SubRegion);
                        

                        Tareas.Visible = true;
                    }
                    else
                    {
                        MensajePantalla("No se le a aprobado el poa Todavia");
                    }

                    }
                    else
                    {
                        MensajePantalla("Mes invalido.");

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


        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
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


        protected string Combo()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 2;";
        }
        protected string CombosNacionales()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 1;";
        }

        // Combo Mes
        protected void Poas_ItemsRequested1(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, ComboMes(), "Descripcion", "Id", true);
        }

        protected void Poas_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, CombosNacionales(), "Descripcion", "Id", true);
            
            if (Session["Mes_"] != null) {

                comboBox.SelectedValue = Session["Id_POA_"].ToString();
                
            }
        }

        protected void Poas_ItemsRequested2(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combo(), "Descripcion", "Id", true);
        }

        protected string ComboMes()
        {
            return "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses;";
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

        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }

        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
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

        //protected void GridTareaP_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        //{
        //    int Op;
        //    UsuarioValida us = (UsuarioValida)Session["DataUser"];
        //    PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
        //    if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 92).Permiso != true) && (us.Id_Tipoperfil == 1))
        //    {
        //        Op = 0;
        //    }
        //    else
        //    {
        //        Op = 1;
        //    }
        //    procesos.LlenarRadGrid(GridTareaP, Grid(Op));
        //}


        //protected void GridTareaP_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        //{
        //    CargarDatos(); // El grid llama este evento automáticamente cuando necesita datos
        //}

        private void CargarDatos(int Subregion)
        {
            //GridTareaP.DataSource = Grid(306); // Tu lógica para cargar datos

            procesos.LlenarRadGrid(GridTareaP, Grid(Subregion));
            GridTareaP.Rebind();
        }


        private void CargarDatos_regiones(int Subregion)
        {
            //GridTareaP.DataSource = Grid(306); // Tu lógica para cargar datos

            procesos.LlenarRadGrid(GridTareaP_regiones, Grid_regiones(Subregion));
            GridTareaP_regiones.Rebind();
        }



        protected void Seleccionar_Tarea(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas();

            if (e.CommandName == "Select")
            {

                DMI.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                DMI.NombrePOA = item.GetDataKeyValue("POA").ToString();
                DMI.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                DMI.Nombre_Region = item.GetDataKeyValue("Nombre_Region").ToString();
                DMI.Nombre_SubRegion = item.GetDataKeyValue("Subregion").ToString();
                DMI.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                DMI.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                DMI.Fecha_Final = item.GetDataKeyValue("Fecha_Final").ToString();
                DMI.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
                DMI.Descripcion_mes = item.GetDataKeyValue("mes").ToString();
                DMI.Id_Mensaje = Convert.ToInt32(item.GetDataKeyValue("IdMensaje").ToString());
                DMI.Instrucciones = item.GetDataKeyValue("Instrucciones").ToString();



                Session["Mantenimiento"] = "True";
                Session["infoNacionalMonitoreo"] = DMI;
                Response.Redirect("ActividadNacionalMonitoreo.aspx");

            }
            }
         protected void Seleccionar_Tarea_regiones(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas();     
        

            if (e.CommandName == "Select")
            {

                DMI.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                DMI.NombrePOA = item.GetDataKeyValue("POA").ToString();
                DMI.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                DMI.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                DMI.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                //DMI.Fecha_Inicio = item.GetDataKeyValue("Fecha_Inicio").ToString();
                //DMI.Fecha_Final = item.GetDataKeyValue("Fecha_Final").ToString();
                DMI.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
                DMI.Descripcion_mes = item.GetDataKeyValue("mes").ToString();
                DMI.Nombre_SubRegion = item.GetDataKeyValue("Subregion").ToString();

                Session["Mantenimiento"] = "True";            
                Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
                Response.Redirect("Componentes_Monitoreo.aspx");          

                

                
            }
            }



        protected string Grid(int Subregion)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT adup.Id_PoAnual,adup.IdMensaje,adup.Id_Region,adup.Id_Subregion,UPPER('POA NACIONAL ' +CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                               "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), adup.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), adup.Fecha_Final, 103) Fecha_Final," +
                               "adup.EstadoDeAsignacion,r.Nombre_Region,sr.Subregion,adup.Instrucciones,adup.Id_Mes,m.Descripcion_Mes mes FROM AsignacionDepartamentosUPMonitoreo adup " +
                               "INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = adup.Id_PoAnual " +
                               "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = adup.IdMensaje " +
                               "INNER JOIN Region r ON r.Id_Region = adup.Id_Region " +
                               "INNER JOIN Subregion sr ON sr.Id_Subregion = adup.Id_Subregion AND sr.Id_Region = r.Id_Region " +
                               "INNER JOIN Meses m ON m.Id_meses = adup.Id_Mes WHERE adup.Id_Mes= " + Session["Mes"] + " and adup.Id_PoAnual= "+ Session["Id_POA"] + "";

                CadenaSQL += " AND adup.Id_Subregion  = " + Subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
                //CadenaSQL += " AND adup.Id_Subregion  = " + Users.id_subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
           
           
            return CadenaSQL;
        }
        protected string Grid_regiones(int Subregion)
        {
            Users = (UsuarioValida)Session["DataUser"];
            string CadenaSQL = "SELECT adup.Id_PoAnual,adup.IdMensaje,adup.Id_Region,adup.Id_Subregion,UPPER('POA REGIONAL ' +CAST(pc.Anio_Correspondiente AS varchar)) POA," +
                               "mt.DescripcionMensaje Etapa, CONVERT(VARCHAR(12), adup.FechaDeAsignacion, 103) FechaDeAsignacion,CONVERT(VARCHAR(12), adup.Fecha_Final, 103) Fecha_Final," +
                               "adup.EstadoDeAsignacion,r.Nombre_Region,sr.Subregion,adup.Instrucciones,adup.Id_Mes,m.Descripcion_Mes mes FROM AsignacionSubRegion_Monitoreo adup " +
                               "INNER JOIN Poas_Creados pc ON pc.Id_PoAnual = adup.Id_PoAnual " +
                               "INNER JOIN  Mensaje_Tarea mt ON mt.Id_Mensaje = adup.IdMensaje " +
                               "INNER JOIN Region r ON r.Id_Region = adup.Id_Region " +
                               "INNER JOIN Subregion sr ON sr.Id_Subregion = adup.Id_Subregion AND sr.Id_Region = r.Id_Region " +
                               "INNER JOIN Meses m ON m.Id_meses = adup.Id_Mes WHERE adup.Id_Mes= " + Session["Mes"] + " and adup.Id_PoAnual= "+ Session["Id_POA"] + "";

                CadenaSQL += " AND adup.Id_Subregion  = " + Subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
                //CadenaSQL += " AND adup.Id_Subregion  = " + Users.id_subregion + " ORDER BY r.Id_Region,SR.Id_Subregion;";
           
           
            return CadenaSQL;
        }

    }
}