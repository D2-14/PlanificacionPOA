<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="RevisionDeMetas.aspx.cs" Inherits="PlanificacionPOA.Paginas.RevisionDeMetas" %>
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
             <h5 class="m-b-10">Revisión de Metas SubRegionales</h5>
                   <p class="text-muted m-b-10">En este Apartado el Director Regional puede revisar la metas ingresadas por las direcciones subregionales que tiene a su cargo</p>
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
                                   DataKeyNames="Id_PoAnual,FechaDeAsignacion,POA,FechaDeEntrega,EstadoDeAsignacion,Id_Region,Id_Subregion,IdMensaje,Asignado,Instrucciones,Nombre_SubRegion,TipoAsignacion,NoReprogramacion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="IdMensaje" UniqueName="IdMensaje" Visible="false"></telerik:GridBoundColumn>
                                      <telerik:GridBoundColumn DataField="Id_Region" UniqueName="Id_Region" Display="false"></telerik:GridBoundColumn>   
                                      <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Visible="false"></telerik:GridBoundColumn>                                         
                                       <telerik:GridBoundColumn DataField="Asignado" UniqueName="Asignado" Visible="false"></telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="TipoAsignacion" UniqueName="TipoAsignacion" Visible="false"></telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="NoReprogramacion" UniqueName="NoReprogramacion" Visible="false"></telerik:GridBoundColumn> 
                                      <telerik:GridBoundColumn DataField="Instrucciones" UniqueName="Instrucciones" Visible="false"></telerik:GridBoundColumn> 
                                      <telerik:GridButtonColumn Text="ver Metas de la subregión" HeaderText="Visualizar<br/>Metas" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" ImageUrl="../Iconos/lupaG.png" ButtonCssClass="imageButtonClass">
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
                                      <telerik:GridButtonColumn Text="Mensaje de la subregion" HeaderText="Mensaje" CommandName="Select1" UniqueName="BotonB" ButtonType="ImageButton" ImageUrl="../Iconos/mensaje.png" ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>
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
                                        <%-- AGREGAR DOCUMENTO EXCEL PORA DESCARGAR POA --%>
                                         <telerik:GridButtonColumn Text="Aprobar las Metas de la subregión" HeaderText="Aprobar<br/>Metas" CommandName="Select2" UniqueName="BotonC" 
                                         ButtonType="ImageButton" ImageUrl="../Iconos/Aprobar.png" ButtonCssClass="imageButtonClass" ConfirmText="Esta Seguro de aprobar las metas?" ConfirmDialogType="RadWindow" ConfirmTitle="Aprobar Metas">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="10" Font-Names="Arial"/>
                                     <ItemStyle HorizontalAlign="Center"/>
                                    </telerik:GridButtonColumn>
                                    <telerik:GridButtonColumn Text="Denegar las Metas de la subregión" HeaderText="Denegar<br/>Metas" CommandName="Select3" UniqueName="BotonD" 
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
                            <div id="ApartadodeMetas" runat="server" visible="false">
                                 <table style="margin:auto;border-collapse:separate;border-spacing: 10px;text-align:center;"> 
                                <tr><td><asp:Label ID="T01" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#0066cc"/></td></tr>
                                <tr><td><asp:Label ID="T02" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#cc0000"/></td></tr>
                            </table> 
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                               <tr>
                                   <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Regresar al modulo anterior"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>
                                   <td><asp:LinkButton ID="VerificarCambios" runat="server" CssClass="btn btn-warning btn-sm" ToolTip="Verificar Cambios POA"  Text="Guardar"><span class="glyphicon glyphicon-search"></span>&nbsp;Verficar Cambios POA</asp:LinkButton></td>    
                               </tr>
                            </table><br/> 
                             <table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                 <td><label for="Label2">Componente:</label></td> 
                                 <td><telerik:RadComboBox ID="CboComponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Componente" Width="400px" Height="280"></telerik:RadComboBox></td>
                               </tr>
                               <tr>
                                 <td><label for="Label2">Subcomponente:</label></td>  
                                 <td><telerik:RadComboBox ID="CboSubcomponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Subcomponente" DropDownWidth="400" Width="400px" Height="280"></telerik:RadComboBox></td>  
                               </tr>
                            </table><br />
                                   <telerik:RadGrid runat="server" ID="GdrDatosdeActividades" AutoGenerateColumns="False" Width="100%" 
                                                    AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" GridLines="Both" 
                                                    Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">                                   
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="20" EnableHeaderContextMenu="true"
                                   DataKeyNames="Id_Componente,Id_SubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,Id_MetasRedProgramatica,Id_NoPlanificable,
                                                 Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,PtUM1,PtUM2,PtUM3,
                                                 StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                  
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="PC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="SC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="TC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Consolidado de Meta Anual" Name="CMA">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                       </ColumnGroups> 
                                    <Columns>                                                                        
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_SubComponente" UniqueName="Id_SubComponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_MetasRedProgramatica" UniqueName="Id_MetasRedProgramatica" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_NoPlanificable" UniqueName="Id_NoPlanificable" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UnidadMedida" UniqueName="Id_UnidadMedida" Display="false"></telerik:GridBoundColumn>                                                                                    	                                        
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains" HeaderText="Actvidades">
                                                <HeaderStyle Width="100%" Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1" AllowFiltering="false" >
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
                                            <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="PC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="PC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="PC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="SC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="SC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="SC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="TC" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="TC" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="TC" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2" AllowFiltering="false">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3" AllowFiltering="false">
                                                  <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                         
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
                                 <div id="Respuesta2" runat="server" visible="false" >
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="RespuestaAct" runat="server" ForeColor="Red" Font-Bold="true" Text="- No Hay Información -" Font-Size="15"/></td></tr>
                                </table> 
                                </div>
                                    <div id="CambiosPOA" runat="server" visible="false"><hr />
                                    <table style="margin:auto;border-collapse:separate;border-spacing: 10px;"> 
                                    <tr><td><asp:Label ID="Label3" runat="server" ForeColor="Red" Font-Bold="true" Text="Consulta de Cambios en valores UM" Font-Size="15"/></td></tr>
                                </table> 
                                    <table>
                                        <tr>
                                            <td><asp:LinkButton ID="btncerrar" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="cerrar consulta"  Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana Cambios</asp:LinkButton><br /></td>                                        
                                        </tr>
                                    </table>                                     
                                   <telerik:RadGrid runat="server" ID="GdrCambios" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                          
                                     </ClientSettings>
                                   <MasterTableView PageSize="5" 
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
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha<br/>Actualización" HeaderText="fecha" FilterControlWidth="100%" 
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
                                </div>
                            </div> 
                        </ContentTemplate>
                        </asp:UpdatePanel> 
                      <div id="exp" style="text-align:center;"><br /><asp:LinkButton ID="btnXLS" runat="server" CssClass="btn btn-info btn-sm" ToolTip="exporta a excel"  Text="Guardar"><span class="glyphicon glyphicon-download-alt"></span>&nbsp;Exportar a Excel</asp:LinkButton></div> 
                       <telerik:RadWindow runat="server" Modal="true" ID="MensajeObserva" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Observaciones de Ingreso de metas" Font-Size="10"/></div></div>
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
                   <telerik:RadWindow runat="server" Modal="true" ID="VerIngresos" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="true" Text="Metas Ingresadas a la Actividad" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                               
                                <tr><td>
                                    <telerik:RadGrid runat="server" ID="GridUnidades" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="12" 
                                   DataKeyNames="Id_mes,Descripcion_Mes,Meta_UM1,Meta_UM2,Meta_UM3" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>                                                                             
                                      <telerik:GridBoundColumn DataField="Id_mes" UniqueName="Id_mes" Visible="false"></telerik:GridBoundColumn>                                                            
                                        <telerik:GridBoundColumn DataField="Descripcion_Mes" UniqueName="Descripcion_Mes" HeaderText="Mes">
                                          <HeaderStyle Width="100px" Font-Size="9" HorizontalAlign="Center" Font-Names="Arial"/>
                                          <ItemStyle HorizontalAlign="Left" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                            
                                        <telerik:GridBoundColumn DataField="Meta_UM1"  UniqueName="Meta_UM1" HeaderText="UM1">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="Meta_UM2"  UniqueName="Meta_UM2" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                    </telerik:GridBoundColumn> 
                                    <telerik:GridBoundColumn DataField="Meta_UM3"  UniqueName="Meta_UM3" HeaderText="UM2">
                                           <HeaderStyle Width="70px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                           <ItemStyle HorizontalAlign="Right" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
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
                   <telerik:RadWindow runat="server" Modal="true" ID="DenegarMetas" Skin="Office2007" Behaviors="Move" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-envelope"></span>&nbsp;&nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Observación de Denegación" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing: 5px;">                               
                                <tr><td><asp:TextBox ID="txtmensajeDenegado" Font-Names="Arial" Font-Size="9" runat="server" class="form-control" Width="400px" Height="130px" TextMode="MultiLine"></asp:TextBox></td></tr>
                            </table>                                                                         
                                <table style="margin:auto;border-collapse:separate;border-spacing: 10px;">               
                                <tr style="text-align:center">                    
                                <td><asp:LinkButton ID="btnDenegar" runat="server" CssClass="btn btn-info btn-sm" Text="Guardar"><span class="glyphicon glyphicon-send"></span>&nbsp;Denegar Metas</asp:LinkButton></td>
                                <td><asp:LinkButton ID="CerrarVentanaDenegar" runat="server" CssClass="btn btn-danger btn-sm" Text="Guardar"><span class="glyphicon glyphicon-remove"></span>&nbsp;Cerrar Ventana</asp:LinkButton></td>  
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
