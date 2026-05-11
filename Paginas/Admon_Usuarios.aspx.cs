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
    public partial class Admon_Usuarios : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        protected void GridDeUsuarios(int op)
        {
            if (op == 1)
            {
                procesos.LlenarRadGrid(GridUsuarioOtros, "SELECT u.id_usuario,CASE WHEN ISNULL(u.apellidos, '') = '' THEN " +
                                                      "u.nombres ELSE u.nombres + ', ' + u.apellidos END  AS Usuario,u.dpi, " +
                                                      "u.estado_usuario, CASE WHEN(u.estado_usuario = 1) THEN'ACTIVADO' " +
                                                      "ELSE 'DESACTIVADO' END AS Estado," +
                                                      "u.usuario as Correo,p.Descripcion perfil " +
                                                      "FROM usuarios u INNER JOIN plantillas p ON u.Id_Tipoperfil = p.Id_Plantilla ORDER BY Usuario");
            }
            if (op == 2)
            {
                procesos.LlenarRadGrid(GridUsuarioEdicion, "SELECT u.id_usuario,CASE WHEN ISNULL(u.apellidos, '') = '' THEN " +
                                                  "u.nombres ELSE u.nombres + ', ' + u.apellidos END  AS Usuario,u.dpi, " +
                                                  "u.estado_usuario, CASE WHEN(u.estado_usuario = 1) THEN'ACTIVADO' " +
                                                  "ELSE 'DESACTIVADO' END AS Estado," +
                                                  "u.usuario as Correo,p.Descripcion perfil " +
                                                  "FROM usuarios u INNER JOIN plantillas p ON u.Id_Tipoperfil =p.Id_Plantilla WHERE u.estado_usuario = 1 ORDER BY Usuario");
            }
        }
        protected void Subregion_Edicion(string data)
        {
            string strsub = "SELECT id_subregion id,Subregion FROM Subregion WHERE Id_Estado_Subregion = 1 AND id_region =" + data + " ORDER BY id;";
            procesos.LLenarComboASP(subregion, strsub, "subregion", "id", true);
        }
        protected void Inicializar(int op)
        {
            if (op == 1)
            {
                txtnombres.Text = string.Empty;
                txtapelllidos.Text = string.Empty;
                txtdpi.Text = string.Empty;
                txtusuario.Text = string.Empty;
                cbotipoPerfil.SelectedIndex = 0;
                cboRegion.SelectedIndex = 0;
                cbosubregion.SelectedIndex = 0;
                cboPuesto.SelectedIndex = 0;
            }
            if (op == 2)
            {
                nombre.Text = string.Empty;
                apellido.Text = string.Empty;
                txtdpi2.Text = string.Empty;
                usuario.Text = string.Empty;
                perfil.SelectedIndex = 0;
                puesto.SelectedIndex = 0;
                region.SelectedIndex = 0;
                subregion.SelectedIndex = 0;
            }
        }
        protected void fillcomboIngreso()
        {
            procesos.LLenarComboASP(cbotipoPerfil, "SELECT Id_Plantilla as id, Descripcion as PerfilNombre  FROM Plantillas WHERE Estado = 1  ORDER BY Descripcion;", "PerfilNombre", "id", true);
            procesos.LLenarComboASP(cboRegion, "SELECT Id_Region id,Nombre_Region Region FROM Region WHERE Id_Estado_Region = 1  ORDER BY Nombre_Region", "Region", "id", true);
            procesos.LLenarComboASP(cboPuesto, "SELECT id_puesto id,Puesto FROM puesto WHERE Id_Estado_Puesto = 1 ORDER BY Puesto;", "Puesto", "id", true);
        }
        protected void llenarCombosedit()
        {
            procesos.LLenarComboASP(perfil, "SELECT Id_Plantilla as id, Descripcion as PerfilNombre  FROM Plantillas WHERE Estado = 1 ORDER BY Descripcion;", "PerfilNombre", "id", true);           
            procesos.LLenarComboASP(region, "SELECT Id_Region id,Nombre_Region Region FROM Region WHERE Id_Estado_Region = 1  ORDER BY Nombre_Region", "Region", "id", true);
            procesos.LLenarComboASP(puesto, "SELECT id_puesto id,Puesto FROM puesto WHERE Id_Estado_Puesto = 1 ORDER BY Puesto;", "Puesto", "id", true);
        }
        protected string SqlCadena(string Id) 
        {
            string CSQL = "SELECT id_subregion id,Subregion FROM Subregion WHERE Id_Estado_Subregion = 1 AND Codigo_SubRegion >=1 AND id_region =" + Id +
                          " UNION "+
                          "SELECT id_subregion id,Subregion FROM Subregion WHERE Id_Estado_Subregion = 1 AND id_region =" + Id +
                          " ORDER BY Subregion;";
            return CSQL;
        }
        protected void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {           
            procesos.LLenarComboASP(cbosubregion,SqlCadena(cboRegion.SelectedItem.Value), "Subregion", "id", true);
        }       
        protected void cboRegion_Edicion_SelectedIndexChanged(object sender, EventArgs e)
        {            
            procesos.LLenarComboASP(subregion, SqlCadena(region.SelectedItem.Value), "subregion", "id", true);
        }
        protected void Cancelar_Click(object sender, EventArgs e)
        {
            Inicializar(1);
        }
        protected void Cancelar_Edicion_Click(object sender, EventArgs e)
        {
            Inicializar(2);
            CloseWinwdows(Edicion_Usuario, "Key");
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 4).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Agregar.Click += new EventHandler(Agregar_Click);
            Guardar.Click += new EventHandler(Guardar_Click);
            Cancelar.Click += new EventHandler(Cancelar_Click);
            Cancelar_Edicion.Click += new EventHandler(Cancelar_Edicion_Click);
            cboRegion.SelectedIndexChanged += new EventHandler(cboRegion_SelectedIndexChanged);
            region.SelectedIndexChanged += new EventHandler(cboRegion_Edicion_SelectedIndexChanged);           
            GridUsuarioOtros.NeedDataSource += new GridNeedDataSourceEventHandler(GridUsuarioOtros_NeedDataSource);
            GridUsuarioOtros.ItemDataBound += GridUsuarioOtros_ItemDataBound;
            GridUsuarioOtros.ItemCommand += new GridCommandEventHandler(Seleccionar_usuario);
            GridUsuarioEdicion.NeedDataSource += new GridNeedDataSourceEventHandler(GridUsuarioEdicion_NeedDataSource);
            GridUsuarioEdicion.ItemCommand += new GridCommandEventHandler(Seleccionar_usuario_Edicion);
            GridUsuarioEdicion.ItemDataBound += GridUsuarioEdicion_ItemDataBound;

            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VericarPermiso();
                fillcomboIngreso();
                llenarCombosedit();
            }
        }
        protected void GridUsuarioOtros_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridDeUsuarios(1);
        }
        protected void GridUsuarioOtros_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                if (Convert.ToInt32(item.GetDataKeyValue("estado_usuario").ToString()) == 0)
                {        
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/On.png";
                }
            }
        }
        protected void Seleccionar_usuario(object sender, GridCommandEventArgs e)
        {
            int CodigoUsuario;
            int EstadoUsuario;
            int Cambio_Estado;
            Manipulacion_Usuarios Guardar = new Manipulacion_Usuarios();
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            GridDataItem item = e.Item as GridDataItem;

            if (e.CommandName == "Select")
            {
                CodigoUsuario = Convert.ToInt32(item.GetDataKeyValue("id_usuario").ToString());
                EstadoUsuario = Convert.ToInt32(item.GetDataKeyValue("estado_usuario").ToString());

                if (EstadoUsuario == 0)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }

                if ((Convert.ToInt32(Session["Usuario"].ToString()) == CodigoUsuario) && (Cambio_Estado == 2))
                {
                    MensajePantalla("No Puede Desactivar el Usuario, es el mismo que esta utilizando");
                }
                else
                {
                    if (Guardar.Activacion_Desactivacion(CodigoUsuario, Cambio_Estado, ref Error))
                    {
                        GridUsuarioOtros.Rebind();
                        GridUsuarioEdicion.Rebind();
                    }
                    else
                    {
                        MensajePantalla(Error.Descripcion.ToString());
                    }
                }
            }
            if (e.CommandName == "Select2")
            {
                string correo;
                Correo_Data c = new Correo_Data();
                Envio_Correos Enviar = new Envio_Correos();
                Encriptacion Convertir = new Encriptacion();
                Usuario_del_Sistema iu = new Usuario_del_Sistema();
                Entrada_Sistema Ensi = new Entrada_Sistema();

                iu.Id = Convert.ToInt32(item.GetDataKeyValue("id_usuario").ToString());
                iu.Estado = Convert.ToInt32(item.GetDataKeyValue("estado_usuario").ToString());
                iu.Opcion = 3;
                iu.Password = Convertir.GenerarPass();
                correo = item.GetDataKeyValue("Correo").ToString();

                if (iu.Estado == 0)
                {
                    MensajePantalla("Este Usuario esta desactivado no se puede resetear la clave.......");
                }
                else
                {
                    if (Ensi.Reset_Contrasenia(iu, ref Error))
                    {
                        c.Destinatario = correo;
                        c.Sistema = "Sistema de Planificación (POA) de INAB";
                        c.Tipo = "RESET";
                        c.Password = iu.Password;

                        if (Enviar.Enviar_Correo(c))
                        {
                            GridUsuarioOtros.Rebind();
                            GridUsuarioEdicion.Rebind();
                            MensajePantalla("Se a Reseteado la contraseña, y se ha enviado un correo electronico con su nueva contraseña");
                        }
                        else
                        {
                            MensajePantalla("No se pudo enviar el correo");
                        }
                    }
                    else
                    {
                        MensajePantalla(Error.Descripcion.ToString());
                    }
                }
            }
        }
        protected void GridUsuarioEdicion_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            GridDeUsuarios(2);
        }
        protected void GridUsuarioEdicion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell = item["Estado"];
                if (cell.Text == "ACTIVADO")
                {
                    cell.ForeColor = Color.Blue;                   
                }
                else
                {
                    cell.ForeColor = Color.Red;                  
                }
            }
        }
        protected void Seleccionar_usuario_Edicion(object sender, GridCommandEventArgs e)
        {
            int CodigoUsuario;
            int estadoUsuario;

            if (e.CommandName == "Select")
            {
                GridDataItem item = e.Item as GridDataItem;
                CodigoUsuario = Convert.ToInt32(item.GetDataKeyValue("id_usuario").ToString());
                estadoUsuario = Convert.ToInt32(item.GetDataKeyValue("estado_usuario").ToString());
                Tusaurio.Text = CodigoUsuario.ToString();

                if (estadoUsuario == 0)
                {
                    MensajePantalla("Este Usuario esta desactivado no se puede Editar.......");
                }
                else
                {
                    try
                    {                       
                        procesos.AgregarParametro("@IdUsuario", SqlDbType.Int, CodigoUsuario);
                        DataSet DatosUsuario = procesos.Execute("Sp_Procesos_Obtener_data");
                        if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
                        {
                            nombre.Text = DatosUsuario.Tables[0].Rows[0]["nombres"].ToString();
                            apellido.Text = DatosUsuario.Tables[0].Rows[0]["apellidos"].ToString();
                            txtdpi2.Text = DatosUsuario.Tables[0].Rows[0]["DPI"].ToString();
                            usuario.Text = DatosUsuario.Tables[0].Rows[0]["Usuario"].ToString();
                            usuario.ReadOnly = true;
                            perfil.Text = DatosUsuario.Tables[0].Rows[0]["perfil"].ToString();
                            puesto.SelectedValue = DatosUsuario.Tables[0].Rows[0]["id_puesto"].ToString();
                            region.SelectedValue = DatosUsuario.Tables[0].Rows[0]["id_region"].ToString();
                            Subregion_Edicion(DatosUsuario.Tables[0].Rows[0]["id_region"].ToString());
                            subregion.SelectedValue = DatosUsuario.Tables[0].Rows[0]["id_subregion"].ToString();                            

                            OpenWinwdows(Edicion_Usuario, "900", "585", "Key", "Editar Usuario");
                        }
                        else
                        {
                            MensajePantalla("No se Encuentra informacion Disponible de lo que solicito");
                        }
                    }
                    catch (Exception) { }
                }
            }
        }
        protected void Agregar_Click(object sender, EventArgs e)
        {
            Usuario_Manipulacion u = new Usuario_Manipulacion();
            Manipulacion_Usuarios ui = new Manipulacion_Usuarios();
            Envio_Correos Revisar = new Envio_Correos();
            Validar_Data v;
            Correo_Data c = new Correo_Data();
            Encriptacion Convertir = new Encriptacion();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();

            string Pass_Ingreso_sistema = Convertir.GenerarPass();
            u.Nombres = txtnombres.Text;
            u.Apellidos = txtapelllidos.Text;
            u.DPI = txtdpi.Text;
            u.Usuario = txtusuario.Text;
            u.Tperfil = Convert.ToInt32(cbotipoPerfil.SelectedItem.Value);
            u.Puesto = Convert.ToInt32(cboPuesto.SelectedItem.Value);
            u.Region = Convert.ToInt32(cboRegion.SelectedItem.Value);
            u.Subregion = Valor_Subregion(u.Region, cbosubregion);
            u.Usuarioqcambio = Convert.ToInt32(Session["Usuario"].ToString());
            int Busqueda = u.Usuario.IndexOf("@inab.gob.gt");
            v = ui.Verificar_Vacios(u);

            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                if (Revisar.Verifica_Correo(u.Usuario))
                {
                    if (Busqueda != -1)
                    {
                        if (ui.Creacion_UsuariosSys(u, Pass_Ingreso_sistema, ref er))
                        {
                            Inicializar(1);
                            MensajePantalla("El Usuario fue Grabado Correctamente...");
                            GridUsuarioOtros.Rebind();
                            GridUsuarioEdicion.Rebind();
                            c.Destinatario = u.Usuario;
                            c.Sistema = "Sistema de Planificación (POA) de INAB";
                            c.Tipo = "CREACION";
                            c.Password = Pass_Ingreso_sistema;

                            if (Revisar.Enviar_Correo(c))
                            { }
                            else
                            {
                                MensajePantalla("No se pudo enviar el correo intente de nuevo");
                            }
                        }
                        else
                        {
                            Inicializar(1);
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                    else
                    {
                        MensajePantalla("No es un correo Institucional...");
                    }
                }
                else
                {
                    MensajePantalla("Error: esa direccion de correo es invalida revisar");
                }
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            Usuario_Manipulacion u = new Usuario_Manipulacion();
            Manipulacion_Usuarios ui = new Manipulacion_Usuarios();
            Envio_Correos Revisar = new Envio_Correos();
            Validar_Data v;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();

            u.Nombres = nombre.Text;
            u.Apellidos = apellido.Text;
            u.DPI = txtdpi2.Text;
            u.Usuario = usuario.Text;
            u.Tperfil = Convert.ToInt32(perfil.SelectedItem.Value);
            u.Puesto = Convert.ToInt32(puesto.SelectedItem.Value);
            u.Region = Convert.ToInt32(region.SelectedItem.Value);
            u.Subregion = Valor_Subregion(u.Region, subregion);
            u.Password = Tusaurio.Text;
            u.Usuarioqcambio = Convert.ToInt32(Session["Usuario"].ToString());
            int Busqueda = u.Usuario.IndexOf("@inab.gob.gt");
            v = ui.Verificar_Vacios(u);

            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                if (Revisar.Verifica_Correo(u.Usuario))
                {
                    if (Busqueda != -1)
                    {
                        if (ui.Edicion_UsuariosSys(u, ref er))
                        {
                            Inicializar(2);
                            MensajePantalla("El Usuario fue Editado Correctamente...");
                            GridUsuarioOtros.Rebind();
                            GridUsuarioEdicion.Rebind();
                            CloseWinwdows(Edicion_Usuario, "Key");
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                    else
                    {
                        MensajePantalla("No es un correo Institucional...");
                    }
                }
                else
                {
                    MensajePantalla("Error: esa direccion de correo es invalida revisar");
                }
            }
        }
        private int Valor_Subregion(int Codigo_Region, DropDownList Lista)
        {
            int Valor_Respuesta = 0;
            if (Codigo_Region == 0)
            {
                Valor_Respuesta = 0;
            }
            else
            {
                Valor_Respuesta = Convert.ToInt32(Lista.SelectedItem.Value);
            }

            return Valor_Respuesta;
        }
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 330, 180, "Alerta", null);
                return;
            }
        }
        /*ventanas*/
        protected void CloseWinwdows(RadWindow Ventana, string Llave)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").close();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
    }
}