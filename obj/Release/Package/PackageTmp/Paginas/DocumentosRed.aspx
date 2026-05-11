<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="DocumentosRed.aspx.cs" Inherits="PlanificacionPOA.Paginas.DocumentosRed" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Login_Css/Copiar.css" rel="stylesheet" />
    <div class="page-header card">
        <div class="card-block">
               <h5 class="m-b-10">Cargar Documentos PDF al sistema</h5>
                   <p class="text-muted m-b-10">En este apartado se podra subir documentacion en formato pdf, así como visualizarlos y descargarlos</p>
                     <ul class="breadcrumb-title b-t-default p-t-10">
                        <li>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>                                                           
                                <table runat="server" id="Table1" style="margin:auto;border-collapse:separate;border-spacing: 2px;"> 
                                <tr><td>  
                               <div id="Permisos" runat="server">
                              <div class="panel panel-success">                        
                              <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-open-file" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Text="Cargar Documentos al Sistema" Font-Size="10"/></div>
                             <div class="panel-body">
                                 <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;">
                                    <tr style="font-family:Arial;font-size:13px;font-weight:bold;">
                                      <td ><label for="Label2">Adjuntar Documento</label></td>                                                
                                    </tr>
                                     <tr>
                                         <td><telerik:RadAsyncUpload runat="server" ID="RadAcuerdoConvenio" Culture="es-GT" MaxFileInputsCount="1"
                                         Skin="MetroTouch" AllowedFileExtensions=".pdf" Width="280px" ChunkSize="0" DropZones=".DropZone1"></telerik:RadAsyncUpload></td> 
                                     </tr>
                                 </table> 
                                     <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center">                                                                                                                                                                                                                                                                                                         
                                          <tr><td><div class="DropZone1"><br /><p>Arrastre su Archivo</p><p>en Formato PDF Aquí</p></div></td></tr>
                                     </table>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                                 <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;">
                                     <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del Documento</label></td></tr>
                                     <tr><td><asp:TextBox ID="DescripcionDocumento" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox></td></tr>
                                 </table> 
                              <table style="margin:auto;border-collapse:separate;border-spacing:10px;">
                                <tr>
                                   <td> <asp:LinkButton ID="AgregarDocumento" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar">
                                   <span class="glyphicon glyphicon-import"></span>&nbsp;Cargar Documento al Sistema</asp:LinkButton></td>
                                </tr>        
                             </table>                                   
                            </div></div> 
                                </div>
                                 <div class="panel panel-danger">                        
                              <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-inbox" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Documentos Cargados al Sistema" Font-Size="10"/></div>                             
                               <table style="margin:auto;border-collapse:separate;border-spacing:10px;">
                                  <tr><td>
                                       <telerik:RadGrid runat="server" ID="GridDocumentos" AutoGenerateColumns="False" Width="100%" RenderMode="Lightweight"  
                                        AllowSorting ="False" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" Culture="es-GT" Skin="Office2007"   
                                        ShowStatusBar ="True" ShowGroupPanel="false">
                                        <GroupingSettings CaseSensitive="False" />
                                        <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                        <Selecting AllowRowSelect="True"></Selecting>                                      
                                        </ClientSettings>
                                        <MasterTableView PageSize="10" 
                                          DataKeyNames="Id,Descripcion,Enlace_del_Documento,NombreArchivo" NoMasterRecordsText="Sin Información">
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                        <Columns>
                                          <telerik:GridButtonColumn Text="Eliminar el Documento" CommandName="Delete" UniqueName="BotonX" HeaderText="Eliminar<br/>Documento" ButtonType="ImageButton" ButtonCssClass="imageButtonClass" 
                                                ImageUrl="../Iconos/Eliminar.png" ConfirmText="Desea eliminar el Documento?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar DocumentoPOA">
                                                <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                              <ItemStyle HorizontalAlign="Center"/></telerik:GridButtonColumn>                                          
                                         <telerik:GridBoundColumn DataField="Id" UniqueName="Id" Visible="false"></telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="Descripcion"  UniqueName="Descripcion" HeaderText="Descripción del Documento" AllowFiltering="false">
                                         <HeaderStyle Width="250px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                         <ItemStyle HorizontalAlign="Justify"  Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                        </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="NombreArchivo" UniqueName="NombreArchivo" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Nombre del Documento">
                                           <HeaderStyle Width="250px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                         <ItemStyle HorizontalAlign="Justify"  Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>   
                                         </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Enlace_del_Documento" UniqueName="Enlace_del_Documento" Display="false"></telerik:GridBoundColumn>
                                           <telerik:GridButtonColumn Text="Ver Documento"  CommandName="Select" HeaderText="Ver<br/>Documento" UniqueName="BotonA"  ButtonType="ImageButton" ImageUrl="../Iconos/LupaG.png" ButtonCssClass="imageButtonClass">
                                          <HeaderStyle Width="20px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                               <ItemStyle HorizontalAlign="Center"/>
                                         </telerik:GridButtonColumn>                                  
                                        </Columns>
                                     </MasterTableView>
                                          <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                           {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                           &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                                        </telerik:RadGrid>
                                    </td></tr>
                                </table>
                                     <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="RespuestaAct" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Hay Documentos Cargados al Sistema -" Font-Size="15"/></td></tr>
                                </table> 
                                     </div> 
                           </td></tr>
                            </table>                                                      
                                </ContentTemplate>
                           </asp:UpdatePanel>
                         </li>
                      </ul>
            </div> 
        </div> 
    <telerik:RadWindow  runat="server" Modal="true" ID="visualizar" Skin="Office2007" Behaviors="Move,Maximize" Left="980px" Top="2px" ReloadOnShow="true">
        <ContentTemplate>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="panel panel-primary">
                         <div class="panel-heading"><asp:LinkButton ID="CerraVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></div>
                        </div>                         
                        <iframe id="viewer" runat="server" frameborder="0" scrolling="no"  style="width:100%;height:800px;"></iframe>                                         
                </ContentTemplate> 
                </asp:UpdatePanel>                        
            </ContentTemplate> 
         </telerik:RadWindow> 
</asp:Content>
