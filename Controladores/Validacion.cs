using PlanificacionPOA.ConexionBDD;
using System;
using System.Data;
using System.Text.RegularExpressions;
using Telerik.Web.UI;

namespace PlanificacionPOA.Controladores
{
    public static class Extensions
    {
        private static readonly Regex regex = new Regex(@"\s+");
        public static string RemoveWhiteSpaces(this string str)
        {
            return regex.Replace(str, String.Empty);
        }
    }
    public class Validacion
    {
        public int intNoNull(Object Valor)
        {
            int iResultado;

            if (Valor != null)
            {
                bool isValid = int.TryParse(Valor.ToString(),out iResultado);

                if (isValid) return iResultado; else return 0;
            }
            else return 0;
        }
        public string StrNoNull(Object Valor)
        {
            if (Valor == null) return ""; else return Valor.ToString();
        }
        public decimal DecimalNoNull(Object Valor)
        {
            if (Valor == null)
                return 0;
            else
            {
                if (System.DBNull.Value.Equals(Valor))
                    return 0;
                else
                {
                    if (Valor.ToString() == "")
                        return 0;
                    else
                        return decimal.Parse(Valor.ToString());
                }
            }
        }
        public bool Condicion(int valor)
        {
            if (valor == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int IntNULLCombo(RadComboBox obj)
        {
            int valor;
            if (obj.SelectedIndex == -1)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToInt32(obj.SelectedItem.Value);
            }
            return valor;
        }
        public string StrNULLCombo(RadComboBox obj)
        {
            string valor;
            if (obj.SelectedIndex == -1)
            {
                valor = string.Empty;
            }
            else
            {
                valor = obj.SelectedItem.Text;
            }
            return valor;
        }
        public string StrNULLText(RadTextBox obj)
        {
            string valor;
            if (obj.Text == string.Empty)
            {
                valor = string.Empty;
            }
            else
            {
                valor = obj.Text;
            }
            return valor;
        }
        public decimal decimalcombo(RadComboBox obj)
        {
            decimal valor;
            if (obj.SelectedIndex == -1)
            {
                valor = 0;
            }
            else
            {
                valor = Convert.ToDecimal(obj.SelectedItem.Text);
            }
            return valor;
        }
        public bool Verifica_Correo(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        public string Convertir_Cadena_Mayuscula(string Cadena) 
        {
            string Resultado;
            Resultado = Cadena.RemoveWhiteSpaces();

            return Resultado.ToUpper();
        }
        public bool BusquedaGRIDDato(RadGrid Informacion,string Campo,string Validar)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if(Convertir_Cadena_Mayuscula(Validar) == Convertir_Cadena_Mayuscula(item.GetDataKeyValue(Campo).ToString())) 
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }                    
                }
            }
            return Resultado;
        }
        public bool BusquedaGRIDDato2(RadGrid Informacion, string Campo,string Campo2,string Validar,int Validar2)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if ((Convertir_Cadena_Mayuscula(Validar) == Convertir_Cadena_Mayuscula(item.GetDataKeyValue(Campo).ToString())) && (Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString()) == Validar2))
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
            }
            return Resultado;
        }
        public bool BusquedaGRIDDato3IDs(RadGrid Informacion, string Campo, string Campo2, string Campo3, int Validar, int Validar2, int Validar3)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if ((Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString()) == Validar) && (Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString()) == Validar2) && (Convert.ToInt32(item.GetDataKeyValue(Campo3).ToString()) == Validar3))
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
            }
            return Resultado;
        }
        public bool BusquedaGRIDDato3(RadGrid Informacion, string Campo, string Campo2, string Campo3, string Validar, int Validar2, int Validar3)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if ((Convertir_Cadena_Mayuscula(Validar) == Convertir_Cadena_Mayuscula(item.GetDataKeyValue(Campo).ToString())) && (Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString()) == Validar2) && (Convert.ToInt32(item.GetDataKeyValue(Campo3).ToString()) == Validar3))
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
            }
            return Resultado;
        }
        public bool BusquedaGRIDDato4(RadGrid Informacion, string Campo, string Campo2, string Campo3, string Campo4, string Validar, int Validar2, int Validar3, int Validar4)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if ((Convertir_Cadena_Mayuscula(Validar) == Convertir_Cadena_Mayuscula(item.GetDataKeyValue(Campo).ToString())) && (Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString()) == Validar2)
                        && (Convert.ToInt32(item.GetDataKeyValue(Campo3).ToString()) == Validar3) && (Convert.ToInt32(item.GetDataKeyValue(Campo4).ToString()) == Validar4))
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
            }
            return Resultado;
        }
        public bool BusquedaGRIDDatoPOA(RadGrid Informacion, string Campo,string Campo2,int Validar,int Validar2)
        {
            bool Resultado = false;
            if (Informacion.Items.Count != 0)
            {
                foreach (GridDataItem item in Informacion.Items)
                {
                    if ((Validar == Convert.ToInt32(item.GetDataKeyValue(Campo).ToString())) && (Validar2 ==Convert.ToInt32(item.GetDataKeyValue(Campo2).ToString())))
                    {
                        Resultado = true;
                        break;
                    }
                    else
                    {
                        Resultado = false;
                    }
                }
            }
            return Resultado;
        }
        public DataSet VerificarBDD(string SQlString)
        {
            ConectarBDD Data = new ConectarBDD();
            DataSet Respuesta = Data.obtenerDataSetCodigo(SQlString, "tabla");
            return Respuesta;
        }
        public int ComprobarAño(int Valor) 
        {
            string slqstring = "select Year(GETDATE()) AnioEnCurso;";
            DataSet Verifica = VerificarBDD(slqstring);
            int AnioCurso = Convert.ToInt32(Verifica.Tables[0].Rows[0]["AnioEnCurso"].ToString());
            int Anio1Adelante = AnioCurso + 1;
            int Resultado = 0;

            if(Valor < AnioCurso) 
            {
                Resultado = 1;/* el año es menor que el año en curso*/
            }
            else if (Valor > Anio1Adelante)
            {
                Resultado = 2;/* el año es mayor que el año en curso*/
            }

            return Resultado;
        }
        public int VerificarTipoUnidadMedida(string Cadena)
        {            
            int idTipoUnidad = 0;            
            string slqstringCadena = "SELECT ISNULL(idTipoUnidad,0) Numero FROM Tipo_UnidadMedida WHERE DescripcionExtra = '";
            string slqstring = string.Empty;

            slqstring = slqstringCadena + Cadena.RemoveWhiteSpaces().ToLower() + "'";
            DataSet Verifica = VerificarBDD(slqstring);
            idTipoUnidad = Convert.ToInt32(Verifica.Tables[0].Rows[0]["Numero"].ToString());
            
            return idTipoUnidad;
        }
    }
}