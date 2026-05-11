using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class ConsultadePoaRegionales : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 400, 180, "Alerta", null);
                return;
            }
        }
        protected void Inicializacion_Objetos()
        {
            RadRegion.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegion.ItemCommand += new GridCommandEventHandler(RadRegion_ItemCommand);
            RadRegion.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);
            CboComponente.TextChanged += new EventHandler(CboComponente_TextChanged);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            GdrDatosdeActividades.NeedDataSource += new GridNeedDataSourceEventHandler(GdrDatosdeActividades_NeedDataSource);
            GdrDatosdeActividades.ItemDataBound += GdrDatosdeActividades_ItemDataBound;
            GridUnidades.NeedDataSource += new GridNeedDataSourceEventHandler(GridUnidades_NeedDataSource);
            GdrDatosdeActividades.ItemCommand += new GridCommandEventHandler(Seleccionar_Actividad);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            /**/
            RadRegion2.NeedDataSource += new GridNeedDataSourceEventHandler(RadRegion_NeedDataSource);
            RadRegion2.ItemCommand += new GridCommandEventHandler(RadRegion2_ItemCommand);
            RadRegion2.DetailTableDataBind += new GridDetailTableDataBindEventHandler(RadRegion_DetailTableDataBind);           
            RegresarPantallaanterior2.Click += new EventHandler(RegresarPantallaanterior2_Click);
            CboComponente1.TextChanged += new EventHandler(CboComponente1_TextChanged);
            CboSubcomponente1.TextChanged += new EventHandler(CboSubcomponente1_TextChanged);
            GrdProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GrdProductos_NeedDataSource);
            GrdProductos.ItemCommand += new GridCommandEventHandler(Seleccionar_Productos);
            CerrarVentana.Click += new EventHandler(CerrarVentana_Click);
            BtnRegresarpantallaProducto.Click += new EventHandler(BtnRegresarpantallaProducto_Click);
            /*moni*/
            GrdConsultaProbosque.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaProbosque.ItemDataBound += GrdConsultaProbosque_ItemDataBound;
            GrdConsultaProbosque.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsProbosque);
            GrdConsultaRNF.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaRNF.ItemDataBound += GrdConsultaRNF_ItemDataBound;
            GrdConsultaRNF.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsRNF);
            GrdConsultaPINPEP.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaPINPEP.ItemDataBound += GrdConsultaPINPEP_ItemDataBound;
            GrdConsultaPINPEP.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsPINPEP);
            GrdConsultaMonitoreo.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaMonitoreo.ItemDataBound += GrdConsultaMonitoreo_ItemDataBound;
            GrdConsultaMonitoreo.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsMonitoreo);
            GrdConsultaExentos.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaExentos.ItemDataBound += GrdConsultaExentos_ItemDataBound;
            GrdConsultaExentos.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsExentos);
            GrdConsultaReduccionEmisiones.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaReduccionEmisiones.ItemDataBound += GrdConsultaReduccionEmisiones_ItemDataBound;
            GrdConsultaReduccionEmisiones.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsReduccionEmisiones);
            GrdConsultaJuridico.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaJuridico.ItemDataBound += GrdConsultaJuridico_ItemDataBound;
            GrdConsultaJuridico.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsJuridico);
            GrdConsultaMangle.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaMangle.ItemDataBound += GrdConsultaMangle_ItemDataBound;
            GrdConsultaMangle.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsMangle);
            GrdConsultaCapacitacion.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaCapacitacion.ItemDataBound += GrdConsultaCapacitacion_ItemDataBound;
            GrdConsultaCapacitacion.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsCapacitacion);
            GrdConsultaPPMF.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaPPMF.ItemDataBound += GrdConsultaPPMF_ItemDataBound;
            GrdConsultaPPMF.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsPPMF);
            GrdConsultaPinabete.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaPinabete.ItemDataBound += GrdConsultaPinabete_ItemDataBound;
            GrdConsultaPinabete.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsPinabete);
            GrdConsultaProteccion.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaProteccion.ItemDataBound += GrdConsultaProteccion_ItemDataBound;
            GrdConsultaProteccion.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsProteccion);
            GrdConsultaCulturaForestal.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaCulturaForestal.ItemDataBound += GrdConsultaCulturaForestal_ItemDataBound;
            GrdConsultaCulturaForestal.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsCulturaForestal);
            GrdConsultaIncentivoForestal.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaIncentivoForestal.ItemDataBound += GrdConsultaIncentivoForestal_ItemDataBound;
            GrdConsultaIncentivoForestal.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsIncentivoForestal);
            GrdConsultaFiscalizacionControl.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaFiscalizacionControl.ItemDataBound += GrdConsultaFiscalizacionControl_ItemDataBound;
            GrdConsultaFiscalizacionControl.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsFiscalizacionControl);
            GrdConsultaFortalecimiento.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaFortalecimiento.ItemDataBound += GrdConsultaFortalecimiento_ItemDataBound;
            GrdConsultaFortalecimiento.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsFortalecimiento);
            GrdConsultaIndustriaCom.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaIndustriaCom.ItemDataBound += GrdConsultaIndustriaCom_ItemDataBound;
            GrdConsultaIndustriaCom.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsIndustriaCom);
            GrdConsultaLicenciaF.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaLicenciaF.ItemDataBound += GrdConsultaLicenciaF_ItemDataBound;
            GrdConsultaLicenciaF.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsLicenciaF);
            GrdConsultaConsumoFamiliar.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdConsultaConsumoFamiliar.ItemDataBound += GrdConsultaConsumoFamiliar_ItemDataBound;
            GrdConsultaConsumoFamiliar.ItemCommand += new GridCommandEventHandler(Seleccionar_ItemsConsumoFamiliar);
            /*detalle*/
            BtnOcultar.Click += new EventHandler(BtnOcultar_Click);
            GrdModalidadArea.NeedDataSource += new GridNeedDataSourceEventHandler(GrdModalidadArea_NeedDataSource);
            GrdModalidadArea.PreRender += new EventHandler(GrdModalidadArea_PreRender);
            GrdActores.NeedDataSource += new GridNeedDataSourceEventHandler(GrdActores_NeedDataSource);
            GrdActores.PreRender += new EventHandler(GrdActores_PreRender);
            GrdParticipantes.NeedDataSource += new GridNeedDataSourceEventHandler(GrdParticipantes_NeedDataSource);           
            GrdParticipantes.PreRender += new EventHandler(GrdParticipantes_PreRender);
            GrdPertencia.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPertencia_NeedDataSource);            
            GrdPertencia.PreRender += new EventHandler(GrdPertencia_PreRender);            
            GrdNotas.NeedDataSource += new GridNeedDataSourceEventHandler(GrdNotas_NeedDataSource);
            GrdNotas.PreRender += new EventHandler(GrdNotas_PreRender);           
            GrdPublicidad.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPublicidad_NeedDataSource);
            GrdPublicidad.PreRender += new EventHandler(GrdPublicidad_PreRender);            
            GrdPublico.NeedDataSource += new GridNeedDataSourceEventHandler(GrdPublico_NeedDataSource);
            GrdPublico.PreRender += new EventHandler(GrdPublico_PreRender);            
            GrdMaterial.NeedDataSource += new GridNeedDataSourceEventHandler(GrdMaterial_NeedDataSource);
            GrdMaterial.PreRender += new EventHandler(GrdMaterial_PreRender);            
            GrdCampaniaPub.NeedDataSource += new GridNeedDataSourceEventHandler(GrdCampaniaPub_NeedDataSource);
            GrdCampaniaPub.PreRender += new EventHandler(GrdCampaniaPub_PreRender);            
            GrdNotasPosiNega.NeedDataSource += new GridNeedDataSourceEventHandler(GrdNotasPosiNega_NeedDataSource);
            GrdNotasPosiNega.PreRender += new EventHandler(GrdNotasPosiNega_PreRender);
            GrdRendimiento.NeedDataSource += new GridNeedDataSourceEventHandler(GrdRendimiento_NeedDataSource);
            GrdRendimiento.PreRender += new EventHandler(GrdRendimiento_PreRender);           
        }
        protected void BtnRegresarpantallaProducto_Click(object sender, EventArgs e)
        {
            RegionesMonitoreosDetalle.Visible = true;
            DetalleDeEjecucionMensual.Visible = false;
            Personas.Visible = false;
        }
        protected void Ocultar() 
        {
            GrdConsultaMonitoreo.Visible = false;
            GrdConsultaPINPEP.Visible = false;
            GrdConsultaProbosque.Visible = false;
            GrdConsultaRNF.Visible = false;
            GrdConsultaExentos.Visible = false;
            GrdConsultaReduccionEmisiones.Visible = false;
            GrdConsultaJuridico.Visible = false;
            GrdConsultaMangle.Visible = false;
            GrdConsultaCapacitacion.Visible = false;
            GrdConsultaPPMF.Visible = false;
            GrdConsultaPinabete.Visible = false;
            GrdConsultaProteccion.Visible = false;
            GrdConsultaCulturaForestal.Visible = false;
            GrdConsultaIncentivoForestal.Visible = false;
            GrdConsultaFiscalizacionControl.Visible = false;
            GrdConsultaFortalecimiento.Visible = false;
            GrdConsultaIndustriaCom.Visible = false;
            GrdConsultaLicenciaF.Visible = false;
            RadGridDatosExtra.Visible = false;           
        } 
        protected void Seleccionar_Productos(object sender, GridCommandEventArgs e)
        {
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();
            DatosMonitoreoIngresoMetas DMI = new DatosMonitoreoIngresoMetas();          
            DatosTarea Dt = (DatosTarea)Session["info2"];
            GridDataItem item = e.Item as GridDataItem;
                       
            if (e.CommandName == "Select")
            {
                DMI.Id_PoAnual = Dt.Id_PoAnual;
                DMI.Id_Subregion = Dt.Id_SubRegion;
                DMI.IdComponente = Dt.Id_Componente;
                DMI.Id_SubComponente = Dt.Id_SubComponente;
                DMI.Id_ProductoVerificable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());               
                DMI.Id_Mes = Dt.Id_Mes;
                Session["CargaInfo"] = DMI;
                Ocultar();

                if (xdata.Validad_IngresoMesMonitoreo(DMI) == false) 
                {
                    MensajePantalla("No tiene información ingresada ese mes");
                }
                else 
                {
                    DetalleDeEjecucionMensual.Visible = true;
                    RegionesMonitoreosDetalle.Visible = false;
                    TProducto.Text = "Componente a Consultar: ";
                    TProducto1.Text = CboComponente1.Text;
                    
                    /*ASUNTOS JURÍDICOS*/
                    if (DMI.IdComponente == 1)
                    {
                        Session["Opcion"] = 1;
                        GrdConsultaJuridico.Visible = true;
                        GrdConsultaJuridico.Rebind();
                    }
                    /*CAPACITACIÓN*/
                    if (DMI.IdComponente == 2)
                    {
                        Session["Opcion"] = 1;
                        GrdConsultaCapacitacion.Visible = true;
                        GrdConsultaCapacitacion.Rebind();
                    }
                    /*CULTURA FORESTAL*/
                    if (DMI.IdComponente == 3)
                    {
                        Session["Opcion"] = 13;
                        GrdConsultaCulturaForestal.Visible = true;
                        GrdConsultaCulturaForestal.Rebind();
                    }
                    /*EXENTOS DE LICENCIA FORESTAL*/
                    if (DMI.IdComponente == 4)
                    {
                        Session["Opcion"] = 14;
                        GrdConsultaExentos.Visible = true;
                        GrdConsultaExentos.Rebind();
                    }
                    /*CONSUMOS FAMILIARES*/
                    if (DMI.IdComponente == 5)
                    {
                        Session["Opcion"] = 17;
                        GrdConsultaConsumoFamiliar.Visible = true;
                        GrdConsultaConsumoFamiliar.Rebind();
                    }
                    /*FISCALIZACIÓN Y CONTROL*/
                    if (DMI.IdComponente == 6)
                    {
                        Session["Opcion"] = 2;
                        GrdConsultaFiscalizacionControl.Visible = true;
                        GrdConsultaFiscalizacionControl.Rebind();
                    }
                    /*FORTALECIMIENTO FORESTAL, MUNICIPAL Y COMUNAL*/
                    if (DMI.IdComponente == 7)
                    {
                        Session["Opcion"] = 3;
                        GrdConsultaFortalecimiento.Visible = true;
                        GrdConsultaFortalecimiento.Rebind();
                    }
                    /*INCENTIVOS FORESTALES*/
                    if (DMI.IdComponente == 8)
                    {
                        Session["Opcion"] = 6;
                        GrdConsultaIncentivoForestal.Visible = true;
                        GrdConsultaIncentivoForestal.Rebind();
                    }
                    /*INDUSTRIA Y COMERCIO*/
                    if (DMI.IdComponente == 9)
                    {
                        Session["Opcion"] = 7;
                        GrdConsultaIndustriaCom.Visible = true;
                        GrdConsultaIndustriaCom.Rebind();
                    }
                    /*LICENCIAS FORESTALES*/
                    if (DMI.IdComponente == 10)
                    {
                        Session["Opcion"] = 16;
                        GrdConsultaLicenciaF.Visible = true;
                        GrdConsultaLicenciaF.Rebind();
                    }
                    /*MANGLE*/
                    if (DMI.IdComponente == 11)
                    {
                        Session["Opcion"] = 4;
                        GrdConsultaMangle.Visible = true;
                        GrdConsultaMangle.Rebind();
                    }
                    /*MONITOREO FORESTAL*/
                    if (DMI.IdComponente == 12)
                    {
                        Session["Opcion"] = 5;
                        GrdConsultaMonitoreo.Visible = true;
                        GrdConsultaMonitoreo.Rebind();
                    }
                    /*PINABETE*/
                    if (DMI.IdComponente == 13)
                    {
                        Session["Opcion"] = 9;
                        GrdConsultaPinabete.Visible = true;
                        GrdConsultaPinabete.Rebind();
                    }
                    /*PINPEP*/
                    if (DMI.IdComponente == 14)
                    {
                        Session["Opcion"] = 12;
                        GrdConsultaPINPEP.Visible = true;
                        GrdConsultaPINPEP.Rebind();
                    }
                    /*PPMF*/
                    if (DMI.IdComponente == 15)
                    {
                        Session["Opcion"] = 10;
                        GrdConsultaPPMF.Visible = true;
                        GrdConsultaPPMF.Rebind();
                    }
                    /*PROBOSQUE*/
                    if (DMI.IdComponente == 16)
                    {
                        Session["Opcion"] = 4;
                        GrdConsultaProbosque.Visible = true; 
                        GrdConsultaProbosque.Rebind();
                    }
                    /*PROTECCIÓN FORESTAL*/
                    if (DMI.IdComponente == 17)
                    {
                        Session["Opcion"] = 8;
                        GrdConsultaProteccion.Visible = true;
                        GrdConsultaProteccion.Rebind();
                    }
                    /*RNF*/
                    if (DMI.IdComponente == 18)
                    {
                        Session["Opcion"] = 15;
                        GrdConsultaRNF.Visible = true;
                        GrdConsultaRNF.Rebind();
                    }
                    /*CARBONO*/
                    if (DMI.IdComponente == 19)
                    {
                        
                    }
                    /* PROGRAMA DE REDUCCIÓN DE EMISIONES*/
                    if (DMI.IdComponente == 20)
                    {
                        Session["Opcion"] = 11;
                        GrdConsultaReduccionEmisiones.Visible = true;
                        GrdConsultaReduccionEmisiones.Rebind();
                    }                    
                }               
            }
        }
        protected void GrdProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];
            if (Dt.Id_SubComponente != 0)
            {
                GrdProductos.Visible = true;
                string CadenaSql = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + Dt.Id_PoAnual + "," + Dt.Id_Componente + "," +
                                    Dt.Id_SubComponente  + "," + Dt.Id_SubRegion + "," + Dt.Id_Mes + "," + 2;
                procesos.LlenarRadGrid(GrdProductos, CadenaSql);
            }
            else
            {
                GrdProductos.Visible = false;
            }
        }
        protected void RadRegion2_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();           
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            string Mes = string.Empty; 
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");
            RadComboBox comboBox2 = (RadComboBox)item.FindControl("Mes");

            if (e.CommandName == "Select")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                comboBox2.DataBind();
                string Valor2 = comboBox2.SelectedValue;
                if (Valor2 == string.Empty)
                {
                    Dt.Id_Mes = 0;
                }
                else
                {
                    Dt.Id_Mes = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                    Mes = comboBox2.Text; 
                }

                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else if (Dt.Id_Mes == 0)
                {
                    MensajePantalla("No Seleccionado el Mes de Consulta");
                }
                else
                {
                    CboComponente1.ClearSelection();
                    CboSubcomponente1.ClearSelection();
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                        Dt.Id_Componente = procesos.IntNULLCombo(CboComponente1);
                        Dt.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente1);
                    }                    
                    Session["info2"] = Dt;
                    RegionesMonitoreo.Visible = false;
                    RegionesMonitoreosDetalle.Visible = true; 
                    ControladorTAb.Visible = false;
                    T011.Text = Dt.NombrePoa + " (Monitoreo)";
                    T012.Text = Dt.DescripcionSubregion;
                    T013.Text ="Mes de Ejecución: "+ Mes;
                    string stringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1;";
                    procesos.LLenarComboT(CboComponente1, stringComando, "Descripcion", "Id", true);                    
                    VerificargRID1();
                }
            }
        }
        protected void RadRegion_ItemCommand(object sender, GridCommandEventArgs e)
        {
            DatosTarea Dt = new DatosTarea();
            ManipulacionIngresoValoresMetas M = new ManipulacionIngresoValoresMetas();            
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            GridDataItem item;
            item = e.Item as GridDataItem;
            RadComboBox comboBox = (RadComboBox)item.FindControl("Poas");

            if (e.CommandName == "Select")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.NombrePoa = comboBox.Text;
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCarga2(Dt) == true)
                    {
                        Session["info2"] = Dt;
                        Regiones.Visible = false;
                        poas.Visible = true;
                        ControladorTAb.Visible = false; 
                        T01.Text = Dt.NombrePoa + " (Planificación)";
                        T02.Text = Dt.DescripcionSubregion;
                        string stringComando = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + ",0,1;";
                        procesos.LLenarComboT(CboComponente, stringComando, "Descripcion", "Id", true);
                        VerificargRID();
                    }
                    else
                    {
                        MensajePantalla("a esta Subregión No se le a aprobado el poa Todavia");
                    }
                }
            }            
            if (e.CommandName == "Select1")
            {
                comboBox.DataBind();
                string Valor = comboBox.SelectedValue;
                if (Valor == string.Empty)
                {
                    Dt.Id_PoAnual = 0;
                }
                else
                {
                    Dt.Id_PoAnual = Convert.ToInt32(comboBox.SelectedValue.ToString());
                }
                if (Dt.Id_PoAnual == 0)
                {
                    MensajePantalla("No Seleccionado el POA");
                }
                else
                {
                    if (e.Item.OwnerTableView.Name == "SubRegion")
                    {
                        Dt.Id_Usuario = Convert.ToInt32(Session["Usuario"].ToString());
                        Dt.Id_Region = Convert.ToInt32(item.GetDataKeyValue("Cod_Padre"));
                        Dt.Id_SubRegion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
                        Dt.DescripcionSubregion = item["Subregion"].Text;
                    }
                    if (M.VerificarCarga2(Dt) == true)                     
                    {
                        Session["info50"] = Dt;
                        Exportar_Excel(ExportarEx,"../ExportarExcel/ExportarExcelPOA.aspx", "200", "200", "key5", "Exportar a excel POA");
                        //Exportar_Excel(ExportarEx, "../ExportarExcel/ExcelPOARegionalVariado.aspx", "200", "200", "key20", "Exportar a excel POA");
                    }
                    else
                    {
                        MensajePantalla("a esta Subregión No se le a aprobado el poa Todavia");
                    }                   
                }
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
                DatosTarea dt = new DatosTarea();
                Session["CargarMetasValor"] = Ris;
                Session["d10"] = 0;
                Session["info2"] = dt;
                Session["info3"] = Ris;
                poas.Visible = false;
                RegionesMonitoreosDetalle.Visible = false;               
            }

            CerraVentana.Click += new EventHandler(CerraVentana_Click);
        }
        protected void RadRegion_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {                
                UsuarioValida Us =(UsuarioValida)Session["DataUser"];
                string CadenaSQl;

                if((Us.Id_Tipoperfil == 5) ||(Us.Id_Tipoperfil == 7) ||(Us.Id_Tipoperfil == 19))
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1 and r.Id_Region ="+ Us.id_region+";"; 
                }
                else 
                {
                    CadenaSQl = "SELECT r.Id_Region, r.Nombre_Region, 0 as Cod_Padre,r.Id_Region as Hijo,r.Id_Estado_Region FROM Region r where Id_Estado_Region = 1 and Codigo_Region >= 1;"; 
                }                                                
                procesos.LlenarRadGrid(RadRegion, CadenaSQl);
                procesos.LlenarRadGrid(RadRegion2, CadenaSQl);
            }
        }
        protected void RadRegion_DetailTableDataBind(object source, GridDetailTableDataBindEventArgs e)
        {
            GridDataItem dataItem = e.DetailTableView.ParentItem;
            string CadenaString = "SELECT Id_Subregion,Subregion,Id_Region AS Cod_Padre,0 Hijo,Id_Estado_Subregion FROM Subregion " +
                                 "WHERE Id_Estado_Subregion = 1 and Codigo_SubRegion >= 1 and Codigo_SubRegion != 99 AND ISNULL(Nacional,0)<>1 AND Id_Region = ";
            switch (e.DetailTableView.Name)
            {
                case "SubRegion":
                    {                    
                        UsuarioValida Us = (UsuarioValida)Session["DataUser"];                        

                        if(Us.Id_Tipoperfil == 7) 
                        {
                            CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString() + "and Id_Subregion ="+Us.id_subregion +";";
                        }
                        else 
                        {
                           CadenaString += dataItem.GetDataKeyValue("Id_Region").ToString();
                        }                            
                        procesos.LlenarRadGrid(RadRegion, CadenaString);
                        procesos.LlenarRadGrid(RadRegion2, CadenaString);
                        break;
                    }
            }
        }
        protected string Combos()
        {
            return "SELECT pc.Id_PoAnual Id,(tp.Descripcion_POA+' '+CAST(pc.Anio_Correspondiente AS nvarchar(MAX))) Descripcion " +
                   "FROM Poas_Creados pc INNER JOIN Tipo_De_Poa tp ON pc.Id_Poa = tp.Id_Poa WHERE pc.IniciarTarea = 1 AND PC.Id_Poa = 2;";
        }
        protected void Poas_ItemsRequested2(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combos(), "Descripcion", "Id", true);
        }
        protected void Poas_ItemsRequested3(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, Combos(), "Descripcion", "Id", true);
        }
        protected string ComboMes()
        {
            return "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses;";
        }
        protected void Poas_ItemsRequested1(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            RadComboBox comboBox = (RadComboBox)sender;
            procesos.LLenarComboT(comboBox, ComboMes(), "Descripcion", "Id", true);
        }

        /*informacion de actividades*/
        protected void RegresarPantallaanterior2_Click(object sender, EventArgs e)
        {
            RegionesMonitoreo.Visible = true;
            RegionesMonitoreosDetalle.Visible = false;
            ControladorTAb.Visible = true;
            VerificargRID1(); 
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Regiones.Visible = true;
            poas.Visible = false;
            ControladorTAb.Visible = true;
            CboComponente.ClearSelection();
            CboSubcomponente.ClearSelection();
            VerificargRID();
        }
        protected void GdrDatosdeActividades_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                TableCell cell1 = item["DescripcionProductoVeficable"];
                TableCell cell2 = item["DescripcionUM1"];
                TableCell cell3 = item["DescripcionUM2"];
                TableCell cell4 = item["DescripcionUM3"];

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
                }
            }
        }
        protected void VerificargRID()
        {
            GdrDatosdeActividades.Rebind();
            if (GdrDatosdeActividades.Items.Count != 0) { GdrDatosdeActividades.Visible = true; } else { GdrDatosdeActividades.Visible = false; }
        }
        protected void VerificargRID1()
        {
            RadGridDatosExtra.Visible = false;
            GrdProductos.Rebind();
            if (GrdProductos.Items.Count != 0) { GrdProductos.Visible = true; } else { GrdProductos.Visible = false; }
        }
        private void CboComponente_TextChanged(object sender, EventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string Strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente.SelectedItem.Value + ",2;";
            CboSubcomponente.ClearSelection();
            VerificargRID();
            procesos.LLenarComboT(CboSubcomponente, Strsub, "Descripcion", "Id", true);
            procesos.LLenarComboT(CboSubcomponente1, Strsub, "Descripcion", "Id", true);
        }
        private void CboComponente1_TextChanged(object sender, EventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            string Strsub = "EXEC Sp_obtenerComboIngresoDSR " + Dt.Id_PoAnual + "," + CboComponente1.SelectedItem.Value + ",2;";
            CboSubcomponente1.ClearSelection();
            VerificargRID1();           
            procesos.LLenarComboT(CboSubcomponente1, Strsub, "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            RegresoInformacionSubregional Ris = new RegresoInformacionSubregional();
            DatosTarea Dt = (DatosTarea)Session["info2"];
            Ris.Id_PoAnual = Dt.Id_PoAnual;
            Ris.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente));
            Ris.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente));
            Ris.Id_SubRegion = Dt.Id_SubRegion;
            VerificargRID();
        }
        private void CboSubcomponente1_TextChanged(object sender, EventArgs e)
        {            
            DatosTarea Dt = (DatosTarea)Session["info2"];           
            Dt.Id_Componente = Convert.ToInt32(procesos.IntNULLCombo(CboComponente1));
            Dt.Id_SubComponente = Convert.ToInt32(procesos.IntNULLCombo(CboSubcomponente1));
            Dt.Id_SubRegion = Dt.Id_SubRegion;
            Session["info2"] = Dt;
            VerificargRID1();
        }
        protected void GdrDatosdeActividades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            if ((procesos.IntNULLCombo(CboComponente) != 0) && (procesos.IntNULLCombo(CboSubcomponente) != 0))
            {
                Respuesta2.Visible = false;
                string CadenaSql = "EXEC Sp_obtener_data_Actividad_Subregional " + Dt.Id_PoAnual + "," + procesos.IntNULLCombo(CboComponente) + ","
                                    + procesos.IntNULLCombo(CboSubcomponente) + "," + Dt.Id_SubRegion + ";";
                procesos.LlenarRadGrid(GdrDatosdeActividades, CadenaSql);
            }
            else
            {
               Respuesta2.Visible = true;
            }
        }
        protected void Seleccionar_Actividad(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            int Llave = 0;
            if (e.CommandName == "Select")
            {                
                string Enlace = item.GetDataKeyValue("DireccionMedioVerificacion").ToString();               
                if(Enlace.Length <= 12) 
                {
                    MensajePantalla("- No Tiene un enlace que consultar");
                }
                else 
                {
                    Page page = HttpContext.Current.CurrentHandler as Page;
                    string strScript = "var w=window.open('" + Enlace + "','zz');window.focus();";
                    ScriptManager.RegisterStartupScript(page, page.GetType(), "ShowInfo", strScript, true);
                }

                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {               
                txtInstruccion.Text = item.GetDataKeyValue("DireccionMedioVerificacion").ToString();
                OpenWinwdows(MensajePla, "500", "370", "Key1", "Dirección del Medio de Verificación");                
                Llave = 1;
            }
            /*Abrir la ventana*/
            if (Llave == 0)
            {
                Session["d10"] = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                Session["d11"] = Convert.ToInt32(item.GetDataKeyValue("Id_NoPlanificable").ToString());
                VerificargRIDVentana();
            }
        }
        protected void VerificargRIDVentana()
        {
            GridUnidades.Rebind();
            if (GridUnidades.Items.Count != 0)
            {
                if (Convert.ToInt32(Session["d11"].ToString()) == 0)
                {
                    OpenWinwdows(VerIngresos, "500", "520", "Key", "Visualización de ingreso de Metas");
                }
                else
                {
                    MensajePantalla("- No Tiene Información porque es una Actividad NO PLANIFICABLE -");
                }                
            }
            else
            {
                if (Convert.ToInt32(Session["d11"].ToString()) == 0)
                {
                    MensajePantalla("- No Tiene Información esta Actividad -");
                }
                else 
                {
                    MensajePantalla("- No Tiene Información porque es una Actividad NO PLANIFICABLE -");
                }
            }
        }
        protected void CerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(MensajePla, "Key1");
        }



        protected void GridUnidades_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosTarea Dt = (DatosTarea)Session["info2"];
            if ((procesos.IntNULLCombo(CboComponente) != 0) && (procesos.IntNULLCombo(CboSubcomponente) != 0))
            {
                string CadenaSql = "EXEC Sp_Procesamiento_MetasUM_Subregional " + 1 + "," +
                               +Dt.Id_PoAnual + "," + Dt.Id_SubRegion + "," + procesos.IntNULLCombo(CboComponente) + "," + procesos.IntNULLCombo(CboSubcomponente) + "," + Session["d10"].ToString() + ";";
                procesos.LlenarRadGrid(GridUnidades, CadenaSql);
            }
        }
        /*Monitoreo*/
        protected void BtnOcultar_Click(object sender, EventArgs e)
        {
            Personas.Visible = false;
            GrdModalidadArea.Visible = false;
            GrdActores.Visible = false;
            GrdParticipantes.Visible = false;
            GrdPertencia.Visible = false;                     
            //GrdRendimiento.Visible = false;
        }
        protected void GrdIngresoEncabezado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["CargaInfo"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + Convert.ToInt32(Session["Opcion"].ToString()) + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;

            if (DMI.IdComponente == 1) { procesos.LlenarRadGrid(GrdConsultaJuridico, CadenaSql); }
            if (DMI.IdComponente == 2) { procesos.LlenarRadGrid(GrdConsultaCapacitacion, CadenaSql); }
            if (DMI.IdComponente == 3) { procesos.LlenarRadGrid(GrdConsultaCulturaForestal, CadenaSql); }
            if (DMI.IdComponente == 4) { procesos.LlenarRadGrid(GrdConsultaExentos, CadenaSql); }
            if (DMI.IdComponente == 5) { procesos.LlenarRadGrid(GrdConsultaConsumoFamiliar, CadenaSql); }
            if (DMI.IdComponente == 6) { procesos.LlenarRadGrid(GrdConsultaFiscalizacionControl, CadenaSql); }
            if (DMI.IdComponente == 7) { procesos.LlenarRadGrid(GrdConsultaFortalecimiento, CadenaSql); }            
            if (DMI.IdComponente == 8) { procesos.LlenarRadGrid(GrdConsultaIncentivoForestal, CadenaSql); }
            if (DMI.IdComponente == 9) { procesos.LlenarRadGrid(GrdConsultaIndustriaCom, CadenaSql); }
            if (DMI.IdComponente == 10) { procesos.LlenarRadGrid(GrdConsultaLicenciaF, CadenaSql); }
            if (DMI.IdComponente == 11) { procesos.LlenarRadGrid(GrdConsultaMangle, CadenaSql); }
            if (DMI.IdComponente == 12) { procesos.LlenarRadGrid(GrdConsultaMonitoreo, CadenaSql); }
            if (DMI.IdComponente == 13) { procesos.LlenarRadGrid(GrdConsultaPinabete, CadenaSql); }
            if (DMI.IdComponente == 14) { procesos.LlenarRadGrid(GrdConsultaPINPEP, CadenaSql); }
            if (DMI.IdComponente == 15) { procesos.LlenarRadGrid(GrdConsultaPPMF, CadenaSql); }
            if (DMI.IdComponente == 16) { procesos.LlenarRadGrid(GrdConsultaProbosque, CadenaSql); }
            if (DMI.IdComponente == 17) { procesos.LlenarRadGrid(GrdConsultaProteccion, CadenaSql); }
            if (DMI.IdComponente == 18) { procesos.LlenarRadGrid(GrdConsultaRNF, CadenaSql); }
            if (DMI.IdComponente == 20) { procesos.LlenarRadGrid(GrdConsultaReduccionEmisiones, CadenaSql); }
        }
        protected void GrdConsultaJuridico_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaJuridico.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaCapacitacion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaCapacitacion.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaCulturaForestal_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonB").Display = VPC.ShowHideProductoCulturaForestal(Producto, 1);//Comunida Linguistica
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoCulturaForestal(Producto, 1);//Grupo Etario
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoCulturaForestal(Producto, 2);//Notas
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonE").Display = VPC.ShowHideProductoCulturaForestal(Producto, 4);//tipo de publicidad
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonF").Display = VPC.ShowHideProductoCulturaForestal(Producto, 3);//publico
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonG").Display = VPC.ShowHideProductoCulturaForestal(Producto, 3);//material
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonH").Display = VPC.ShowHideProductoCulturaForestal(Producto, 5);//Campaña
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("BotonI").Display = VPC.ShowHideProductoCulturaForestal(Producto, 5);//tipo de notas
                /*validar Valores 0*/
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaCulturaForestal.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaExentos_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoExentosForestales(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaExentos.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaConsumoFamiliar_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaConsumoFamiliar.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaFiscalizacionControl_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("BotonB").Display = VPC.ShowHideProductoFisca(Producto, 1);
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoFisca(Producto, 2);
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoFisca(Producto, 2);
                /*validar Valores 0*/
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaFiscalizacionControl.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }        
        protected void GrdConsultaFortalecimiento_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoForta(Producto, 1);
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoForta(Producto, 1);
                /*validar Valores 0*/
             /*   GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaFortalecimiento.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
             */
            }
        }
        protected void GrdConsultaIncentivoForestal_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoIncentivoForestalM(Producto, 1);
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoIncentivoForestalM(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaIncentivoForestal.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaIndustriaCom_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoIndustria(Producto, 1);
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoIndustria(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaIndustriaCom.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaLicenciaF_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoLicencia(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaLicenciaF.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaMangle_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoMangle(Producto, 1);
                GrdConsultaMangle.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoMangle(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaMangle.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaMonitoreo_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoMonitoreo(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaMonitoreo.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaPinabete_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoPinabete(Producto, 1);
                GrdConsultaPinabete.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoPinabete(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaPinabete.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaPINPEP_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoPINPEP(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaPINPEP.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaPPMF_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaPPMF.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaProbosque_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoProbosque(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaProbosque.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaProteccion_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("BotonD").Display = VPC.ShowHideProductoProteccionForestal(Producto, 1);
                GrdConsultaProteccion.MasterTableView.GetColumn("BotonC").Display = VPC.ShowHideProductoProteccionForestal(Producto, 1);
                /*validar Valores 0*/
                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaProteccion.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void GrdConsultaRNF_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdConsultaRNF.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaRNF.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoRNF(Producto, 1);                
            }
        }        
        protected void GrdConsultaReduccionEmisiones_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;

                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                /*validar Valores 0*/
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdConsultaReduccionEmisiones.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }

        protected void Seleccionar_ItemsJuridico(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                Demo.Orden = 1;
                Demo.Descripcion = "Fecha";
                Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 2;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
            }
        }
        protected void Seleccionar_ItemsCapacitacion(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {                
                Session["Opcion1"] = 1;
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());                
                RecargaParticipantes();

                
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {               
                Session["Opcion2"] = 2;
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargaPertenencia();
                Llave = 1;
            }
            
            if (Llave == 0)
            {                
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                Demo.Orden = 1;
                Demo.Descripcion = "Fecha";
                Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 2;
                Demo.Descripcion = "Evento";
                Demo.Valores = item.GetDataKeyValue("Evento").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 3;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
            }
        }
        protected void Seleccionar_ItemsMangle(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }           

            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;                
                Demo.Orden = 1;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);                
            }
        }       
        protected void Seleccionar_ItemsProbosque(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();           
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            
            if (Llave == 0)
            {                               
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 184) || (Producto == 185) || (Producto == 189) || (Producto == 192) || (Producto == 193) || (Producto == 194) ||
                (Producto == 195) || (Producto == 199) || (Producto == 204) || (Producto == 198) || (Producto == 201))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1; 
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Resolución/Número de Informe";
                    Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Modalidad";
                    Demo.Valores = item.GetDataKeyValue("Modalidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if ((Producto == 186) || (Producto == 187) || (Producto == 188) || (Producto == 190) || (Producto == 191) ||
                    (Producto == 196) || (Producto == 197) || (Producto == 200) || (Producto == 202) || (Producto == 203))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    if ((Producto == 196) || (Producto == 197) || (Producto == 200) || (Producto == 202) || (Producto == 203))
                    {
                        Demo.Orden = 2;
                        Demo.Descripcion = "Número de Resolución de Certificación";
                        Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 3;
                        Demo.Descripcion = "Fecha de Certificación";
                        Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 4;
                        Demo.Descripcion = "Área Certificada";
                        Demo.Valores = item.GetDataKeyValue("ValorUM2").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }
                    if ((Producto == 186) || (Producto == 187) || (Producto == 188) || (Producto == 190) || (Producto == 191))
                    {
                        Demo.Orden = 2;
                        Demo.Descripcion = "Número de Resolución de Aprobación";
                        Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 3;
                        Demo.Descripcion = "Fecha de Aprobación";
                        Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 4;
                        Demo.Descripcion = "Área Aprobada";
                        Demo.Valores = item.GetDataKeyValue("ValorUM2").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }                   
                }              
            }
        }
        protected void Seleccionar_ItemsRNF(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            
            if (Llave == 0)
            {                
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 255)
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Categoría";
                    Demo.Valores = item.GetDataKeyValue("CategoriaRNF").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "SubCategoría";
                    Demo.Valores = item.GetDataKeyValue("SubcategoriaRNF").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Especificaciones";
                    Demo.Valores = item.GetDataKeyValue("Especificaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Tipo de Denegación";
                    Demo.Valores = item.GetDataKeyValue("Denegacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if ((Producto == 218) || (Producto == 219))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NoRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("TipoRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Estado del RNF";
                    Demo.Valores = item.GetDataKeyValue("EstadoRNF").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }               
            }
        }
        protected void Seleccionar_ItemsPINPEP(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }            

            if (Llave == 0)
            {                
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
                    (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución/Número de Informe";
                    Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Modalidad";
                    Demo.Valores = item.GetDataKeyValue("Modalidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    
                }
                if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) ||
                    (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    if ((Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
                    {                        
                        Demo.Orden = 1;
                        Demo.Descripcion = "Fecha de Certificación";
                        Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 2;
                        Demo.Descripcion = "Número de Expediente";
                        Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 3;
                        Demo.Descripcion = "Dictamen Tecnico de Certificación";
                        Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 4;
                        Demo.Descripcion = "Área Certificada";
                        Demo.Valores = item.GetDataKeyValue("ValorUM2").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);

                    }
                    if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170))
                    {                        
                        Demo.Orden = 1;
                        Demo.Descripcion = "Fecha de Aprobación";
                        Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 2;
                        Demo.Descripcion = "Número de Expediente";
                        Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 3;
                        Demo.Descripcion = "DNúmero de Resolución de Aprobación";
                        Demo.Valores = item.GetDataKeyValue("ResolucionInforme").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                        Demo.Orden = 4;
                        Demo.Descripcion = "Área Aprobada";
                        Demo.Valores = item.GetDataKeyValue("ValorUM2").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }                                       
                }               
            }
        }
        protected void Seleccionar_ItemsMonitoreo(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }           
            
            if (Llave == 0)
            {                               
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 126) || (Producto == 127) || (Producto == 128) || (Producto == 129) || (Producto == 130) || (Producto == 131) ||
                    (Producto == 132) || (Producto == 133) || (Producto == 124))
                {                                       
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("Noexpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Garantías";
                    Demo.Valores = item.GetDataKeyValue("Garantia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número Informe";
                    Demo.Valores = item.GetDataKeyValue("NoInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if ((Producto == 123) || (Producto == 134))
                {                                                                                                                                                                                                 
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha de Evaluación / Monitoreo";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("Noexpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Estado";
                    Demo.Valores = item.GetDataKeyValue("Estado").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Fase Evaluada";
                    Demo.Valores = item.GetDataKeyValue("Fase").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Estatus";
                    Demo.Valores = item.GetDataKeyValue("Estatus").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Edad";
                    Demo.Valores = item.GetDataKeyValue("Edad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Tipo de Garantías";
                    Demo.Valores = item.GetDataKeyValue("Garantia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 8;
                    Demo.Descripcion = "Número de Informe";
                    Demo.Valores = item.GetDataKeyValue("NoInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 9;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);

                }
                if ((Producto == 136) || (Producto == 137) || (Producto == 138) || (Producto == 141) || (Producto == 142) || (Producto == 143) ||
                    (Producto == 144) || (Producto == 145) || (Producto == 146))
                {                    
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha de Monitoreo";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("Noexpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Edad de Plantación";
                    Demo.Valores = item.GetDataKeyValue("Edad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número de Informe / Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Volumen";
                    Demo.Valores = item.GetDataKeyValue("Volumen").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 139) || (Producto == 140))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha de Evaluación";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("Noexpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Volumen";
                    Demo.Valores = item.GetDataKeyValue("Volumen").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Coordenada X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaX").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Coordenada Y";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaY").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Número de Informe";
                    Demo.Valores = item.GetDataKeyValue("NoInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                    Demo.Orden = 8;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 154) || (Producto == 155) || (Producto == 156) || (Producto == 157) || (Producto == 158) || (Producto == 159) ||
                   (Producto == 147) || (Producto == 148) || (Producto == 149) || (Producto == 150) || (Producto == 151) || (Producto == 152) ||
                   (Producto == 153))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha de Evaluación";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("Noexpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Fase";
                    Demo.Valores = item.GetDataKeyValue("Fase").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número de Informe";
                    Demo.Valores = item.GetDataKeyValue("NoInforme").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                    Demo.Orden = 5;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }                
            }
        }
        protected void Seleccionar_ItemsExentos(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }            

            if (Llave == 0)
            {                             
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 256)
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                                       
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                    Demo.Orden = 4;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 46) || (Producto == 47) || (Producto == 48))
                {
                    InicializarExtra();
                    RadGridDatosExtra.Visible = true;
                    Demo.Orden = 1;
                    Demo.Descripcion = "Fecha";
                    Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Numero de Registro";
                    Demo.Valores = item.GetDataKeyValue("NoRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }                
            }
        }
        protected void Seleccionar_ItemsReduccionEmisiones(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarModalidades();
                Llave = 1;
            }           
            if (Llave == 0)
            {                                
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                InicializarExtra();
                RadGridDatosExtra.Visible = true;                
                Demo.Orden = 1;
                Demo.Descripcion = "Número de Resolución";
                Demo.Valores = item.GetDataKeyValue("NoResolucion").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 2;
                Demo.Descripcion = "Fecha de Resolución";
                Demo.Valores = item.GetDataKeyValue("FechaResolucion").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 3;
                Demo.Descripcion = "Número de Expediente";
                Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);               

                if ((Producto == 239) || (Producto == 240) || (Producto == 241) || (Producto == 244) ||
                    (Producto == 245) || (Producto == 246) || (Producto == 247) || (Producto == 248))
                {                  
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Proyecto";
                    Demo.Valores = item.GetDataKeyValue("TipoProyecto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                Demo.Orden = 5;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);                                
            }
        }
        protected void Seleccionar_ItemsPPMF(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;           
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }           

            if (Llave == 0)
            {                               
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 181) || (Producto == 182) || (Producto == 183))
                {                              
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Bosque";
                    Demo.Valores = item.GetDataKeyValue("TipoBosque").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Coordenada X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaX").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Coordenada Y";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaY").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Fecha de establecimiento (Plantación)";
                    Demo.Valores = item.GetDataKeyValue("FechaPlantacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Fecha de establecimiento (PPM)";
                    Demo.Valores = item.GetDataKeyValue("FechaPPM").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Nombre del sitio";
                    Demo.Valores = item.GetDataKeyValue("NombreSitio").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Número de Experimento";
                    Demo.Valores = item.GetDataKeyValue("NoExperimento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 8;
                    Demo.Descripcion = "Número de Experimento";
                    Demo.Valores = item.GetDataKeyValue("NoExperimento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 9;
                    Demo.Descripcion = "Numero de Parcela";
                    Demo.Valores = item.GetDataKeyValue("NoParcela").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 10;
                    Demo.Descripcion = "Número de Medición";
                    Demo.Valores = item.GetDataKeyValue("NoMedicion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 11;
                    Demo.Descripcion = "Número de Medición";
                    Demo.Valores = item.GetDataKeyValue("NoMedicion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 12;
                    Demo.Descripcion = "Codigo de Proyecto";
                    Demo.Valores = item.GetDataKeyValue("CodigoProyecto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 13;
                    Demo.Descripcion = "Replanteo (%)";
                    Demo.Valores = item.GetDataKeyValue("Replanteo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 234)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Nombre del sitio";
                    Demo.Valores = item.GetDataKeyValue("NombreSitio").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Experimento";
                    Demo.Valores = item.GetDataKeyValue("NoExperimento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Numero de Parcela";
                    Demo.Valores = item.GetDataKeyValue("NoParcela").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número de Medición";
                    Demo.Valores = item.GetDataKeyValue("NoMedicion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 235)
                {                   
                    Demo.Orden = 1;
                    Demo.Descripcion = "Unidad de Muestreo";
                    Demo.Valores = item.GetDataKeyValue("UnidadMuestreo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Coordenada X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaX").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Coordenada Y";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaY").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                Demo.Orden = 14;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);                              
            }
        }
        protected void Seleccionar_ItemsPinabete(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }           
            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 162) || (Producto == 163))
                {                   
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Area";
                    Demo.Valores = item.GetDataKeyValue("TipoArea").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NoRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                Demo.Orden = 4;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);                               
            }
        }
        protected void Seleccionar_ItemsProteccion(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());                
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }           

            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 210)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Agente Causal(Nombre Cientifico)";
                    Demo.Valores = item.GetDataKeyValue("AgenteCausal").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Nombre del Titular";
                    Demo.Valores = item.GetDataKeyValue("NombreTitular").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Hectarías Saneadas";
                    Demo.Valores = item.GetDataKeyValue("Hectarias").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 207)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Agente Causal(Nombre Cientifico)";
                    Demo.Valores = item.GetDataKeyValue("AgenteCausal").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Nombre del Titular";
                    Demo.Valores = item.GetDataKeyValue("NombreTitular").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Hectarías a Sanear";
                    Demo.Valores = item.GetDataKeyValue("Hectarias").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if ((Producto == 208) || (Producto == 215))
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Coornadas en X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaX").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Coornadas en Y";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaY").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Nombre del Contacto";
                    Demo.Valores = item.GetDataKeyValue("NombreContacto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número de Teléfono";
                    Demo.Valores = item.GetDataKeyValue("NumeroTelefono").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Equipo de Protección";
                    Demo.Valores = item.GetDataKeyValue("EquipoProteccion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 209)
                {
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Área Bajo Manejo";
                    Demo.Valores = item.GetDataKeyValue("TipoAreaManejo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = item.GetDataKeyValue("TipoAreaManejo").ToString();
                    Demo.Valores = item.GetDataKeyValue("AreaBajoManejo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = item.GetDataKeyValue("Fase de Proyecto").ToString();
                    Demo.Valores = item.GetDataKeyValue("fase").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if ((Producto == 213) || (Producto == 236))
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Escenario:";
                    Demo.Valores = item.GetDataKeyValue("Escenario").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                   
                    int Valor = Convert.ToInt32(item.GetDataKeyValue("Id_TipoEscenario").ToString());
                    if ((Valor == 1) || (Valor == 2) || (Valor == 3))
                    {
                        Demo.Orden = 2;
                        Demo.Descripcion = "Hectarias";
                        Demo.Valores = item.GetDataKeyValue("Hectarias").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);                        
                    }
                    else
                    {
                        Demo.Orden = 2;
                        Demo.Descripcion = "Hectarias";
                        Demo.Valores = "No Aplica";
                        GridDatosExtra(Demo, RadGridDatosExtra);                      
                    }
                    Demo.Orden = 3;
                    Demo.Descripcion = "Agente Causal(Nombre Cientifico)";
                    Demo.Valores = item.GetDataKeyValue("AgenteCausal").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Número de Muestra(Correlativo Regional)";
                    Demo.Valores = item.GetDataKeyValue("NumeroMuestra").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 216)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Bosque";
                    Demo.Valores = item.GetDataKeyValue("Bosque").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Incendio";
                    Demo.Valores = item.GetDataKeyValue("Incendio").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Administración";
                    Demo.Valores = item.GetDataKeyValue("Administracion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                Demo.Orden = 6;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
            }
        }
        protected void Seleccionar_ItemsCulturaForestal(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {
               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());               
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }
            if (e.CommandName == "Select3")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarNOtas();
                Llave = 1;
            }
            if (e.CommandName == "Select4")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarPublicidad();
                Llave = 1;
            }
            if (e.CommandName == "Select5")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarPublico();
                Llave = 1;
            }
            if (e.CommandName == "Select6")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarMaterial();
                Llave = 1;
            }
            if (e.CommandName == "Select7")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargarCampania();
                Llave = 1;
            }
            if (e.CommandName == "Select8")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                NotasPosiNegas();
                Llave = 1;
            }           

            if (Llave == 0)
            {               
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 45)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Evento";
                    Demo.Valores = item.GetDataKeyValue("TipoEvento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Nombre del Evento";
                    Demo.Valores = item.GetDataKeyValue("NombreEvento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tema";
                    Demo.Valores = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Campaña";
                    Demo.Valores = item.GetDataKeyValue("Campania").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Medio Participante";
                    Demo.Valores = item.GetDataKeyValue("MediosParticipantes").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 35)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tema Atendido";
                    Demo.Valores = item.GetDataKeyValue("TemaAtendido").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 38)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Nombre del Material";
                    Demo.Valores = item.GetDataKeyValue("NombredelMaterial").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                  
                }
                if ((Producto == 39) || (Producto == 40))
                {                   
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Evento";
                    Demo.Valores = item.GetDataKeyValue("TipoEvento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Nombre del Evento";
                    Demo.Valores = item.GetDataKeyValue("NombreEvento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tema";
                    Demo.Valores = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Campaña";
                    Demo.Valores = item.GetDataKeyValue("Campania").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 41)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Nombre del Medio de Comunicación";
                    Demo.Valores = item.GetDataKeyValue("NombreMediosComunicacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tema Abordado";
                    Demo.Valores = item.GetDataKeyValue("TemaAbordado").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                  
                }
                if (Producto == 42)
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Periodo de Publicidad/Fecha Inicio";
                    Demo.Valores = item.GetDataKeyValue("PeriodoPublicidadInicio").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Periodo de Publicidad/Fecha Finalizción";
                    Demo.Valores = item.GetDataKeyValue("PeriodoPublicidadFinal").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Apoyo";
                    Demo.Valores = item.GetDataKeyValue("TipoApoyo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Nombre de Entidad";
                    Demo.Valores = item.GetDataKeyValue("NombreEntidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tema";
                    Demo.Valores = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Tipo de Campaña";
                    Demo.Valores = item.GetDataKeyValue("Campania").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 44)
                {
                    Demo.Orden = 1;
                    Demo.Descripcion = "Nombre de la Entidad con la que se Realizo el Acuerdo";
                    Demo.Valores = item.GetDataKeyValue("TemaONombreEntidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Campaña";
                    Demo.Valores = item.GetDataKeyValue("Campania").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                  
                }
                Demo.Orden = 7;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);               
            }
        }
        protected void Seleccionar_ItemsIncentivoForestal(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }
           
            if (Llave == 0)
            {                
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 85) || (Producto == 86))
                {                   
                    Demo.Orden = 1;
                    Demo.Descripcion = "Número de Expediente";
                    Demo.Valores = item.GetDataKeyValue("NumeroExpediente").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Area";
                    Demo.Valores = item.GetDataKeyValue("Area").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Incentivo";
                    Demo.Valores = item.GetDataKeyValue("DescripcionTipoIncentivo").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Modalidad de Incentivo";
                    Demo.Valores = item.GetDataKeyValue("DescripcionModalidad").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Fase de Proyecto";
                    Demo.Valores = item.GetDataKeyValue("DescripcionFase").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                Demo.Orden = 6;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
            }
        }
        protected void Seleccionar_ItemsFiscalizacionControl(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                RecargaRendimiento();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());                
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }
            if (e.CommandName == "Select3")
            {               
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            
            if (Llave == 0)
            {                
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                Demo.Orden = 1;
                Demo.Descripcion = "Fecha";
                Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                               
                if (Producto == 52)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("Registro2").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if ((Producto == 51) || (Producto == 53) || (Producto == 60))
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("Registro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 54)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("Registro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Acta";
                    Demo.Valores = item.GetDataKeyValue("Acta").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   

                    if (item.GetDataKeyValue("Acta").ToString() == "Con Anomalia")
                    {
                        Demo.Orden = 5;
                        Demo.Descripcion = "Descripción de Anomalia";
                        Demo.Valores = item.GetDataKeyValue("ErroresAnomalias").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }
                }
                if (Producto == 55)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Nombre Empresa Exportadora";
                    Demo.Valores = item.GetDataKeyValue("NombreEmpresa").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro del Exim";
                    Demo.Valores = item.GetDataKeyValue("RegistroExim").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tipo de Producto";
                    Demo.Valores = item.GetDataKeyValue("Tipo_Producto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Pais";
                    Demo.Valores = item.GetDataKeyValue("Pais").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 56)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("Registro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Error Registrado";
                    Demo.Valores = item.GetDataKeyValue("ErroresAnomalias").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 57)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Estado";
                    Demo.Valores = item.GetDataKeyValue("Estado").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 58)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("Registro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroDeRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "La Empresa ya fue Reactivada en el SERNAF";
                    Demo.Valores = item.GetDataKeyValue("Seinef").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 59)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Acción";
                    Demo.Valores = item.GetDataKeyValue("Accion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Incumplimiento";
                    Demo.Valores = item.GetDataKeyValue("Incumplimiento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 61)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Nombre Comercial";
                    Demo.Valores = item.GetDataKeyValue("NombreEmpresa").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número del RNF";
                    Demo.Valores = item.GetDataKeyValue("RegistroExim").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Producto";
                    Demo.Valores = item.GetDataKeyValue("Tipo_Producto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 62) { }
                if (Producto == 64)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Existencia de Cobertura Forestal";
                    Demo.Valores = item.GetDataKeyValue("Existencia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 65)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo de Cobertura Forestal";
                    Demo.Valores = item.GetDataKeyValue("Cobertura").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 66)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Producto";
                    Demo.Valores = item.GetDataKeyValue("Tipo_Producto").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 67)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                Demo.Orden = 10;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
            }
        }
        protected void Seleccionar_ItemsFortalecimiento(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {
                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());                
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }            

            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                Demo.Orden = 1;
                Demo.Descripcion = "Puesto Quien Ejecuta la Actividad";
                Demo.Valores = item.GetDataKeyValue("Actividad").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 6;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                              
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 68) || (Producto == 74) || (Producto == 75) || (Producto == 81) || (Producto == 82))
                {
                   
                }
                if ((Producto == 71) || (Producto == 76) || (Producto == 230))
                {                    
                    Demo.Orden = 2;
                    Demo.Descripcion = "Ubicación(Aldea, Canton, Zona)";
                    Demo.Valores = item.GetDataKeyValue("UbicacionOrganizacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Comunidad U Organización";
                    Demo.Valores = item.GetDataKeyValue("ComunidadOrganizacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if (Producto == 72)
                {                                                                        
                    Demo.Orden = 2;
                    Demo.Descripcion = "Nombre del Documento";
                    Demo.Valores = item.GetDataKeyValue("NombreDocumento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Año de Vigencia de la Politica";
                    Demo.Valores = item.GetDataKeyValue("AnioVigenciaPolitica").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Acciones de Seguimiento(Cuando Aplique)";
                    Demo.Valores = item.GetDataKeyValue("AccionesSeguimiento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                                        
                }
                if (Producto == 79)
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Acciones de Seguimiento(Cuando Aplique)";
                    Demo.Valores = item.GetDataKeyValue("AccionesSeguimiento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if ((Producto == 69) || (Producto == 70) || (Producto == 73) || (Producto == 77) || (Producto == 78) || (Producto == 80))
                {
                    Demo.Orden = 2;
                    Demo.Descripcion = "Tipo De Actores";
                    Demo.Valores = item.GetDataKeyValue("Actores").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = item.GetDataKeyValue("Actores").ToString();
                    Demo.Valores = item.GetDataKeyValue("TipoActores").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Nombre del Actor";
                    Demo.Valores = item.GetDataKeyValue("NombreActor").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tema Atendidor";
                    Demo.Valores = item.GetDataKeyValue("TemaAtendido").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
            }
        }
        protected void Seleccionar_ItemsIndustriaCom(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }
            if (e.CommandName == "Select1")
            {
                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
                Session["Opcion1"] = 7;
                RecargarActores();
                Llave = 1;
            }
            if (e.CommandName == "Select2")
            {                
                Session["Padre"] = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());                
                Session["Opcion2"] = 6;
                RecargaPertenencia();
                Llave = 1;
            }           

            if (Llave == 0)
            {               
                InicializarExtra();
                RadGridDatosExtra.Visible = true;

                Demo.Orden = 10;
                Demo.Descripcion = "Observaciones";
                Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);

                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 92) || (Producto == 93) || (Producto == 95) || (Producto == 102) || (Producto == 103))
                {                    
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tema";
                    Demo.Valores = item.GetDataKeyValue("DescripcionTema").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_Tema").ToString()) == 7)
                    {
                        Demo.Orden = 2;
                        Demo.Descripcion = "Especifique Tema";
                        Demo.Valores = item.GetDataKeyValue("Tema_Especifico").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }                    
                }
                if ((Producto == 91) || (Producto == 94))
                {                   
                    Demo.Orden = 1;
                    Demo.Descripcion = "Tipo de Registro";
                    Demo.Valores = item.GetDataKeyValue("TipoRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 2;
                    Demo.Descripcion = "Número de Registro";
                    Demo.Valores = item.GetDataKeyValue("NumeroRegistro").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 3;
                    Demo.Descripcion = "Tipo de Organización";
                    Demo.Valores = item.GetDataKeyValue("DescripcioOrganizacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_TipoOrganizacion").ToString()) == 4)
                    {
                        Demo.Orden = 4;
                        Demo.Descripcion = "Especifique Tema";
                        Demo.Valores = item.GetDataKeyValue("Tema_Organizacion").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tipo Empresa";
                    Demo.Valores = item.GetDataKeyValue("DescripcionEmpresa").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                   
                    if (Convert.ToInt32(item.GetDataKeyValue("Id_TipoEmpresa").ToString()) == 4)
                    {
                        Demo.Orden = 6;
                        Demo.Descripcion = "Especifique Tema";
                        Demo.Valores = item.GetDataKeyValue("Tema_Empresa").ToString();
                        GridDatosExtra(Demo, RadGridDatosExtra);
                    }
                    Demo.Orden = 7;
                    Demo.Descripcion = "Tipo de Producto Recomendado";
                    Demo.Valores = item.GetDataKeyValue("Producto_Recomendado").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }               
            }
        }
        protected void Seleccionar_ItemsLicenciaF(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;
            if (e.CommandName == "Select")
            {
                string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
                string Extension = cadena.Substring((cadena.Length - 4), 4);

                if (File.Exists(Enlace))
                {
                    if (Extension == ".pdf")
                    {
                        viewer.Visible = true;
                        Dowload.Visible = false;
                        viewer.Attributes.Add("src", cadena);
                        OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
                    }
                    else
                    {
                        viewer.Visible = false;
                        Dowload.Visible = true;
                        OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
                        Descarga.HRef = cadena;
                    }
                }
                else
                {
                    MensajePantalla("El archivo no existe Fisicamente.");
                }
                Llave = 1;
            }

            if (e.CommandName == "Delete") { Llave = 1; }

            if (Llave == 0)
            {
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                
                Demo.Orden = 1;
                Demo.Descripcion = "Fecha";
                Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 2;
                Demo.Descripcion = "Número de Expediente";
                Demo.Valores = item.GetDataKeyValue("NoExpediente").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);

                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if (Producto == 104)
                {
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                }
                if (Producto == 113)
                {                    
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Modificación";
                    Demo.Valores = item.GetDataKeyValue("TipoDeModificacion").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if (Producto == 105)
                {                    
                    Demo.Orden = 3;
                    Demo.Descripcion = "Resolución de POA";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Licencia";
                    Demo.Valores = item.GetDataKeyValue("TipoLicencia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tipo de Bosque";
                    Demo.Valores = item.GetDataKeyValue("TipoDeBosque").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 108) || (Producto == 111) || (Producto == 110) ||
                    (Producto == 107) || (Producto == 109) || (Producto == 112))
                {
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                    
                }
                if ((Producto == 253) || (Producto == 254))
                {                   
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Informe Trimestral";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Bosque";
                    Demo.Valores = item.GetDataKeyValue("TipoDeBosque").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Licencia";
                    Demo.Valores = item.GetDataKeyValue("NoLicencia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Hectarias";
                    Demo.Valores = item.GetDataKeyValue("Hectarias").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);

                }
                if ((Producto == 259) || (Producto == 261))
                {                    
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Nombre Titular";
                    Demo.Valores = item.GetDataKeyValue("Titular").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Número de Telefono";
                    Demo.Valores = item.GetDataKeyValue("NoTelefono").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Número de Telefono";
                    Demo.Valores = item.GetDataKeyValue("NoTelefono").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Nombre Elaborador";
                    Demo.Valores = item.GetDataKeyValue("Elaborador").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 6;
                    Demo.Descripcion = "Número de Telefono";
                    Demo.Valores = item.GetDataKeyValue("NoTelefonoElabora").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 7;
                    Demo.Descripcion = "Especie";
                    Demo.Valores = item.GetDataKeyValue("Especie").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 8;
                    Demo.Descripcion = "Tratamiento";
                    Demo.Valores = item.GetDataKeyValue("Tratamiento").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 9;
                    Demo.Descripcion = "Coordenada X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaX").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 10;
                    Demo.Descripcion = "Coordenada X";
                    Demo.Valores = item.GetDataKeyValue("CoordenadaY").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                    Demo.Orden = 11;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 106) || (Producto == 114) ||
                    (Producto == 115) || (Producto == 116))
                {                   
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Tipo de Licencia";
                    Demo.Valores = item.GetDataKeyValue("TipoLicencia").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 5;
                    Demo.Descripcion = "Tipo de Bosque";
                    Demo.Valores = item.GetDataKeyValue("TipoDeBosque").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);                   
                    Demo.Orden = 6;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }
                if ((Producto == 117) || (Producto == 118) ||
                    (Producto == 119) || (Producto == 249))
                {                    
                    Demo.Orden = 3;
                    Demo.Descripcion = "Número de Resolución/ de Dictamen";
                    Demo.Valores = item.GetDataKeyValue("NoResolucionInformePOATrimestral").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                    Demo.Orden = 4;
                    Demo.Descripcion = "Observaciones";
                    Demo.Valores = item.GetDataKeyValue("Observaciones").ToString();
                    GridDatosExtra(Demo, RadGridDatosExtra);
                }               
            }
        }
        protected void Seleccionar_ItemsConsumoFamiliar(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            DatosExtraMonitoreo Demo = new DatosExtraMonitoreo();
            List<DatosExtraMonitoreo> DEM = new List<DatosExtraMonitoreo>();
            Session["CargaDataextra"] = DEM;
            int Llave = 0;

            if (e.CommandName == "Delete") { Llave = 1; }

            if (Llave == 0)
            {
                string Describe = string.Empty;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 49) || (Producto == 50)) //aprobado
                {
                    Describe = "Número de Resolución de Aprobación";
                }
                if ((Producto == 250) || (Producto == 251))//denegado
                {
                    Describe = "Número de Resolución de Denegación";
                }
                InicializarExtra();
                RadGridDatosExtra.Visible = true;
                Demo.Orden = 1;
                Demo.Descripcion = "Número de Expediente";
                Demo.Valores = item.GetDataKeyValue("Expediente").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 2;
                Demo.Descripcion = "Número de Dictamen Técnico";
                Demo.Valores = item.GetDataKeyValue("DictamenTecnico").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 3;                
                Demo.Descripcion = Describe;
                Demo.Valores = item.GetDataKeyValue("Resolucion").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 4;
                Demo.Descripcion = "Fecha de Resolución";
                Demo.Valores = item.GetDataKeyValue("Fecha").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);               
                Demo.Orden = 5;
                Demo.Descripcion = "Nombre Científico (SP)";
                Demo.Valores = item.GetDataKeyValue("NombreCientifico").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 6;
                Demo.Descripcion = "Codigo Especie";
                Demo.Valores = item.GetDataKeyValue("CodigoMirasil").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 7;
                Demo.Descripcion = "Troza (Volumen)";
                Demo.Valores = item.GetDataKeyValue("Troza").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 8;
                Demo.Descripcion = "Leña (Volumen)";
                Demo.Valores = item.GetDataKeyValue("Lenia").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);
                Demo.Orden = 9;
                Demo.Descripcion = "Número de Árboles";
                Demo.Valores = item.GetDataKeyValue("TotalDeArboles").ToString();
                GridDatosExtra(Demo, RadGridDatosExtra);                
            }
        }
        /*detalles*/
        protected void RecargaRendimiento()
        {
            GrdRendimiento.Rebind();
            if (GrdRendimiento.Items.Count == 0)
            {
                GrdRendimiento.Visible = false;
            }
            else
            {
                GrdRendimiento.Visible = true;
            }
        }
        private void RecargarModalidades()
        {
            GrdModalidadArea.Rebind();
            if (GrdModalidadArea.Items.Count == 0)
            {
                MensajePantalla("- No Tiene Información -");
                GrdModalidadArea.Visible = false;
            }
            else
            {
                GrdModalidadArea.Visible = true;
                Personas.Visible = true;
            }
        }
        private void RecargarActores()
        {
            GrdActores.Rebind();
            if (GrdActores.Items.Count == 0)
            {
                GrdActores.Visible = false;
                MensajePantalla("- No Tiene Información -");
            }
            else
            {
                GrdActores.Visible = true;
                Personas.Visible = true;
            }
        }
        private void RecargaParticipantes()
        {
            GrdParticipantes.Rebind();
            if (GrdParticipantes.Items.Count == 0)
            {
                GrdParticipantes.Visible = false;
                MensajePantalla("- No Tiene Información -");
            }
            else
            {
                GrdParticipantes.Visible = true;
                Personas.Visible = true;
            }
        }
        private void RecargaPertenencia()
        {
            GrdPertencia.Rebind();
            if (GrdPertencia.Items.Count == 0)
            {
                GrdPertencia.Visible = false;
                MensajePantalla("- No Tiene Información -");
            }
            else
            {
                GrdPertencia.Visible = true;
                Personas.Visible = true;
            }
        }
        private void RecargarNOtas()
        {
            GrdNotas.Rebind();
            if (GrdNotas.Items.Count == 0)
            {
                GrdNotas.Visible = false;
            }
            else
            {
                GrdNotas.Visible = true;
            }
        }
        private void RecargarPublicidad()
        {
            GrdPublicidad.Rebind();
            if (GrdPublicidad.Items.Count == 0)
            {
                GrdPublicidad.Visible = false;
            }
            else
            {
                GrdPublicidad.Visible = true;
            }
        }
        private void RecargarPublico()
        {
            GrdPublico.Rebind();
            if (GrdPublico.Items.Count == 0)
            {
                GrdPublico.Visible = false;
            }
            else
            {
                GrdPublico.Visible = true;
            }
        }
        private void RecargarMaterial()
        {
            GrdMaterial.Rebind();
            if (GrdMaterial.Items.Count == 0)
            {
                GrdMaterial.Visible = false;
            }
            else
            {
                GrdMaterial.Visible = true;
            }
        }
        private void RecargarCampania()
        {
            GrdCampaniaPub.Rebind();
            if (GrdCampaniaPub.Items.Count == 0)
            {
                GrdCampaniaPub.Visible = false;
            }
            else
            {
                GrdCampaniaPub.Visible = true;
            }
        }
        private void NotasPosiNegas()
        {
            GrdNotasPosiNega.Rebind();
            if (GrdNotasPosiNega.Items.Count == 0)
            {
                GrdNotasPosiNega.Visible = false;
            }
            else
            {
                GrdNotasPosiNega.Visible = true;
            }
        }
        protected void GrdModalidadArea_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["CargaInfo"]; 
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 8 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdModalidadArea, CadenaSql);
        }
        protected void GrdActores_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["CargaInfo"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + Convert.ToInt32(Session["Opcion1"].ToString()) + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion +
                                "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdActores, CadenaSql);
        }
        protected void GrdParticipantes_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["CargaInfo"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + Convert.ToInt32(Session["Opcion1"].ToString()) + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion +
                                "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdParticipantes, CadenaSql);
        }
        protected void GrdPertencia_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["CargaInfo"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + Convert.ToInt32(Session["Opcion2"].ToString()) + "," + DMI.Id_PoAnual + "," + 
                                DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPertencia, CadenaSql);
        }
        protected void GrdNotas_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 9 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdNotas, CadenaSql);
        }
        protected void GrdPublicidad_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 10 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPublicidad, CadenaSql);
        }
        protected void GrdPublico_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 11 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdPublico, CadenaSql);
        }
        protected void GrdMaterial_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 12 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdMaterial, CadenaSql);
        }
        protected void GrdCampaniaPub_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 13 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdCampaniaPub, CadenaSql);
        }
        protected void GrdNotasPosiNega_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 14 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdNotasPosiNega, CadenaSql);
        }
        protected void GrdRendimiento_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreoDetalle " + 3 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes + "," + Convert.ToInt32(Session["Padre"].ToString());

            procesos.LlenarRadGrid(GrdRendimiento, CadenaSql);
        }
        private void GrdRendimiento_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdRendimiento.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Especie"].Text == gridDataItem3["Id_Especie"].Text)
                    {
                        gridDataItem2["Especie"].RowSpan = gridDataItem3["Especie"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Especie"].RowSpan + 1;
                        gridDataItem3["Especie"].Visible = false;
                    }
                    if (gridDataItem2["Maquinaria"].Text == gridDataItem3["Maquinaria"].Text)
                    {
                        gridDataItem2["Maquinaria"].RowSpan = gridDataItem3["Maquinaria"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Maquinaria"].RowSpan + 1;
                        gridDataItem3["Maquinaria"].Visible = false;
                    }
                }
            }
        }
        private void GrdNotasPosiNega_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdNotasPosiNega.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoNota"].Text == gridDataItem3["Id_TipoNota"].Text)
                    {
                        gridDataItem2["TipoNota"].RowSpan = gridDataItem3["TipoNota"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoNota"].RowSpan + 1;
                        gridDataItem3["TipoNota"].Visible = false;
                    }
                }
            }
        }
        private void GrdCampaniaPub_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdCampaniaPub.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Campania"].Text == gridDataItem3["Id_Campania"].Text)
                    {
                        gridDataItem2["Campania"].RowSpan = gridDataItem3["Campania"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Campania"].RowSpan + 1;
                        gridDataItem3["Campania"].Visible = false;
                    }
                }
            }
        }
        private void GrdMaterial_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdMaterial.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoMaterial"].Text == gridDataItem3["Id_TipoMaterial"].Text)
                    {
                        gridDataItem2["TipoMaterial"].RowSpan = gridDataItem3["TipoMaterial"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoMaterial"].RowSpan + 1;
                        gridDataItem3["TipoMaterial"].Visible = false;
                    }
                }
            }
        }
        private void GrdPublico_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPublico.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Publico"].Text == gridDataItem3["Id_Publico"].Text)
                    {
                        gridDataItem2["Publico"].RowSpan = gridDataItem3["Publico"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Publico"].RowSpan + 1;
                        gridDataItem3["Publico"].Visible = false;
                    }
                }
            }
        }
        private void GrdPublicidad_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPublicidad.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_TipoPublicidad"].Text == gridDataItem3["Id_TipoPublicidad"].Text)
                    {
                        gridDataItem2["TipoPublicidad"].RowSpan = gridDataItem3["TipoPublicidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoPublicidad"].RowSpan + 1;
                        gridDataItem3["TipoPublicidad"].Visible = false;
                    }
                }
            }
        }
        private void GrdNotas_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdNotas.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Notas"].Text == gridDataItem3["Id_Notas"].Text)
                    {
                        gridDataItem2["Notas"].RowSpan = gridDataItem3["Notas"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Notas"].RowSpan + 1;
                        gridDataItem3["Notas"].Visible = false;
                    }
                }
            }
        }
        private void GrdModalidadArea_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdModalidadArea.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Modalidad"].Text == gridDataItem3["Id_Modalidad"].Text)
                    {
                        gridDataItem2["Modalidad"].RowSpan = gridDataItem3["Modalidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Modalidad"].RowSpan + 1;
                        gridDataItem3["Modalidad"].Visible = false;
                    }
                }
            }
        }
        private void GrdActores_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdActores.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Comunidad"].Text == gridDataItem3["Id_Comunidad"].Text)
                    {
                        gridDataItem2["Comunidad"].RowSpan = gridDataItem3["Comunidad"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Comunidad"].RowSpan + 1;
                        gridDataItem3["Comunidad"].Visible = false;
                    }
                }
            }
        }
        private void GrdParticipantes_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdParticipantes.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Evento"].Text == gridDataItem3["Id_Evento"].Text)
                    {
                        gridDataItem2["Evento"].RowSpan = gridDataItem3["Evento"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Evento"].RowSpan + 1;
                        gridDataItem3["Evento"].Visible = false;
                    }

                    if (gridDataItem2["Id_Participante"].Text == gridDataItem3["Id_Participante"].Text)
                    {
                        gridDataItem2["TipoParticipantes"].RowSpan = gridDataItem3["TipoParticipantes"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoParticipantes"].RowSpan + 1;
                        gridDataItem3["TipoParticipantes"].Visible = false;
                    }
                    if (gridDataItem2["Id_Participante"].Text == gridDataItem3["Id_Participante"].Text)
                    {
                        gridDataItem2["TipoParticipantes"].RowSpan = gridDataItem3["TipoParticipantes"].RowSpan < 2
                        ? 2
                        : gridDataItem3["TipoParticipantes"].RowSpan + 1;
                        gridDataItem3["TipoParticipantes"].Visible = false;
                    }
                }
            }
        }
        private void GrdPertencia_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem gridDataItem1 in (GridItemCollection)this.GrdPertencia.Items)
            {
                GridTableView ownerTableView = gridDataItem1.OwnerTableView;
                for (int index = ownerTableView.Items.Count - 2; index >= 0; --index)
                {
                    GridDataItem gridDataItem2 = ownerTableView.Items[index];
                    GridDataItem gridDataItem3 = ownerTableView.Items[index + 1];

                    if (gridDataItem2["Id_Genero"].Text == gridDataItem3["Id_Genero"].Text)
                    {
                        gridDataItem2["Sexo"].RowSpan = gridDataItem3["Sexo"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Sexo"].RowSpan + 1;
                        gridDataItem3["Sexo"].Visible = false;
                    }

                    if (gridDataItem2["Id_pertenencia"].Text == gridDataItem3["Id_pertenencia"].Text)
                    {
                        gridDataItem2["Pertenecia"].RowSpan = gridDataItem3["Pertenecia"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Pertenecia"].RowSpan + 1;
                        gridDataItem3["Pertenecia"].Visible = false;
                    }
                    if (gridDataItem2["Id_GrupoEtario"].Text == gridDataItem3["Id_GrupoEtario"].Text)
                    {
                        gridDataItem2["Etario"].RowSpan = gridDataItem3["Etario"].RowSpan < 2
                        ? 2
                        : gridDataItem3["Etario"].RowSpan + 1;
                        gridDataItem3["Etario"].Visible = false;
                    }
                }
            }
        }
        /*datos extras*/
        protected void InicializarExtra() 
        {
            RadGridDatosExtra.DataSource = null;
            RadGridDatosExtra.Rebind();
        }
        protected void GridDatosExtra(DatosExtraMonitoreo DatosEtra, RadGrid Grid)
        {                  
            List<DatosExtraMonitoreo> ListaEspeciesLocal = new List<DatosExtraMonitoreo>();
            ListaEspeciesLocal.Clear();
            ListaEspeciesLocal = FillList(Grid);
            ListaEspeciesLocal.Add(DatosEtra);          
            InicializarExtra();
            RadGridDatosExtra.DataSource = ListaEspeciesLocal.OrderBy(x => x.Orden).ToList();
            RadGridDatosExtra.Rebind();
        }
        public List<DatosExtraMonitoreo> FillList(RadGrid Grid)
        {            
            List<DatosExtraMonitoreo> Lista = new List<DatosExtraMonitoreo>();
            Lista.Clear();

            foreach (GridDataItem row in Grid.Items)
            {
                Lista.Add(new DatosExtraMonitoreo
                {
                    Orden = Convert.ToInt32(row["Orden"].Text.ToString()),
                    Descripcion = row["Descripcion"].Text.ToString(),
                    Valores = row["Valores"].Text.ToString()                    
                });
            }           
            return Lista.OrderByDescending(x => x.Orden).ToList();
        }

        protected void CerraVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(visualizar, "Key");
        }

        /*Ventanas*/
        protected void Exportar_Excel(RadWindow Ventana, string Direccion, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_navigateUrl((\"" + Direccion + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_height((\"" + Alto + "\"));" +
                            "$find(\"" + Ventana.ClientID + "\").set_title((\"" + Titulo + "\"));" +
                           "$find(\"" + Ventana.ClientID + "\").show();Sys.Application.remove_load(f);}Sys.Application.add_load(f);";

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Llave, script, true);
        }
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