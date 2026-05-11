using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class Admon_Poas : System.Web.UI.Page
    {
        public AIObjetos DatosAI = new AIObjetos();
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        public RadTab Pest1 = new RadTab();
        public RadTab Pest2 = new RadTab();        
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void Inicializacion_ObjetosRegional() 
        {                                   
            GridComponente.NeedDataSource += new GridNeedDataSourceEventHandler(GridComponente_NeedDataSource);
            GridComponente.ItemCommand += new GridCommandEventHandler(Seleccionar_Componente);
            GridComponente.ItemDataBound += Componente_ItemDataBound;
            NuevoComponente.Click += new EventHandler(NuevoComponente_Click);
            GuardarComponente.Click += new EventHandler(GuardarComponente_Click);
            CancelarComponente.Click += new EventHandler(CancelarComponente_Click);

            GridSubComponente.NeedDataSource += new GridNeedDataSourceEventHandler(GridSubComponente_NeedDataSource);
            GridSubComponente.ItemCommand += new GridCommandEventHandler(Seleccionar_SubComponente);
            GridSubComponente.ItemDataBound += SubComponente_ItemDataBound;
            NuevoSubComponente.Click += new EventHandler(NuevoSubComponente_Click);
            GuardarSubComponente.Click += new EventHandler(GuardarSubComponente_Click);
            CancelarSubComponente.Click += new EventHandler(CancelarSubComponente_Click);
            CboComponenteBusqueda.TextChanged += new EventHandler(CboComponenteBusqueda_TextChanged);
            CboComponente1.TextChanged += new EventHandler(CboComponente1_TextChanged);
            GridSubComponente.PreRender += new EventHandler(GridSubComponente_PreRender);

            GridUnidaMedidaRegional.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidaMedidaRegional_NeedDataSource);
            GridUnidaMedidaRegional.ItemCommand += new GridCommandEventHandler(Seleccionar_UnidaMedidaRegional);
            GridUnidaMedidaRegional.ItemDataBound += UnidaMedidaRegional_ItemDataBound;
            NuevoUnidaMedidaRegional.Click += new EventHandler(NuevoUnidaMedidaRegional_Click);
            GuardarUnidaMedidaRegional.Click += new EventHandler(GuardarUnidaMedidaRegional_Click);
            CancelarUnidaMedidaRegional.Click += new EventHandler(CancelarUnidaMedidaRegional_Click);
            CboComponenteBusquedaUnidad.TextChanged += new EventHandler(CboComponenteBusquedaUnidad_TextChanged);
            CboComponente2.TextChanged += new EventHandler(CboComponente2_TextChanged);           
            GridUnidaMedidaRegional.PreRender += new EventHandler(GridUnidaMedidaRegional_PreRender);

            GridProductoVerificable.NeedDataSource += new GridNeedDataSourceEventHandler(GridProductoVerificable_NeedDataSource);
            GridProductoVerificable.ItemCommand += new GridCommandEventHandler(Seleccionar_ProductoVerificable);
            GridProductoVerificable.ItemDataBound += ProductoVerificable_ItemDataBound;
            NuevoProductoVerificable.Click += new EventHandler(NuevoProductoVerificable_Click);
            GuardarProductoVerificable.Click += new EventHandler(GuardarProductoVerificable_Click);
            CancelaProductoVerificable.Click += new EventHandler(CancelaProductoVerificable_Click);
            CboComponenteProductoVerificable.TextChanged += new EventHandler(CboComponenteProductoVerificable_TextChanged);
            CboComponente3.TextChanged += new EventHandler(CboComponente3_TextChanged);
            GridProductoVerificable.PreRender += new EventHandler(GridProductoVerificable_PreRender);           
        }
        protected void Inicializacion_ObjetosNacional() 
        {
            GridObjetivos.NeedDataSource += new GridNeedDataSourceEventHandler(GridObjetivos_NeedDataSource);
            GridObjetivos.ItemCommand += new GridCommandEventHandler(Seleccionar_Objetivos);
            GridObjetivos.ItemDataBound += GridObjetivos_ItemDataBound;           
            NuevoObjetivo.Click += new EventHandler(NuevoObjetivo_Click);
            GuardarObjetivo.Click += new EventHandler(GuardarObjetivo_Click);
            CancelarObjetivo.Click += new EventHandler(CancelarObjetivo_Click);

            GridResultado.NeedDataSource += new GridNeedDataSourceEventHandler(GridResultado_NeedDataSource);
            GridResultado.ItemCommand += new GridCommandEventHandler(Seleccionar_Resultado);
            GridResultado.ItemDataBound += Resultado_ItemDataBound;
            GridResultado.PreRender += new EventHandler(GridResultado_PreRender);
            NuevoResultado.Click += new EventHandler(NuevoResultado_Click);
            GuardarResultado.Click += new EventHandler(GuardarResultado_Click);
            CancelarResultado.Click += new EventHandler(CancelarResultado_Click);

            GridIndicador.NeedDataSource += new GridNeedDataSourceEventHandler(GridIndicador_NeedDataSource);
            GridIndicador.ItemCommand += new GridCommandEventHandler(Seleccionar_Indicador);
            GridIndicador.ItemDataBound += Indicador_ItemDataBound;
            GridIndicador.PreRender += new EventHandler(GridIndicador_PreRender);
            NuevoIndicador.Click += new EventHandler(NuevoIndicador_Click);
            GuardarIndicador.Click += new EventHandler(GuardarIndicador_Click);
            CancelarIndicador.Click += new EventHandler(CancelarIndicador_Click);

            GridUnidadMedidaPN.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidadMedidaPN_NeedDataSource);
            GridUnidadMedidaPN.ItemCommand += new GridCommandEventHandler(Seleccionar_UnidadMedidaPN);
            GridUnidadMedidaPN.ItemDataBound += UnidadMedidaPN_ItemDataBound;
            NuevoUnidadMedidaPN.Click += new EventHandler(NuevoUnidadMedidaPN_Click);
            GuardarUnidadMedidaPN.Click += new EventHandler(GuardarUnidadMedidaPN_Click);
            CancelarUnidadMedidaPN.Click += new EventHandler(CancelarUnidadMedidaPN_Click);            
        }
        protected void fillcombo() 
        {
            string stringComando =
                            "DECLARE @Componente AS TABLE(Id INT, Descripcion NVARCHAR(MAX), Correlativo INT); " +
                            "INSERT INTO @Componente " +
                            "SELECT IdComponente, Descripcion_Componente,Correlativo FROM Componente WHERE Estado_Componente = 1; " +
                            "INSERT INTO @Componente " +
                            "SELECT 1000 Id,'TODO',700 Descripcion; " +
                            "SELECT Id, Descripcion FROM @Componente ORDER BY Correlativo;";

            string stringComando1 = "SELECT IdComponente Id, Descripcion_Componente Descripcion FROM Componente WHERE Estado_Componente = 1 ORDER BY correlativo;";

            procesos.LLenarComboT(CboObjetivoResultado, "SELECT IdObjetivo,Descripcion_Objetivo FROM Objetivos WHERE Estado_Objetivo = 1;", "Descripcion_Objetivo", "IdObjetivo", true);
            procesos.LLenarComboT(CboResultadoIndicador, "SELECT IdResultado,Descripcion_Resultado FROM Resultado WHERE Estado_Resultado = 1;", "Descripcion_Resultado", "IdResultado", true);            
            procesos.LLenarComboT(CboComponente1, stringComando1, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboComponente2, stringComando1, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboComponente3, stringComando1, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboUnidadMedida1, "SELECT IdTipoUnidad Id,DescripcionTipo Descripcion FROM Tipo_UnidadMedida WHERE EstadoTipoUnidad = 1;", "Descripcion", "Id", true);                        
            procesos.LLenarComboT(CboComponenteBusqueda, stringComando, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboComponenteBusquedaUnidad, stringComando, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboComponenteProductoVerificable, stringComando, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboTipoConteo, "SELECT id_conteo Id, descripcion_conteo Descripcion from tipo_ConteoRegional where Estado_Conteo = 1;", "Descripcion", "Id", true);
            procesos.LLenarComboT(TipoDeConteoNacional, "SELECT id_conteo Id, descripcion_conteo Descripcion from tipo_ConteoRegional where Estado_Conteo = 1;", "Descripcion", "Id", true);

            procesos.LLenarComboT(CboCorrelativoComponente1, "SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativoComponente;", "Descripcion", "Id", true);
            procesos.LLenarComboT(cboSubcomponten1, "SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativosubComponente;", "Descripcion", "Id", true);
            procesos.LLenarComboT(cboCorrelativoActividad, "SELECT Id_Correlativo Id,(Descripcion+' '+CAST(Id_Correlativo AS nvarchar(50))+':') Descripcion FROM CorrelativoActividades;", "Descripcion", "Id", true);            
        }
        protected void VerificarPoaRegional() 
        {
            GridComponente.Rebind();
            GridSubComponente.Rebind();
            GridUnidaMedidaRegional.Rebind();
            GridProductoVerificable.Rebind();

            insertarComponente.Visible = false;
            if (GridComponente.Items.Count != 0) { GridComponente.Visible = true; } else { GridComponente.Visible = false; }            
            insertarSubComponente.Visible = false;
            if (GridSubComponente.Items.Count != 0) { GridSubComponente.Visible = true; } else { GridSubComponente.Visible = false; }
            insertarUnidaMedidaRegional.Visible = false;
            if (GridUnidaMedidaRegional.Items.Count != 0) { GridUnidaMedidaRegional.Visible = true; } else { GridUnidaMedidaRegional.Visible = false; }
            insertarProductoVerificable.Visible = false;
            if (GridProductoVerificable.Items.Count != 0) { GridProductoVerificable.Visible = true; } else { GridProductoVerificable.Visible = false; }
            GridProductoVerificable.Visible = false;
        }
        protected void VerificarPoaNacional() 
        {
            Session["op"] = 1;
            Session["CodigoCambia"] = 0;
            PermisosPermitidos = PermisosUsuario.Permisos(Convert.ToInt32(Session["Usuario"].ToString()));           
            Pest1 = ControladorTAb.FindTabByText("Mantenimiento Poa Regional");
            Pest2 = ControladorTAb.FindTabByText("Mantenimiento Poa Nacional");
            Pest1.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 8).Permiso;
            Pest2.Visible = PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 9).Permiso;
           
            GridObjetivos.Rebind();
            GridResultado.Rebind();
            GridIndicador.Rebind();
            GridUnidadMedidaPN.Rebind();

            if (GridObjetivos.Items.Count != 0) { GridObjetivos.Visible = true; } else { GridObjetivos.Visible = false; }
            insertarobjetivo.Visible = false;
            if (GridResultado.Items.Count != 0) { GridResultado.Visible = true; } else { GridResultado.Visible = false; }
            insertarResultado.Visible = false;
            if (GridIndicador.Items.Count != 0) { GridIndicador.Visible = true; } else { GridIndicador.Visible = false; }
            insertarIndicador.Visible = false;
            if (GridUnidadMedidaPN.Items.Count != 0) { GridUnidadMedidaPN.Visible = true; } else { GridUnidadMedidaPN.Visible = false; }
            insertarUnidadMedidaPN.Visible = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            Inicializacion_ObjetosNacional();
            Inicializacion_ObjetosRegional();
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos,7).Permiso != true)
                {
                    Response.Redirect("Portada.aspx");
                }
                VerificarPoaNacional();
                VerificarPoaRegional();
                fillcombo();               
            }
        }
        /*POAS Regionales*/
        /*Componentes*/
        protected void CancelarComponente_Click(object sender, EventArgs e)
        {
            insertarComponente.Visible = false;
            NuevoComponente.Enabled = true;
            Componente.Text = string.Empty;
            GridComponente.MasterTableView.GetColumn("BotonA").Display = true;
            GridComponente.MasterTableView.GetColumn("BotonB").Display = true;
        }
        protected void NuevoComponente_Click(object sender, EventArgs e)
        {
            insertarComponente.Visible = true;
            NuevoComponente.Enabled = false;
            Componente.Text = string.Empty;
            CboCorrelativoComponente1.ClearSelection();
            GridComponente.MasterTableView.GetColumn("BotonA").Display = false;
            GridComponente.MasterTableView.GetColumn("BotonB").Display = false;
        }
        protected void GuardarComponente_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosRegional ai = new AIObjetosRegional();
            Validacion C = new Validacion();
            ai.Descripcion = Componente.Text;
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Correlativo = procesos.IntNULLCombo(CboCorrelativoComponente1);
            ai.Tipo = 1;

            if (ai.Descripcion == string.Empty)
            {
                MensajePantalla("No ha ingresado descripción...");
            }
            else
            {
                if (ai.Correlativo == 0) 
                {
                    MensajePantalla("Debe Seleccionar el Correlativo...");
                }
                else
                {
                    if (C.BusquedaGRIDDato(GridComponente, "Descripcion_Componente", ai.Descripcion) == true && (ai.Opcion == 1))
                    {
                        MensajePantalla("Ya ingreso ese Componente");
                    }
                    else
                    {
                        if (x.Creacion_ObjetosRegional(ai, ref er))
                        {
                            Componente.Text = string.Empty;
                            if (Convert.ToInt32(Session["op"].ToString()) == 1)
                            {
                                MensajePantalla("Fue Agregado Correctamente...");
                            }
                            else
                            {
                                MensajePantalla("Fue Actualizado Correctamente...");
                            }
                            insertarComponente.Visible = false;
                            NuevoComponente.Enabled = true;
                            Session["op"] = 1;
                            GridComponente.Visible = true;
                            GridComponente.Rebind();
                            GridComponente.MasterTableView.GetColumn("BotonA").Display = true;
                            GridComponente.MasterTableView.GetColumn("BotonB").Display = true;
                            fillcombo();
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                }                
            }
        }
        protected void GridComponente_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string Cadena = "SELECT IdComponente,Descripcion_Componente,Estado_Componente,(CASE WHEN Estado_Componente = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado," +
                            "ISNULL((ISNULL(com.Descripcion +' '+ CAST(c.Correlativo AS varchar(20)), '')), '') Correlativo,ISNULL(c.Correlativo, 0) Id_correlativo " +
                            "FROM Componente c LEFT JOIN CorrelativoComponente com ON c.Correlativo = com.Id_Correlativo ORDER BY c.Correlativo ";
            procesos.LlenarRadGrid(GridComponente, Cadena);
        }
        protected void Componente_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Componente").ToString()) == 2)
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                 
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_Componente(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdComponente").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Componente").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 5;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridComponente.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdComponente").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Componente").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    NuevoObjetivo.Enabled = false;
                    insertarComponente.Visible = true;
                    Componente.Text = item.GetDataKeyValue("Descripcion_Componente").ToString();
                    CboCorrelativoComponente1.SelectedValue = item.GetDataKeyValue("Id_correlativo").ToString();
                    GridComponente.MasterTableView.GetColumn("BotonA").Display = false;
                    GridComponente.MasterTableView.GetColumn("BotonB").Display = false;
                }
            }
        }
        /*Subcomponentes*/
        private void CboComponente1_TextChanged(object sender, EventArgs e)
        {
            GridSubComponente.MasterTableView.GetColumn("BotonA").Display = false;
            GridSubComponente.MasterTableView.GetColumn("BotonB").Display = false;
            CboComponenteBusqueda.SelectedValue = procesos.IntNULLCombo(CboComponente1).ToString();
            GridSubComponente.Rebind();
            if (GridSubComponente.Items.Count > 0)
            {
                GridSubComponente.Visible = true;
            }
            else
            {               
                GridSubComponente.Visible = false;
            }
        }
        private void CboComponenteBusqueda_TextChanged(object sender, EventArgs e)
        {
            GridSubComponente.Rebind();
            if (GridSubComponente.Items.Count > 0) 
            {
                GridSubComponente.Visible = true;
                GridSubComponente.MasterTableView.GetColumn("BotonA").Display = true;
                GridSubComponente.MasterTableView.GetColumn("BotonB").Display = true;
            }
            else 
            {
                MensajePantalla("No Contiene Un subcomponente Agregado");
                GridSubComponente.Visible = false;
            }
        }
        protected void CancelarSubComponente_Click(object sender, EventArgs e)
        {
            insertarSubComponente.Visible = false;
            NuevoSubComponente.Enabled = true;
            TituloSubcomponente.Visible = true;
            SubComponente.Text = string.Empty;
            CboComponenteBusqueda.Visible = true;
            CboComponente1.ClearSelection();
            cboSubcomponten1.ClearSelection();
            GridSubComponente.MasterTableView.GetColumn("BotonA").Display = true;
            GridSubComponente.MasterTableView.GetColumn("BotonB").Display = true;

            if (Convert.ToInt32(Session["op"].ToString()) == 1)
            {                
                CboComponenteBusqueda.ClearSelection();
                GridSubComponente.Rebind();
                GridSubComponente.Visible = false; 
            }               
        }
        protected void NuevoSubComponente_Click(object sender, EventArgs e)
        {
            insertarSubComponente.Visible = true;
            NuevoSubComponente.Enabled = false;
            TituloSubcomponente.Visible = false;
            SubComponente.Text = string.Empty;                        
            CboComponenteBusqueda.Visible = false;
            CboComponenteBusqueda.ClearSelection();
            CboComponente1.ClearSelection();
            cboSubcomponten1.ClearSelection();
            fillcombo();            
            GridSubComponente.Rebind();
            GridSubComponente.Visible = false;                 
        }        
        protected void GuardarSubComponente_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosRegional ai = new AIObjetosRegional();
            Validacion C = new Validacion();

            ai.Descripcion = SubComponente.Text;
            ai.Dato_2 = procesos.IntNULLCombo(CboComponente1);
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Correlativo = procesos.IntNULLCombo(cboSubcomponten1);
            ai.Tipo = 2;

            if ((ai.Descripcion == string.Empty) || (ai.Dato_2 == 0))
            {
                MensajePantalla("No ha ingresado Todos los datos...");
            }
            else
            {
                if (ai.Correlativo == 0)
                {
                    MensajePantalla("Debe Seleccionar el Correlativo...");
                }
                else
                {
                    if (C.BusquedaGRIDDato(GridSubComponente, "Descripcion_SubComponente", ai.Descripcion) == true && (ai.Opcion == 1))
                    {
                        MensajePantalla("Ya ingreso ese SubComponente");
                    }
                    else
                    {
                        if (x.Creacion_ObjetosRegional(ai, ref er))
                        {
                            SubComponente.Text = string.Empty;
                            CboComponente1.ClearSelection();                            
                            if (Convert.ToInt32(Session["op"].ToString()) == 1)
                            {
                                MensajePantalla("Fue Agregado Correctamente...");
                            }
                            else
                            {
                                MensajePantalla("Fue Actualizado Correctamente...");
                            }
                            insertarSubComponente.Visible = false;
                            NuevoSubComponente.Enabled = true;
                            Session["op"] = 1;
                            GridSubComponente.Visible = true;
                            TituloSubcomponente.Visible = true;
                            CboComponenteBusqueda.Visible = true;
                            CboComponenteBusqueda.SelectedValue = ai.Dato_2.ToString();
                            GridSubComponente.MasterTableView.GetColumn("BotonA").Display = true;
                            GridSubComponente.MasterTableView.GetColumn("BotonB").Display = true;
                            GridSubComponente.Rebind();
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                }
            }
        }
        protected void GridSubComponente_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string Cadena = "SELECT sr.Id_SubComponente,sr.Id_Componente,sr.Descripcion_SubComponente,sr.Estado_SubComponente," +
                            "(CASE WHEN sr.Estado_SubComponente = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado,c.Descripcion_Componente," +
                            "ISNULL((ISNULL(com.Descripcion +' '+ CAST(c.Correlativo AS varchar(20))+'.'+ CAST(sr.Correlativo AS varchar(20)), '')), '') Correlativo," +
                            "ISNULL(sr.Correlativo, 0) Id_correlativo " +
                            "FROM  SubComponenteRegional sr INNER JOIN Componente c ON sr.Id_Componente = c.IdComponente " +
                            "LEFT JOIN CorrelativoSubcomponente com ON sr.Correlativo = com.Id_Correlativo "; 
            
            if (procesos.IntNULLCombo(CboComponenteBusqueda) != 1000)
            {
                Cadena += " WHERE Id_Componente = " + procesos.IntNULLCombo(CboComponenteBusqueda).ToString() + " ORDER BY c.Correlativo,c.IdComponente,sr.Correlativo,sr.Id_SubComponente";
                procesos.LlenarRadGrid(GridSubComponente, Cadena);
            }
            else 
            {
                Cadena += " ORDER BY c.Correlativo,c.IdComponente,sr.Correlativo,sr.Id_SubComponente";
                procesos.LlenarRadGrid(GridSubComponente, Cadena);
            }
        }
        private void GridSubComponente_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridSubComponente.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["Descripcion_Componente"].RowSpan = gridDataItem3["Descripcion_Componente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Componente"].RowSpan + 1;
                        gridDataItem3["Descripcion_Componente"].Visible = false;
                    }

                }
            }
        }
        protected void SubComponente_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_SubComponente").ToString()) == 2)
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                  
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_SubComponente(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_SubComponente").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }

                DatosAI.Opcion = 6;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridSubComponente.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_SubComponente").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    CboComponente1.ClearSelection();
                    cboSubcomponten1.ClearSelection();
                    CboComponenteBusqueda.Visible = false;
                    NuevoSubComponente.Enabled = false;
                    insertarSubComponente.Visible = true;
                    GridSubComponente.MasterTableView.GetColumn("BotonA").Display = false;
                    GridSubComponente.MasterTableView.GetColumn("BotonB").Display = false;
                    SubComponente.Text = item.GetDataKeyValue("Descripcion_SubComponente").ToString();
                    CboComponente1.SelectedValue = item.GetDataKeyValue("Id_Componente").ToString();
                    cboSubcomponten1.SelectedValue = item.GetDataKeyValue("Id_correlativo").ToString();
                    CboComponenteBusqueda.SelectedValue = CboComponente1.SelectedValue;
                    GridSubComponente.Rebind();
                }
            }
        }     
        /*Unidad de Medida*/
        private void CboComponente2_TextChanged(object sender, EventArgs e)
        {
            GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonA").Display = false;
            GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonB").Display = false;
            CboComponenteBusquedaUnidad.SelectedValue = procesos.IntNULLCombo(CboComponente2).ToString();
            string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente2.SelectedItem.Value + " ORDER BY id;";
            procesos.LLenarComboT(cboSubcomponenteUnidad, strsub, "Descripcion", "Id", true);
            GridUnidaMedidaRegional.Rebind();
            if (GridUnidaMedidaRegional.Items.Count > 0)
            {
                GridUnidaMedidaRegional.Visible = true;
            }
            else
            {
                GridUnidaMedidaRegional.Visible = false;
            }
        }       
        private void CboComponenteBusquedaUnidad_TextChanged(object sender, EventArgs e)
        {
            GridUnidaMedidaRegional.Rebind();
            if (GridUnidaMedidaRegional.Items.Count > 0)
            {
                GridUnidaMedidaRegional.Visible = true;
                GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonA").Display = true;
                GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonB").Display = true;
            }
            else
            {
                MensajePantalla("No Contiene Una Unidad de Medida Agregada");
                GridUnidaMedidaRegional.Visible = false;
            }
        }
        protected void CboQuitar() 
        {
            CboComponente2.ClearSelection();
            CboUnidadMedida1.ClearSelection();
            CboTipoConteo.ClearSelection();
            cboSubcomponenteUnidad.ClearSelection();
        }
        protected void CancelarUnidaMedidaRegional_Click(object sender, EventArgs e)
        {
            insertarUnidaMedidaRegional.Visible = false;
            NuevoUnidaMedidaRegional.Enabled = true;
            ComponenteUnidadmedida.Visible = true;
            UnidaMedidaRegional.Text = string.Empty;
            CboQuitar();
            GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonA").Display = true;
            GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonB").Display = true;
            CboComponenteBusquedaUnidad.Visible = true;
            if (Convert.ToInt32(Session["op"].ToString()) == 1) 
            {
                CboComponenteBusquedaUnidad.ClearSelection();
                GridUnidaMedidaRegional.Rebind();
                GridUnidaMedidaRegional.Visible = false;
            }
        }
        protected void NuevoUnidaMedidaRegional_Click(object sender, EventArgs e)
        {
            insertarUnidaMedidaRegional.Visible = true;
            NuevoUnidaMedidaRegional.Enabled = false;
            ComponenteUnidadmedida.Visible = false;
            UnidaMedidaRegional.Text = string.Empty;
            CboComponenteBusquedaUnidad.Visible = false;
            CboComponenteBusquedaUnidad.ClearSelection();            
            fillcombo();
            CboQuitar();
            GridUnidaMedidaRegional.Rebind();
            GridUnidaMedidaRegional.Visible = false;
        }
        protected Validar_Data Validar_UnidaMedidaRegional(AIObjetosRegional d)
        {            
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Descripcion == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la descripcion de la medida.</br>"; }
            if (d.Dato_2 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el componente.</br>"; }
            if (d.Dato_3 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado la unidad de medida.</br>"; }
            if (d.Dato_4 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el subcomponente de la unidad de medida.</br>"; }
            if (d.Dato_5 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el tipo de conteo de la unidad de medida.</br>"; }
            if (d.Descripcion != string.Empty) 
            {
                if (C.BusquedaGRIDDato3(GridUnidaMedidaRegional, "Descripcion_UnidadMedida", "IdTipoUnidad", "IdSubcomponente", d.Descripcion, d.Dato_3,d.Dato_4) == true && (d.Opcion == 1)) 
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresada esa unidad de medida.</br>";
                }                    
            }
            return v;
        }
        protected void GuardarUnidaMedidaRegional_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosRegional ai = new AIObjetosRegional();
            Validar_Data V;

            ai.Descripcion = UnidaMedidaRegional.Text;
            ai.Dato_2 = procesos.IntNULLCombo(CboComponente2);
            ai.Dato_3 = procesos.IntNULLCombo(CboUnidadMedida1); 
            ai.Dato_4 = procesos.IntNULLCombo(cboSubcomponenteUnidad);
            ai.Dato_5 = procesos.IntNULLCombo(CboTipoConteo);
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Tipo = 3;

            V = Validar_UnidaMedidaRegional(ai);
            if (V.Verificar)
            {
                MensajePantalla(V.Mensaje);
            }
            else
            {
                if (x.Creacion_ObjetosRegional(ai, ref er))
                {
                    UnidaMedidaRegional.Text = string.Empty;
                    CboQuitar();
                    if (Convert.ToInt32(Session["op"].ToString()) == 1)
                    {
                        MensajePantalla("Fue Agregado Correctamente...");
                    }
                    else
                    {
                        MensajePantalla("Fue Actualizado Correctamente...");
                    }
                    insertarUnidaMedidaRegional.Visible = false;
                    NuevoUnidaMedidaRegional.Enabled = true;
                    ComponenteUnidadmedida.Visible = true;
                    Session["op"] = 1;
                    GridUnidaMedidaRegional.Visible = true;
                    CboComponenteBusquedaUnidad.Visible = true;
                    CboComponenteBusquedaUnidad.SelectedValue = ai.Dato_2.ToString();
                    GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonA").Display = true;
                    GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonB").Display = true;
                    GridUnidaMedidaRegional.Rebind();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void GridUnidaMedidaRegional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string Cadena = "SELECT um.IdUnidadMedida,um.IdComponente,um.IdTipoUnidad,um.IdSubcomponente,sc.Descripcion_Subcomponente,Isnull(tcr.descripcion_conteo,'')descripcion_conteo,Isnull(um.id_conteo,0) id_conteo," +
                            "um.Descripcion_UnidadMedida,um.Estado_UnidadMedida,(CASE WHEN um.Estado_UnidadMedida = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado,c.Descripcion_Componente,tu.DescripcionTipo " +
                            "FROM Unidad_De_Medida_Regional um INNER JOIN SubComponenteRegional sc ON um.IdSubcomponente = sc.Id_SubComponente "+
                            "INNER JOIN Componente c ON c.IdComponente = sc.Id_Componente INNER JOIN Tipo_UnidadMedida tu ON tu.IdTipoUnidad = um.IdTipoUnidad "+
                            "LEFT JOIN Tipo_ConteoRegional tcr ON tcr.id_conteo = um.id_conteo ";

            if (procesos.IntNULLCombo(CboComponenteBusquedaUnidad) != 1000)
            {
                Cadena += "WHERE um.IdComponente = " + procesos.IntNULLCombo(CboComponenteBusquedaUnidad).ToString() + " ORDER BY c.correlativo,sc.correlativo";
                procesos.LlenarRadGrid(GridUnidaMedidaRegional, Cadena);
            }
            else 
            {
                Cadena += " ORDER BY c.correlativo,sc.correlativo";
                procesos.LlenarRadGrid(GridUnidaMedidaRegional, Cadena + ";");
            }
        }
        private void GridUnidaMedidaRegional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridUnidaMedidaRegional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["IdSubcomponente"].Text == gridDataItem3["IdSubcomponente"].Text)
                    {
                        gridDataItem2["Descripcion_Subcomponente"].RowSpan = gridDataItem3["Descripcion_Subcomponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Subcomponente"].RowSpan + 1;
                        gridDataItem3["Descripcion_Subcomponente"].Visible = false;
                    }
                    if (gridDataItem2["IdComponente"].Text == gridDataItem3["IdComponente"].Text)
                    {
                        gridDataItem2["Descripcion_Componente"].RowSpan = gridDataItem3["Descripcion_Componente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Componente"].RowSpan + 1;
                        gridDataItem3["Descripcion_Componente"].Visible = false;
                    }
                }
            }
        }
        protected void UnidaMedidaRegional_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString()) == 2)
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_UnidaMedidaRegional(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;           
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            GridDataItem item = e.Item as GridDataItem;

            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdUnidadMedida").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 7;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridUnidaMedidaRegional.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdUnidadMedida").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {                    
                    CboComponenteBusquedaUnidad.Visible = false;
                    NuevoUnidaMedidaRegional.Enabled = false;
                    insertarUnidaMedidaRegional.Visible = true;
                    GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonA").Display = false;
                    GridUnidaMedidaRegional.MasterTableView.GetColumn("BotonB").Display = false;
                    UnidaMedidaRegional.Text = item.GetDataKeyValue("Descripcion_UnidadMedida").ToString();
                    CboComponente2.SelectedValue = item.GetDataKeyValue("IdComponente").ToString();
                    string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente2.SelectedItem.Value + " ORDER BY id;";
                    procesos.LLenarComboT(cboSubcomponenteUnidad, strsub, "Descripcion", "Id", true);
                    cboSubcomponenteUnidad.SelectedValue = item.GetDataKeyValue("IdSubcomponente").ToString();
                    CboUnidadMedida1.SelectedValue = item.GetDataKeyValue("IdTipoUnidad").ToString();
                    CboTipoConteo.SelectedValue = item.GetDataKeyValue("id_conteo").ToString();
                    CboComponenteBusquedaUnidad.SelectedValue = CboComponente2.SelectedItem.Value;
                    GridUnidaMedidaRegional.Rebind();
                }
            }
        }
        /*Producto Verificables -Actividades del poa-*/
        private void CboComponente3_TextChanged(object sender, EventArgs e)
        {
            GridProductoVerificable.MasterTableView.GetColumn("BotonA").Display = false;
            GridProductoVerificable.MasterTableView.GetColumn("BotonB").Display = false;
            CboComponenteProductoVerificable.SelectedValue = procesos.IntNULLCombo(CboComponente3).ToString();
            string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente3.SelectedItem.Value + " ORDER BY id;";
            procesos.LLenarComboT(cbosubocomponenteProducto, strsub, "Descripcion", "Id", true);
            GridProductoVerificable.Rebind();
            if (GridProductoVerificable.Items.Count > 0)
            {
                GridProductoVerificable.Visible = true;
            }
            else
            {
                GridProductoVerificable.Visible = false;
            }
        }
        private void CboComponenteProductoVerificable_TextChanged(object sender, EventArgs e)
        {
            GridProductoVerificable.Rebind();
            if (GridProductoVerificable.Items.Count > 0)
            {
                GridProductoVerificable.Visible = true;
                GridProductoVerificable.MasterTableView.GetColumn("BotonB").Display = true;
                GridProductoVerificable.MasterTableView.GetColumn("BotonA").Display = true;
            }
            else
            {
                MensajePantalla("No Contiene Una Actividad Agregado");
                GridProductoVerificable.Visible = false;
            }
        }
        protected void CboQuitarProducto()
        {
            CboComponente3.ClearSelection();
            cbosubocomponenteProducto.ClearSelection();           
        }
        protected void CancelaProductoVerificable_Click(object sender, EventArgs e)
        {
            insertarProductoVerificable.Visible = false;
            NuevoProductoVerificable.Enabled = true;
            ComponenteProductoVerificable.Visible = true;
            ProductoVerficableRegional.Text = string.Empty;
            CboQuitarProducto();
            GridProductoVerificable.MasterTableView.GetColumn("BotonB").Display = true;
            GridProductoVerificable.MasterTableView.GetColumn("BotonA").Display = true;
            CboComponenteProductoVerificable.Visible = true;
            if (Convert.ToInt32(Session["op"].ToString()) == 1)
            {
                CboComponenteProductoVerificable.ClearSelection();
                GridProductoVerificable.Rebind();
                GridProductoVerificable.Visible = false;
            }
        }
        protected void NuevoProductoVerificable_Click(object sender, EventArgs e)
        {
            insertarProductoVerificable.Visible = true;
            NuevoProductoVerificable.Enabled = false;
            ComponenteProductoVerificable.Visible = false;
            ProductoVerficableRegional.Text = string.Empty;
            CboComponenteProductoVerificable.Visible = false;
            CboComponenteProductoVerificable.ClearSelection();
            cboCorrelativoActividad.ClearSelection();
            fillcombo();
            CboQuitarProducto();
            GridProductoVerificable.Rebind();
            GridProductoVerificable.Visible = false;
        }
        protected Validar_Data Validar_ProductoVerificable(AIObjetosRegional d)
        {
            Validar_Data v = new Validar_Data();
            Validacion C = new Validacion();
            v.Verificar = false;

            if (d.Descripcion == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la descripcion del producto verficable.</br>"; }
            if (d.Dato_2 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el componente.</br>"; }           
            if (d.Dato_4 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el subcomponente de la unidad de medida.</br>"; }
            if (d.Correlativo == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Correlativo del producto verificable.</br>"; }
            if (d.Descripcion != string.Empty)
            {
                if (C.BusquedaGRIDDato3(GridUnidaMedidaRegional, "Descripcion_Subcomponente", "IdComponente", "IdSubcomponente", d.Descripcion, d.Dato_2, d.Dato_4) == true && (d.Opcion == 1))
                {
                    v.Verificar = true;
                    v.Mensaje += "Ya fue ingresada esa Actividad.</br>";
                }
            }
            return v;
        }
        protected void GuardarProductoVerificable_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetosRegional ai = new AIObjetosRegional();
            Validar_Data Va;

            ai.Descripcion = ProductoVerficableRegional.Text;
            ai.Dato_2 = procesos.IntNULLCombo(CboComponente3);
            ai.Dato_3 = 0;
            ai.Dato_4 = procesos.IntNULLCombo(cbosubocomponenteProducto);
            ai.Dato_5 = 0;
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Correlativo = procesos.IntNULLCombo(cboCorrelativoActividad);
            ai.Tipo = 4;

            Va = Validar_ProductoVerificable(ai);
            if (Va.Verificar)
            {
                MensajePantalla(Va.Mensaje);
            }
            else
            {
                if (x.Creacion_ObjetosRegional(ai, ref er))
                {
                    ProductoVerficableRegional.Text = string.Empty;
                    CboQuitarProducto();
                    if (Convert.ToInt32(Session["op"].ToString()) == 1)
                    {
                        MensajePantalla("Fue Agregado Correctamente...");
                    }
                    else
                    {
                        MensajePantalla("Fue Actualizado Correctamente...");
                    }
                    insertarProductoVerificable.Visible = false;
                    NuevoProductoVerificable.Enabled = true;
                    ComponenteProductoVerificable.Visible = true;
                    Session["op"] = 1;
                    GridProductoVerificable.Visible = true;
                    CboComponenteProductoVerificable.Visible = true;
                    CboComponenteProductoVerificable.SelectedValue = ai.Dato_2.ToString();
                    GridProductoVerificable.MasterTableView.GetColumn("BotonA").Display = true;
                    GridProductoVerificable.MasterTableView.GetColumn("BotonB").Display = true;
                    GridProductoVerificable.Rebind();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void GridProductoVerificable_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            string Cadena = "SELECT pv.Id_Producto,pv.IdComponente,pv.Id_SubComponente,sc.Descripcion_Subcomponente,c.Descripcion_Componente,pv.Descripcion_Producto,pv.Estado_Producto,"+
                            "(CASE WHEN pv.Estado_Producto = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado," +
                            "ISNULL((ISNULL(com.Descripcion+' '+CAST(c.Correlativo AS varchar(20))+'.'+CAST(sc.Correlativo AS varchar(20)) +'.'+CAST(pv.Correlativo AS varchar(20)), '')), '') Correlativo," +
                            "ISNULL(pv.Correlativo, 0) Id_correlativo " +
                            "FROM Productos_Verificables pv INNER JOIN SubComponenteRegional sc ON pv.Id_Subcomponente = sc.Id_SubComponente INNER JOIN "+
                            "Componente c ON c.IdComponente = sc.Id_Componente LEFT JOIN CorrelativoActividades com ON pv.Correlativo = com.Id_Correlativo ";

            if (procesos.IntNULLCombo(CboComponenteProductoVerificable) != 1000)
            {
                Cadena += "WHERE pv.IdComponente = " + procesos.IntNULLCombo(CboComponenteProductoVerificable).ToString() + " order by c.Correlativo,c.IdComponente,sc.Correlativo,sc.Id_SubComponente,pv.correlativo";

                procesos.LlenarRadGrid(GridProductoVerificable, Cadena);
            }
            else
            {
                Cadena += " order by c.Correlativo,c.IdComponente,sc.Correlativo,sc.Id_SubComponente,pv.correlativo";
                procesos.LlenarRadGrid(GridProductoVerificable, Cadena + ";");
            }
        }
        private void GridProductoVerificable_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridProductoVerificable.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Subcomponente"].Text == gridDataItem3["Id_Subcomponente"].Text)
                    {
                        gridDataItem2["Descripcion_Subcomponente"].RowSpan = gridDataItem3["Descripcion_Subcomponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Subcomponente"].RowSpan + 1;
                        gridDataItem3["Descripcion_Subcomponente"].Visible = false;
                    }
                    if (gridDataItem2["IdComponente"].Text == gridDataItem3["IdComponente"].Text)
                    {
                        gridDataItem2["Descripcion_Componente"].RowSpan = gridDataItem3["Descripcion_Componente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Componente"].RowSpan + 1;
                        gridDataItem3["Descripcion_Componente"].Visible = false;
                    }
                }
            }
        }
        protected void ProductoVerificable_ItemDataBound(object sender, GridItemEventArgs e)
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
        protected void Seleccionar_ProductoVerificable(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;           
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 10;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridProductoVerificable.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("Id_Producto").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Producto").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    cboCorrelativoActividad.ClearSelection(); 
                    CboComponenteProductoVerificable.Visible = false;
                    NuevoProductoVerificable.Enabled = false;
                    insertarProductoVerificable.Visible = true;
                    GridProductoVerificable.MasterTableView.GetColumn("BotonB").Display = false;
                    GridProductoVerificable.MasterTableView.GetColumn("BotonA").Display = false;                    
                    ProductoVerficableRegional.Text = item.GetDataKeyValue("Descripcion_Producto").ToString();
                    CboComponente3.SelectedValue = item.GetDataKeyValue("IdComponente").ToString();
                    string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente3.SelectedItem.Value + " ORDER BY id;";
                    procesos.LLenarComboT(cbosubocomponenteProducto, strsub, "Descripcion", "Id", true);
                    cbosubocomponenteProducto.SelectedValue = item.GetDataKeyValue("Id_SubComponente").ToString();
                    cboCorrelativoActividad.SelectedValue = item.GetDataKeyValue("Id_correlativo").ToString();
                    CboComponenteProductoVerificable.SelectedValue = CboComponente3.SelectedItem.Value;
                    GridProductoVerificable.Rebind();
                }
            }
        }
        /*POAS Nacionales*/
        /*Objetivos*/
        protected void CancelarObjetivo_Click(object sender, EventArgs e)
        {
            insertarobjetivo.Visible = false;
            NuevoObjetivo.Enabled = true;
            Objetivo.Text = string.Empty;
            GridObjetivos.MasterTableView.GetColumn("BotonA").Display = true;
            GridObjetivos.MasterTableView.GetColumn("BotonB").Display = true;
        }
        protected void NuevoObjetivo_Click(object sender, EventArgs e) 
        {
            insertarobjetivo.Visible = true;
            NuevoObjetivo.Enabled = false;
            Objetivo.Text = string.Empty;
            GridObjetivos.MasterTableView.GetColumn("BotonA").Display = false;
            GridObjetivos.MasterTableView.GetColumn("BotonB").Display = false;
        }
        protected void GuardarObjetivo_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetos ai = new AIObjetos();
            Validacion C = new Validacion();

            ai.Descripcion_1 = Objetivo.Text;
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Tipo = 1; 

            if (ai.Descripcion_1 == string.Empty)
            {
                MensajePantalla("No ha ingresado descripción...");
            }
            else
            {
                if (C.BusquedaGRIDDato(GridObjetivos, "Descripcion_Objetivo", ai.Descripcion_1) == true && (ai.Opcion == 1))
                {
                    MensajePantalla("Ya ingreso ese Objetivo");
                }
                {
                    if (x.Creacion_Objetos(ai, ref er))
                    {
                        Objetivo.Text = string.Empty;
                        if (Convert.ToInt32(Session["op"].ToString()) == 1)
                        {
                            MensajePantalla("Fue Agregado Correctamente...");
                        }
                        else
                        {
                            MensajePantalla("Fue Actualizado Correctamente...");
                        }
                        insertarobjetivo.Visible = false;
                        NuevoObjetivo.Enabled = true;
                        Session["op"] = 1;
                        GridObjetivos.Visible = true;
                        GridObjetivos.Rebind();
                        GridObjetivos.MasterTableView.GetColumn("BotonA").Display = true;
                        GridObjetivos.MasterTableView.GetColumn("BotonB").Display = true;
                        fillcombo();
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void GridObjetivos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridObjetivos, "SELECT IdObjetivo,Descripcion_Objetivo,Estado_Objetivo,(CASE WHEN Estado_Objetivo = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado "+
                                                  "FROM Objetivos;");
        }
        protected void GridObjetivos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Objetivo").ToString()) == 2)
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_Objetivos(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;             
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdObjetivo").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Objetivo").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 1;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString()); 

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridObjetivos.Rebind();                   
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1") 
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdObjetivo").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Objetivo").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    NuevoObjetivo.Enabled = false;
                    insertarobjetivo.Visible = true;
                    Objetivo.Text = item.GetDataKeyValue("Descripcion_Objetivo").ToString();
                    GridObjetivos.MasterTableView.GetColumn("BotonA").Display = false;
                    GridObjetivos.MasterTableView.GetColumn("BotonB").Display = false;
                }
            }
        }
        /*Resultado*/
        protected void CancelarResultado_Click(object sender, EventArgs e)
        {
            insertarResultado.Visible = false;
            NuevoResultado.Enabled = true;
            Resultado.Text = string.Empty;
            CboObjetivoResultado.ClearSelection();
            GridResultado.MasterTableView.GetColumn("BotonA").Display = true;
            GridResultado.MasterTableView.GetColumn("BotonB").Display = true;
        }
        protected void NuevoResultado_Click(object sender, EventArgs e)
        {
            insertarResultado.Visible = true;
            NuevoResultado.Enabled = false;
            Resultado.Text = string.Empty;
            CboObjetivoResultado.ClearSelection();
            GridResultado.MasterTableView.GetColumn("BotonA").Display = false;
            GridResultado.MasterTableView.GetColumn("BotonB").Display = false;
        }
        protected void GuardarResultado_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetos ai = new AIObjetos();
            Validacion C = new Validacion();

            ai.Descripcion_1 = Resultado.Text;
            ai.Dato_2 = procesos.IntNULLCombo(CboObjetivoResultado); 
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Tipo = 2;

            if ((ai.Descripcion_1 == string.Empty) || (ai.Dato_2 == 0))
            {
                MensajePantalla("No ha ingresado Todos los datos...");
            }
            else
            {
                if (C.BusquedaGRIDDato2(GridResultado, "Descripcion_Resultado", "IdObjetivo",ai.Descripcion_1, ai.Dato_2) == true && (ai.Opcion == 1))
                {
                    MensajePantalla("Ya fue ingresada ese Resultado.");
                }
                else
                {
                    if (x.Creacion_Objetos(ai, ref er))
                    {
                        Resultado.Text = string.Empty;
                        CboObjetivoResultado.ClearSelection();
                        if (Convert.ToInt32(Session["op"].ToString()) == 1)
                        {
                            MensajePantalla("Fue Agregado Correctamente...");
                        }
                        else
                        {
                            MensajePantalla("Fue Actualizado Correctamente...");
                        }
                        insertarResultado.Visible = false;
                        NuevoResultado.Enabled = true;
                        Session["op"] = 1;
                        GridResultado.Visible = true;
                        GridResultado.Rebind();
                        fillcombo();
                        GridResultado.MasterTableView.GetColumn("BotonA").Display = true;
                        GridResultado.MasterTableView.GetColumn("BotonB").Display = true;
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void GridResultado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridResultado, "SELECT R.IdResultado,R.IdObjetivo,R.Descripcion_Resultado,R.Estado_Resultado,(CASE WHEN R.Estado_Resultado = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado,O.Descripcion_Objetivo " +
                                                  "FROM Resultado R INNER JOIN Objetivos O ON R.IdObjetivo = O.IdObjetivo;");
        }
        private void GridResultado_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridResultado.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["IdObjetivo"].Text == gridDataItem3["IdObjetivo"].Text)
                    {
                        gridDataItem2["Descripcion_Objetivo"].RowSpan = gridDataItem3["Descripcion_Objetivo"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Objetivo"].RowSpan + 1;
                        gridDataItem3["Descripcion_Objetivo"].Visible = false;
                    }

                }
            }
        }
        protected void Resultado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Resultado").ToString()) == 2)
                {                  
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_Resultado(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;           
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdResultado").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Resultado").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 2;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridResultado.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdResultado").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Resultado").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    NuevoResultado.Enabled = false;
                    insertarResultado.Visible = true;
                    Resultado.Text = item.GetDataKeyValue("Descripcion_Resultado").ToString();
                    CboObjetivoResultado.SelectedValue = item.GetDataKeyValue("IdObjetivo").ToString();
                    GridResultado.MasterTableView.GetColumn("BotonA").Display = false;
                    GridResultado.MasterTableView.GetColumn("BotonB").Display = false;
                }
            }
        }
        /*Indicadores*/
        protected void CancelarIndicador_Click(object sender, EventArgs e)
        {
            insertarIndicador.Visible = false;
            NuevoIndicador.Enabled = true;
            Indicador.Text = string.Empty;
            CboResultadoIndicador.ClearSelection();
            GridIndicador.MasterTableView.GetColumn("BotonA").Display = true;
            GridIndicador.MasterTableView.GetColumn("BotonB").Display = true;
        }
        protected void NuevoIndicador_Click(object sender, EventArgs e)
        {
            insertarIndicador.Visible = true;
            NuevoIndicador.Enabled = false;
            Indicador.Text = string.Empty;
            CboResultadoIndicador.ClearSelection();
            GridIndicador.MasterTableView.GetColumn("BotonA").Display = false;
            GridIndicador.MasterTableView.GetColumn("BotonB").Display = false;
        }
        protected void GuardarIndicador_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetos ai = new AIObjetos();
            Validacion C = new Validacion();

            ai.Descripcion_1 = Indicador.Text;
            ai.Dato_2 = procesos.IntNULLCombo(CboResultadoIndicador);
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Tipo = 3;

            if((ai.Descripcion_1 == string.Empty) ||(ai.Dato_2 == 0))
            {
                MensajePantalla("No ha ingresado Todos los datos...");
            }
            else
            {
                if (C.BusquedaGRIDDato2(GridIndicador, "Descripcion_Indicadores", "IdResultado", ai.Descripcion_1, ai.Dato_2) == true && (ai.Opcion == 1))
                {
                    MensajePantalla("Ya fue ingresado ese Indicador.");
                }
                else
                {
                    if (x.Creacion_Objetos(ai, ref er))
                    {
                        Indicador.Text = string.Empty;
                        CboResultadoIndicador.ClearSelection();
                        if (Convert.ToInt32(Session["op"].ToString()) == 1)
                        {
                            MensajePantalla("Fue Agregado Correctamente...");
                        }
                        else
                        {
                            MensajePantalla("Fue Actualizado Correctamente...");
                        }
                        insertarIndicador.Visible = false;
                        NuevoIndicador.Enabled = true;
                        Session["op"] = 1;
                        GridIndicador.Visible = true;
                        GridIndicador.Rebind();
                        GridIndicador.MasterTableView.GetColumn("BotonA").Display = true;
                        GridIndicador.MasterTableView.GetColumn("BotonB").Display = true;
                    }
                    else
                    {
                        MensajePantalla(er.Descripcion.ToString());
                    }
                }
            }
        }
        protected void GridIndicador_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridIndicador, "SELECT I.IdIndicadores,I.IdResultado,I.Descripcion_Indicadores,I.Estado_Indicadores,(CASE WHEN I.Estado_Indicadores = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado,R.Descripcion_Resultado " +
                                                  "FROM Indicadores I INNER JOIN Resultado R ON I.IdResultado = R.IdResultado;");
        }
        private void GridIndicador_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GridIndicador.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["IdResultado"].Text == gridDataItem3["IdResultado"].Text)
                    {
                        gridDataItem2["Descripcion_Resultado"].RowSpan = gridDataItem3["Descripcion_Resultado"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Descripcion_Resultado"].RowSpan + 1;
                        gridDataItem3["Descripcion_Resultado"].Visible = false;
                    }

                }
            }
        }
        protected void Indicador_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                if (Convert.ToInt32(item.GetDataKeyValue("Estado_Indicadores").ToString()) == 2)
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                    
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_Indicador(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;
            int Cambio_Estado;        
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            GridDataItem item = e.Item as GridDataItem;

            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdIndicadores").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Indicadores").ToString());

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 3;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridIndicador.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdIndicadores").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_Indicadores").ToString());
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    NuevoIndicador.Enabled = false;
                    insertarIndicador.Visible = true;
                    Indicador.Text = item.GetDataKeyValue("Descripcion_Indicadores").ToString();
                    CboResultadoIndicador.SelectedValue = item.GetDataKeyValue("IdResultado").ToString();
                    GridIndicador.MasterTableView.GetColumn("BotonA").Display = false;
                    GridIndicador.MasterTableView.GetColumn("BotonB").Display = false;
                }
            }
        }
        /*Unidad de Medida Poa Nacional*/
        protected void CancelarUnidadMedidaPN_Click(object sender, EventArgs e)
        {
            insertarUnidadMedidaPN.Visible = false;
            NuevoUnidadMedidaPN.Enabled = true;
            UnidadMedidaPN.Text = string.Empty;
        }
        protected void NuevoUnidadMedidaPN_Click(object sender, EventArgs e)
        {
            insertarUnidadMedidaPN.Visible = true;
            NuevoUnidadMedidaPN.Enabled = false;
            UnidadMedidaPN.Text = string.Empty;
            TipoDeConteoNacional.ClearSelection();
        }
        protected void GuardarUnidadMedidaPN_Click(object sender, EventArgs e)
        {
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();
            AIObjetos ai = new AIObjetos();
            Validacion C = new Validacion();

            ai.Descripcion_1 = UnidadMedidaPN.Text;
            ai.Opcion = Convert.ToInt32(Session["op"].ToString());
            ai.Dato_1 = Convert.ToInt32(Session["CodigoCambia"].ToString());
            ai.Dato_3 = procesos.IntNULLCombo(TipoDeConteoNacional); 
            ai.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());
            ai.Tipo = 4;

            if (ai.Descripcion_1 == string.Empty)
            {
                MensajePantalla("No ha ingresado descripción...");
            }
            else
            {
                if (ai.Dato_3 == 0)
                {
                    MensajePantalla("Debe Seleccionar el tipo de conteo...");
                }
                else
                {

                    if (C.BusquedaGRIDDato(GridUnidadMedidaPN, "Descripcion_UnidadMedida", ai.Descripcion_1) == true && (ai.Opcion == 1))
                    {
                        MensajePantalla("Ya ingreso ese Componente");
                    }
                    else
                    {
                        if (x.Creacion_Objetos(ai, ref er))
                        {
                            UnidadMedidaPN.Text = string.Empty;
                            TipoDeConteoNacional.ClearSelection();
                            if (Convert.ToInt32(Session["op"].ToString()) == 1)
                            {
                                MensajePantalla("Fue Agregado Correctamente...");
                            }
                            else
                            {
                                MensajePantalla("Fue Actualizado Correctamente...");
                            }
                            insertarUnidadMedidaPN.Visible = false;
                            NuevoUnidadMedidaPN.Enabled = true;
                            Session["op"] = 1;
                            GridUnidadMedidaPN.Rebind();
                            GridUnidadMedidaPN.Visible = true;
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                }
            }
        }
        protected void GridUnidadMedidaPN_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GridUnidadMedidaPN, "SELECT UDMN.IdUnidadMedida,UDMN.Descripcion_UnidadMedida,UDMN.Estado_UnidadMedida," +
                "(CASE WHEN UDMN.Estado_UnidadMedida = 1 THEN 'ACTIVADO' ELSE 'DESACTIVADO' END) Estado," +
                "UDMN.Tipodeconteo, TCR.Descripcion_Conteo FROM Unidad_De_Medida_Nacional UDMN INNER JOIN Tipo_ConteoRegional TCR ON UDMN.Tipodeconteo = TCR.Id_Conteo;");
        }
        protected void UnidadMedidaPN_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                if (Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString()) == 2)
                {                   
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/off.png";
                }
                else
                {                 
                    (item["BotonA"].Controls[0] as ImageButton).ImageUrl = "../Iconos/on.png";
                }
            }
        }
        protected void Seleccionar_UnidadMedidaPN(object sender, GridCommandEventArgs e)
        {
            int Codigo;
            int Estado;           
            int Cambio_Estado;     
            Mensajes_Error_BDD Error = new Mensajes_Error_BDD();
            Manejo_De_Mantenimiento_PoaNacional x = new Manejo_De_Mantenimiento_PoaNacional();

            GridDataItem item = e.Item as GridDataItem;
            if (e.CommandName == "Select")
            {
                Codigo = Convert.ToInt32(item.GetDataKeyValue("IdUnidadMedida").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString());
               

                if (Estado == 2)
                {
                    Cambio_Estado = 1;
                }
                else
                {
                    Cambio_Estado = 2;
                }
                DatosAI.Opcion = 4;
                DatosAI.Dato_1 = Codigo;
                DatosAI.Dato_2 = Cambio_Estado;             
                DatosAI.Idusuario = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Activar_Desactivar(DatosAI, ref Error))
                {
                    GridUnidadMedidaPN.Rebind();
                }
                else
                {
                    MensajePantalla(Error.Descripcion.ToString());
                }
            }
            if (e.CommandName == "Select1")
            {
                Session["CodigoCambia"] = Convert.ToInt32(item.GetDataKeyValue("IdUnidadMedida").ToString());
                Estado = Convert.ToInt32(item.GetDataKeyValue("Estado_UnidadMedida").ToString());
                TipoDeConteoNacional.SelectedValue = item.GetDataKeyValue("Tipodeconteo").ToString();              
                Session["op"] = 2;

                if (Estado == 2)
                {
                    MensajePantalla("Esta Desactivado no se puede Editar.......");
                }
                else
                {
                    NuevoUnidadMedidaPN.Enabled = false;
                    insertarUnidadMedidaPN.Visible = true;
                    UnidadMedidaPN.Text = item.GetDataKeyValue("Descripcion_UnidadMedida").ToString();
                }
            }
        }
    }
}