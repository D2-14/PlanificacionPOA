using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace PlanificacionPOA.Controladores
{
    public class Manejo_De_Mantenimiento_PoaNacional
    {
        public bool VerifcarDatosPoaNacional(int Idopoa, int idSubregion)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Resulta;
            string CadenaSQl = "SELECT dbo.fn_Revision_DataNacional(" + Idopoa + "," + idSubregion + ") AS Cantidad";            
            DataSet Datos = Grabar.obtenerDataSetCodigo(CadenaSQl, "Tabla");

            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                if (Convert.ToInt32(Datos.Tables[0].Rows[0]["Cantidad"].ToString()) != 0)
                {
                    Resulta = true;
                }
                else
                {
                    Resulta = false;
                }
            }
            else
            {
                Resulta = false;
            }
            return Resulta;
        }
        public bool Activar_Desactivar(AIObjetos p, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos = new SqlCommand();
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@opcion", SqlDbType.Int, p.Opcion);
            Grabar.AgregarParametro("@Dato_1", SqlDbType.Int, p.Dato_1);
            Grabar.AgregarParametro("@Dato_2", SqlDbType.Int, p.Dato_2);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, p.Idusuario);
            
            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Activacion_Desactivacion", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public int Obtener_correlativos_Configuracion(string slqstring)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Dato;
            DataSet Datos = Grabar.obtenerDataSetCodigo(slqstring, "Tabla");

            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Dato = Convert.ToInt32(Datos.Tables[0].Rows[0]["Correlativo"].ToString());
                
            }
            else
            {
                Dato = 0;
            }
            return Dato;
        }
        public bool Creacion_Objetos(AIObjetos x1, ref Mensajes_Error_BDD e)
        {            
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int,x1.Opcion);
            Grabar.AgregarParametro("@Id", SqlDbType.Int, x1.Dato_1);
            Grabar.AgregarParametro("@IdO", SqlDbType.Int, x1.Dato_2);
            Grabar.AgregarParametro("@Descripcion", SqlDbType.VarChar,x1.Descripcion_1);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int,x1.Idusuario);
            Grabar.AgregarParametro("@Tipo", SqlDbType.Int, x1.Tipo);
            Grabar.AgregarParametro("@Dato3", SqlDbType.Int, x1.Dato_3);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Creacion_ObjetosPOANacional", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Creacion_ObjetosRegional(AIObjetosRegional x1, ref Mensajes_Error_BDD e)
        {      
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, x1.Opcion);
            Grabar.AgregarParametro("@Tipo", SqlDbType.Int, x1.Tipo);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x1.Idusuario);
            Grabar.AgregarParametro("@Dato_1", SqlDbType.Int, x1.Dato_1);
            Grabar.AgregarParametro("@Dato_2", SqlDbType.Int, x1.Dato_2);
            Grabar.AgregarParametro("@Dato_3", SqlDbType.Int, x1.Dato_3);
            Grabar.AgregarParametro("@Dato_4", SqlDbType.Int, x1.Dato_4);
            Grabar.AgregarParametro("@Dato_5", SqlDbType.Int, x1.Dato_5);            
            Grabar.AgregarParametro("@Descripcion", SqlDbType.VarChar, x1.Descripcion);
            Grabar.AgregarParametro("@Correlativo", SqlDbType.Int, x1.Correlativo);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Creacion_ObjetosPOARegional", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Creacion_ObjetosNacionalesMantenimiento(AIObjetosNacionales x1,int Corr, ref Mensajes_Error_BDD e)
        {   
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
            
            Grabar.AgregarParametro("@Op", SqlDbType.Int, x1.Opcion);
            Grabar.AgregarParametro("@Idobjeto", SqlDbType.Int, x1.Idobjeto);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x1.Id_Usuario);
            Grabar.AgregarParametro("@Dato_1", SqlDbType.Int, x1.Id_producto);           
            Grabar.AgregarParametro("@Dato_2", SqlDbType.Int, x1.IdObjetivo);
            Grabar.AgregarParametro("@Dato_3", SqlDbType.Int, x1.IdResultado);
            Grabar.AgregarParametro("@Dato_4", SqlDbType.Int, x1.IdIndicadores);
            Grabar.AgregarParametro("@Dato_5", SqlDbType.Int, x1.Id_Region);
            Grabar.AgregarParametro("@Dato_6", SqlDbType.Int, x1.Id_Subregion);
            Grabar.AgregarParametro("@Descripcion", SqlDbType.VarChar, x1.Descripcion_Producto);
            Grabar.AgregarParametro("@CorrelativoPSA", SqlDbType.VarChar, x1.CorrelativoPSA);
            Grabar.AgregarParametro("@Descripcion_Correlativo", SqlDbType.VarChar, x1.Descripcion_Correlativo);
            Grabar.AgregarParametro("@Correlativo", SqlDbType.VarChar, Corr);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Creacion_ObjetosPOANacionalMantenimiento", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Guardar_producto_Configuracion(ConfiguracionUMNacionales pr,XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, pr.Opcion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, pr.Correlativo_Configuracion);            
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, pr.Id_Usuario);            
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);     
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, pr.Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, pr.Id_Subregion);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productosConfiguracion_Nacionales", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Guardar_producto_ConfiguracionPlani(ConfiguracionUMNacionales pr,int IDPOA ,XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, pr.Opcion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, pr.Correlativo_Configuracion);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, pr.Id_Usuario);
            Grabar.AgregarParametro("@Id_POA", SqlDbType.Int, IDPOA);
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, pr.Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, pr.Id_Subregion);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productosConfiguracion_NacionalesPlani", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public List<ConfiguracionUMNacionales> Agregar_ProductoListaConfiguracion(ConfiguracionUMNacionales pr)
        {
            List<ConfiguracionUMNacionales> Lpr = new List<ConfiguracionUMNacionales>();
            Lpr.Add(pr);

            return Lpr;
        }
        public XmlDocument DetalleXMLProductoNacionales(List<ConfiguracionUMNacionales> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo_Configuracion", G.Correlativo_Configuracion, ElementoDetalle);
                x.AgregarAtributo("Id_Producto", G.Id_Producto, ElementoDetalle);
                x.AgregarAtributo("DescripcionProducto", G.DescripcionProducto, ElementoDetalle);               
                x.AgregarAtributo("Id_SubProducto", G.Id_SubProducto, ElementoDetalle);
                x.AgregarAtributo("DescripcionSubProducto", G.DescripcionSubProducto, ElementoDetalle);
                x.AgregarAtributo("Id_Actividad", G.Id_Actividad, ElementoDetalle);
                x.AgregarAtributo("DescripcionActividad", G.DescripcionActividad, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM1", G.DescripcionUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM2", G.DescripcionUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM3", G.DescripcionUM3, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("DireccionMedioVerificacion", G.DireccionMedioVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_Region", G.Id_Region, ElementoDetalle);
                x.AgregarAtributo("Id_Subregion", G.Id_Subregion, ElementoDetalle);
                x.AgregarAtributo("Id_Correlativo_Producto", G.Id_Correlativo_Producto, ElementoDetalle);
                x.AgregarAtributo("Id_Correlativo_SubProducto", G.Id_Correlativo_SubProducto, ElementoDetalle);
                x.AgregarAtributo("Id_Correlativo_Actividad", G.Id_Correlativo_Actividad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public bool Eliminacion_ProductoNacional2(int Id, int Id_Usuario, int Id_Region, int Id_Subregion,int Op, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, Id_Usuario);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Id_Subregion);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productosNacionalesCatalogo", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminacion_ProductoNacional(int Id,int Id_Usuario,int Id_Region,int Id_Subregion, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, Id_Usuario);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Id_Subregion);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productosConfiguracionNacional", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminacion_ProductoNacionalPlani(int Id, int Id_Usuario,int idPoa,int Id_Region, int Id_Subregion, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, Id_Usuario);
            Grabar.AgregarParametro("@Id_POA", SqlDbType.Int, idPoa);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Id_Subregion);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productosConfiguracionNacionalPlani", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminacion_Actividades_POANacional(int Id, DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int,x.Id_Usuario);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int,x.Id_Region);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int,x.Id_SubRegion);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_ActividadesPOANacional", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}