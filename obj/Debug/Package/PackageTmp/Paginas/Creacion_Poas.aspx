<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Creacion_Poas.aspx.cs" Inherits="PlanificacionPOA.Paginas.Creacion_Poas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">   
    <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>  
     <div class="page-header card">
         <div class="card-block">
             <h5 class="m-b-10">Mantenimientos de Sistema</h5>
              <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
            <p class="text-muted m-b-10">En este apartado se creaaran los Poa's que se utilizan en el sistema de planificación</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                     <telerik:RadWindow  runat="server" ID="ExportarEx" Skin="Office2007" Behaviors="Close,Move" Modal="true"></telerik:RadWindow> 
                      <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-th-list" style="font-size:12px;"></span>                                  
                                  &nbsp;&nbsp;<asp:Label ID="L36" runat="server" Font-Bold="true" Text="Poa's Creados" Font-Size="10"/></div>
                          <div class="panel-body">
                               <table style="border-collapse:separate;border-spacing: 10px;">
                               <tr>
                                 <td><asp:LinkButton ID="NuevoPOA" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-plus-sign"></span>&nbsp;Agregar Nuevo POA</asp:LinkButton></td>
                               </tr>
                              </table>
                              <table style="margin:auto;border-collapse:separate;border-spacing: 10px;" id="insertarpoASS" runat="server"> 
                                  <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Tipo de POA:</label></td></tr>
                                   <tr>
                                      <td><telerik:RadComboBox ID="CboTipoPoa" runat="server" EmptyMessage="Seleccione Tipo POA" Width="400px"></telerik:RadComboBox></td>
                                   </tr>
                                   <tr style="font-family:Arial;font-size:13px; font-weight:bold;"> <td><label for="Label2">Descripción del POA:</label></td></tr>
                                    <tr id="Verificar" runat="server" visible="false" style="font-family:Arial;font-size:13px; font-weight:bold;color:red;" ><td><label for="Label2">*Solo este Campo Puede Editar</label></td></tr>
                                   <tr>
                                      <td><asp:TextBox ID="DescipcionPOA" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
                                   </tr>                                  
                                   <tr style="font-family:Arial;font-size:13px; font-weight:bold;"><td><label for="Label2">Año Correspondiente del POA:</label></td></tr>
                                   <tr>
                                      <td><telerik:RadNumericTextBox ID="AnioCorrespodiente" runat="server" Skin="MetroTouch" style="text-align:right" onkeydown="return (event.keyCode!=13);" Value="0" Width="400px"><NumberFormat DecimalDigits="0" /></telerik:RadNumericTextBox></td>
                                   </tr>
                                   <tr>
                                      <td>
                                        <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">
                                        <tr>
                                           <td><asp:LinkButton ID="GuardarPOA" runat="server" CssClass="btn btn-success btn-sm" Text="Guardar"><span class="glyphicon glyphicon-floppy-saved"></span>&nbsp;Guardar POA</asp:LinkButton></td>
                                           <td><asp:LinkButton ID="CancelarPOA" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                        </tr>
                                       </table> 
                                     </td>                                                                         
                                   </tr>
                               </table>                                
                               <telerik:RadGrid runat="server" ID="GridPOASSistema" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="15" 
                                   DataKeyNames="Id_PoAnual,Id_Poa,POA,Descripcion_POA,Estado_PoAnual,Estado,Anio,IniciarTarea,Inicios" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                
                                    <telerik:GridButtonColumn Text="Eliminar el Informe POA" CommandName="Delete" UniqueName="BotonX" HeaderText="Eliminar<br/>POA" ButtonType="ImageButton" ButtonCssClass="imageButtonClass" 
                                        ImageUrl="../Iconos/Eliminar.png" ConfirmText="Desea eliminar el POA?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar POA">
                                     <HeaderStyle Width="1px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" Width="1px"  /> 
                                    </telerik:GridButtonColumn> 
                                   <telerik:GridButtonColumn Text="Activar/Desactivar POA" HeaderText="Activar<br/>Desactivar" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" HeaderStyle-Width="20px" ImageUrl="../Iconos/on.png" ButtonCssClass="imageButtonClass">
                                      <HeaderStyle Width="10px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                   </telerik:GridButtonColumn> 
                                   <telerik:GridButtonColumn Text="Editar los datos del Poa" HeaderText="Edición" CommandName="Select1" UniqueName="BotonB"  ButtonType="ImageButton" ImageUrl="../Iconos/editarI.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                      <telerik:GridBoundColumn DataField="IniciarTarea" UniqueName="IniciarTarea" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Poa" UniqueName="Id_Poa" Visible="false"></telerik:GridBoundColumn>                                                                                                                                                   
                                      <telerik:GridBoundColumn DataField="POA" UniqueName="POA" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Tipo de POA">
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Anio" UniqueName="Anio" HeaderText="Año Que<br/> Corresponde" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                          <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>      
                                      <telerik:GridBoundColumn DataField="Descripcion_POA" UniqueName="Descripcion_POA" HeaderText="Descripción<br/>del POA" AllowFiltering="false">
                                          <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                    
                                        <telerik:GridBoundColumn DataField="Estado"  UniqueName="Estado" HeaderText="Estado" AllowFiltering="false">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="Inicios"  UniqueName="Inicios" HeaderText="Tarea" AllowFiltering="false">
                                           <HeaderStyle Width="60px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                     <telerik:GridButtonColumn Text="Cargar Productos Regionales (Actividades)" HeaderText="Actividades<br/>SubRegionales" CommandName="Select2" UniqueName="BotonC"  ButtonType="ImageButton" ImageUrl="../Iconos/descarga.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                      <telerik:GridButtonColumn Text="Exportar la información del poa a un formato de Excel" HeaderText="Descargar<br/>Formato Poa" CommandName="Select3" UniqueName="BotonD"  ButtonType="ImageButton" ImageUrl="../Iconos/excel.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                      <telerik:GridButtonColumn Text="Iniciar Tareas" HeaderText="Inicio de<br/>POA" CommandName="Select4" UniqueName="BotonE"  ButtonType="ImageButton" ImageUrl="../Iconos/InicioTarea.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                     <telerik:GridButtonColumn Text="Realiza una Replica de POA del año anterior" HeaderText="Replica<br/>de POA" CommandName="Select5" UniqueName="BotonF"  ButtonType="ImageButton" ImageUrl="../Iconos/copiar.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
                                     <telerik:GridButtonColumn Text="Reprogramación POA" HeaderText="Reprogramación<br/>POA Anual" CommandName="Select6" UniqueName="BotonG" ButtonType="ImageButton" ImageUrl="../Iconos/Reprogramar.png" ButtonCssClass="imageButtonClass">
                                    <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn> 
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
                    <telerik:RadWindow runat="server" Modal="true" ID="InicioTareas" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                 <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-cog"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Mantenimiento POA" Font-Size="10"/></div></div>
                        <div class="panel-body">                        
                           <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">
                            <tr style="text-align:center"><td><label for="Label2">Fecha final entrega POA</label></td> </tr>
                            <tr> <td><telerik:RadDatePicker ID="txtFechaEntrega" runat="server" Width="300px" onkeydown="return (event.keyCode!=13);" Skin="MetroTouch"></telerik:RadDatePicker></td></tr>
                           </table>
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">
                                 <tr style="text-align:center"><td><label for="Label2">Instrucciónes</label></td> </tr>
                                <tr><td><asp:TextBox ID="txtInstrucciones" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                                                                         
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="GuardarTarea" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Enviar Tarea</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CancelarTarea" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar</asp:LinkButton></td>  
                                </tr>                                                           
                                </table>
                             </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow>             
         </div> 
     </div> 
    <telerik:RadAjaxManagerProxy ID="RadAjaxManager1" runat="server">      
    <AjaxSettings> 
         <telerik:AjaxSetting AjaxControlID="GridPOASSistema">
            <UpdatedControls>               
                <telerik:AjaxUpdatedControl ControlID="GridPOASSistema" LoadingPanelID="RadAjaxLoadingPanel1" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings> 
    </telerik:RadAjaxManagerProxy>     
</asp:Content>
