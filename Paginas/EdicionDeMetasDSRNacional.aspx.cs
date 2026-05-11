using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class EdicionDeMetasDSRNacional : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void RadSearchBoxActividad_Search(object sender, SearchBoxEventArgs e)
        {
            string supplierID = string.Empty;

            if (e.Text != string.Empty)
            {
                supplierID = e.Value;
            }
            else
            {
                supplierID = string.Empty;
            }

            Session["CadenaBusqueda"] = supplierID;
            GdrDatosdeActividades.Rebind();
        }
        protected string LlenarBusqueda()
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string stringslq = string.Empty;
            if (Dt != null)
            {
                stringslq = "EXEC Sp_obtener_data_BusquedaItemNacionales " + Dt.Id_Region + "," + Dt.Id_SubRegion + ",1";
            }
            return stringslq;
        }
        protected void RegresarPantallaanteriorMetas_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            InformacionActividadesNacionales Ian = new InformacionActividadesNacionales();
            EdicionValoresMetas.Visible = false;
            Seleccion.Visible = true;
            Normal_informacion();
            if (GridUnidadesIngreso.Items.Count != 0) { GridUnidadesIngreso.MasterTableView.GetColumn("BotonA").Display = true; }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Session["ValorDevuelta"] = 1;
            Response.Redirect("MantenimientoPOAs.aspx");
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
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + Session["d1"].ToString() + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
        }
        protected void GridUnidadesIngreso_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 1 + "," +
                               +Ian.Id_PoAnual + "," + Ian.Id_SubRegion + "," + Ian.Correlativo_Configuracion + ";";
            procesos.LlenarRadGrid(GridUnidadesIngreso, CadenaSql);
        }
        protected void RadCuatrimestre_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];
            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Nacional " + 2 + "," +
                               +Ian.Id_PoAnual + "," + Ian.Id_SubRegion + "," + Ian.Correlativo_Configuracion + ";";
            procesos.LlenarRadGrid(RadCuatrimestre, CadenaSql);
        }
        protected void VerificarBotonMeses()
        {
            GuardaMetasNacional gms = new GuardaMetasNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ian.Id_PoAnual;
            gms.Id_SubRegion = Ian.Id_SubRegion;
            gms.Correlativo_Configuracion = Ian.Correlativo_Configuracion;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            if (x.Verificar_BotonGenerarMesesNacionales(gms, ref er))
            {
                btnGenerarMeses.Visible = true;
            }
            else
            {
                btnGenerarMeses.Visible = false;
            }
        }
        protected void BtnGenerarMeses_Click(object sender, EventArgs e)
        {
            GuardaMetasNacional gms = new GuardaMetasNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ian.Id_PoAnual;
            gms.Id_SubRegion = Ian.Id_SubRegion;
            gms.Id_Producto = Ian.Id_Producto;
            gms.Id_SubProducto = Ian.Id_SubProducto;
            gms.Id_Actividad = Ian.Id_Actividad;
            gms.Correlativo_Configuracion = Ian.Correlativo_Configuracion;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            if (x.Generar_mesesNacionales(gms, ref er))
            {
                MensajePantalla("Se Generaron los meses Correctamente...");
                VerificargRID();
                VerificargRIDUnidadIngreso();
                btnGenerarMeses.Visible = false;
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Inicializacion_Objetos()
        {
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.DeleteCommand += new GridCommandEventHandler(Eliminar_Actividades);
            GdrDatosdeActividades.PreRender += new EventHandler(GdrDatosdeActividades_PreRender);
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            RadCuatrimestre.NeedDataSource += new GridNeedDataSourceEventHandler(RadCuatrimestre_NeedDataSource);
            GridUnidadesIngreso.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidadesIngreso_NeedDataSource);
            GridUnidadesIngreso.ItemCommand += new GridCommandEventHandler(Seleccionar_Meses);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);          
            RegresarPantallaanteriorMetas.Click += new EventHandler(RegresarPantallaanteriorMetas_Click);
            btnGenerarMeses.Click += new EventHandler(BtnGenerarMeses_Click);
            CancelarEdicion.Click += new EventHandler(CancelarEdicion_Click);
            GuardarMetas.Click += new EventHandler(GuardarMetas_Click);          
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
        protected void ConfiguracionIngreso()
        {
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];
            if (Ian.RedProgramatica == 1)
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

            LblUM1.Text = Ian.DUM1;
            LblUM2.Text = Ian.DUM2;
            LblUM3.Text = Ian.DUM3;
            LblMes.Text = string.Empty;

            RUM1.Visible = Valor2(Ian.idDUM1);
            RUM1T.Visible = Valor2(Ian.idDUM1);
            RUM2.Visible = Valor2(Ian.idDUM2);
            RUM2T.Visible = Valor2(Ian.idDUM2);
            RUM3.Visible = Valor2(Ian.idDUM3);
            RUM3T.Visible = Valor2(Ian.idDUM3);

            if (Ian.Id_SubProducto == 1)
            {
                subProdlbl.Visible = false;
            }
            else
            {
                subProdlbl.Visible = true;
            }
            if (Ian.Id_Actividad == 1)
            {
                Actividadlbl.Visible = false;
            }
            else
            {
                Actividadlbl.Visible = true;
            }

            lblActividad.Text = Ian.DescripcionActividad;
            lblProducto.Text = Ian.DescripcionProducto;
            lblSubproducto.Text = Ian.DescripcionSubProducto;
            Session["Validar"] = 1;
            GuardarMetas.Enabled = false;
            GuardarMetas.Visible = false;
            CancelarEdicion.Visible = false;

            VerificarBotonMeses();
            VerificargRIDUnidadIngreso();
            Session["Destino"] = 1;
            EdicionValoresMetas.Visible = true;
            Seleccion.Visible = false;
        }
        protected void Eliminar_Actividades(object source, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;
            Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            int Id;

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                Id = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                Session["llave"] = 1;
                DatosTarea Dt = (DatosTarea)Session["info2"];
                if (Mmp.Eliminacion_Actividades_POANacional(Id, Dt, ref er))
                {
                    MensajePantalla("Se elimino la Actividad");
                    VerificargRID();
                }
                else
                {
                    Session["llave"] = 0;
                    MensajePantalla(er.Descripcion.ToString());
                }
                if (GdrDatosdeActividades.Items.Count == 0)
                {
                    GdrDatosdeActividades.Visible = false;
                    Response.Redirect("CatalogoPoaNacional.aspx");
                }
                else
                {

                    GdrDatosdeActividades.Visible = Visible;
                }
                Session["llave"] = 1;
            }
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            InformacionActividadesNacionales Ian = new InformacionActividadesNacionales();
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                if (e.CommandName == "Select")
                {
                    Ian.Id_PoAnual = Dt.Id_PoAnual;
                    Ian.Correlativo_Configuracion = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                    Ian.Id_Producto = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
                    Ian.Id_SubProducto = Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString());
                    Ian.Id_Actividad = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
                    Ian.Id_SubRegion = Dt.Id_SubRegion;
                    Ian.RedProgramatica = Convert.ToInt32(item.GetDataKeyValue("Id_MetasRedProgramatica").ToString());
                    Ian.DescripcionProducto = item.GetDataKeyValue("DescripcionProducto").ToString();
                    Ian.DescripcionSubProducto = item.GetDataKeyValue("DescripcionSubProducto").ToString();
                    Ian.DescripcionActividad = item.GetDataKeyValue("DescripcionActividad").ToString();
                    Ian.DUM1 = item.GetDataKeyValue("DescripcionUM1").ToString();
                    Ian.DUM2 = item.GetDataKeyValue("DescripcionUM2").ToString();
                    Ian.DUM3 = item.GetDataKeyValue("DescripcionUM3").ToString();
                    Ian.idDUM1 = Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString());
                    Ian.idDUM2 = Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString());
                    Ian.idDUM3 = Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString());
                    Ian.TipoAsignacion = Dt.TipoAsignacion;

                    Session["llave"] = 1;
                    Session["CargarMetasValor"] = Ian;
                    ConfiguracionIngreso();
                    VerificargRIDUnidadIngreso();
                }
                /*Abrir la ventana*/
                if (Session["llave"].ToString() == "0")
                {
                    Session["d1"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                    VerificargRIDVentana();
                }
                Session["llave"] = 0;
            }
        }
        protected void VerificargRIDUnidadIngreso()
        {
            GridUnidadesIngreso.Rebind();
            RadCuatrimestre.Rebind();
            if (GridUnidadesIngreso.Items.Count != 0)
            {
                GridUnidadesIngreso.Visible = true;
                RadCuatrimestre.Visible = true;
            }
            else
            {
                GridUnidadesIngreso.Visible = false;
                RadCuatrimestre.Visible = false;
            }
        }
        protected void VerificargRID()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0)
            {
                GdrDatosdeActividades.Visible = true;
                Respuesta.Visible = false;
            }
            else
            {
                Respuesta.Visible = true;
                GdrDatosdeActividades.Visible = false;
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
        protected void Normal_informacion()
        {
            VerificargRID();
            Session["d1"] = 0;
            Session["CadenaBusqueda"] = string.Empty;
            Session["llave"] = 0;
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
            DatosTarea Dt = (DatosTarea)Session["info2"];
            T01.Text = Dt.NombrePoa;
            T02.Text = Dt.DescripcionSubregion;
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
                Normal_informacion();
                VericarPermiso();
            }
        }
        protected void CancelarEdicion_Click(object sender, EventArgs e)
        {
            CancelarEdicion.Visible = false;
            GridUnidadesIngreso.MasterTableView.GetColumn("BotonA").Display = true;
            GuardarMetas.Enabled = false;
            GuardarMetas.Visible = false;
            RegresarPantallaanteriorMetas.Visible = true;
            LimpiarCampos();
        }
        protected void GuardarMetas_Click(object sender, EventArgs e)
        {
            GuardaMetasNacional gms = new GuardaMetasNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ian.Id_PoAnual;
            gms.Id_SubRegion = Ian.Id_SubRegion;
            gms.Correlativo_Configuracion = Ian.Correlativo_Configuracion;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            gms.Id_Mes = Convert.ToInt32(Session["Idmes"].ToString());
            gms.UM1 = procesos.DecimalRadNumericTextBox(txtum1);
            gms.UM2 = procesos.DecimalRadNumericTextBox(txtum2);
            gms.UM3 = procesos.DecimalRadNumericTextBox(txtum3);
            gms.TipoAsignacion = Ian.TipoAsignacion;

            if (x.Ingreso_de_ValoresMetasNacionales(gms, ref er))
            {
                MensajePantalla("Se ha agregado el valor Correctamente...");
                GuardarMetas.Enabled = false;
                GuardarMetas.Visible = false;
                RegresarPantallaanteriorMetas.Visible = true;
                LimpiarCampos();
                CancelarEdicion.Visible = false;
                GridUnidadesIngreso.MasterTableView.GetColumn("BotonA").Display = true;
                VerificargRIDUnidadIngreso();
                Normal_informacion();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Seleccionar_Meses(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;
            ManipulacionIngresoValoresMetas x1 = new ManipulacionIngresoValoresMetas();

            if (e.CommandName == "Select")
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 57).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos para esta función");
                }
                else
                {
                    InformacionActividadesNacionales Ian = (InformacionActividadesNacionales)Session["CargarMetasValor"];

                    LblMes.Text = x1.Mes(Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString()));
                    txtum1.Text = item.GetDataKeyValue("Meta_UM1").ToString();
                    txtum2.Text = item.GetDataKeyValue("Meta_UM2").ToString();
                    txtum3.Text = item.GetDataKeyValue("Meta_UM3").ToString();
                    Session["Idmes"] = Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString());

                    txtum1.ReadOnly = Valor(Ian.idDUM1);
                    txtum2.ReadOnly = Valor(Ian.idDUM2);
                    txtum3.ReadOnly = Valor(Ian.idDUM3);

                    GuardarMetas.Enabled = true;
                    GuardarMetas.Visible = true;
                    GridUnidadesIngreso.MasterTableView.GetColumn("BotonA").Display = false;
                    CancelarEdicion.Visible = true;
                    RegresarPantallaanteriorMetas.Visible = false;
                }
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