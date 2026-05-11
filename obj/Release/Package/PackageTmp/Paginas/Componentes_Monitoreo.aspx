<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Componentes_Monitoreo.aspx.cs" Inherits="PlanificacionPOA.Paginas.Componentes_Monitoreo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server"> 
     <telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager> 
     <div class="page-header card">
         <div class="card-block">
             <h5 class="m-b-10">COMPONENTES(Monitoreo y Seguimiento)</h5>
              <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
            <p class="text-muted m-b-10">En este apartado podra seleccionar los Componentes que integran los Poa's Regionales, para que ingrese los datos a la
                medidas UM y sus medios de verificación</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>                      
                      <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-list-alt" style="font-size:12px;"></span>                                  
                            &nbsp;&nbsp;<asp:Label ID="L36" runat="server" Font-Bold="true" Text="COMPONENTES DEL POA REGIONALES" Font-Size="10"/></div>
                          <div class="panel-body">
                              <table style="border-collapse:separate;border-spacing:10px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                    <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-success btn-sm" ToolTip="Regresar al modulo anterior" Text="Guardar">
                                    <span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Módulo Anterior (Tarea Monitoreo SubRegional)</asp:LinkButton></td>
                                    <td><asp:LinkButton ID="FinalizarIngreso" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Finalizar el Ingreso de las Metas" Text="Guardar">
                                    <span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Finalizar Ingreso de Información</asp:LinkButton></td>
                                </tr>
                            </table>
                                <telerik:RadGrid runat="server" ID="GridProductos" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="8" 
                                   DataKeyNames="IdComponente,Descripcion_Componente,Proceso" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns> 
                                      <telerik:GridButtonColumn Text="Seleccionar Producto para ingresar Metas" HeaderText="Seleccionar Producto" CommandName="Select" 
                                          UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/grifo.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="150px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>                                         
                                      <telerik:GridBoundColumn DataField="IdComponente" UniqueName="IdComponente" Visible="false"></telerik:GridBoundColumn>                                                                                                                                                                                    
                                      <telerik:GridBoundColumn DataField="Descripcion_Componente" UniqueName="Descripcion_Componente" FilterControlWidth="100%" 
                                          AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="DESCRIPCIÓN DEL COMPONENTE REGIONAL">
                                          <HeaderStyle Font-Size="11" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>     
                                     <telerik:GridBoundColumn DataField="Proceso" UniqueName="Proceso" AutoPostBackOnFilter="true" AllowFiltering="false" HeaderText="ESTADO DEL INGRESO DE INFORMACIÓN">
                                          <HeaderStyle Font-Size="11" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true" Width="200px" />
                                          <ItemStyle HorizontalAlign="Center" Font-Size="10" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
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
             </div>
         </div>
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
                            <asp:Label ID="lblConfirm" Font-Size="14px" Text="Desea FInalizar el ingreso de Información de la subregión"
                                runat="server"></asp:Label>
                            <br />
                            <br />
                            </div>
                           <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                                   
                                <td><asp:LinkButton ID="btnIrConfiguracion" runat="server" CssClass="btn btn-warning btn-sm" Text="Guardar"><span class="glyphicon glyphicon-ok"></span>&nbsp;Aceptar</asp:LinkButton></td>                                  
                                    <td><asp:LinkButton ID="btnCerrarVentana" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>   
                                </tr>                                                           
                          </table>                       
                    </div>
                      </ContentTemplate>
                </asp:UpdatePanel>
                </ContentTemplate>
            </telerik:RadWindow>
</asp:Content>
