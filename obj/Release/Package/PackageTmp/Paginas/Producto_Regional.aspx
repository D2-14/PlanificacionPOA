<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Producto_Regional.aspx.cs" Inherits="PlanificacionPOA.Paginas.Producto_Regional" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
     <div class="page-header card">
         <div class="card-block">
             <h5 class="m-b-10"><asp:Label ID="Lanio" runat="server" Font-Bold="true"/></h5>
              <center><h3 class="m-b-10">Sistema de Planificación POA de -INAB-</h3></center>
            <p class="text-muted m-b-10">En este apartado se crearan los Productos Regionales para la planificación Operativa Anual</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                      <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-th-list" style="font-size:12px;"></span>                                  
                                  <br /><asp:Label ID="L36" runat="server" Font-Bold="true" Text="PRODUCTOS REGIONALES<br/>INSTITUTO NACIONAL DE BOSQUES -INAB-<br/>
                                      DIRECCIÓN DE PLANIFICACIÓN, MONITOREO Y EVALUACIÓN INSTITUCIONAL" Font-Size="10"/></div>
                           <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                               <tr>
                                   <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar</asp:LinkButton></td>  
                                  <td><asp:LinkButton ID="GuardarProducto" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Guardar el producto en el sistema"  Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar</asp:LinkButton></td>
                                  <td><asp:LinkButton ID="Cancelarproducto" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Cancelar Ingreso del producto" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>                                    
                               </tr>
                            </table><br />                           
                           <table style="margin:auto;border-collapse:separate;border-spacing:10px;font-family:Arial;font-size:13px;font-weight:bold;"> 
                                <tr>
                                 <td><label for="Label2">Componente:</label></td> 
                                 <td><telerik:RadComboBox ID="CboComponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" Width="400px" Height="280"></telerik:RadComboBox></td>
                               </tr>
                               <tr>
                                 <td><label for="Label2">Subcomponente:</label></td>  
                                 <td><telerik:RadComboBox ID="CboSubcomponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Subcomponente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox></td>  
                               </tr>
                               <tr>
                                 <td><label for="Label2">Producto Verificable:</label></td>  
                                 <td><telerik:RadComboBox ID="CboProducto" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Producto Verificable" DropDownWidth="650" Width="500px" Height="280"></telerik:RadComboBox></td>  
                               </tr>
                           </table>                              
                          <table style="margin:auto;border-collapse:separate;border-spacing:10px;font-family:Arial;font-size:13px;font-weight:bold;"> 
                              <tr>
                                  <td><asp:CheckBox  id="chkRedProgramatica" runat="server" class="form-control" Text="Metas Red Programatica&nbsp;&nbsp;&nbsp;&nbsp;"
                                        TextAlign="Left" /></td>
                                  <td><asp:CheckBox  id="chkNoPlanificable" runat="server" class="form-control" Text="No Planificable&nbsp;&nbsp;&nbsp;&nbsp;"
                                        TextAlign="Left" /></td>         
                              </tr>
                              <tr></tr>
                          </table>                        
                           <table style="margin:auto;border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">                             
                                   <tr style="text-align:center;">
                                       <td id="U1" runat="server"><label for="Label2">Unidad de Medida -UM1-</label></td>
                                       <td id="U2" runat="server"><label for="Label2">Unidad de Medida -UM2-</label></td>
                                       <td id="U3" runat="server"><label for="Label2">Unidad de Medida -UM3-</label></td>
                                   </tr>
                                   <tr>
                                       <td><telerik:RadComboBox ID="RadUM1" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Unidad de Medida UM1" DropDownWidth="200" Width="100%" Height="280"></telerik:RadComboBox></td>  
                                       <td><telerik:RadComboBox ID="RadUM2" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Unidad de Medida UM2" DropDownWidth="200" Width="100%" Height="280"></telerik:RadComboBox></td>  
                                       <td><telerik:RadComboBox ID="RadUM3" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Unidad de Medida UM3" DropDownWidth="200" Width="100%" Height="280"></telerik:RadComboBox></td>  
                                   </tr>                                    
                                  <tr style="text-align:center;">
                                      <td><label for="Label2">Unidad Evaluada</label></td>
                                      <td colspan="2"><label for="Label2">Medio de Verificación</label></td>
                                  </tr>
                                  <tr style="text-align:center;">
                                      <td><telerik:RadComboBox ID="CboUnidadMedidaEvaludada" Skin="MetroTouch" runat="server" EmptyMessage="Seleccione Unidad de Medida Evaludada" Width="200px"></telerik:RadComboBox></td>
                                      <td colspan="2"><asp:TextBox ID="MedioVerficacion" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="100%"></asp:TextBox></td>
                                  </tr>
                                    <tr style="text-align:center;"><td colspan="3"><label for="Label2">Dirección de Medio de Verificación</label></td></tr>
                                    <tr><td colspan="3"><asp:TextBox ID="DireccionMedioV" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="100%"></asp:TextBox></td></tr>
                               </table>
                                 <telerik:RadGrid runat="server" ID="GdrProductoRegional" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="20" 
                                   DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,Id_MetasRedProgramatica, 
                                                 Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,MedioDeVerificacion,	 
                                                 DireccionMedioVerificacion,CorrelativoC,CorrelativoSC,CorrelativoPC" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                    <telerik:GridButtonColumn Text="Eliminar producto verificable del POA" CommandName="Delete" UniqueName="BotonA" HeaderText="Eliminar<br/>Producto" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar el producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar POA" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn> 
                                      <telerik:GridButtonColumn Text="Editar el producto verificable del Poa" HeaderText ="Editar<br/>Producto" CommandName="Select" UniqueName="BotonB" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_NoPlanificable" UniqueName="Id_NoPlanificable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoC" UniqueName="CorrelativoC" Display="false"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="CorrelativoSC" UniqueName="CorrelativoSC" Display="false"></telerik:GridBoundColumn>
	                                    <telerik:GridBoundColumn DataField="CorrelativoPC" UniqueName="CorrelativoPC" Display="false"></telerik:GridBoundColumn>
                                        
                                        <telerik:GridBoundColumn DataField="Id_UnidadMedida" UniqueName="Id_UnidadMedida" Display="false"></telerik:GridBoundColumn>                                        
                                            <telerik:GridBoundColumn DataField="DescripcionComponente" UniqueName="DescripcionComponente" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componente">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionSubComponente" UniqueName="DescripcionSubComponente" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Subcomponente">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto Verificable">
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
	                                        <telerik:GridBoundColumn DataField="DescripcionUnidadMedida" UniqueName="DescripcionUnidadMedida" HeaderText="Unidad Evaluada" AllowFiltering="false">
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
                      </div> 
                 </ContentTemplate> 
              </asp:UpdatePanel> 
         </div> 
     </div> 
</asp:Content>
