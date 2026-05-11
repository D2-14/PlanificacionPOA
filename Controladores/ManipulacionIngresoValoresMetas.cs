using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PlanificacionPOA.Controladores
{
    public class ManipulacionIngresoValoresMetas
    {
        public bool Edicion_de_ValoresMetas(GuardarMetasSubregion gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, gmsub.Id_Componente);
            Grabar.AgregarParametro("@Id_SubComponente", SqlDbType.Int, gmsub.Id_SubComponente);
            Grabar.AgregarParametro("@Id_ProductoVeficable", SqlDbType.Int, gmsub.Id_ProductoVeficable);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, gmsub.Id_Mes);
            Grabar.AgregarParametro("@UM1", SqlDbType.Decimal, gmsub.UM1);
            Grabar.AgregarParametro("@UM2", SqlDbType.Decimal, gmsub.UM2);
            Grabar.AgregarParametro("@UM3", SqlDbType.Decimal, gmsub.UM3);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Metas_PoaSubregionalPlanis", true)) != null)
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
        public bool Ingreso_de_ValoresMetas(GuardarMetasSubregion gmsub , ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
            
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, gmsub.Id_Componente);
            Grabar.AgregarParametro("@Id_SubComponente", SqlDbType.Int, gmsub.Id_SubComponente);
            Grabar.AgregarParametro("@Id_ProductoVeficable", SqlDbType.Int, gmsub.Id_ProductoVeficable);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, gmsub.Id_Mes);
            Grabar.AgregarParametro("@UM1", SqlDbType.Decimal, gmsub.UM1);
            Grabar.AgregarParametro("@UM2", SqlDbType.Decimal, gmsub.UM2);
            Grabar.AgregarParametro("@UM3", SqlDbType.Decimal , gmsub.UM3);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Decimal, gmsub.TipoAsignacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Metas_PoaSubregionals", true)) != null)
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
        public bool Ingreso_de_ValoresMetasNacionales(GuardaMetasNacional gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, gmsub.Correlativo_Configuracion);            
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, gmsub.Id_Mes);
            Grabar.AgregarParametro("@UM1", SqlDbType.Decimal, gmsub.UM1);
            Grabar.AgregarParametro("@UM2", SqlDbType.Decimal, gmsub.UM2);
            Grabar.AgregarParametro("@UM3", SqlDbType.Decimal, gmsub.UM3);
            Grabar.AgregarParametro("@TipoAsignacion", SqlDbType.Decimal, gmsub.TipoAsignacion);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Metas_PoaNacionalIngreso", true)) != null)
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
        public bool ConfiguracionUMMetasNacionales(GuardaMetasNacional gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, gmsub.Correlativo_Configuracion);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);
            Grabar.AgregarParametro("@Id_Unidad_Evaluada", SqlDbType.Int, gmsub.Id_Unidad_Evaluada);
            Grabar.AgregarParametro("@RedProgramatica", SqlDbType.Int, gmsub.RedProgramatica);            

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_ConfiguracionUnidadMedidas_PoaNacionalIngreso", true)) != null)
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
        public bool Generar_meses(GuardarMetasSubregion gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
            
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, gmsub.Id_Componente);
            Grabar.AgregarParametro("@Id_SubComponente", SqlDbType.Int, gmsub.Id_SubComponente);
            Grabar.AgregarParametro("@Id_ProductoVeficable", SqlDbType.Int, gmsub.Id_ProductoVeficable);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);            

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Meses_PoaSubregional", true)) != null)
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
        public bool Generar_meses_Todos(DatosTarea gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);          
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Meses_PoaSubregional_Todos", true)) != null)
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
        public bool Generar_meses_TodosNacionales(DatosTarea gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Meses_PoaNacional_Todos", true)) != null)
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
        public bool Generar_mesesNacionales(GuardaMetasNacional gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, gmsub.Correlativo_Configuracion);
            Grabar.AgregarParametro("@Id_Producto", SqlDbType.Int, gmsub.Id_Producto);
            Grabar.AgregarParametro("@Id_SubProducto", SqlDbType.Int, gmsub.Id_SubProducto);
            Grabar.AgregarParametro("@Id_Actividad", SqlDbType.Int, gmsub.Id_Actividad);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Procesamiento_de_Meses_PoaNacional", true)) != null)
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
        public bool Verificar_BotonGenerarMeses(GuardarMetasSubregion gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, gmsub.Id_Componente);
            Grabar.AgregarParametro("@Id_SubComponente", SqlDbType.Int, gmsub.Id_SubComponente);
            Grabar.AgregarParametro("@Id_ProductoVeficable", SqlDbType.Int, gmsub.Id_ProductoVeficable);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Verificar_boton", true)) != null)
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
        public bool Verificar_BotonGenerarMesesNacionales(GuardaMetasNacional gmsub, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, gmsub.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, gmsub.Id_SubRegion);
            Grabar.AgregarParametro("@Correlativo_Configuracion", SqlDbType.Int, gmsub.Correlativo_Configuracion);           
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, gmsub.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_Verificar_botonNacional", true)) != null)
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
        public bool VerificarCarga(DatosTarea gmsub) 
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                "SELECT ISNULL(CargaCompleta, 0) AS Verificar FROM MetasSubregionProyeccion WHERE Id_PoAnual = "+ gmsub.Id_PoAnual.ToString() + 
                " AND Id_Subregion = "+ gmsub.Id_SubRegion + ";";
                
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else 
            {
                Valor = false;
            }
                return Valor;
        }
        public bool VerificarCargaNacionales(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                "SELECT ISNULL(CargaCompleta, 0) AS Verificar FROM MetasDepartamentoUPProyeccion WHERE Id_PoAnual = " + gmsub.Id_PoAnual.ToString() +
                " AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarTareaIniciada(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                "SELECT ISNULL(CargaCompleta, 0) AS Verificar FROM MetasDepartamentoUPProyeccion WHERE Id_PoAnual = " + gmsub.Id_PoAnual.ToString() +
                " AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarConfiguraciondeActvidades(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena = "Sp_VerifcarData_ProductosNacionales "+ gmsub.Id_Region +"," + gmsub.Id_SubRegion + ";";                

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                if (Convert.ToInt32(Datos.Tables[0].Rows[0]["EXISTE"].ToString()) != 0)
                {
                    Valor = true;
                }
                else
                {
                    Valor = false;
                }
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarCarga2(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                "SELECT ISNULL(CargaCompleta, 0) AS Verificar FROM MetasSubregionProyeccion WHERE Aprobado = 1 and Id_PoAnual = " + gmsub.Id_PoAnual.ToString() +
                " AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarCargaNacional(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                "SELECT ISNULL(CargaCompleta, 0) AS Verificar FROM MetasDepartamentoUPProyeccion WHERE Aprobado = 1 and Id_PoAnual = " + gmsub.Id_PoAnual.ToString() +
                " AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }


        public bool VerificarCargaNacional_(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena =
                //"SELECT ISNULL(Id_Subregion, 0) AS Verificar FROM MetasDepartamentoUPMonitoreo WHERE  Id_PoAnual = 2 AND Id_Subregion = " + gmsub.Id_SubRegion + ";";
                "SELECT ISNULL(Id_Subregion, 0) AS Verificar FROM MetasDepartamentoUPMonitoreo WHERE  Id_PoAnual =" + gmsub.Id_PoAnual + "AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarCargaNacional2(DatosTarea D)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta;
            string Cadena = "SELECT ISNULL(COUNT(*), 0) Cantidad FROM MetasDepartamentoUPMonitoreo WHERE Id_PoAnual = " + D.Id_PoAnual + " AND Id_Subregion =" + D.Id_SubRegion;
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["Cantidad"].ToString());

                if (Valor != 0)
                {
                    Respuesta = true;
                }
                else
                {
                    Respuesta = false;
                }
            }
            else
            {
                Respuesta = false;
            }
            return Respuesta;
        }
        public bool VerificarCargaModificaciones(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena = "SELECT Id_PoAnual FROM Historial_IngresoValoresUM WHERE Id_PoAnual = "+ gmsub.Id_PoAnual.ToString() + " AND Id_Subregion = "+ gmsub.Id_SubRegion +";";
            
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public bool VerificarModificacionesNacionales(DatosTarea gmsub)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Valor;

            string Cadena = "SELECT Id_PoAnual FROM Historial_IngresoValoresUMNacionales WHERE Id_PoAnual = " + gmsub.Id_PoAnual.ToString() + " AND Id_Subregion = " + gmsub.Id_SubRegion + ";";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = true;
            }
            else
            {
                Valor = false;
            }
            return Valor;
        }
        public string Mes(int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            string Nombre;
            string tc = string.Empty;
            string nombrecompleto;
            string Cadena = "SELECT Descripcion_Mes AS D FROM Meses WHERE Id_meses  = '" + id + "'";
            DataSet DatosUsuario = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            if((id == 1) || (id == 2) || (id == 3) || (id == 4)) { tc = "Primer Cuatrimestre"; }
            if((id == 5) || (id == 6) || (id == 7) || (id == 8)) { tc = "Segundo Cuatrimestre"; }
            if((id == 9) || (id == 10) || (id == 11) || (id == 12)) { tc = "Tercer Cuatrimestre"; }

            Nombre = DatosUsuario.Tables[0].Rows[0]["D"].ToString();
            nombrecompleto ="Mes de "+ Nombre + " que pertenece al " + tc;
            return nombrecompleto;
        }
        public DataSet DatospoatituloReporte(DatosReporte x)
        {
            ConectarBDD Grabar = new ConectarBDD();

            string Cadena = "SELECT(Nombres + ' ' + Apellidos) Subregional,sr.Subregion,r.Nombre_Region Region " +
                           "FROM Usuarios u INNER JOIN Subregion sr ON u.Id_Subregion = sr.Id_Subregion " +
                           "INNER JOIN Region r ON r.Id_Region = u.Id_Region WHERE u.Id_Subregion = " + x.Id_SubRegion.ToString() + " AND u.Estado_Usuario=1;";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            return Datos;
        }
        public DataSet Datospoatitulo(DatosTarea x)
        {
            ConectarBDD Grabar = new ConectarBDD();
            
            string Cadena ="SELECT(Nombres + ' ' + Apellidos) Subregional,sr.Subregion,r.Nombre_Region Region "+
                           "FROM Usuarios u INNER JOIN Subregion sr ON u.Id_Subregion = sr.Id_Subregion "+
                           "INNER JOIN Region r ON r.Id_Region = u.Id_Region WHERE u.Id_Subregion = "+x.Id_SubRegion.ToString() + " AND u.Estado_Usuario=1;";                
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            
            return Datos;
        }
        public DataSet DatospoatituloNacional(DatosTarea x)
        {
            ConectarBDD Grabar = new ConectarBDD();

            string Cadena = "SELECT(Nombres + ' ' + Apellidos) Subregional,sr.Subregion,r.Nombre_Region Region " +
                           "FROM Usuarios u INNER JOIN Subregion sr ON u.Id_Subregion = sr.Id_Subregion " +
                           "INNER JOIN Region r ON r.Id_Region = u.Id_Region WHERE /*u.Id_Tipoperfil in(6,8,27,12,13,14,24,25) AND*/ " +
                           "u.Id_Subregion = " + x.Id_SubRegion.ToString() + " AND u.Estado_Usuario=1 ;";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            return Datos;
        }
        public string Aniopoa(int x)
        {
            ConectarBDD Grabar = new ConectarBDD();
            string valor;
            string Cadena = "select Anio_Correspondiente anio from Poas_Creados where Id_PoAnual = " + x.ToString() + ";";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            valor = Datos.Tables[0].Rows[0]["anio"].ToString();
            return valor;
        }        
    }
}