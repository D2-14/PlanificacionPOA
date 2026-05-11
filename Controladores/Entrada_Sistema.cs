using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.ConexionBDD;

namespace PlanificacionPOA.Controladores
{
    public class Entrada_Sistema
    {
        public bool VerifcarDatosGridAsignacion(int op,int idSubregion,int id)
        {
            ConectarBDD Grabar = new ConectarBDD();
            bool Resulta;
            string CadenaSQl = "EXEC Sp_Procesos_Obtener_dataAsginacion " + op +","+ idSubregion;
          
            DataSet DatosUsuario = Grabar.obtenerDataSetCodigo(CadenaSQl, "Tabla");

            if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
            {
                if(Convert.ToInt32(DatosUsuario.Tables[0].Rows[0]["Cantidad"].ToString()) != 0) 
                {
                    Resulta = true;
                }
                else 
                {
                    if (Convert.ToInt32(id) == 1)
                    {
                        Resulta = true;
                    }
                    else
                    {
                        Resulta = false;
                    }
                }
            }
            else
            {
                Resulta = false;
            }
            return Resulta;
        }
        public bool Verificar_Usuario(Ingreso_Usuario u, ref Mensajes_Error_BDD e)
        {           
            ConectarBDD Grabar = new ConectarBDD();
            Encriptacion Convertir = new Encriptacion();
            Validacion v = new Validacion();
            string pass;
            int intentos;
            int estado;            
            Grabar.AgregarParametro("@Usuario", SqlDbType.VarChar, u.Usuario);
            DataSet DatosUsuario = Grabar.Execute("sp_Extraer_usuario");
            if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
            {
                pass = Convertir.Descodificar(DatosUsuario.Tables[0].Rows[0]["Contraseña"].ToString());
                estado = Convert.ToInt32(DatosUsuario.Tables[0].Rows[0]["Estado_Usuario"].ToString());
                intentos = Convert.ToInt32(DatosUsuario.Tables[0].Rows[0]["Intento_Ingreso"].ToString());
                if (estado != 1)
                {
                    e.Numero = (v.intNoNull(500));
                    e.Descripcion += v.StrNoNull("El Usuario no esta Activo en el sistema");
                    return false;
                }
                else
                {
                    if (pass != u.Password)
                    {
                        e.Numero = (v.intNoNull(500));
                        if (intentos == 5)
                        {
                            e.Descripcion += v.StrNoNull("Ha hecho Cinco Intentos con la contraseña, su usuario ha sido desactivado, comunicarse con el administrador del sistema");
                            Grabar.EjecutarCodigo("Update usuarios set EstadoUsuario = 0 WHERE Usuario ='" + u.Usuario + "';");
                        }
                        else
                        {
                            e.Descripcion += v.StrNoNull("La contraseña Ingresada No es la correcta");
                            Grabar.EjecutarCodigo("Update usuarios set Intento = Intento + 1 WHERE Usuario ='" + u.Usuario + "';");
                        }
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                e.Numero = (v.intNoNull(500));
                e.Descripcion += v.StrNoNull("No Existe ese Usuario en el Sistema");
                return false;
            }
        }
        public string  ExtraerCorreo(int idSubregion)
        {
            ConectarBDD Grabar = new ConectarBDD();
            string Correo; 
            string Cadena = "SELECT Usuario FROM Usuarios  WHERE Id_Subregion = " + idSubregion;
            DataSet DatosUsuario = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
            {
                Correo = DatosUsuario.Tables[0].Rows[0]["Usuario"].ToString();                
            }
            else
            {
                Correo = string.Empty; 
            }
            return Correo;
        }
        public Extraer_Usuario Data_U(string Us)
        {
            ConectarBDD Grabar = new ConectarBDD();         
            Extraer_Usuario Usuario = new Extraer_Usuario();
            string Cadena = "SELECT id_usuario,Estado_Usuario FROM Usuarios WHERE Usuario = '" + Us + "'";
            DataSet DatosUsuario = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
            {
                Usuario.Cambios = Convert.ToInt32(DatosUsuario.Tables[0].Rows[0]["Estado_Usuario"].ToString());
                Usuario.id_usuario = DatosUsuario.Tables[0].Rows[0]["id_usuario"].ToString();
                Usuario.ErrorCodigo = 1;
            }
            else
            {
                Usuario.ErrorCodigo = 2;
                Usuario.Descripcion = "No Existe ese Usuario en el Sistema...";
            }
            return Usuario;
        }
        public Extraer_Usuario Data_Usuario(Ingreso_Usuario Us)
        {
            Extraer_Usuario Usuario = new Extraer_Usuario();
            ConectarBDD ManejoBDD = new ConectarBDD();
            try
            {
                ManejoBDD.AgregarParametro("@Usuario", SqlDbType.VarChar, Us.Usuario);
                DataSet DatosUsuario = ManejoBDD.Execute("sp_Extraer_usuario");
                if ((DatosUsuario != null) && (DatosUsuario.Tables.Count > 0) && (DatosUsuario.Tables[0].Rows.Count > 0))
                {
                    Usuario.id_usuario = DatosUsuario.Tables[0].Rows[0]["id_usuario"].ToString();
                    Usuario.Id_Tipoperfil = DatosUsuario.Tables[0].Rows[0]["Id_Tipoperfil"].ToString();
                    Usuario.nombreusuario = DatosUsuario.Tables[0].Rows[0]["nombreusuario"].ToString();
                    Usuario.id_region = DatosUsuario.Tables[0].Rows[0]["id_region"].ToString();
                    Usuario.id_subregion = DatosUsuario.Tables[0].Rows[0]["id_subregion"].ToString();
                    Usuario.DescripcionPerfil = DatosUsuario.Tables[0].Rows[0]["DescripcionPerfil"].ToString();
                    Usuario.Cambios = Convert.ToInt32(DatosUsuario.Tables[0].Rows[0]["Cambios"].ToString());
                    Usuario.ErrorCodigo = 1;
                }
                else
                {
                    Usuario.ErrorCodigo = 2;
                    Usuario.Descripcion = "No se Encuentra informacion de este usuario";
                }
            }
            catch (Exception)
            {
                Usuario.ErrorCodigo = 2;
                Usuario.Descripcion = "No se pudo Conectar a la base de datos";
            }
            return Usuario;
        }
        public void Quitar_Intentos(string Us)
        {
            ConectarBDD ManejoBDD = new ConectarBDD();
            try
            {
                ManejoBDD.EjecutarCodigo("Update usuarios set Intento = 0 where Usuario ='" + Us + "';");
            }
            catch (Exception) { }
        }
        public void Guardar_Inicio_Sesion(string Us, int Id_Usuario)
        {
            ConectarBDD ManejoBDD = new ConectarBDD();
            try
            {
                ManejoBDD.EjecutarCodigo("Update usuarios set Intento = 0 where Usuario ='" + Us + "';");
                ManejoBDD.EjecutarCodigo("INSERT INTO RegistroSesion(id_usuario,FechaInicio,Activa)Values(" + Id_Usuario + ",GETDATE(),1);");
            }
            catch (Exception) { }
        }
        public bool Cambio_Password(Ingreso_Usuario u, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Encriptacion Convertir = new Encriptacion();
            Validacion v = new Validacion();

            string password = Convertir.Codificar(u.Password);
            Grabar.AgregarParametro("@IdUsuario", SqlDbType.Int, u.Id);
            Grabar.AgregarParametro("@IdPassword", SqlDbType.VarChar, password);

            if ((iComandos = Grabar.ExecuteNonQuery("sp_Cambio_Contrasenia", true)) != null)
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
        public bool Reset_Contrasenia(Usuario_del_Sistema u, ref Mensajes_Error_BDD e)
        {
            SqlCommand iComandos;
            ConectarBDD Grabar = new ConectarBDD();
            Encriptacion Convertir = new Encriptacion();
            Validacion v = new Validacion();
            string passw;
            passw = Convertir.Codificar(u.Password);

            Grabar.AgregarParametro("@usuario", SqlDbType.Int, u.Id);
            Grabar.AgregarParametro("@opcion", SqlDbType.Int, u.Opcion);
            Grabar.AgregarParametro("@pass", SqlDbType.VarChar, passw);

            if ((iComandos = Grabar.ExecuteNonQuery("sp_Activacion_Desactivado_Usuario", true)) != null)
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
        public List<Permisos_del_Sistema> Permisos(int id_Usuario)
        {
            List<Permisos_del_Sistema> Carga = new List<Permisos_del_Sistema>();
            ConectarBDD Grabar = new ConectarBDD();

            Grabar.AgregarParametro("@idUsuario", SqlDbType.Int, id_Usuario);
            DataSet Menu = Grabar.ExecuteMenu("Sp_Menu_dinamico");

            foreach (DataRow Fila in Menu.Tables["tabla"].Rows)
            {
                Carga.Add(new Permisos_del_Sistema
                {
                    Id_Menu = Convert.ToInt32(Fila["Menu"].ToString()),
                    Id_Padre = Convert.ToInt32(Fila["Padre"].ToString()),
                    Descripcion = Fila["Descripcion"].ToString(),
                    Url = Fila["Url"].ToString()
                });

            }
            return Carga;
        }
        public Datos_Permisos Verifica_Permisos(List<Permisos_del_Sistema> Permisos, int Permiso)
        {
            Datos_Permisos p = new Datos_Permisos();
            p.Permiso = false;
            p.Url = string.Empty;

            if (Permisos.Count != 0)
            {
                var item = Permisos.Find(x => x.Id_Menu == Permiso);
                if (item == null)
                 {
                    p.Permiso = false;
                    p.Url = string.Empty;
                }
                else
                {
                    p.Permiso = true;
                    p.Url = item.Url.ToString();
                }
            }
            return p;
        }
        /*validacion de data*/
        public Validar_Data ValidacionEntrada(Ingreso_Usuario u)
        {
            Validar_Data v = new Validar_Data();           
            Validacion V = new Validacion();

            v.Verificar = false;
            if (u.Usuario == string.Empty) { v.Verificar = true; v.Mensaje += "No Ingresado el usuario del sistema (Correo Eléctronico).</br>"; }
            if (u.Password == string.Empty) { v.Verificar = true; v.Mensaje += "No Ingresado la contraseña.</br>"; }
            if (V.Verifica_Correo(u.Usuario) == false) { v.Verificar = true; v.Mensaje += "Error: esa direccion de correo es invalida revisar.</br>"; }

            return v;
        }
        public Buscar_Select Extraer_SP(int Id_Usuario)
        {
            ConectarBDD Grabar = new ConectarBDD();           
            Buscar_Select BS = new Buscar_Select();
            string Cadena = "SELECT id_subregion AS IDS,Id_Tipoperfil AS IDP FROM Usuarios WHERE Id_Usuario = " + Id_Usuario + ";";
            DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

            if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0))
            {
                BS.Subregion = Convert.ToInt32(Datos.Tables[0].Rows[0]["IDS"].ToString());
                BS.Perfil = Convert.ToInt32(Datos.Tables[0].Rows[0]["IDP"].ToString());
            }
            return BS;
        }
    }
}