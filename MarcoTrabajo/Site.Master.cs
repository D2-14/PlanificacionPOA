using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Telerik.Web.UI;
using System.Linq;

namespace PlanificacionPOA
{
    public partial class SiteMaster : MasterPage
    {
        public ConectarBDD BDD = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        protected void Botones()
        {
            btnCreacionUsuario.Click += new EventHandler(btnCreacionUsuario_Click);
            btnRolesUsuario.Click += new EventHandler(btnRolesUsuario_Click);
            btnImagen.Click += new EventHandler(btnImagen_Click);
            Btncerrarsesion.Click += new EventHandler(Btncerrarsesion_Click);
            LCerrarSesion.Click += new EventHandler(Btncerrarsesion_Click);
            Btninicio.Click += new EventHandler(Btninicio_Click);
            LMantenimientoPOAS.Click += new EventHandler(MantenimientoPOA_Click);
            LCreacionPOA.Click += new EventHandler(LinkCreacionPOAS_Click);
            LEnvioTarea.Click += new EventHandler(LEnvioTarea_Click);
            btnConsultaPOaRegional.Click += new EventHandler(btnConsultaPOaRegional_Click);
            /*regionales*/
            btnTareaPlanificador.Click += new EventHandler(btnTareaPlanificador_Click);
            btnTareaRegional.Click += new EventHandler(btnTareaRegional_Click);
            btnVerficarMetas.Click += new EventHandler(btnVerficarMetas_Click);
            btnTareaSubregional.Click += new EventHandler(btnTareaSubregional_Click);
            btnJefePlanificacion.Click += new EventHandler(btnJefePlanificacion_Click);
            btnTareaMonitoreoR.Click += new EventHandler(btnTareaMonitoreoR_Click);
            btnTareaMonitoreoSR.Click += new EventHandler(btnTareaMonitoreoSR_Click);
            btnReporte.Click += new EventHandler(btnReporte_Click);

            btnAvanacional.Click += new EventHandler(btnAvanacional_Click);
            btnAvanregional.Click += new EventHandler(btnAvanregional_Click);

            /*Documentos*/
            DDocumentoRed.Click += new EventHandler(DDocumentoRed_Click);
            LSoportes.Click += new EventHandler(Soporte_Click);
            /*nacionales*/
            btnCatalogoNacional.Click += new EventHandler(btnCatalogoNacional_Click);
            btnJefePlanificacionNacional.Click += new EventHandler(btnJefePlanificacionNacional_Click);
            btnTareaNacionalDirectores.Click += new EventHandler(btnTareaNacionalDirectores_Click);
            btnVerficarMetasNacionalDirectores.Click += new EventHandler(btnVerficarMetasNacionalDirectores_Click);
            btnTareaNacionalJefes.Click += new EventHandler(btnTareaNacionalJefes_Click);
            btnConsultaPoaNacional.Click += new EventHandler(btnConsultaPoaNacional_Click);

            btnTareaDirectoresMonitoreo.Click += new EventHandler(btnTareaDirectoresMonitoreo_Click);
            btnTareaJefesMonitoreo.Click += new EventHandler(btnTareaJefesMonitoreo_Click);
            /*Reprogramaciones*/
            LReproPlanificacion.Click += new EventHandler(BtnReprogramacionPlanificacion_Click);
            LReproRegional.Click += new EventHandler(BtnReprogramacionRegional_Click);
            LReproNacional.Click += new EventHandler(BtnReprogramacionNacional_Click);
            LReproPlanificacionN.Click += new EventHandler(BtnReproPlanificacionN_Click);

            //CR_Mantenimiento SEGUIMIENTO POA
            lSeguimientoPOA.Click += new EventHandler(lSeguimientoPOA_Click);

            Session["Permisos_Sistema"] = PermisosPermitidos;
        }
        private void MenuDinamico(int codigoUsuario)
        {

            string[] perfilesDelegados = { "15", "16", "17", "18", "19", "20","21","22", "23" };

            PermisosPermitidos = PermisosUsuario.Permisos(codigoUsuario);
            Session["Permisos_Sistema"] = PermisosUsuario.Permisos(codigoUsuario);
            int Id = Convert.ToInt32(Session["perfil"].ToString());
            int Region = Convert.ToInt32(Session["CodigoSubregion"].ToString());
            /*permisos*/
            CerrarS.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 2).Permiso;
            cerrar.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 2).Permiso;
            LCerrarSesion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 2).Permiso;
            Btninicio.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 1).Permiso;
            /*administracion planificacion y monitoreo*/
            AdminDireccion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,87).Permiso;
            UlPlanificacion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 23).Permiso;
            Pla1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 29).Permiso;
            Pla2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 34).Permiso;
            Pla3.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 48).Permiso;
            UlMonitoreo.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 88).Permiso;
            Repo.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 89).Permiso;
            Reportes.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 89).Permiso;
            /*administracion Tareas Regional*/
            AdminTarea.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 20).Permiso;            
            UlRegional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 21).Permiso;
            UlSubRegional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 22).Permiso;            
            ConsultaPoaRegional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 45).Permiso;
            btnConsultaPOaRegional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 45).Permiso;           
            Reg1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 27).Permiso;
            Reg2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 31).Permiso;
            Reg2.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(7,Region,Id);
            Reg3.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 63).Permiso;
            Reg3.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(6, Region, Id);
            Sub1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 28).Permiso;
            Sub2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 64).Permiso;
            if (perfilesDelegados.Contains(Session["perfil"].ToString()))
            {
            Sub2.Visible = true;
                Sub1.Visible = false;
            }
            else
            {
            Sub2.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(8, Region, Id);

            }
            /*administracion Tareas Nacional*/
            AdminTareaNacional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 39).Permiso;
            Catalogonacional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 40).Permiso;           
            UlTareaNacional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 52).Permiso;
            TareaDirector.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 49).Permiso;           
            RevisionDirector.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 50).Permiso;
            RevisionDirector.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(5, Region, Id);
            Tareajefaturas.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 51).Permiso;           
            ConsultaPoaNacional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 54).Permiso;
            TareaMDirector.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 91).Permiso;
            TareaMDirector.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(4, Region, Id);
            TareaMJefatura.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 92).Permiso;
            TareaMJefatura.Visible = PermisosUsuario.VerifcarDatosGridAsignacion(2, Region, Id);
            /*administracion sistema*/
            admin.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 3).Permiso;
            Configuracion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 3).Permiso;
            usuarioA.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 4).Permiso;
            usuarioB.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 5).Permiso;
            usuarioC.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,61).Permiso;
            /*Mantenimientos*/
            Mantenimiento.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 6).Permiso;
            LMantenimiento.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 6).Permiso;
            LMantenimientoPOAS.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,7).Permiso;
            Li1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 7).Permiso;
            LCreacionPOA.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 10).Permiso;
            li2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 10).Permiso;
            LEnvioTarea.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,62).Permiso;
            Li4.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 62).Permiso;
            /*Soporte*/
            LSoportes.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 38).Permiso;
            Li3.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 38).Permiso;
            /*documentos*/
            Documento.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos,35).Permiso;
            /*Reprogramaciones*/
            Reprogramacion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 99).Permiso;
            Repro1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 99).Permiso;
            ReproPlanificacion.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 100).Permiso;
            ReproRegional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 101).Permiso;
            ReproNacional.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 102).Permiso;
            ReproPlanificacionN.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 103).Permiso;

            if (Id != 1)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 100).Permiso == true)
                {
                    if (PermisosUsuario.VerifcarDatosGridAsignacion(9, Region, Id) == false)
                    {
                        Reprogramacion.Visible = false;
                        Repro1.Visible = false;
                    }
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 101).Permiso == true)
                {
                    if (PermisosUsuario.VerifcarDatosGridAsignacion(10, Region, Id) == false)
                    {
                        Reprogramacion.Visible = false;
                        Repro1.Visible = false;
                    }
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 102).Permiso == true)
                {
                    if (PermisosUsuario.VerifcarDatosGridAsignacion(11, Region, Id) == false)
                    {
                        Reprogramacion.Visible = false;
                        Repro1.Visible = false;
                    }
                }
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 103).Permiso == true)
                {
                    if (PermisosUsuario.VerifcarDatosGridAsignacion(12, Region, Id) == false)
                    {
                        Reprogramacion.Visible = false;
                        Repro1.Visible = false;
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Botones();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                lblUsuario.Text = Session["UsuarioNombre"].ToString();
                lblperfil.Text = Session["DescripcionPerfil"].ToString();
                User2.Text = Session["UsuarioNombre"].ToString();
                Perfil2.Text = Session["DescripcionPerfil"].ToString();
                MenuDinamico(Convert.ToInt32(Session["Usuario"].ToString()));
                Session["Validar"] = 0;
                Session["CambiosIngreso"] = 0;
                Session["ValorDevuelta"] = 0;
                Notificacion();
            }           
        }       
        private void Notificacion()
        {
            Manipulacion_de_Tareas t = new Manipulacion_de_Tareas();
            DiasPendiente Dp = t.TiempoIngreso((UsuarioValida)Session["DataUser"]);
            
            if (Dp.Resulta == true)
            {
                List<DiasPendiente> Lista = t.Mensajes((UsuarioValida)Session["DataUser"]);
                foreach (var mens in Lista) 
                { 
                    RadNotification.Visible = true;
                    RadNotification.VisibleOnPageLoad = true;
                    RadNotification.Title = "Notificación del Sistema";
                    RadNotification.Text = mens.Mensaje;

                    if (Dp.Valor == 1) 
                    {
                        RadNotification.TitleIcon = "warning";
                        RadNotification.ContentIcon = "warning";
                    }
                    else 
                    {
                        RadNotification.TitleIcon = "info";
                        RadNotification.ContentIcon ="info";
                    }                                                   
                }
            }
            else
            {
                RadNotification.Visible = false;
            }
            RadNotification.Visible = false;
        }
        /*botones*/
        protected void Btninicio_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 1).Url);
        }
        protected void btnCreacionUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 4).Url);
        }
        protected void btnImagen_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"],61).Url);
        }
        protected void btnRolesUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 5).Url);
        }
        protected void Btncerrarsesion_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 2).Url);
        }        
        /*Tareas Regionales*/       
        protected void btnTareaPlanificador_Click(object sender, EventArgs e)
        {
           Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 29).Url);
        }
        protected void btnTareaSubregional_Click(object sender, EventArgs e)
        {
           Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 28).Url);
        }
        protected void btnTareaRegional_Click(object sender, EventArgs e)
        {
           Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 27).Url);
        }
        protected void btnVerficarMetas_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 31).Url);
        }
        protected void btnJefePlanificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 34).Url);
        }        
        protected void btnConsultaPOaRegional_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 45).Url);
        }
        protected void btnTareaMonitoreoR_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 63).Url);
        }
        protected void btnTareaMonitoreoSR_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 64).Url);
        }

        /*Tareas Nacionales*/
        protected void btnCatalogoNacional_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 40).Url);
        }
        protected void btnJefePlanificacionNacional_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 48).Url);//Tareas_JefePlanificacion_Nacional
        }
        protected void btnTareaNacionalDirectores_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 49).Url);//Tareas_Directores_Nacionales
        }
        protected void btnVerficarMetasNacionalDirectores_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 50).Url);//RevisionDeMetasNacionales
        }
        protected void btnTareaNacionalJefes_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 51).Url);//Tareas_Departamentos
        }
        protected void btnConsultaPoaNacional_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 54).Url); //consulta de poas ingresados al sistema
        }
        protected void btnTareaDirectoresMonitoreo_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 91).Url); //Tarea Monitoreo directores
        }
        protected void btnTareaJefesMonitoreo_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 92).Url); //Tarea Monitoreo Jefaturas parques unidades
        }
        /*Monitoreo*/        
        protected void btnReporte_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 89).Url);
        }


        protected void btnAvanacional_Click(object sender, EventArgs e)
        {
            // Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 89).Url);
            Response.Redirect("Avances_Nacional.aspx");
        }

        protected void btnAvanregional_Click(object sender, EventArgs e)
        {
            // Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 89).Url);
            Response.Redirect("Avance_Regional.aspx");
        }

        /*Mantenimiento*/
        protected void MantenimientoPOA_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 7).Url);
        }
        protected void LinkCreacionPOAS_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 10).Url);
        }
        protected void LEnvioTarea_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 62).Url);
        }
        protected void lSeguimientoPOA_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 104).Url);
        }
        /*Documentación*/
        protected void DDocumentoRed_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 35).Url);
        }
        /*Soporte*/
        protected void Soporte_Click(object sender, EventArgs e) 
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 38).Url);
        }
        /*Reprogramaciones*/
        protected void BtnReprogramacionPlanificacion_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 100).Url);
        }
        protected void BtnReprogramacionRegional_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 101).Url);
        }
        protected void BtnReprogramacionNacional_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 102).Url);
        }
        protected void BtnReproPlanificacionN_Click(object sender, EventArgs e)
        {
            Response.Redirect(PermisosUsuario.Verifica_Permisos((List<Permisos_del_Sistema>)Session["Permisos_Sistema"], 103).Url);
        }
         

    }
}