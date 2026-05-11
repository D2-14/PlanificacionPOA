using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Web.UI;

namespace PlanificacionPOA
{
    public partial class Cambio_Password : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                Limpiar_Objetos();
                mensaje.Visible = false;
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Entrada_Sistema sistemU = new Entrada_Sistema();
            Ingreso_Usuario u = new Ingreso_Usuario();
            u.Id = Convert.ToInt32(Session["Usuario"].ToString());
            Mensajes_Error_BDD es = new Mensajes_Error_BDD();
            es.Numero = 0;
            es.Descripcion = string.Empty;
            string pass1 = Password1.Text;
            string Confirma = Password2.Text;

            if ((pass1.Trim(new char[] { ' ', ';' }) == string.Empty) || (Confirma.Trim(new char[] { ' ', ';' }) == string.Empty))
            {
                Limpiar_Objetos();
                MensajeDeAlerta("Debe de llenar todos los campos");
            }
            else
            {
                if (pass1.Length < 10)
                {
                    MensajeDeAlerta("La contraseña debe ser mayor de 10 caracteres");
                }
                else
                {
                    if (pass1.ToString() != Confirma.ToString())
                    {
                        MensajeDeAlerta("No coinciden la contraseña con la confirmación de contraseña");
                    }
                    else
                    {
                        u.Password = pass1.Trim(new char[] { ' ', ';' });
                        if (sistemU.Cambio_Password(u, ref es))
                        {
                            Password1.Text = string.Empty;
                            Password2.Text = string.Empty;
                            mensaje.Visible = true;
                            btnAceptar.Visible = false;
                            btnCancelar.Text = "Regresar al Login";
                            cerrarSesion();
                        }
                        else
                        {
                            MensajeDeAlerta(es.Descripcion.ToString());
                        }
                    }
                }
            }
        }
        public void cerrarSesion()
        {
            Session.Clear();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login.aspx");
        }
        protected void Limpiar_Objetos()
        {
            Password1.Text = string.Empty;
            Password2.Text = string.Empty;
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