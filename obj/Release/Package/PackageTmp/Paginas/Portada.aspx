<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Portada.aspx.cs" Inherits="PlanificacionPOA.Paginas.Portada" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            $find('<%=RadImagen.ClientID%>').playSlideshow();
        }
    </script>
    <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
    <table id="Pendiente" runat="server" style="font-family:Arial;font-size:13px;font-weight:bold;">
        <tr>
            <td><asp:ImageButton ID="ImageBNotifica" runat="server" Width="70px" ToolTip="Tiene Tareas Pendientes que Revisar"/></td>
            <td><label for="Label2">Tiene Tarea<br />Pendiente</label></td>
        </tr>
    </table>    
     <div class="page-header card">         
        <div class="card-block">
             <h5 class="m-b-10">Portada</h5>            
           <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
                     <ul class="breadcrumb-title b-t-default p-t-10"/>
                <div class="container-fluid">
                     <telerik:RadWindow  runat="server" RenderMode="Classic" ID="VerNotificacion" Skin="Office2007" Behaviors="Close,Move" Modal="true"></telerik:RadWindow>                   
                     <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                    <div class="demo-container size-wide" style="margin:auto;width:800px;">
                        <telerik:RadImageGallery runat="server" ID="RadImagen" OnNeedDataSource="RadImagen_NeedDataSource" LoopItems="true"
                         DataDescriptionField="Descripcion" DataImageField="Urlimagen" Culture="es-GT" Skin="Black" AllowPaging="True" 
                         RenderMode="Lightweight" ShowLoadingPanel="True">
                            <ImageAreaSettings ResizeMode="Fill" />
                        <ClientSettings>                           
                            <AnimationSettings SlideshowSlideDuration="3000">
                                <NextImagesAnimation Type="VerticalSlide" Speed="2500"/>
                                <PrevImagesAnimation Type="VerticalSlide" Speed="2500"/>
                            </AnimationSettings>
                        </ClientSettings>
                       </telerik:RadImageGallery>
                     </div> 
                    </ContentTemplate> 
                   </asp:UpdatePanel> 
                </div><br />                                                           
             <ul class="breadcrumb-title b-t-default p-t-10"/>
            </div> 
         </div>       
       <telerik:RadWindow  runat="server" Modal="true" ID="VentanaDeNotificacion" Skin="Office2007" Behaviors="Move,Close" Left="950px" Top="2px" ReloadOnShow="true">
        <ContentTemplate>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                     <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;">
                               <tabla style="margin:auto;border-collapse:separate;border-spacing:10px;font-family:Arial;font-size:13px;font-weight:bold;">                                  
                                   <tr>                                            
                                      <td>
                                          <span class="glyphicon glyphicon-inbox" style="font-size:12px;"></span><br />
                                         <img src="../Imagenes/CampanaNotifica.jpg" style="width:40px;"/>&nbsp;&nbsp;&nbsp;
                                         <asp:Label ID="L1" runat="server" Font-Bold="true" Text="INSTITUTO NACIONAL DE BOSQUES -INAB-" Font-Size="10"/>
                                           &nbsp;&nbsp;&nbsp;<img src="../Imagenes/CampanaNotifica.jpg" style="width:40px;"/><br />
                                         <asp:Label ID="L2" runat="server" Font-Bold="true" Font-Size="10" Text="Notificaciones Del Sistema" />                                         
                                       </td>
                                  </tr>                                                                                                                        
                               </tabla>                               
                           </div>
                           <div class="panel-body">  
                                <telerik:RadGrid runat="server" ID="GridNotificacion" AutoGenerateColumns="False" Width="100%" AllowSorting ="True" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                     <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Descripcion,Urls,Cantidad,Permiso" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Seleccionar, ir a las Tareas Asignadas" CommandName="Select" ButtonType="ImageButton" 
                                            ImageUrl="../Iconos/Seleccionar.png" HeaderText="Seleccionar" ButtonCssClass="imageButtonClass">                              
                                        <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" ForeColor="Red"/>
                                        <ItemStyle  HorizontalAlign="Center"/> 
                                        </telerik:GridButtonColumn> 
                                        <telerik:GridBoundColumn DataField="Permiso" UniqueName="Permiso" Display="false"></telerik:GridBoundColumn> 
                                      <telerik:GridBoundColumn DataField="Urls" UniqueName="Urls" Display="false"></telerik:GridBoundColumn>                                          
                                      <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" AllowFiltering="false"  HeaderText="Descripción de Tarea">
                                          <HeaderStyle Width="200px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Cantidad" UniqueName="Cantidad" AllowFiltering="false"  HeaderText="Cantidad">
                                          <HeaderStyle Width="80px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Right" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>
                           </div> 
                     </div> 
               </ContentTemplate> 
           </asp:UpdatePanel> 
       </ContentTemplate> 
     </telerik:RadWindow>
    <telerik:RadWindow runat="server" Modal="true" ID="FaltanDias" Skin="Office2007" Behaviors="Move" Left="950px" Top="2px" ReloadOnShow="true">
        <ContentTemplate>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                     <div class="panel panel-success">
                           <div class="panel-heading"></div>
                               <table style="margin:auto;border-collapse:separate;border-spacing: 20px;text-align:center;">                                   
                                   <tr><td><img src="../Imagenes/comunicado.gif" width="450" height="200"/></td></tr>
                                   <tr><td><asp:Label ID="MensajeDias" runat="server" ForeColor="Red" Font-Bold="true" Font-Size="15"/></td></tr>
                                   <tr><td><asp:LinkButton ID="CerrarVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton> </td></tr>
                               </table>                                                                                                                      
                     </div> 
               </ContentTemplate> 
           </asp:UpdatePanel> 
       </ContentTemplate> 
     </telerik:RadWindow>     
</asp:Content>
