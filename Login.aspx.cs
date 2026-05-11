using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;

namespace PlanificacionPOA
{
    public partial class Login : System.Web.UI.Page
    {
        Entrada_Sistema Control = new Entrada_Sistema();
        protected void Limpiar_Objetos()
        {
            Usuario.Text = string.Empty;
            Password.Text = string.Empty;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            btnAceptar.Click += btnAceptar_Click;
            lkbOlvide.Click += lkbOlvide_Click;

            if (!Page.IsPostBack)
            {
                Limpiar_Objetos();
            }
        }
        protected void Cargar_UsuarioData(Extraer_Usuario eu)
        {
            UsuarioValida us = new UsuarioValida()
            {
                id_usuario = Convert.ToInt32(eu.id_usuario),
                Id_Tipoperfil = Convert.ToInt32(eu.Id_Tipoperfil),
                id_region = Convert.ToInt32(eu.id_region),
                id_subregion = Convert.ToInt32(eu.id_subregion),
                DescripcionPerfil = eu.DescripcionPerfil
            };

            Session["DataUser"] = us;
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Validar_Data t;
            Ingreso_Usuario u = new Ingreso_Usuario();
            Extraer_Usuario Datos;
            
            Mensajes_Error_BDD es = new Mensajes_Error_BDD()
            {
                Numero = 0,
                Descripcion = string.Empty
            };

            u.Usuario = Usuario.Text;
            u.Password = Password.Text.Trim(new char[] { ' ', ';' });
            u.Opcion = 0;
            t = Control.ValidacionEntrada(u);

            if (t.Verificar == true)
            {
                MensajeDeAlerta(t.Mensaje);
            }
            else
            {
                if (Control.Verificar_Usuario(u, ref es))
                {
                    Datos = Control.Data_Usuario(u);
                    if (Datos.ErrorCodigo == 1)
                    {
                        Session["Usuario"] = Datos.id_usuario;
                        Session["perfil"] = Datos.Id_Tipoperfil;
                        Session["UsuarioNombre"] = Datos.nombreusuario;
                        Session["CodigoRegion"] = Datos.id_region;
                        Session["CodigoSubregion"] = Datos.id_subregion;
                        Session["DescripcionPerfil"] = Datos.DescripcionPerfil;
                        
                        Cargar_UsuarioData(Datos);

                        if (Datos.Cambios == 0)
                        {
                            Limpiar_Objetos();
                            Control.Quitar_Intentos(u.Usuario);
                            Response.Redirect("~/Cambio_Password.aspx");
                        }
                        else
                        {
                            Control.Guardar_Inicio_Sesion(Usuario.Text, Convert.ToInt32(Session["Usuario"]));
                            Response.Redirect("~/Paginas/Portada.aspx");
                        }
                    }
                    else
                    {
                        Limpiar_Objetos();
                        MensajeDeAlerta(Datos.Descripcion);
                    }
                }
                else
                {
                    Limpiar_Objetos();
                    MensajeDeAlerta(es.Descripcion.ToString());
                }
            }
        }
        protected void lkbOlvide_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Resetear_Password.aspx");
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