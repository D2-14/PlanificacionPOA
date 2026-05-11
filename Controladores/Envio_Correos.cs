using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using PlanificacionPOA.Modelos;

namespace PlanificacionPOA.Controladores
{
    public class Envio_Correos
    {
        public static MailMessage msg;
        public static SmtpClient clienteSmt;
        public Boolean Verifica_Correo(String email)
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
        public Boolean Enviar_Correo(Correo_Data Data)
        {            
            string Correo_Emisor = System.Configuration.ConfigurationManager.AppSettings["Cuenta"];
            string Password = System.Configuration.ConfigurationManager.AppSettings["Clave"];

            msg = new MailMessage();
            MailAddress bcc;
            string Asunto_Envio = string.Empty;
            string correo = string.Empty;
            string Titulo = "Sistema de Planificación, Evaluación y Seguimiento Institucional";

            if (Data.Tipo == "RESET")
            {
                Asunto_Envio = "Envio de Nueva Contraseña del sistema de" + Data.Sistema;
                correo =
                    "<p align='justify'>" +
                    "Usted a Reseteado la contraseña del sistema de " + Data.Sistema + " por lo cual le ha sido enviada la nueva<br>" +
                    " contraseña. La Contraseña para ingresar al sistema es: <b>" + Data.Password + "</b>" +
                    "</p><br/><br/>https://sistemapoa.inab.gob.gt/Login";
            }
            if (Data.Tipo == "CREACION")
            {
                Asunto_Envio = "Envio Contraseña del sistema de " + Data.Sistema;
                correo =
                "<p align='justify'>" +
                "El Usuario del sistema es su correo electronico<br>" +
                " y La contraseña para ingresar al sistema " + Data.Sistema + "<br>" +
                " es: <b>" + Data.Password + "</b>" +
                "</p><br/><br/>https://sistemapoa.inab.gob.gt/Login";
            }
            //agregar correos ocultos
            bcc = new MailAddress(Data.Destinatario);
            msg.Bcc.Add(bcc);

            msg.From = new MailAddress(Correo_Emisor, Titulo, Encoding.UTF8);
            msg.Subject = Asunto_Envio;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;

            string html = correo + "<p align='center'> " + "<br><br><br><b>Unidad Tecnologías de la Información y Comunicación<b>Instituto Nacional de Bosques (INAB)<br>más Bosques más Vida" + "</b></p>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
            msg.AlternateViews.Add(htmlView);

            try
            {
                //cliente smtp de envio de correos
                clienteSmt = new SmtpClient();
                clienteSmt.Host = System.Configuration.ConfigurationManager.AppSettings["Salida"].ToString();
                clienteSmt.Port = 587;
                clienteSmt.EnableSsl = false;
                clienteSmt.UseDefaultCredentials = false;
                clienteSmt.Credentials = new NetworkCredential(Correo_Emisor, Password);

                clienteSmt.Send(msg);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                msg.Dispose();
                clienteSmt.Dispose();
                return false;
            }
            finally
            {
                msg.Dispose();
                clienteSmt.Dispose();
            }
        }
        public Boolean Enviar_Correo_Aprobado(Datos_AprobacionPoa Data)
        {
            string Correo_Emisor = System.Configuration.ConfigurationManager.AppSettings["Cuenta"];
            string Password = System.Configuration.ConfigurationManager.AppSettings["Clave"];

            msg = new MailMessage();
            MailAddress bcc;
            string Asunto_Envio;
            string correo;
            string Titulo = "Sistema de Planificación, Evaluación y Seguimiento Institucional";

            Asunto_Envio = "Notificación de Aprobacion de POA " + Data.NombrePoa;

            correo =
                   "<p align='justify'>" +
                   "El Plan Operativo Anual de "+ Data.DescripcionSubregion + " fue aprobado por el Jefe de Planificación<br>" + Data.Instrucciones + "</b>" +
                   "</p>";

            //agregar correos ocultos
            bcc = new MailAddress(Data.Destinatario);
            msg.Bcc.Add(bcc);

            msg.From = new MailAddress(Correo_Emisor, Titulo, Encoding.UTF8);
            msg.Subject = Asunto_Envio;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;

            string html = correo + "<p align='center'> " + "<br><br><br><b><b>Instituto Nacional de Bosques (INAB)<br>más Bosques más Vida" + "</b></p>";
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, Encoding.UTF8, MediaTypeNames.Text.Html);
            msg.AlternateViews.Add(htmlView);

            try
            {
                //cliente smtp de envio de correos
                clienteSmt = new SmtpClient();
                clienteSmt.Host = System.Configuration.ConfigurationManager.AppSettings["Salida"].ToString();
                clienteSmt.Port = 587;
                clienteSmt.EnableSsl = false;
                clienteSmt.UseDefaultCredentials = false;
                clienteSmt.Credentials = new NetworkCredential(Correo_Emisor, Password);

                clienteSmt.Send(msg);
                return true;
            }
            catch (SmtpFailedRecipientException)
            {
                msg.Dispose();
                clienteSmt.Dispose();
                return false;
            }
            finally
            {
                msg.Dispose();
                clienteSmt.Dispose();
            }
        }
    }
}