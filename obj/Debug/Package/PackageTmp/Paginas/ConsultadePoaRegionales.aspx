<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ConsultadePoaRegionales.aspx.cs" Inherits="PlanificacionPOA.Paginas.ConsultadePoaRegionales" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
       <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true" ></telerik:RadWindow> 
            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
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
                                                <telerik:GridBoundColumn DataField="Subregion"  UniqueName="Subregion" HeaderText="SubRegion de INAB">
                                                   <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="BlueViolet" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="#006600" Font-Names="Arial"/>   
                                                </telerik:GridBoundColumn>
                                                  <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Poa's Generados"  HeaderStyle-Width="20px">
                                                 <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Poas" Skin="Silk" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested2" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
                                                        HighlightTemplatedItems="true" Width="180px" Height="180px"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn> 
                                                <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
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
                                    <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="Regiones del Instituto Nacional de Bosques INAB">                             
                                        <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="#ff0000" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                   </telerik:GridBoundColumn>                                                            
                                    <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                            </telerik:RadGrid>
                      </div>
                      </telerik:RadPageView> 
                         <telerik:RadPageView ID="Opcion2" runat="server" Height="100%"><br/>
                         <div id="RegionesMonitoreo" runat="server">                                                  
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
                                                <telerik:GridBoundColumn DataField="Subregion"  UniqueName="Subregion" HeaderText="SubRegion de INAB">
                                                   <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="BlueViolet" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="#006600" Font-Names="Arial"/>   
                                                </telerik:GridBoundColumn>
                                                  <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Poa's Generados"  HeaderStyle-Width="20px">
                                                 <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Poas" Skin="Silk" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested3" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
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
                                                <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                                                  <telerik:GridButtonColumn Text="Ver información del POA" HeaderText="Consultar" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                                                                                                                                                                                           
                                       </Columns>                                           
                                      </telerik:GridTableView>
                            </DetailTables>
                            <Columns>                                                                                     
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Id_Estado_Region"  UniqueName="Id_Estado_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="Regiones del Instituto Nacional de Bosques INAB">                             
                                        <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="#ff0000" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                   </telerik:GridBoundColumn>                                                            
                                    <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                            </telerik:RadGrid>
                      </div>
                          </telerik:RadPageView> 
                     </telerik:RadMultiPage>                                    
                      <div id="poas" runat="server">
                          <div class="panel panel-success"> 
                               <div class="panel-body">
                         <table style="margin:auto;border-collapse:separate;border-spacing: 10px;text-align:center;"> 
                                <tr><td><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                                <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                            </table> 
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                               <tr>
                                   <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Consulta</asp:LinkButton></td>                                    
                               </tr>
                            </table><br/> 
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                 <td><label for="Label2">Componente:</label></td> 
                                 <td><telerik:RadComboBox ID="CboComponente" Skin="Silk" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" Width="400px" Height="280"></telerik:RadComboBox></td>
                               </tr>
                               <tr>
                                 <td><label for="Label2">Subcomponente:</label></td>  
                                 <td><telerik:RadComboBox ID="CboSubcomponente" Skin="Silk" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione Subcomponente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox></td>  
                               </tr>
                            </table><br />
                                   <telerik:RadGrid runat="server" ID="GdrDatosdeActividades" AutoGenerateColumns="False" Width="100%" 
                                                    AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" 
                                                    Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="20" EnableHeaderContextMenu="true"
                                   DataKeyNames="Id_Componente,Id_SubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,Id_MetasRedProgramatica,Id_NoPlanificable,
                                                 Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,PtUM1,PtUM2,PtUM3,
                                                 StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3,MedioDeVerificacion,DireccionMedioVerificacion" NoMasterRecordsText="Sin Información">                                  
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
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_NoPlanificable" UniqueName="Id_NoPlanificable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UnidadMedida" UniqueName="Id_UnidadMedida" Display="false"></telerik:GridBoundColumn>                                                                                    	                                        
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actvidades">
                                                <HeaderStyle Width="100%" Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1" AllowFiltering="false" >
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
                                            <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="PC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="PC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="PC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="SC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="SC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="SC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="TC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="TC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="TC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                      
                                        <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" AllowFiltering="false"  HeaderText="Medio de Verificación">
                                                <HeaderStyle Width="100%" Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle  HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="DireccionMedioVerificacion" UniqueName="DireccionMedioVerificacion" AllowFiltering="false"
                                                AutoPostBackOnFilter="true" HeaderText="Dirección de </br> medio de Verificación" Display="false">
                                                <HeaderStyle Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn Text="Visualizar Dirección del medio de verificación" CommandName="Select2" HeaderText="Dirección </br> medio de Verificación" UniqueName="BotonB"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>  
                                        <telerik:GridButtonColumn Text="Consultar el enlace" CommandName="Select" HeaderText="Consultar enlace" UniqueName="BotonA"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/PaginaWeb.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>      
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                 <div id="Respuesta2" runat="server" visible="false" >
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="RespuestaAct" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Hay Información -" Font-Size="15"/></td></tr>
                                </table> 
                                </div>
                      </div>  
                       </div> 
                          </div> <%--Aqui llega regional planificacion--%>
                    <div id="RegionesMonitoreosDetalle" runat="server">
                          <div class="panel panel-success"> 
                               <div class="panel-body">
                                  <table style="margin:auto;border-collapse:separate;border-spacing: 2px;text-align:center;"> 
                                <tr><td><asp:Label ID="T011" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                                <tr><td><asp:Label ID="T012" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                               <tr><td><asp:Label ID="T013" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                            </table> 
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                               <tr>
                                   <td><asp:LinkButton ID="RegresarPantallaanterior2" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-backward"></span>&nbsp;Regresar Modulo Anterior</asp:LinkButton></td>                                    
                               </tr>
                            </table><br/> 
                                 <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                 <td><label for="Label2">Componente:</label></td> 
                                 <td><telerik:RadComboBox ID="CboComponente1" Skin="Silk" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" Width="400px" Height="280"></telerik:RadComboBox></td>
                               </tr>
                               <tr>
                                 <td><label for="Label2">Subcomponente:</label></td>  
                                 <td><telerik:RadComboBox ID="CboSubcomponente1" Skin="Silk" runat="server" AutoPostBack="true" Filter="Contains" EmptyMessage="Seleccione Subcomponente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox></td>  
                               </tr>
                            </table><br />
                                <telerik:RadGrid runat="server" ID="GrdProductos" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="8" 
                                   DataKeyNames="Id_ProductoVeficable,DescripcionProductoVeficable" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Seleccionar el Producto Verificable para ingreso de Información" HeaderText ="Seleccionar" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/Aprobar.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                      <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Visible="false"></telerik:GridBoundColumn>                                                                                    
                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Producto Verificable" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                          <HeaderStyle Font-Size="9" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                          
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior"  Position="Top" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>
                               </div>
                         </div> 
                  </div>   
                    <div id="DetalleDeEjecucionMensual" runat="server" visible="false">
                         <div class="panel panel-success"> 
                               <div class="panel-body">
                                     <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:center;"> 
                                        <tr>
                                            <td><asp:Label ID="TProducto" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td>
                                            <td><asp:Label ID="TProducto1" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#cc0000"/></td>
                                        </tr>                                        
                                    </table> 
                                    <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                   <td><asp:LinkButton ID="BtnRegresarpantallaProducto" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-backward"></span>&nbsp;&nbsp;&nbsp;Modulo Anterior</asp:LinkButton></td>                                    
                                    </tr>
                            </table><br/>
                              <div id="DatosExtra">
                                   <telerik:RadGrid runat="server" ID="RadGridDatosExtra" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" Visible ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="false" GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="false" 
                                  ShowGroupPanel="false" ShowFooter="false">
                                    <GroupingSettings CaseSensitive="False" />                                     
                                   <MasterTableView  
                                   DataKeyNames="Orden,Descripcion,Valores" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="INFORMACIÓN GENERAL" Name="IG">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                       </ColumnGroups> 
                                    <Columns>                                   
                                            <telerik:GridBoundColumn DataField="Orden" UniqueName="Orden" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" HeaderText="DESCRIPCIÓN" ColumnGroupName="IG">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Width="300px" />
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Valores" UniqueName="Valores" HeaderText="INFORMACIÓN" ColumnGroupName="IG">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Width="300px" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="Green" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                               </div> 
                                <telerik:RadGrid runat="server" ID="GrdConsultaConsumoFamiliar" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                Fecha,Observaciones,Expediente,Resolucion,DictamenTecnico,NombreCientifico,CodigoMirasil,Troza,Lenia,
                                                TotalDeArboles,Municipal" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                    
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Expediente" UniqueName="Expediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Resolucion" UniqueName="Resolucion" Display="false"></telerik:GridBoundColumn>                                           
                                            <telerik:GridBoundColumn DataField="DictamenTecnico" UniqueName="DictamenTecnico" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreCientifico" UniqueName="NombreCientifico" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoMirasil" UniqueName="CodigoMirasil" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Troza" UniqueName="Troza" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Lenia" UniqueName="Lenia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TotalDeArboles" UniqueName="TotalDeArboles" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Municipal" UniqueName="Municipal" Display="false"></telerik:GridBoundColumn>                                                                                         
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}" DataFormatString="{0:#,##0.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,##0.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,##0.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>     
                              <telerik:RadGrid runat="server" ID="GrdConsultaProbosque" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" Visible="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" 
                                  ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                NoExpediente,ResolucionInforme,Modalidad,Fecha,Observaciones" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>                                   
                                    <Columns>                                   
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="ResolucionInforme" UniqueName="ResolucionInforme" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="Modalidad" UniqueName="Modalidad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" Display="false">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                              <telerik:RadGrid runat="server" ID="GrdConsultaRNF" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True"  Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Fecha,Observaciones,NoRegistro,NoExpediente,TipoRegistroId,IdDivisionProducto,TipoRegistro,IdEstadoRNF,EstadoRNF,CategoriaRNF,
                                                 SubcategoriaRNF,Especificaciones,IdTipoDenegacion,Denegacion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                    
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoRegistro" UniqueName="NoRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoRegistroId" UniqueName="TipoRegistroId" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IdDivisionProducto" UniqueName="IdDivisionProducto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoRegistro" UniqueName="TipoRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IdEstadoRNF" UniqueName="IdEstadoRNF" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CategoriaRNF" UniqueName="CategoriaRNF" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="SubcategoriaRNF" UniqueName="SubcategoriaRNF" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Especificaciones" UniqueName="Especificaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IdTipoDenegacion" UniqueName="IdTipoDenegacion" Display="false"></telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="Denegacion" UniqueName="Denegacion" Display="false"></telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="EstadoRNF" UniqueName="EstadoRNF" Display="false"></telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,##0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" 
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" Display="false">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                              <telerik:RadGrid runat="server" ID="GrdConsultaPINPEP" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                NoExpediente,ResolucionInforme,Modalidad,Fecha,Observaciones" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                    
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="ResolucionInforme" UniqueName="ResolucionInforme" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="Modalidad" UniqueName="Modalidad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" Display="false">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                              <telerik:RadGrid runat="server" ID="GrdConsultaMonitoreo" AutoGenerateColumns="False" Width="100%" AllowSorting ="false"
                                   AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,Noexpediente,
                                       Fase,NoInforme,NoResolucion,Especie,Volumen,CoordenadaX,CoordenadaY,Garantia,Edad,Estado,Estatus,Fecha,Observaciones" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                      
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                    
                                             <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Noexpediente" UniqueName="Noexpediente" Display="false"></telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="Fase" UniqueName="Fase" Display="false"></telerik:GridBoundColumn>                                                                                
                                            <telerik:GridBoundColumn DataField="NoInforme" UniqueName="NoInforme" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoResolucion" UniqueName="NoResolucion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Especie" UniqueName="Especie" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Volumen" UniqueName="Volumen" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaX" UniqueName="CoordenadaX" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaY" UniqueName="CoordenadaY" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Garantia" UniqueName="Garantia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Edad" UniqueName="Edad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Estatus" UniqueName="Estatus" Display="false"></telerik:GridBoundColumn>                                        
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">      
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                              <telerik:RadGrid runat="server" ID="GrdConsultaExentos" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                Fecha,Observaciones,NoExpediente,NoResolucion,NoRegistro" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                    
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	      
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoResolucion" UniqueName="NoResolucion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoRegistro" UniqueName="NoRegistro" Display="false"></telerik:GridBoundColumn>                                                                                                                                                                      
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" Display="false">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                              <telerik:RadGrid runat="server" ID="GrdConsultaReduccionEmisiones" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,NoResolucion,NoExpediente,FechaResolucion,TipoProyecto" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                            <telerik:GridButtonColumn Text="Consulta del detalle de areas por Modalidad" CommandName="Select1" HeaderText="Detalle de<br/>Areas Por Modalidad" UniqueName="BotonD"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                     
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                          
                                            <telerik:GridBoundColumn DataField="NoResolucion" UniqueName="NoResolucion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="FechaResolucion" UniqueName="FechaResolucion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoProyecto" UniqueName="TipoProyecto" Display="false"></telerik:GridBoundColumn>                                                                                     
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,###.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,###.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.###0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaJuridico" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible ="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,Fecha" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                   
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                              <telerik:RadGrid runat="server" ID="GrdConsultaMangle" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                    AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                            <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                         
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaCapacitacion" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                   AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                Observaciones,Fecha,Evento,Id_Evento" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                            <telerik:GridButtonColumn Text="Consulta de Participantes" CommandName="Select1" HeaderText="Participantes" 
                                                UniqueName="BotonB" ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn> 
                                          <telerik:GridButtonColumn Text="Consulta Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" 
                                              ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>     
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	 
                                             <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Evento" UniqueName="Evento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Evento" UniqueName="Id_Evento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>                                          
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>   
                              <telerik:RadGrid runat="server" ID="GrdConsultaPPMF" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,TipoBosque,CoordenadaX,CoordenadaY,FechaPlantacion,NoMedicion,FechaPPM,NombreSitio,NoExperimento,NoParcela,
                                                 Replanteo,UnidadMuestreo,CodigoProyecto" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                             
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                           
                                            <telerik:GridBoundColumn DataField="TipoBosque" UniqueName="TipoBosque" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaX" UniqueName="CoordenadaX" Display="false"></telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="CoordenadaY" UniqueName="CoordenadaY" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="FechaPlantacion" UniqueName="FechaPlantacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoMedicion" UniqueName="NoMedicion" Display="false"></telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="FechaPPM" UniqueName="FechaPPM" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreSitio" UniqueName="NombreSitio" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExperimento" UniqueName="NoExperimento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoParcela" UniqueName="NoParcela" Display="false"></telerik:GridBoundColumn>
                                           <telerik:GridBoundColumn DataField="Replanteo" UniqueName="Replanteo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UnidadMuestreo" UniqueName="UnidadMuestreo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoProyecto" UniqueName="CodigoProyecto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaPinabete" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,TipoArea,NoRegistro,NoExpediente" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                            <telerik:GridButtonColumn Text="Consulta Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                         
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoArea" UniqueName="TipoArea" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoRegistro" UniqueName="NoRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaProteccion" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                 AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,NoExpediente,AgenteCausal,NombreTitular,Hectarias,CoordenadaX,CoordenadaY,NombreContacto,NumeroTelefono,Id_EquipoProteccion,
                                                 EquipoProteccion,Id_tipoAreaBM,TipoAreaManejo,Id_AreaBM,AreaBajoManejo,Id_fase,fase,Id_TipoEscenario,Escenario,NumeroMuestra,Id_Tipo_Bosque,
                                                 Bosque,Id_Tipo_Incendio,Incendio,Id_Tipo_Administracion,Administracion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                   <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>        
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AgenteCausal" UniqueName="AgenteCausal" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreTitular" UniqueName="NombreTitular" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hectarias" UniqueName="Hectarias" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaX" UniqueName="CoordenadaX" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaY" UniqueName="CoordenadaY" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreContacto" UniqueName="NombreContacto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroTelefono" UniqueName="NumeroTelefono" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_EquipoProteccion" UniqueName="Id_EquipoProteccion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="EquipoProteccion" UniqueName="EquipoProteccion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_tipoAreaBM" UniqueName="Id_tipoAreaBM" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoAreaManejo" UniqueName="TipoAreaManejo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_AreaBM" UniqueName="Id_AreaBM" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AreaBajoManejo" UniqueName="AreaBajoManejo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_fase" UniqueName="Id_fase" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="fase" UniqueName="fase" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_TipoEscenario" UniqueName="Id_TipoEscenario" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Escenario" UniqueName="Escenario" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroMuestra" UniqueName="NumeroMuestra" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Tipo_Bosque" UniqueName="Id_Tipo_Bosque" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Bosque" UniqueName="Bosque" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Tipo_Incendio" UniqueName="Id_Tipo_Incendio" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Incendio" UniqueName="Incendio" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Tipo_Administracion" UniqueName="Id_Tipo_Administracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Administracion" UniqueName="Administracion" Display="false"></telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaCulturaForestal" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible ="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,NombreEvento,TipoEvento,Campania,TemaONombreEntidad,MediosParticipantes,NombredelMaterial,NombreMediosComunicacion,
                                                 TemaAbordado,TemaAtendido,PeriodoPublicidadInicio,PeriodoPublicidadFinal,TipoApoyo,NombreEntidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns> 
                                            <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonB" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                         <telerik:GridButtonColumn Text="Ingreso Cantidad de Notas" CommandName="Select3" HeaderText="Ingreso<br/>Cantidad de Notas" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>  
                                        <telerik:GridButtonColumn Text="Ingreso Tipo de Publicidad" CommandName="Select4" HeaderText="Ingreso<br/>Tipo Publicidad" UniqueName="BotonE" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn> 
                                         <telerik:GridButtonColumn Text="Ingreso Publico Dirigido" CommandName="Select5" HeaderText="Ingreso<br/>Público Dirigido" UniqueName="BotonF" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn> 
                                         <telerik:GridButtonColumn Text="Ingreso Tipo de Materia" CommandName="Select6" HeaderText="Ingreso<br/>Tipo Material" UniqueName="BotonG" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn> 
                                        <telerik:GridButtonColumn Text="Ingreso Campaña de Comunicación" CommandName="Select7" HeaderText="Ingreso<br/>Campaña Comunicación" UniqueName="BotonH" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                        <telerik:GridButtonColumn Text="Ingreso Tipo de Notas" CommandName="Select8" HeaderText="Ingreso<br/>Tipo de Notas" UniqueName="BotonI" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Agregar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                                                                      
                                            <telerik:GridBoundColumn DataField="NombreEvento" UniqueName="NombreEvento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoEvento" UniqueName="TipoEvento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Campania" UniqueName="Campania" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TemaONombreEntidad" UniqueName="TemaONombreEntidad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="MediosParticipantes" UniqueName="MediosParticipantes" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombredelMaterial" UniqueName="NombredelMaterial" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreMediosComunicacion" UniqueName="NombreMediosComunicacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TemaAbordado" UniqueName="TemaAbordado" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TemaAtendido" UniqueName="TemaAtendido" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PeriodoPublicidadInicio" UniqueName="PeriodoPublicidadInicio" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PeriodoPublicidadFinal" UniqueName="PeriodoPublicidadFinal" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoApoyo" UniqueName="TipoApoyo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreEntidad" UniqueName="NombreEntidad" Display="false"></telerik:GridBoundColumn>                                           
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaIncentivoForestal" AutoGenerateColumns="False" Width="100%" 
                                 AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,NumeroExpediente,Area,DescripcionTipoIncentivo,DescripcionModalidad,DescripcionFase" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                         <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                          
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroExpediente" UniqueName="NumeroExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Area" UniqueName="Area" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionTipoIncentivo" UniqueName="DescripcionTipoIncentivo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionModalidad" UniqueName="DescripcionModalidad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionFase" UniqueName="DescripcionFase" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                              <telerik:RadGrid runat="server" ID="GrdConsultaFiscalizacionControl" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,Registro,
                                       NumeroDeRegistro,ErroresAnomalias,Acta,Seinef,Tipo_Producto,Especie,Pais,Estado,Accion,Incumplimiento,Existencia,Cobertura,Registro2,
                                       Observaciones,Fecha,NombreEmpresa,RegistroExim" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                            <telerik:GridButtonColumn Text="Consulta de Rendimiento" CommandName="Select1" HeaderText="Rendimiento" Display="false"  
                                                UniqueName="BotonB" ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                         <telerik:GridButtonColumn Text="Consulta de  Comunidad Leguistica" CommandName="Select3" HeaderText="Comunidad Lengüistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>     
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Registro" UniqueName="Registro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Registr2" UniqueName="Registro2" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroDeRegistro" UniqueName="NumeroDeRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ErroresAnomalias" UniqueName="ErroresAnomalias" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Acta" UniqueName="Acta" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Seinef" UniqueName="Seinef" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tipo_Producto" UniqueName="Tipo_Producto" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Especie" UniqueName="Especie" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Pais" UniqueName="Pais" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Accion" UniqueName="Accion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Incumplimiento" UniqueName="Incumplimiento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Existencia" UniqueName="Existencia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Cobertura" UniqueName="Cobertura" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreEmpresa" UniqueName="NombreEmpresa" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="RegistroExim" UniqueName="RegistroExim" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>                                          
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                         
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                              <telerik:RadGrid runat="server" ID="GrdConsultaFortalecimiento" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Id_Puesto_Actvidad,Actividad,NombreActor,TemaAtendido,AccionesSeguimiento,ComunidadOrganizacion,UbicacionOrganizacion, 
                                                  NombreDocumento,AnioVigenciaPolitica,Observaciones,Actores,TipoActores" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                           
                                         <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>     
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	     
                                            <telerik:GridBoundColumn DataField="Actores" UniqueName="Actores" Display="false"></telerik:GridBoundColumn>	     
                                            <telerik:GridBoundColumn DataField="TipoActores" UniqueName="TipoActores" Display="false"></telerik:GridBoundColumn>	                                                 
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                                                                        
                                            <telerik:GridBoundColumn DataField="Id_Puesto_Actvidad" UniqueName="Id_Puesto_Actvidad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Actividad" UniqueName="Actividad" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreActor" UniqueName="NombreActor" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TemaAtendido" UniqueName="TemaAtendido" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AccionesSeguimiento" UniqueName="AccionesSeguimiento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ComunidadOrganizacion" UniqueName="ComunidadOrganizacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="UbicacionOrganizacion" UniqueName="UbicacionOrganizacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreDocumento" UniqueName="NombreDocumento" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="AnioVigenciaPolitica" UniqueName="AnioVigenciaPolitica" Display="false"></telerik:GridBoundColumn>                                                                                                                                                                        
                                        <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>                                          
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                         
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                              <telerik:RadGrid runat="server" ID="GrdConsultaIndustriaCom" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                  AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Observaciones,
                                                 Id_Tema,DescripcionTema,Tema_Especifico,TipoRegistro,NumeroRegistro,Id_TipoOrganizacion,DescripcioOrganizacion,
                                                Tema_Organizacion,Id_TipoEmpresa,DescripcionEmpresa,Tema_Empresa,Producto_Recomendado" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Consulta de Comunidad Linguistica" CommandName="Select1" HeaderText="Comunidad Linguistica" 
                                            UniqueName="BotonD" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>
                                          <telerik:GridButtonColumn Text="Consulta de Grupo Etario" CommandName="Select2" HeaderText="Grupo Etario" UniqueName="Botonc" Display="false"   
                                              ButtonType="ImageButton" ImageUrl="../Iconos/Visualizar.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>           
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                             
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Tema" UniqueName="Id_Tema" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionTema" UniqueName="DescripcionTema" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tema_Especifico" UniqueName="Tema_Especifico" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoRegistro" UniqueName="TipoRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NumeroRegistro" UniqueName="NumeroRegistro" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_TipoOrganizacion" UniqueName="Id_TipoOrganizacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcioOrganizacion" UniqueName="DescripcioOrganizacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tema_Organizacion" UniqueName="Tema_Organizacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_TipoEmpresa" UniqueName="Id_TipoEmpresa" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="DescripcionEmpresa" UniqueName="DescripcionEmpresa" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tema_Empresa" UniqueName="Tema_Empresa" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Producto_Recomendado" UniqueName="Producto_Recomendado" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,###.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}">
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
                               <telerik:RadGrid runat="server" ID="GrdConsultaLicenciaF" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                   AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                 Fecha,Observaciones, NoExpediente,NoResolucionInformePOATrimestral,NoLicencia,Hectarias,Titular,NoTelefono,NoTelefonoElabora,
                                                 Elaborador,Especie,CoordenadaX,CoordenadaY,TipoDeModificacion,TipoLicencia,TipoDeBosque ,Tratamiento" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                   
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	                                                 
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoExpediente" UniqueName="NoExpediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoResolucionInformePOATrimestral" UniqueName="NoResolucionInformePOATrimestral" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoLicencia" UniqueName="NoLicencia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Hectarias" UniqueName="Hectarias" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Titular" UniqueName="Titular" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoTelefono" UniqueName="NoTelefono" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NoTelefonoElabora" UniqueName="NoTelefonoElabora" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Especie" UniqueName="Especie" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Especie" UniqueName="Especie" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaX" UniqueName="CoordenadaX" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CoordenadaY" UniqueName="CoordenadaY" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoDeModificacion" UniqueName="TipoDeModificacion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoLicencia" UniqueName="TipoLicencia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TipoDeBosque" UniqueName="TipoDeBosque" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Tratamiento" UniqueName="Tratamiento" Display="false"></telerik:GridBoundColumn> 	
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" DataFormatString="{0:#,##0.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,##0.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,##0.#0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridButtonColumn Text="Ver Documento" CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA" 
                                                ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" Display="false">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                                                                                                                                                                                                                                                                                                                                                                                                        
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>      
                            <div id="Personas" runat="server" visible="false">
                                 <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                   <td><asp:LinkButton ID="BtnOcultar" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Cerrar ventana de Consulta"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;&nbsp;Cerrar Consultar</asp:LinkButton></td>                                    
                                    </tr>
                            </table><br/>
                                 <telerik:RadGrid runat="server" ID="GrdModalidadArea" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible ="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_Modalidad,Modalidad,Area" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_Modalidad" UniqueName="Id_Modalidad" Display="false"></telerik:GridBoundColumn>	                                                                              
                                          <telerik:GridBoundColumn DataField="Modalidad" UniqueName="Modalidad" HeaderText="Modalidad">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Area" UniqueName="Area" HeaderText="Numero de Personas" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                                 <telerik:RadGrid runat="server" ID="GrdActores" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_Comunidad,Comunidad,NumeroPersonas" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                       
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_Comunidad" UniqueName="Id_Comunidad" Display="false"></telerik:GridBoundColumn>	                                                                              
                                         <telerik:GridBoundColumn DataField="Comunidad" UniqueName="Comunidad" HeaderText="Comunidad Lingüistica"
                                                    FooterText="Total de Personas" FooterStyle-Font-Bold="true">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="NumeroPersonas" UniqueName="NumeroPersonas" HeaderText="Numero de Personas" 
                                                 Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                 <telerik:RadGrid runat="server" ID="GrdParticipantes" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,Id_Evento,Id_Participante,
                                                Id_Tipoparticipante,Id_Comunidad,NumeroPersonaComunidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                       
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               
	                                       <telerik:GridBoundColumn DataField="Id_Evento" UniqueName="Id_Evento" Display="false"></telerik:GridBoundColumn>	 
                                           <telerik:GridBoundColumn DataField="Id_Participante" UniqueName="Id_Participante" Display="false"></telerik:GridBoundColumn>	
                                            <telerik:GridBoundColumn DataField="Id_Tipoparticipante" UniqueName="Id_Tipoparticipante" Display="false"></telerik:GridBoundColumn>	                                        
                                        <telerik:GridBoundColumn DataField="Evento" UniqueName="Evento" HeaderText="Tipo de Evento" FooterText="Total de Personas" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="TipoParticipantes" UniqueName="TipoParticipantes" HeaderText="Tipo de Participantes">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Participantes" UniqueName="Participantes" HeaderText="Participantes">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                           
	                                        <telerik:GridBoundColumn DataField="ComunidadL" UniqueName="ComunidadL" HeaderText="Comunidad Lengüistica">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="NumeroPersonaComunidad" UniqueName="NumeroPersonaComunidad" 
                                                        HeaderText="No. de Personas" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>                                                                                                                                                        	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                <br />
                                 <telerik:RadGrid runat="server" ID="GrdPertencia" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible ="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									            Id_Genero,Sexo,Id_pertenencia,Pertenecia,Id_GrupoEtario,Etario,NumeroPersonaEtario" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               
	                                       <telerik:GridBoundColumn DataField="Id_Genero" UniqueName="Id_Genero" Display="false"></telerik:GridBoundColumn>	 
                                           <telerik:GridBoundColumn DataField="Id_pertenencia" UniqueName="Id_pertenencia" Display="false"></telerik:GridBoundColumn>	
                                            <telerik:GridBoundColumn DataField="Id_GrupoEtario" UniqueName="Id_GrupoEtario" Display="false"></telerik:GridBoundColumn>	                                        
                                        <telerik:GridBoundColumn DataField="Sexo" UniqueName="Sexo" HeaderText="Genero" FooterText="Total de Personas" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Pertenecia" UniqueName="Pertenecia" HeaderText="Pueblo de Pertenecia">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Etario" UniqueName="Etario" HeaderText="Grupo etario">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="NumeroPersonaEtario" UniqueName="NumeroPersonaEtario" 
                                                        HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                 <telerik:RadGrid runat="server" ID="GrdNotas" AutoGenerateColumns="False" Width="100%" AllowSorting ="false"
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_Notas,Notas,NumeroNotas" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                       
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_Notas" UniqueName="Id_Notas" Display="false"></telerik:GridBoundColumn>	                                                                              
                                         <telerik:GridBoundColumn DataField="Notas" UniqueName="Notas" HeaderText="Notas">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="NumeroNotas" UniqueName="NumeroNotas" HeaderText="Numero de Notas" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                                 <telerik:RadGrid runat="server" ID="GrdPublicidad" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_TipoPublicidad,TipoPublicidad,Cantidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_TipoPublicidad" UniqueName="Id_TipoPublicidad" Display="false"></telerik:GridBoundColumn>	                                                                              
                                         <telerik:GridBoundColumn DataField="TipoPublicidad" UniqueName="TipoPublicidad" HeaderText="Tipo de Publicidad">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                                 <telerik:RadGrid runat="server" ID="GrdPublico" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_Publico,Publico,Cantidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                       
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_Publico" UniqueName="Id_Publico" Display="false"></telerik:GridBoundColumn>	                                                                              
                                         <telerik:GridBoundColumn DataField="Publico" UniqueName="Publico" HeaderText="Descripción">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                                 <telerik:RadGrid runat="server" ID="GrdMaterial" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									          Id_TipoMaterial,Id_Material,TipoMaterial,Material,Cantidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                      
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                                                                                                        
                                            <telerik:GridBoundColumn DataField="Id_TipoMaterial" UniqueName="Id_TipoMaterial" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Material" UniqueName="Id_Material" Display="false"></telerik:GridBoundColumn>                                        
                                            <telerik:GridBoundColumn DataField="TipoMaterial" UniqueName="TipoMaterial" HeaderText="Tipo Material">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Material" UniqueName="Material" HeaderText="Material">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid> 
                                 <telerik:RadGrid runat="server" ID="GrdCampaniaPub" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false"   
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									           Id_Campania,Campania,Cantidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                    
                                            <telerik:GridBoundColumn DataField="Id_Campania" UniqueName="Id_Campania" Display="false"></telerik:GridBoundColumn>	                                                                                                                          
                                            <telerik:GridBoundColumn DataField="Campania" UniqueName="Campania" HeaderText="Campaña de Capacitación">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                                 <telerik:RadGrid runat="server" ID="GrdNotasPosiNega" AutoGenerateColumns="False" Width="100%" 
                                     AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" Visible="false"  
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,Id_Mes,
									          Id_TipoNota,Id_Nota,TipoNota,Nota,Cantidad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               	                                                                                                                                                                                                            
                                            <telerik:GridBoundColumn DataField="Id_TipoNota" UniqueName="Id_TipoNota" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Nota" UniqueName="Id_Nota" Display="false"></telerik:GridBoundColumn>                                                                                                                            
                                            <telerik:GridBoundColumn DataField="TipoNota" UniqueName="TipoNota" HeaderText="Tipo de Nota">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                                </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Nota" UniqueName="Nota" HeaderText="Tipo de Medio">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" HeaderText="Cantidad" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                      	                                                                                                                                                                                                                                                                                                                                                                                                                                                     
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                 <telerik:RadGrid runat="server" ID="GrdRendimiento" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                     AllowFilteringByColumn="false" AllowPaging="True" Visible="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="CorrelativoPadre,CorrelativoHijo,Id_Componente,Id_SubComponente,Id_ProductoVerificable,
                                       Id_Mes,Maquinaria,Id_Especie,Especie" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                        
                                            <telerik:GridBoundColumn DataField="CorrelativoPadre" UniqueName="CorrelativoPadre" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CorrelativoHijo" UniqueName="CorrelativoHijo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                                                                    
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                                                                                               
	                                        <telerik:GridBoundColumn DataField="Id_Especie" UniqueName="Id_Especie" Display="false"></telerik:GridBoundColumn>	                                                                                   
                                            <telerik:GridBoundColumn DataField="Especie" UniqueName="Especie" HeaderText="Modelo">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="Maquinaria" UniqueName="Maquinaria" HeaderText="Modelo">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                                                                               
                                             <telerik:GridBoundColumn DataField="PorcentajeMaderaAserrada" UniqueName="PorcentajeMaderaAserrada" HeaderText="Madera Aserrada">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="PorcentajeLepa" UniqueName="PorcentajeLepa" HeaderText="Lepa">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PorcentajeAserrio" UniqueName="PorcentajeAserrio" HeaderText="Aserrio">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                     <telerik:GridBoundColumn DataField="PorcentajeOtro" UniqueName="PorcentajeOtro" HeaderText="otro">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Total" UniqueName="Total" HeaderText="Total">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn>   
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>  
                            </div>       
                           </div> 
                       </div> 
                    </div>  
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
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Metas Ingresadas a la Actividad" Font-Size="10"/></div></div>
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
     <telerik:RadWindow runat="server" Modal="true" ID="MensajePla" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-link"></span>&nbsp;&nbsp;
                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Dirección del Medio de Verificación" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:justify;">                               
                                <tr><td><asp:TextBox ID="txtInstruccion" Font-Names="Arial" Font-Size="9" runat="server" ReadOnly="true" class="form-control" Width="400px" Height="130px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                                                                         
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                                                  
                                <td><asp:LinkButton ID="CerrarVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>  
                                </tr>                                                           
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
</asp:Content>
