using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class DocumentosRed : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 330, 180, "Alerta", null);
                return;
            }
        }
        protected void VerificargRID()
        {
            GridDocumentos.Rebind();
            if (GridDocumentos.Items.Count != 0)
            {
                GridDocumentos.Visible = true;
                RespuestaAct.Visible = false;
            }
            else
            {
                GridDocumentos.Visible = false;
                RespuestaAct.Visible = true;
            }
        }
        protected void VerificarPermisos()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 36).Permiso != true)
            {
                Permisos.Visible = false;
                GridDocumentos.MasterTableView.GetColumn("BotonX").Display = false;
            }
            else 
            {
                Permisos.Visible = true;
                GridDocumentos.MasterTableView.GetColumn("BotonX").Display = true;
            }
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 37).Permiso != true)
            {               
                GridDocumentos.MasterTableView.GetColumn("BotonA").Display = false;
            }
            else
            {             
                GridDocumentos.MasterTableView.GetColumn("BotonA").Display = true;
            }
        }
        protected void GridDocumentos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string CadenaSql = "SELECT Id,Descripcion,NombreArchivo,Enlace_del_Documento FROM DocumentosRed";
            procesos.LlenarRadGrid(GridDocumentos, CadenaSql);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            AgregarDocumento.Click += new EventHandler(AgregarDocumento_Click);
            CerraVentana.Click += new EventHandler(CerraVentana_Click);
            GridDocumentos.NeedDataSource += new GridNeedDataSourceEventHandler(GridDocumentos_NeedDataSource);
            GridDocumentos.ItemCommand += new GridCommandEventHandler(Seleccionar_Documento);
            GridDocumentos.DeleteCommand += new GridCommandEventHandler(Eliminar_Documento);
            
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VerificargRID();
                VerificarPermisos();
            }
        }
        protected void AgregarDocumento_Click(object sender, EventArgs e)
        {
            DocumentoFisico D = new DocumentoFisico();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas mc = new Manipulacion_de_Tareas();
            Manejo_De_Archivos Mda = new Manejo_De_Archivos();
            ArchivosParaCarga DA;

            DA = Mda.Datos_de_Archivo("DocumentosRed\\", RadAcuerdoConvenio); 
            if (DA.Existe == false)
            {
                MensajePantalla("Debe Cargar Archivo...");
            }
            else
            {
                D.Enlace_del_Documento = DA.EnlaceDeGuardado; 
                D.Descripcion = DescripcionDocumento.Text.Trim();
                D.NombreArchivo = DA.Nombre;
                D.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (DA.bytes > 8000000)
                {
                    MensajePantalla("El Tamaño del archivo debe ser menor 8MB");
                }
                else
                {
                    if (Mda.ExisteArchivo_en_Sistema(D.Enlace_del_Documento) == true)
                    {
                        MensajePantalla("El Nombre de esa Imagen Ya existe en el sistema");
                    }
                    else
                    {
                        if (mc.Subir_Documento(D, ref er))
                        {
                            foreach (UploadedFile f in RadAcuerdoConvenio.UploadedFiles)
                            {
                                f.SaveAs(D.Enlace_del_Documento, true);
                            }

                            DescripcionDocumento.Text = string.Empty;
                            MensajePantalla("Se Cargo el Documento");
                            VerificargRID();
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                }
            }
        }
        /*manejo de grid*/
        protected void CerraVentana_Click(object sender, EventArgs e)
        {           
            CloseWinwdows(visualizar, "Key");
        }
        protected void Eliminar_Documento(object source, GridCommandEventArgs e)
        {
            Manejo_De_Archivos Mda = new Manejo_De_Archivos();
            GridDataItem item = e.Item as GridDataItem;          
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas mc = new Manipulacion_de_Tareas();
            
            int Correlativo = Convert.ToInt32(item.GetDataKeyValue("Id").ToString()); 
            int Usuario = Convert.ToInt32(Session["Usuario"].ToString());            
            string Nombre = item.GetDataKeyValue("NombreArchivo").ToString();
            string EnlaceM = Mda.DireccionArchivoSistema("DocumentosRed\\", Nombre);

            if (File.Exists(EnlaceM))
            {
                if (Mda.Eliminar_Archivo_Sistema(EnlaceM) == false)
                {
                    if (mc.Eliminar_Documento(Correlativo, Usuario, ref er))
                    {                        
                        MensajePantalla("Se elimino el Documento");
                        VerificargRID();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
                else 
                {
                    MensajePantalla("No se Pudo Eliminar el archivo Fisicamente");
                }
            }
            else 
            {
                MensajePantalla("El archivo no existe Fisicamente.");
            }
        }
        protected void Seleccionar_Documento(object sender, GridCommandEventArgs e)
        {            
            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Manejo_De_Archivos Mda = new Manejo_De_Archivos(); 
                string Nombre = item.GetDataKeyValue("NombreArchivo").ToString();
                string cadena = @"~\DocumentosRed\\" + Nombre;
                string Enlace = Mda.DireccionArchivoSistema("DocumentosRed\\", Nombre); 

                if (File.Exists(Enlace))
                {
                    viewer.Attributes.Add("src", cadena);
                    OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");                    
                }               
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
        protected void CloseWinwdows(RadWindow Ventana, string Llave)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").close();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
    }
}