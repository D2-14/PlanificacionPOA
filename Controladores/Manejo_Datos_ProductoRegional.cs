using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace PlanificacionPOA.Controladores
{
    public class Manejo_Datos_ProductoRegional
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<ProductoRegional> Obtener_Productos(int Id)
        {
            List<ProductoRegional> Registro = new List<ProductoRegional>();
            string Cadena = "EXEC Sp_obtener_data_Productos " + Id;
            DataSet Datos = procesos.obtenerDataSetCodigo(Cadena, "Tabla");

            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                foreach (DataRow f in Datos.Tables[0].Rows)
                {
                    ProductoRegional result = new ProductoRegional();
                    {
                        result.Id_Componente = Convert.ToInt32(f["Id_Componente"].ToString());
                        result.DescripcionComponente = f["DescripcionComponente"].ToString();
                        result.Id_SubComponente = Convert.ToInt32(f["Id_SubComponente"].ToString());
                        result.DescripcionSubComponente = f["DescripcionSubComponente"].ToString();
                        result.Id_ProductoVeficable = Convert.ToInt32(f["Id_ProductoVeficable"].ToString());
                        result.DescripcionProductoVeficable = f["DescripcionProductoVeficable"].ToString();
                        result.Id_MetasRedProgramatica = Convert.ToInt32(f["Id_MetasRedProgramatica"].ToString());
                        result.Id_NoPlanificable = Convert.ToInt32(f["Id_NoPlanificable"].ToString());
                        result.Id_UM1 = Convert.ToInt32(f["Id_UM1"].ToString());
                        result.DescripcionUM1 = f["DescripcionUM1"].ToString();
                        result.Id_UM2 = Convert.ToInt32(f["Id_UM2"].ToString());
                        result.DescripcionUM2 = f["DescripcionUM2"].ToString();
                        result.Id_UM3 = Convert.ToInt32(f["Id_UM3"].ToString());
                        result.DescripcionUM3 = f["DescripcionUM3"].ToString();
                        result.Id_UnidadMedida = Convert.ToInt32(f["Id_UnidadMedida"].ToString());
                        result.DescripcionUnidadMedida = f["DescripcionUnidadMedida"].ToString();
                        result.MedioDeVerificacion = f["MedioDeVerificacion"].ToString();
                        result.DireccionMedioVerificacion = f["DireccionMedioVerificacion"].ToString();
                    }
                    Registro.Add(result);                    
                }
            }                                   
            return Registro;
        }        
        public List<ProductoRegional> Agregar_ProductoLista(ProductoRegional pr)
        {
            List<ProductoRegional> Lpr = new List<ProductoRegional>();
            Lpr.Add(pr);

            return Lpr;
        }
        public XmlDocument DetalleXMLProducto(List<ProductoRegional> p)
        {
            XmlConverter x = new XmlConverter();
            XmlDocument Detalle = x.CrearDocumentoXML("Detalle");

            foreach (var G in p)
            {
                XmlNode ElementoDetalle = Detalle.CreateElement("Lista");

                x.AgregarAtributo("Id_Componente",G.Id_Componente, ElementoDetalle);
                x.AgregarAtributo("DescripcionComponente", G.DescripcionComponente, ElementoDetalle);
                x.AgregarAtributo("Id_SubComponente", G.Id_SubComponente, ElementoDetalle);
                x.AgregarAtributo("DescripcionSubComponente", G.DescripcionSubComponente, ElementoDetalle);
                x.AgregarAtributo("Id_ProductoVeficable", G.Id_ProductoVeficable, ElementoDetalle);
                x.AgregarAtributo("DescripcionProductoVeficable", G.DescripcionProductoVeficable, ElementoDetalle);
                x.AgregarAtributo("Id_MetasRedProgramatica", G.Id_MetasRedProgramatica, ElementoDetalle);
                x.AgregarAtributo("Id_NoPlanificable", G.Id_NoPlanificable, ElementoDetalle);
                x.AgregarAtributo("Id_UM1", G.Id_UM1, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM1", G.DescripcionUM1, ElementoDetalle);
                x.AgregarAtributo("Id_UM2", G.Id_UM2, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM2", G.DescripcionUM2, ElementoDetalle);
                x.AgregarAtributo("Id_UM3", G.Id_UM3, ElementoDetalle);
                x.AgregarAtributo("DescripcionUM3", G.DescripcionUM3, ElementoDetalle);
                x.AgregarAtributo("Id_UnidadMedida", G.Id_UnidadMedida, ElementoDetalle);
                x.AgregarAtributo("DescripcionUnidadMedida", G.DescripcionUnidadMedida, ElementoDetalle);
                x.AgregarAtributo("MedioDeVerificacion", G.MedioDeVerificacion, ElementoDetalle);
                x.AgregarAtributo("DireccionMedioVerificacion", G.DireccionMedioVerificacion, ElementoDetalle);
                x.AgregarAtributo("CorrelativoC", G.CorrelativoC, ElementoDetalle);
                x.AgregarAtributo("CorrelativoSC", G.CorrelativoSC, ElementoDetalle);
                x.AgregarAtributo("CorrelativoPC", G.CorrelativoPC, ElementoDetalle);

                Detalle.ChildNodes[1].AppendChild(ElementoDetalle);
            }
            return Detalle;
        } 
        public bool Verficar_IngresoProducto(List<ProductoRegional> Informacion, DproductoEnvio Dx)
        {
            bool Result = false;
            DproductoEnvio d = new DproductoEnvio(); 

            if (Informacion.Count != 0)
            {
                var item = Informacion.Find(x => x.Id_Componente == Dx.Id_Componente && x.Id_SubComponente == Dx.Id_SubComponente && x.Id_ProductoVeficable == Dx.Id_ProductoVeficable);
                
                if (item == null)
                {
                    Result = false;
                }
                else
                {
                    Result = true;
                }
            }
            else
            {
                Result = false;
            }
            return Result;
        }
    }
}