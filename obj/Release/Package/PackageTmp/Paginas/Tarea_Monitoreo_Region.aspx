<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Tarea_Monitoreo_Region.aspx.cs" Inherits="PlanificacionPOA.Paginas.Tarea_Monitoreo_Region" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Tareas Asignadas al Regional</h5>
                   <p class="text-muted m-b-10">En este Apartado estan las tareas asignadas al director Regional de parte de Monitoreo y seguimiento
                       de la Dirección de Planificación, Monitoreo y Evaluación Institucional</p>
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
                                   DataKeyNames="Id_PoAnual,FechaDeAsignacion,Fecha_Inicio,Fecha_Final,EstadoDeAsignacion,Id_Region,Id_Subregion,
                                                 IdMensaje,Asignado,Id_Mes,Instrucciones,POA,mes" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>  
                                     <telerik:GridButtonColumn Text="Enviar Tareas a los SubRegionales" HeaderText="Iniciar<br/>Tarea" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/TareaRegional.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="30px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>                                           
                                         <telerik:GridButtonColumn Text="Mensaje enviado de Monitoreo y Seguimiento" HeaderText="Mensaje" CommandName="Select1" 
                                          UniqueName="BotonB" ButtonType="ImageButton" ImageUrl="../Iconos/mensaje.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="IdMensaje" UniqueName="IdMensaje" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Visible="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>   
                                       <telerik:GridBoundColumn DataField="Instrucciones" UniqueName="Instrucciones" Visible="false"></telerik:GridBoundColumn>     
                                       <telerik:GridBoundColumn DataField="Asignado" UniqueName="Asignado" Visible="false"></telerik:GridBoundColumn>                                      
                                        <telerik:GridBoundColumn DataField="POA" UniqueName="POA" HeaderText="Poa" >
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                             
                                      <telerik:GridBoundColumn DataField="Etapa" UniqueName="Etapa" HeaderText="Etapa">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                    
                                        <telerik:GridBoundColumn DataField="Nombre_Region"  UniqueName="Nombre_Region" HeaderText="Región">
                                           <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="mes"  UniqueName="mes" HeaderText="Mes de Ingreso de <br/>Ingreso de Ejecución">
                                           <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                           
                                     <telerik:GridBoundColumn DataField="Fecha_Inicio"  UniqueName="Fecha_Inicio" HeaderText="Fecha de Inicio<br/>de la Tarea" Display="false">
                                           <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                           <telerik:GridBoundColumn DataField="FechaDeAsignacion"  UniqueName="FechaDeAsignacion" HeaderText="Fecha de Asignación<br/>de la Tarea">
                                           <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>  
                                     <telerik:GridBoundColumn DataField="Fecha_Final"  UniqueName="Fecha_Final" HeaderText="Fecha de Finalización<br/>de la Tarea">
                                           <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                            
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
                    <telerik:RadWindow runat="server" Modal="true" ID="InicioTarea" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Mensaje de tarea a Subregiones" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                               
                                <tr><td><asp:TextBox ID="txtmensaje" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="130px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                                                                         
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="IniciarTarea" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Iniciar Tarea</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CerrarVentanaTarea" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>  
                                </tr>                                                           
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
                  </li>
             </ul>
          </div> 
    </div> 
</asp:Content>
