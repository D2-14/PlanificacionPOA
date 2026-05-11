<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ReprogramacionPlanificacion.aspx.cs" Inherits="PlanificacionPOA.Paginas.ReprogramacionPlanificacion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Tareas de Revisión de Reprogramación Asignadas al (ENCARGADO PLANIFICACIÓN)</h5>
                   <p class="text-muted m-b-10">En este Apartado  podra revisar las Reprogramaciones de las Subregiones puede pre Aprobar, denegar la reprogramación que ingresaron
                       informacion las direcciones subregionales.
                   </p>
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true"></telerik:RadWindow> 
                               <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>                        
                               <telerik:RadGrid runat="server" ID="GRDSubregiones" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="15" 
                                   DataKeyNames="Id_PoAnual,FechaDeAsignacion,POA,FechaDeEntrega,EstadoDeAsignacion,Id_Region,Id_Subregion,IdMensaje,Instrucciones,Nombre_SubRegion,
                                       TipoAsignacion,NoReprogramacion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display ="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="IdMensaje" UniqueName="IdMensaje" Display ="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>                                         
                                       <telerik:GridBoundColumn DataField="Asignado" UniqueName="Asignado" Visible ="false"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="NoReprogramacion" UniqueName="NoReprogramacion" Visible ="false"></telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="TipoAsignacion" UniqueName="TipoAsignacion" Visible ="false"></telerik:GridBoundColumn>
                                      <telerik:GridButtonColumn Text="ver Metas de la subregión" HeaderText="Ver<br/>Metas" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>                                    
                                         <telerik:GridBoundColumn DataField="Nombre_Region" UniqueName="Nombre_Region" HeaderText="Región">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Nombre_SubRegion"  UniqueName="Nombre_SubRegion" HeaderText="SubRegión">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                   
                                      <telerik:GridBoundColumn DataField="Etapa" UniqueName="Etapa" HeaderText="Etapa">
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                               
                                         <telerik:GridBoundColumn DataField="POA" UniqueName="POA" HeaderText="Poa" >
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="FechaDeAsignacion"  UniqueName="FechaDeAsignacion" HeaderText="Fecha de<br/>Asignación">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                     <telerik:GridBoundColumn DataField="FechaDeEntrega"  UniqueName="FechaDeEntrega" HeaderText="Fecha de<br/>Finalización">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>
                                         <telerik:GridButtonColumn Text="Exportar la información del poa a un formato de Excel" HeaderText="Descargar<br/>Poa" CommandName="Select4" UniqueName="BotonH"  
                                             ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                         <telerik:GridButtonColumn Text="Aprobar las Metas de la subregión" HeaderText="Aprobar<br/>Metas" CommandName="Select2" UniqueName="BotonC" 
                                         ButtonType="ImageButton" ImageUrl="../Iconos/Aprobar.png" ButtonCssClass="imageButtonClass" ConfirmText="Esta Seguro de aprobar las metas?" ConfirmDialogType="RadWindow" ConfirmTitle="Aprobar Metas">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn Text="Observaciones de Metas para la Región" HeaderText="Observaciones<br/>de Metas" CommandName="Select3" UniqueName="BotonD" 
                                         ButtonType="ImageButton" ImageUrl="../Iconos/Denegar.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
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
                  </li>
             </ul> 
        </div> 
    </div> 
</asp:Content>
