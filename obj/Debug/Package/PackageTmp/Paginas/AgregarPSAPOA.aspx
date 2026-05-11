<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPSAPOA.aspx.cs" Inherits="PlanificacionPOA.Paginas.AgregarPSAPOA" %>
 <%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Agregar Productos, Subproductos y Actividades a POoas Nacionales</h5>
                   <p class="text-muted m-b-10">En este Apartado podra Agregar los productos, subproductos y actividades a poas que ya estan
                       aprobados por Planificación</p>    
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <telerik:radwindowmanager ID="RadWindowManager" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                             <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                                <tr><td style="text-align:center;" ><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                            </table>
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                    <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Mantenimiento</asp:LinkButton></td>                               
                                </tr>                        
                                </table>
                                <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;">
                                    <tr>
                                        <td><asp:Label ID="Label1" runat="server" Text="Información Poa que no esta Aprobado"  Font-Bold="true" Font-Size="12" ForeColor="#ff0000"/></td>
                                        <td><asp:Label ID="Label2" runat="server" Text="Información Poa Aprobado por Planificación"  Font-Bold="true" Font-Size="12" ForeColor="#ff0000"/></td>
                                    </tr>
                                    <tr style="vertical-align:top;">
                                        <td>
                                       <telerik:RadGrid runat="server" ID="GridProductos" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="8" 
                                   DataKeyNames="Tipo,Correlativo,Descripcion,Id_Producto,Id_SubProducto,Id_Actividad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns> 
                                         <telerik:GridButtonColumn Text="EAgregar Producto, Subproducto y Actividad" CommandName="Delete" UniqueName="BotonA" HeaderText="Agregar" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/AgregarD.png" ConfirmText="Desea Agregar el Producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Agregar Producto" 
                                        ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn>                                        
                                        <telerik:GridBoundColumn DataField="Tipo" UniqueName="Tipo" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Visible="false"></telerik:GridBoundColumn>                                           
                                      <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" FilterControlWidth="100%" 
                                          AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="DESCRIPCIÓN DEL PRODUCTO/SUBPRODUCTO/ACTIVIDAD">
                                          <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                        
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid> 
                                        </td>
                                        <td>
                               <telerik:RadGrid runat="server" ID="GridProductosAproabados" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="8" 
                                   DataKeyNames="Tipo,Correlativo,Descripcion,Id_Producto,Id_SubProducto,Id_Actividad" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns> 
                                         <telerik:GridButtonColumn Text="Eliminar Producto, Subproducto y Actividad" CommandName="Delete" UniqueName="BotonA" HeaderText="Eliminar" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/delete.png" ConfirmText="Desea eliminar el producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Producto" 
                                        ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn>                                      
                                        <telerik:GridBoundColumn DataField="Tipo" UniqueName="Tipo" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_Producto" UniqueName="Id_Producto" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_SubProducto" UniqueName="Id_SubProducto" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="Id_Actividad" UniqueName="Id_Actividad" Visible="false"></telerik:GridBoundColumn>                                           
                                      <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" FilterControlWidth="100%" 
                                          AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="DESCRIPCIÓN DEL PRODUCTO/SUBPRODUCTO/ACTIVIDAD">
                                          <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                        
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid> 
                                        </td>
                                    </tr>
                                </table> 
                        </ContentTemplate> 
                      </asp:UpdatePanel>
                  </li> 
              </ul>
         </div> 
</div> 
</asp:Content>
