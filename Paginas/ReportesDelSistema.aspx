<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ReportesDelSistema.aspx.cs" Inherits="PlanificacionPOA.Paginas.Monitoreo_ConsultaPoa" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
     <script type="text/javascript">
        function CloseWindow() {
            GetRadWindow().close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radwindow) {
                oWindow = window.radwindow;
            }
            else if (window.frameElement.radwindow) {
                oWindow = window.frameElement.radwindow;
            }
            return oWindow;

        }
    </script>

 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>

        <telerik:RadWindow  runat="server" ID="ExportarEx"  Skin="Office2007" Behaviors="Close,Move,Maximize" Modal="true" >            
        </telerik:RadWindow>

        <telerik:radwindowmanager ID="RadWindowManager1"  runat="server" EnableShadow="true" Skin="Office2007">          
        </telerik:radwindowmanager>

         <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Reporteria del sistema de POa</h5>
                   <p class="text-muted m-b-10">En este Apartado podra generar la reporteria del sistema de poas Regionales y nacionales. Planificación y Monitoreo
                   </p>
            <ul class="breadcrumb-title b-t-default p-t-10">
               <li>
                    <telerik:RadTabStrip runat="server" ID="ControladorTAb" MultiPageID="Paginas" SelectedIndex="0" Skin="Silk" Culture="es-GT">
                     <Tabs>
                          <telerik:RadTab TabIndex="0" Text="Reportes Regiones" Width="400px" Font-Size="13px"></telerik:RadTab>
                          <telerik:RadTab TabIndex="1" Text="Reportes Nacionales" Width="400px" Font-Size="13px"></telerik:RadTab>             
                     </Tabs>
                   </telerik:RadTabStrip>
                   <telerik:RadMultiPage ID="Paginas" runat="server" SelectedIndex="0">
                        <telerik:RadPageView ID="Region" runat="server" Height="100%" Selected="true"><br />
                            <telerik:RadTabStrip runat="server" ID="ControladorTAb2" MultiPageID="Paginas2" SelectedIndex="0" Skin="MetroTouch" Culture="es-GT">
                            <Tabs>
                            <telerik:RadTab TabIndex="0" Text="Reportes Planificación" Width="400px" Font-Size="13px"></telerik:RadTab>
                            <telerik:RadTab TabIndex="1" Text="Reportes Monitoreo" Width="400px" Font-Size="13px" Enabled="true"></telerik:RadTab>             
                            </Tabs>
                           </telerik:RadTabStrip>


                             <telerik:RadMultiPage ID="Paginas2" runat="server" SelectedIndex="0">
                                  <telerik:RadPageView ID="Rp" runat="server" Height="100%"  Selected="true"><br />
                                      <div id="Repo1" runat="server">
                                           <telerik:RadGrid runat="server" ID="GridReportes" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" 
                                               AllowFilteringByColumn="false" AllowPaging="True" 
                                            GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                            <GroupingSettings CaseSensitive="False" />
                                            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                            <Selecting AllowRowSelect="True"></Selecting>                                      
                                            </ClientSettings>
                                        <MasterTableView PageSize="8"                                          
                                        DataKeyNames="Id_Reporte,DescripcionRep" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_Reporte" UniqueName="Id_Reporte" Visible="false"></telerik:GridBoundColumn>                                                                                                                                                                                    
                                      <telerik:GridBoundColumn DataField="DescripcionRep" UniqueName="DescripcionRep" HeaderText="Tipo de Reporte">
                                          <HeaderStyle Font-Size="11" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
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
                                         <telerik:GridButtonColumn Text="Exportar Reporte" HeaderText="Reporte" CommandName="Select" UniqueName="BotonA" 
                                             ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="150px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>     
                                        <telerik:GridButtonColumn Text="Exportar Reporte Metas RED" HeaderText=" Reporte Metas RED" CommandName="Select1" UniqueName="BotonB" 
                                             ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="150px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>     
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>                             
                                      </div>
                                       <div id="Regiones" runat="server" visible="false">
                                            <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                            <tr>
                                                <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  
                                                    Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Módulo Anterior</asp:LinkButton></td>
                                                
                                                </tr>                        
                                                </table>
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
                                                  <telerik:GridButtonColumn Text="Exportar Reporte Metas Red" HeaderText="Exportar Reporte" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
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
                        <telerik:RadPageView ID="Rm" runat="server" Height="100%"><br />
                         <telerik:RadGrid ID="RadRegionM" runat="server" ShowStatusBar="true" AutoGenerateColumns="False" GridLines="Both" Culture="es-GT" Skin="Office2007"
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
                                                  <telerik:GridButtonColumn Text="Exportar Reporte Metas Red" HeaderText="Exportar Reporte" CommandName="Select" UniqueName="BotonA" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
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
                        </telerik:RadPageView> 
                             </telerik:RadMultiPage>    

                        </telerik:RadPageView> 
                       

                     <%--  <telerik:RadPageView ID="Nacional" runat="server" Height="100%">
                           Se esta Trabajando
                        </telerik:RadPageView> --%>
                       
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
                                                     <%--<telerik:GridButtonColumn Text="Activar Tareas que se Desactivaron por tiempo ingreso finalizo" HeaderText="Activar Tareas" CommandName="Select2" UniqueName="BotonC" 
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
                                              </telerik:GridButtonColumn> --%>
                                                <telerik:GridButtonColumn Text="Descargar.." HeaderText="Descargar" CommandName="Select3" UniqueName="BotonD" 
                                                      ButtonType="ImageButton" ImageUrl="../Iconos/Excel.png" ButtonCssClass="imageButtonClass" >
                                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                                    <ItemStyle HorizontalAlign="Center"/>
                                              </telerik:GridButtonColumn>
                                           <%-- <telerik:GridButtonColumn Text="Revisar los cambios que se han hecho al poa de la subregión" HeaderText="Revisar Cambios" CommandName="Select4" UniqueName="BotonE" 
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
                                              </telerik:GridButtonColumn>  --%>
                                       </Columns>                                           
                                      </telerik:GridTableView>
                            </DetailTables>
                            <Columns>                                                                                     
                                    <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Id_Estado_Region"  UniqueName="Id_Estado_Region" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="**Direcciones del Instituto Nacional de Bosques INAB">                             
                                        <HeaderStyle Width="100%" Font-Size="10" HorizontalAlign="Center" ForeColor="#ff0000" Font-Names="Arial" Font-Bold="true"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                   </telerik:GridBoundColumn>                                                            
                                    <telerik:GridBoundColumn DataField="Cod_Padre" UniqueName="Cod_Padre" Visible="false"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="Hijo" UniqueName="Hijo" Visible="false"></telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                            </telerik:RadGrid>
                                </div> 
                             <%--  <div id="ConfigurarUM" runat="server" visible="true">
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
                              </div> --%>




                              <%--<div id="EdicionManualNacional" runat="server" visible="true">
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
                              </div> --%>


                                 
                             </telerik:RadPageView> 
                   </telerik:RadMultiPage> 
                </li> 
           </ul>
             </div>
       </div> 
    </ContentTemplate> 
</asp:UpdatePanel> 



</asp:Content>
