using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class IngresoMetasValoresSR : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Session["Validar"] = 1;

            if (Convert.ToInt32(Session["Destino"].ToString()) == 1)
            {
                Response.Redirect("IngresodeMetasDSR.aspx");
            }
            else 
            {
                Response.Redirect("RevisionDeMetasPlanificacion.aspx"); 
            }
        }
        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {           
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 +","+
                               + Ris.Id_PoAnual + "," + Ris.Id_SubRegion +"," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_ProductoVeficable + ";";
            procesos.LlenarRadGrid(GridUnidades, CadenaSql);
        }
        protected void RadCuatrimestre_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e) 
        { 
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 2 + "," +
                               +Ris.Id_PoAnual + "," + Ris.Id_SubRegion + "," + Ris.Id_Componente + "," + Ris.Id_SubComponente + "," + Ris.Id_ProductoVeficable + ";";
            procesos.LlenarRadGrid(RadCuatrimestre, CadenaSql);
        }
        protected void BtnGenerarMeses_Click(object sender, EventArgs e)
        {
            GuardarMetasSubregion gms = new GuardarMetasSubregion();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();                       
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ris.Id_PoAnual;
            gms.Id_Subregion = Ris.Id_SubRegion;
            gms.Id_Componente = Ris.Id_Componente;
            gms.Id_SubComponente = Ris.Id_SubComponente;
            gms.Id_ProductoVeficable = Ris.Id_ProductoVeficable;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

            if (x.Generar_meses(gms, ref er))
            {
                MensajePantalla("Se Generaron los meses Correctamente...");                          
                VerificargRID();
                btnGenerarMeses.Visible = false;
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void Inicializacion_Objetos()
        {
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            RadCuatrimestre.NeedDataSource += new GridNeedDataSourceEventHandler(RadCuatrimestre_NeedDataSource);
            GridUnidades.ItemCommand += new GridCommandEventHandler(Seleccionar_Meses);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GuardarMetas.Click += new EventHandler(GuardarMetas_Click);
            btnGenerarMeses.Click += new EventHandler(BtnGenerarMeses_Click);
            CancelarEdición.Click += new EventHandler(CancelarEdición_Click);            
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
            if(op != 0) { return false;}

            return v;
        }
        private bool Valor2(int op)
        {
            bool v = false;
            if (op != 0) { return true; }

            return v;
        }        
        protected void Fillcombo()
        {            
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

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
            Session["Validar"] = 1;           
            GuardarMetas.Enabled = false;
            CancelarEdición.Visible = false;            
        }
        protected void VerificargRID()
        {
            GridUnidades.Rebind();
            RadCuatrimestre.Rebind();
            if (GridUnidades.Items.Count != 0) 
            { 
                GridUnidades.Visible = true; 
                RadCuatrimestre.Visible = true; 
            } 
            else 
            { 
                GridUnidades.Visible = false; 
                RadCuatrimestre.Visible = false; 
            }            
        }
        protected void VerificarBotonMeses() 
        {
            GuardarMetasSubregion gms = new GuardarMetasSubregion();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();           
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];

            gms.Id_PoAnual = Ris.Id_PoAnual;
            gms.Id_Subregion = Ris.Id_SubRegion;
            gms.Id_Componente = Ris.Id_Componente;
            gms.Id_SubComponente = Ris.Id_SubComponente;
            gms.Id_ProductoVeficable = Ris.Id_ProductoVeficable;
            gms.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());             

            if (x.Verificar_BotonGenerarMeses(gms, ref er))
            {
                btnGenerarMeses.Visible = true;
            }
            else
            {
                btnGenerarMeses.Visible = false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            Inicializacion_Objetos();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 32).Permiso != true)
                {
                    Response.Redirect("~/Login.aspx");
                }
                Fillcombo();
                VerificarBotonMeses();
                VerificargRID();
            }
        }        
        protected void GuardarMetas_Click(object sender, EventArgs e)
        {
            GuardarMetasSubregion gms = new GuardarMetasSubregion();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();                
            ManipulacionIngresoValoresMetas x = new ManipulacionIngresoValoresMetas();
            RegresoInformacionSubregional Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
           
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
            gms.TipoAsignacion = Ris.TipoAsignacion;

            if (x.Ingreso_de_ValoresMetas(gms, ref er))
            {
                MensajePantalla("Se ha agregado el valor Correctamente...");               
                GuardarMetas.Enabled = false;               
                LimpiarCampos();
                CancelarEdición.Visible = false;
                GridUnidades.MasterTableView.GetColumn("BotonA").Display = true;
                VerificargRID();
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
            }
        }
        protected void CancelarEdición_Click(object sender, EventArgs e) 
        {
            CancelarEdición.Visible = false;           
            GridUnidades.MasterTableView.GetColumn("BotonA").Display = true;
            GuardarMetas.Enabled = false;            
            LimpiarCampos();
        }
        protected void Seleccionar_Meses(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];                
            GridDataItem item = e.Item as GridDataItem;                             
            ManipulacionIngresoValoresMetas x1 = new ManipulacionIngresoValoresMetas();
                       
            if (e.CommandName == "Select")
            {                
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 33).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos para esta función");
                }
                else 
                {
                    RegresoInformacionSubregional  Ris = (RegresoInformacionSubregional)Session["CargarMetasValor"];
                    if (Ris.NoPlanificable == 0)
                    {
                        LblMes.Text = x1.Mes(Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString()));                     
                        txtum1.Text  = item.GetDataKeyValue("Meta_UM1").ToString();
                        txtum2.Text = item.GetDataKeyValue("Meta_UM2").ToString();
                        txtum3.Text = item.GetDataKeyValue("Meta_UM3").ToString();
                        Session["Idmes"] = Convert.ToInt32(item.GetDataKeyValue("Id_mes").ToString());
                                                           
                        txtum1.ReadOnly = Valor(Ris.idDUM1);
                        txtum2.ReadOnly = Valor(Ris.idDUM2);
                        txtum3.ReadOnly = Valor(Ris.idDUM3);
                    
                        GuardarMetas.Enabled = true;                    
                        GridUnidades.MasterTableView.GetColumn("BotonA").Display = false;
                        CancelarEdición.Visible = true;
                    }
                    else
                    {
                        MensajePantalla("No se ingresan valores porque es una actividad No planificable");
                    }
                }
            }
        }
    }
}