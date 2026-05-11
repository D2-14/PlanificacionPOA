using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Componentes_Monitoreo : System.Web.UI.Page
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
        protected void Inicializacion_Objetos()
        {
            GridProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductos_NeedDataSource);
            GridProductos.ItemCommand += new GridCommandEventHandler(Seleccionar_Producto);
            GridProductos.ItemDataBound += GridProductos_ItemDataBound;
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            RegresarPantallaanterior_Mantenimiento.Click += new EventHandler(RegresarPantallaanterior_Mantenimiento_Click);
            FinalizarIngreso.Click += new EventHandler(FinalizarIngreso_Click);
            btnCerrarVentana.Click += new EventHandler(BtnCerrarVentana_Click);
            btnIrConfiguracion.Click += new EventHandler(BtnIrConfiguracion_Click);
        }

        protected void RegresarPantallaanterior_Mantenimiento_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguimientoPOA.aspx");
        }
        protected void FinalizarIngreso_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo x = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();           
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 85).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else 
            {
                OpenWinwdows(confirmar, "330", "170", "Key5", "Información");                        
            }            
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tarea_Monitoreo_SubRegion.aspx");
        }
        protected void VerificargRID()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            string usuario = Session["Usuario"].ToString();
            if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 84).Permiso != true) && (usuario != "5"))
            {
                Response.Redirect("Portada.aspx");
            }
            GridProductos.Rebind();
            if (GridProductos.Items.Count != 0) { GridProductos.Visible = true; } else { GridProductos.Visible = false; }
        }
        protected void GridProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            try
            {
                DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
                // SE AGREGA PARAMETRO DE SESSION[] ya que se incorporan cambios de DELEGADOS-juridcos-com social
                string sqlstring = "Sp_VerificarEstadoComponente " + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente + "," + DMI.Id_Mes + "," + Session["perfil"];

                //string sqlstring = "Sp_VerificarEstadoComponente " + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente + "," + DMI.Id_Mes;
                procesos.LlenarRadGrid(GridProductos, sqlstring);
            }
            catch 
            {
                Response.Redirect("Portada.aspx");
            } 
        }
        protected void Seleccionar_Producto(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;           
            DatosMonitoreoIngresoMetas DMI =(DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];          
            string Estado; 
            if (e.CommandName == "Select")
            {
                DMI.IdComponente = Convert.ToInt32(item.GetDataKeyValue("IdComponente").ToString());
                DMI.Descripcion_Componente = item.GetDataKeyValue("Descripcion_Componente").ToString();
                DMI.Id_SubComponente = 0;
                Estado = item.GetDataKeyValue("Proceso").ToString();
                Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;              

                /*ASUNTOS JURÍDICOS*/
                if (DMI.IdComponente == 1) {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 65).Permiso  != true )
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else 
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 65).Url);                          
                        }                       
                    }                   
                }
                /*CAPACITACIÓN*/
                if (DMI.IdComponente == 2)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 66).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto") 
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 66).Url);
                        }
                    }
                }
                /*CULTURA FORESTAL*/
                if (DMI.IdComponente == 3)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 67).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 67).Url);
                        }
                    }
                }
                /*EXENTOS DE LICENCIA FORESTAL*/
                if (DMI.IdComponente == 4)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 68).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 68).Url);
                        }
                    }
                }
                /*CONSUMOS FAMILIARES*/
                if (DMI.IdComponente == 5)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 69).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 69).Url);
                        }
                    }
                }
                /*FISCALIZACIÓN Y CONTROL*/
                if (DMI.IdComponente == 6)
                {
                    if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 70).Permiso != true))
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 70).Url);
                        }
                    }
                }
                /*FORTALECIMIENTO FORESTAL, MUNICIPAL Y COMUNAL*/
                if (DMI.IdComponente == 7)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 71).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 71).Url);
                        }
                    }
                }
                /*INCENTIVOS FORESTALES*/
                if (DMI.IdComponente == 8)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 72).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 72).Url);
                        }
                    }
                }
                /*INDUSTRIA Y COMERCIO*/
                if (DMI.IdComponente == 9)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 73).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 73).Url);
                        }
                    }
                }
                /*LICENCIAS FORESTALES*/
                if (DMI.IdComponente == 10)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 74).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 74).Url);
                        }
                    }
                }
                /*MANGLE*/
                if (DMI.IdComponente == 11)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 75).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 75).Url);
                        }
                    }
                }
                /*MONITOREO FORESTAL*/
                if (DMI.IdComponente == 12)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 76).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 76).Url);
                        }
                    }
                }
                /*PINABETE*/
                if (DMI.IdComponente == 13)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 77).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 77).Url);
                        }
                    }
                }
                /*PINPEP*/
                if (DMI.IdComponente == 14)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 78).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 78).Url);
                        }
                    }
                }
                /*PPMF*/
                if (DMI.IdComponente == 15)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 79).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 79).Url);
                        }
                    }
                }
                /*PROBOSQUE*/
                if (DMI.IdComponente == 16)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 80).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 80).Url);
                        }
                    }
                }
                /*PROTECCIÓN FORESTAL*/
                if (DMI.IdComponente == 17)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 81).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 81).Url);
                        }
                    }
                }
                /*RNF*/
                if (DMI.IdComponente == 18)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 82).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 82).Url);
                        }
                    }
                }
                /*CARBONO*/
                if (DMI.IdComponente == 19)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 83).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 83).Url);
                        }
                    }
                }
                /* PROGRAMA DE REDUCCIÓN DE EMISIONES*/
                if (DMI.IdComponente == 20)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 90).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == "Incompleto")
                        {
                            Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 90).Url);
                        }
                    }
                }
            }            
        }
        protected void GridProductos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["Proceso"];
                
                if (item.GetDataKeyValue("Proceso").ToString() == "Completo")
                {
                    cell1.BackColor = Color.Green;
                    cell1.ForeColor = Color.White;
                    cell1.Font.Bold = true;
                }
                else 
                {
                    cell1.BackColor = Color.Red;
                    cell1.ForeColor = Color.White;
                    cell1.Font.Bold = true;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                string usuario = Session["Usuario"].ToString();
                if ((PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 84).Permiso != true) && (usuario !="5"))
                {
                    
                    Response.Redirect("Portada.aspx");
                }

                VerificargRID();


                if (Session["perfil"].ToString() == "7")
                {
                    FinalizarIngreso.Visible = true;
                }
                else
                {
                    FinalizarIngreso.Visible = false;
                }

               
                if (Session["Mantenimiento"] == "True")
                {
                    RegresarPantallaanterior.Visible = false;
                    RegresarPantallaanterior_Mantenimiento.Visible = true;
                }
                else
                {
                    RegresarPantallaanterior_Mantenimiento.Visible = false ;
                    RegresarPantallaanterior.Visible = true;
                }
            }

        }
        protected void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(confirmar, "Key5");
        }
        protected void BtnIrConfiguracion_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo x = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            if (x.Finalizar_IngresoMonitoreo(DMI, ref er))
            {
               Response.Redirect(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 85).Url);
            }
            else
            {
                MensajePantalla(er.Descripcion.ToString());
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