using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace PlanificacionPOA
{
    public partial class Resetear_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;

            if (!Page.IsPostBack)
            {
                Usuario.Text = string.Empty;
                mensaje.Visible = false;
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {            
            Envio_Correos Correos = new Envio_Correos();
            Entrada_Sistema Guardar = new Entrada_Sistema();
            Encriptacion Convertir = new Encriptacion();
            Usuario_del_Sistema c = new Usuario_del_Sistema();
            Extraer_Usuario u;
            Mensajes_Error_BDD es = new Mensajes_Error_BDD();
            Correo_Data data = new Correo_Data();
            Validacion v = new Validacion();

            es.Numero = 0;
            es.Descripcion = string.Empty;
            c.Usuario = Usuario.Text.Trim(new char[] { ' ', ';' });

            if (c.Usuario != string.Empty)
            {
                SqlCommand iComandos = new SqlCommand();

                u = Guardar.Data_U(c.Usuario);
                c.Estado = Convert.ToInt32(u.Cambios);
                c.Id = Convert.ToInt32(u.id_usuario);
                if (u.ErrorCodigo == 1)
                {
                    if (u.Cambios != 1)
                    {
                        Usuario.Text = string.Empty;
                        MensajeDeAlerta("Este Usuario esta desactivado del sistema");
                    }
                    else
                    {
                        if (v.Verifica_Correo(c.Usuario))
                        {
                            c.Password = Convertir.GenerarPass();
                            c.Opcion = 3;
                            if (Guardar.Reset_Contrasenia(c, ref es))
                            {
                                data.Destinatario = c.Usuario;
                                data.Sistema = "Sistema de Planificación POA de INAB";
                                data.Tipo = "RESET";
                                data.Password = c.Password;
                                if (Correos.Enviar_Correo(data))
                                {
                                    Usuario.Text = string.Empty;
                                    mensaje.Visible = true;
                                    btnAceptar.Visible = false;
                                    btnCancelar.Text = "Regresar al Login";
                                }
                                else
                                {
                                    MensajeDeAlerta("No se pudo enviar el correo intente de nuevo");
                                }
                            }
                            else
                            {
                                MensajeDeAlerta(es.Descripcion.ToString());
                            }
                            Usuario.Text = string.Empty;
                        }
                        else
                        {
                            Usuario.Text = string.Empty;
                            MensajeDeAlerta("Error: esa direccion de correo es invalida revisar");
                        }
                    }
                }
                else
                {
                    Usuario.Text = string.Empty;
                    MensajeDeAlerta(u.Descripcion);
                }
            }
            else
            {
                Usuario.Text = string.Empty;
                MensajeDeAlerta("Debe de ingresar su usuario que es el correo..");
            }
        }
        void MensajeDeAlerta(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWMensaje.RadAlert(Mensaje, 330, 180, "Alerta", null);
            }
        }
    }
}