<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Tareas_Departamentos.aspx.cs" Inherits="PlanificacionPOA.Paginas.Tareas_Departamentos" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Tareas Asignadas a Departamento, Unidades Y Parques Nacionales</h5>
                   <p class="text-muted m-b-10">En este Apartado estan las tareas que fueron asignadas a Departamento, Unidades Y Parques Nacionales, dependiendo a donde pertenezca su poa</p>
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>
                          <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>                        
                               <telerik:RadGrid runat="server" ID="GridTareaP" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="15" 
                                   DataKeyNames="Id_PoAnual,FechaDeAsignacion,FechaDeEntrega,EstadoDeAsignacion,Id_Region,Id_Subregion,IdMensaje,Instrucciones,POA,TipoAsignacion,NoReprogramacion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="IdMensaje" UniqueName="IdMensaje" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>   
                                       <telerik:GridBoundColumn DataField="Instrucciones" UniqueName="Instrucciones" Visible="false"></telerik:GridBoundColumn>     
                                       <telerik:GridBoundColumn DataField="TipoAsignacion" UniqueName="TipoAsignacion" Visible="false"></telerik:GridBoundColumn>  
                                          <telerik:GridBoundColumn DataField="NoReprogramacion" UniqueName="NoReprogramacion" Visible="false"></telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="POA" UniqueName="POA" HeaderText="Poa" >
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                             
                                      <telerik:GridBoundColumn DataField="Etapa" UniqueName="Etapa" HeaderText="Etapa">
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                    
                                        <telerik:GridBoundColumn DataField="Nombre_Region"  UniqueName="Nombre_Region" HeaderText="Coordinación Técnica<br/>Dirección">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Subregion"  UniqueName="Subregion" HeaderText="Departamento,<br/>Unidad/Parque Nacional">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                      <telerik:GridButtonColumn Text="Mensaje del Regional" HeaderText="Mensaje" CommandName="Select1" UniqueName="BotonB" ButtonType="ImageButton" ImageUrl="../Iconos/mensaje.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>
                                        <telerik:GridBoundColumn DataField="FechaDeAsignacion"  UniqueName="FechaDeAsignacion" HeaderText="Fecha de Asignación">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                     <telerik:GridBoundColumn DataField="FechaDeEntrega"  UniqueName="FechaDeEntrega" HeaderText="Fecha de Finalización">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                             
                                      <telerik:GridButtonColumn Text="Ingreso de metas Regionales" HeaderText="Ingreso<br/>de Metas" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/descarga.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial" />
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
                      </ContentTemplate>
                    </asp:UpdatePanel>                       
                       <telerik:RadWindow runat="server" Modal="true" ID="MensajePla" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Instrucciones" Font-Size="10"/></div></div>
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
               <telerik:RadWindow ID="confirmar" runat="server" Left="900px" Top="2px" Modal="true" Behaviors="None" Skin="Office2007"
                    VisibleTitlebar="false" VisibleStatusbar="false" Style="z-index: 100001">
                <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>   
                    <div style="margin-top: 30px; float: left;">
                        <div style="width:60px; padding-left: 15px; float: left;">                           
                            <img src="../Iconos/alerta.gif" width="40" alt="Confirmar Pagina" />
                        </div>
                       <div style="width: 250px; float: left;">
                            <asp:Label ID="lblConfirm" Font-Size="14px" Text="NO puede Iniciar el Ingreso de Metas, NO a configurado sus Actividades"
                                runat="server"></asp:Label>
                            <br />
                            <br />
                            </div>
                           <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">
                                <td><asp:LinkButton ID="btnCerrarVentana" runat="server" CssClass="btn btn-warning btn-sm" Text="Guardar"><span class="glyphicon glyphicon-ok"></span>&nbsp;Aceptar</asp:LinkButton></td>      
                                <td><asp:LinkButton ID="btnIrConfiguracion" runat="server" CssClass="btn btn-primary btn-sm" Text="Guardar"><span class="glyphicon glyphicon-open"></span>&nbsp;Ir a Configuración UM</asp:LinkButton></td>                                  
                                </tr>                                                           
                          </table>                       
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
