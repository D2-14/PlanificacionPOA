using Newtonsoft.Json;
using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos.ModelosApi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Xml;

namespace PlanificacionPOA.Controladores
{
    public class ManejarApi
    {
        public XmlDocument Incentivos(EnvioDatosApi DatosEnvio, int Tipo)
        {
            IncetivosForestalesINAB Dat;
            List<ClaseOne> Lista = new List<ClaseOne>();
            HttpClient Cliente = new HttpClient();
            string Direccion = string.Empty;

            if (Tipo == 1)
            {
                Direccion = "Reporte_Probosque_Aprobados";
                DatosEnvio.Username = "IncentivosForestalProbosque";
                DatosEnvio.Password = "ABDdxTwRI7UnBvTy1SJgnxYNh1CQ4qxyB8vysBBbOy4=";
            }
            if (Tipo == 2)
            {
                Direccion = "Reporte_Probosque_Certificados";
                DatosEnvio.Username = "IncentivosForestalProbosque";
                DatosEnvio.Password = "ABDdxTwRI7UnBvTy1SJgnxYNh1CQ4qxyB8vysBBbOy4=";
            }
            if (Tipo == 3)
            {
                Direccion = "Reporte_PINPEP_Aprobados";
                DatosEnvio.Username = "IncentivosForestal";
                DatosEnvio.Password = "ABDdxTwRI7UnBvTy1SJgn3o16UhYBmw/HgE2VxmyV/g=";
            }
            if (Tipo == 4)
            {
                Direccion = "Reporte_PINPEP_Certificados";
                DatosEnvio.Username = "IncentivosForestal";
                DatosEnvio.Password = "ABDdxTwRI7UnBvTy1SJgn3o16UhYBmw/HgE2VxmyV/g=";
            }
            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync(Direccion, DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<IncetivosForestalesINAB>(Resultado);
                Lista = Dat.Listado;
            }           
            return DetalleXMLIncentivos(Lista);
        }       
        public XmlDocument DetalleXMLIncentivos(List<ClaseOne> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("Resolucion", G.Resolucion, ElementoDetalle);
                    x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                    x.AgregarAtributo("IdModalidad", G.IdModalidad, ElementoDetalle);
                    x.AgregarAtributo("Modalidad", G.Modalidad, ElementoDetalle);
                    x.AgregarAtributo("Area", G.Area, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument RegistroNacionalForestal(EnvioDatosApi DatosEnvio)
        {
            RegistroNacional Dat;
            List<ClaseTwo> Lista = new List<ClaseTwo>();
            HttpClient Cliente = new HttpClient();

            DatosEnvio.Username = "RegistroForestal";
            DatosEnvio.Password = "xbNyD6qq2DCxO2zZDPnCHunfDYXtZ4aRUbz+QUTbg8po6EtxsWKhuB1Odu6apaY0";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Registro", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<RegistroNacional>(Resultado);
                Lista = Dat.Listado;
            }
            return DetalleXMLRegistroForestal(Lista);
        }
        public XmlDocument DetalleXMLRegistroForestal(List<ClaseTwo> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("Id_Region", G.Id_Region, ElementoDetalle);
                    x.AgregarAtributo("subregionId", G.subregionId, ElementoDetalle);
                    x.AgregarAtributo("DepartamentoId", G.DepartamentoId, ElementoDetalle);
                    x.AgregarAtributo("MunicipioId", G.MunicipioId, ElementoDetalle);
                    x.AgregarAtributo("TipoRegistroId", G.TipoRegistroId, ElementoDetalle);
                    x.AgregarAtributo("TipoRegistro", G.TipoRegistro, ElementoDetalle);
                    x.AgregarAtributo("No_Registro", G.No_Registro, ElementoDetalle);
                    x.AgregarAtributo("NoExpediente", G.NoExpediente, ElementoDetalle);
                    x.AgregarAtributo("Id_Estado", G.Id_Estado, ElementoDetalle);//1 incripcion 2 actualizacion
                    x.AgregarAtributo("Fecha", G.Fecha, ElementoDetalle);
                    x.AgregarAtributo("IdDivisionProducto", G.IdDivisionProducto, ElementoDetalle);
    
                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument ObligacionesForestales(EnvioDatosApi DatosEnvio)
        {
            Obligaciones Dat;
            List<ClaseThree> Lista = new List<ClaseThree>();
            HttpClient Cliente = new HttpClient();
            
            DatosEnvio.Username = "MonitoreoForestal";
            DatosEnvio.Password = "iTbHCnuLfb1w4qEePAseN1MoIqKLdKC2qae+XexVMq+PVXp13JbsZEjZb3hztK0i";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Monitoreo", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<Obligaciones>(Resultado);
                Lista = Dat.Listado;
            }            
            return DetalleXMLObligacionesForestal(Lista);
        }
        public XmlDocument DetalleXMLObligacionesForestal(List<ClaseThree> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("IdTipoGarantia", G.IdTipoGarantia, ElementoDetalle);
                    x.AgregarAtributo("Tipo_Garantia", G.Tipo_Garantia, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("Resolucion", G.Resolucion, ElementoDetalle);
                    x.AgregarAtributo("Informe", G.Informe, ElementoDetalle);
                    x.AgregarAtributo("Area", G.Area, ElementoDetalle);
                    x.AgregarAtributo("Observaciones", G.Observaciones, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument LicenciasForestal(EnvioDatosApi DatosEnvio)
        {
            LicenciasForestales Dat;
            List<ClaseFour> Lista = new List<ClaseFour>();
            HttpClient Cliente = new HttpClient();
           
            DatosEnvio.Username = "ManejoForestal";
            DatosEnvio.Password = "nWTqiFUA6l8P0pt6b2f7lAqpEZlxJIY7W79TxDSHagk=";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Manejo_Licencia", DatosEnvio, new JsonMediaTypeFormatter()).Result;
            

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<LicenciasForestales>(Resultado);
                Lista = Dat.Listado;
            }            
            return DetalleXMLLinceciasForestales(Lista);
        }
        public XmlDocument DetalleXMLLinceciasForestales(List<ClaseFour> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("IdtipoLicencia", G.IdtipoLicencia, ElementoDetalle);
                    x.AgregarAtributo("Tipolicencia", G.Tipolicencia, ElementoDetalle);
                    x.AgregarAtributo("ResolucionAprobacion", G.ResolucionAprobacion, ElementoDetalle);
                    x.AgregarAtributo("FechaAprobacion", G.FechaAprobacion, ElementoDetalle);
                    x.AgregarAtributo("Titular", G.Titular, ElementoDetalle);
                    x.AgregarAtributo("NoPoas", G.NoPoas, ElementoDetalle);
                    x.AgregarAtributo("AreaAprobada", G.AreaAprobada, ElementoDetalle);
                    x.AgregarAtributo("volumenAprobado", G.volumenAprobado, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument ExentoForestal(EnvioDatosApi DatosEnvio)
        {
            ExentosForestales Dat;
            List<ClaseFive> Lista = new List<ClaseFive>();
            HttpClient Cliente = new HttpClient();
            
            DatosEnvio.Username = "ExentosForestal";
            DatosEnvio.Password = "Y/mr0wDjousIV3bywVUqQcZFBMGO5PGfi2i0I999qWk=";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Exentos", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<ExentosForestales>(Resultado);
                Lista = Dat.Listado;
            }            
            return DetalleXMLExcentosForestales(Lista);
        }
        public XmlDocument DetalleXMLExcentosForestales(List<ClaseFive> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("IdActividadPOA", G.IdActividadPOA, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("Resolucion", G.Resolucion, ElementoDetalle);
                    x.AgregarAtributo("FechaResolucion", G.FechaResolucion, ElementoDetalle);
                    x.AgregarAtributo("Titular", string.Empty, ElementoDetalle);
                    x.AgregarAtributo("SexoTitular", string.Empty, ElementoDetalle);
                    x.AgregarAtributo("Volumen", G.Volumen, ElementoDetalle);
                    x.AgregarAtributo("Area", G.Area, ElementoDetalle);
                    x.AgregarAtributo("NoRNF", G.NoRNF, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument PlanesOperativos(EnvioDatosApi DatosEnvio)
        {
            PlanesdeManejo Dat;
            List<ClaseSix> Lista = new List<ClaseSix>();
            HttpClient Cliente = new HttpClient();
      
            DatosEnvio.Username = "ManejoForestal";
            DatosEnvio.Password = "nWTqiFUA6l8P0pt6b2f7lAqpEZlxJIY7W79TxDSHagk=";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Manejo_Planes_Operativos", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<PlanesdeManejo>(Resultado);
                Lista = Dat.Listado;
            }            
            return DetalleXMLPlanesOperativos(Lista);
        }
        public XmlDocument DetalleXMLPlanesOperativos(List<ClaseSix> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("ResolucionPOA", G.ResolucionPOA, ElementoDetalle);
                    x.AgregarAtributo("ResolucionAprobacion", G.ResolucionAprobacion, ElementoDetalle);
                    x.AgregarAtributo("FechaAprobacion", G.FechaAprobacion, ElementoDetalle);
                    x.AgregarAtributo("Titular", G.Titular, ElementoDetalle);
                    x.AgregarAtributo("Area", G.Area, ElementoDetalle);
                    x.AgregarAtributo("volumen", G.volumen, ElementoDetalle);
                    x.AgregarAtributo("IdTipoLicencia", G.IdTipoLicencia, ElementoDetalle);
                    x.AgregarAtributo("TipoLicencia", G.TipoLicencia, ElementoDetalle);
                    x.AgregarAtributo("IdTipoBosque", G.IdTipoBosque, ElementoDetalle);
                    x.AgregarAtributo("TipoBosque", G.TipoBosque, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public XmlDocument ModificacionPOA(EnvioDatosApi DatosEnvio)
        {
            ModificacionesPoa Dat;
            List<ClaseSeven> Lista = new List<ClaseSeven>();
            HttpClient Cliente = new HttpClient();

            DatosEnvio.Username = "ManejoForestal";
            DatosEnvio.Password = "nWTqiFUA6l8P0pt6b2f7lAqpEZlxJIY7W79TxDSHagk=";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_Manejo_ModificacionesPOAS", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<ModificacionesPoa>(Resultado);
                Lista = Dat.Listado;
            }            
            return DetalleXMLModificacionPOA(Lista);
        }
        public XmlDocument DetalleXMLModificacionPOA(List<ClaseSeven> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("Expediente", G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("CodigoPOA", G.CodigoPOA, ElementoDetalle);
                    x.AgregarAtributo("FechaAprobacion", G.FechaAprobacion, ElementoDetalle);
                    x.AgregarAtributo("Titular", G.Titular, ElementoDetalle);
                    x.AgregarAtributo("Area", G.Area, ElementoDetalle);
                    x.AgregarAtributo("volumen", G.volumen, ElementoDetalle);
                    x.AgregarAtributo("AmpliacionTiempo", G.AmpliacionTiempo, ElementoDetalle);

                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        public ResultadoConsumoFamiliar CosumoFamiliar(EnvioDatosApi DatosEnvio)
        {
            ConsumoFamiliar Dat;
            ResultadoConsumoFamiliar Resp = new ResultadoConsumoFamiliar(); 
            List<Consumo> LAprobado = new List<Consumo>();
            List<Consumo> LDenegado = new List<Consumo>();
            HttpClient Cliente = new HttpClient();

            DatosEnvio.Username = "ConsumoFamiliar";
            DatosEnvio.Password = "Y/mr0wDjousIV3bywVUqQcZFBMGO5PGfi2i0I999qWk=";

            Cliente.BaseAddress = new Uri(System.Configuration.ConfigurationManager.AppSettings["ApiRestFullSistemas"]);
            var Respuesta = Cliente.PostAsync("Reporte_ConsumoFamiliar", DatosEnvio, new JsonMediaTypeFormatter()).Result;

            if (Respuesta.IsSuccessStatusCode)
            {
                var Resultado = Respuesta.Content.ReadAsStringAsync().Result;
                Dat = JsonConvert.DeserializeObject<ConsumoFamiliar>(Resultado);
                LAprobado = Dat.Aprobado;
                LDenegado = Dat.Denegado;                
            }
            Resp.Aprobado = DetalleXMLConsumoFamiliar(LAprobado);
            Resp.Denegado = DetalleXMLConsumoFamiliar(LDenegado);
            return Resp;
        }
        public XmlDocument DetalleXMLConsumoFamiliar(List<Consumo> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            if (p != null)
            {
                foreach (var G in p)
                {
                    XmlNode ElementoDetalle = Detalle.CreateElement("Lista");
                    x.AgregarAtributo("No", G.No, ElementoDetalle);
                    x.AgregarAtributo("IdRegion", G.IdRegion, ElementoDetalle);
                    x.AgregarAtributo("Region", G.Region, ElementoDetalle);
                    x.AgregarAtributo("IdSubregion", G.IdSubregion, ElementoDetalle);
                    x.AgregarAtributo("Subregion", G.Subregion, ElementoDetalle);
                    x.AgregarAtributo("IdDepartamento", G.IdDepartamento, ElementoDetalle);
                    x.AgregarAtributo("Departamento", G.Departamento, ElementoDetalle);
                    x.AgregarAtributo("IdMunicipio", G.IdMunicipio, ElementoDetalle);
                    x.AgregarAtributo("Municipio", G.Municipio, ElementoDetalle);
                    x.AgregarAtributo("DictamenTecnico", G.DictamenTecnico == null ? "" : G.DictamenTecnico, ElementoDetalle);
                    x.AgregarAtributo("ConsumoId",G.ConsumoId, ElementoDetalle);
                    x.AgregarAtributo("NombreCientifico",G.NombreCientifico == null ? "" : G.NombreCientifico, ElementoDetalle); ;
                    x.AgregarAtributo("CodigoMirasil",G.CodigoMirasil == null ? "" : G.CodigoMirasil, ElementoDetalle);
                    x.AgregarAtributo("Troza",G.Troza, ElementoDetalle);
                    x.AgregarAtributo("Lenia",G.Lenia, ElementoDetalle);
                    x.AgregarAtributo("Volumen",G.Volumen, ElementoDetalle);
                    x.AgregarAtributo("TotalDeArboles",G.TotalDeArboles, ElementoDetalle);
                    x.AgregarAtributo("Expediente",G.Expediente, ElementoDetalle);
                    x.AgregarAtributo("Resolucion",G.Resolucion == null ? "" : G.Resolucion, ElementoDetalle);
                    x.AgregarAtributo("FechaAprobacion",G.FechaAprobacion, ElementoDetalle);
                    x.AgregarAtributo("Municipal", G.Municipal, ElementoDetalle);
                    Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
                }
            }
            return Detalle;
        }
        /*Guardar en la base de datos*/
        /*incentivos*/
        public int VerificarAnio(int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            int Valor;
            string Cadena = "SELECT Anio_Correspondiente FROM Poas_Creados WHERE Id_PoAnual = " + id;
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");
            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                Valor = Convert.ToInt32( Datos.Tables[0].Rows[0]["Anio_Correspondiente"].ToString());
            }
            else
            {
                Valor = 0;
            }

            return Valor;
        }        
    }
}