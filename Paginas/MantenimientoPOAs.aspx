<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="MantenimientoPOAs.aspx.cs" Inherits="PlanificacionPOA.Paginas.MantenimientoPOAs" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
    <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Mantenimiento de POA'S SubRegionales (Encargado de Planificación)</h5>
                   <p class="text-muted m-b-10">En este Apartado el Encargado de Planificación podra Editar los valores de las unidades de medida de las actividades
                       contenidas dentro de los poas de las subregiones y Activar las tareas pasadas de tiempo de entrega  etc.. </p> 
             <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true" ></telerik:RadWindow> 
            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <div class="panel panel-success">                        
                          <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-cog" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="M a n t e n i m i e n t o" Font-Size="10"/></div>
                          <div class="panel-body">
                              <telerik:RadTabStrip runat="server" ID="ControladorTAb" MultiPageID="Paginas" SelectedIndex="0" Skin="Silk" Culture="es-GT">
                                    <Tabs>
                                    <telerik:RadTab TabIndex="0" Text="Poa Regional" Width="400px" Font-Size="13px"></telerik:RadTab>
                                    <telerik:RadTab TabIndex="1" Text="Poa Nacional" Width="400px" Font-Size="13px"></telerik:RadTab>             
                                    </Tabs>
                            </telerik:RadTabStrip>
                              <telerik:RadMultiPage ID="Paginas" runat="server" SelectedIndex="0">  
                                 <telerik:RadPageView ID="Opcion1" runat="server" Height="100%"  Selected="true"><br/>
                                    <div id="Titulo1" runat="server" visible="true">                                    
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
                                                <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                                                <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Poa's Generados" HeaderStyle-Width="20px">
                                                 <ItemTemplate>
                                                        <telerik:RadComboBox runat="server" ID="Poas" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested2" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true" 
                                                        HighlightTemplatedItems="true" Width="150px" Height="180px"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn> 
                                                    <telerik:GridButtonColumn Text="Activar Tareas que se Desactivaron por tiempo ingreso finalizo" HeaderText="Activar Tareas" CommandName="Select2" UniqueName="BotonC" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Refresh.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                                   </telerik:GridButtonColumn>
                                                  <telerik:GridButtonColumn Text="Edición del POA por parte de la Subregión" HeaderText="Editar<br/>(SubRegión)" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn> 
                                                 <telerik:GridButtonColumn Text="Edición del POA por parte de Planificiación" HeaderText="Editar<br/>(Planificación)" CommandName="Select1" UniqueName="BotonB" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>                                              
                                                <telerik:GridButtonColumn Text="Descargar el Poa en formato Excel" HeaderText="Descargar POA" CommandName="Select3" UniqueName="BotonD" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Excel.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn Text="Revisar los cambios que se han hecho al poa de la subregión" HeaderText="Revisar Cambios" CommandName="Select4" UniqueName="BotonE" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" >
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
                                       <%--Eleccion de Actividades--%>
                            <div id="SeleccionITEM" runat="server" visible="false">
                        <hr />
                        <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                        <tr>
                            <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Módulo Anterior</asp:LinkButton></td>
                            <td><asp:LinkButton ID="btnenviar" runat="server" CssClass="btn btn-info btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Enviar Tarea de Edición</asp:LinkButton></td>
                        </tr>                        
                        </table>
                        <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                        <tr><td style="text-align:center;" ><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                        <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                      </table>  
                       <div id="Encabezado" runat="server">                                                
                      <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                       <tr>
                          <td><label for="Label2">Componente:</label></td> 
                          <td><telerik:RadComboBox ID="CboComponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" Width="400px" Height="280"></telerik:RadComboBox></td>
                       </tr>
                       <tr>
                         <td><label for="Label2">Subcomponente:</label></td>  
                         <td><telerik:RadComboBox ID="CboSubcomponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Subcomponente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox></td>  
                       </tr>                          
                      </table><br />
                    </div>
                        <telerik:RadGrid runat="server" ID="GdrDatosdeActividades" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView  PageSize="20"
                                   DataKeyNames="Id_Componente,Id_SubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,Id_MetasRedProgramatica, 
                                                 Id_NoPlanificable,Agregado" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns> 
                                        <telerik:GridButtonColumn Text="Agregar las Actividades a Editar" HeaderText ="Agregar Actividades" 
                                                        CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/Agregar.png" 
                                                        ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Size="9" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                         <telerik:GridButtonColumn Text="Eliminar las Actividades a Editar" HeaderText ="Eliminar Actividades" 
                                                        CommandName="Select1" UniqueName="BotonB" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/Eliminar.png" 
                                                        ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Size="9" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_NoPlanificable" UniqueName="Id_NoPlanificable" Display="false"></telerik:GridBoundColumn>	                                                                                   	                                      
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Producto Verificable">
                                                <HeaderStyle Width="300px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Agregado" UniqueName="Agregado" HeaderText="Editar">
                                                <HeaderStyle Width="50px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>	
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>    
                                    </div>                                     
                                     <hr />                                                                                                                  
                            </telerik:RadPageView>
                             <telerik:RadPageView ID="Nacional" runat="server" Height="100%"><br />
                                 <div id="Nacionales" runat="server" visible="true">                                
                                        <telerik:RadGrid ID="GRDNacionales" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="Both" Culture="es-GT" Skin="Office2007"
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
                                                        <telerik:RadComboBox runat="server" ID="Poas" EnableLoadOnDemand="True" Filter="Contains" EmptyMessage="Seleccione Poa"
                                                        OnItemsRequested="Poas_ItemsRequested" DataTextField="Descripcion" DataValueField="Id" AutoPostBack="true"
                                                        HighlightTemplatedItems="true" Width="150px" Height="180"></telerik:RadComboBox>
                                                   </ItemTemplate>
                                                    <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                                    </telerik:GridTemplateColumn>
                                                     <telerik:GridButtonColumn Text="Activar Tareas que se Desactivaron por tiempo ingreso finalizo" HeaderText="Activar Tareas" CommandName="Select2" UniqueName="BotonC" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Refresh.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>
                                                  <telerik:GridButtonColumn Text="Edición del POA por parte de la Jefatura,Unidad" HeaderText="Editar Metas<br/>(Depto,Unidad)" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass" HeaderButtonType="LinkButton" DataTextField="BotonA" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn> 
                                                 <telerik:GridButtonColumn Text="Edición del POA por parte de Planificiación" HeaderText="Editar Metas<br/>(Planificación)" CommandName="Select1" UniqueName="BotonB" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn> 
                                             <telerik:GridButtonColumn Text="Agregar Producto,subproducto, actividad a un aprobado" HeaderText="Agregar<br/>Elementos al Poa" CommandName="Select7" UniqueName="BotonQ" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/AgregarD.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn> 
                                                <telerik:GridButtonColumn Text="Descargar el Poa en formato Excel" HeaderText="Descargar POA" CommandName="Select3" UniqueName="BotonD" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Excel.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn Text="Revisar los cambios que se han hecho al poa de la subregión" HeaderText="Revisar Cambios" CommandName="Select4" UniqueName="BotonE" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>
                                             <telerik:GridButtonColumn Text="Mantenimientos para agregar productos, subproductos, actividades y Configurar" HeaderText="Mantenimiento<br/>Nacional" CommandName="Select5" UniqueName="BotonF" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/mantenimiento.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn> 
                                            <telerik:GridButtonColumn Text="Editar unidades de medida a Evaluar" HeaderText="UM a<br/>Evaluar" CommandName="Select6" UniqueName="BotonG" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Configurar.png" ButtonCssClass="imageButtonClass" >
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
                               <div id="ConfigurarUM" runat="server" visible="true">
                                   <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                                        <tr><td style="text-align:center;" ><asp:Label ID="Label11" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="tituloum" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="titulosub" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                                    </table>      
                                    <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                        <tr>
                                            <td><asp:LinkButton ID="SalirConfiguracionUM" runat="server" CssClass="btn btn-danger btn-sm" 
                                                ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana de Configuración</asp:LinkButton></td>                                   
                                        </tr>
                                   </table><br />
                                    <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                        <td>
                                            <telerik:RadSearchBox ID="RadSearchBoxActividad" runat="server" Filter="Contains" ShowMoreResultsBox="true" CurrentFilterFunction="Contains"
                                                              AllowCustomText="True" Skin="Bootstrap" Font-Size="9" Width="570" MaxResultCount="20" Culture="es-GT" AutoPostBack="true" ZIndex="10000000"
                                                              EmptyMessage="Ingrese nombre del Producto, Subproducto o Actividad para hacer la busqueda" OnSearch="RadSearchBoxActividad_Search">   
                                                              <DropDownSettings Height="300" Width="570"></DropDownSettings>                                                               
                                            </telerik:RadSearchBox>      
                                        </td>
                                    </tr>
                                </table><br />
                                 <telerik:RadGrid runat="server" ID="RadActividadesUM" AutoGenerateColumns="False" Width="100%" 
                                AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" GridLines="Both" 
                               Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" EnableHeaderContextMenu="true"
                                   DataKeyNames="Correlativo_Configuracion,Id_Producto,DescripcionProducto,Id_SubProducto,DescripcionSubProducto,Id_Actividad,DescripcionActividad,
                                                 Id_MetasRedProgramatica,Id_Unidad_Evaluada,DescripcionEvaluada,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,
                                                 PtUM1,PtUM2,PtUM3,StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                  
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
                                      <telerik:GridButtonColumn Text="Seleccionar para Configurar metas" HeaderText ="Configuración<br/>UM" 
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
                                         <telerik:GridBoundColumn DataField="DescripcionEvaluada" UniqueName="DescripcionEvaluada" HeaderText="Unidad de<br/>Medida Evaluda" AllowFiltering="false">
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
                              <div id="EdicionManualNacional" runat="server" visible="true">
                                <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                                        <tr><td style="text-align:center;" ><asp:Label ID="Label15" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="tituloedicion1" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                        <tr><td><asp:Label ID="tituloedicion2" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                                    </table>      
                                    <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                        <tr>
                                            <td><asp:LinkButton ID="RegresarMantenimiento" runat="server" CssClass="btn btn-danger btn-sm" 
                                                ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana de Edición</asp:LinkButton></td>
                                            <td><asp:LinkButton ID="EdicionActividadesNacionalesEnviar" runat="server" CssClass="btn btn-info btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Enviar Tarea de Edición</asp:LinkButton></td>
                                        </tr>
                                   </table><br />
                                    <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                    <tr>
                                        <td>
                                            <telerik:RadSearchBox ID="BusquedaEdicion" runat="server" Filter="Contains" ShowMoreResultsBox="true" CurrentFilterFunction="Contains"
                                                              AllowCustomText="True" Skin="Bootstrap" Font-Size="9" Width="570" MaxResultCount="20" Culture="es-GT" AutoPostBack="true" ZIndex="10000000"
                                                              EmptyMessage="Ingrese nombre del Producto, Subproducto o Actividad para hacer la busqueda" OnSearch="BusquedaEdicion_Search">   
                                                              <DropDownSettings Height="300" Width="570"></DropDownSettings>                                                               
                                            </telerik:RadSearchBox>      
                                        </td>
                                    </tr>
                                </table><br />
                                 <telerik:RadGrid runat="server" ID="GrdEdicionNacional" AutoGenerateColumns="False" Width="100%" 
                                AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" GridLines="Both" 
                               Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true" EnableRowHoverStyle="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" EnableHeaderContextMenu="true"
                                   DataKeyNames="Correlativo_Configuracion,Id_Producto,DescripcionProducto,Id_SubProducto,DescripcionSubProducto,Id_Actividad,DescripcionActividad,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,Agregado" NoMasterRecordsText="Sin Información">                                  
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                         
                                       </ColumnGroups> 
                                    <Columns>                                                                        
                                         <telerik:GridButtonColumn Text="Eliminar Agregar productos, subproductos y actividades" HeaderText ="Eliminar" 
                                                        CommandName="Select1" UniqueName="BotonB" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/Eliminar.png" 
                                                        ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Size="9" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn>
                                            <telerik:GridButtonColumn Text="Agregar productos, subproductos y actividades" HeaderText ="Agregar" 
                                                        CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/Agregar.png" 
                                                        ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Size="9" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                            <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Display="false"></telerik:GridBoundColumn>	                                        	                                                                                                                                                            	                                        	                                        
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
                                          <telerik:GridBoundColumn DataField="Agregado" UniqueName="Agregado" HeaderText="Editar">
                                                <HeaderStyle Width="50px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>	
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>                                 
                              </div> 
                             </telerik:RadPageView> 
                            </telerik:RadMultiPage>       
                          </div>
                      </div> 
                 </li> 
             </ul>
         </div> 
       </div> 
    </ContentTemplate> 
  </asp:UpdatePanel>  
     <telerik:RadWindow runat="server" Modal="true" ID="ActivacionTareas" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
     <ContentTemplate>
         <asp:UpdatePanel runat="server" >
             <ContentTemplate>                   
                <div class="panel panel-success">
                <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Activación de Tareas" Font-Size="10"/></div></div>
                <div class="panel-body"> 
                    <table style="margin:auto;border-collapse:separate;border-spacing: 2px;text-align:center;">               
                     <tr><td><asp:LinkButton ID="CerrarVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td></tr>                                                           
                  </table>
                 <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:justify;">                               
                  <tr><td>
                    <telerik:RadGrid runat="server" ID="TareasFueraTiempo" AutoGenerateColumns="False" Width="100%" AllowSorting ="true" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="5" 
                                   DataKeyNames="Id_PoAnual,Id_Region,Id_SubRegion,Descripcion,Id" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>                                     
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>                                          
                                       <telerik:GridBoundColumn DataField="Id" UniqueName="Id" Visible="false"></telerik:GridBoundColumn>                                          
                                        <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" HeaderText="Tareas Pendientes" >
                                          <HeaderStyle Width="230px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Fecha Extensión"  HeaderStyle-Width="110px">
                                         <ItemTemplate>
                                                <telerik:RadDatePicker ID="txtFechaEntrega" runat="server" Width="110px" onkeydown="return (event.keyCode!=13);"></telerik:RadDatePicker>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                        <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                        </telerik:GridTemplateColumn>           
                                      <telerik:GridButtonColumn Text="Activar la Tarea" HeaderText="Activar<br/>Tarea" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/EnvioTarea.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>                                   
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>
                           <div id="Respuesta" runat="server" visible="false" >
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="Estado" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Tiene Tareas Pendientes -" Font-Size="15"/></td></tr>
                                </table> 
                                </div>      
                                </td></tr>
                            </table>                 
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
      <telerik:RadWindow runat="server" Modal="true" ID="InicioTarea" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Mensaje de tarea a Subregion" Font-Size="10"/></div></div>
                        <div class="panel-body">      
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;"> 
                                <tr style="text-align:center"><td><label for="Label2">Fecha final de Edición POA</label></td></tr>
                              <tr><td><telerik:RadDatePicker ID="txtFechaEntrega" runat="server" Width="300px" onkeydown="return (event.keyCode!=13);" Skin="MetroTouch"></telerik:RadDatePicker></td></tr>
                            </table> 
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                                
                                <tr><td><asp:TextBox ID="txtmensaje" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                           
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="IniciarTarea" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Iniciar Tarea Edición</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CerrarVentanaTarea" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>  
                                </tr>                                                           
                                </table>
                             </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
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
                    <telerik:RadWindow runat="server" Modal="true" ID="ConfiguracionUMNacional" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-th"></span>&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Configuración de Unidad a Evaluar (UM)" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                                    <table style="border-collapse:separate;border-spacing:5px;font-size:14px;text-align:center;">  
                                     <tr>
                                       <td style="text-align:right;"><asp:Label ID="Label16" runat="server" Text="Producto:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblProducto" runat="server" Width="350px"  /></td>
                                   </tr>    
                                     <tr id="subProdlbl" runat ="server">
                                       <td><asp:Label ID="Label14" runat="server" Text="Subproducto:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblSubproducto" runat="server" Width="350px"  /></td>
                                   </tr>    
                                   <tr id="Actividadlbl" runat ="server">
                                       <td style="text-align:right;"><asp:Label ID="Label5" runat="server" Text="Actividad:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblActividad" runat="server" Width="350px"  /></td>
                                   </tr>                                    
                                </table><hr /> 
                                 <table style="margin:auto;border-collapse:separate;border-spacing:0px;font-size:14px;text-align:center;">
                                     <tr><td><asp:Label ID="Label12" runat="server" Text="Unidades de Medida" Font-Bold="true" /></td></tr>
                                  </table>
                                 <table  style="margin:auto;border-collapse:separate;border-spacing:7px;font-size:14px;text-align:center;"> 
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
                                </table><hr />
                                <table style="margin:auto;border-collapse:separate;border-spacing:5px;font-size:12px;text-align:center;">
                                      <tr><td><asp:Label ID="Label10" runat="server" Text="Unidad Evaluada" Font-Bold="true" /></td></tr>
                                    <tr>
                                        <td><telerik:RadComboBox ID="CboUnidadMedidaEvaludada" Skin="MetroTouch" runat="server" EmptyMessage="Unidad de Medida Evaludada" Width="220px"></telerik:RadComboBox></td>
                                         <td><asp:CheckBox  id="chkRedProgramatica" runat="server" class="form-control" Text="Metas Red Programatica&nbsp;&nbsp;&nbsp;&nbsp;" TextAlign="Left" /></td>
                                    </tr>
                                </table> <br />
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="btnGuardarConfiguracionUM" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar Configuración</asp:LinkButton></td>
                                <td><asp:LinkButton ID="btnCancelarconfiguarcionUM" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Configuración</asp:LinkButton></td>  
                                </tr>                                                           
                                </table>
                             </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
         <telerik:RadWindow runat="server" Modal="true" ID="ActivacionTareasNacionales" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
     <ContentTemplate>
         <asp:UpdatePanel runat="server" >
             <ContentTemplate>                   
                <div class="panel panel-success">
                <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label13" runat="server" Font-Bold="true" Text="Activación de Tareas" Font-Size="10"/></div></div>
                <div class="panel-body"> 
                    <table style="margin:auto;border-collapse:separate;border-spacing: 2px;text-align:center;">               
                     <tr><td><asp:LinkButton ID="cerrarVentanaActivar" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td></tr>                                                           
                  </table>
                 <table style="margin:auto;border-collapse:separate;border-spacing: 5px;text-align:justify;">                               
                  <tr><td>
                    <telerik:RadGrid runat="server" ID="TareasFueraTiempoNacional" AutoGenerateColumns="False" Width="100%" AllowSorting ="true" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="5" 
                                   DataKeyNames="Id_PoAnual,Id_Region,Id_SubRegion,Descripcion,Id" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>                                     
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>                                          
                                       <telerik:GridBoundColumn DataField="Id" UniqueName="Id" Visible="false"></telerik:GridBoundColumn>                                          
                                        <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" HeaderText="Tareas Pendientes" >
                                          <HeaderStyle Width="230px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Fecha Extensión"  HeaderStyle-Width="110px">
                                         <ItemTemplate>
                                                <telerik:RadDatePicker ID="txtFechaEntrega" runat="server" Width="110px" onkeydown="return (event.keyCode!=13);"></telerik:RadDatePicker>
                                        </ItemTemplate>
                                        <HeaderStyle Width="10px" HorizontalAlign="Center" ForeColor="#660033" Font-Bold="true" Font-Size="12px" Font-Names="Arial"/>
                                        <ItemStyle HorizontalAlign="Center" Width="50px"  /> 
                                        </telerik:GridTemplateColumn>           
                                      <telerik:GridButtonColumn Text="Activar la Tarea" HeaderText="Activar<br/>Tarea" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/EnvioTarea.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="60px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>                                   
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>
                                <div id="respuesta123" runat="server" visible="false" >
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="titulo123" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Tiene Tareas Pendientes -" Font-Size="15"/></td></tr>
                                </table> 
                                </div>      
                                </td></tr>
                            </table>                 
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
            <telerik:RadWindow runat="server" Modal="true" ID="InicioTareaNacional" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label17" runat="server" Font-Bold="true" Text="Mensaje de tarea" Font-Size="10"/></div></div>
                        <div class="panel-body">      
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;"> 
                                <tr style="text-align:center"><td><label for="Label2">Fecha final de Edición POA</label></td></tr>
                              <tr><td><telerik:RadDatePicker ID="FechaEdicionNacional" runat="server" Width="300px" onkeydown="return (event.keyCode!=13);" Skin="MetroTouch"></telerik:RadDatePicker></td></tr>
                            </table> 
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                                
                                <tr><td><asp:TextBox ID="DescripcionMensaje" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                           
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="IniciarTareaNacionalEdicion" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Iniciar Tarea Edición</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CerrarVentanaTareanacionalEdicion" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>  
                                </tr>                                                           
                                </table>
                             </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
</asp:Content>
