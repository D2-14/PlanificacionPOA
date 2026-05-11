using System.Xml;

namespace PlanificacionPOA.Controladores
{
    public class XmlConverter
    {
        public XmlDocument CrearDocumentoXML(string pNodoRaiz)
        {
            XmlDocument iResultado = new XmlDocument();

            XmlDeclaration iDeclaracion = iResultado.CreateXmlDeclaration("1.0", null, null);
            iResultado.AppendChild(iDeclaracion);

            XmlElement iRaiz = iResultado.CreateElement(pNodoRaiz);
            iResultado.AppendChild(iRaiz);

            return iResultado;
        }
        public XmlAttribute AgregarAtributo(string pEtiqueta, object pValor, XmlNode pContenedor)
        {
            XmlAttribute iResultado = pContenedor.OwnerDocument.CreateAttribute(pEtiqueta);
            iResultado.Value = pValor.ToString();
            pContenedor.Attributes.Append(iResultado);

            return iResultado;
        }
    }
}