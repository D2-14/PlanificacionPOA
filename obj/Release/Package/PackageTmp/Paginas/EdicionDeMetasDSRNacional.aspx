<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="EdicionDeMetasDSRNacional.aspx.cs" Inherits="PlanificacionPOA.Paginas.EdicionDeMetasDSRNacional" %>
    <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Ingreso de Metas Nacionales</h5>
                   <p class="text-muted m-b-10">En este Apartado podra ingresar sus metas a los productos, subproductos y actividades
                       que realizaron</p>    
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <telerik:radwindowmanager ID="RadWindowManager" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                                <tr><td style="text-align:center;" ><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                            </table>
                       <div id="Seleccion" runat="server" visible ="true"> 
                       <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                         <tr>
                             <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Mantenimiento</asp:LinkButton></td>                               
                         </tr>                        
                     </table>
                           <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                             <td>
                                 <telerik:RadSearchBox ID="RadSearchBoxActividad" runat="server" Filter="Contains" ShowMoreResultsBox="true" CurrentFilterFunction = "Contains"
                                                              AllowCustomText="True" Skin="Bootstrap" Font-Size="9" Width="570" MaxResultCount="20" Culture="es-GT" AutoPostBack="true" ZIndex="10000000"
                                                              EmptyMessage="Ingrese nombre del Producto, Subproducto o Actividad para hacer la busqueda" OnSearch="RadSearchBoxActividad_Search">   
                                                              <DropDownSettings Height="300" Width="570"></DropDownSettings>                                                               
                                </telerik:RadSearchBox>      
                             </td>
                         </tr>
                           </table> 
                           <br/>
                             <telerik:RadGrid runat="server" ID="GdrDatosdeActividades" AutoGenerateColumns="False" Width="100%" 
                                AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" GridLines="Both" 
                               Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" EnableHeaderContextMenu="true"
                                   DataKeyNames="Correlativo_Configuracion,Id_Producto,DescripcionProducto,Id_SubProducto,DescripcionSubProducto,Id_Actividad,DescripcionActividad,
                                                  Id_MetasRedProgramatica,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,PtUM1,PtUM2,PtUM3,StUM1,StUM2,StUM3,ttUM1,
                                                 ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                  
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="PC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="SC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="TC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Consolidado de Meta Anual" Name="CMA">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                       </ColumnGroups> 
                                    <Columns>
                                       <telerik:GridButtonColumn Text="Eliminar Actividad" CommandName="Delete" UniqueName="BotonB" HeaderText="Eliminar" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/delete.png" ConfirmText="Desea eliminar la Actividad?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Actividad" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn>   
                                      <telerik:GridButtonColumn Text="Seleccionar para Ingreso de metas" HeaderText ="Ingreso de<br/>Metas" 
                                                        CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/Aprobar.png" 
                                                        ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Size="9" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>	                                       
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>	                                                                                                                       	                                        
	                                        
                                            <telerik:GridBoundColumn DataField="DescripcionProducto" UniqueName="DescripcionProducto" HeaderText="Producto">
                                                <HeaderStyle  Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                         <telerik:GridBoundColumn DataField="DescripcionSubProducto" UniqueName="DescripcionSubProducto" HeaderText="SubProducto">
                                                <HeaderStyle Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionActividad" UniqueName="DescripcionActividad" HeaderText="Actvidad">
                                                <HeaderStyle Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
                                            <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="PC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="PC" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="PC" HeaderText="UM3">
                                                  <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="SC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="SC" HeaderText="UM2">
                                                 <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="SC" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="TC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="TC" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="TC" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                         
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                       <div id="Respuesta" runat="server" visible="false" >
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="Estado" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Hay Información -" Font-Size="15"/></td></tr>
                                </table> 
                      </div>
                   </div>  
                      <div id="EdicionValoresMetas" runat="server" visible="false"><br />                         
                               <table runat="server" id="Ingreso" style="margin:auto;border-collapse:separate;border-spacing: 0px;"> 
                                <tr><td>                       
                              <div class="panel panel-success">                        
                              <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-th-list" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Ingreso de Metas Nacionales" Font-Size="10"/></div>
                             <div class="panel-body">
                              <table runat="server" id="MensajeTipo" style="margin:auto;border-collapse:separate;border-spacing:10px;border: #b2b2b2 1px solid;background-color:#00ccff;">                                
                             <tr style="font-family:Arial; text-align:center;">                                
                                 <td><asp:Label ID="Label2" runat="server" Text="Esta actividad pertenece a la red programatica" ForeColor="White" Font-Size="11"/>
                                     <br />
                                     <asp:Label ID="Label4" runat="server" Text="planificar de forma mensual" ForeColor="White" Font-Size="11"/>
                                 </td>                               
                             </tr>
                                 </table>
                                 <table style="border-collapse:separate;border-spacing:5px;font-size:14px;text-align:center;">  
                                     <tr>
                                       <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="Producto:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblProducto" runat="server" Width="500px"  /></td>
                                   </tr>    
                                     <tr id="subProdlbl" runat ="server">
                                       <td><asp:Label ID="Label14" runat="server" Text="Subproducto:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblSubproducto" runat="server" Width="500px"  /></td>
                                   </tr>    
                                   <tr id="Actividadlbl" runat ="server">
                                       <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="Actividad:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblActividad" runat="server" Width="500px"  /></td>
                                   </tr>                                    
                                </table> 
                                 <table style="margin:auto;border-collapse:separate;border-spacing:3px;font-size:14px;text-align:center;">
                                     <tr><td><asp:Label ID="Label12" runat="server" Text="Unidades de Medida" Font-Bold="true" /></td></tr>
                                  </table>
                                 <table  style="margin:auto;border-collapse:separate;border-spacing:3px;font-size:14px;text-align:center;"> 
                                     <tr>
                                         <td id="RUM1T" runat="server"><asp:Label ID="Label6" runat="server" Text="UM1:" Font-Bold="true" /></td>
                                         <td id="RUM2T" runat="server"><asp:Label ID="Label8" runat="server" Text="UM2:" Font-Bold="true" /></td>  
                                         <td id="RUM3T" runat="server"><asp:Label ID="Label9" runat="server" Text="UM3:" Font-Bold="true" /></td>        
                                    </tr>
                                    <tr>
                                       <td id="RUM1" runat="server"><asp:Label ID="LblUM1" runat="server" Text="UM1" Width="120px"/></td>
                                       <td id="RUM2" runat="server"><asp:Label ID="LblUM2" runat="server" Text="UM2" Width="120px"/></td> 
                                       <td id="RUM3" runat="server"><asp:Label ID="LblUM3" runat="server" Text="UM3" Width="120px"/></td>
                                    </tr>                                       
                                </table>                                 
                                  <table style="margin:auto;border-collapse:separate;border-spacing:8px;font-size:14px;text-align:center;">                                      
                                      <tr><td colspan="3"><asp:Label ID="LblMes" runat="server" Width="300px" Font-Bold="true" /></td></tr>
                                      <tr >
                                        <td><asp:Label ID="Label10" runat="server" Text="UM1" Font-Bold="true" /></td>
                                        <td><asp:Label ID="Label11" runat="server" Text="UM2" Font-Bold="true" /></td>
                                        <td><asp:Label ID="Label13" runat="server" Text="UM3" Font-Bold="true" /></td>
                                     </tr>
                                      <tr>
                                          <td><telerik:RadNumericTextBox ID="txtum1" runat="server" Width="120px" style="text-align:right;"  MinValue="0" 
                                              onkeydown="return (event.keyCode!=13);" Skin="MetroTouch" MaxLength="10" NumberFormat-DecimalDigits="4" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>
                                          <td><telerik:RadNumericTextBox ID="txtum2" runat="server" Width="120px" style="text-align:right;" MinValue="0"
                                              onkeydown="return (event.keyCode!=13);" Skin="MetroTouch" MaxLength="10" NumberFormat-DecimalDigits="4" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>
                                          <td><telerik:RadNumericTextBox ID="txtum3" runat="server" Width="120px" style="text-align:right;" MinValue="0"
                                              onkeydown="return (event.keyCode!=13);" Skin="MetroTouch" MaxLength="10" NumberFormat-DecimalDigits="4" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>                                          
                                      </tr>
                                  </table>
                             <table style="margin:auto;border-collapse:separate;border-spacing:5px;">
                                <tr>                                                                                                                                                                                                        
                                 <td><asp:LinkButton ID="btnGenerarMeses" runat="server" CssClass="btn btn-warning btn-sm" Text="Guardar"><span class="glyphicon glyphicon-refresh"></span>&nbsp;Cargar Meses</asp:LinkButton></td>
                                 <td><asp:LinkButton ID="GuardarMetas" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Metas</asp:LinkButton></td>
                                 <td><asp:LinkButton ID="CancelarEdicion" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Cancelar edicion de metas" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Ingreso</asp:LinkButton></td>
                                 <td><asp:LinkButton ID="RegresarPantallaanteriorMetas" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior" Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Cerrar Ingreso de Metas</asp:LinkButton></td>
                                </tr>                      
                         </table> 
                            </div> 
                                 <telerik:RadGrid runat="server" ID="GridUnidadesIngreso" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="4" 
                                   DataKeyNames="Id_mes,Descripcion_Mes,Meta_UM1,Meta_UM2,Meta_UM3,Id_Producto,Id_SubProducto,Id_Actividad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Editar Valores de ingreso de metas" HeaderText ="Editar<br/>Valores" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                      <telerik:GridBoundColumn DataField="Id_mes" UniqueName="Id_mes" Visible="false"></telerik:GridBoundColumn>       
                                       <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Visible="false"></telerik:GridBoundColumn>  
                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Visible="false"></telerik:GridBoundColumn>  
                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Visible="false"></telerik:GridBoundColumn>                                          
                                        <telerik:GridBoundColumn DataField="Descripcion_Mes" UniqueName="Descripcion_Mes" HeaderText="Mes" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Meta_UM1"  UniqueName="Meta_UM1" HeaderText="UM1" AllowFiltering="false">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="Meta_UM2"  UniqueName="Meta_UM2" HeaderText="UM2" AllowFiltering="false">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Meta_UM3"  UniqueName="Meta_UM3" HeaderText="UM3" AllowFiltering="false">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial" />                                           
                                    </telerik:GridBoundColumn>                                                                         
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior"  Position="Top" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid><br /><br />
                                  <telerik:RadGrid runat="server" ID="RadCuatrimestre" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="3" 
                                   DataKeyNames="Id,DescripcionCuatrimestre,Meta_UM1T,Meta_UM2T,Meta_UM3T" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                       
                                      <telerik:GridBoundColumn DataField="Id" UniqueName="Id" Visible="false"></telerik:GridBoundColumn>                                                            
                                        <telerik:GridBoundColumn DataField="DescripcionCuatrimestre" UniqueName="DescripcionCuatrimestre" HeaderText="Cuatrimestre">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Meta_UM1T"  UniqueName="Meta_UM1T" HeaderText="UM1">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="Meta_UM2T"  UniqueName="Meta_UM2T" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Meta_UM3T"  UniqueName="Meta_UM3T" HeaderText="UM3">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                         
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>
                           </td></tr>
                            </table>  
                          </div>                             
                 </ContentTemplate> 
                   </asp:UpdatePanel> 
                        <hr />
                        <telerik:RadWindow runat="server" Modal="true" ID="VerIngresos" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Metas Ingresadas a la Actividad" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                               
                                <tr><td>
                                    <telerik:RadGrid runat="server" ID="GridUnidades" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="12" 
                                   DataKeyNames="Id_mes,Descripcion_Mes,Meta_UM1,Meta_UM2,Meta_UM3" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_mes" Visible="false"></telerik:GridBoundColumn>                                                            
                                        <telerik:GridBoundColumn DataField="Descripcion_Mes" HeaderText="Mes">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Meta_UM1" HeaderText="UM1">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="Meta_UM2" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Meta_UM3" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                         
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>                                
                               </td></tr>
                            </table>                                                                                                        
                        </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
                 </li>
             </ul>
          </div> 
    </div> 
</asp:Content>
