<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="ModificacionesPOA.aspx.cs" Inherits="PlanificacionPOA.Paginas.ModificacionesPOA" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
       function Hide()
       {
           document.getElementById('exp').style.display = 'none';
       }
       function Show() {
           document.getElementById('exp').style.display = 'block';
       }
     </script>
     <div class="page-header card">
        <div class="card-block">
             <h5 class="m-b-10">Modificaciones del POA'S SubRegional</h5>
                   <p class="text-muted m-b-10">En este Apartado  se podra visualizar las Modificaciones que se le hicieron al poa de la subregión </p>          
            <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
             <table style="border-collapse:separate;border-spacing:2px;font-family:Arial;font-size:13px;font-weight:bold;">
                   <tr><td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Módulo Anterior</asp:LinkButton></td></tr>
             </table>
             <ul class="breadcrumb-title b-t-default p-t-10">
                  <li>
                      <div class="panel panel-success">                        
                          <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-eye-open" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Visualización de Modificaciones" Font-Size="10"/></div>
                          <div class="panel-body">
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate> 
                               <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;"> 
                                    <tr><td style="text-align:center;" ><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="14" ForeColor="#0066cc"/></td></tr>
                                    <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff0000"/></td></tr>
                                </table> 
                                 </ContentTemplate> 
                            </asp:UpdatePanel>  
                              <div id="exp"><asp:LinkButton ID="btnXLS" runat="server" CssClass="btn btn-info btn-sm" ToolTip="exporta a excel"  Text="Guardar"><span class="glyphicon glyphicon-download-alt"></span>&nbsp;Exportar a Excel las Modificaciones</asp:LinkButton><br /><br /></div> 
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate> 
                              <telerik:RadGrid runat="server" ID="GdrCambios" AutoGenerateColumns="False" Width="100%" AllowSorting ="True" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="15" 
                                   DataKeyNames="IdComponente,Id_SubComponente,mes,Componente,Subcomponente,Producto,UM1A,UM2A,UM3A,UM1AC,UM2AC,UM3AC,Fecha" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                         <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Valores UM Anteriores" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Valores UM Actuales" Name="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                         
                                       </ColumnGroups> 
                                    <Columns>                                           
                                            <telerik:GridBoundColumn DataField="IdComponente" UniqueName="IdComponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Display="false"></telerik:GridBoundColumn>	                                                                           
                                            <telerik:GridBoundColumn DataField="Componente" UniqueName="Componente" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Componente">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Subcomponente">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Producto" UniqueName="Producto" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actividad">
                                                <HeaderStyle Width="200px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="mes" UniqueName="mes" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Cuatrimestre">
                                                <HeaderStyle Width="200px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha<br/>Actualización" HeaderText="Fecha" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Right" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="UM1A" UniqueName="UM1A" HeaderText="UM1" AllowFiltering="false" ColumnGroupName="UM">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="UM2A" UniqueName="UM2A" HeaderText="UM2" AllowFiltering="false" ColumnGroupName="UM">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="UM3A" UniqueName="UM3A" HeaderText="UM3" AllowFiltering="false" ColumnGroupName="UM">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="UM1AC" UniqueName="UM1AC" HeaderText="UM1" AllowFiltering="false" ColumnGroupName="UM1">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="#ff0066" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="UM2AC" UniqueName="UM2AC" HeaderText="UM2" AllowFiltering="false" ColumnGroupName="UM1">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="#ff0066" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="UM3AC" UniqueName="UM3AC" HeaderText="UM3" AllowFiltering="false" ColumnGroupName="UM1">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Bold="true" Font-Size="8" ForeColor="#ff0066" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                          	                                                                                                                                                                                                                                                                                                                                                                                                                   
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                               <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="RespuestaAct" runat="server" ForeColor="Red" Font-Bold="true" Text="- No tiene Modificaciones -" Font-Size="15"/></td></tr>
                                </table> 
                              </ContentTemplate> 
                            </asp:UpdatePanel>  
                          </div>
                    </div> 
                 </li>
             </ul> 
         </div>
    </div>     
</asp:Content>
