using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Modelos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PlanificacionPOA.Controladores
{
    public class Manipulacion_Usuarios
    {
        public DataSet Extraer_Data(string Sql)
        {
            ConectarBDD Data = new ConectarBDD();
            DataSet Respuesta = Data.obtenerDataSetCodigo(Sql, "tabla");

            return Respuesta;
        }
        public Validar_Data Verificar_Vacios(Usuario_Manipulacion UsuarioV)
        {
            Validar_Data v = new Validar_Data();
            Validar_Cui DPI = new Validar_Cui();
            v.Verificar = false;
            if (UsuarioV.Nombres == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Nombre.<br/>"; }
            if (UsuarioV.Apellidos == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Apellido.<br/>"; }
            if (UsuarioV.Usuario == string.Empty) { v.Verificar = true; v.Mensaje += "No a ingresado el Usuario.<br/>"; }         
            if (UsuarioV.Tperfil == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el Perfil.<br/>"; }
            if (UsuarioV.Puesto == 0) { v.Verificar = true; v.Mensaje += "No a ingresado el Puesto que desempeña.<br/>"; }
            if (UsuarioV.Region == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la Región que Pertenece.<br/>"; }
            if (UsuarioV.Subregion == 0) { v.Verificar = true; v.Mensaje += "No a ingresado la SubRegión que Pertenece.<br/>"; }
          
            return v;
        }
        public bool Creacion_UsuariosSys(Usuario_Manipulacion u, string passw, ref Mensajes_Error_BDD e)
        {
            Encriptacion Convertir = new Encriptacion();
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();
            string Password_Codificado = Convertir.Codificar(passw);

            Grabar.AgregarParametro("@Usuario", SqlDbType.VarChar, u.Usuario);
            Grabar.AgregarParametro("@Tperfil", SqlDbType.Int, u.Tperfil);
            Grabar.AgregarParametro("@Nombre", SqlDbType.VarChar, u.Nombres);
            Grabar.AgregarParametro("@Apellido", SqlDbType.VarChar, u.Apellidos);
            Grabar.AgregarParametro("@Dpi", SqlDbType.VarChar, u.DPI);
            Grabar.AgregarParametro("@password", SqlDbType.VarChar, Password_Codificado);
            Grabar.AgregarParametro("@region", SqlDbType.Int, u.Region);
            Grabar.AgregarParametro("@subregion", SqlDbType.Int, u.Subregion);
            Grabar.AgregarParametro("@puesto", SqlDbType.Int, u.Puesto);
            Grabar.AgregarParametro("@Idusuario", SqlDbType.Int, u.Usuarioqcambio);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Creacion_de_Usuarios", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Edicion_UsuariosSys(Usuario_Manipulacion u, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@Usuario", SqlDbType.VarChar, u.Usuario);
            Grabar.AgregarParametro("@Tperfil", SqlDbType.Int, u.Tperfil);
            Grabar.AgregarParametro("@Nombre", SqlDbType.VarChar, u.Nombres);
            Grabar.AgregarParametro("@Apellido", SqlDbType.VarChar, u.Apellidos);
            Grabar.AgregarParametro("@Dpi", SqlDbType.VarChar, u.DPI);
            Grabar.AgregarParametro("@codigoU", SqlDbType.VarChar, u.Password);
            Grabar.AgregarParametro("@Region", SqlDbType.Int, u.Region);
            Grabar.AgregarParametro("@Subregion", SqlDbType.Int, u.Subregion);
            Grabar.AgregarParametro("@Puesto", SqlDbType.Int, u.Puesto);
            Grabar.AgregarParametro("@Id_usuario", SqlDbType.Int, u.Usuarioqcambio);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_edicion_de_Usuarios", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Activar_DesactivarRol(Permisos p, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@opcion", SqlDbType.Int, p.Opcion);
            Grabar.AgregarParametro("@CodigoMenu", SqlDbType.Int, p.CodigoMenu);
            Grabar.AgregarParametro("@Perfil", SqlDbType.Int, p.Perfil);
            Grabar.AgregarParametro("@Id_Usuario", SqlDbType.Int, p.Codigo_Usuario);
            Grabar.AgregarParametro("@Id_Usuario_Modifica", SqlDbType.Int, p.Codigo_Usuario_Modifica);

            if ((iComandos = Grabar.ExecuteNonQuery("Sp_Activacion_Desactivacion_Roles_Opciones", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    e.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    e.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Activacion_Desactivacion(int Usuario, int opcion, ref Mensajes_Error_BDD Error)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Validacion v = new Validacion();

            Grabar.AgregarParametro("@usuario", SqlDbType.Int, Usuario);
            Grabar.AgregarParametro("@opcion", SqlDbType.Int, opcion);
            Grabar.AgregarParametro("@pass", SqlDbType.VarChar, "xoxo");

            if ((iComandos = Grabar.ExecuteNonQuery("sp_Activacion_Desactivado_Usuario", true)) != null)
            {
                if (!DBNull.Value.Equals(iComandos.Parameters["@Error"].Value) && int.Parse(iComandos.Parameters["@Error"].Value.ToString()) == 0)
                {
                    return true;
                }
                else
                {
                    Error.Numero = (v.intNoNull(iComandos.Parameters["@Error"].Value));
                    Error.Descripcion += v.StrNoNull(iComandos.Parameters["@MensajeError"].Value);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public string TextSQl(int option)
        {
            string SqlText = string.Empty;
            if (option == 1)
            {
                SqlText = "SELECT u.id_usuario,CASE WHEN ISNULL(u.apellidos, '') = '' THEN " +
                          "u.nombres ELSE u.nombres + ', ' + u.apellidos END  AS Usuario,u.dpi, " +
                          "u.Estado_Usuario, CASE WHEN(u.Estado_Usuario = 1) THEN'ACTIVADO' " +
                          "ELSE 'DESACTIVADO' END AS Estado," +
                          "u.usuario as Correo,p.Descripcion perfil,p.Id_Plantilla " +
                          "FROM usuarios u INNER JOIN Plantillas p ON u.Id_Tipoperfil =p.Id_Plantilla WHERE u.Estado_Usuario = 1 ORDER BY Usuario";
            }
            if (option == 2)
            {
                SqlText = "SELECT m.Id_Menu,m.Descripcion_Menu,m.Cod_Padre,ap.ActivarMenu AS IdEstado, " +
                          "CASE WHEN ap.ActivarMenu = 1 THEN 'Activo' ELSE 'Inactivo' END AS Estado " +
                          "FROM menus m INNER JOIN AsignacionesDePermisos ap ON m.Id_Menu = ap.Id_Menu " +
                          "AND M.Cod_Padre = AP.Cod_Padre WHERE ap.Id_Plantilla = 1 AND AP.Id_Usuario = 1 order by m.orden";
            }
            return SqlText;
        }
    }
}