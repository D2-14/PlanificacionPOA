<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="CatalogoPoaNacional.aspx.cs" Inherits="PlanificacionPOA.Paginas.CatalogoPoaNacional" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Login_Css/Formulario.css" rel="stylesheet" />
    <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
     <div class="page-header card">
         <div class="card-block">
            <h5 class="m-b-10">Mantenimiento del Sistema</h5>
              <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
            <p class="text-muted m-b-10">En este apartado se crearan los Productos, Subproductos, Actividades y configuración de unidades de medida (UM) Nacionales para la planificación Operativa Anual</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>              
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                      <telerik:RadWizard RenderMode="Lightweight" ID="RadWizard1" runat="server" Width="100%" DisplayNavigationButtons="false" Skin="MetroTouch" Culture="es-GT">
                          <WizardSteps>
                           <telerik:RadWizardStep ID="Opcion1" Title="Carga de Productos" StepType="Start" > 
                             <table style="border-collapse:separate;border-spacing:10px;">
                              <tr><td><asp:LinkButton ID="NuevoProducto" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo Producto</asp:LinkButton></td></tr>
                            </table>
                            <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarProducto" runat="server">
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Objetivo:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboObjetivo" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Objetivo" DropDownWidth="600" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Resultados:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboResultado" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Resultado" DropDownWidth="600" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Indicador:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboIndicador" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Indicador" DropDownWidth="600" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo Producto:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboCorrelativoP" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo Producto" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Descripción de Producto:</label></td></tr>
                                <tr><td colspan="2"><asp:TextBox ID="Producto" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="80px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                 <tr>                                                                         
                                   <td>
                                       <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                         <tr>
                                            <td><asp:LinkButton ID="GuardarProducto" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Producto</asp:LinkButton></td>
                                            <td><asp:LinkButton ID="CancelarProducto" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar/Cerrar</asp:LinkButton></td>  
                                         </tr>
                                       </table> 
                                    </td>                                                                         
                                  </tr>
                              </table> 
                              <telerik:RadGrid runat="server" ID="GridProductoNacional" AutoGenerateColumns="False" Width="100%" AllowSorting ="False" 
                                   AllowFilteringByColumn ="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                     <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                   <Selecting AllowRowSelect="True"></Selecting>                                      
                                   </ClientSettings>
                                  <MasterTableView PageSize="10" 
                                  DataKeyNames="Id_producto,IdObjetivo,IdResultado,IdIndicadores,Descripcion_Producto,Id_Region,Id_Subregion,Estado_Producto,
                                        Estado,Objetivo,Resultado,Indicadores,Correlativo,Descripcion_ProductoU" NoMasterRecordsText="Sin Información">
                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                  <%--   <telerik:GridButtonColumn Text="Eliminar producto" CommandName="Delete" UniqueName="BotonX" HeaderText="Eliminar<br/>Producto" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar el producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Producto" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn> --%>
                                    <telerik:GridButtonColumn Text="Activar/Desactivar Producto" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                       <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                       <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                    <telerik:GridButtonColumn Text="Editar el Producto" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                        <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                    <telerik:GridBoundColumn DataField="Id_producto" UniqueName="Id_producto" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="IdObjetivo" UniqueName="IdObjetivo" Display="false"></telerik:GridBoundColumn>  
                                    <telerik:GridBoundColumn DataField="IdResultado" UniqueName="IdResultado" Display="false"></telerik:GridBoundColumn>    
                                    <telerik:GridBoundColumn DataField="IdIndicadores" UniqueName="IdIndicadores" Display="false"></telerik:GridBoundColumn>    
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                    <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Estado_Producto" UniqueName="Estado_Producto" Display="false"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Objetivo" UniqueName="Objetivo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Objetivos">
                                          <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>      
                                    <telerik:GridBoundColumn DataField="Resultado" UniqueName="Resultado" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Resultados">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Indicadores" UniqueName="Indicadores" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Indicadores">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Descripcion_ProductoU" UniqueName="Descripcion_ProductoU" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>  
                                     <telerik:GridBoundColumn DataField="Descripcion_Producto" UniqueName="Descripcion_Producto" AutoPostBackOnFilter="false" Display="false">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>     
                                    <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false" >
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                  </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                    &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                     
                                </telerik:RadGrid>
                           </telerik:RadWizardStep> 
                              <telerik:RadWizardStep ID="Opcion2" Title="Carga de SubProductos"> 
                                <table style="border-collapse:separate;border-spacing:10px;">
                                    <tr><td><asp:LinkButton ID="NuevoSubProducto" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo SubProducto</asp:LinkButton></td></tr>
                                </table>
                                 <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarSubProducto" runat="server">                               
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Producto:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboProducto" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Producto" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>                                
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo SubProducto:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboCorrelativoSP" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo SubProducto" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Descripción de SubProducto:</label></td></tr>
                                <tr><td colspan="2"><asp:TextBox ID="SubProducto" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="80px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                 <tr>                                                                         
                                   <td>
                                       <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                         <tr>
                                            <td><asp:LinkButton ID="GuardarSubProducto" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar SubProducto</asp:LinkButton></td>
                                            <td><asp:LinkButton ID="CancelarSubProducto" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar/Cerrar</asp:LinkButton></td>  
                                         </tr>
                                       </table> 
                                    </td>                                                                         
                                  </tr>
                              </table> 
                              <telerik:RadGrid runat="server" ID="GridSubProductoNacional" AutoGenerateColumns="False" Width="100%" AllowSorting ="False" AllowFilteringByColumn="true" 
                                  AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                     <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                   <Selecting AllowRowSelect="True"></Selecting>                                      
                                   </ClientSettings>
                                  <MasterTableView PageSize="10" 
                                  DataKeyNames="Id_Subproducto,Id_producto,Descripcion_Subproducto,Id_Region,Id_Subregion,Estado_SubProducto,Estado,Producto,Descripcion_SubproductoU,Correlativo" NoMasterRecordsText="Sin Información">
                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                     <%--<telerik:GridButtonColumn Text="Eliminar Subproducto" CommandName="Delete" UniqueName="BotonX" HeaderText="Eliminar<br/>subProducto" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar el subproducto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar subProducto" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn> --%>
                                    <telerik:GridButtonColumn Text="Activar/Desactivar SubProducto" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                       <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                       <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                    <telerik:GridButtonColumn Text="Editar SubProducto" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                        <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                    <telerik:GridBoundColumn DataField="Id_Subproducto" UniqueName="Id_Subproducto" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Id_producto" UniqueName="Id_producto" Display ="false"></telerik:GridBoundColumn>                                                                            
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                    <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn> 
                                     <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Estado_SubProducto" UniqueName="Estado_SubProducto" Display="false"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Producto" UniqueName="Producto" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto">
                                          <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Descripcion_SubproductoU" UniqueName="Descripcion_SubproductoU" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Subproducto">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>    
                                    <telerik:GridBoundColumn DataField="Descripcion_Subproducto" UniqueName="Descripcion_Subproducto" AutoPostBackOnFilter="true" Display="false">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                                                      
                                    <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false" >
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                  </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                    &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                     
                                </telerik:RadGrid>
                           </telerik:RadWizardStep> 
                            <telerik:RadWizardStep ID="Opcion3" Title="Carga de Actividades"> 
                             <table style="border-collapse:separate;border-spacing:10px;">
                                    <tr><td><asp:LinkButton ID="NuevaActividad" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nueva Actividad</asp:LinkButton></td></tr>
                                </table>
                                 <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarActividad" runat="server">                               
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Producto:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboProductoActividad" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Producto" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                 <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione SubProducto:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboSubproducto" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione SubProducto" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>    
                                 <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo Actividad:</label></td></tr>
                                <tr><td><telerik:RadComboBox ID="CboCorrelativoA" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo Actividad" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Descripción de la Actividad:</label></td></tr>
                                <tr><td colspan="2"><asp:TextBox ID="Actividad" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="80px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                 <tr>                                                                         
                                   <td>
                                       <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                         <tr>
                                            <td><asp:LinkButton ID="GuardarActividad" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Actividad</asp:LinkButton></td>
                                            <td><asp:LinkButton ID="CancelarActividad" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar/Cerrar</asp:LinkButton></td>  
                                         </tr>
                                       </table> 
                                    </td>                                                                         
                                  </tr>
                              </table>
                                <telerik:RadGrid runat="server" ID="GridActividadNacional" AutoGenerateColumns="False" Width="100%" AllowSorting ="False" AllowFilteringByColumn="true" 
                                  AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                     <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                   <Selecting AllowRowSelect="True"></Selecting>                                      
                                   </ClientSettings>
                                  <MasterTableView PageSize="10" 
                                  DataKeyNames="Id_Actividad,Id_producto,Id_Subproducto,Descripcion_ActividadU,Descripcion_Actividad,Id_Region,Id_Subregion,Estado_Actividad,Estado,Producto,Subproducto,Correlativo" NoMasterRecordsText="Sin Información">
                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                 <%--    <telerik:GridButtonColumn Text="Eliminar Acvtividad" CommandName="Delete" UniqueName="BotonX" HeaderText="Eliminar<br/>Actividad" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar las Actvidad?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Actividad" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn> --%>
                                    <telerik:GridButtonColumn Text="Activar/Desactivar Actividad" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                       <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                       <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                    <telerik:GridButtonColumn Text="Editar Actividad" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                        <ItemStyle HorizontalAlign="Center" /> 
                                    </telerik:GridButtonColumn> 
                                     <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Visible="false"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Id_producto" UniqueName="Id_producto" Display="false"></telerik:GridBoundColumn>     
                                    <telerik:GridBoundColumn DataField="Id_Subproducto" UniqueName="Id_Subproducto" Display="false"></telerik:GridBoundColumn>                                                                                                          
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                    <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Estado_Actividad" UniqueName="Estado_Actividad" Display="false"></telerik:GridBoundColumn>
                                     <telerik:GridBoundColumn DataField="Producto" UniqueName="Producto" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto">
                                          <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                     <telerik:GridBoundColumn DataField="Subproducto" UniqueName="Subproducto" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="SubProducto">
                                          <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>     
                                    <telerik:GridBoundColumn DataField="Descripcion_ActividadU" UniqueName="Descripcion_ActividadU" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actividad">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                     <telerik:GridBoundColumn DataField="Descripcion_Actividad" UniqueName="Descripcion_Actividad" Display="false" >
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                                                         
                                    <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false" >
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                  </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                    &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                     
                                </telerik:RadGrid>
                            </telerik:RadWizardStep> 
                              <telerik:RadWizardStep ID="Opcion4" Title="Configuración de UM" StepType="Finish"> 
                                 <table style="border-collapse:separate;border-spacing: 10px;">
                                   <tr>
                                       <td><asp:LinkButton ID="NuevaConfiguracionUM" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nueva Configuración UM</asp:LinkButton></td>
                                       <td><asp:LinkButton ID="GuardarConfiguracionUM" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Configuración</asp:LinkButton></td>
                                       <td><asp:LinkButton ID="CancelarGuardadoConfiguracionUM" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar/Cerrar</asp:LinkButton></td>  
                                   </tr>
                                 </table> 
                                  <div id="IngresoConfiguracionUM" runat="server">                                                                     
                                       <table style="margin:auto;border-collapse:separate;border-spacing:5px;">  
                                           <tr style="font-family:Arial;font-size:13px; font-weight:bold;text-align:center;"><td><label for="Label2">Producto</label></td></tr>
                                           <tr><td><telerik:RadComboBox ID="CboProductoUM" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Producto" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                           <tr style="font-family:Arial;font-size:13px; font-weight:bold;text-align:center;"><td><label for="Label2">SubProducto</label></td></tr> 
                                           <tr><td><telerik:RadComboBox ID="CboSubproductoUM" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione SubProducto" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                           <tr style="font-family:Arial;font-size:13px; font-weight:bold;text-align:center;"><td><label for="Label2">Actividad</label></td></tr>
                                           <tr><td><telerik:RadComboBox ID="CboActividadUM" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Actividad" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td></tr>                                          
                                       </table>                                       
                                      <table style="margin:auto;border-collapse:separate;border-spacing: 10px;text-align:center;"> 
                                          <tr style="font-family:Arial;font-size:13px; font-weight:bold;">
                                               <td><label for="Label2">Unidad de Medida -UM1-</label></td>
                                               <td><label for="Label2">Unidad de Medida -UM2-</label></td>
                                               <td><label for="Label2">Unidad de Medida -UM3-</label></td>
                                          </tr>
                                          <tr>
                                              <td><telerik:RadComboBox ID="UM1Dato" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione UM1" Width="200px" Height="280"></telerik:RadComboBox></td>
                                              <td><telerik:RadComboBox ID="UM2Dato" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione UM2" Width="200px" Height="280"></telerik:RadComboBox></td>
                                              <td><telerik:RadComboBox ID="UM3Dato" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione UM3" Width="200px" Height="280"></telerik:RadComboBox></td>
                                         </tr>
                                           <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="3"><label for="Label2">Medio de Verificación</label></td></tr>
                                           <tr><td colspan="3"><asp:TextBox ID="MedioVerificacionUM" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                           <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="3"><label for="Label2">Dirección de Verificación</label></td></tr>
                                           <tr><td colspan="3"><asp:TextBox ID="DireccionVerificacionUM" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                      </table>                                     
                                 </div>
                                  <telerik:RadGrid runat="server" ID="GrdConfiguracionUM" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo_Configuracion,Id_Producto,Id_SubProducto,Id_Actividad,Id_UM1,Id_UM2,Id_UM3,DescripcionProducto,DescripcionSubProducto,DescripcionActividad,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,MedioDeVerificacion,DireccionMedioVerificacion,Id_Region,Id_Subregion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                    <telerik:GridButtonColumn Text="Eliminar producto" CommandName="Delete" UniqueName="BotonA" HeaderText="Eliminar<br/>Producto" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar el producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Producto" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn> 
                                      <telerik:GridButtonColumn Text="Editar el producto Poa" HeaderText ="Editar<br/>Producto" CommandName="Select" UniqueName="BotonB" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Display="false"></telerik:GridBoundColumn>	                                        	                                        
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	                                        
                                            <telerik:GridBoundColumn DataField="DescripcionProducto" UniqueName="DescripcionProducto" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionSubProducto" UniqueName="DescripcionSubProducto" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="SubProducto">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionActividad" UniqueName="DescripcionActividad" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actividades">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
	                                        <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" HeaderText="Medio Verficación" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="DireccionMedioVerificacion" UniqueName="DireccionMedioVerificacion" Display="false" HeaderText="Dirección Medio" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                                                   
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                           </telerik:RadWizardStep> 
                            </WizardSteps> 
                      </telerik:RadWizard>                      
                 </ContentTemplate> 
             </asp:UpdatePanel>
           </div> 
         </div> 
</asp:Content>
