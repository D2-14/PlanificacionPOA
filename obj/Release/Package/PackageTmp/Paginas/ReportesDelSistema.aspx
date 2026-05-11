<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ReportesDelSistema.aspx.cs" Inherits="PlanificacionPOA.Paginas.Monitoreo_ConsultaPoa" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true"></telerik:RadWindow>
        <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
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
                       <telerik:RadPageView ID="Nacional" runat="server" Height="100%">
                           Se esta Trabajando
                        </telerik:RadPageView>    
                   </telerik:RadMultiPage> 
                </li> 
           </ul>
             </div>
       </div> 
    </ContentTemplate> 
</asp:UpdatePanel> 
</asp:Content>
