using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Admon_Permisos : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public Manipulacion_Usuarios mu = new Manipulacion_Usuarios();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();

        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 5).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            GridUsuariosSistema.NeedDataSource += new GridNeedDataSourceEventHandler(GridUsuariosSistema_NeedDataSource);
            GridUsuariosSistema.ItemCommand += new GridCommandEventHandler(Seleccionar_usuario);
            Opciones_del_Sistema.NeedDataSource += new EventHandler<TreeListNeedDataSourceEventArgs>(Opciones_del_Sistema_NeedDataSource);
            Opciones_del_Sistema.ItemCommand += new EventHandler<TreeListCommandEventArgs>(Opciones_del_Sistema_ItemCommand);
           
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VericarPermiso();
                Session["CodigoUsuario"] = 0;
                Session["CodigoPerfil"] = 0;
                LblUsuario.Text = "Usuario: No a Seleccionado un Usuario";
            }
        }       
        protected void LLenarGridUsu()
        {
            procesos.LlenarRadGrid(GridUsuariosSistema, mu.TextSQl(1));
        }
        protected void GridUsuariosSistema_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            LLenarGridUsu();
        }
        protected void Seleccionar_usuario(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                GridDataItem item = e.Item as GridDataItem;
                Session["CodigoUsuario"] = Convert.ToInt32(item.GetDataKeyValue("id_usuario").ToString());
                Session["CodigoPerfil"] = Convert.ToInt32(item.GetDataKeyValue("Id_Plantilla").ToString());
                LblUsuario.Text = "Usuario: " + item.GetDataKeyValue("Correo").ToString();
                Opciones_del_Sistema.Rebind();
            }
        }
        protected void TKGridusuario_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell = item["Estado"];
                if (cell.Text == "ACTIVADO")
                {
                    cell.ForeColor = Color.Blue;
                    DataRowView dr = item.DataItem as DataRowView;
                }
                else
                {
                    cell.ForeColor = Color.Red;
                    DataRowView dr = item.DataItem as DataRowView;
                }
            }
        }
        protected void GridMenuprincipal()
        {
            if ((int)Session["CodigoUsuario"] == 0)
            {
                procesos.LlenarTreeGrid(Opciones_del_Sistema, mu.TextSQl(2));
            }
            else
            {
                procesos.LlenarTreeGrid(Opciones_del_Sistema, "SELECT m.Id_Menu,m.Descripcion_Menu,m.Cod_Padre,ap.ActivarMenu AS IdEstado, " +
                                                 "CASE WHEN ap.ActivarMenu = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado " +
                                                 "FROM menus m INNER JOIN AsignacionesDePermisos ap ON m.Id_Menu = ap.Id_Menu " +
                                                 "AND M.Cod_Padre = AP.Cod_Padre WHERE ap.Id_Plantilla = " +
                                                 Session["CodigoPerfil"].ToString() + " AND AP.Id_Usuario = " + Session["CodigoUsuario"].ToString() +
                                                 " order by m.orden");
            }
        }
        protected void Opciones_del_Sistema_NeedDataSource(object sender, TreeListNeedDataSourceEventArgs e)
        {
            GridMenuprincipal();
        }
        protected void Opciones_ItemDataBound(object sender, TreeListItemDataBoundEventArgs e)
        {
            if (e.Item is TreeListDataItem)
            {
                TreeListDataItem item = e.Item as TreeListDataItem;
                if (item["Estado"].Text == "Activo")
                {
                    item["Estado"].ForeColor = Color.Green;
                    ImageButton imagenes = (ImageButton)item.FindControl("SelectButton");
                    imagenes.ImageUrl = "../Iconos/flechas_Arriba.png";
                    imagenes.ToolTip = "El Permiso para este usuario se encuentra Activado";
                }
                else
                {
                    item["Estado"].ForeColor = Color.Red;
                    ImageButton imagenes = (ImageButton)item.FindControl("SelectButton");
                    imagenes.ImageUrl = "../Iconos/flechas_Abajo.png";
                    imagenes.ToolTip = "El Permiso para este usuario se encuentra Inactivo";
                }
            }
        }
        protected int Estado_Perfil(Permisos p)
        {
            int Estado;
            Manipulacion_Usuarios mrs = new Manipulacion_Usuarios();
            string Sql = "SELECT ActivarMenu FROM AsignacionesDePermisos WHERE Id_Menu = " + p.CodigoMenu.ToString() + " AND Id_Plantilla =" + p.Perfil.ToString() +
                        " AND Id_Usuario = " + p.Codigo_Usuario.ToString();

            DataSet Respuesta = mrs.Extraer_Data(Sql);
            Estado = Convert.ToInt32(Respuesta.Tables[0].Rows[0]["ActivarMenu"].ToString());
            return Estado;
        }
        protected void Opciones_del_Sistema_ItemCommand(object sender, TreeListCommandEventArgs e)
        {
            int ActivoInactivo;
            Manipulacion_Usuarios Guardar = new Manipulacion_Usuarios();           
            Mensajes_Error_BDD erro = new Mensajes_Error_BDD();
            Permisos per = new Permisos();

            if (e.CommandName == "Select")
            {
                if ((int)Session["CodigoUsuario"] == 0)
                {
                    MensajePantalla("No a seleccionado al Usuario");
                }
                else
                {
                    TreeListDataItem item = e.Item as TreeListDataItem;                   
                    per.CodigoMenu = Convert.ToInt32(item.GetDataKeyValue("Id_Menu").ToString());
                    per.Perfil = (int)Session["CodigoPerfil"];
                    per.Codigo_Usuario = (int)Session["CodigoUsuario"];
                    per.Codigo_Usuario_Modifica = Convert.ToInt32(Session["Usuario"].ToString());

                    if (Estado_Perfil(per) == 1)
                    {
                        ActivoInactivo = 2;
                    }
                    else
                    {
                        ActivoInactivo = 1;
                    }
                    per.Opcion = ActivoInactivo;
                    if (Guardar.Activar_DesactivarRol(per, ref erro))
                    {
                        Opciones_del_Sistema.Rebind();
                        if (per.Codigo_Usuario == per.Codigo_Usuario_Modifica)
                        {
                            Response.Redirect("Admon_Permisos.aspx");
                        }
                    }
                    else
                    {
                        MensajePantalla(erro.Descripcion.ToString());
                    }
                }
            }
        }
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 330, 180, "Alerta", null);
                return;
            }
        }
    }
}