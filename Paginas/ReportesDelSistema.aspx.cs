using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Monitoreo_ConsultaPoa : System.Web.UI.Page
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
            GridReportes.NeedDataSource += new GridNeedDataSourceEventHandler(GridReportes_NeedDataSource);           
            GridReportes.ItemCommand += new GridCommandEventHandler(GridReportes_ItemCommand);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            /*monitoreo*/
            RadRegionM.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegionM.ItemCommand += new GridCommandEventHandler(RadRegionM_ItemCommand);
            RadRegionM.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);

            /*GRID NACIONALES*/
            GRDNacionales.NeedDataSource += new GridNeedDataSourceEventHandler(GRDNacionales_NeedDataSource);
            GRDNacionales.ItemCommand += new GridCommandEventHandler(GRDNacionales_ItemCommand);
            GRDNacionales.DetailTableDataBind += new GridDetailTableDataBindEventHandler(GRDNacionales_DetailTableDataBind);
            GRDNacionales.ItemDataBound += GRDNacionales_ItemDataBound;

          

        }


        protected void GRDNacionales_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {
                        int Region = Convert.ToInt32(dataItem.GetDataKeyValue("Id_Region").ToString());
                        if (Region == 13)
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(76,78,77,94,508);";
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
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion in(507, 518, 521);";
                        }
                        else
                        {
                            
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + " ORDER BY Subregion";
                        }
                        procesos.LlenarRadGrid(GRDNacionales, CadenaString);
                        break;
                    }
            }
        }

        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Regiones.Visible = false;
            Repo1.Visible = true;
        }
        protected void GridReportes_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosReporte Dt = new DatosReporte();            
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
                    Dt.Id_Reporte = Convert.ToInt32(item.GetDataKeyValue("Id_Reporte").ToString());                                                            
                    Dt.Is_Sicoin = 0;                   
                    Dt.Id_Region = Convert.ToInt32(Session["CodigoRegion"].ToString());
                    Dt.Id_SubRegion = Convert.ToInt32(Session["CodigoSubregion"].ToString());
                    Dt.Id_Perfil = Convert.ToInt32(Session["perfil"].ToString());
                    Session["info2"] = Dt;

                    if (Dt.Id_Reporte == 1) 
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 95).Permiso == true)
                        {
                            Excel(3);
                        }
                        else 
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                    else if (Dt.Id_Reporte == 2) 
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 96).Permiso == true)
                        {
                            Excel(3);
                        }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                    else if (Dt.Id_Reporte == 3) 
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 97).Permiso == true)
                        {
                            Excel(3);
                        }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
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
                    Dt.Id_Reporte = Convert.ToInt32(item.GetDataKeyValue("Id_Reporte").ToString());
                    Dt.Is_Sicoin = 1;
                    Dt.Id_Region = Convert.ToInt32(Session["CodigoRegion"].ToString());
                    Dt.Id_SubRegion = Convert.ToInt32(Session["CodigoSubregion"].ToString());
                    Dt.Id_Perfil = Convert.ToInt32(Session["perfil"].ToString());
                    Session["info2"] = Dt;
                    
                    if (Dt.Id_Reporte == 4) 
                    {
                       if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 98).Permiso == true)
                       {
                            Excel(2);
                       }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                    else if (Dt.Id_Reporte == 1)
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 95).Permiso == true)
                        {
                            Excel(1);
                        }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                    else if (Dt.Id_Reporte == 2)
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 96).Permiso == true)
                        {
                            Excel(1);
                        }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                    else if (Dt.Id_Reporte == 3)
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 97).Permiso == true)
                        {
                            Excel(1);
                        }
                        else
                        {
                            MensajePantalla("No tiene permiso para esta función.....");
                        }
                    }
                }
            }
        }
        
        protected void Excel(int Op) 
        {
            if (Op == 1)
            {                 
                 Regiones.Visible = false;
                Repo1.Visible = true;
                Exportar_Excel(ExportarEx, "../ExportarExcel/ReporteRegiones.aspx", "200", "200", "key2", "Exportar a excel Reporte Sicoin");
            }
            if (Op == 2)
            {
                Regiones.Visible = true;
                Repo1.Visible = false;
                RadRegion.Rebind();
            }
            if (Op == 3)
            {
                Exportar_Excel(ExportarEx, "../ExportarExcel/ReporteRegiones.aspx", "200", "200", "key1", "Exportar a excel Reporte");
            }
        }
        protected void GridReportes_NeedDataSource(object sender, GridNeedDataSourceEventArgs e) 
        {
            UsuarioValida Us = (UsuarioValida)Session["DataUser"];

            string CadenaString;


            if (Us.Id_Tipoperfil==4)
            {

                 CadenaString = "SELECT Id_Reporte,DescripcionRep FROM Reportes WHERE Id_Estado = 1 AND Id_Reporte IN (1);";
            }
            else
            {
                 CadenaString = "SELECT Id_Reporte,DescripcionRep FROM Reportes WHERE Id_Estado = 1;";
            }
                                   

           procesos.LlenarRadGrid(GridReportes, CadenaString);

        }
        protected void GridReportes_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int Codigo;
            if (e.Item is GridDataItem)
            {
                GridDataItem item;
                item = e.Item as GridDataItem;
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Reporte").ToString());
                if (Codigo == 4) 
                {
                    ((ImageButton)item["BotonA"].Controls[0]).Visible = false;
                    (item["BotonB"].Controls[0] as ImageButton).ImageUrl = "../Iconos/grifo.png";
                }
                else 
                {
                    ((ImageButton)item["BotonA"].Controls[0]).Visible = true;
                    (item["BotonB"].Controls[0] as ImageButton).ImageUrl = "../Iconos/excel.png";
                }
            }
        }
        protected void RadRegionM_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosReporte Dt = new DatosReporte();
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
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.Id_Perfil = 0;
                    }
                    Session["info2"] = Dt;
                    Exportar_Excel(ExportarEx, "../ExportarExcel/ReporteRegionesAvances.aspx", "200", "200", "key3", "Exportar a excel Reporte Avances");
                }
            }
        }
        protected void RadRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosReporte Dt = new DatosReporte();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            
            if (e.CommandName == "Select")
            {
                if (e.Item.OwnerTableView.Name == "SubRegion")
                {
                    Dt = (DatosReporte)Session["info2"];
                    Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                    Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    Dt.Id_Perfil = 0; 
                }
                Session["info2"] = Dt;
                Exportar_Excel(ExportarEx, "../ExportarExcel/ReporteRegiones.aspx", "250", "250", "key3", "Exportar a excel Reporte Sicoin");
            }
        }

        protected void RadRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 and Codigo_SubRegion >= 1 and Codigo_SubRegion != 99 AND Id_Region = ";
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
                        procesos.LlenarRadGrid(RadRegion, CadenaString);
                        procesos.LlenarRadGrid(RadRegionM, CadenaString);
                        break;
                    }
            }
        }
        protected void RadRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                UsuarioValida Us = (UsuarioValida)Session["DataUser"];
                string CadenaSQl;

                if ((Us.Id_Tipoperfil == 5) || (Us.Id_Tipoperfil == 7))
                {
                    Region.Visible = true;
                    Nacional.Visible = true;
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1 and r.Id_Region =" + Us.id_region + ";";
                }
                else if ((Us.Id_Tipoperfil == 4))
                {
                    Region.Visible = false;
                    Nacional.Visible = true;
                    
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1 and r.Id_Region =" + Us.id_region + ";";
                }
                else
                {
                    Region.Visible = true;
                    Nacional.Visible = true;
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1;";
                }
                procesos.LlenarRadGrid(RadRegion, CadenaSQl);
                procesos.LlenarRadGrid(RadRegionM, CadenaSQl);
            }
        }
        protected string Combos()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 2;";
        }   protected string CombosNacionales()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 1;";
        }

        protected string ComboMes()
        {
            return "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses;";
        }
        protected void Poas_ItemsRequested2(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combos(), "Descripcion", "Id", true);
        }


        protected void Poas_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            //RadComboBox comboBox = (RadComboBox)sender;
            //procesos.LLenarComboT(comboBox, ComboMes(), "Descripcion", "Id", true);


            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, CombosNacionales(), "Descripcion", "Id", true);
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
                DatosTarea dt = new DatosTarea();
                Session["CargarMetasValor"] = Ris;               
                Session["info2"] = dt;                
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

   
        protected void GRDNacionales_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();
            Session["Id_PoAnual_Combo"] = string.Empty;

            GridDataItem item;
            item = e.Item as GridDataItem;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");

            if (e.CommandName=="Select3")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                Session["Id_PoAnual_Combo"] = Valor;
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
                    if (M.VerificarCargaNacional_(Dt) == true)
                    {
                        Session["info50"] = Dt;
                        //Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional.aspx", "200", "200", "key5", "Exportar a excel POA");
                        Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarPOANacional_Cuatrimestre.aspx", "200", "200", "key5", "Exportar a excel POA");

                        

                        ClientScript.RegisterStartupScript(GetType(), "Javascript", "setTimeout(function(){ CloseModal(); },25);", true);

                      

                    }
                    else
                    {
                        MensajePantalla("No tiene datos en el poa");
                    }
                }

            }

        }

        protected bool Direcciones(int Codigo)
        {
            bool dato = false;
            if (Codigo == 305) { dato = true; }
            if (Codigo == 410) { dato = true; }
            if (Codigo == 466) { dato = true; }
            if (Codigo == 409) { dato = true; }
            if (Codigo == 411) { dato = true; }
            if (Codigo == 412) { dato = true; }
            if (Codigo == 458) { dato = true; }
            if (Codigo == 497) { dato = true; }
            if (Codigo == 498) { dato = true; }

            return dato;
        }


        protected void GRDNacionales_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int Codigo;
            if (e.Item is GridDataItem)
            {
                GridDataItem item;
                item = e.Item as GridDataItem;
                if (e.Item.OwnerTableView.Name == "SubRegion")
                {
                    Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    if (Direcciones(Codigo) == true)
                    {
                        //((ImageButton)item["BotonA"].Controls[0]).Visible = false;
                        //((ImageButton)item["BotonB"].Controls[0]).Visible = false;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = false;
                        //((ImageButton)item["BotonE"].Controls[0]).Visible = false;
                        //((ImageButton)item["BotonF"].Controls[0]).Visible = false;
                        //((ImageButton)item["BotonG"].Controls[0]).Visible = false;
                        //((ImageButton)item["BotonQ"].Controls[0]).Visible = false;
                    }
                    else
                    {
                        //((ImageButton)item["BotonA"].Controls[0]).Visible = true;
                        //((ImageButton)item["BotonB"].Controls[0]).Visible = true;
                        ((ImageButton)item["BotonD"].Controls[0]).Visible = true;
                        //((ImageButton)item["BotonE"].Controls[0]).Visible = true;
                        //((ImageButton)item["BotonF"].Controls[0]).Visible = true;
                        //((ImageButton)item["BotonG"].Controls[0]).Visible = true;
                        //((ImageButton)item["BotonQ"].Controls[0]).Visible = true;
                    }
                }
            }
        }


        protected void GRDNacionales_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            UsuarioValida Us = (UsuarioValida)Session["DataUser"];
            if (!e.IsFromDetailTable)
            {
                string CadenaSQl;

                if (Us.Id_Tipoperfil == 4 /*Director Nacional*/)
                {

                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                                "and Id_Region IN("+ Us.id_region +") order by  r.Nombre_Region; ";
                    
                }

                else
                {

                CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 " +
                                "and Id_Region IN(12,81, 140,19, 142, 92, 135, 136, 138, 137, 143,147, 90, 91, 82, 13, 16,17, 20,22,18,14)  order by  r.Nombre_Region; ";

                }

                procesos.LlenarRadGrid(GRDNacionales, CadenaSQl);
            }
        }


    }
}