using PlanificacionPOA.Modelos;
using System;
using System.IO;
using Telerik.Web.UI;

namespace PlanificacionPOA.Controladores
{
    public class Manejo_De_Archivos
    {
       public ArchivosParaCarga Datos_de_Archivo(string Carpetas,RadAsyncUpload ObjetoSubirArchivo)
       {
            ArchivosParaCarga DA = new ArchivosParaCarga();
            string Nombre;

            foreach (UploadedFile f in ObjetoSubirArchivo.UploadedFiles)
            {
                Nombre = f.GetName().ToString();
                if (Nombre == string.Empty)
                { 
                    DA.Existe = false; 
                } 
                else
                { 
                    DA.Existe = true;
                    DA.Nombre = Nombre;
                    DA.bytes = (int)f.ContentLength;
                    DA.EnlaceDeGuardado = AppDomain.CurrentDomain.BaseDirectory + Carpetas + f.GetName();
                    DA.ExtensionArchivo = f.GetExtension();
                }
            }
            return DA;
       }        
        public string DireccionArchivoSistema(string Carpetas,string NombreArchivo)
        {
            string Path = AppDomain.CurrentDomain.BaseDirectory + Carpetas + NombreArchivo;            
            return Path;
        }
        public Mensajes_Error_BDD Crear_Carpeta_Sistema(string Direccion,string NombreCarpeta) 
        {
            Mensajes_Error_BDD Respuesta = new Mensajes_Error_BDD();
            string Path = AppDomain.CurrentDomain.BaseDirectory + Direccion + NombreCarpeta;
            bool Revisar = Directory.Exists(Path);
           
            if (Revisar == false) 
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Direccion + NombreCarpeta);

                if (Revisar == true)
                {
                    Respuesta.Numero = 1;
                    Respuesta.Descripcion = "Se Creo la Carpeta en el Sistema";
                }
                else
                {
                    Respuesta.Numero = 0;
                    Respuesta.Descripcion = "Hubo un Problema No se pudo crear la Carpeta en el Sistema";
                }
            }
            else 
            {
                Respuesta.Numero = 0;
                Respuesta.Descripcion = "La Carpeta Ya Exsite en el Sistema"; 
            }
            
            return Respuesta;            
        }
        public bool ExisteCarpeta_en_Sistema(string DireccionArchivo)
        {
            bool Respuesta;

            if (Directory.Exists(DireccionArchivo) == true)
            {
                Respuesta = true;
            }
            else
            {
                Respuesta = false;
            }
            return Respuesta;
        }
        public bool ExisteArchivo_en_Sistema(string DireccionArchivo) 
        {
            bool Respuesta;

            if (File.Exists(DireccionArchivo) == true)
            {
                Respuesta = true;
            }
            else
            {
                Respuesta = false;
            }
            return Respuesta; 
        }
        public int Cantidad_De_Archivos(string Ubicacion) 
        {
            int Cantidad_Archivos = 0;
            DirectoryInfo Di = new DirectoryInfo(Ubicacion);

            foreach (var fi in Di.GetFiles())
            {
                Cantidad_Archivos += 1;
            }

            return Cantidad_Archivos;
        }
        public bool Eliminar_Archivo_Sistema(string DireccionArchivo)
        {
            bool Respuesta;
            
            File.SetAttributes(DireccionArchivo, FileAttributes.Normal);
            File.Delete(DireccionArchivo);

            if (ExisteArchivo_en_Sistema(DireccionArchivo) == false) 
            {
                Respuesta = false;
            }
            else 
            {
                Respuesta = true;
            }                
            return Respuesta;
        }
    }
}