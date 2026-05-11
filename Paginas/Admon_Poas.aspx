<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Admon_Poas.aspx.cs" Inherits="PlanificacionPOA.Paginas.Admon_Poas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
     <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Mantenimientos de Sistema</h5>
           <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
            <p class="text-muted m-b-10">En este apartado podra hacer ingreso de datos a tablas que se utilizan en el sistema de planificación</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                      <telerik:RadTabStrip runat="server" ID="ControladorTAb" MultiPageID="Paginas" SelectedIndex="0" Skin="MetroTouch" Culture="es-GT">
                        <Tabs>
                            <telerik:RadTab Text="Mantenimiento Poa Regional" Width="400px"></telerik:RadTab>
                            <telerik:RadTab Text="Mantenimiento Poa Nacional" Width="400px"></telerik:RadTab>             
                        </Tabs>
                        </telerik:RadTabStrip>
                          <telerik:RadMultiPage ID="Paginas" runat="server" SelectedIndex="0"> 
                                <telerik:RadPageView ID="Regional" runat="server" Height="100%">
                                      <telerik:RadWizard RenderMode="Lightweight" runat="server" ID="RadWizard1" Width="100%" Skin="WebBlue" RenderedSteps="Active" DisplayNavigationButtons="false" Culture="es-GT">
                                          <WizardSteps>
                                               <telerik:RadWizardStep ID="RadWizardStep1" Title="Componentes POA Regional" StepType="Start" >                                                                                                       
                                                                 <table style="border-collapse:separate;border-spacing:10px;">
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="NuevoComponente" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo Componente</asp:LinkButton></td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarComponente" runat="server">
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Descripción del Componente:</label></td></tr>
                                                                    <tr><td colspan="2"><asp:TextBox ID="Componente" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="90px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo Componente:</label></td></tr>
                                                                    <tr><td><telerik:RadComboBox ID="CboCorrelativoComponente1" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo Componente" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                                                    <tr>                                                                         
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarComponente" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Componente</asp:LinkButton></td>
                                                                                    <td><asp:LinkButton ID="CancelarComponente" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridComponente" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                     <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                                                       {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                                                        &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>  
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdComponente,Descripcion_Componente,Estado_Componente,Estado,Correlativo,Id_correlativo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Componente" HeaderText ="Activar/Desactivar" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton"  HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                          <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center"  Width="10px"/>                                                                           
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar el componente del poa" CommandName="Select1" HeaderText ="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                       <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" Width="10px" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdComponente" UniqueName="IdComponente" Visible="false"></telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="Id_correlativo" UniqueName="Id_correlativo" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado_Componente" UniqueName="Estado_Componente" Visible="false"></telerik:GridBoundColumn>                                                                        
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Componente" UniqueName="Descripcion_Componente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componentes">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="Correlativo"  UniqueName="Correlativo" HeaderText="Componente" AllowFiltering="false">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                   </Columns>
                                                                </MasterTableView>                                                                                                                                                                                         
                                                            </telerik:RadGrid>                                                         
                                               </telerik:RadWizardStep> 
                                               <telerik:RadWizardStep ID="RadWizardStep2" Title="SubComponente POA Regional">
                                                   <table style="border-collapse:separate;border-spacing: 10px;">                                                                    
                                                     <tr>
                                                        <td><asp:LinkButton ID="NuevoSubComponente" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo SubComponente</asp:LinkButton> </td>
                                                     </tr>
                                                   </table>
                                                       <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarSubComponente" runat="server"> 
                                                                      <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponente1" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="500" Width="400px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo SubComponente:</label></td></tr>
                                                                    <tr><td><telerik:RadComboBox ID="cboSubcomponten1" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo SubComponente" Width="400px" Height="280"></telerik:RadComboBox></td></tr>
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del SubComponente:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="SubComponente" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>                                                                   
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarSubComponente" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar SubComponente</asp:LinkButton></td>
                                                                                     <td><asp:LinkButton ID="CancelarSubComponente" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr id="TituloSubcomponente" runat="server" style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                     <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponenteBusqueda" Skin="MetroTouch" runat="server" AutoPostBack="true" Font-Size="12px" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox><br /></td>
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridSubComponente" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="Id_SubComponente,Id_Componente,Descripcion_SubComponente,Estado_SubComponente,Estado,Descripcion_Componente,
                                                                         correlativo,Id_correlativo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar SubComponente" HeaderText ="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar el subcomponente del poa" CommandName="Select1" HeaderText ="Editar"  UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false" ></telerik:GridBoundColumn>   
                                                                         <telerik:GridBoundColumn DataField="Id_correlativo" UniqueName="Id_correlativo" Display="false" ></telerik:GridBoundColumn>        
                                                                        <telerik:GridBoundColumn DataField="Estado_SubComponente" UniqueName="Estado_SubComponente" Visible="false"></telerik:GridBoundColumn> 
                                                                         <telerik:GridBoundColumn DataField="Descripcion_Componente" UniqueName="Descripcion_Componente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componente">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_SubComponente" UniqueName="Descripcion_SubComponente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="SubComponente">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                          <telerik:GridBoundColumn DataField="Correlativo"  UniqueName="Correlativo" HeaderText="Subcomponente" AllowFiltering="false">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                   </Columns>
                                                                </MasterTableView>
                                                                    <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                                                       {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                                                        &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                     
                                                            </telerik:RadGrid>
                                               </telerik:RadWizardStep> 
                                              <telerik:RadWizardStep ID="RadWizardStep3" Title="Unidad de Medida POA Regional">
                                                         <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr>
                                                                      <td><asp:LinkButton ID="NuevoUnidaMedidaRegional" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nueva Unidad de Medida</asp:LinkButton> </td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarUnidaMedidaRegional" runat="server"> 
                                                                      <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponente2" Skin="MetroTouch" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="500" Width="520px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">SubComponente:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="cboSubcomponenteUnidad" Skin="MetroTouch" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione SubComponente" DropDownWidth="500" Width="520px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td><label for="Label2">Unidad de Medida:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboUnidadMedida1" Skin="MetroTouch" runat="server" EmptyMessage="Seleccione Unidad de Medida" Width="520px"></telerik:RadComboBox></td>
                                                                    </tr>                                                                                                                                                                                       
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción de Unidad de Medida:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="UnidaMedidaRegional" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="520px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Tipo de Conteo:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboTipoConteo" Skin="MetroTouch" runat="server" AutoPostBack="true" EmptyMessage="Seleccione Tipo de Conteo" Width="520px"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarUnidaMedidaRegional" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Unidad de Medida</asp:LinkButton></td>
                                                                                     <td><asp:LinkButton ID="CancelarUnidaMedidaRegional" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                 <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr id="ComponenteUnidadmedida" runat="server" style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                     <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponenteBusquedaUnidad" Skin="MetroTouch" runat="server" AutoPostBack="true" Font-Size="12px" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox><br /></td>
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridUnidaMedidaRegional" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdUnidadMedida,IdComponente,IdTipoUnidad,IdSubcomponente,Descripcion_Subcomponente,Descripcion_UnidadMedida,Estado_UnidadMedida,Estado,
                                                                        Descripcion_Componente,DescripcionTipo,descripcion_conteo,id_conteo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Unidad de Medida" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar la unidad de medida del poa" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdUnidadMedida" UniqueName="IdUnidadMedida" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="IdComponente" UniqueName="IdComponente" Display="false"></telerik:GridBoundColumn>    
                                                                        <telerik:GridBoundColumn DataField="IdTipoUnidad" UniqueName="IdTipoUnidad" Visible="false"></telerik:GridBoundColumn>    
                                                                        <telerik:GridBoundColumn DataField="IdSubcomponente" UniqueName="IdSubcomponente"  Display="false"></telerik:GridBoundColumn>                                                                                                                                
                                                                         <telerik:GridBoundColumn DataField="Estado_UnidadMedida" UniqueName="Estado_UnidadMedida" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="id_conteo" UniqueName="id_conteo" Visible="false"></telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="Descripcion_Componente" UniqueName="Descripcion_Componente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componente">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Subcomponente" UniqueName="Descripcion_Subcomponente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Subcomponente">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_UnidadMedida" UniqueName="Descripcion_UnidadMedida" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="UnidadMedida">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="DescripcionTipo"  UniqueName="DescripcionTipo" HeaderText="Configuración <br/>Unidad de Medida" AllowFiltering="false" >
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="descripcion_conteo"  UniqueName="descripcion_conteo" HeaderText="Tipo de<br/>Conteo" AllowFiltering="false" >
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false" >
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                   </Columns>
                                                                </MasterTableView>
                                                                    <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                                                       {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                                                        &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                     
                                                            </telerik:RadGrid>
                                               </telerik:RadWizardStep>
                                               <telerik:RadWizardStep ID="RadWizardStep4" Title="Actividades POA Regional" StepType="Finish">
                                                    <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="NuevoProductoVerificable" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nueva Actividad</asp:LinkButton> </td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarProductoVerificable" runat="server"> 
                                                                      <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponente3" Skin="MetroTouch" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="500" Width="520px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">SubComponente:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="cbosubocomponenteProducto" Skin="MetroTouch" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione SubComponente" DropDownWidth="500" Width="520px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr> 
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td colspan="2"><label for="Label2">Seleccione Correlativo de Actividad:</label></td></tr>
                                                                    <tr><td><telerik:RadComboBox ID="cboCorrelativoActividad" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Correlativo de Actividad" Width="520px" Height="280"></telerik:RadComboBox></td></tr>
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción de Actividad:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="ProductoVerficableRegional" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="520px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>                                         
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarProductoVerificable" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Acvtidad</asp:LinkButton></td>
                                                                                     <td><asp:LinkButton ID="CancelaProductoVerificable" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                 <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr id="ComponenteProductoVerificable" runat="server" style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Componente:</label></td></tr>
                                                                     <tr>
                                                                        <td><telerik:RadComboBox ID="CboComponenteProductoVerificable" Skin="MetroTouch" runat="server" AutoPostBack="true" Font-Size="12px" Filter="Contains" EmptyMessage="Seleccione Componente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox><br /></td>
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridProductoVerificable" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="Id_Producto,IdComponente,Id_SubComponente,Descripcion_Producto,Estado_Producto,Estado,
                                                                        Descripcion_Componente,Descripcion_Subcomponente,Correlativo,Id_correlativo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Producto Verificable" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar la actividad del poa (Producto Verificable)" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                       <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="IdComponente" UniqueName="IdComponente" Display="false"></telerik:GridBoundColumn>                                                                           
                                                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente"  Display="false"></telerik:GridBoundColumn>    
                                                                        <telerik:GridBoundColumn DataField="Id_correlativo" UniqueName="Id_correlativo"  Display="false"></telerik:GridBoundColumn>   
                                                                         <telerik:GridBoundColumn DataField="Estado_Producto" UniqueName="Estado_Producto" Visible="false"></telerik:GridBoundColumn>                                                                       
                                                                         <telerik:GridBoundColumn DataField="Descripcion_Componente" UniqueName="Descripcion_Componente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componente">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Subcomponente" UniqueName="Descripcion_Subcomponente" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Subcomponente">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>                                                                                                                                            
                                                                         <telerik:GridBoundColumn DataField="Descripcion_Producto"  UniqueName="Descripcion_Producto" HeaderText="Actividad" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" >
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false" >
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                          <telerik:GridBoundColumn DataField="Correlativo"  UniqueName="Correlativo" HeaderText="Actividad" AllowFiltering="false">
                                                                        <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
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
                                </telerik:RadPageView>
                                <telerik:RadPageView ID="Nacional" runat="server" Height="100%">
                                     <telerik:RadWizard  runat="server" ID="RadWizard2" Width="100%" Skin="WebBlue" RenderedSteps="Active" DisplayNavigationButtons="false" Culture="es-GT" >
                                          <WizardSteps>
                                               <telerik:RadWizardStep ID="RadW1" Title="Objetivos POA Nacional" StepType="Start" >
                                                             <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="NuevoObjetivo" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo Objetivo</asp:LinkButton> </td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarobjetivo" runat="server">
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del Objetivo:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="Objetivo" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="180px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarObjetivo" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Objetivo</asp:LinkButton></td>
                                                                                    <td><asp:LinkButton ID="CancelarObjetivo" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridObjetivos" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdObjetivo,Descripcion_Objetivo,Estado_Objetivo,Estado" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Objetivo" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar los objetivos del poa nacional" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                        <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdObjetivo" UniqueName="IdObjetivo" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado_Objetivo" UniqueName="Estado_Objetivo" Visible="false"></telerik:GridBoundColumn>                                                                        
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Objetivo" UniqueName="Descripcion_Objetivo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Objetivos">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
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
                                              <telerik:RadWizardStep ID="RadW2" Title="Resultados POA Nacional">
                                                                 <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="NuevoResultado" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo Resultado</asp:LinkButton> </td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarResultado" runat="server"> 
                                                                      <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Objetivo del resultado:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboObjetivoResultado" Skin="MetroTouch" Font-Names="Arial" Font-Size="9px" runat="server" Filter="Contains" EmptyMessage="Seleccione Objetivo" DropDownWidth="800" Width="400px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del resultado:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="Resultado" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="180px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarResultado" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Resultado</asp:LinkButton></td>
                                                                                     <td><asp:LinkButton ID="CancelarResultado" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridResultado" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdResultado,IdObjetivo,Descripcion_Resultado,Estado_Resultado,Estado,Descripcion_Objetivo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Resultado" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                          <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar los Resultados del poa nacional" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdResultado" UniqueName="IdResultado" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="IdObjetivo" UniqueName="IdObjetivo" Display="false"></telerik:GridBoundColumn>                                                                        
                                                                        <telerik:GridBoundColumn DataField="Estado_Resultado" UniqueName="Estado_Resultado" Visible="false"></telerik:GridBoundColumn>  
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Objetivo" UniqueName="Descripcion_Objetivo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Objetivos">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Resultado" UniqueName="Descripcion_Resultado" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Resultados">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
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
                                               <telerik:RadWizardStep ID="RadW3" Title="Indicadores POA Regional">
                                                                 <table style="border-collapse:separate;border-spacing: 10px;">
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="NuevoIndicador" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo Indicador</asp:LinkButton></td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarIndicador" runat="server"> 
                                                                      <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Resultado del Indicador:</label></td></tr>
                                                                    <tr>
                                                                        <td><telerik:RadComboBox ID="CboResultadoIndicador" Skin="MetroTouch" Font-Names="Arial" Font-Size="9px" runat="server" Filter="Contains" EmptyMessage="Seleccione el Resultado" DropDownWidth="800" Width="400px" Height="280"></telerik:RadComboBox></td>
                                                                    </tr>
                                                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del Indicador:</label></td></tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="Indicador" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="90px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                         <td>
                                                                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                                                                 <tr>
                                                                                     <td><asp:LinkButton ID="GuardarIndicador" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Indicador</asp:LinkButton></td>
                                                                                     <td><asp:LinkButton ID="CancelarIndicador" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                                 </tr>
                                                                             </table> 
                                                                         </td>                                                                         
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridIndicador" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdIndicadores,IdResultado,Descripcion_Indicadores,Estado_Indicadores,Estado,Descripcion_Resultado" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Resultado" HeaderText="Activar/Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar los Indicadores del poa nacional" CommandName="Select1" HeaderText="Editar" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                                            <ItemStyle HorizontalAlign="Center" /> 
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdIndicadores" UniqueName="IdIndicadores" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="IdResultado" UniqueName="IdResultado" Display="false"></telerik:GridBoundColumn>                                                                        
                                                                        <telerik:GridBoundColumn DataField="Estado_Indicadores" UniqueName="Estado_Indicadores" Visible="false"></telerik:GridBoundColumn> 
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Resultado" UniqueName="Descripcion_Resultado" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Resultado">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Descripcion_Indicadores" UniqueName="Descripcion_Indicadores" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Indicadores">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
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
                                               <telerik:RadWizardStep ID="RadW4" Title="Unidades de Medida" StepType="Finish">
                                                              <table style="border-collapse:separate;border-spacing: 10px;display:block;">
                                                                <tr>
                                                                <td><asp:LinkButton ID="NuevoUnidadMedidaPN" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nueva Unidad de Medida</asp:LinkButton> </td>
                                                                     </tr>
                                                                 </table>
                                                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarUnidadMedidaPN" runat="server">
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td colspan="2"><label for="Label2">Unidad de Medida:</label></td></tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="UnidadMedidaPN" Font-Names="Arial" runat="server" class="form-control" Width="300px"></asp:TextBox>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td colspan="2"><label for="Label2">Tipo de Conteo:</label></td></tr>
                                                                    <tr>                                                                         
                                                                        <td colspan="2">
                                                                          <telerik:RadComboBox ID="TipoDeConteoNacional" Skin="MetroTouch" Font-Names="Arial" runat="server" Width="300px" EmptyMessage="Seleccione Tipo de Conteo"></telerik:RadComboBox>
                                                                        </td> 
                                                                    </tr>
                                                                     <tr>
                                                                         <td><asp:LinkButton ID="GuardarUnidadMedidaPN" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Unidad de Medida</asp:LinkButton></td>
                                                                         <td><asp:LinkButton ID="CancelarUnidadMedidaPN" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                                                     </tr>
                                                                 </table> 
                                                                <telerik:RadGrid runat="server" ID="GridUnidadMedidaPN" AutoGenerateColumns="False" Width="100%"  
                                                                    AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                                                    ShowStatusBar ="True" ShowGroupPanel="false">
                                                                    <GroupingSettings CaseSensitive="False" />
                                                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                                                    <Selecting AllowRowSelect="True"></Selecting>                                      
                                                                    </ClientSettings>
                                                                    <MasterTableView PageSize="15" 
                                                                        DataKeyNames="IdUnidadMedida,Descripcion_UnidadMedida,Estado_UnidadMedida,Estado,Tipodeconteo,Descripcion_Conteo" NoMasterRecordsText="Sin Información">
                                                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                                                    <Columns>
                                                                         <telerik:GridButtonColumn Text="Activar/Desactivar Unidad de Medida" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                                                         <HeaderStyle Width="10px" HorizontalAlign="Center"/>
                                                                             <ItemStyle HorizontalAlign="Center"/>
                                                                         </telerik:GridButtonColumn> 
                                                                        <telerik:GridButtonColumn Text="Editar las unidades de medida del poa nacional" CommandName="Select1" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                                        <HeaderStyle Width="20px" HorizontalAlign="Center"/>
                                                                            <ItemStyle HorizontalAlign="Center"/>
                                                                        </telerik:GridButtonColumn> 
                                                                        <telerik:GridBoundColumn DataField="IdUnidadMedida" UniqueName="Id_Proyecto" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Tipodeconteo" UniqueName="Tipodeconteo" Visible="false"></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado_UnidadMedida" UniqueName="Estado_Objetivo" Visible="false"></telerik:GridBoundColumn>                                                                        
                                                                        <telerik:GridBoundColumn DataField="Descripcion_UnidadMedida" UniqueName="Descripcion_UnidadMedida" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Unidad de Medida">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                         <telerik:GridBoundColumn DataField="Descripcion_Conteo" UniqueName="Descripcion_Conteo" HeaderText="Tipo de Conteo" AllowFiltering="false">
                                                                        <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
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
                                         </WizardSteps> 
                                    </telerik:RadWizard>                                                             
                                </telerik:RadPageView> 
                          </telerik:RadMultiPage>                      
                  </ContentTemplate>
             </asp:UpdatePanel>         
             <ul class="breadcrumb-title b-t-default p-t-10"/>
            </div> 
         </div>                                
</asp:Content>
