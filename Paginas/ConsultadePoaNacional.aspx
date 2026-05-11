<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ConsultadePoaNacional.aspx.cs" Inherits="PlanificacionPOA.Paginas.ConsultadePoaNacional" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
 <ContentTemplate>
             <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true"></telerik:RadWindow>
             <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
    <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Consulta de Poa's Ingresados al sistema</h5>
                   <p class="text-muted m-b-10">En este Apartado podra consultar los poa's ingresados al sistema que se encuentran aprobados</p>
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <telerik:RadTabStrip runat="server" ID="ControladorTAb" MultiPageID="Paginas" SelectedIndex="0" Skin="Silk" Culture="es-GT">
                     <Tabs>
                          <telerik:RadTab TabIndex="0" Text="Consulta Poa (Planificación)" Width="400px" Font-Size="13px"></telerik:RadTab>
                          <telerik:RadTab TabIndex="1" Text="Consulta Poa (Monitoreo)" Width="400px" Font-Size="13px"></telerik:RadTab>             
                     </Tabs>
                     </telerik:RadTabStrip> 
                      <telerik:RadMultiPage ID="Paginas" runat="server" SelectedIndex="0">
                          <telerik:RadPageView ID="Opcion1" runat="server" Height="100%"  Selected="true"><br/>
                           <div id="Regiones" runat="server">                                 
                           <telerik:RadGrid ID="RadRegion" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="Both" Culture="es-GT" Skin="Office2007"
                                          PageSize="50" AllowSorting="false" AllowMultiRowSelection="False" AllowPaging="True" AllowFilteringByColumn="false">
                                     <PagerStyle Mode="NumericPages"></PagerStyle>
                                    <MasterTableView DataKeyNames="Id_Region,Cod_Padre,Id_Estado_Region" AllowMultiColumnSorting="True" Name="Region">
                                    <DetailTables>
                                        <telerik:GridTableView DataKeyNames="Id_Subregion,Cod_Padre,Id_Estado_Subregion,Subregion" Name="SubRegion" Width="100%">                           
                                        <Columns>                                                   
                                                <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Id_Estado_Subregion" UniqueName="Id_Estado_Subregion" Visible="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Subregion"  UniqueName="Subregion" HeaderText="Departamentos/ Unidades de Apoyo / Parques Nacionales de INAB">
                                                   <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="BlueViolet" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="#006600" Font-Names="Arial"/>   
                                                </telerik:GridBoundColumn>                                                                           
                                                <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                                                  <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Poa's Generados"  HeaderStyle-Width="20px">
                                                 <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Poas" Skin="Silk" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested2" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
                                                        HighlightTemplatedItems="true" Width="180px" Height="180px"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn>    
                                                  <telerik:GridButtonColumn Text="Ver información del POA" HeaderText="Consultar Poa" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                                                                           
                                                <telerik:GridButtonColumn Text="Descargar el Poa en formato Excel" HeaderText="Descargar POA" CommandName="Select1" UniqueName="BotonD" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Excel.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                                                         
                                       </Columns>                                           
                                      </telerik:GridTableView>
                            </DetailTables>
                            <Columns>                                                                                     
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Id_Estado_Region"  UniqueName="Id_Estado_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="Direcciones del Instituto Nacional de Bosques INAB">                             
                                        <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="#ff0000" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                   </telerik:GridBoundColumn>                                                            
                                    <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                            </telerik:RadGrid>
                             </div>
                               <div id="poas" runat="server">
                                  <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:center;"> 
                                        <tr><td><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                                </table>
                                  <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                        <tr>
                                            <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-danger btn-sm" 
                                                ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana de Visualización de POA</asp:LinkButton></td>                                   
                                        </tr>
                                   </table><br />
                                  <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                        <td>
                                            <telerik:RadSearchBox ID="RadSearchBoxActividad" runat="server" Filter="Contains" ShowMoreResultsBox="true" CurrentFilterFunction="Contains"
                                                              AllowCustomText="True" Skin="Office2007" Font-Size="9" Width="570" MaxResultCount="20" Culture="es-GT" AutoPostBack="true" ZIndex="10000000"
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
                                                 Id_MetasRedProgramatica,Id_Unidad_Evaluada,DescripcionEvaluada,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,
                                                 PtUM1,PtUM2,PtUM3,StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3,MedioDeVerificacion" NoMasterRecordsText="Sin Información">                                  
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
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Unidad_Evaluada" UniqueName="Id_Unidad_Evaluada" Display="false"></telerik:GridBoundColumn>                                        
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>	                                                                                                                       	                                        
	                                        
                                            <telerik:GridBoundColumn DataField="DescripcionProducto" UniqueName="DescripcionProducto" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Producto">
                                                <HeaderStyle  Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                         <telerik:GridBoundColumn DataField="DescripcionSubProducto" UniqueName="DescripcionSubProducto" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="SubProducto">
                                                <HeaderStyle Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionActividad" UniqueName="DescripcionActividad" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actvidad">
                                                <HeaderStyle Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1" AllowFiltering="false" >
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
                                            <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="PC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="PC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="PC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="SC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="SC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle  Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="SC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="TC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="TC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="TC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="DescripcionEvaluada" UniqueName="DescripcionEvaluada" Display="false" HeaderText="Unidad de<br/>Medida Evaluda" AllowFiltering="false">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" HeaderText="Medio de<br/>Verificación">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                             </div> 
                          </telerik:RadPageView>
                            <telerik:RadPageView ID="Opcion2" runat="server" Height="100%"><br/>
                                <div id="NacionalMonitoreo" runat="server">                                 
                                        <telerik:RadGrid ID="RadRegion2" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="Both" Culture="es-GT" Skin="Office2007"
                                          PageSize="50" AllowSorting="false" AllowMultiRowSelection="False" AllowPaging="True" AllowFilteringByColumn="false">
                                     <PagerStyle Mode="NumericPages"></PagerStyle>
                                    <MasterTableView DataKeyNames="Id_Region,Cod_Padre,Id_Estado_Region" AllowMultiColumnSorting="True" Name="Region">
                                    <DetailTables>
                                        <telerik:GridTableView DataKeyNames="Id_Subregion,Cod_Padre,Id_Estado_Subregion,Subregion" Name="SubRegion" Width="100%">                           
                                        <Columns>                                                   
                                                <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false" ></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Id_Estado_Subregion" UniqueName="Id_Estado_Subregion" Visible="false"></telerik:GridBoundColumn>
                                                <telerik:GridBoundColumn DataField="Subregion"  UniqueName="Subregion" HeaderText="Departamentos/ Unidades de Apoyo / Parques Nacionales de INAB">
                                                   <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="BlueViolet" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="#006600" Font-Names="Arial"/>   
                                                </telerik:GridBoundColumn>                                                                           
                                                <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                                                  <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Poa's Generados"  HeaderStyle-Width="20px">
                                                 <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Poas" Skin="Silk" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested2" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
                                                        HighlightTemplatedItems="true" Width="180px" Height="180px"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn> 
                                                     <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Mes de Ingreso"  HeaderStyle-Width="20px">
                                                     <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Mes" Skin="Silk" EnableLoadOnDemand="True" EmptyMessage="Seleccione Mes"
                                                        OnItemsRequested="Poas_ItemsRequested1" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
                                                        HighlightTemplatedItems="true" Width="180px" Height="180px"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn> 
                                                  <telerik:GridButtonColumn Text="Ver información del POA" HeaderText="Consultar Poa" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                                                                           
                                                <telerik:GridButtonColumn Text="Descargar el Poa en formato Excel" HeaderText="Descargar POA" CommandName="Select1" UniqueName="BotonD" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Excel.png" ButtonCssClass="imageButtonClass" Visible="false">
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                                                         
                                       </Columns>                                           
                                      </telerik:GridTableView>
                            </DetailTables>
                            <Columns>                                                                                     
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Id_Estado_Region"  UniqueName="Id_Estado_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="Direcciones del Instituto Nacional de Bosques INAB">                             
                                        <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="#ff0000" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                   </telerik:GridBoundColumn>                                                            
                                    <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                            </telerik:RadGrid>
                             </div>
                                 <div id="poasNacional" runat="server" visible="false">
                                  <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:center;"> 
                                        <tr><td><asp:Label ID="Tit01" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="Tit02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                                        <tr><td><asp:Label ID="Tit03" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                                </table>
                                  <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                        <tr>
                                            <td><asp:LinkButton ID="RegresarPantallaanterior2" runat="server" CssClass="btn btn-danger btn-sm" 
                                                ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana de Visualización de ejecución de Metas</asp:LinkButton></td>                                   
                                        </tr>
                                   </table><br />
                                  <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                        <td>
                                            <telerik:RadSearchBox ID="RadSearchBoxActividad2" runat="server" Filter="Contains" ShowMoreResultsBox="true" CurrentFilterFunction="Contains"
                                                              AllowCustomText="True" Skin="Office2007" Font-Size="9" Width="570" MaxResultCount="20" Culture="es-GT" AutoPostBack="true" ZIndex="10000000"
                                                              EmptyMessage="Ingrese nombre del Producto, Subproducto o Actividad para hacer la busqueda" OnSearch="RadSearchBoxActividad2_Search">   
                                                              <DropDownSettings Height="300" Width="570"></DropDownSettings>                                                               
                                            </telerik:RadSearchBox>      
                                        </td>
                                    </tr>
                           </table> 
                           <br/>
                            <telerik:RadGrid runat="server" ID="GdrDatosdeActividades2" AutoGenerateColumns="False" Width="100%" 
                                AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" GridLines="Both" 
                               Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" EnableHeaderContextMenu="true"
                                   DataKeyNames="Tipo,Correlativo_Configuracion,Descripcion" NoMasterRecordsText="Sin Información">                                                                        
                                    <Columns> 
                                         <telerik:GridButtonColumn Text="Seleccionar el Producto Verificable para ingreso de Información" HeaderText ="Seleccionar" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/Aprobar.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tipo" UniqueName="Tipo" Display="false"></telerik:GridBoundColumn>	                                                                                                                                                     	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Descripcion Productos, Subproductos y Actividades">
                                                <HeaderStyle  Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>	                                                                                                                                                                                                    
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                             </div> 
                              <div id="DetalleIngreso" runat="server" visible="false">
                                  <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                        <tr>
                                            <td><asp:LinkButton ID="RegresarPantallaanterior3" runat="server" CssClass="btn btn-danger btn-sm" 
                                                ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana de Visualización de POA</asp:LinkButton></td>                                   
                                        </tr>
                                   </table><br />
                                   <telerik:RadGrid runat="server" ID="GrdIngresoEncabezado" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Tipo,Correlativo_Configuracion,Id_Producto,Id_SubProducto,Id_Actividad,Id_Subregion,DescripcionPSA, 
                                                 Id_UM1,Id_UM2,Id_UM3,Id_Mes,DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,MedioDeVerificacion,
                                                 Observaciones,fecha" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                   
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tipo" UniqueName="Tipo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Display="false"></telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                       	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	                                              
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                                                                   
                                         <telerik:GridBoundColumn DataField="DescripcionPSA" UniqueName="DescripcionPSA" HeaderText="Producto/Subproducto/Actividad">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="fecha" UniqueName="fecha" HeaderText="Fecha">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" DataFormatString="{0:#,###.#0}" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>                                             
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" 
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                              </div> 
                            </telerik:RadPageView> 
                      </telerik:RadMultiPage>                                                                                                                                                
                  </li> 
            </ul> 
         </div> 
        </div>
       </ContentTemplate> 
    </asp:UpdatePanel> 
     <telerik:RadWindow runat="server" Modal="true" ID="VerIngresos" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Metas Ingresadas a la Actividad" Font-Size="10"/></div></div>
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
                                      <telerik:GridBoundColumn DataField="Id_mes" UniqueName="Id_mes" Visible="false"></telerik:GridBoundColumn>                                                            
                                        <telerik:GridBoundColumn DataField="Descripcion_Mes" UniqueName="Descripcion_Mes" HeaderText="Mes">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Meta_UM1"  UniqueName="Meta_UM1" HeaderText="UM1">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="Meta_UM2"  UniqueName="Meta_UM2" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Meta_UM3"  UniqueName="Meta_UM3" HeaderText="UM2">
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
    <telerik:RadWindow  runat="server" Modal="true" ID="visualizar" Skin="Office2007" Behaviors="Move,Maximize" Left="980px" Top="2px" ReloadOnShow="true">
        <ContentTemplate>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="panel panel-primary">
                         <div class="panel-heading"><asp:LinkButton ID="CerraVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></div>
                        </div>                         
                        <iframe id="viewer" runat="server" frameborder="0" scrolling="no"  style="width:100%;height:800px;"></iframe>  
                         <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;" id="Dowload" runat="server">
                             <tr><td><a id="Descarga" runat="server">Descargue el Archivo de Excel para Su Verificación <br />
                                 <img src="../Iconos/excel.png" width="50" />
                                     </a> </td></tr>
                         </table>    
                </ContentTemplate> 
                </asp:UpdatePanel>                        
            </ContentTemplate> 
         </telerik:RadWindow> 
 <telerik:RadWindow runat="server" Modal="true" ID="VerDatosExtra" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label34" runat="server" Font-Bold="true" Text="Información Adicional" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                                            
                             <table style="margin:auto;border-collapse:separate;border-spacing:10px;" class="table table-bordered border-primary" id="Table1" runat="server"> 
                                  <tr>
                                  <td><asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Observaciones:" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblObserva" runat="server" Font-Bold="true" Width="200px" Text="xxx" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>   
                             </table> 
                        </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow>     
</asp:Content>
