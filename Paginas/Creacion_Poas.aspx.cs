using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Creacion_Poas : System.Web.UI.Page
    {
        public PoasCreados POA = new PoasCreados();
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public AIObjetos DatosAI = new AIObjetos();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }        
        protected void Inicializacion_Objetos() 
        {
            GridPOASSistema.NeedDataSource += new GridNeedDataSourceEventHandler(GridPOASSistema_NeedDataSource);
            GridPOASSistema.ItemCommand += new GridCommandEventHandler(Seleccionar_POA);
            GridPOASSistema.ItemDataBound += GridPOASSistema_ItemDataBound;
            GridPOASSistema.DeleteCommand += new GridCommandEventHandler(Eliminar_POA);
            NuevoPOA.Click += new EventHandler(NuevoPOA_Click);
            GuardarPOA.Click += new EventHandler(GuardarPOA_Click);
            CancelarPOA.Click += new EventHandler(CancelarPOA_Click);
            GuardarTarea.Click += new EventHandler(GuardarTarea_Click);
            CancelarTarea.Click += new EventHandler(CancelarTarea_Click);           
        }        
        protected void Fillcombo() 
        {
           procesos.LLenarComboT(CboTipoPoa, "SELECT Id_Poa,Descripcion_POA FROM Tipo_De_Poa WHERE IdEstado = 1;", "Descripcion_POA", "Id_Poa", true);
        }
        protected void VerificargRID() 
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridPOASSistema.Rebind();
            if (GridPOASSistema.Items.Count != 0) { GridPOASSistema.Visible = true; } else { GridPOASSistema.Visible = false; }
            insertarpoASS.Visible = false;

            Session["op"] = 1;
            Session["CodigoCambia"] = 0;
            Session["Codigo"] = 0;            
            GridPOASSistema.MasterTableView.GetColumn("BotonX").Display = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 15).Permiso;
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 10).Permiso != true)
            {
                Response.Redirect("Portada.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                VericarPermiso();
                VerificargRID();                
                Fillcombo();               
            }
        }
        protected void CargarIcono(int Opcion) 
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (Opcion == 1) 
            {
                GridPOASSistema.MasterTableView.GetColumn("BotonA").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonB").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonC").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonD").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonE").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonF").Display = true;
                GridPOASSistema.MasterTableView.GetColumn("BotonX").Display = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 15).Permiso;
            }
            if (Opcion == 2)
            {
                GridPOASSistema.MasterTableView.GetColumn("BotonA").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonB").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonC").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonD").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonE").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonF").Display = false;
                GridPOASSistema.MasterTableView.GetColumn("BotonX").Display = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 15).Permiso;
            }
        }
        protected void CancelarPOA_Click(object sender, EventArgs e)
        {
            insertarpoASS.Visible = false;
            NuevoPOA.Enabled = true;
            DescipcionPOA.Text = string.Empty;
            CboTipoPoa.ClearSelection();
            Verificar.Visible = false;
            CboTipoPoa.Enabled = true;
            AnioCorrespodiente.ReadOnly = true;
            AnioCorrespodiente.Text = string.Empty; 
            CargarIcono(1);            
        }
        protected void NuevoPOA_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 18).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                insertarpoASS.Visible = true;
                NuevoPOA.Enabled = false;
                DescipcionPOA.Text = string.Empty;
                CboTipoPoa.ClearSelection();
                Verificar.Visible = false;
                CboTipoPoa.Enabled = true;
                AnioCorrespodiente.ReadOnly = false;
                AnioCorrespodiente.Text = string.Empty;
                CargarIcono(2);
            }
        }
        protected Validar_Data Validar_POa(PoasCreados d)
        {
            Validacion C = new Validacion();
            Validar_Data v = new Validar_Data();
            int Comparar;
            v.Verificar = false;
           
            if (d.Dato_2 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Tipo de poa.</br>"; }
            if (d.AnioCorresponde == 0) { v.Verificar = true; v.Mensaje += "No ha Ingresado el año del POA.</br>"; }   
            
            if(d.AnioCorresponde != 0) 
            {               
                Comparar = C.ComprobarAño(d.AnioCorresponde);
                if(Comparar == 1) { v.Verificar = true; v.Mensaje += "No se Puede Crear un poa de un año Anterior.</br>"; }
                if(Comparar == 2) { v.Verificar = true; v.Mensaje += "No se Puede Crear un poa de dos años posteriores al año en curso.</br>"; }
            }
            if (d.Dato_2 != 0) 
            {
                if (C.BusquedaGRIDDatoPOA(GridPOASSistema, "Id_Poa","Anio", d.Dato_2, d.AnioCorresponde) == true && (d.Opcion == 1) == true)
                {
                    v.Verificar = true; v.Mensaje += "ya Creo ese POA.</br>";
                }
            }

            return v;
        }
        protected void GuardarPOA_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();
            PoasCreados ai = new PoasCreados();
            Validar_Data V;

            ai.Descripcion = DescipcionPOA.Text;
            ai.AnioCorresponde = procesos.STRRadNumericTextBox(AnioCorrespodiente); 
            ai.Dato_2 = procesos.IntNULLCombo(CboTipoPoa);
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            
            V = Validar_POa(ai);
            if (V.Verificar)
            {
                MensajePantalla(V.Mensaje);
            }
            else
            {
                 if (x.Creacion_Poas(ai, ref er))
                 {
                    DescipcionPOA.Text = string.Empty;
                    AnioCorrespodiente.Text = "0";
                    CboTipoPoa.ClearSelection();
                     if (Convert.ToInt32(Session["op"].ToString()) == 1)
                     {
                         MensajePantalla("Fue Agregado Correctamente...");
                     }
                     else
                     {
                         MensajePantalla("Fue Actualizado Correctamente...");
                     }
                    insertarpoASS.Visible = false;
                    NuevoPOA.Enabled = true;
                     Session["op"] = 1;
                    GridPOASSistema.Visible = true;
                    CargarIcono(1);                    
                    GridPOASSistema.Rebind();
                 }
                 else
                 {
                     MensajePantalla(er.Descripcion.ToString());
                 }
            }
        }
        protected void GridPOASSistema_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridPOASSistema, "SELECT pc.Id_PoAnual,pc.Id_Poa,tp.Descripcion_POA POA,pc.Descripcion_POA,pc.Anio_Correspondiente Anio,pc.Estado_PoAnual,IniciarTarea," +
                                                    "(CASE WHEN pc.Estado_PoAnual = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado,"+
                                                    "(CASE WHEN pc.IniciarTarea = 1 THEN 'Tarea Iniciada' ELSE 'Tarea sin Iniciar' END) Inicios " +
                                                    "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp. Id_Poa;");
        }
        protected void GridPOASSistema_ItemDataBound(object sender, GridItemEventArgs e)
        {
            int Codigo;
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString()) == 2)
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
                
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());
                
                if(Codigo != 2) 
                {
                    ((ImageButton)item["BotonC"].Controls[0]).Visible = false;
                    ((ImageButton)item["BotonD"].Controls[0]).Visible = false;
                    //((ImageButton)item["BotonF"].Controls[0]).Visible = false;
                    ((ImageButton)item["BotonF"].Controls[0]).Visible = true;
                }
                else 
                {
                    ((ImageButton)item["BotonC"].Controls[0]).Visible = true;
                    ((ImageButton)item["BotonD"].Controls[0]).Visible = true;
                    ((ImageButton)item["BotonF"].Controls[0]).Visible = true;
                }
            }
        }        
        protected void Seleccionar_POA(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;
            int InicioT;
            int Tipo;
            ConectarBDD procesos = new ConectarBDD();
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            PermisosPermitidos =(List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

           GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")/*Activar y desactivar poas*/
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 9;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridPOASSistema.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")/*Edición de poas*/
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString());
                InicioT = Convert.ToInt32(item.GetDataKeyValue("IniciarTarea").ToString());
                Session["op"] = 2;
                
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 12).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (InicioT == 1)
                    {
                        Verificar.Visible = true;
                        CboTipoPoa.Enabled = false;
                        AnioCorrespodiente.ReadOnly = false;
                    }
                    else
                    {
                        Verificar.Visible = false;
                        CboTipoPoa.Enabled = true;
                        AnioCorrespodiente.ReadOnly = true;
                    }

                    if (Estado == 2)
                    {
                        MensajePantalla("Esta Desactivado no se puede Editar.......");
                    }
                    else
                    {

                        NuevoPOA.Enabled = false;
                        insertarpoASS.Visible = true;
                        CargarIcono(2);

                        DescipcionPOA.Text = item.GetDataKeyValue("Descripcion_POA").ToString();
                        AnioCorrespodiente.Text = item.GetDataKeyValue("Anio").ToString(); ;
                        CboTipoPoa.SelectedValue = item.GetDataKeyValue("Id_Poa").ToString();
                    }
                }
            }
            if (e.CommandName == "Select2")/*Carga de productos*/
            {
                Session["CodigoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Session["anioPoa"] = Convert.ToInt32(item.GetDataKeyValue("Anio").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString());               
                Tipo = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());
                
                if (Tipo == 2)
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 11).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (Estado == 2)
                        {
                            MensajePantalla("Esta Desactivado no se puede Cargar Productos.....");
                        }
                        else
                        {
                            Response.Redirect("Producto_Regional.aspx");
                        }
                    }
                }
                else
                {
                    MensajePantalla("Solo Aplica a Planes Operativos Anuales Regionales");
                }
            }
            if (e.CommandName == "Select3")/*Exportar poa en formato pdf*/
            {                
                Session["Codigo"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Session["anioPoa2"] = Convert.ToInt32(item.GetDataKeyValue("Anio").ToString());
                Tipo = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());                
                
                if (Tipo == 2)
                {
                    procesos.AgregarParametro("@Id_PoAnual", SqlDbType.Int, Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString()));
                    DataSet Datos = procesos.Execute("Sp_obtener_data_Productos");
                    if ((Datos != null) && (Datos.Tables.Count > 0) && (Datos.Tables[0].Rows.Count > 0)) 
                    {
                        Exportar_Excel(ExportarEx, "../ExportarExcel/ExportarExcelPOARegional.aspx", "250", "250", "key2", "Exportar a excel Configuración Plan Operativo Regional");
                    }
                    else 
                    {
                        MensajePantalla("No se puede exporta a excel no tiene información configurada....");
                    }                   
                }
                else 
                {                    
                    MensajePantalla("Solo Aplica a Planes Operativos Anuales Regionales");
                }
            }
            if (e.CommandName == "Select4")/*Iniciar Tareas*/
            {
                
                Session["CodigoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Session["TipoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString());
                InicioT = Convert.ToInt32(item.GetDataKeyValue("IniciarTarea").ToString());

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Iniciar la tarea.......");
                }
                else
                {
                    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 13).Permiso != true)
                    {
                        MensajePantalla("no tiene Permisos.......");
                    }
                    else
                    {
                        if (InicioT == 0)
                        {
                          OpenWinwdows(InicioTareas, "500", "480", "Key", "Inicio de Poa");
                        }
                        else
                        {
                            MensajePantalla("La Tarea Ya fue Iniciada.......");
                        }
                    }
                }
            }
            if (e.CommandName == "Select5")/*Copiar el contenido del poa anterior*/
            {              
                int POa = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_PoAnual").ToString());
                Tipo = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());

                if (Tipo == 2)
                {
                    if (Estado == 2)
                    {
                        MensajePantalla("Esta Desactivado no se hacer la replica....");
                    }
                    else
                    {
                        if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 14).Permiso != true)
                        {
                            MensajePantalla("no tiene Permisos.......");
                        }
                        else
                        {
                            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
                            Manejo_Creacion_Poas D = new Manejo_Creacion_Poas();
                            if (D.Copiar_Informacion_AnteriorPoa(POa, Convert.ToInt32(Session["Usuario"].ToString()), ref er))
                            {
                                MensajePantalla("Se Realizo Correctamente...");
                                GridPOASSistema.Rebind();
                            }
                            else
                            {
                                MensajePantalla(er.Descripcion.ToString());
                            }
                        }
                    }
                }
                else 
                {
                    MensajePantalla("Solo Aplica a Planes Operativos Anuales Regionales");
                }
            }
            if (e.CommandName == "Select6")/*Reprogramacion de poas*/
            {
                Session["CodigoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
                Session["TipoPoa"] = Convert.ToInt32(item.GetDataKeyValue("Id_Poa").ToString());              
               // InicioT = Convert.ToInt32(item.GetDataKeyValue("IniciarTarea").ToString());

              /*  if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 41).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    if (InicioT == 0)
                    {
                        OpenWinwdows(InicioTareas, "500", "480", "Key", "Mantenimiento del Poa");
                    }
                    else
                    {
                        MensajePantalla("La Tarea Ya fue Iniciada.......");
                    }
                }*/
            }
        }
        protected void Eliminar_POA(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();                        
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 15).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                if (Convert.ToInt32(item.GetDataKeyValue("IniciarTarea").ToString()) == 0)
                {
                    if (x.Eliminar_POA(Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString()), Convert.ToInt32(Session["Usuario"].ToString()), ref er))
                    {
                        GridPOASSistema.Rebind();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                    if (GridPOASSistema.Items.Count == 0)
                    {
                        GridPOASSistema.Visible = false;
                    }
                    else
                    {
                        GridPOASSistema.Visible = Visible;
                    }
                }
                else
                {
                    MensajePantalla("No Puede eliminar este Poa ya fue iniciada la tarea");
                }
            }
        }
        protected Validar_Data Validar_Tarea(Tarea d)
        {
            Validar_Data V = new Validar_Data();                       
            string Cadena = "SELECT Id_PoAnual,Informacion FROM Poas_Creados WHERE Id_PoAnual = " + d.Id_PoAnual;
            DataSet Datos = procesos.obtenerDataSetCodigo(Cadena, "Tabla");

            if (Convert.ToInt32(Session["TipoPoa"].ToString()) == 2)
            {
                string dat = Datos.Tables[0].Rows[0]["Informacion"].ToString();
                if (dat.Length == 0)
                { V.Verificar = true; V.Mensaje += "No ha ingresado Productos regionales para iniciar la tarea.</br>"; }
            }           
            if (d.FechaDeEntrega == string.Empty) { V.Verificar = true; V.Mensaje += "No ha ingresado la fecha de entrega.</br>"; }
            if (d.Instrucciones == string.Empty) { V.Verificar = true; V.Mensaje += "No ha Ingresado las instrucciones.</br>"; }           
            return V;
        }
        protected void GuardarTarea_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();
            Tarea Ai = new Tarea();
            Validar_Data V;

            Ai.FechaDeEntrega = procesos.Fechas(txtFechaEntrega);
            Ai.Instrucciones = txtInstrucciones.Text.Trim();
            Ai.Id_PoAnual = Convert.ToInt32(Session["CodigoPoa"].ToString());           
            Ai.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());           

            V = Validar_Tarea(Ai);
            if (V.Verificar)
            {
                MensajePantalla(V.Mensaje);
            }
            else
            {
                if (x.Inicializar_TareaPoa(Ai, ref er))
                {
                    MensajePantalla("Se inicializo Correctamente...");                                       
                    GridPOASSistema.Rebind();
                    txtInstrucciones.Text = string.Empty;
                    txtFechaEntrega.Clear();
                    CloseWinwdows(InicioTareas, "Key");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void CancelarTarea_Click(object sender, EventArgs e)
        {
            txtInstrucciones.Text = string.Empty;
            txtFechaEntrega.Clear();
            CloseWinwdows(InicioTareas, "Key");
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
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
    }
}