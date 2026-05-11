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
    public partial class ImagenesPortada : System.Web.UI.Page
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
            ImagenGRD.Rebind();
            if (ImagenGRD.Items.Count != 0)
            {
                ImagenGRD.Visible = true;
                RespuestaAct.Visible = false;
            }
            else
            {
                ImagenGRD.Visible = false;
                RespuestaAct.Visible = true;
            }
        }
        protected void ImagenGRD_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string CadenaSql = "SELECT Id,Urlimagen,Descripcion,DireccionEliminacion,Titulo,Estado FROM ImagenesPortada;";
            procesos.LlenarRadGrid(ImagenGRD, CadenaSql);
        }
        protected void Eliminar_ImagenGRD(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas mc = new Manipulacion_de_Tareas();
            Manejo_De_Archivos MDA = new Manejo_De_Archivos();
            int Correlativo = Convert.ToInt32(item.GetDataKeyValue("Id").ToString());
            int Usuario = Convert.ToInt32(Session["Usuario"].ToString());           
            string Nombre = item.GetDataKeyValue("Titulo").ToString();
            string Enlace2 = MDA.DireccionArchivoSistema("Imagenes\\Carrusel\\", Nombre);

            if (File.Exists(Enlace2))
            {
                if(MDA.Eliminar_Archivo_Sistema(Enlace2) == false)
                {
                    if (mc.Eliminar_Imagen(Correlativo, Usuario, ref er))
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
        protected void AgregarImagen_Click(object sender, EventArgs e)
        {
            DocumentoFisico D = new DocumentoFisico();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manipulacion_de_Tareas mc = new Manipulacion_de_Tareas();
            Manejo_De_Archivos MDA = new Manejo_De_Archivos();
            ArchivosParaCarga APC;

            APC = MDA.Datos_de_Archivo("Imagenes\\Carrusel\\", RadImagen);
            
            if (APC.Existe == false)
            {
                MensajePantalla("Debe Cargar Archivo...");
            }
            else
            {
                if (APC.bytes > 8000000)
                {
                    MensajePantalla("El Tamaño del archivo debe ser menor 8MB");
                }
                else
                {
                    D.Enlace_del_Documento = APC.EnlaceDeGuardado;
                    D.Descripcion = DescripcionDocumento.Text.Trim();
                    D.NombreArchivo = APC.Nombre; 
                    D.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());

                    if (MDA.ExisteArchivo_en_Sistema(D.Enlace_del_Documento) == true)
                    {
                        MensajePantalla("El Nombre de esa Imagen Ya existe en el sistema");
                    }
                    else
                    {
                        if (mc.Subir_Imagen(D, ref er))
                        {
                            foreach (UploadedFile f in RadImagen.UploadedFiles)
                            {
                                f.SaveAs(D.Enlace_del_Documento, true);
                            }
                            DescripcionDocumento.Text = string.Empty;
                            MensajePantalla("Se Cargo la imagen al sisema");
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
        protected void Seleccionar_Imagen(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            Manejo_De_Archivos MDA = new Manejo_De_Archivos();
            if (e.CommandName == "Select")
            {
                string Nombre = item.GetDataKeyValue("Titulo").ToString();
                string cadena = @"~\Imagenes\\Carrusel\\" + Nombre;
                string Enlace = MDA.DireccionArchivoSistema("Imagenes\\Carrusel\\", Nombre);

                if (File.Exists(Enlace))
                {
                    viewer.Attributes.Add("src", cadena);
                    OpenWinwdows(visualizar, "980", "800", "Key", "Visualizador de Imagenes");
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ImagenGRD.NeedDataSource += new GridNeedDataSourceEventHandler(ImagenGRD_NeedDataSource);
            ImagenGRD.DeleteCommand += new GridCommandEventHandler(Eliminar_ImagenGRD);
            ImagenGRD.ItemCommand += new GridCommandEventHandler(Seleccionar_Imagen);
            AgregarImagen.Click += new EventHandler(AgregarImagen_Click);
                       
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VerificargRID();               
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