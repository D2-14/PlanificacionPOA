<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="Tarea_Monitoreo.aspx.cs" Inherits="PlanificacionPOA.Paginas.Tarea_Monitoreo" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <telerik:radwindowmanager ID="RadWindowManager1" runat="server" RenderMode="Classic" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>  
     <div class="page-header card">
         <div class="card-block">
             <h5 class="m-b-10">Envio de Tarea para Ingreso de Metas Mensuales (Monitoreo y Seguimiento)</h5>
              <center><h3 class="m-b-10">Sistema de Planificación, Evaluación y Seguimiento Institucional</h3></center>
            <p class="text-muted m-b-10">En este apartado se podra enviar la tarea a las Regiones, Direcciones para que ingresen sus metas del POA</p><br />
            <ul class="breadcrumb-title b-t-default p-t-10"/>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                      <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;"><span class="glyphicon glyphicon-th-list" style="font-size:12px;"></span>                                  
                      &nbsp;&nbsp;<asp:Label ID="L36" runat="server" Font-Bold="true" Text="Poa's en el Sistema" Font-Size="10"/></div>
                          <div class="panel-body">
                               <telerik:RadGrid runat="server" ID="GridPOASSistema" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" AllowMultiRowSelection="False">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="15" 
                                   DataKeyNames="Id_PoAnual,Id_Poa,POA,Descripcion_POA,Estado_PoAnual,Anio,IniciarTarea" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                                                                                        
                                      <telerik:GridBoundColumn DataField="IniciarTarea" UniqueName="IniciarTarea" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Poa" UniqueName="Id_Poa" Visible="false"></telerik:GridBoundColumn>                                                                                                                                                   
                                      <telerik:GridBoundColumn DataField="POA" UniqueName="POA" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Descripcion del POA">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Anio" UniqueName="Anio" HeaderText="Año que Corresponde el Poa" FilterControlWidth="100%" AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                          <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                                                                                              
                                      <telerik:GridButtonColumn Text="Iniciar Tareas" HeaderText="Iniciar Tarea" CommandName="Select" UniqueName="BotonA"  ButtonType="ImageButton" ImageUrl="../Iconos/InicioTarea.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="100px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
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
        </div>
   </div>
    <telerik:RadWindow runat="server" Modal="true" ID="VerTareasEnviadas" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Tareas Enviadas" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                               
                                <tr><td>
                                    <telerik:RadGrid runat="server" ID="TaresEnviadas" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="12" 
                                   DataKeyNames="Id_meses,Descripcion_Mes,Estado,FechaInicial,FechaInicial,FechaEnvio" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_meses" Visible="false"></telerik:GridBoundColumn>                                                            
                                        <telerik:GridBoundColumn DataField="Descripcion_Mes" HeaderText="Mes de Tarea">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Estado" HeaderText="Estado de Tarea">
                                           <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="FechaEnvio" HeaderText="Fecha de Envio de Tarea">
                                           <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="FechaInicial" HeaderText="Fecha de Inicio de Tarea">
                                           <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="FechaInicial" HeaderText="Fecha Final de Tarea">
                                           <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Center" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn>                                                                         
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>                                
                               </td></tr>
                            </table>                                                                                                        
                        </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow> 
<telerik:RadWindow runat="server" Modal="true" ID="InicioTareas" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                 <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-cog"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Envio de Tarea de Ingreso de Metas" Font-Size="10"/></div></div>
                        <div class="panel-body">                        
                           <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">
                               <tr  style="text-align:center"><td colspan="2"><label for="Label2">Mes que se ejecuta la Tarea</label></td></tr>
                              <tr><td colspan="2" style="text-align:center"><telerik:RadComboBox ID="CboMeses" runat="server" EmptyMessage="Seleccione el Mes" Width="400px" Skin="Silk" Filter="Contains"></telerik:RadComboBox></td></tr>
                            <tr style="text-align:center;">                               
                                <td><label for="Label2">Fecha que Termina la Tarea</label></td> 
                            </tr>
                            <tr>                                                                
                                <td><telerik:RadDatePicker ID="txtFechaFinal" runat="server" Width="400px" onkeydown="return (event.keyCode!=13);" Skin="Silk" VerticalContentAlignment="Center">

                                    </telerik:RadDatePicker></td>
                            </tr>                             
                           </table>
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">
                                 <tr style="text-align:center"><td><label for="Label2">Instrucciónes</label></td> </tr>
                                <tr><td><asp:TextBox ID="txtInstrucciones" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                                                                         
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="GuardarTarea" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Enviar Tarea</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CancelarTarea" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Envio</asp:LinkButton></td>  
                                </tr>                                                           
                                </table>
                             </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow>    
</asp:Content>
