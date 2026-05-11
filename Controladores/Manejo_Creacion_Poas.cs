using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace PlanificacionPOA.Controladores
{
    public class Manejo_Creacion_Poas
    {
        public int Obtener_Correlativo(int Opcion, int Combo)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            string Cadena = string.Empty; 
            if (Opcion == 1) 
            {
                Cadena = "select ISNULL(Correlativo,0) Correlativo from Componente where IdComponente = " + Combo;
            }
            if (Opcion == 2)
            {
                Cadena = "select ISNULL(Correlativo,0) Correlativo from SubComponenteRegional where Id_SubComponente = " + Combo;
            }
            if (Opcion == 3)
            {
                Cadena = "select ISNULL(Correlativo,0) Correlativo from Productos_Verificables where Id_Producto = " + Combo;
            }                                                
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["Correlativo"].ToString());                
            }
            else
            {
                Valor = 0;
            }

            return Valor;
        }
        public bool Activar_Desactivar(AIObjetos p, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
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
        public bool Creacion_Poas(PoasCreados x1, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, x1.Opcion);
            Grabar.AgregarParametro("@Id", SqlDbType.Int, x1.Dato_1);                       
            Grabar.AgregarParametro("@TipoPOA", SqlDbType.Int, x1.Dato_2);
            Grabar.AgregarParametro("@Descripcion", SqlDbType.VarChar, x1.Descripcion);
            Grabar.AgregarParametro("@AnioCorresponde", SqlDbType.Int, x1.AnioCorresponde);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x1.Idusuario);
            
            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Creacion_Poas", true)) != null)
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
        public bool Inicializar_TareaPoa(Tarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
           
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);            
            Grabar.AgregarParametro("@FechaDeEntrega", SqlDbType.NVarChar, x.FechaDeEntrega);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);           
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_Tarea", true)) != null)
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
        public bool Enviar_Tarea_Monitoreo(TMonitoreo x, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);          
            Grabar.AgregarParametro("@FechaFinal", SqlDbType.NVarChar, x.FechaDeFinal);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, x.Id_Mes);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_Tarea_Monitoreo", true)) != null)
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
        public bool Copiar_Informacion_AnteriorPoa(int Id_PoAnual, int Id_Usuario, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int,Id_PoAnual);            
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int,Id_Usuario);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_CopiarDatos_Poa_Anterioranio", true)) != null)
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
        public bool Eliminar_POA(int Id_PoAnual, int Id_Usuario, ref Mensajes_Error_BDD e)
        {            
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Id_PoAnual);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, Id_Usuario);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_de_Poa", true)) != null)
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
        /*Ingreso de productos*/
        public bool Ingreso_de_productoPOA(int ops,ProductoRegional pr,int Idproducto,XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {           
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, ops);
            Grabar.AgregarParametro("@IdproductoAnterior", SqlDbType.Int, Idproducto);
            Grabar.AgregarParametro("@Id_PoAnual",SqlDbType.Int, pr.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Usuario",SqlDbType.Int, pr.Id_Usuario);
            Grabar.AgregarParametro("@AnioPoa", SqlDbType.Int, pr.anioPoa);
            Grabar.AgregarParametro("@Informacion",SqlDbType.Xml, DescripcionDAta.OuterXml);                      

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Ingreso_de_productos_Poa", true)) != null)
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
        public bool Eliminacion_ProductoPOABDD(int Id_Poa, int Id_Usuario, int Id_producto, ref Mensajes_Error_BDD e)
        {            
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Id_Poa);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, Id_Usuario);           
            Grabar.AgregarParametro("@Idproducto", SqlDbType.Int, Id_producto);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productos_Poa", true)) != null)
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