<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="IngresoMetasValoresSR.aspx.cs" Inherits="PlanificacionPOA.Paginas.IngresoMetasValoresSR" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Ingreso de Metas SubRegionales</h5>
                   <p class="text-muted m-b-10">En este Apartado se podra ingresar los valores a las actividades dependiente las unidades
                        de medida que tiene dicha actividad</p>
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                             <table style="border-collapse:separate;border-spacing:0px;font-family:Arial;font-size:13px;font-weight:bold;">
                               <tr>
                                   <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior" Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar a las Actividades</asp:LinkButton></td>                                                                                                       
                               </tr>
                            </table><br/>
                               <table runat="server" id="Ingreso" style="margin:auto;border-collapse:separate;border-spacing: 2px;"> 
                                <tr><td>                       
                              <div class="panel panel-success">                        
                              <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-th-list" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Ingreso de Metas Subregionales" Font-Size="10"/></div>
                             <div class="panel-body">
                              <table runat="server" id="MensajeTipo" style="margin:auto;border-collapse:separate;border-spacing:10px;border: #b2b2b2 1px solid;background-color:#00ccff;"> 
                             <tr style="font-family:Arial; text-align:center;">
                                 <td><asp:Label ID="Label1" runat="server" Text="Esta actividad pertenece a la red programatica" ForeColor="White" Font-Size="11"/>
                                     <br />
                                     <asp:Label ID="Label2" runat="server" Text="planificar de forma mensual" ForeColor="White" Font-Size="11"/>
                                 </td>                               
                             </tr>
                                 </table>
                                 <table style="border-collapse:separate;border-spacing:10px;font-size:14px;text-align:center;">                                    
                                   <tr>
                                       <td><asp:Label ID="Label4" runat="server" Text="Actividad:" Font-Bold="true" /></td>
                                       <td style="text-align:justify;font-size:12px;"><asp:Label ID="lblActividad" runat="server" Width="500px"  /></td>
                                   </tr>                                    
                                </table> 
                                 <table style="margin:auto;border-collapse:separate;border-spacing:3px;font-size:14px;text-align:center;">
                                     <tr><td><asp:Label ID="Label12" runat="server" Text="Unidades de Medida" Font-Bold="true" /></td></tr>
                                  </table>
                                 <table  style="border-collapse:separate;border-spacing:5px;font-size:14px;"> 
                                    <tr id="RUM1" runat="server">
                                        <td><asp:Label ID="Label6" runat="server" Text="UM1:" Font-Bold="true" /></td>
                                        <td><asp:Label ID="LblUM1" runat="server" Text="UM1" /></td>
                                     </tr>
                                     <tr id="RUM2" runat="server">
                                        <td><asp:Label ID="Label7" runat="server" Text="UM2:" Font-Bold="true" /></td>
                                        <td><asp:Label ID="LblUM2" runat="server" Text="UM2"/></td>                                        
                                    </tr>
                                     <tr id="RUM3" runat="server">
                                        <td><asp:Label ID="Label8" runat="server" Text="UM3:" Font-Bold="true" /></td>                                        
                                        <td><asp:Label ID="LblUM3" runat="server" Text="UM3" /></td>
                                    </tr>
                                </table>                                 
                                  <table style="margin:auto;border-collapse:separate;border-spacing:8px;font-size:14px;text-align:center;">                                      
                                      <tr><td colspan="3"><asp:Label ID="LblMes" runat="server" Width="300px" Font-Bold="true" /></td></tr>
                                      <tr >
                                        <td><asp:Label ID="Label9" runat="server" Text="UM1" Font-Bold="true" /></td>
                                        <td><asp:Label ID="Label10" runat="server" Text="UM2" Font-Bold="true" /></td>
                                        <td><asp:Label ID="Label11" runat="server" Text="UM3" Font-Bold="true" /></td>
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
                                 <td><asp:LinkButton ID="CancelarEdición" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Cancelar edicion de metas" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Ingreso</asp:LinkButton></td>                                
                                </tr>                      
                         </table> 
                            </div> 
                                 <telerik:RadGrid runat="server" ID="GridUnidades" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="4" 
                                   DataKeyNames="Id_mes,Descripcion_Mes,Meta_UM1,Meta_UM2,Meta_UM3,Id_Componente,Id_SubComponente,Id_ProductoVeficable" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Editar Valores de ingreso de metas" HeaderText ="Editar<br/>Valores" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                      <telerik:GridBoundColumn DataField="Id_mes" UniqueName="Id_mes" Visible="false"></telerik:GridBoundColumn>       
                                       <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Visible="false"></telerik:GridBoundColumn>  
                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Visible="false"></telerik:GridBoundColumn>  
                                        <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Visible="false"></telerik:GridBoundColumn>                                          
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
                        </ContentTemplate> 
                      </asp:UpdatePanel> 
                     </li>
                </ul>
            </div> 
            </div> 
</asp:Content>
