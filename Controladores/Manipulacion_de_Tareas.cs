using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PlanificacionPOA.Controladores
{
    public class Manipulacion_de_Tareas
    {
        public DataSet Obtener_Tareas(UsuarioValida Users)
        {           
            ConectarBDD procesos = new ConectarBDD();
            DataSet TareaD = null;
            procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Users.id_usuario);
            procesos.AgregarParametro("@Id_Tipoperfil", SqlDbType.Int, Users.Id_Tipoperfil);
            procesos.AgregarParametro("@id_region", SqlDbType.Int, Users.id_region);
            procesos.AgregarParametro("@id_subregion", SqlDbType.Int, Users.id_subregion);
           
            DataSet Tarea = procesos.Execute("Sp_Verificar_Tareas_Pendientes");
            if ((Tarea.Tables[1] != null)  && (Tarea.Tables[1].Rows.Count > 0))
            {
                TareaD = Tarea; 
            }            
            return TareaD;
        }
        public bool Pendientes(UsuarioValida Users)
        {
            bool Resultado;
            ConectarBDD procesos = new ConectarBDD();
            procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Users.id_usuario);
            procesos.AgregarParametro("@Id_Tipoperfil", SqlDbType.Int, Users.Id_Tipoperfil);
            procesos.AgregarParametro("@id_region", SqlDbType.Int, Users.id_region);
            procesos.AgregarParametro("@id_subregion", SqlDbType.Int, Users.id_subregion);
          
            DataSet Tarea = procesos.Execute("Sp_Verificar_Tareas_Pendientes");
            if ((Tarea.Tables[0] != null) && (Tarea.Tables[0].Rows.Count > 0))
            {
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) != 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            else 
            {
                Resultado = false;
            }
            return Resultado;
        }
        public string Testigo_notificacion(UsuarioValida Users)
        {
            string Resultado = string.Empty;
            ConectarBDD procesos = new ConectarBDD();
            procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Users.id_usuario);
            procesos.AgregarParametro("@Id_Tipoperfil", SqlDbType.Int, Users.Id_Tipoperfil);
            procesos.AgregarParametro("@id_region", SqlDbType.Int, Users.id_region);
            procesos.AgregarParametro("@id_subregion", SqlDbType.Int, Users.id_subregion);
            
            DataSet Tarea = procesos.Execute("Sp_Verificar_Tareas_Pendientes");
            if ((Tarea.Tables[0] != null) && (Tarea.Tables[0].Rows.Count > 0))
            {
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 0)
                {
                    Resultado = string.Empty;
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 1)
                {
                    Resultado = "Mensaje_1.png";
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 2)
                {
                    Resultado = "Mensaje_2.png";
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 3)
                {
                    Resultado = "Mensaje_3.png";
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 4)
                {
                    Resultado = "Mensaje_4.png";
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) == 5)
                {
                    Resultado = "Mensaje_5.png";
                }
                if (Convert.ToInt32(Tarea.Tables[0].Rows[0]["No_Tareas"].ToString()) >= 6)
                {
                    Resultado = "Mensaje_6.png";
                }
            }           
            return Resultado;
        }
        public DataSet Dias_FaltaEntrega(UsuarioValida Users)
        {
            DataSet Resultado;
            ConectarBDD procesos = new ConectarBDD();
            procesos.AgregarParametro("@Id_Usuario", SqlDbType.Int, Users.id_usuario);
            procesos.AgregarParametro("@Id_Tipoperfil", SqlDbType.Int, Users.Id_Tipoperfil);
            procesos.AgregarParametro("@id_region", SqlDbType.Int, Users.id_region);
            procesos.AgregarParametro("@id_subregion", SqlDbType.Int, Users.id_subregion);
           
            DataSet Tarea = procesos.Execute("Sp_Verificar_Tareas_Pendientes");
            if ((Tarea.Tables[1] != null)  && (Tarea.Tables[1].Rows.Count > 0))
            {
                Resultado = Tarea; 
            }
            else
            {
                Resultado = null;
            }
            return Resultado;
        }

        /*Tarea a subregionales edicion*/
        public bool Inicializar_TareaPoaSubregionalEdicion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar,x.FechaEntrega);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_TareaSubregionEdicion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Inicializar_TareaPoaNacionalEdicion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_TareaNacionalEdicion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool AgregarActividadesEditar(ItemEdit x,int Op, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_Poa);          
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Id_ProductoVeficable", SqlDbType.Int,x.Id_ProductoVeficable);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_AgregarActividadesEditar", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool AgregarActividadesEditarNacionalES(ItemEdit x, int Op, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_Poa);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, x.Id_ProductoVeficable);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_AgregarActividadesEditarNacionales", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /*Tarea a subregionales*/
        public bool Inicializar_TareaPoaSubregional(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaE", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);
            Grabar.AgregarParametro("@Idmensaje", SqlDbType.Int, x.IdMensaje);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_TareaSubregion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Inicializar_TareaPoaSubregionalMonitoreo(DatosMonitoreoIngresoMetas x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaDeInicio", SqlDbType.NVarChar, x.Fecha_Inicio);
            Grabar.AgregarParametro("@FechaFinal", SqlDbType.NVarChar, x.Fecha_Final);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.NVarChar, x.Id_Mes);           
            Grabar.AgregarParametro("@Idmensaje", SqlDbType.Int, x.Id_Mensaje);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Envio_Tarea_Subregion_Monitoreo", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Tarea a jefaturas/unidades/parques nacionales*/
        public bool Inicializar_TareaPoaDepartamentoPaque2(DatosMonitoreoIngresoMetas x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaDeInicio", SqlDbType.NVarChar, x.Fecha_Inicio);
            Grabar.AgregarParametro("@FechaFinal", SqlDbType.NVarChar, x.Fecha_Final);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, x.Id_Mes);
            Grabar.AgregarParametro("@Idmensaje", SqlDbType.Int, x.Id_Mensaje);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_TareaDepartamentoParqueMonitoreo", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Inicializar_TareaPoaDepartamentoPaque(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaE", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);
            Grabar.AgregarParametro("@Idmensaje", SqlDbType.Int, x.IdMensaje);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Inicializar_TareaDepartamentoParque", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Denegación de tareas*/
        public bool Denegar_tareaSubregion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@fechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ReenviarMetasDenegadasSubregion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Denegar_tareaDepartamento(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@fechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ReenviarMetasDenegadasDepartamento", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Enviar tarea al Regional*/
        public bool Enviar_tareaRegion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EnviarTareaActividadesaRegion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Enviar Tareas planificador*/
        public bool Enviar_tareaPlanificador(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EnviarTareaActividadesaPlanificacion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Denegación de tareas del planificador*/
        public bool Denegar_tareaARegion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@fechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ReenviarMetasDenegadasRegion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
            /*pre-aprobacion de tareas */
        public bool Enviar_tareaJefePlanificacion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EnviarTareaActividadesJefePlanificacion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }        
        /*denegacion de metas del jefe de planificacion*/
        public bool Denegar_tareaARegiondelJefe(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ReenviarMetasDenegadasRegiondelJefe", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Denegar_tareaAJefePlanificacionNacional(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ReenviarMetasDenegadasJefeNacional", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Aprobacion de tareas por parte del jefe de planificacion*/
        public bool Aprobar_tareaJefePlanificacion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_AprobarTareaActividadesJefePlanificacion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Aprobar_tareaJefePlanificacionNacional(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_AprobarTareaActividadesPlanificacionNacional", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /*Agregar Documento*/
        public bool Subir_Documento(DocumentoFisico x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
           
            Grabar.AgregarParametro("@Enlace_del_Documento", SqlDbType.NVarChar, x.Enlace_del_Documento);
            Grabar.AgregarParametro("@Descripcion", SqlDbType.NVarChar, x.Descripcion);
            Grabar.AgregarParametro("@NombreArchivo", SqlDbType.NVarChar, x.NombreArchivo);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int,x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_SubirDocumentosSistema", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Subir_Imagen(DocumentoFisico x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Enlace_del_Documento", SqlDbType.NVarChar, x.Enlace_del_Documento);
            Grabar.AgregarParametro("@Descripcion", SqlDbType.NVarChar, x.Descripcion);
            Grabar.AgregarParametro("@NombreArchivo", SqlDbType.NVarChar, x.NombreArchivo);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_SubirImagenSistema", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar_Documento(int Correlativo,int us, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Correlativo);          
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, us);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EliminarDocumentoRed", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Eliminar_Imagen(int Correlativo, int us, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id", SqlDbType.Int, Correlativo);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, us);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EliminarImagenesPortada", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /*Activación de tareas por parte del Encargado de planificacion*/
        public bool ActivacióndeMetas(DatosTarea x,int Id,string Fecha, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Fecha", SqlDbType.NVarChar,Fecha);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Activar_Tareas", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ActivacióndeMetasNacionales(DatosTarea x, int Id, string Fecha, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Id", SqlDbType.Int, Id);
            Grabar.AgregarParametro("@Fecha", SqlDbType.NVarChar, Fecha);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Activar_TareasNacionales", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public DiasPendiente TiempoIngreso(UsuarioValida uv) 
        {
            DiasPendiente Dp = new DiasPendiente();
            DataSet Ds;            
            Ds = Dias_FaltaEntrega(uv);
            
            if(Convert.ToInt32(Ds.Tables[1].Rows[0]["Dias"].ToString()) != 0) 
            {
                Dp.Resulta = true;
                Dp.Mensaje = Ds.Tables[1].Rows[0]["Titulo"].ToString();
                Dp.Valor = Convert.ToInt32(Ds.Tables[1].Rows[0]["Dias"].ToString());
            }
            else 
            {
                Dp.Resulta = false;
                Dp.Mensaje = string.Empty;
            }
            return Dp;
        }
        public List<DiasPendiente> Mensajes(UsuarioValida uv) 
        {
            List<DiasPendiente> Men = new List<DiasPendiente>();
            DiasPendiente Dp = new DiasPendiente();
            DataSet Ds;
            Ds = Dias_FaltaEntrega(uv);

            foreach (DataRow Fila in Ds.Tables[1].Rows)
            {
                Men.Add(new DiasPendiente
                {
                   Mensaje = Fila["Titulo"].ToString()
                   
                });

            }           
            return Men;
        }
        /*Enviar tarea al director nacional o al jefe de planificacion*/
        public bool Enviar_DirectorJefe(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EnviarTareaActividadesaDirectorJefe", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Enviar_JefePlanificacion(DatosTarea x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_SubRegion);
            Grabar.AgregarParametro("@Instrucciones", SqlDbType.NVarChar, x.Instrucciones);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);
            Grabar.AgregarParametro("@FechaEntrega", SqlDbType.NVarChar, x.FechaEntrega);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Int, x.TipoAsignacion);
            Grabar.AgregarParametro("@NoReprogramacion", SqlDbType.Int, x.NoReprogramacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_EnviarTareaActividadesaJefePlanificacion", true)) != null)
            {
                if (!DBNull.Value.Equals(IComandos.Parameters["@Error"].Value) && int.Parse(IComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(IComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(IComandos.Parameters["@MensajeError"].Value);
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