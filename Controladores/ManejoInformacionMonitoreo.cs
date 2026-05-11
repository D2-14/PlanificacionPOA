using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;
using Telerik.Web.UI;

namespace PlanificacionPOA.Controladores
{
    public class ManejoInformacionMonitoreo
    {
        public int ValorDeOpcion(int Opcion, int Valor1, int Valor2)
        {
            int Resultado;
            if (Opcion == 3)
            {
                Resultado = Valor1;
            }
            else
            {
                Resultado = Valor2;
            }

            return Resultado;
        }
        public int ValorDelMes(RadComboBox Combo, int Mes)
        {
            ConectarBDD procesos = new ConectarBDD();
            int Id_Mes;
            if (procesos.IntNULLCombo(Combo) == 0)
            {
                Id_Mes = Mes;
            }
            else
            {
                Id_Mes = procesos.IntNULLCombo(Combo);
            }

            return Id_Mes;
        }
        public bool Validad_Fechas_ValidasCF(string fecha1, string fecha2)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta = false;
            string Cadena = "SELECT dbo.fn_VerificarFechas2('" + fecha1 + "','" + fecha2 + "') AS Dato";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["Dato"].ToString());
                if (Valor == 1)
                {
                    Respuesta = false;
                }
                if (Valor == 2)
                {
                    Respuesta = true;
                }
            }
            else
            {
                Respuesta = false;
            }

            return Respuesta;
        }
        public bool Validad_Fechas_ValidasNacionales(int MesIngreso, string FechaIngresada, int Id_PoaAnual)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta = false;
            string Cadena = "SELECT dbo.fn_VerificarFechasNacionales(" + MesIngreso + ",'" + FechaIngresada + "','" + Id_PoaAnual + "') AS Dato";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["Dato"].ToString());
                if (Valor == 1)
                {
                    Respuesta = true;
                }
                if (Valor == 2)
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
        public bool Validad_Fechas_Validas(int MesIngreso, string FechaIngresada, int Id_poaAnual)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta = false;
            string Cadena = "SELECT dbo.fn_VerificarFechas(" + MesIngreso + ",'" + FechaIngresada + "','" + Id_poaAnual + "') AS Dato";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["Dato"].ToString());
                if (Valor == 1)
                {
                    Respuesta = true;
                }
                if (Valor == 2)
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
        public bool Validad_IngresoMesMonitoreo(DatosMonitoreoIngresoMetas DMI)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta;
            string Cadena = "SELECT DBO.fn_VerificarIngresoMonitoreo (" + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                               + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + ") AS CantidadFilas";

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["CantidadFilas"].ToString());

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

        public bool Validad_Llenado_detalle(int Op, DatosMonitoreoIngresoMetas DMI)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            bool Respuesta;
            string Cadena = "Sp_Verificar_llenado_detalles_GridMonitoreo " + Op + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                               + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["CantidadFilas"].ToString());

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
        public decimal Validad_Llenado_detalleCantidadPRE(int Op, DatosMonitoreoIngresoMetas DMI, int Padre)
        {
            ConectarBDD Grabar = new ConectarBDD();
            decimal Valor;
            decimal Respuesta;
            string Cadena = "Sp_Verificar_detalles_Cantidad_GridMonitoreoPRE " + Op + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                               + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Padre;

            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToDecimal(Datos.Tables[0].Rows[0]["CantidadPersonas"].ToString());

                if (Valor != 0)
                {
                    Respuesta = Valor;
                }
                else
                {
                    Respuesta = 0;
                }
            }
            else
            {
                Respuesta = 0;
            }

            return Respuesta;
        }


        public int Validad_Llenado_detalleCantidad(int Op, DatosMonitoreoIngresoMetas DMI, int Padre)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            int Respuesta;
            string Cadena = "Sp_Verificar_detalles_Cantidad_GridMonitoreo " + Op + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                               + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Padre;


            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["CantidadPersonas"].ToString());

                if (Valor != 0)
                {
                    Respuesta = Valor;
                }
                else
                {
                    Respuesta = 0;
                }
            }
            else
            {
                Respuesta = 0;
            }

            return Respuesta;
        }
        public bool FinalizarIngresoDeObjetosNacionales(DatosMonitoreoIngresoMetas edm, int Corr, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, edm.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, edm.Id_Subregion);
            Grabar.AgregarParametro("@Id_Correlativo", SqlDbType.Int, Corr);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, edm.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, edm.Id_Mes);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_FinalizarIngresoObjetosNacionalMonitoreo", true)) != null)
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
        public bool FinalizarIngresoDeComponente(DatosMonitoreoIngresoMetas edm, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, edm.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, edm.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, edm.IdComponente);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, edm.Id_Usuario);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, edm.Id_Mes);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_FinalizarIngresoComponenteS", true)) != null)
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
        public string VerificarParticipante(int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            string Valor;
            string Cadena = "SELECT ISNULL(Descripcion,'') Descrbir FROM ValidarTipoParticipantes WHERE Estado = 1 AND Id_Participante = " + id;
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Datos.Tables[0].Rows[0]["Descrbir"].ToString();
            }
            else
            {
                Valor = string.Empty;
            }

            return Valor;
        }
        public bool VerificarProyeccionMetaSubregion(DatosTarea dt)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Dato;
            string Cadena = "SELECT Id_PoAnual FROM MetasSubregionProyeccion WHERE Aprobado = 1 " +
                            "AND Id_PoAnual = " + dt.Id_PoAnual + " AND Id_Subregion = " + dt.Id_SubRegion + ";";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Dato = true;
            }
            else
            {
                Dato = false;
            }
            return Dato;
        }
        public int Tipo_conteoNacional(int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            string Cadena = "SELECT dbo.fn_Tipo_de_ConteoNacional(" + id + ") AS id_conteo";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["id_conteo"].ToString());
            }
            else
            {
                Valor = 0;
            }
            return Valor;
        }
        public int Tipo_conteo(int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            string Cadena = "SELECT dbo.fn_Tipo_de_Conteo(" + id + ") AS id_conteo";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32(Datos.Tables[0].Rows[0]["id_conteo"].ToString());
            }
            else
            {
                Valor = 0;
            }
            return Valor;
        }
        /*finalizar ingreso*/
        public bool Finalizar_IngresoMonitoreo(DatosMonitoreoIngresoMetas x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_Subregion);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, x.Id_Mes);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_FinalizarIngresoMonitoreo", true)) != null)
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
        public bool Finalizar_IngresoMonitoreoNacional(DatosMonitoreoIngresoMetas x, ref Mensajes_Error_BDD e)
        {
            SqlCommand IComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, x.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Region", SqlDbType.Int, x.Id_Region);
            Grabar.AgregarParametro("@Id_SubRegion", SqlDbType.Int, x.Id_Subregion);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, x.Id_Mes);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, x.Id_Usuario);

            if ((IComandos = Grabar.ExecuteNonQuery("Sp_FinalizarIngresoMonitoreoNacional", true)) != null)
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
        /*Manejo de xml*/
        /*Encabezado*/
        public XmlDocument DetalleXMLProductoEncabezadoIncetivoForestal(EncabezadoIncentivosForestales pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoIncentivosForestales> p = new List<EncabezadoIncentivosForestales>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NumeroExpediente", G.NumeroExpediente, ElementoDetalle);
                x.AgregarAtributo("Area", G.Area, ElementoDetalle);
                x.AgregarAtributo("Id_TipoIncentivo", G.Id_TipoIncentivo, ElementoDetalle);
                x.AgregarAtributo("Id_Incentivo", G.Id_Incentivo, ElementoDetalle);
                x.AgregarAtributo("Id_fase", G.Id_fase, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoIndustriayComercio(EncabezadoIndustriaComercio pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoIndustriaComercio> p = new List<EncabezadoIndustriaComercio>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_Tema", G.Id_Tema, ElementoDetalle);
                x.AgregarAtributo("Tema_Especifico", G.Tema_Especifico, ElementoDetalle);
                x.AgregarAtributo("Id_TipoRegistro", G.Id_TipoRegistro, ElementoDetalle);
                x.AgregarAtributo("NumeroRegistro", G.NumeroRegistro, ElementoDetalle);
                x.AgregarAtributo("Id_TipoOrganizacion", G.Id_TipoOrganizacion, ElementoDetalle);
                x.AgregarAtributo("Tema_Organizacion", G.Tema_Organizacion, ElementoDetalle);
                x.AgregarAtributo("Id_TipoEmpresa", G.Id_TipoEmpresa, ElementoDetalle);
                x.AgregarAtributo("Tema_Empresa", G.Tema_Empresa, ElementoDetalle);
                x.AgregarAtributo("Producto_Recomendado", G.Producto_Recomendado, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoProteccionForestal(EncabezadoProteccionForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoProteccionForestal> p = new List<EncabezadoProteccionForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("AgenteCausal", G.AgenteCausal, ElementoDetalle);
                x.AgregarAtributo("NombreTitular", G.NombreTitular, ElementoDetalle);
                x.AgregarAtributo("Hectarias", G.Hectarias, ElementoDetalle);
                x.AgregarAtributo("CoordenadaX", G.CoordenadaX, ElementoDetalle);
                x.AgregarAtributo("CoordenadaY", G.CoordenadaY, ElementoDetalle);
                x.AgregarAtributo("NombreContacto", G.NombreContacto, ElementoDetalle);
                x.AgregarAtributo("NumeroTelefono", G.NumeroTelefono, ElementoDetalle);
                x.AgregarAtributo("Id_EquipoProteccion", G.Id_EquipoProteccion, ElementoDetalle);
                x.AgregarAtributo("Id_tipoAreaBM", G.Id_tipoAreaBM, ElementoDetalle);
                x.AgregarAtributo("Id_AreaBM", G.Id_AreaBM, ElementoDetalle);
                x.AgregarAtributo("Id_fase", G.Id_fase, ElementoDetalle);
                x.AgregarAtributo("Id_TipoEscenario", G.Id_TipoEscenario, ElementoDetalle);
                x.AgregarAtributo("NumeroMuestra", G.NumeroMuestra, ElementoDetalle);
                x.AgregarAtributo("Id_Tipo_Bosque", G.Id_Tipo_Bosque, ElementoDetalle);
                x.AgregarAtributo("Id_Tipo_Incendio", G.Id_Tipo_Incendio, ElementoDetalle);
                x.AgregarAtributo("Id_Tipo_Administracion", G.Id_Tipo_Administracion, ElementoDetalle);
                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoProgramaRE(EncabezadoProgramaReduccionEmision pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoProgramaReduccionEmision> p = new List<EncabezadoProgramaReduccionEmision>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NoResolucion", G.NoResolucion, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("FechaResolucion", G.FechaResolucion, ElementoDetalle);
                x.AgregarAtributo("Id_TipoProyecto", G.Id_TipoProyecto, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoCulturaForestal(EncabezadoCulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoCulturaForestal> p = new List<EncabezadoCulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NombreEvento", G.NombreEvento, ElementoDetalle);
                x.AgregarAtributo("Id_TipoEvento", G.Id_TipoEvento, ElementoDetalle);
                x.AgregarAtributo("Id_Campania", G.Id_Campania, ElementoDetalle);
                x.AgregarAtributo("TemaONombreEntidad", G.TemaONombreEntidad, ElementoDetalle);
                x.AgregarAtributo("MediosParticipantes", G.MediosParticipantes, ElementoDetalle);
                x.AgregarAtributo("NombredelMaterial", G.NombredelMaterial, ElementoDetalle);
                x.AgregarAtributo("NombreMediosComunicacion", G.NombreMediosComunicacion, ElementoDetalle);
                x.AgregarAtributo("TemaAbordado", G.TemaAbordado, ElementoDetalle);
                x.AgregarAtributo("Id_TemaAtendido", G.Id_TemaAtendido, ElementoDetalle);
                x.AgregarAtributo("PeriodoPublicidadInicio", G.PeriodoPublicidadInicio, ElementoDetalle);
                x.AgregarAtributo("PeriodoPublicidadFinal", G.PeriodoPublicidadFinal, ElementoDetalle);
                x.AgregarAtributo("Id_TipoApoyo", G.Id_TipoApoyo, ElementoDetalle);
                x.AgregarAtributo("NombreEntidad", G.NombreEntidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoPPMF(EncabezadoPPMF pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoPPMF> p = new List<EncabezadoPPMF>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_TipoBosque", G.Id_TipoBosque, ElementoDetalle);
                x.AgregarAtributo("CoordenadaX", G.CoordenadaX, ElementoDetalle);
                x.AgregarAtributo("CoordenadaY", G.CoordenadaY, ElementoDetalle);
                x.AgregarAtributo("FechaPlantacion", G.FechaPlantacion, ElementoDetalle);
                x.AgregarAtributo("NoMedicion", G.NoMedicion, ElementoDetalle);
                x.AgregarAtributo("FechaPPM", G.FechaPPM, ElementoDetalle);
                x.AgregarAtributo("NombreSitio", G.NombreSitio, ElementoDetalle);
                x.AgregarAtributo("NoExperimento", G.NoExperimento, ElementoDetalle);
                x.AgregarAtributo("NoParcela", G.NoParcela, ElementoDetalle);
                x.AgregarAtributo("Replanteo", G.Replanteo, ElementoDetalle);
                x.AgregarAtributo("UnidadMuestreo", G.UnidadMuestreo, ElementoDetalle);
                x.AgregarAtributo("CodigoProyecto", G.CodigoProyecto, ElementoDetalle);
                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoPinabete(EncabezadoPinabete pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoPinabete> p = new List<EncabezadoPinabete>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_TipoArea", G.Id_TipoArea, ElementoDetalle);
                x.AgregarAtributo("NoRegistro", G.NoRegistro, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("Survey", G.Survey, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoMangle(EncabezadoMangle pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoMangle> p = new List<EncabezadoMangle>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Survey", G.Survey, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezado(EncabezadoMonitoreoIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoMonitoreoIngreso> p = new List<EncabezadoMonitoreoIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_Evento", G.Id_Evento, ElementoDetalle);
                x.AgregarAtributo("Survey", G.Survey, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*Componente Capacitacion*/
        public XmlDocument DetalleXMLProductoCapacitacionD1(CapacitacionDatos1 pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<CapacitacionDatos1> p = new List<CapacitacionDatos1>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Evento", G.Id_Evento, ElementoDetalle);
                x.AgregarAtributo("Id_Participante", G.Id_Participante, ElementoDetalle);
                x.AgregarAtributo("Id_Tipoparticipante", G.Id_Tipoparticipante, ElementoDetalle);
                x.AgregarAtributo("Id_Comunidad", G.Id_Comunidad, ElementoDetalle);
                x.AgregarAtributo("NumeroPersonaComunidad", G.NumeroPersonaComunidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCapacitacionD2(CapacitacionDatos2 pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<CapacitacionDatos2> p = new List<CapacitacionDatos2>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Genero", G.Id_Genero, ElementoDetalle);
                x.AgregarAtributo("Id_pertenencia", G.Id_pertenencia, ElementoDetalle);
                x.AgregarAtributo("Id_GrupoEtario", G.Id_GrupoEtario, ElementoDetalle);
                x.AgregarAtributo("NumeroPersonaEtario", G.NumeroPersonaEtario, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*Fiscalizacion*/
        public XmlDocument DetalleXMLProductoFicalizacion(EncabezadoFiscalizacionIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoFiscalizacionIngreso> p = new List<EncabezadoFiscalizacionIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_TipoDeRegistro", G.Id_TipoDeRegistro, ElementoDetalle);
                x.AgregarAtributo("NumeroDeRegistro", G.NumeroDeRegistro, ElementoDetalle);
                x.AgregarAtributo("ErroresAnomalias", G.ErroresAnomalias, ElementoDetalle);
                x.AgregarAtributo("Id_ReactivaSeinef", G.Id_ReactivaSeinef, ElementoDetalle);
                x.AgregarAtributo("Id_TipoDeActa", G.Id_TipoDeActa, ElementoDetalle);
                x.AgregarAtributo("Tipo_Producto", G.Tipo_Producto, ElementoDetalle);
                x.AgregarAtributo("Id_Especie", G.Id_Especie, ElementoDetalle);
                x.AgregarAtributo("Id_Pais", G.Id_Pais, ElementoDetalle);
                x.AgregarAtributo("Id_Estado", G.Id_Estado, ElementoDetalle);
                x.AgregarAtributo("Id_TipoAccion", G.Id_TipoAccion, ElementoDetalle);
                x.AgregarAtributo("Id_TipoIncumplimiento", G.Id_TipoIncumplimiento, ElementoDetalle);
                x.AgregarAtributo("Id_TipoCobertura", G.Id_TipoCobertura, ElementoDetalle);
                x.AgregarAtributo("Id_ExistenciaCobertura", G.Id_ExistenciaCobertura, ElementoDetalle);
                x.AgregarAtributo("NombreEmpresa", G.NombreEmpresa, ElementoDetalle);
                x.AgregarAtributo("RegistroExim", G.RegistroExim, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoFiscalizacionDatos1(FiscalizacionDatos1 pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<FiscalizacionDatos1> p = new List<FiscalizacionDatos1>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Maquinaria", G.Maquinaria, ElementoDetalle);
                x.AgregarAtributo("Id_Especie", G.Id_Especie, ElementoDetalle);
                x.AgregarAtributo("PorcentajeMaderaAserrada", G.PorcentajeMaderaAserrada, ElementoDetalle);
                x.AgregarAtributo("PorcentajeLepa", G.PorcentajeLepa, ElementoDetalle);
                x.AgregarAtributo("PorcentajeAserrio", G.PorcentajeAserrio, ElementoDetalle);
                x.AgregarAtributo("PorcentajeOtro", G.PorcentajeOtro, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoFiscalizacionDatos2(FiscalizacionDatos2 pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<FiscalizacionDatos2> p = new List<FiscalizacionDatos2>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Comunidad", G.Id_Comunidad, ElementoDetalle);
                x.AgregarAtributo("NumeroPersonas", G.NumeroPersonas, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*Fortalecimiento*/
        public XmlDocument DetalleXMLProductoFortalecimiento(EncabezadoFortalecimiento pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoFortalecimiento> p = new List<EncabezadoFortalecimiento>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_Puesto_Actvidad", G.Id_Puesto_Actvidad, ElementoDetalle);
                x.AgregarAtributo("NombreActor", G.NombreActor, ElementoDetalle);
                x.AgregarAtributo("TemaAtendido", G.TemaAtendido, ElementoDetalle);
                x.AgregarAtributo("AccionesSeguimiento", G.AccionesSeguimiento, ElementoDetalle);
                x.AgregarAtributo("ComunidadOrganizacion", G.ComunidadOrganizacion, ElementoDetalle);
                x.AgregarAtributo("UbicacionOrganizacion", G.UbicacionOrganizacion, ElementoDetalle);
                x.AgregarAtributo("NombreDocumento", G.NombreDocumento, ElementoDetalle);
                x.AgregarAtributo("AnioVigenciaPolitica", G.AnioVigenciaPolitica, ElementoDetalle);
                x.AgregarAtributo("TipoActor", G.TipoActor, ElementoDetalle);
                x.AgregarAtributo("Actores", G.Actores, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoProgramaRE(DetallePRE pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<DetallePRE> p = new List<DetallePRE>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Modalidad", G.Id_Modalidad, ElementoDetalle);
                x.AgregarAtributo("Area", G.Area, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal7(Detalle7CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle7CulturaForestal> p = new List<Detalle7CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Campania", G.Id_Campania, ElementoDetalle);
                x.AgregarAtributo("Cantidad", G.Cantidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal8(Detalle8CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle8CulturaForestal> p = new List<Detalle8CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_TipoNota", G.Id_TipoNota, ElementoDetalle);
                x.AgregarAtributo("Id_Nota", G.Id_Nota, ElementoDetalle);
                x.AgregarAtributo("Cantidad", G.Cantidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal6(Detalle6CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle6CulturaForestal> p = new List<Detalle6CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_TipoMaterial", G.Id_TipoMaterial, ElementoDetalle);
                x.AgregarAtributo("Id_Material", G.Id_Material, ElementoDetalle);
                x.AgregarAtributo("Cantidad", G.Cantidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal5(Detalle5CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle5CulturaForestal> p = new List<Detalle5CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Publico", G.Id_Publico, ElementoDetalle);
                x.AgregarAtributo("Cantidad", G.Cantidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal4(Detalle4CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle4CulturaForestal> p = new List<Detalle4CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_TipoPublicidad", G.Id_TipoPublicidad, ElementoDetalle);
                x.AgregarAtributo("Cantidad", G.Cantidad, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoRNF(EncabezadoRNF pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoRNF> p = new List<EncabezadoRNF>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NoRegistro", G.NoRegistro, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("TipoRegistroId", G.TipoRegistroId, ElementoDetalle);
                x.AgregarAtributo("IdDivisionProducto", G.IdDivisionProducto, ElementoDetalle);
                x.AgregarAtributo("TipoRegistro", G.TipoRegistro, ElementoDetalle);
                x.AgregarAtributo("IdEstadoRNF", G.IdEstadoRNF, ElementoDetalle);
                x.AgregarAtributo("CategoriaRNF", G.CategoriaRNF, ElementoDetalle);
                x.AgregarAtributo("SubcategoriaRNF", G.SubcategoriaRNF, ElementoDetalle);
                x.AgregarAtributo("Especificaciones", G.Especificaciones, ElementoDetalle);
                x.AgregarAtributo("IdTipoDenegacion", G.IdTipoDenegacion, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoLicencia(EncabezadoLicenciaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoLicenciaForestal> p = new List<EncabezadoLicenciaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("NoResolucionInformePOATrimestral", G.NoResolucionInformePOATrimestral, ElementoDetalle);
                x.AgregarAtributo("Id_TipoDeModificacion", G.Id_TipoDeModificacion, ElementoDetalle);
                x.AgregarAtributo("Id_TipoLicencia", G.Id_TipoLicencia, ElementoDetalle);
                x.AgregarAtributo("Id_TipoDeBosque", G.Id_TipoDeBosque, ElementoDetalle);
                x.AgregarAtributo("NoLicencia", G.NoLicencia, ElementoDetalle);
                x.AgregarAtributo("Hectarias", G.Hectarias, ElementoDetalle);
                x.AgregarAtributo("Titular", G.Titular, ElementoDetalle);
                x.AgregarAtributo("NoTelefono", G.NoTelefono, ElementoDetalle);
                x.AgregarAtributo("CoordenadaX", G.CoordenadaX, ElementoDetalle);
                x.AgregarAtributo("CoordenadaY", G.CoordenadaY, ElementoDetalle);
                x.AgregarAtributo("Especie", G.Especie, ElementoDetalle);
                x.AgregarAtributo("Elaborador", G.Elaborador, ElementoDetalle);
                x.AgregarAtributo("NoTelefonoElabora", G.NoTelefonoElabora, ElementoDetalle);
                x.AgregarAtributo("Id_Tratamiento", G.Id_Tratamiento, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCosumoFamiliar(EncabezadoConsumoFamiliarIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoConsumoFamiliarIngreso> p = new List<EncabezadoConsumoFamiliarIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                x.AgregarAtributo("Resolucion", G.Resolucion, ElementoDetalle);
                x.AgregarAtributo("DictamenTecnico", G.DictamenTecnico, ElementoDetalle);
                x.AgregarAtributo("NombreCientifico", G.NombreCientifico, ElementoDetalle);
                x.AgregarAtributo("CodigoMirasil", G.CodigoMirasil, ElementoDetalle);
                x.AgregarAtributo("Troza", G.Troza, ElementoDetalle);
                x.AgregarAtributo("Lenia", G.Lenia, ElementoDetalle);
                x.AgregarAtributo("TotalDeArboles", G.TotalDeArboles, ElementoDetalle);
                x.AgregarAtributo("Municipal", G.Municipal, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoCulturaForestal3(Detalle3CulturaForestal pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Detalle3CulturaForestal> p = new List<Detalle3CulturaForestal>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Notas", G.Id_Notas, ElementoDetalle);
                x.AgregarAtributo("NumeroNotas", G.NumeroNotas, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoFortalecimiento1(Fortalecimiento1 pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<Fortalecimiento1> p = new List<Fortalecimiento1>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("CorrelativoPadre", G.CorrelativoPadre, ElementoDetalle);
                x.AgregarAtributo("CorrelativoHijo", G.CorrelativoHijo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_Comunidad", G.Id_Comunidad, ElementoDetalle);
                x.AgregarAtributo("NumeroPersonas", G.NumeroPersonas, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*PINPEP*/
        public XmlDocument DetalleXMLProductoPinpep(EncabezadoPINPEPIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoPINPEPIngreso> p = new List<EncabezadoPINPEPIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_Modalidad", G.Id_Modalidad, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("ResolucionInforme", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("Tipo_Componente", G.Tipo_SubComponente, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoExentosForestales(EncabezadoExentosIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoExentosIngreso> p = new List<EncabezadoExentosIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);//Hectarias
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);//Volumen
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("NoResolucion", G.NoResolucion, ElementoDetalle);
                x.AgregarAtributo("NoRegistro", G.NoRegistro, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*Probosque*/
        public XmlDocument DetalleXMLProductoProbosque(EncabezadoProbosqueIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoProbosqueIngreso> p = new List<EncabezadoProbosqueIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Id_Modalidad", G.Id_Modalidad, ElementoDetalle);
                x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("ResolucionInforme", G.NoExpediente, ElementoDetalle);
                x.AgregarAtributo("Tipo_SubComponente", G.Tipo_SubComponente, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*obligaciones Forestales*/
        public XmlDocument DetalleXMLProductoMonitoreoForestal(EncabezadoMonitoreoIngreso pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoMonitoreoIngreso> p = new List<EncabezadoMonitoreoIngreso>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_Componente", G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_Subcomponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVerificable", G.Id_ProductoVerificable, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Id_Departamento", G.Id_Departamento, ElementoDetalle);
                x.AgregarAtributo("Id_Municipio", G.Id_Municipio, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);
                x.AgregarAtributo("Noexpediente", G.Noexpediente, ElementoDetalle);
                x.AgregarAtributo("Fase", G.Fase, ElementoDetalle);
                x.AgregarAtributo("NoInforme", G.NoInforme, ElementoDetalle);
                x.AgregarAtributo("NoResolucion", G.NoResolucion, ElementoDetalle);
                x.AgregarAtributo("Id_Especie", G.Id_Especie, ElementoDetalle);
                x.AgregarAtributo("Volumen", G.Volumen, ElementoDetalle);
                x.AgregarAtributo("CoordenadaX", G.CoordenadaX, ElementoDetalle);
                x.AgregarAtributo("CoordenadaY", G.CoordenadaY, ElementoDetalle);
                x.AgregarAtributo("Edad", G.Edad, ElementoDetalle);
                x.AgregarAtributo("Id_Garantia", G.Id_Garantia, ElementoDetalle);
                x.AgregarAtributo("Estado", G.Estado, ElementoDetalle);
                x.AgregarAtributo("Estatus", G.Estatus, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        public XmlDocument DetalleXMLProductoEncabezadoNacional(EncabezadoNacionalGeneral pr)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");
            List<EncabezadoNacionalGeneral> p = new List<EncabezadoNacionalGeneral>();

            p.Add(pr);

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Correlativo", G.Correlativo, ElementoDetalle);
                x.AgregarAtributo("Id_PoAnual", G.Id_PoAnual, ElementoDetalle);
                x.AgregarAtributo("Tipo", G.Tipo, ElementoDetalle);
                x.AgregarAtributo("Correlativo_Configuracion", G.Correlativo_Configuracion, ElementoDetalle);
                x.AgregarAtributo("Id_Producto", G.Id_Producto, ElementoDetalle);
                x.AgregarAtributo("Id_SubProducto", G.Id_SubProducto, ElementoDetalle);
                x.AgregarAtributo("Id_Actividad", G.Id_Actividad, ElementoDetalle);
                x.AgregarAtributo("Id_Subregion", G.Id_Subregion, ElementoDetalle);
                x.AgregarAtributo("Id_Mes", G.Id_Mes, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("ValorUM1", G.ValorUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("ValorUM2", G.ValorUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("ValorUM3", G.ValorUM3, ElementoDetalle);
                x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("Id_usu", G.Id_usu, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        }
        /*Manejo de Documentos*/
        public bool VerificarPDF(RadAsyncUpload ObjetoSubirArchivo)
        {
            ArchivosParaCarga DA = new ArchivosParaCarga();
            bool valor;
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
                }
            }
            valor = DA.Existe;
            return valor;
        }
        public Medios SubirPDFNacional(DatosMonitoreoIngresoMetas DMI, int Correlativo, RadAsyncUpload ObjetoSubirArchivo, string FechaHora)
        {
            Medios DA = new Medios();
            string Carpetas;
            Crear_Carpeta_Sistema("Medios_VerificacionNacional\\", DMI.NombrePOA);
            Crear_Carpeta_Sistema("Medios_VerificacionNacional\\" + DMI.NombrePOA + "\\", DMI.Id_Subregion.ToString());
            Crear_Carpeta_Sistema("Medios_VerificacionNacional\\" + DMI.NombrePOA + "\\" + DMI.Id_Subregion.ToString() + "\\", Correlativo.ToString());
            Carpetas = "Medios_VerificacionNacional\\" + DMI.NombrePOA + "\\" + DMI.Id_Subregion.ToString() + "\\" + Correlativo.ToString() + "\\";
            foreach (UploadedFile f in ObjetoSubirArchivo.UploadedFiles)
            {
                DA.Medio_Subir = AppDomain.CurrentDomain.BaseDirectory + Carpetas + f.GetName().Replace(".", $"{FechaHora}.");
                //DA.Medio_Subir = AppDomain.CurrentDomain.BaseDirectory + Carpetas + f.GetName();
                DA.Medio_Local = Carpetas + f.GetName();

                

        
                DA.Medio_Local= DA.Medio_Local.Replace(".", $"{FechaHora}.");
                
              
               

             
                



            }
            return DA;
        }
        public Medios SubirPDF(DatosMonitoreoIngresoMetas DMI, RadAsyncUpload ObjetoSubirArchivo,string FechaHora=null)
        {
            Medios DA = new Medios();
            string Carpetas;
            Crear_Carpeta_Sistema("Medios_Verificacion\\", DMI.NombrePOA);
            Crear_Carpeta_Sistema("Medios_Verificacion\\"+ DMI.NombrePOA +"\\", DMI.Id_Subregion.ToString());
            Crear_Carpeta_Sistema("Medios_Verificacion\\" + DMI.NombrePOA + "\\" + DMI.Id_Subregion.ToString() + "\\", DMI.IdComponente.ToString());
            Carpetas = "Medios_Verificacion\\" + DMI.NombrePOA + "\\" + DMI.Id_Subregion.ToString() + "\\"+ DMI.IdComponente.ToString() + "\\";
            foreach (UploadedFile f in ObjetoSubirArchivo.UploadedFiles)
            {                                
                DA.Medio_Subir = AppDomain.CurrentDomain.BaseDirectory + Carpetas + f.GetName().Replace(".", $"{FechaHora}.");                
                DA.Medio_Local = Carpetas + f.GetName();

                if(!string.IsNullOrEmpty(FechaHora))
                {

                    DA.Medio_Local = DA.Medio_Local.Replace(".", $"{FechaHora}.");
                }

            }
            return DA;
        }
        public void Crear_Carpeta_Sistema(string Direccion, string NombreCarpeta)
        {
            Mensajes_Error_BDD Respuesta = new Mensajes_Error_BDD();
            string Path = AppDomain.CurrentDomain.BaseDirectory + Direccion + NombreCarpeta;
            bool Revisar = Directory.Exists(Path);

            if (Revisar == false)
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Direccion + NombreCarpeta);                
            }            
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
        public bool Eliminar_MedioVerificacionFisico(string DireccionArchivo)
        {
            bool Respuesta;
            string Directorio = AppDomain.CurrentDomain.BaseDirectory + DireccionArchivo;
            
            if (ExisteArchivo_en_Sistema(Directorio) == true) 
            {
                File.SetAttributes(Directorio, FileAttributes.Normal);
                File.Delete(Directorio);
            }
            if (ExisteArchivo_en_Sistema(Directorio) == false)
            {
                Respuesta = false;
            }
            else
            {
                Respuesta = true;
            }
            return Respuesta;
        }

        /*Grabar informacion en las tablas de la base de datos*/
        public string CadenaComboDeptoMuni(string D1, string D2, int Op)
        {
            string Cadena = "";
            if (Op == 1)
            {
                Cadena = "SELECT DISTINCT D.Id_Departamento Id,D.Departamento Descripcion FROM Departamento D INNER JOIN Municipio_Subregion MS " +
                               "ON D.Id_Departamento = MS.Id_Departamento WHERE MS.Id_Subregion = " + D2;
            }
            if (Op == 2)
            {
                Cadena = "SELECT DISTINCT m.Id_Municipio Id, m.Municipio Descripcion FROM Municipio m " +
                               "INNER JOIN Municipio_Subregion MS ON m.Id_Municipio = MS.Id_Municipio " +
                               "WHERE m.Id_Departamento = " + D1 + " AND MS.Id_Subregion = " + D2;
            }
            return Cadena;
        }
        public bool GuardarItemEncabezadoApi(int Op, DatosMonitoreoIngresoMetas Generico, XmlDocument DescripcionDAta, XmlDocument DescripcionDAtaAPI, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Generico.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Generico.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, Generico.IdComponente);
            Grabar.AgregarParametro("@Id_usu", SqlDbType.Int, Generico.Id_Usuario);
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);
            Grabar.AgregarParametro("@InformacionAPI", SqlDbType.Xml, DescripcionDAtaAPI.OuterXml);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productosVerificablesMonitoreoEncabezadoAPI", true)) != null)
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
        public bool GuardarItemEncabezadoNacional(DatosMonitoreoIngresoMetas Generico,int Corr,XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();            
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Generico.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Generico.Id_Subregion);
            Grabar.AgregarParametro("@Id_Correlativo", SqlDbType.Int, Corr);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, Generico.Id_Mes);
            Grabar.AgregarParametro("@Id_usu", SqlDbType.Int, Generico.Id_Usuario);
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productoSAMonitoreoNacional", true)) != null)
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
        public bool GuardarItemEncabezado(int Op, DatosMonitoreoIngresoMetas Generico,XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Generico.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Generico.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, Generico.IdComponente);
            Grabar.AgregarParametro("@Id_usu", SqlDbType.Int, Generico.Id_Usuario);
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);
            Grabar.AgregarParametro("@Id_Subcomponente", SqlDbType.Int, Generico.Id_SubComponente);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productosVerificablesMonitoreoEncabezado", true)) != null)
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
        public bool Eliminacion_ProductoNacional(EliminacionDatoMonitoreo edm, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
           
            Grabar.AgregarParametro("@Correlativo", SqlDbType.Int, edm.Correlativo);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, edm.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, edm.Id_Subregion);           
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, edm.Id_Mes);
            Grabar.AgregarParametro("@Id_usu", SqlDbType.Int, edm.Id_usu);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productosNacionalesMonitoreo", true)) != null)
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
        /**/
        public bool AgregarEliminar_ProductoPoa(int Op, MonitoreoObjetos Mo, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int,Mo.Id_Poa);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int,Mo.Id_Subregion);
            Grabar.AgregarParametro("@Correlativo", SqlDbType.Int, Mo.Correlativo);            
            Grabar.AgregarParametro("@Id_Producto", SqlDbType.Int, Mo.Id_Producto);
            Grabar.AgregarParametro("@Id_SubProducto", SqlDbType.Int,Mo.Id_SubProducto);
            Grabar.AgregarParametro("@Id_Actividad", SqlDbType.Int, Mo.Id_Actividad);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_AgregarEliminar_ProductoPoaNacionalPlani", true)) != null)
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
        /**/
        public bool Eliminacion_Producto(int Op,EliminacionDatoMonitoreo edm, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, Op);
            Grabar.AgregarParametro("@Correlativo", SqlDbType.Int, edm.Correlativo);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, edm.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, edm.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, edm.Id_Componente);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, edm.Id_Mes);
            Grabar.AgregarParametro("@Id_usu", SqlDbType.Int, edm.Id_usu);
           
            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_productosVerificablesMonitoreo", true)) != null)
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
        public bool GuardarItemDetalle(int op,DatosMonitoreoIngresoMetas Generico, XmlDocument DescripcionDAta, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Op", SqlDbType.Int, op);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Generico.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, Generico.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, Generico.IdComponente);          
            Grabar.AgregarParametro("@Informacion", SqlDbType.Xml, DescripcionDAta.OuterXml);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Guardar_productosVerificablesMonitoreoDetalle", true)) != null)
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
        public bool Eliminacion_DatosExtra(int op,EliminacionDatoMonitoreo edm, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@op", SqlDbType.Int, op);
            Grabar.AgregarParametro("@Correlativo", SqlDbType.Int, edm.Correlativo);
            Grabar.AgregarParametro("@Id_PoAnual", SqlDbType.Int, edm.Id_PoAnual);
            Grabar.AgregarParametro("@Id_Subregion", SqlDbType.Int, edm.Id_Subregion);
            Grabar.AgregarParametro("@Id_Componente", SqlDbType.Int, edm.Id_Componente);
            Grabar.AgregarParametro("@Id_Mes", SqlDbType.Int, edm.Id_Mes);           

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Eliminacion_MonitoreoDatosExtra", true)) != null)
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