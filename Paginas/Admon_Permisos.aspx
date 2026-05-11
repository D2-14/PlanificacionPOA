<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Admon_Permisos.aspx.cs" Inherits="PlanificacionPOA.Paginas.Admon_Permisos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header card">
        <div class="card-block">
               <h5 class="m-b-10">Asignación de Permisos en el Sistema</h5>
                   <p class="text-muted m-b-10">Asignación de Permisos (Roles) a los usuarios creados en el sistema, aquí  podra asignarles que procesos tienen permisos en el sistema.
                       ademas podra asignar permisos por usuario ademas de los permisos por perfil que tiene por defecto </p>
                     <ul class="breadcrumb-title b-t-default p-t-10">
                        <li>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
                                 <telerik:RadTabStrip runat="server" ID="RadTabStrip1"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="MetroTouch">
                                <Tabs>
                                <telerik:RadTab Text="Usuarios" Width="400px" Font-Size="13px"></telerik:RadTab>               
                                </Tabs>
                                </telerik:RadTabStrip>
                               <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0">
                                    <telerik:RadPageView ID="RadPageView1" runat="server">                                         
                                        <table runat="server" id="Table2" style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                        <tr><td>
                                    <div class="panel panel-success">
                                       <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-user" style="font-size:12px;"></span>&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Datos del Usuario" Font-Size="10"/></div>      
                                    <div class="panel-body">                                       
                                       <telerik:RadGrid runat="server" ID="GridUsuariosSistema" AutoGenerateColumns="False" Width="100%" 
                                     AllowSorting ="False" AllowFilteringByColumn="True" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                     ShowStatusBar ="True" ShowGroupPanel="false" onitemdatabound="TKGridusuario_ItemDataBound">
                                    <GroupingSettings CaseSensitive="False" />
                                    <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                          <Selecting AllowRowSelect="True"></Selecting>                                       
                                    </ClientSettings>
                    <MasterTableView PageSize="5" 
                     DataKeyNames="id_usuario,Estado_Usuario,usuario,Correo,Id_Plantilla" NoMasterRecordsText="Sin Información">
                     <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                     <Columns>                              
                              <telerik:GridButtonColumn Text="Seleccionar el Usuario Para Asignarle permiso o Quitarle"  CommandName="Select" ButtonType="ImageButton" ImageUrl="../Iconos/Seleccionar.png" HeaderText="Seleccionar" ButtonCssClass="imageButtonClass">                              
                                  <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" ForeColor="Red"/>
                                  <ItemStyle  HorizontalAlign="Center"/> 
                              </telerik:GridButtonColumn>
                              <telerik:GridBoundColumn DataField="id_usuario" UniqueName="id_usuario" Visible="false">                     
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                                 <telerik:GridBoundColumn DataField="Id_Plantilla" UniqueName="Id_Plantilla" Visible="false">                     
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Estado_Usuario"  UniqueName="estadousuario" Visible="false">                             
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Usuario" UniqueName="Usuario" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Nombre Completo">
                                  <HeaderStyle Width="200px" HorizontalAlign="Center" Font-Bold="true" />
                                   <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>
                              </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="Correo" UniqueName="Correo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Usuario" >
                                  <HeaderStyle Width="250px" HorizontalAlign="Center" Font-Bold="true"/>
                                   <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" HeaderText="Estado" AllowFiltering="False" Visible="false">                                                            
                                  <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="true"/>
                                  <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>  
                              </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="perfil" UniqueName="Estado" HeaderText="Perfil" AllowFiltering="False">                                                            
                                  <HeaderStyle Width="180px" HorizontalAlign="Center" Font-Bold="true"/>
                                   <ItemStyle  HorizontalAlign="left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                              </telerik:GridBoundColumn>  
                     </Columns>
                    </MasterTableView>
                    <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                          {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                          &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/> 
                        <FilterMenu RenderMode="Classic">
                        </FilterMenu>
                        <HeaderContextMenu>
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                                     </div></div>     
                                     </td></tr></table>    
                                    </telerik:RadPageView>
                                </telerik:RadMultiPage>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                                </ContentTemplate> 
                           </asp:UpdatePanel> 
                        </li> 
                     </ul>            
            </div> 
       </div> 
   <div class="page-header card">
        <div class="card-block">
                     <ul class="breadcrumb-title b-t-default p-t-10">
                        <li>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>                                
                                 <telerik:RadTabStrip runat="server" ID="RadTabStrip2"  MultiPageID="RadMultiPage1" SelectedIndex="0" Skin="MetroTouch">
                                <Tabs>
                                <telerik:RadTab Text="Permisos (Roles)" Width="400px" Font-Size="13px"></telerik:RadTab>               
                                </Tabs>
                                </telerik:RadTabStrip>
                               <telerik:RadMultiPage ID="RadMultiPage2" runat="server" SelectedIndex="0">
                                    <telerik:RadPageView ID="RadPageView2" runat="server">
                                        <table runat="server" id="Table1" style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                        <tr><td>
                                    <div class="panel panel-success">
                                       <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-list-alt" style="font-size:12px;"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Permisos del Sistema" Font-Size="10"/>                                          
                                        <span class="glyphicon glyphicon-chevron-left" style="font-size:12px;"></span>                                          
                                            <asp:Label ID="LblUsuario" runat="server" Font-Bold="True" Font-Size="10"></asp:Label>                                       
                                        <span class="glyphicon glyphicon-chevron-right" style="font-size:12px;"></span>                                     
                                    </div>       
                                    <div class="panel-body"> 
                                    <telerik:RadTreeList  ID="Opciones_del_Sistema" runat="server" onitemdatabound="Opciones_ItemDataBound" 
                                        DataKeyNames="Id_Menu" ParentDataKeyNames="Cod_Padre" AutoGenerateColumns="false"  GridLines="Both" Culture="es-GT" Skin="Office2007">                
                                        <ItemStyle VerticalAlign="Middle"></ItemStyle>
                                        <Columns>
                                        <telerik:TreeListBoundColumn DataField="Id_Menu" HeaderText="" visible="false" UniqueName="Id_Menu"></telerik:TreeListBoundColumn>
                                        <telerik:TreeListBoundColumn DataField="Descripcion_Menu" HeaderText="Menu" UniqueName="Descripcion_Menu">
                                        <HeaderStyle HorizontalAlign="Center" Width="90px" Font-Bold="true" Font-Names="Arial"/>
                                        <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>   
                                        </telerik:TreeListBoundColumn>
                                        <telerik:TreeListBoundColumn DataField="Estado" HeaderText="Estado" UniqueName="Estado">                    
                                        <HeaderStyle HorizontalAlign="Center" Width="90px" Font-Bold="true" Font-Names="Arial"/>    
                                        <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Bold="true"/>
                                        </telerik:TreeListBoundColumn>                    
                                        <telerik:TreeListTemplateColumn HeaderStyle-Width="70px">
                                        <HeaderTemplate>
                                    <a style="text-align:center;font-family:Arial;font-size:10px;">Activar<br />Desactivar</a>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="SelectButton" CommandName="Select" width="20px" runat="server" UniqueName="BotonA" ImageAlign="Middle" ImageUrl="~/iconos/flecha_Abajo.png" ToolTip="Asignar/Desasignar Permisos al Perfil"/>                                                   
                        </ItemTemplate>
                        <HeaderStyle Width="25px" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" Font-Size="12"/>
                        <ItemStyle HorizontalAlign="Center" />
                    </telerik:TreeListTemplateColumn>
                </Columns>
                    </telerik:RadTreeList>
                                     </div></div>     
                                     </td></tr></table>    
                                    </telerik:RadPageView>
                                </telerik:RadMultiPage>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                                </ContentTemplate> 
                           </asp:UpdatePanel> 
                        </li> 
                     </ul>
               <ul class="breadcrumb-title b-t-default p-t-10"/> 
            </div> 
       </div> 
</asp:Content>
