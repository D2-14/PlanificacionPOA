using PlanificacionPOA.ConexionBDD;
using System;

namespace PlanificacionPOA
{
    public partial class Cerrar_Session_Sistema : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            ConectarBDD ManejoBDD = new ConectarBDD();
            ManejoBDD.EjecutarCodigo("UPDATE RegistroSesion SET FechaFinal=GETDATE(), Activa = 0 WHERE Activa = 1 AND id_usuario=" + Session["Usuario"] + ";");
            Session.Clear();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}