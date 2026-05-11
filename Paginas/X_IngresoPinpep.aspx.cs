using PlanificacionPOA.ConexionBDD;
using PlanificacionPOA.Controladores;
using PlanificacionPOA.Modelos;
using PlanificacionPOA.Modelos.ModelosApi;
using PlanificacionPOA.Modelos.Monitoreo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Xml;
using Telerik.Web.UI;

namespace PlanificacionPOA.Paginas
{
    public partial class X_IngresoPinpep : System.Web.UI.Page
    {
        public ConectarBDD procesos = new ConectarBDD();
        public List<Permisos_del_Sistema> PermisosPermitidos = new List<Permisos_del_Sistema>();
        public Entrada_Sistema PermisosUsuario = new Entrada_Sistema();
        void MensajePantalla(string Mensaje)
        {
            if (Mensaje != string.Empty)
            {
                RadWindowManager1.RadAlert(Mensaje, 360, 180, "Alerta", null);
                return;
            }
        }
        protected void BtnCerrarVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(confirmar, "Key5");
        }
        protected void BtnFinalizarIngreso_Click(object sender, EventArgs e)
        {
            OpenWinwdows(confirmar, "330", "170", "Key5", "Información");
        }
        protected void RegresarPantallaanterior_Click(object sender, EventArgs e)
        {
            Response.Redirect("Componentes_Monitoreo.aspx");
        }
        protected void BtnIrConfiguracion_Click(object sender, EventArgs e)
        {
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];

