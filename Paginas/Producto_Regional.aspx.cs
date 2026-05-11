using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{   
    public partial class Producto_Regional : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 500,200, "Alerta", null);
                return;
            }
        }
        protected void Cancelarproducto_Click(object sender, EventArgs e)
        {
            Limpiar_Objetos();
            Session["opcion"] = 0;
            CombosAI(2);
            GdrProductoRegional.Rebind();
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Limpiar_Objetos();
            Response.Redirect("Creacion_Poas.aspx");
        }        
        protected int VerificarCheck(int op) 
        {
            int Valor = 0;

            if(op == 1) 
            {
                if (chkRedProgramatica.Checked == true)
                {
                    Valor = 1;
                }
                else
                {
                    Valor = 0;
                }
            }
            if (op == 2) 
            {
                if (chkNoPlanificable.Checked == true)
                {
                    Valor = 1;
                }
                else
                {
                    Valor = 0;
                }
            }
            return Valor;
        }
        protected Validar_Data Validar_Producto(ProductoRegional pr)
        {
            Manejo_Datos_ProductoRegional mdpr = new Manejo_Datos_ProductoRegional();
            DproductoEnvio Dpe = new DproductoEnvio();           
            Validar_Data v = new Validar_Data();           

            Dpe.Id_Componente = pr.Id_Componente;
            Dpe.Id_SubComponente = pr.Id_SubComponente;
            Dpe.Id_ProductoVeficable = pr.Id_ProductoVeficable;

            if (pr.Id_Componente == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Componente del producto.</br>"; }
            if (pr.Id_SubComponente == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Subcomponente del producto.</br>"; }
            if (pr.Id_ProductoVeficable == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado el Producto verificable.</br>"; }
            if (pr.Id_UM1 == 0 && pr.Id_UM2 == 0 && pr.Id_UM3 == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado una unidad de medida -UM-.</br>"; }
            if (pr.Id_UnidadMedida == 0) { v.Verificar = true; v.Mensaje += "No ha seleccionado una unidad de medida evaluada.</br>"; }
            if (pr.MedioDeVerificacion == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado el medio de verificación.</br>"; }
            if (pr.DireccionMedioVerificacion == string.Empty) { v.Verificar = true; v.Mensaje += "No ha ingresado la direccion del medio de verificación.</br>"; }

            if (Convert.ToInt32(Session["opcion"].ToString()) == 0)
            {
                if (pr.Id_Componente != 0 && pr.Id_UM2 != 0 && pr.Id_UM3 != 0)
                {
                    if (mdpr.Verficar_IngresoProducto(mdpr.Obtener_Productos(pr.Id_PoAnual), Dpe) == true) 
                    { 
                        v.Verificar = true; v.Mensaje += "Ese Producto Regional ya fue ingresado en este POA.</br>"; 
                    }
                }
            }
            return v;
        }
        protected void GuardarProducto_Click(object sender, EventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();
            Manejo_Datos_ProductoRegional mdpr = new Manejo_Datos_ProductoRegional();
            ProductoRegional p = new ProductoRegional();
            Validar_Data V;

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 16).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                p.Id_Componente = procesos.IntNULLCombo(CboComponente);
                p.DescripcionComponente = procesos.StrNULLCombo(CboComponente);
                p.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente);
                p.DescripcionSubComponente = procesos.StrNULLCombo(CboSubcomponente);
                p.Id_ProductoVeficable = procesos.IntNULLCombo(CboProducto);
                p.DescripcionProductoVeficable = procesos.StrNULLCombo(CboProducto);
                p.Id_MetasRedProgramatica = VerificarCheck(1);
                p.Id_NoPlanificable = VerificarCheck(2);
                p.Id_UM1 = procesos.IntNULLCombo(RadUM1);
                p.DescripcionUM1 = procesos.StrNULLCombo(RadUM1);
                p.Id_UM2 = procesos.IntNULLCombo(RadUM2);
                p.DescripcionUM2 = procesos.StrNULLCombo(RadUM2);
                p.Id_UM3 = procesos.IntNULLCombo(RadUM3);
                p.DescripcionUM3 = procesos.StrNULLCombo(RadUM3);
                p.Id_UnidadMedida = procesos.IntNULLCombo(CboUnidadMedidaEvaludada);
                p.DescripcionUnidadMedida = procesos.StrNULLCombo(CboUnidadMedidaEvaludada);
                p.MedioDeVerificacion = MedioVerficacion.Text.Trim();
                p.DireccionMedioVerificacion = DireccionMedioV.Text.Trim();
                p.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                p.Id_PoAnual = Convert.ToInt32(Session["CodigoPoa"].ToString());
                p.anioPoa = Convert.ToInt32(Session["anioPoa"].ToString());
                p.CorrelativoC = x.Obtener_Correlativo(1, p.Id_Componente);
                p.CorrelativoSC = x.Obtener_Correlativo(2, p.Id_SubComponente);
                p.CorrelativoPC = x.Obtener_Correlativo(3, p.Id_ProductoVeficable);

                V = Validar_Producto(p);
                if (V.Verificar)
                {
                    MensajePantalla(V.Mensaje);
                }
                else
                {
                    XmlDocument DescripcionProducto = mdpr.DetalleXMLProducto(mdpr.Agregar_ProductoLista(p));

                    if (Convert.ToInt32(Session["opcion"].ToString()) == 0)
                    {
                        if (x.Ingreso_de_productoPOA(1,p,0, DescripcionProducto, ref er))
                        {
                            MensajePantalla("Se ha agregado el Producto Correctamente...");
                            Session["opcion"] = 0;
                            GdrProductoRegional.Visible = Visible;
                            GdrProductoRegional.Rebind();
                            Limpiar_Objetos();
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                    else 
                    {
                        if (x.Ingreso_de_productoPOA(2, p,Convert.ToInt32(Session["idProducto"].ToString()), DescripcionProducto, ref er))
                        {
                            MensajePantalla("Se ha Editado el Producto Correctamente...");
                            Session["opcion"] = 0;
                            GdrProductoRegional.Visible = Visible;
                            GdrProductoRegional.Rebind();
                            Limpiar_Objetos();
                            CombosAI(2);
                        }
                        else
                        {
                            MensajePantalla(er.Descripcion.ToString());
                        }
                    }
                }
            }           
        }
        protected void Limpiar_Objetos() 
        {
            CboComponente.ClearSelection();
            CboUnidadMedidaEvaludada.ClearSelection();      
            CboSubcomponente.ClearSelection();
            CboSubcomponente.Items.Clear();
            CboProducto.ClearSelection();
            CboProducto.Items.Clear();
            RadUM1.ClearSelection();
            RadUM2.ClearSelection();
            RadUM3.ClearSelection();
            RadUM1.Items.Clear();
            RadUM2.Items.Clear();
            RadUM3.Items.Clear();
            RadUM1.Visible = true; 
            U1.Visible = true;
            RadUM2.Visible = true;
            U2.Visible = true;
            RadUM3.Visible = true; 
            U3.Visible = true;
            MedioVerficacion.Text = string.Empty;
            DireccionMedioV.Text = string.Empty;
            chkRedProgramatica.Checked = false;
            chkNoPlanificable.Checked = false;           
        }        
        protected void Fillcombo()
        {        
            string stringComando = "SELECT IdComponente Id,Descripcion_Componente Descripcion FROM Componente WHERE Estado_Componente = 1 ORDER BY correlativo;";           
            procesos.LLenarComboT(CboComponente, stringComando, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboUnidadMedidaEvaludada, "SELECT IdTipoUnidad AS id,DescripcionExtra AS Descripcion FROM Tipo_UnidadMedida", "Descripcion", "Id", true);
            Session["opcion"] = 0;
            Session["idProducto"] = 0;
        }
        protected void Inicializacion_Objetos()
        {
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            Cancelarproducto.Click += new EventHandler(Cancelarproducto_Click);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GuardarProducto.Click += new EventHandler(GuardarProducto_Click);
            GdrProductoRegional.NeedDataSource += new GridNeedDataSourceEventHandler(GdrProductoRegional_NeedDataSource);
            GdrProductoRegional.DeleteCommand += new GridCommandEventHandler(Eliminar_Producto);
            GdrProductoRegional.ItemDataBound += GdrProductoRegional_ItemDataBound;
            GdrProductoRegional.ItemCommand += new GridCommandEventHandler(Seleccionar_Producto);
            GdrProductoRegional.PreRender += new EventHandler(GdrProductoRegional_PreRender);
        }
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {           
            string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente.SelectedItem.Value + " ORDER BY correlativo;";
            procesos.LLenarComboT(CboSubcomponente, strsub, "Descripcion", "Id", true);            
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            string strsub = "SELECT Id_Producto AS id,Descripcion_Producto AS Descripcion  FROM Productos_Verificables WHERE Estado_Producto = 1 AND IdComponente = " + CboComponente.SelectedItem.Value +
                            "AND Id_SubComponente = " + CboSubcomponente.SelectedItem.Value + "ORDER BY correlativo;";
            procesos.LLenarComboT(CboProducto, strsub, "Descripcion", "Id", true);

            String strsub2 = "SELECT IdUnidadMedida AS id,Descripcion_UnidadMedida AS Descripcion FROM Unidad_De_Medida_Regional WHERE Estado_UnidadMedida = 1 AND IdComponente = " + CboComponente.SelectedItem.Value + " " +
                             "AND IdSubComponente = " + CboSubcomponente.SelectedItem.Value;           
            procesos.LLenarComboT(RadUM1, strsub2 + " AND IdTipoUnidad = 1 ORDER BY id;", "Descripcion", "Id", true);
            procesos.LLenarComboT(RadUM2, strsub2 + " AND IdTipoUnidad = 2 ORDER BY id;", "Descripcion", "Id", true);
            procesos.LLenarComboT(RadUM3, strsub2 + " AND IdTipoUnidad = 3 ORDER BY id;", "Descripcion", "Id", true);
            Ver_CombosUM();              
        }
        protected void Ver_CombosUM() 
        {
            if (RadUM1.Items.Count == 0) { RadUM1.Visible = false; U1.Visible = false; } else { RadUM1.Visible = true; U1.Visible = true; }
            if (RadUM2.Items.Count == 0) { RadUM2.Visible = false; U2.Visible = false; } else { RadUM2.Visible = true; U2.Visible = true; }
            if (RadUM3.Items.Count == 0) { RadUM3.Visible = false; U3.Visible = false; } else { RadUM3.Visible = true; U3.Visible = true; }
        }
        protected void GdrProductoRegional_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            procesos.LlenarRadGrid(GdrProductoRegional,"EXEC Sp_obtener_data_Productos "+ Convert.ToInt32(Session["CodigoPoa"].ToString())+";");
        }
        private void GdrProductoRegional_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GdrProductoRegional.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Componente"].Text == gridDataItem3["Id_Componente"].Text)
                    {
                        gridDataItem2["DescripcionComponente"].RowSpan = gridDataItem3["DescripcionComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionComponente"].Visible = false;
                    }
                    if (gridDataItem2["Id_Subcomponente"].Text == gridDataItem3["Id_Subcomponente"].Text)
                    {
                        gridDataItem2["DescripcionSubComponente"].RowSpan = gridDataItem3["DescripcionSubComponente"].RowSpan < 2
                        ? 2
                        : gridDataItem3["DescripcionSubComponente"].RowSpan + 1;
                        gridDataItem3["DescripcionSubComponente"].Visible = false;
                    }                    
                }
            }
        }
        protected void GdrProductoRegional_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["DescripcionProductoVeficable"];
                TableCell cell2 = item["DescripcionUM1"];
                TableCell cell3 = item["DescripcionUM2"];
                TableCell cell4 = item["DescripcionUM3"];
                TableCell cell5 = item["DescripcionUnidadMedida"];
                TableCell cell6 = item["MedioDeVerificacion"];

                if (Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString()) == 1) 
                {
                    cell1.BackColor = Color.Aquamarine;
                    cell1.Font.Bold = true; 
                    cell2.BackColor = Color.Aquamarine;
                    cell2.Font.Bold = true;
                    cell3.BackColor = Color.Aquamarine;
                    cell3.Font.Bold = true;
                    cell4.BackColor = Color.Aquamarine;
                    cell4.Font.Bold = true;
                    cell5.BackColor = Color.Aquamarine;
                    cell5.Font.Bold = true;
                    cell6.BackColor = Color.Aquamarine;
                    cell6.Font.Bold = true;                  
                }                               
            }                       
        }
        protected void VerificargRID()
        {
            GdrProductoRegional.Rebind();
            if (GdrProductoRegional.Items.Count != 0) { GdrProductoRegional.Visible = true; } else { GdrProductoRegional.Visible = false; }                      
        }
        protected void Eliminar_Producto(object source, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Manejo_Creacion_Poas x = new Manejo_Creacion_Poas();
            DproductoEnvio Dpe = new DproductoEnvio();                        

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 16).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                Dpe.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());
                Dpe.Id_SubComponente = Convert.ToInt32(item.GetDataKeyValue("Id_SubComponente").ToString());
                Dpe.Id_ProductoVeficable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                int Id_poa = Convert.ToInt32(Session["CodigoPoa"].ToString());
                int Id_usu = Convert.ToInt32(Session["Usuario"].ToString());

                if (x.Eliminacion_ProductoPOABDD(Id_poa, Id_usu, Dpe.Id_ProductoVeficable, ref er))
                {
                    GdrProductoRegional.Rebind();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
                if (GdrProductoRegional.Items.Count == 0)
                {
                    GdrProductoRegional.Visible = false;
                }
                else
                {
                    GdrProductoRegional.Visible = Visible;
                }
            }
        }
        protected void Seleccionar_Producto(object sender, GridCommandEventArgs e)
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item = e.Item as GridDataItem;                      
            if (e.CommandName == "Select")
            {                                            
                Session["opcion"] = 1;               

                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 19).Permiso != true)
                {
                    MensajePantalla("no tiene Permisos.......");
                }
                else
                {
                    Session["idProducto"] = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());  
                    CboComponente.SelectedValue = item.GetDataKeyValue("Id_Componente").ToString();
                    string strsub = "SELECT Id_Subcomponente Id,Descripcion_Subcomponente Descripcion FROM SubComponenteRegional WHERE Estado_Subcomponente = 1 AND Id_Componente =" + CboComponente.SelectedItem.Value + " ORDER BY id;";
                    procesos.LLenarComboT(CboSubcomponente, strsub, "Descripcion", "Id", true);
                    CboSubcomponente.SelectedValue = item.GetDataKeyValue("Id_SubComponente").ToString();
                    string strsub1 = "SELECT Id_Producto AS id,Descripcion_Producto AS Descripcion  FROM Productos_Verificables WHERE Estado_Producto = 1 AND IdComponente = " + CboComponente.SelectedItem.Value +
                            "AND Id_SubComponente = " + CboSubcomponente.SelectedItem.Value + "ORDER BY id;";
                    procesos.LLenarComboT(CboProducto, strsub1, "Descripcion", "Id", true);
                    CboProducto.SelectedValue = item.GetDataKeyValue("Id_ProductoVeficable").ToString();

                    if(Convert.ToInt32(item.GetDataKeyValue("Id_MetasRedProgramatica").ToString()) == 1) 
                    {
                        chkRedProgramatica.Checked = true;
                    }
                    else 
                    {
                        chkRedProgramatica.Checked = false;
                    }
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString()) == 1)
                    {
                        chkNoPlanificable.Checked = true;
                    }
                    else
                    {
                        chkNoPlanificable.Checked = false;
                    }
                    string Strsub3 = "SELECT IdUnidadMedida AS id,Descripcion_UnidadMedida AS Descripcion FROM Unidad_De_Medida_Regional WHERE Estado_UnidadMedida = 1 AND IdComponente = " + CboComponente.SelectedItem.Value + " " +
                             "AND IdSubComponente = " + CboSubcomponente.SelectedItem.Value;
                    procesos.LLenarComboT(RadUM1, Strsub3 + " AND IdTipoUnidad = 1 ORDER BY id;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(RadUM2, Strsub3 + " AND IdTipoUnidad = 2 ORDER BY id;", "Descripcion", "Id", true);
                    procesos.LLenarComboT(RadUM3, Strsub3 + " AND IdTipoUnidad = 3 ORDER BY id;", "Descripcion", "Id", true);
                    Ver_CombosUM();

                    RadUM1.SelectedValue = item.GetDataKeyValue("Id_UM1").ToString();
                    RadUM2.SelectedValue = item.GetDataKeyValue("Id_UM2").ToString();
                    RadUM3.SelectedValue = item.GetDataKeyValue("Id_UM3").ToString();
      
                    CboUnidadMedidaEvaludada.SelectedValue = item.GetDataKeyValue("Id_UnidadMedida").ToString();
                    MedioVerficacion.Text = item.GetDataKeyValue("MedioDeVerificacion").ToString();
                    DireccionMedioV.Text = item.GetDataKeyValue("DireccionMedioVerificacion").ToString();

                    CombosAI(1);
                }                               
            }
        }
        private void  CombosAI(int op)
        {
            if(op == 1) 
            {
                CboComponente.Enabled = false;
                CboSubcomponente.Enabled = false;
                GdrProductoRegional.MasterTableView.GetColumn("BotonA").Display = false;
                GdrProductoRegional.MasterTableView.GetColumn("BotonB").Display = false;
            }
            else 
            {
                CboComponente.Enabled = true;
                CboSubcomponente.Enabled = true;
                GdrProductoRegional.MasterTableView.GetColumn("BotonA").Display = true;
                GdrProductoRegional.MasterTableView.GetColumn("BotonB").Display = true;
            }
        }
        protected void VericarPermiso()
        {
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 11).Permiso != true)
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
                Lanio.Text = "PLAN OPERATIVO ANUAL " + Session["anioPoa"].ToString();               
                Fillcombo();
                VerificargRID();
            }
        }       
    }
}