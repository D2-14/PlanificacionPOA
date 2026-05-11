<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Admon_Usuarios.aspx.cs" Inherits="PlanificacionPOA.Paginas.Admon_Usuarios" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">    
   <div class="page-header card">
        <div class="card-block">
               <h5 class="m-b-10">Información de los Usuarios</h5>
                   <p class="text-muted m-b-10">Ingreso de la información del usuario que va a utilizar el sistema, Activación e Inactivar de Usuarios,
                       Reseteo de contraseñas, y edición de usuario </p>
                     <ul class="breadcrumb-title b-t-default p-t-10">
                        <li>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                             <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>   
                             <asp:TextBox ID="Tusaurio" runat="server" Visible="false"></asp:TextBox>  
                        <telerik:RadTabStrip runat="server" ID="RadTabStrip1" MultiPageID="Paginas" SelectedIndex="0" Skin="MetroTouch" Culture="es-GT">
                        <Tabs>
                            <telerik:RadTab Text="Administración de Usuarios del Sistema" Width="400px" Font-Size="13px"></telerik:RadTab>
                            <telerik:RadTab Text="Edición" Width="400px" Font-Size="13px"></telerik:RadTab>             
                        </Tabs>
                        </telerik:RadTabStrip>                        
                        <telerik:RadMultiPage ID="Paginas" runat="server" SelectedIndex="0" > 
                        <telerik:RadPageView ID="Usuarios" runat="server" Height="100%"><br />
                            <table runat="server" id="Table1" style="margin:auto;border-collapse:separate;border-spacing: 2px;"> 
                                <tr><td>                       
                              <div class="panel panel-success">                        
                              <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-user" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Datos del Usuario" Font-Size="10"/></div>
                             <div class="panel-body">
                              <table runat="server" id="ConFecha" style="margin:auto;border-collapse:separate;border-spacing:10px;"> 
                             <tr style="font-family:Arial;font-size:13px;font-weight:bold;">
                                 <td><label for="Label2">Nombres</label></td>
                                 <td><label for="Label2">Apellidos</label></td>
                                 <td><label for="Label2">No. DPI (CUI)</label></td>
                            </tr>
                                <tr>
                                    <td><asp:TextBox ID="txtnombres" runat="server" class="form-control" Width="100%" placeholder="Ingrese Nombres."></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtapelllidos" runat="server" class="form-control" Width="100%" placeholder="Ingrese Apellidos."></asp:TextBox></td>
                                    <td><telerik:RadMaskedTextBox ID="txtdpi" runat="server" DisplayMask="####-#####-####"
                                                 Mask="####-#####-####" NumericRangeAlign="Left" onkeydown="return (event.keyCode!=13);"
                                                PromptChar="_" SelectionOnFocus="SelectAll" Width="100%" Skin="MetroTouch">
                                            </telerik:RadMaskedTextBox></td>                        
                            </tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td><label for="Label2">Dirección/Unidad/Región</label></td></tr>
                                  <tr><td colspan="3"><asp:DropDownList ID="cboRegion" runat="server" AutoPostBack="True" CssClass="form-control" Width="100%"></asp:DropDownList></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td><label for="Label2">Departamento/Subregión</label></td></tr>
                                  <tr><td colspan="3"><asp:DropDownList ID="cbosubregion" runat="server" AutoPostBack="True" class="form-control" Width="100%"></asp:DropDownList></td></tr>
                                <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td><label for="Label2">Puesto</label></td></tr>
                                <tr><td colspan="3"><asp:DropDownList ID="cboPuesto" runat="server" AutoPostBack="True" class="form-control" Width="100%"></asp:DropDownList></td></tr>
                                    <tr style="font-family:Arial;font-size:13px; font-weight:bold;">
                                    <td><label for="Label2">Usuario</label></td>
                                    <td><label for="Label2">Tipo de Perfil</label></td>                   
                            </tr>
                            <tr>                                
                               <td><asp:TextBox ID="txtusuario" runat="server" class="form-control" Width="100%" TextMode="Email" placeholder="Correo electrónico Institucional...."></asp:TextBox></td>                                      
                               <td colspan="2"><asp:DropDownList ID="cbotipoPerfil" runat="server" AutoPostBack="True" class="form-control" Width="100%"></asp:DropDownList></td>                     
                            </tr>
                         </table> 
                             <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                <tr>
                                    <td>
                               <asp:LinkButton ID="Agregar" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Agregar Usuario en el Sistema</asp:LinkButton>                               
                                </td>
                                    <td>
                               <asp:LinkButton ID="Cancelar" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton>                               
                                </td>  
                                </tr>                      
                         </table> 
                            </div>                                       
                           </td></tr>
                            </table> 
                            <table runat="server" id="Table2" style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                <tr><td>
                                    <div class="panel panel-success">
                                    <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-cog" style="font-size:12px;"></span>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Activación, Inactivación y Reseteo Contraseña de Usuarios" Font-Size="10"/></div>
                                    <div class="panel-body"> 
                                        <telerik:RadGrid runat="server" ID="GridUsuarioOtros" AutoGenerateColumns="False" Width="100%"  
                                     AllowSorting ="False" AllowFilteringByColumn="True" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                     ShowStatusBar ="True" ShowGroupPanel="false">
                                         <GroupingSettings CaseSensitive="False" />
                                        <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                          <Selecting AllowRowSelect="True"></Selecting>                                      
                                    </ClientSettings>
                                    <MasterTableView PageSize="5" 
                                    DataKeyNames="id_usuario,estado_usuario,Usuario,Correo" NoMasterRecordsText="Sin Información">
                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                              <telerik:GridButtonColumn Text="Activar/Desactivar Usuario" HeaderText="Activar<br/>Desactivar" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton"  HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                  <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                              </telerik:GridButtonColumn>                              
                              <telerik:GridButtonColumn Text="Reiniciar la Contraseña del Usuario" HeaderText="Reiniciar la Contraseña" CommandName="Select2" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/ResetearN.png" ButtonCssClass="imageButtonClass">
                                  <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true" />
                                   <ItemStyle HorizontalAlign="Center"/>
                              </telerik:GridButtonColumn>                                
                              <telerik:GridBoundColumn DataField="id_usuario" UniqueName="id_usuario" Visible="false" HeaderStyle-Width="60px" >                     
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="estado_usuario"  UniqueName="estado_usuario" Visible="false" HeaderStyle-Width="60px">                             
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Usuario" UniqueName="Usuario" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Nombre Completo">
                                  <HeaderStyle Width="250px"  Font-Bold="true"  HorizontalAlign="Center" Font-Names="Arial"/>
                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                              </telerik:GridBoundColumn>  
                                  <telerik:GridBoundColumn DataField="Correo" UniqueName="Correo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Correo Electrónico (Usuario)">
                                  <HeaderStyle Width="250px" HorizontalAlign="Center"  Font-Bold="true" Font-Names="Arial"/>
                                    <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                              </telerik:GridBoundColumn>                   
                              <telerik:GridBoundColumn DataField="Estado" UniqueName="Estado" HeaderText="Estado" AllowFiltering="False">                                                            
                                  <HeaderStyle Width="100px" HorizontalAlign="Center"  Font-Bold="true" Font-Names="Arial"/>
                                  <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>  
                              </telerik:GridBoundColumn>
                         <telerik:GridBoundColumn DataField="perfil"   UniqueName="Estado" HeaderText="Perfil" AllowFiltering="False">                                                            
                                  <HeaderStyle Width="210px" HorizontalAlign="Center"  Font-Bold="true" Font-Names="Arial"/>
                                   <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                              
                              </telerik:GridBoundColumn>  
                     </Columns>
                    </MasterTableView>
                   <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                          {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                          &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/> 
                        <FilterMenu>
                        </FilterMenu>
                        <HeaderContextMenu>
                        </HeaderContextMenu>
                    </telerik:RadGrid>
                                    </div> 
                               </td></tr>
                            </table> 
                        </telerik:RadPageView> 
                        <telerik:RadPageView ID="Edicion" runat="server" Height="100%"><br />
                             <table runat="server" id="Table3" style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                <tr><td>
                                    <div class="panel panel-success">
                                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-pencil" style="font-size:12px;"></span>&nbsp;&nbsp;
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Edición de Usuarios del Sistema" Font-Size="10"></asp:Label></div>
                                        </div>
                                        <div class="panel-body">                                                                                  
                                        <div class="BarraScroll">
                                    <telerik:RadGrid runat="server" ID="GridUsuarioEdicion" AutoGenerateColumns="False" Width="100%" 
                                     AllowSorting ="False" AllowFilteringByColumn="True" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                     ShowStatusBar ="True" ShowGroupPanel="false">
                                     <GroupingSettings CaseSensitive="False" />
                                        <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                          <Selecting AllowRowSelect="True"></Selecting>                                        
                                    </ClientSettings>
                                    <MasterTableView PageSize="10" 
                                    DataKeyNames="id_usuario,estado_usuario,usuario,Correo" NoMasterRecordsText="Sin Información">
                                    <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                              
                              <telerik:GridButtonColumn Text="Editar Usuario del Sistema" HeaderText="Editar" CommandName="Select" ButtonType="ImageButton" ImageUrl="../Iconos/EditarI.png" ButtonCssClass="imageButtonClass">                              
                                   <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial"  Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                              </telerik:GridButtonColumn>
                              <telerik:GridBoundColumn DataField="id_usuario" UniqueName="id_usuario" Visible="false">                     
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="estado_usuario"  UniqueName="estado_usuario" Visible="false">                             
                                  <HeaderStyle Width="60px" />
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Usuario"  UniqueName="Usuario" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains"  HeaderText="Nombre Completo">
                                  <HeaderStyle Width="300px" HorizontalAlign="Center" Font-Bold="true" />
                                   <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>
                              </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="Correo"  UniqueName="Correo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains"  HeaderText="Correo Electrónico (Usuario)">
                                  <HeaderStyle Width="300px" HorizontalAlign="Center" Font-Bold="true"/>
                                   <ItemStyle HorizontalAlign="Left" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="Estado"   UniqueName="Estado" HeaderText="Estado" AllowFiltering="False">                                                            
                                  <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="true"/>
                                  <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>  
                              </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="perfil"   UniqueName="Estado" HeaderText="Perfil" AllowFiltering="False">                                                            
                                  <HeaderStyle Width="250px" HorizontalAlign="Center" Font-Bold="true"/>
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
                             </div> 
                   
                      </div> 
                     </div> 
                               </td></tr>
                            </table>    
                        </telerik:RadPageView> 
                        </telerik:RadMultiPage> 
                           </ContentTemplate> 
                        </asp:UpdatePanel>
       <telerik:RadWindow runat="server" Modal="true" ID="Edicion_Usuario" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
        <ContentTemplate>
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-pencil"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Edicion de Usuarios del Sistema" Font-Size="10"/></div></div>
                        <div class="panel-body">                        
                           <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">
                <tr>
                    <td><label for="Label2">Nombres</label></td>
                    <td><label for="Label2">Apellidos</label></td>
                     <td><label for="Label2">No. DPI (CUI)</label></td>
                </tr>
                <tr>
                    <td><asp:TextBox ID="nombre" runat="server" class="form-control" Width="250px"></asp:TextBox></td>
                    <td><asp:TextBox ID="apellido" runat="server" class="form-control" Width="250px"></asp:TextBox></td>
                    <td><telerik:RadMaskedTextBox ID="txtdpi2" runat="server" DisplayMask="####-#####-####" 
                                                 Mask="####-#####-####" NumericRangeAlign="Left" onkeydown="return (event.keyCode!=13);"
                                                PromptChar="_" SelectionOnFocus="SelectAll" Width="250px" Skin="MetroTouch">
                                            </telerik:RadMaskedTextBox></td>
                </tr>
                    <tr><td><label for="Label2">Dirección/Unidad/Región</label></td></tr>
                    <tr><td colspan="3" ><asp:DropDownList ID="region" runat="server" class="form-control" Width="765px" AutoPostBack="true"></asp:DropDownList></td> </tr>
                    <tr><td><label for="Label2">Departamento/Subregión</label></td> </tr>
                     <tr><td colspan="3"><asp:DropDownList ID="subregion" runat="server" class="form-control" Width="765px"></asp:DropDownList></td> </tr>
                     <tr><td><label for="Label2">Puesto</label></td></tr>
                    <tr><td colspan="3"><asp:DropDownList ID="puesto" runat="server"  class="form-control" Width="765px"></asp:DropDownList></td></tr>
                <tr>
                    <td><label for="Label2">Usuario</label></td>
                    <td><label for="Label2">Tipo de Perfil</label></td>                   
                </tr>
                 <tr>
                    <td><asp:TextBox ID="usuario" runat="server" class="form-control" Width="250px"></asp:TextBox></td>                                      
                    <td colspan="2"><asp:DropDownList ID="perfil" runat="server" AutoPostBack="True" class="form-control" Width="510px"></asp:DropDownList></td>                    
                </tr>                               
            </table><br />  
            <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                <tr style="text-align:center">                    
                           <td>
                               <asp:LinkButton ID="Guardar" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar la información</asp:LinkButton>                               
                           </td>
                            <td>
                               <asp:LinkButton ID="Cancelar_Edicion" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Edición</asp:LinkButton>                               
                           </td>  
                       </tr>                                                           
            </table>
                             </div>
                        </div> 
                        
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 

                        </li>                                                              
                   </ul>
             <ul class="breadcrumb-title b-t-default p-t-10"/>                                                                                                   
      </div>
   </div>
</asp:Content>