            if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 85).Permiso != true)
            {
                MensajePantalla("no tiene Permisos.......");
            }
            else
            {
                if (Mim.FinalizarIngresoDeComponente(DMI, ref er))
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void CerraVentana_Click(object sender, EventArgs e)
        {
            CloseWinwdows(visualizar, "Key");
        }
        protected string CadenaSql(int opcion, int Subcomponente)
        {
            ManejoInformacionMonitoreo X = new ManejoInformacionMonitoreo();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];

            string Cadena = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                             X.ValorDeOpcion(3, Subcomponente, DMI.Id_SubComponente) + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + opcion;
            return Cadena;
        }
        private void CboDepartamento_TextChanged(object sender, EventArgs e)
        {
            cboMunicipio.ClearSelection();
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            procesos.LLenarComboT(cboMunicipio, Mim.CadenaComboDeptoMuni(procesos.IntNULLCombo(cboDepartamento).ToString(), DMI.Id_Subregion.ToString(), 2), "Descripcion", "Id", true);
        }
        private void CboSubcomponente_TextChanged(object sender, EventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            DMI.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente);
            Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
            GrdProductos.Rebind();
        }
        protected void GrdProductos_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            if (DMI.Id_SubComponente != 0)
            {
                GrdProductos.Visible = true;
                string CadenaSql = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                                    DMI.Id_SubComponente + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + 2;
                procesos.LlenarRadGrid(GrdProductos, CadenaSql);
            }
            else
            {
                GrdProductos.Visible = false;
            }
        }

        //VERSION API --------------------
        //protected void Seleccionar_Productos(object sender, GridCommandEventArgs e)
        //{
        //    ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
        //    ConectarBDD Grabar = new ConectarBDD();
        //    GridDataItem item = e.Item as GridDataItem;
        //    string Cadena;
        //    int Producto;
        //    DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
        //    if (e.CommandName == "Select")
        //    {
        //        DMI.Id_ProductoVerificable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
        //        DMI.Descripcion_ProductoVerificable = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
        //        Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
        //        GrdProductos.Visible = false;
        //        subcomp.Visible = false;
        //        Informacion.Visible = true;
        //        txtSubcomponente.Text = procesos.StrNULLCombo(CboSubcomponente);
        //        ProductoV.Text = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
        //        Cadena = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
        //                            DMI.Id_SubComponente + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + 3 + "," + Producto;
        //        DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

        //        DMI.Id_UM1 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM1"].ToString());
        //        DMI.Id_UM2 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM2"].ToString());
        //        DMI.Id_UM3 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM3"].ToString());

        //        Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;

        //        LblUM1.Text = "UM1 " + Datos.Tables[0].Rows[0]["DescripcionUM1"].ToString();
        //        trum1.Visible = vp.ValidarCamposUM(DMI.Id_UM1, 1).ExpresionBool;
        //        txtum1.Text = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionNumber;
        //        txtum1.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionBool;

        //        LblUM2.Text = "UM2 " + Datos.Tables[0].Rows[0]["DescripcionUM2"].ToString();
        //        trum2.Visible = vp.ValidarCamposUM(DMI.Id_UM2, 1).ExpresionBool;
        //        txtum2.Text = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionNumber;
        //        txtum2.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionBool;

        //        LblUM3.Text = "UM3 " + Datos.Tables[0].Rows[0]["DescripcionUM3"].ToString();
        //        trum3.Visible = vp.ValidarCamposUM(DMI.Id_UM3, 1).ExpresionBool;
        //        txtum3.Text = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionNumber;
        //        txtum3.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionBool;

        //        //Validar objetos visibles
        //        Guardar.Visible = false;
        //        Label9.Visible = true;
        //        cboMunicipio.Visible = true;
        //        if ((Producto == 169) ||
        //             (Producto == 178))
        //        {
        //            observa.Visible = true;
        //            t1.Visible = true;
        //            t2.Visible = true;
        //            t3.Visible = true;
        //            t4.Visible = true;
        //            tmes.Visible = false;
        //            procesos.LLenarComboT(CboModalidad, "SELECT Id_Modalidad Id,Descripcion  FROM Modalidad_PINPEPMonitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
        //            Guardar.Visible = true;
        //        }
        //        if ((Producto == 164) || (Producto == 165) || (Producto == 171) || (Producto == 172) || (Producto == 175) || (Producto == 180))
        //        {
        //            observa.Visible = true;
        //            t1.Visible = true;
        //            t2.Visible = true;
        //            t3.Visible = false; //Expediente, Resolucion
        //            t4.Visible = false; // Modalidad
        //            tmes.Visible = false;
        //            procesos.LLenarComboT(CboModalidad, "SELECT Id_Modalidad Id,Descripcion  FROM Modalidad_PINPEPMonitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
        //            Guardar.Visible = true;
        //        }
        //        if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) ||
        //            (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
        //        {
        //            observa.Visible = false;
        //            t1.Visible = false;
        //            t2.Visible = false;
        //            t3.Visible = false;
        //            t4.Visible = false;
        //            tmes.Visible = true;
        //            txtum2.Text = "0";
        //            txtum2.ReadOnly = true;
        //            txtum3.Text = "0";
        //            txtum3.ReadOnly = true;
        //            Label9.Visible = false;
        //            cboMunicipio.Visible = false;
        //            procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
        //            cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
        //            Guardar.Visible = true;
        //        }
        //        RecargarGrid();
        //        LimpiarArchivo();
        //    }
        //}

        protected void Seleccionar_Productos(object sender, GridCommandEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            ConectarBDD Grabar = new ConectarBDD();
            GridDataItem item = e.Item as GridDataItem;
            string Cadena;
            int Producto;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            if (e.CommandName == "Select")
            {
                DMI.Id_ProductoVerificable = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                DMI.Descripcion_ProductoVerificable = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVeficable").ToString());
                GrdProductos.Visible = false;
                subcomp.Visible = false;
                Informacion.Visible = true;
                txtSubcomponente.Text = procesos.StrNULLCombo(CboSubcomponente);
                ProductoV.Text = item.GetDataKeyValue("DescripcionProductoVeficable").ToString();
                Cadena = "Sp_obtener_data_Actividad_Subregional_Seguimiento " + DMI.Id_PoAnual + "," + DMI.IdComponente + "," +
                                    DMI.Id_SubComponente + "," + DMI.Id_Subregion + "," + DMI.Id_Mes + "," + 3 + "," + Producto;
                DataSet Datos = Grabar.obtenerDataSetCodigo(Cadena, "Tabla");

                DMI.Id_UM1 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM1"].ToString());
                DMI.Id_UM2 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM2"].ToString());
                DMI.Id_UM3 = Convert.ToInt32(Datos.Tables[0].Rows[0]["Id_UM3"].ToString());

                Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;

                LblUM1.Text = "UM1 " + Datos.Tables[0].Rows[0]["DescripcionUM1"].ToString();
                trum1.Visible = vp.ValidarCamposUM(DMI.Id_UM1, 1).ExpresionBool;
                txtum1.Text = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionNumber;
                //txtum1.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM1, 2).ExpresionBool;

                LblUM2.Text = "UM2 " + Datos.Tables[0].Rows[0]["DescripcionUM2"].ToString();
                trum2.Visible = vp.ValidarCamposUM(DMI.Id_UM2, 1).ExpresionBool;
                txtum2.Text = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionNumber;
                //txtum2.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM2, 2).ExpresionBool;

                LblUM3.Text = "UM3 " + Datos.Tables[0].Rows[0]["DescripcionUM3"].ToString();
                trum3.Visible = vp.ValidarCamposUM(DMI.Id_UM3, 1).ExpresionBool;
                txtum3.Text = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionNumber;
                //txtum3.ReadOnly = vp.ValidarCamposUM(DMI.Id_UM3, 2).ExpresionBool;

                //Validar objetos visibles
                Guardar.Visible = false;
                Label9.Visible = true;
                cboMunicipio.Visible = true;
                if ((Producto == 169) ||
                     (Producto == 178))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    t3.Visible = true;
                    t4.Visible = true;
                    tmes.Visible = false;
                    procesos.LLenarComboT(CboModalidad, "SELECT Id_Modalidad Id,Descripcion  FROM Modalidad_PINPEPMonitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }
                if ((Producto == 164) || (Producto == 165) || (Producto == 171) || (Producto == 172) || (Producto == 175) || (Producto == 180))
                {
                    observa.Visible = true;
                    t1.Visible = true;
                    t2.Visible = true;
                    t3.Visible = false; //Expediente, Resolucion
                    t4.Visible = false; // Modalidad
                    tmes.Visible = false;
                    procesos.LLenarComboT(CboModalidad, "SELECT Id_Modalidad Id,Descripcion  FROM Modalidad_PINPEPMonitoreo WHERE Estado = 1;", "Descripcion", "Id", true);
                    Guardar.Visible = true;
                }

                //API
                if ((Producto == 166) || (Producto == 168) || (Producto == 170))

                {
                    observa.Visible = true;
                    t1.Visible = false;
                    t2.Visible = false;
                    t3.Visible = false;
                    t4.Visible = false;
                    tmes.Visible = true;
                    txtum2.Text = "0";
                    txtum2.ReadOnly = false;
                    txtum3.Text = "0";
                    txtum3.ReadOnly = true;
                    Label9.Visible = true;
                    cboMunicipio.Visible = true;
                    procesos.LLenarComboT(cboMesIngreso, "SELECT Id_meses Id,Descripcion_Mes Descripcion FROM Meses WHERE Id_meses <=" + DMI.Id_Mes, "Descripcion", "Id", true);
                    cboMesIngreso.SelectedValue = DMI.Id_Mes.ToString();
                    Guardar.Visible = true;
                }

                if ((Producto == 174) || (Producto == 173) || (Producto == 177) || (Producto == 179))
                {
                    txtObservaciones.Visible = true;
                    Label12.Visible = false;
                    t1.Visible = true;
                    t2.Visible = true;
                    tmes.Visible = false;
                    t3.Visible = false;
                    t4.Visible = false;
                    txtum1.ReadOnly = false;
                    Guardar.Visible = true;


                }

                if ((Producto == 297) || (Producto == 298) || (Producto == 299) || (Producto == 300) || (Producto == 292) || (Producto == 293) || (Producto == 294)
                   || (Producto == 295) || (Producto == 296)|| (Producto == 301)|| (Producto == 302)|| (Producto == 303)|| (Producto == 304)
                   || (Producto == 166)|| (Producto == 167)|| (Producto == 168)|| (Producto == 170)
                   )
                {
                    cboMunicipio.Visible = true;
                    Guardar.Visible = true;
                    //FECHA
                    t1.Visible = true;
                    t2.Visible = true;
                    //
                    tmes.Visible = false;
                }

                RecargarGrid();
                LimpiarArchivo();
            }
        }

        protected void CancelarIngreso_Click(object sender, EventArgs e)
        {
            cboDepartamento.ClearSelection();
            cboMunicipio.ClearSelection();
            txtFecha.Clear();
            GrdProductos.Visible = true;
            subcomp.Visible = true;
            Informacion.Visible = false;
            cboMunicipio.Items.Clear();
            txtObservaciones.Text = string.Empty;
            CboModalidad.ClearSelection();
            txtnoResolInforme.Text = string.Empty;
            txtExpediente.Text = string.Empty;
        }
        protected void FillCampos()
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            lblPoa.Text = DMI.NombrePOA;
            lblComponente.Text = DMI.Descripcion_Componente;
            lbsubregion.Text = DMI.Nombre_SubRegion;
            Lblmes.Text = DMI.Descripcion_mes;
            DMI.Id_SubComponente = 0;
            procesos.LLenarComboT(CboSubcomponente, CadenaSql(1, 0), "Descripcion", "Id", true);
            CboSubcomponente.SelectedIndex = 0;
            DMI.Id_SubComponente = procesos.IntNULLCombo(CboSubcomponente);
            GrdProductos.Rebind();
            Informacion.Visible = false;
            subcomp.Visible = true;
            procesos.LLenarComboT(cboDepartamento, Mim.CadenaComboDeptoMuni("", DMI.Id_Subregion.ToString(), 1), "Descripcion", "Id", true);
            Session["DatosMonitoreoIngresoMetasENVIO"] = DMI;
        }
        protected void GrdIngresoEncabezado_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            string CadenaSql = "Sp_obtener_data_GridProductosMonitoreo " + 12 + "," + DMI.Id_PoAnual + "," + DMI.Id_Subregion + "," + DMI.IdComponente
                                + "," + DMI.Id_SubComponente + "," + DMI.Id_ProductoVerificable + "," + DMI.Id_Mes;

            procesos.LlenarRadGrid(GrdIngresoEncabezado, CadenaSql);
        }
        protected void GrdIngresoEncabezado_ItemDataBound(object sender, GridItemEventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo vp = new ValidarCamposObligatoriosMonitoreo();
            Validar_Productos_Codigo VPC = new Validar_Productos_Codigo();
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());

                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM1").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM2").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUM(Convert.ToInt32(item.GetDataKeyValue("Id_UM3").ToString()), 1).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("BotonA").Display = VPC.ShowHideProductoPINPEP(Producto, 1);
                /*validar Valores 0*/
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM1").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM1").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM2").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM2").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("DescripcionUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
                GrdIngresoEncabezado.MasterTableView.GetColumn("ValorUM3").Display = vp.ValidarCamposUMValor(Convert.ToDecimal(item.GetDataKeyValue("ValorUM3").ToString())).ExpresionBool;
            }
        }
        protected void Inicializacion_Objetos()
        {
            btnCerrarVentana.Click += new EventHandler(BtnCerrarVentana_Click);
            btnIrConfiguracion.Click += new EventHandler(BtnIrConfiguracion_Click);
            CerraVentana.Click += new EventHandler(CerraVentana_Click);
            CboSubcomponente.TextChanged += new EventHandler(CboSubcomponente_TextChanged);
            btnFinalizarIngreso.Click += new EventHandler(BtnFinalizarIngreso_Click);
            RegresarPantallaanterior.Click += new EventHandler(RegresarPantallaanterior_Click);
            GrdProductos.NeedDataSource += new GridNeedDataSourceEventHandler(GrdProductos_NeedDataSource);
            GrdProductos.ItemCommand += new GridCommandEventHandler(Seleccionar_Productos);
            CancelarIngreso.Click += new EventHandler(CancelarIngreso_Click);
            cboDepartamento.TextChanged += new EventHandler(CboDepartamento_TextChanged);
            Guardar.Click += new EventHandler(Guardar_Click);
            GrdIngresoEncabezado.NeedDataSource += new GridNeedDataSourceEventHandler(GrdIngresoEncabezado_NeedDataSource);
            GrdIngresoEncabezado.ItemDataBound += GrdIngresoEncabezado_ItemDataBound;
            GrdIngresoEncabezado.ItemCommand += new GridCommandEventHandler(Seleccionar_Items);
            GrdIngresoEncabezado.DeleteCommand += new GridCommandEventHandler(Eliminar_Items);
            RadDocumentoVerificacion.FileUploaded += new FileUploadedEventHandler(RadDocumentoVerificacion_FileUploaded);
        }
        protected void RadDocumentoVerificacion_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            Session["CargaDocumento"] = RadDocumentoVerificacion;
            Lblarchivo.Text = @"Archivo Esta Precargado";
        }
        private void Limpiar_IngresoUM()
        {
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            ManejoInformacionMonitoreo xdata = new ManejoInformacionMonitoreo();

            if (xdata.Tipo_conteo(DMI.Id_UM1) != 1)
            {
                txtum1.Text = string.Empty;
            }
            if (xdata.Tipo_conteo(DMI.Id_UM2) != 1)
            {
                txtum2.Text = string.Empty;
            }
            if (xdata.Tipo_conteo(DMI.Id_UM3) != 1)
            {
                txtum3.Text = string.Empty;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Inicializacion_Objetos();
            PermisosPermitidos = (List<Permisos_del_Sistema>)Session["Permisos_Sistema"];
            if (Session["Usuario"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                if (PermisosUsuario.Verifica_Permisos(PermisosPermitidos, 80).Permiso != true)
                {
                    Response.Redirect("Componentes_Monitoreo.aspx");
                }
                FillCampos();
            }
        }
        protected void Guardar_Click(object sender, EventArgs e)
        {
            ValidarCamposObligatoriosMonitoreo Validar = new ValidarCamposObligatoriosMonitoreo();
            EncabezadoPINPEPIngreso Generico = new EncabezadoPINPEPIngreso();
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            ManejarApi mapi = new ManejarApi();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();
            Medios DA = new Medios();
            EnvioDatosApi Edapi = new EnvioDatosApi();
            Validar_Data v;
            DatosMonitoreoIngresoMetas DMI = (DatosMonitoreoIngresoMetas)Session["DatosMonitoreoIngresoMetasENVIO"];
            Generico.Id_PoAnual = DMI.Id_PoAnual;
            Generico.Id_Componente = DMI.IdComponente;
            Generico.Id_Subcomponente = procesos.IntNULLCombo(CboSubcomponente);
            Generico.Id_ProductoVerificable = DMI.Id_ProductoVerificable;
            Generico.Id_Subregion = DMI.Id_Subregion;
            Generico.Id_Departamento = procesos.IntNULLCombo(cboDepartamento);
            Generico.Id_Municipio = procesos.IntNULLCombo(cboMunicipio);
            Generico.Id_Mes = Mim.ValorDelMes(cboMesIngreso, DMI.Id_Mes);
            Generico.Id_UM1 = DMI.Id_UM1;
            Generico.Id_UM2 = DMI.Id_UM2;
            Generico.Id_UM3 = DMI.Id_UM3;
            Generico.ValorUM1 = procesos.DecimalRadNumericTextBox(txtum1);
            Generico.ValorUM2 = procesos.DecimalRadNumericTextBox(txtum2);
            Generico.ValorUM3 = procesos.DecimalRadNumericTextBox(txtum3);
            Generico.Fecha = procesos.Fechas(txtFecha);
            Generico.Observaciones = txtObservaciones.Text.ToString();
            Generico.Id_usu = DMI.Id_Usuario;
            Generico.Id_Modalidad = procesos.IntNULLCombo(CboModalidad);
            Generico.NoExpediente = txtExpediente.Text.ToString();
            Generico.ResolucionInforme = txtnoResolInforme.Text.ToString();
            RadDocumentoVerificacion = (RadAsyncUpload)Session["CargaDocumento"];

            //CR  agregar fecha y hora para concatenarselo al nombre del documento que se va a subir
            string FechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            //Aprobacion
            if (Generico.Id_Subcomponente == 26) { Generico.Tipo_SubComponente = 3; }
            //Certificacion
            if (Generico.Id_Subcomponente == 27) { Generico.Tipo_SubComponente = 4; }



            string Mantenimiento;
            if (Session["Mantenimiento"] == "True")
            {
                Mantenimiento = "True";
            }
            else
            {
                Mantenimiento = "False";
            }


            v = Validar.Campos_Obligatorio_PINPEP(Generico, RadDocumentoVerificacion,Mantenimiento);
            if (v.Verificar)
            {
                MensajePantalla(v.Mensaje);
            }
            else
            {
                XmlDocument DescripcionProductoAPI = new XmlDocument();
                int Producto = DMI.Id_ProductoVerificable;

                //Version Manual
                //if ((Producto == 166) || (Producto == 168) || (Producto == 170) 
                if ((Producto == 0)
                    //|| (Producto == 173) ||  (Producto == 174) ||  (Producto == 177) || (Producto == 179))
                    )

                //Version API
                //if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) 
                //   || (Producto == 173) ||  (Producto == 174) ||  (Producto == 177) || (Producto == 179))
                //    )

                {
                    Generico.MedioDeVerificacion = string.Empty;
                    Edapi.Month = Generico.Id_Mes;
                    Edapi.Year = mapi.VerificarAnio(DMI.Id_PoAnual);
                    DescripcionProductoAPI = mapi.Incentivos(Edapi, Generico.Tipo_SubComponente);
                }
                else
                {
                    DA = Mim.SubirPDF(DMI, RadDocumentoVerificacion,FechaHora);
                    Generico.MedioDeVerificacion = DA.Medio_Local;
                }

                XmlDocument DescripcionProducto = Mim.DetalleXMLProductoPinpep(Generico);
                if (Mim.GuardarItemEncabezadoApi(3, DMI, DescripcionProducto, DescripcionProductoAPI, ref er))
                {
                    //Version API
                     //if ((Producto != 166) || (Producto != 167) || (Producto != 168) || (Producto != 170) ||
                     //   (Producto != 173) || (Producto != 174) || (Producto != 177) || (Producto != 179))

                        //Version Manual
                        if (Producto != 0)
                        {
                        foreach (UploadedFile f in RadDocumentoVerificacion.UploadedFiles)
                        {

                            //f.SaveAs(DA.Medio_Subir.Replace(".pdf", $"{FechaHora}.pdf"), true);
                            f.SaveAs(DA.Medio_Subir, true);
                        }
                    }
                    txtExpediente.Text = string.Empty;
                    txtnoResolInforme.Text = string.Empty;
                    Limpiar_IngresoUM();
                    RecargarGrid();
                    LimpiarArchivo();
                    cboMunicipio.ClearSelection();
                    txtObservaciones.Text = string.Empty;
                    txtFecha.Clear();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }
        protected void LimpiarArchivo()
        {
            RadAsyncUpload Arch = new RadAsyncUpload();
            Lblarchivo.Text = string.Empty;
            RadDocumentoVerificacion.Dispose();
            Session["CargaDocumento"] = Arch;
        }
        private void RecargarGrid()
        {
            GrdIngresoEncabezado.Rebind();
            if (GrdIngresoEncabezado.Items.Count == 0)
            {
                GrdIngresoEncabezado.Visible = false;
            }
            else
            {
                GrdIngresoEncabezado.Visible = true;
            }
        }
        protected void Eliminar_Items(object source, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
            ManejoInformacionMonitoreo Mim = new ManejoInformacionMonitoreo();
            EliminacionDatoMonitoreo edm = new EliminacionDatoMonitoreo();
            Mensajes_Error_BDD er = new Mensajes_Error_BDD();

            edm.Correlativo = Convert.ToInt32(item.GetDataKeyValue("Correlativo").ToString());
            edm.Id_PoAnual = Convert.ToInt32(item.GetDataKeyValue("Id_PoAnual").ToString());
            edm.Id_Subregion = Convert.ToInt32(item.GetDataKeyValue("Id_Subregion").ToString());
            edm.Id_Mes = Convert.ToInt32(item.GetDataKeyValue("Id_Mes").ToString());
            edm.Id_usu = Convert.ToInt32(Session["Usuario"].ToString());
            edm.Id_Componente = Convert.ToInt32(item.GetDataKeyValue("Id_Componente").ToString());

            if (Mim.Eliminar_MedioVerificacionFisico(item.GetDataKeyValue("MedioDeVerificacion").ToString()) == false)
            {
                if (Mim.Eliminacion_Producto(13, edm, ref er))
                {
                    RecargarGrid();
                }
                else
                {
                    MensajePantalla(er.Descripcion.ToString());
                }
            }
        }

        // Version API
        //protected void Seleccionar_Items(object sender, GridCommandEventArgs e)
        //{
        //    GridDataItem item = e.Item as GridDataItem;
        //    int Llave = 0;
        //    if (e.CommandName == "Select")
        //    {
        //        string cadena = @"~\" + item.GetDataKeyValue("MedioDeVerificacion").ToString();
        //        string Enlace = AppDomain.CurrentDomain.BaseDirectory + item.GetDataKeyValue("MedioDeVerificacion").ToString();
        //        string Extension = cadena.Substring((cadena.Length - 4), 4);

        //        if (File.Exists(Enlace))
        //        {
        //            if (Extension == ".pdf")
        //            {
        //                viewer.Visible = true;
        //                Dowload.Visible = false;
        //                viewer.Attributes.Add("src", cadena);
        //                OpenWinwdows(visualizar, "980", "700", "Key", "Visualizador de Documento");
        //            }
        //            else
        //            {
        //                viewer.Visible = false;
        //                Dowload.Visible = true;
        //                OpenWinwdows(visualizar, "300", "250", "Key", "Descargar Archivo de Excel");
        //                Descarga.HRef = cadena;
        //            }
        //        }
        //        else
        //        {
        //            MensajePantalla("El archivo no existe Fisicamente.");
        //        }
        //        Llave = 1;
        //    }

        //    if (e.CommandName == "Delete") { Llave = 1; }

        //    if (Llave == 0)
        //    {
        //        x1.Visible = false;
        //        x2.Visible = false;
        //        Table1.Visible = false;
        //        LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
        //        int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
        //        if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
        //            (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180))
        //        {
        //            Table1.Visible = true;
        //            x1.Visible = true;
        //            x2.Visible = false;
        //            lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
        //            LblResolucion.Text = item.GetDataKeyValue("ResolucionInforme").ToString();
        //            lblModalidad.Text = item.GetDataKeyValue("Modalidad").ToString();
        //        }
        //        if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) ||
        //            (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
        //        {
        //            Table1.Visible = false;
        //            x1.Visible = false;
        //            x2.Visible = true;
        //            if ((Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
        //            {
        //                Label41.Text = "Dictamen Tecnico de Certificación:";
        //                Label40.Text = "Fecha de Certificación:";
        //                Label16.Text = "Área Certificada:";
        //            }

        //            if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170))
        //            {
        //                Label41.Text = "Número de Resolución de Aprobación:";
        //                Label40.Text = "Fecha de Aprobación:";
        //                Label16.Text = "Área Aprobada:";
        //            }
        //            lblNoExpediente2.Text = item.GetDataKeyValue("NoExpediente").ToString();
        //            LbResolucion2.Text = item.GetDataKeyValue("ResolucionInforme").ToString();
        //            lblFechaCorresponde.Text = item.GetDataKeyValue("Fecha").ToString();
        //            lblArea.Text = item.GetDataKeyValue("ValorUM2").ToString();
        //        }
        //        OpenWinwdows(VerDatosExtra, "520", "480", "Key", "Información Adicional del Ingresos");
        //    }
        //}

        //Version A PIESITO
        protected void Seleccionar_Items(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = e.Item as GridDataItem;
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

            int Producto_ = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
            if ((Producto_ == 174) || (Producto_ == 173) || (Producto_ == 177) || (Producto_ == 179))
            {

                Llave = 1;
            }

            if (Llave == 0)
            {
                x1.Visible = false;
                x2.Visible = false;
                Table1.Visible = false;
                LblObserva.Text = item.GetDataKeyValue("Observaciones").ToString();
                int Producto = Convert.ToInt32(item.GetDataKeyValue("Id_ProductoVerificable").ToString());
                if ((Producto == 164) || (Producto == 165) || (Producto == 169) || (Producto == 171) ||
                    (Producto == 172) || (Producto == 175) || (Producto == 178) || (Producto == 180))
                {
                    Table1.Visible = true;
                    x1.Visible = true;
                    x2.Visible = false;
                    lblNoExpediente.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LblResolucion.Text = item.GetDataKeyValue("ResolucionInforme").ToString();
                    lblModalidad.Text = item.GetDataKeyValue("Modalidad").ToString();
                }
                if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170) ||
                   (Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
                {
                    Table1.Visible = false;
                    x1.Visible = false;
                    x2.Visible = true;
                    if ((Producto == 173) || (Producto == 174) || (Producto == 177) || (Producto == 179))
                    {
                        Label41.Text = "Dictamen Tecnico de Certificación:";
                        Label40.Text = "Fecha de Certificación:";
                        Label16.Text = "Área Certificada:";
                    }

                    if ((Producto == 166) || (Producto == 167) || (Producto == 168) || (Producto == 170))
                    {
                        Label41.Text = "Número de Resolución de Aprobación:";
                        Label40.Text = "Fecha de Aprobación:";
                        Label16.Text = "Área Aprobada:";
                    }
                    lblNoExpediente2.Text = item.GetDataKeyValue("NoExpediente").ToString();
                    LbResolucion2.Text = item.GetDataKeyValue("ResolucionInforme").ToString();
                    lblFechaCorresponde.Text = item.GetDataKeyValue("Fecha").ToString();
                    lblArea.Text = item.GetDataKeyValue("ValorUM2").ToString();
                }
                OpenWinwdows(VerDatosExtra, "520", "480", "Key", "Información Adicional del Ingresos");
            }
        }



        /*manejo de ventanas*/
        protected void OpenWinwdows(RadWindow Ventana, string Largo, string Alto, string Llave, string Titulo)
        {
            string script = "function f(){$find(\"" + Ventana.ClientID + "\").set_width((\"" + Largo + "\"));" +
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
    }
}