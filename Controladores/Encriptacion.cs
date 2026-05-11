using System;
using System.Security.Cryptography;
using System.Text;

namespace PlanificacionPOA.Controladores
{
    public class Encriptacion
    {
        public string key = "LameCulosDeM";
        public string Codificar(string Password)
        {
            try
            {
                byte[] keyArray;
                byte[] Arreglo_a_Cifrar = Encoding.UTF8.GetBytes(Password);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                byte[] ArrayResultado = cTransform.TransformFinalBlock(Arreglo_a_Cifrar, 0, Arreglo_a_Cifrar.Length);

                tdes.Clear();
                Password = Convert.ToBase64String(ArrayResultado, 0, ArrayResultado.Length);
            }
            catch (Exception) { }
            return Password;
        }
        public string Descodificar(string Password)
        {
            try
            {
                byte[] keyArray;
                byte[] Array_a_Descifrar = Convert.FromBase64String(Password);

                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();

                TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);

                tdes.Clear();
                Password = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception) { }

            return Password;
        }
        public string GenerarPass()
        {
            int longitud = 10;
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");

            return token.Substring(0, longitud);
        }
        public string GeneraUsuario()
        {
            Guid miGuid = Guid.NewGuid();
            string token = Convert.ToBase64String(miGuid.ToByteArray());
            token = token.Replace("=", "").Replace("+", "");

            return token;
        }        
    }
}