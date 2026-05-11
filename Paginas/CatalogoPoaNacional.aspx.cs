using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class CatalogoPoaNacional : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public UsuarioValida Users = new UsuarioValida();

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
            GridProductoNacional.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductoNacional_NeedDataSource);
            GridProductoNacional.ItemCommand += new GridCommandEventHandler(Seleccionar_Productos);
            GridProductoNacional.DeleteCommand += new GridCommandEventHandler(Eliminar_ProductoNacional);
            GridProductoNacional.ItemDataBound += GridProductoNacional_ItemDataBound;
            GridProductoNacional.PreRender += new EventHandler(GridProductoNacional_PreRender);
            CboObjetivo.TextChanged += new EventHandler(CboObjetivo_TextChanged);
            CboResultado.TextChanged += new EventHandler(CboResultado_TextChanged);
            NuevoProducto.Click += new EventHandler(NuevoProducto_Click);
            CancelarProducto.Click += new EventHandler(CancelarProducto_Click);
            GuardarProducto.Click += new EventHandler(GuardarProducto_Click);

            GridSubProductoNacional.NeedDataSource += new GridNeedDataSourceEventHandler(GridSubProductoNacional_NeedDataSource);
            GridSubProductoNacional.ItemCommand += new GridCommandEventHandler(Seleccionar_SubProductos);
            //GridSubProductoNacional.DeleteCommand += new GridCommandEventHandler(Eliminar_SubProductoNacional);
            GridSubProductoNacional.ItemDataBound += GridSubProductoNacional_ItemDataBound;
            GridSubProductoNacional.PreRender += new EventHandler(GridSubProductoNacional_PreRender);
            NuevoSubProducto.Click += new EventHandler(NuevoSubProducto_Click);
            CancelarSubProducto.Click += new EventHandler(CancelarSubProducto_Click);
            GuardarSubProducto.Click += new EventHandler(GuardarSubProducto_Click);

            GridActividadNacional.NeedDataSource += new GridNeedDataSourceEventHandler(GridActividadNacional_NeedDataSource);
            GridActividadNacional.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividades);
            //GridActividadNacional.DeleteCommand += new GridCommandEventHandler(Eliminar_ActividadNacional);
            GridActividadNacional.ItemDataBound += GridActividadNacional_ItemDataBound;
            GridActividadNacional.PreRender += new EventHandler(GridActividadNacional_PreRender);
            NuevaActividad.Click += new EventHandler(NuevaActividad_Click);
            CancelarActividad.Click += new EventHandler(CancelarActividad_Click);
            CboProductoActividad.TextChanged += new EventHandler(CboProductoActividad_TextChanged);
            GuardarActividad.Click += new EventHandler(GuardarActividad_Click);

            GrdConfiguracionUM.NeedDataSource += new GridNeedDataSourceEventHandler(GrdConfiguracionUM_NeedDataSource);
            GrdConfiguracionUM.DeleteCommand += new GridCommandEventHandler(Eliminar_ProductoConfiguracion);
            GrdConfiguracionUM.ItemCommand += new GridCommandEventHandler(Seleccionar_ProductoConfiguracion);           
            GrdConfiguracionUM.PreRender += new EventHandler(GrdConfiguracionUM_PreRender);
            NuevaConfiguracionUM.Click += new EventHandler(NuevaConfiguracionUM_Click);
            GuardarConfiguracionUM.Click += new EventHandler(GuardarConfiguracionUM_Click);
            CancelarGuardadoConfiguracionUM.Click += new EventHandler(CancelarGuardadoConfiguracionUM_Click);

            CboProductoUM.TextChanged += new EventHandler(CboProductoUM_TextChanged);
            CboSubproductoUM.TextChanged += new EventHandler(CboSubproductoUM_TextChanged);
        }
        private void CboObjetivo_TextChanged(object sender, EventArgs e)
        {           
            procesos.LLenarComboT(CboResultado, "SELECT IdResultado Id,Descripcion_Resultado Descripcion FROM Resultado WHERE Estado_Resultado = 1 AND IdObjetivo = "+ procesos.IntNULLCombo(CboObjetivo), "Descripcion", "Id", true);
        }
        private void CboResultado_TextChanged(object sender, EventArgs e)
        {            
            procesos.LLenarComboT(CboIndicador, "SELECT IdIndicadores Id,Descripcion_Indicadores Descripcion FROM Indicadores WHERE Estado_Indicadores = 1 AND IdResultado = "+ procesos.IntNULLCombo(CboResultado), "Descripcion", "Id", true);
        }
        protected void fillProducto() 
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            string Cadena = "SELECT Id_producto Id,(descripcionCorrelativo+' '+Descripcion_Producto) Descripcion FROM ProductoNacional WHERE Estado_Producto = 1 ";
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                Cadena += "AND Id_Region = " + Users.id_region + " AND Id_Subregion = " + Users.id_subregion;
            }
            Cadena += "order by Correlativo;";

            procesos.LLenarComboT(CboProducto, Cadena, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboProductoUM, Cadena, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboProductoActividad,Cadena, "Descripcion", "Id", true);     

            string CadenaUM = "SELECT IdUnidadMedida Id,Descripcion_UnidadMedida Descripcion FROM Unidad_De_Medida_Nacional WHERE Estado_UnidadMedida = 1 Order by IdUnidadMedida";
            procesos.LLenarComboT(UM1Dato, CadenaUM, "Descripcion", "Id", true);
            procesos.LLenarComboT(UM2Dato, CadenaUM, "Descripcion", "Id", true);
            procesos.LLenarComboT(UM3Dato, CadenaUM, "Descripcion", "Id", true);
        }        
        protected void fillcombo()
        {            
            procesos.LLenarComboT(CboObjetivo, "SELECT IdObjetivo Id,Descripcion_Objetivo Descripcion FROM Objetivos WHERE Estado_Objetivo = 1;", "Descripcion", "Id", true);
            procesos.LLenarComboT(CboCorrelativoP, "SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativoProducto;", "Descripcion", "Id", true);
            procesos.LLenarComboT(CboCorrelativoSP, " SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativoSubProducto;", "Descripcion", "Id", true);
            procesos.LLenarComboT(CboCorrelativoA, "SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativoActividad", "Descripcion", "Id", true);
            fillProducto();
            insertarProducto.Visible = false;
            insertarSubProducto.Visible = false;
            insertarActividad.Visible = false;
            Session["Op"] = 1;
            Session["Id"] = 0;
            Session["Id_Region"] = 0;
            Session["Id_Subregion"] = 0;
            
        }
        protected void VerficarGrid() 
        {
            GridProductoNacional.Rebind();
                if (GridProductoNacional.Items.Count > 0) { GridProductoNacional.Visible = true; } else { GridProductoNacional.Visible = false; }
            GridSubProductoNacional.Rebind();
                if (GridSubProductoNacional.Items.Count > 0) { GridSubProductoNacional.Visible = true; } else { GridSubProductoNacional.Visible = false; }
            GridActividadNacional.Rebind();
                if (GridActividadNacional.Items.Count > 0) { GridActividadNacional.Visible = true; } else { GridActividadNacional.Visible = false; }
            GrdConfiguracionUM.Rebind();
                if (GrdConfiguracionUM.Items.Count > 0) { GrdConfiguracionUM.Visible = true; } else { GrdConfiguracionUM.Visible = false; }          
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
                fillcombo();
                VerficarGrid();
                Inicializar(false);
            }
        }
        /*Productos nacionales*/        
        protected void GridProductoNacional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            string CadenaString = "SELECT pn.Id_producto,pn.IdObjetivo,pn.IdResultado,pn.IdIndicadores,(ISNULL(pn.DescripcionCorrelativo,'') +' '+pn.Descripcion_Producto)Descripcion_ProductoU,"+
                                  "pn.Id_Region,pn.Id_Subregion,pn.Estado_Producto,ISNULL(pn.Correlativo,0) Correlativo,pn.Descripcion_Producto," +
                                  "ISNULL(o.Descripcion_Objetivo, '') Objetivo,ISNULL(r.Descripcion_Resultado, '') Resultado,ISNULL(i.Descripcion_Indicadores, '') Indicadores," +
                                  "(CASE WHEN pn.Estado_Producto = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END) Estado " +
                                  "FROM ProductoNacional pn " +
                                  "INNER JOIN Objetivos o ON pn.IdObjetivo = o.IdObjetivo " +
                                  "INNER JOIN Resultado r ON pn.IdResultado = r.IdResultado AND O.IdObjetivo = r.IdObjetivo " +
                                  "INNER JOIN Indicadores i ON pn.IdIndicadores = i.IdIndicadores AND r.IdResultado = i.IdResultado ";

            if(PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                CadenaString += "WHERE pn.Id_Region = " + Users.id_region + " AND pn.Id_Subregion = " + Users.id_subregion;
            }
            CadenaString += " ORDER BY o.Descripcion_Objetivo,r.Descripcion_Resultado,i.Descripcion_Indicadores,pn.Correlativo ASC";
            procesos.LlenarRadGrid(GridProductoNacional, CadenaString);            
        }
        private void GridProductoNacional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridProductoNacional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["IdObjetivo"].Text == gridDataItem3["IdObjetivo"].Text)
                    {
                        gridDataItem2["Objetivo"].RowSpan = gridDataItem3["Objetivo"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Objetivo"].RowSpan + 1;
                        gridDataItem3["Objetivo"].Visible = false;
                    }
                    if (gridDataItem2["IdResultado"].Text == gridDataItem3["IdResultado"].Text)
                    {
                        gridDataItem2["Resultado"].RowSpan = gridDataItem3["Resultado"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Resultado"].RowSpan + 1;
                        gridDataItem3["Resultado"].Visible = false;
                    }
                    if (gridDataItem2["Indicadores"].Text == gridDataItem3["Indicadores"].Text)
                    {
                        gridDataItem2["Indicadores"].RowSpan = gridDataItem3["Indicadores"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Indicadores"].RowSpan + 1;
                        gridDataItem3["Indicadores"].Visible = false;
                    }
                }
            }
        }
        protected void GridProductoNacional_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString()) == 2)
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected Validar_Data Validar_Producto(AIObjetosNacionales d)
        {
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Descripcion_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la descripcion del Producto.</br>"; }
            if (d.CorrelativoPSA == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el correlativo Producto.</br>"; }
            if (d.IdObjetivo == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Objetivo del producto.</br>"; }
            if (d.IdResultado == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Resultado del producto.</br>"; }
            if (d.IdIndicadores == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Indicador del producto.</br>"; }           
            
            if (d.Descripcion_Producto  != string.Empty)
            {
                if (C.BusquedaGRIDDato4(GridProductoNacional, "Descripcion_Producto", "IdObjetivo", "IdResultado", "IdIndicadores", d.Descripcion_Producto, d.IdObjetivo, d.IdResultado,d.IdIndicadores) == true && (d.Opcion == 1))
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresado ese Producto.</br>";
                }
            }
            return v;
        }
        protected void LimpiarDatosGeneral() 
        {
            Session["Id"] = 0;
            Session["Id_Region"] = 0;
            Session["Id_Subregion"] = 0;
            Session["Op"] = 1;            
        }
        protected void CambiarProducto(bool Valor)
        {
            bool Diferente;
            GridProductoNacional.MasterTableView.GetColumn("BotonA").Display = Valor;
            GridProductoNacional.MasterTableView.GetColumn("BotonB").Display = Valor;
            NuevoProducto.Enabled = Valor;
            Producto.Text = string.Empty;
            if(Valor == true) { Diferente = false; } else { Diferente = true; }
            insertarProducto.Visible = Diferente;
        }
        protected void CancelarProducto_Click(object sender, EventArgs e)
        {            
            CambiarProducto(true);
            LimpiarDatosGeneral();
            CboObjetivo.ClearSelection();
            CboResultado.ClearSelection();
            CboIndicador.ClearSelection();
            CboCorrelativoP.ClearSelection();
        }
        protected void NuevoProducto_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso == true)
            {               
                LimpiarDatosGeneral();
                CambiarProducto(false);
            }
            else
            {
                MensajePantalla("No tiene Permisos para Agregar un nuevo producto...");
            }
        }
        protected void Eliminar_ProductoNacional(object source, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;
            Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            int Id;

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                Id = Convert.ToInt32(item.GetDataKeyValue("Id_producto").ToString());
                int Id_usu = Convert.ToInt32(Session["Usuario"].ToString());

                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString()) != 1)
                {
                    MensajePantalla("el Producto se encuentra inactivo, No se Puede Eliminar.");
                }
                else
                {
                    if (Mmp.Eliminacion_ProductoNacional2(Id, Id_usu, Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString()),
                            Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString()), 1, ref er))
                    {
                        VerficarGrid();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }                   
                }
            }
        }
        protected void GuardarProducto_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosNacionales ai = new AIObjetosNacionales();
            Validar_Data v;
            Users = (UsuarioValida)Session["DataUser"];

            ai.Opcion = Convert.ToInt32(Session["Op"].ToString());
            ai.Id_producto = Convert.ToInt32(Session["Id"].ToString());
            ai.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.IdObjetivo = procesos.IntNULLCombo(CboObjetivo);
            ai.IdResultado = procesos.IntNULLCombo(CboResultado);
            ai.IdIndicadores = procesos.IntNULLCombo(CboIndicador);
            ai.Descripcion_Producto = Producto.Text.Trim();
            ai.CorrelativoPSA = procesos.IntNULLCombo(CboCorrelativoP);
            ai.Descripcion_Correlativo = procesos.StrNULLCombo(CboCorrelativoP);  
            if (ai.Opcion == 1) 
            {
                ai.Id_Region = Users.id_region;
                ai.Id_Subregion = Users.id_subregion;
                Session["CorrelativoValida"] = 0;
            }
            else 
            {
                ai.Id_Region = Convert.ToInt32(Session["Id_Region"].ToString());
                ai.Id_Subregion = Convert.ToInt32(Session["Id_Subregion"].ToString());
            }            
            ai.Idobjeto = 1;

            v = Validar_Producto(ai);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                if (x.Creacion_ObjetosNacionalesMantenimiento(ai,Convert.ToInt32(Session["CorrelativoValida"].ToString()), ref er))
                {
                    if (Convert.ToInt32(Session["op"].ToString()) == 1)
                    {
                        MensajePantalla("Fue Agregado Correctamente...");
                        CambiarProducto(false);
                    }
                    else
                    {
                        MensajePantalla("Fue Actualizado Correctamente...");                       
                        CambiarProducto(true);
                    }
                    VerficarGrid();
                    fillProducto();
                }
                else
                {                    
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Seleccionar_Productos(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;
            ConectarBDD procesos = new ConectarBDD();
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            GridDataItem item = e.Item as GridDataItem;
            AIObjetos DatosAI = new AIObjetos();

            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_producto").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 11;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {               
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString());               

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    CboObjetivo.ClearSelection();
                    CboResultado.ClearSelection();
                    CboIndicador.ClearSelection();
                    CboCorrelativoP.ClearSelection();
                    Session["Id"] = Convert.ToInt32(item.GetDataKeyValue("Id_producto").ToString());
                    Session["op"] = 2;
                    Session["Id_Region"] = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    Session["Id_Subregion"] = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());

                    insertarProducto.Visible = true;
                    CambiarProducto(false);
                    Producto.Text = item.GetDataKeyValue("Descripcion_Producto").ToString();
                    CboObjetivo.SelectedValue = item.GetDataKeyValue("IdObjetivo").ToString();
                    
                    procesos.LLenarComboT(CboResultado, "SELECT IdResultado Id,Descripcion_Resultado Descripcion FROM Resultado WHERE Estado_Resultado = 1 AND IdObjetivo = " + procesos.IntNULLCombo(CboObjetivo), "Descripcion", "Id", true);
                    CboResultado.SelectedValue = item.GetDataKeyValue("IdResultado").ToString();
                    procesos.LLenarComboT(CboIndicador, "SELECT IdIndicadores Id,Descripcion_Indicadores Descripcion FROM Indicadores WHERE Estado_Indicadores = 1 AND IdResultado = " + procesos.IntNULLCombo(CboResultado), "Descripcion", "Id", true);

                    CboCorrelativoP.SelectedValue = item.GetDataKeyValue("Correlativo").ToString();
                    Session["CorrelativoValida"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString()); 
                    CboIndicador.SelectedValue = item.GetDataKeyValue("IdIndicadores").ToString();
                    VerficarGrid();
                }
            }
        }
        /*subProductos nacionales*/        
        protected void GridSubProductoNacional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            string CadenaString = "SELECT subn.Id_Subproducto,subn.Id_producto,(ISNULL(subn.DescripcionCorrelativo,'')+' '+subn.Descripcion_Subproducto) Descripcion_SubproductoU," +
                                  "subn.Id_Region,subn.Id_Subregion,subn.Estado_SubProducto,ISNULL(subn.Correlativo,0) Correlativo,Descripcion_Subproducto," +
                                 "(CASE WHEN subn.Estado_SubProducto = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END) Estado,((ISNULL(pn.DescripcionCorrelativo,'')+' '+pn.Descripcion_Producto)) Producto " +
                                 "FROM SubProductoNacional subn INNER JOIN ProductoNacional pn ON subn.Id_producto = pn.Id_producto ";

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                CadenaString += "WHERE subn.Id_Region = " + Users.id_region + " AND subn.Id_Subregion = " + Users.id_subregion;
            }
            CadenaString += "ORDER BY pn.Correlativo,subn.Correlativo ASC";
            procesos.LlenarRadGrid(GridSubProductoNacional, CadenaString);           
        }
        private void GridSubProductoNacional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridSubProductoNacional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_producto"].Text == gridDataItem3["Id_producto"].Text)
                    {
                        gridDataItem2["Producto"].RowSpan = gridDataItem3["Producto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Producto"].RowSpan + 1;
                        gridDataItem3["Producto"].Visible = false;
                    }                    
                }
            }
        }
        protected void GridSubProductoNacional_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_SubProducto").ToString()) == 2)
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected Validar_Data Validar_SubProducto(AIObjetosNacionales d)
        {
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Descripcion_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la descripcion del SubProducto.</br>"; }
            if (d.IdObjetivo == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Producto que pertenece este subproducto.</br>"; }
            if (d.CorrelativoPSA == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Correlativo del subproducto.</br>"; }

            if (d.Descripcion_Producto != string.Empty)
            {
                if (C.BusquedaGRIDDato2(GridSubProductoNacional, "Descripcion_Subproducto", "Id_producto", d.Descripcion_Producto, d.IdObjetivo) == true && (d.Opcion == 1))
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresado ese SubProducto.</br>";
                }
            }
            return v;
        }
        protected void CambiarSubProducto(bool Valor)
        {            
            GridSubProductoNacional.MasterTableView.GetColumn("BotonA").Display = Valor;
            GridSubProductoNacional.MasterTableView.GetColumn("BotonB").Display = Valor;
            NuevoSubProducto.Enabled = Valor;
            SubProducto.Text = string.Empty;           
            bool Diferente;
            if (Valor == true) { Diferente = false; } else { Diferente = true; }
            insertarSubProducto.Visible = Diferente;
        }
        protected void CancelarSubProducto_Click(object sender, EventArgs e)
        {           
            CambiarSubProducto(true);
            LimpiarDatosGeneral();
            CboProducto.ClearSelection();
            CboCorrelativoSP.ClearSelection();
        }
        protected void NuevoSubProducto_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso == true)
            {               
                Session["Id"] = 0;
                Session["Op"] = 1;
                CambiarSubProducto(false);
            }
            else
            {
                MensajePantalla("No tiene Permisos para Agregar un nuevo Subproducto...");
            }
        }
        //protected void Eliminar_SubProductoNacional(object source, GridCommandEventArgs e)
        //{
        //    PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
        //    GridDataItem item = e.Item as GridDataItem;
        //    Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
        //    Mensajes_Error_BDD er = new Mensajes_Error_BDD();
        //    int Id;

        //    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso != true)
        //    {
        //        MensajePantalla("no tiene Permisos.......");
        //    }
        //    else
        //    {
        //        Id = Convert.ToInt32(item.GetDataKeyValue("Id_Subproducto").ToString());
        //        int Id_usu = Convert.ToInt32(Session["Usuario"].ToString());

        //        if (Convert.ToInt32(item.GetDataKeyValue("Estado_SubProducto").ToString()) != 1)
        //        {
        //            MensajePantalla("el subProducto se encuentra inactivo, No se Puede Eliminar.");
        //        }
        //        else
        //        {
        //            if (Mmp.Eliminacion_ProductoNacional2(Id, Id_usu, Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString()),
        //                    Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString()), 2, ref er))
        //            {
        //                VerficarGrid();
        //            }
        //            else
        //            {
        //                MensajePantalla(er.Descripcion.ToString());
        //            }
        //        }
        //    }
        //}
        protected void GuardarSubProducto_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosNacionales ai = new AIObjetosNacionales();
            Validar_Data v = new Validar_Data();
            Users = (UsuarioValida)Session["DataUser"];

            ai.Opcion = Convert.ToInt32(Session["Op"].ToString());
            ai.Id_producto = Convert.ToInt32(Session["Id"].ToString());
            ai.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.IdObjetivo = procesos.IntNULLCombo(CboProducto);           
            ai.Descripcion_Producto = SubProducto.Text.Trim();
            ai.CorrelativoPSA = procesos.IntNULLCombo(CboCorrelativoSP);
            ai.Descripcion_Correlativo = procesos.StrNULLCombo(CboCorrelativoSP);

            if (ai.Opcion == 1)
            {
                ai.Id_Region = Users.id_region;
                ai.Id_Subregion = Users.id_subregion;
                Session["CorrelativoValida"] = 0;
            }
            else
            {
                ai.Id_Region = Convert.ToInt32(Session["Id_Region"].ToString());
                ai.Id_Subregion = Convert.ToInt32(Session["Id_Subregion"].ToString());
            }            
            ai.Idobjeto = 2;

            v = Validar_SubProducto(ai);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                if (x.Creacion_ObjetosNacionalesMantenimiento(ai, Convert.ToInt32(Session["CorrelativoValida"].ToString()), ref er))
                {
                    if (Convert.ToInt32(Session["op"].ToString()) == 1)
                    {
                        MensajePantalla("Fue Agregado Correctamente...");
                        CambiarSubProducto(false);
                    }
                    else
                    {
                        MensajePantalla("Fue Actualizado Correctamente...");
                        LimpiarDatosGeneral();
                        CambiarSubProducto(true);
                    }
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Seleccionar_SubProductos(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;
            ConectarBDD procesos = new ConectarBDD();
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            GridDataItem item = e.Item as GridDataItem;
            AIObjetos DatosAI = new AIObjetos();

            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Subproducto").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_SubProducto").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 12;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_SubProducto").ToString());

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    CboProducto.ClearSelection();
                    CboCorrelativoSP.ClearSelection();
                    Session["Id"] = Convert.ToInt32(item.GetDataKeyValue("Id_Subproducto").ToString());
                    Session["op"] = 2;
                    insertarSubProducto.Visible = true;
                    CambiarSubProducto(false);
                    SubProducto.Text = item.GetDataKeyValue("Descripcion_Subproducto").ToString();
                    CboProducto.SelectedValue = item.GetDataKeyValue("Id_producto").ToString();
                    CboCorrelativoSP.SelectedValue = item.GetDataKeyValue("Correlativo").ToString();
                    Session["CorrelativoValida"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                    Session["Id_Region"] = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    Session["Id_Subregion"] = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    VerficarGrid();
                }
            }
        }
        /*Actividades nacionales*/
        protected void fillSubProducto(int IdProducto)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            string Cadena = "SELECT Id_Subproducto Id,Descripcion_Subproducto Descripcion FROM SubProductoNacional WHERE Estado_SubProducto = 1 AND Id_Subproducto = 1 UNION " +
                           "SELECT Id_Subproducto Id,(descripcionCorrelativo+' '+Descripcion_Subproducto) Descripcion FROM SubProductoNacional WHERE Estado_SubProducto = 1 " +
                           "AND Id_producto = " + IdProducto.ToString();  

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                Cadena += " AND Id_Region = " + Users.id_region + " AND Id_Subregion = " + Users.id_subregion;
            }         
            procesos.LLenarComboT(CboSubproducto, Cadena, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboSubproductoUM, Cadena, "Descripcion", "Id", true);
        }
        private void CboProductoActividad_TextChanged(object sender, EventArgs e)
        {
            fillSubProducto(procesos.IntNULLCombo(CboProductoActividad));
        }        
        protected void GridActividadNacional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            string CadenaString = "SELECT an.Id_Actividad,an.Id_producto,an.Id_Subproducto,(ISNULL(an.descripcionCorrelativo,'') +' '+an.Descripcion_Actividad) Descripcion_ActividadU,an.Id_Region,an.Id_Subregion," +
                                  "an.Estado_Actividad,ISNULL(an.Correlativo,0) Correlativo,an.Descripcion_Actividad," +
                                  "(pn.descripcionCorrelativo+' '+pn.Descripcion_Producto) Producto,(CASE WHEN an.Id_Subproducto = 1 THEN '' ELSE (sn.descripcionCorrelativo+' '+sn.Descripcion_Subproducto) END) Subproducto," +
                                  "(CASE WHEN an.Estado_Actividad = 1 THEN 'ACTIVO' ELSE 'INACTIVO' END) Estado " +
                                  "FROM Actividad_Nacional an INNER JOIN ProductoNacional pn ON pn.Id_producto = an.Id_producto " +
                                  "INNER JOIN SubProductoNacional sn ON sn.Id_Subproducto = an.Id_Subproducto ";

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                CadenaString += "WHERE an.Id_Region = " + Users.id_region + " AND an.Id_Subregion = " + Users.id_subregion;
            }
            CadenaString += "ORDER BY pn.correlativo,sn.correlativo,an.correlativo ASC";
            procesos.LlenarRadGrid(GridActividadNacional, CadenaString);
        }
        private void GridActividadNacional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridActividadNacional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_producto"].Text == gridDataItem3["Id_producto"].Text)
                    {
                        gridDataItem2["Producto"].RowSpan = gridDataItem3["Producto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Producto"].RowSpan + 1;
                        gridDataItem3["Producto"].Visible = false;
                    }
                    if (gridDataItem2["Id_Subproducto"].Text == gridDataItem3["Id_Subproducto"].Text)
                    {
                        gridDataItem2["Subproducto"].RowSpan = gridDataItem3["Subproducto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Subproducto"].RowSpan + 1;
                        gridDataItem3["Subproducto"].Visible = false;
                    }
                }
            }
        }
        protected void GridActividadNacional_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Actividad").ToString()) == 2)
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                 
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected Validar_Data Validar_Actividad(AIObjetosNacionales d)
        {
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Descripcion_Producto == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la descripcion de la Actividad.</br>"; }
            if (d.IdObjetivo == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Producto que pertenece esta Actividad.</br>"; }
            if(d.CorrelativoPSA == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Correlativo que pertenece esta Actividad.</br>"; }

            if (d.Descripcion_Producto != string.Empty)
            {
                if (C.BusquedaGRIDDato3(GridActividadNacional, "Descripcion_Actividad", "Id_producto", "Id_Subproducto", d.Descripcion_Producto, d.IdObjetivo,d.IdResultado) == true && (d.Opcion == 1))
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresado esta Actividad.</br>";
                }
            }
            return v;
        }
        protected void CambiarActividad(bool Valor)
        {
            GridActividadNacional.MasterTableView.GetColumn("BotonA").Display = Valor;
            GridActividadNacional.MasterTableView.GetColumn("BotonB").Display = Valor;
            NuevaActividad.Enabled = Valor;
            Actividad.Text = string.Empty;           
            bool Diferente;
            if (Valor == true) { Diferente = false; } else { Diferente = true; }
            insertarActividad.Visible = Diferente;
        }
        protected void CancelarActividad_Click(object sender, EventArgs e)
        {           
            CambiarActividad(true);
            CboProductoActividad.ClearSelection();
            CboSubproducto.ClearSelection();
            CboCorrelativoA.ClearSelection();
            LimpiarDatosGeneral();
        }
        protected void NuevaActividad_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso == true)
            {               
                LimpiarDatosGeneral();
                CboProductoActividad.ClearSelection();
                CboSubproducto.ClearSelection();
                CboCorrelativoA.ClearSelection();
                CambiarActividad(false);
            }
            else
            {
                MensajePantalla("No tiene Permisos para Agregar una nueva Actividad...");
            }
        }
        //protected void Eliminar_ActividadNacional(object source, GridCommandEventArgs e)
        //{
        //    PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
        //    GridDataItem item = e.Item as GridDataItem;
        //    Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
        //    Mensajes_Error_BDD er = new Mensajes_Error_BDD();
        //    int Id;

        //    if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso != true)
        //    {
        //        MensajePantalla("no tiene Permisos.......");
        //    }
        //    else
        //    {
        //        Id = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
        //        int Id_usu = Convert.ToInt32(Session["Usuario"].ToString());

        //        if (Convert.ToInt32(item.GetDataKeyValue("Estado_Actividad").ToString()) != 1)
        //        {
        //            MensajePantalla("la Actvidad se encuentra inactivo, No se Puede Eliminar.");
        //        }
        //        else
        //        {
        //            if (Mmp.Eliminacion_ProductoNacional2(Id, Id_usu, Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString()),
        //                    Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString()), 3, ref er))
        //            {
        //                VerficarGrid();
        //            }
        //            else
        //            {
        //                MensajePantalla(er.Descripcion.ToString());
        //            }
        //        }
        //    }
        //}
        protected void GuardarActividad_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosNacionales ai = new AIObjetosNacionales();
            Validar_Data v = new Validar_Data();
            Users = (UsuarioValida)Session["DataUser"];

            ai.Opcion = Convert.ToInt32(Session["Op"].ToString());
            ai.Id_producto = Convert.ToInt32(Session["Id"].ToString());
            ai.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.IdObjetivo = procesos.IntNULLCombo(CboProductoActividad);
            ai.IdResultado = procesos.IntNULLCombo(CboSubproducto);
            ai.CorrelativoPSA = procesos.IntNULLCombo(CboCorrelativoA);
            ai.Descripcion_Correlativo = procesos.StrNULLCombo(CboCorrelativoA);
            if (ai.IdResultado == 0) 
            {
                ai.IdResultado = 1;
            }
            ai.Descripcion_Producto = Actividad.Text.Trim();
            if (ai.Opcion == 1)
            {
                ai.Id_Region = Users.id_region;
                ai.Id_Subregion = Users.id_subregion;
                Session["CorrelativoValida"] = 0;
            }
            else
            {
                ai.Id_Region = Convert.ToInt32(Session["Id_Region"].ToString());
                ai.Id_Subregion = Convert.ToInt32(Session["Id_Subregion"].ToString());
            }
            ai.Idobjeto = 3;

            v = Validar_Actividad(ai);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                if (x.Creacion_ObjetosNacionalesMantenimiento(ai, Convert.ToInt32(Session["CorrelativoValida"].ToString()), ref er))
                {
                    if (Convert.ToInt32(Session["op"].ToString()) == 1)
                    {
                        MensajePantalla("Fue Agregado Correctamente...");
                        CambiarActividad(false);
                    }
                    else
                    {
                        MensajePantalla("Fue Actualizado Correctamente...");
                        CambiarActividad(true);
                        LimpiarDatosGeneral();
                    }
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Seleccionar_Actividades(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;         
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            GridDataItem item = e.Item as GridDataItem;
            AIObjetos DatosAI = new AIObjetos();

            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Actividad").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 13;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Actividad").ToString());

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    Session["Id"] = Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString());
                    Session["op"] = 2;
                    insertarActividad.Visible = true;
                    Session["Id_Region"] = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    Session["Id_Subregion"] = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    CambiarActividad(false);
                    Actividad.Text = item.GetDataKeyValue("Descripcion_Actividad").ToString();
                    CboProductoActividad.SelectedValue = item.GetDataKeyValue("Id_producto").ToString();
                    CboCorrelativoA.SelectedValue = item.GetDataKeyValue("Correlativo").ToString();
                    Session["CorrelativoValida"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                    fillSubProducto(Convert.ToInt32(item.GetDataKeyValue("Id_producto").ToString()));
                    if(Convert.ToInt32(item.GetDataKeyValue("Id_Subproducto").ToString()) == 1) 
                    {
                        CboSubproducto.ClearSelection();
                    }
                    else 
                    {
                        CboSubproducto.SelectedValue = item.GetDataKeyValue("Id_Subproducto").ToString();
                    }
                    VerficarGrid();
                }
            }
        }
        /*Configuracion de productos*/
        protected void fillActividad(int IdProducto,int IdSubproducto)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];           
            string Cadena = "SELECT Id_Actividad Id,Descripcion_Actividad Descripcion,ISNULL(Correlativo,0) Correlativo FROM Actividad_Nacional WHERE Estado_Actividad = 1 AND Id_Actividad = 1  UNION " +
                            "SELECT Id_Actividad Id,(DescripcionCorrelativo+' '+Descripcion_Actividad),Correlativo FROM Actividad_Nacional WHERE Estado_Actividad = 1" +
                            " AND Id_producto = " + IdProducto.ToString() + " AND Id_Subproducto = " + IdSubproducto.ToString(); 

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 46).Permiso != true)
            {
                Users = (UsuarioValida)Session["DataUser"];
                Cadena += " AND Id_Region = " + Users.id_region + " AND Id_Subregion = " + Users.id_subregion;
            }
            Cadena += " ORDER BY Correlativo";
            procesos.LLenarComboT(CboActividadUM, Cadena, "Descripcion", "Id", true);          
        }
        private void CboProductoUM_TextChanged(object sender, EventArgs e)
        {
            fillSubProducto(procesos.IntNULLCombo(CboProductoUM));
            fillActividad(procesos.IntNULLCombo(CboProductoUM), procesos.IntNULLComboUNO(CboSubproductoUM));
        }
        private void CboSubproductoUM_TextChanged(object sender, EventArgs e)
        {
            fillActividad(procesos.IntNULLCombo(CboProductoUM),procesos.IntNULLComboUNO(CboSubproductoUM));
        }
        private void GrdConfiguracionUM_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdConfiguracionUM.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_producto"].Text == gridDataItem3["Id_producto"].Text)
                    {
                        gridDataItem2["DescripcionProducto"].RowSpan = gridDataItem3["DescripcionProducto"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionProducto"].RowSpan + 1;
                        gridDataItem3["DescripcionProducto"].Visible = false;
                    }

                    if (gridDataItem2["Id_SubProducto"].Text != "1")
                    {
                        if (gridDataItem2["Id_SubProducto"].Text == gridDataItem3["Id_SubProducto"].Text)
                        {
                            gridDataItem2["DescripcionSubProducto"].RowSpan = gridDataItem3["DescripcionSubProducto"].RowSpan < 2
                            ? 2
                            : gridDataItem3["DescripcionSubProducto"].RowSpan + 1;
                            gridDataItem3["DescripcionSubProducto"].Visible = false;
                        }
                    }
                }
            }
        }                                
        protected void Inicializar(bool Valor) 
        {
            bool ValorContrario;
            if (Valor == true) { ValorContrario = false; } else { ValorContrario = true; }
            IngresoConfiguracionUM.Visible = Valor;
            GuardarConfiguracionUM.Visible = Valor;
            CancelarGuardadoConfiguracionUM.Visible = Valor;
            NuevaConfiguracionUM.Visible = ValorContrario;
            GrdConfiguracionUM.MasterTableView.GetColumn("BotonA").Display = ValorContrario;
            GrdConfiguracionUM.MasterTableView.GetColumn("BotonB").Display = ValorContrario;           
        }
        protected void InicializarObjetosUM()
        {            
            UM1Dato.ClearSelection();
            UM2Dato.ClearSelection();
            UM3Dato.ClearSelection();           
            MedioVerificacionUM.Text = string.Empty; 
            DireccionVerificacionUM.Text  = string.Empty;          
        }        
        protected void NuevaConfiguracionUM_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso == true)
            {                
                Session["Id"] = 0;
                Inicializar(true);
                InicializarObjetosUM();
                LimpiarDatosGeneral();
                CboProductoUM.ClearSelection();
                CboSubproductoUM.ClearSelection();
                CboActividadUM.ClearSelection();
            }
            else
            {
                MensajePantalla("No tiene Permisos para Agregar nuevas Configuraciones...");
            }
        }
        protected Validar_Data Validar_IngresoConfiguracion(ConfiguracionUMNacionales d)
        {
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Id_Producto == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Producto....</br>"; }

            if (d.Id_Producto != 0)
            {
                if (C.BusquedaGRIDDato3IDs(GrdConfiguracionUM, "Id_Producto", "Id_SubProducto", "Id_Actividad", d.Id_Producto, d.Id_SubProducto, d.Id_Actividad) && (d.Opcion == 1))
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresada ese información Verificar....</br>";
                }
            }
            return v;
        }
        protected string CadenasSQL(int Op,int Objeto,int Region,int Subregion) 
        {
            string Cadena = string.Empty;
            if(Op == 1) 
            { 
                Cadena = "SELECT ISNULL(Correlativo, 0) Correlativo FROM ProductoNacional WHERE Id_producto = "+ Objeto + " AND Id_Region = "+ Region + " AND Id_Subregion = "+ Subregion +";";
            }
            if (Op == 2)
            {
                Cadena = "SELECT ISNULL(Correlativo, 0) Correlativo FROM SubProductoNacional WHERE Id_Subproducto = " + Objeto + " AND Id_Region = " + Region + " AND Id_Subregion = " + Subregion + ";";
            }
            if (Op == 3)
            {
                Cadena = "SELECT ISNULL(Correlativo, 0) Correlativo FROM Actividad_Nacional WHERE Id_Actividad = " + Objeto + " AND Id_Region = " + Region + " AND Id_Subregion = " + Subregion + ";";
            }
            return Cadena;
        }
        protected void GuardarConfiguracionUM_Click(object sender, EventArgs e) 
        {
            ConfiguracionUMNacionales Configurar = new ConfiguracionUMNacionales();
            Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Validar_Data V;
            Users = (UsuarioValida)Session["DataUser"];
            
            Configurar.Opcion = Convert.ToInt32(Session["Op"].ToString());
            Configurar.Correlativo_Configuracion = Convert.ToInt32(Session["Id"].ToString());
            Configurar.Id_Producto = procesos.IntNULLCombo(CboProductoUM);
            Configurar.DescripcionProducto = procesos.StrNULLCombo(CboProductoUM);
            Configurar.Id_SubProducto = procesos.IntNULLComboUNO(CboSubproductoUM);
            Configurar.DescripcionSubProducto = procesos.StrNULLCombo(CboSubproductoUM);
            Configurar.Id_Actividad = procesos.IntNULLComboUNO(CboActividadUM);
            Configurar.DescripcionActividad = procesos.StrNULLCombo(CboActividadUM); 
            Configurar.Id_UM1 = procesos.IntNULLCombo(UM1Dato);
            Configurar.DescripcionUM1 = procesos.StrNULLComboNacional(UM1Dato);
            Configurar.Id_UM2 = procesos.IntNULLCombo(UM2Dato);
            Configurar.DescripcionUM2 = procesos.StrNULLComboNacional(UM2Dato);
            Configurar.Id_UM3 = procesos.IntNULLCombo(UM3Dato);
            Configurar.DescripcionUM3 = procesos.StrNULLComboNacional(UM3Dato);
            Configurar.MedioDeVerificacion = MedioVerificacionUM.Text.Trim();
            Configurar.DireccionMedioVerificacion = DireccionVerificacionUM.Text.Trim();
            Configurar.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());           
            if (Configurar.Opcion == 1) 
            {
                Configurar.Id_Region = Users.id_region;
                Configurar.Id_Subregion = Users.id_subregion;               
            }
            else 
            {                                
                //Configurar.Id_Region = Convert.ToInt32(Session["Id_Region"].ToString());
                Configurar.Id_Region = Convert.ToInt32(Users.id_region.ToString());
                Configurar.Id_Subregion = Convert.ToInt32(Session["Id_Subregion"].ToString());
            }
            Configurar.Id_Correlativo_Producto = Mmp.Obtener_correlativos_Configuracion(CadenasSQL(1, Configurar.Id_Producto, Configurar.Id_Region, Configurar.Id_Subregion));
            Configurar.Id_Correlativo_SubProducto = Mmp.Obtener_correlativos_Configuracion(CadenasSQL(2, Configurar.Id_SubProducto, Configurar.Id_Region, Configurar.Id_Subregion));
            Configurar.Id_Correlativo_Actividad = Mmp.Obtener_correlativos_Configuracion(CadenasSQL(3, Configurar.Id_Actividad, Configurar.Id_Region, Configurar.Id_Subregion));

            V = Validar_IngresoConfiguracion(Configurar);
            if (V.Verificar)
            {
                MensajePantalla(V.Mensaje);
            }
            else 
            {
                XmlDocument DescripcionProductoConfiguracion = Mmp.DetalleXMLProductoNacionales(Mmp.Agregar_ProductoListaConfiguracion(Configurar));

                if (Mmp.Guardar_producto_Configuracion(Configurar, DescripcionProductoConfiguracion, ref er))
                {
                    if (Configurar.Opcion == 1) 
                    {
                        MensajePantalla("Se ha agregado Correctamente...");
                        InicializarObjetosUM();
                    }
                    else 
                    {
                        MensajePantalla("Se ha Editado Correctamente...");
                        InicializarObjetosUM();
                        Inicializar(false);
                        LimpiarDatosGeneral();                           
                    }
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void Eliminar_ProductoConfiguracion(object source, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;
            Manejo_De_Mantenimiento_PoaNacional Mmp = new Manejo_De_Mantenimiento_PoaNacional();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            int Id;

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                Id = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                int Id_usu = Convert.ToInt32(Session["Usuario"].ToString());

                if (Mmp.Eliminacion_ProductoNacional(Id, Id_usu, Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString()),
                        Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString()), ref er))
                {
                    VerficarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
                if (GrdConfiguracionUM.Items.Count == 0)
                {
                    GrdConfiguracionUM.Visible = false;
                }
                else
                {
                    GrdConfiguracionUM.Visible = true;
                }
            }
        }
        protected void CancelarGuardadoConfiguracionUM_Click(object sender, EventArgs e) 
        {
            Inicializar(false);            
            InicializarObjetosUM();
            CboProductoUM.ClearSelection();
            CboSubproductoUM.ClearSelection();
            CboActividadUM.ClearSelection();
        }
        protected void GrdConfiguracionUM_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            Users = (UsuarioValida)Session["DataUser"];
            procesos.LlenarRadGrid(GrdConfiguracionUM, "EXEC Sp_obtener_data_ProductosNacionales " + Users.id_region + ","+ Users.id_subregion + ";");
        }
        protected void Seleccionar_ProductoConfiguracion(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];                   
            GridDataItem item = e.Item as GridDataItem;            
            
            if (e.CommandName == "Select")
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 47).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    CboProductoUM.ClearSelection();
                    CboSubproductoUM.ClearSelection();
                    CboActividadUM.ClearSelection();
                    Session["Id"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo_Configuracion").ToString());
                    Session["op"] = 2;
                    Session["Id_Region"] = Convert.ToInt32(item.GetDataKeyValue("Id_Region").ToString());
                    Session["Id_Subregion"] = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                    Inicializar(true);
                    fillProducto();                   
                    CboProductoUM.SelectedValue = item.GetDataKeyValue("Id_Producto").ToString();
                    fillSubProducto(procesos.IntNULLCombo(CboProductoUM));
                    
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_SubProducto").ToString()) == 1) 
                    {
                        CboSubproductoUM.ClearSelection();
                    }
                    else 
                    {
                        CboSubproductoUM.SelectedValue = item.GetDataKeyValue("Id_SubProducto").ToString();
                    }
                    fillActividad(procesos.IntNULLCombo(CboProductoUM), procesos.IntNULLComboUNO(CboSubproductoUM));
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_Actividad").ToString()) == 1) 
                    {
                        CboActividadUM.ClearSelection();
                    }
                    else 
                    {
                        CboActividadUM.SelectedValue = item.GetDataKeyValue("Id_Actividad").ToString();
                    }                                           
                    UM1Dato.SelectedValue = item.GetDataKeyValue("Id_UM1").ToString();
                    if(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()) == 0)
                    {
                        UM1Dato.ClearSelection();
                    }
                    UM2Dato.SelectedValue = item.GetDataKeyValue("Id_UM2").ToString();
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()) == 0)
                    {
                        UM2Dato.ClearSelection();
                    }
                    UM3Dato.SelectedValue = item.GetDataKeyValue("Id_UM3").ToString();
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()) == 0)
                    {
                        UM3Dato.ClearSelection();
                    }
                    MedioVerificacionUM.Text = item.GetDataKeyValue("MedioDeVerificacion").ToString();
                    DireccionVerificacionUM.Text = item.GetDataKeyValue("DireccionMedioVerificacion").ToString();
                    VerficarGrid();
                }
            }
        }               
    }
}