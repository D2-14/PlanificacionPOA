<%@ Page Title="" Language="C#" MasterPageFile="~/MarcoTrabajo/Site.Master" AutoEventWireup="true" CodeBehind="X_ConsumoFamiliar.aspx.cs" Inherits="PlanificacionPOA.Paginas.X_ConsumoFamiliar" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<telerik:radwindowmanager ID="RadWindowManager1" runat="server" EnableShadow="true" Skin="Office2007"></telerik:radwindowmanager>
<div class="page-header card">
    <div class="card-block">
         <table style="border-collapse:separate;border-spacing:3px;">
                 <tr>
                     <td>
                          <Table style="border-collapse:separate;border-spacing:3px;">
                              <tr>
                                  <td><asp:Label ID="Label1" runat="server" Font-Bold="true" Text="INGRESO DE METAS SUBREGIONALES* " Font-Size="13" ForeColor="#006699"/></td>
                                  <td><asp:Label ID="lblPoa" runat="server" Font-Bold="true" Font-Size="13" ForeColor="#009933"/></td>
                              </tr>
                          </Table> 
                     </td>                   
                 </tr>
                 <tr>
                     <td>
                         <Table style="border-collapse:separate;border-spacing:3px;">
                             <tr>
                                 <td><asp:Label ID="lbltipoComponente" runat="server" Font-Bold="true" Text="COMPONENTE" Font-Size="11" ForeColor="#006699"/></td>
                                <td><asp:Label ID="lblComponente" runat="server" Font-Bold="true" Font-Size="11" ForeColor="#009933"/></td>
                             </tr>
                         </Table>
                     </td>                                          
                 </tr>
                  <tr>
                      <td>
                        <Table style="border-collapse:separate;border-spacing:3px;">
                         <tr>
                             <td><asp:Label ID="Label2" runat="server" Font-Bold="true" Text="DIRECCIÓN SUBREGIONAL" Font-Size="11" ForeColor="#006699"/></td>
                             <td><asp:Label ID="lbsubregion" runat="server" Font-Bold="true" Font-Size="11" ForeColor="#009933"/></td>
                         </tr> 
                        </Table> 
                      </td>
                  </tr>
                  <tr>
                      <td>
                        <Table style="border-collapse:separate;border-spacing:3px;">
                         <tr>
                             <td><asp:Label ID="Label3" runat="server" Font-Bold="true" Text="MES DE INGRESO" Font-Size="11" ForeColor="#006699"/></td>
                             <td><asp:Label ID="Lblmes" runat="server" Font-Bold="true" Font-Size="11" ForeColor="#009933"/></td>
                         </tr> 
                        </Table> 
                      </td>
                  </tr>
             </table>
             <ul class="breadcrumb-title b-t-default p-t-10"/>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
              <ContentTemplate>
                     <Table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;" id="subcomp" runat="server">
                         <tr>
                             <td>
                             <Table style="border-collapse:separate;border-spacing:5px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                    <td><asp:LinkButton ID="RegresarPantallaanterior" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Regresar al modulo anterior" Text="Guardar">
                                    <span class="glyphicon glyphicon-fast-backward"></span>&nbsp;Regresar Módulo Anterior</asp:LinkButton></td>  
                              <td><asp:LinkButton ID="btnFinalizarIngreso" runat="server" CssClass="btn btn-warning btn-sm" ToolTip="Finalizar ingreso del componente" Text="Guardar" Visible="false">
                                    <span class="glyphicon glyphicon-download-alt"></span>&nbsp;Finalizar Ingreso de Información</asp:LinkButton></td>
                                </tr>
                             </Table>
                            </td>      
                         </tr>
                         <tr><td><label for="Label2">SubComponente:</label></td></tr> 
                         <tr>
                          <td><telerik:RadComboBox ID="CboSubcomponente" Skin="MetroTouch" AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Subcomponente" Width="400px" Height="280"></telerik:RadComboBox></td>                          
                         </tr>                         
                     </Table><br /> 
                        <telerik:RadGrid runat="server" ID="GrdProductos" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="true" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView PageSize="8" 
                                   DataKeyNames="Id_ProductoVeficable,DescripcionProductoVeficable" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                        <telerik:GridButtonColumn Text="Seleccionar el Producto Verificable para ingreso de Información" HeaderText ="Seleccionar" CommandName="Select" UniqueName="BotonA" ButtonType="ImageButton" 
                                                                HeaderStyle-Width="20px" ImageUrl="../Iconos/Aprobar.png" ButtonCssClass="imageButtonClass">
                                            <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                            <ItemStyle HorizontalAlign="Center" /> 
                                      </telerik:GridButtonColumn> 
                                      <telerik:GridBoundColumn DataField="Id_ProductoVeficable" UniqueName="Id_ProductoVeficable" Visible="false"></telerik:GridBoundColumn>                                                                                    
                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Producto Verificable" FilterControlWidth="100%" 
                                                AutoPostBackOnFilter="true" ShowFilterIcon="false" CurrentFilterFunction="Contains">
                                          <HeaderStyle Font-Size="9" HorizontalAlign="Center" Font-Names="Arial" Font-Bold="true"/>
                                          <ItemStyle HorizontalAlign="Justify" Font-Bold="true" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                      </telerik:GridBoundColumn>                                                                                                                                                                                                                                          
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior"  Position="Top" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                   </telerik:RadGrid>
                  <div id="Informacion" runat="server" visible="false">
                          <table runat="server" id="Encabezado" style="margin:auto;border-collapse:separate;border-spacing: 2px;"> 
                          <tr><td> 
                          <div class="panel panel-success">
                           <div class="panel-heading" style="text-align:center;"></div>
                               <table style="border-collapse:separate;border-spacing:10px;font-family:Arial;font-size:13px;font-weight:bold;">
                                <tr>
                                   <td><asp:LinkButton ID="Guardar" runat="server" CssClass="btn btn-primary btn-sm" ToolTip="Guardar Información" Text="Guardar">
                                    <span class="glyphicon glyphicon-floppy-save"></span>&nbsp;Guardar Información</asp:LinkButton></td>
                                    <td><asp:LinkButton ID="CancelarIngreso" runat="server" CssClass="btn btn-danger btn-sm" ToolTip="Cancelar Ingreso de Información" Text="Guardar">
                                    <span class="glyphicon glyphicon-remove"></span>&nbsp;Cancelar Ingreso</asp:LinkButton></td>                                  
                                </tr>
                            </table>
                                 <table style="margin:auto;border-collapse:separate;border-spacing:3px;text-align:center;">
                                     <tr><td><label for="Label2"><asp:Label ID="Label13" runat="server" Font-Bold="true" Text="SubComponente" Font-Size="10" ForeColor="#006699"/></label></td></tr>
                                     <tr>
                                        <td style="text-align:center;"><asp:TextBox ID="txtSubcomponente" Font-Names="Arial" Font-Size="9" ReadOnly="true"   
                                            runat="server" class="form-control" Width="600px" Height="40px" TextMode="MultiLine" ForeColor="#006699"></asp:TextBox></td>
                                       </tr>
                                    <tr><td><label for="Label2"><asp:Label ID="Label5" runat="server" Font-Bold="true" Text="Producto Verificable" Font-Size="10" ForeColor="#006699"/></label></td></tr>
                                    <tr>
                                        <td style="text-align:center;"><asp:TextBox ID="ProductoV" Font-Names="Arial" Font-Size="9" ReadOnly="true"   
                                            runat="server" class="form-control" Width="600px" Height="80px" TextMode="MultiLine" ForeColor="#006699"></asp:TextBox></td>
                                       </tr>
                                </table><br />
                               <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;">
                                   <tr id="trum1" runat="server">
                                    <td style="text-align:left;"><asp:Label ID="LblUM1" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#009933"/></td>
                                    <td style="width:90px"></td>
                                    <td><asp:Label ID="Label4" runat="server" Font-Bold="true" Text="Ingrese Valor" Font-Size="10" ForeColor="#006699"/></td>
                                    <td><telerik:RadNumericTextBox ID="txtum1" runat="server" Width="120px" style="text-align:right;" MinValue="0" 
                                              onkeydown="return (event.keyCode!=13);" MaxLength="10" NumberFormat-DecimalDigits="2" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>
                                   </tr>
                                  <tr id="trum2" runat="server">
                                    <td style="text-align:left;"><asp:Label ID="LblUM2" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#009933"/></td>
                                    <td style="width:90px"></td>
                                    <td><asp:Label ID="Label7" runat="server" Font-Bold="true" Text="Ingrese Valor" Font-Size="10" ForeColor="#006699"/></td>
                                    <td><telerik:RadNumericTextBox ID="txtum2" runat="server" Width="120px" style="text-align:right;" MinValue="0" 
                                              onkeydown="return (event.keyCode!=13);" MaxLength="10" NumberFormat-DecimalDigits="4" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>
                                   </tr>
                                   <tr id="trum3" runat="server">
                                    <td style="text-align:left;"><asp:Label ID="LblUM3" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#009933"/></td>
                                    <td style="width:90px"></td>
                                    <td><asp:Label ID="Label8" runat="server" Font-Bold="true" Text="Ingrese Valor" Font-Size="10" ForeColor="#006699"/></td>
                                    <td><telerik:RadNumericTextBox ID="txtum3" runat="server" Width="120px" style="text-align:right;" MinValue="0" 
                                              onkeydown="return (event.keyCode!=13);" MaxLength="10" NumberFormat-DecimalDigits="4" 
                                              NumberFormat-DecimalSeparator="."></telerik:RadNumericTextBox></td>
                                   </tr>
                               </table><br />
                               <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;">
                                   <tr>
                                       <td><asp:Label ID="Label6" runat="server" Font-Bold="true" Text="Departamento" Font-Size="10" ForeColor="#006699"/></td>
                                       <td style="width:20px"></td>
                                       <td><asp:Label ID="Label9" runat="server" Font-Bold="true" Text="Municipio" Font-Size="10" ForeColor="#006699"/></td>
                                   </tr>
                                   <tr>
                                     <td><telerik:RadComboBox ID="cboDepartamento"  AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Departamento" Width="250px" Height="90px"></telerik:RadComboBox></td>
                                       <td style="width:20px"></td>
                                     <td><telerik:RadComboBox ID="cboMunicipio"  AutoPostBack="true" runat="server" Filter="Contains" EmptyMessage="Seleccione Municipio" Width="250px" Height="90px"></telerik:RadComboBox></td>  
                                   </tr>
                                   <tr id="t1" runat="server" visible="false">
                                       <td><asp:Label ID="Label10" runat="server" Font-Bold="true" Text="Fecha" Font-Size="10" ForeColor="#006699"/></td>
                                       <td style="width:20px"></td>
                                       <td><asp:Label ID="Label11" runat="server" Font-Bold="true" Text="Medio de Verificación" Font-Size="10" ForeColor="#006699"/></td>
                                   </tr>
                                   <tr id="t2" runat="server" visible="false">
                                     <td><telerik:RadDatePicker ID="txtFecha" runat="server" Width="250px" onkeydown="return (event.keyCode!=13);"></telerik:RadDatePicker></td>
                                       <td style="width:20px"></td>
                                     <td><telerik:RadAsyncUpload runat="server" ID="RadDocumentoVerificacion" Culture="es-GT" MaxFileInputsCount="1"
                                          AllowedFileExtensions=".pdf,.xlsx" Width="250px" ChunkSize="0"></telerik:RadAsyncUpload></td>  
                                   </tr>
                                   <tr>
                                        <td></td><td></td>
                                       <td style="text-align:center"><asp:Label ID="Lblarchivo" runat="server" Font-Bold="true" Font-Size="10" ForeColor="#ff3300"/></td>
                                   </tr>
                               </table>                                                                               
                              <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;" id="tmes" runat="server" visible="false">
                                    <tr><td><asp:Label ID="Label17" runat="server" Font-Bold="true" Text="Mes de Ingreso" Font-Size="10" ForeColor="#006699"/></td></tr>                                       
                                     <tr><td><telerik:RadComboBox ID="cboMesIngreso" runat="server" EmptyMessage="Seleccione Mes" Width="600px"></telerik:RadComboBox></td></tr> 
                               </table>
                              <table style="margin:auto;border-collapse:separate;border-spacing:5px;text-align:center;" id="observa" runat="server">
                                   <tr>
                                      <td><asp:Label ID="Label12" runat="server" Font-Bold="true" Text="Observaciones" Font-Size="10" ForeColor="#006699"/></td>
                                  </tr>
                                  <tr><td><asp:TextBox ID="txtObservaciones" Font-Names="Arial" Font-Size="9"    
                                            runat="server" class="form-control" Width="600px" Height="70px" TextMode="MultiLine" ForeColor="#006699"></asp:TextBox></td></tr>
                              </table> 
                              </div> 
                              </td></tr>
                          </table> 
                          <telerik:RadGrid runat="server" ID="GrdIngresoEncabezado" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="True" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" ShowFooter="true">
                                    <GroupingSettings CaseSensitive="False" />
                                       <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                      <Selecting AllowRowSelect="True"></Selecting>                                             
                                     </ClientSettings>
                                   <MasterTableView PageSize="10" 
                                   DataKeyNames="Correlativo,Id_PoAnual,Id_Componente,Id_Subcomponente,Id_ProductoVerificable,Id_UM1,Id_UM2,Id_UM3,Id_Subregion,Id_Mes,
                                                 DescripcionUM1,DescripcionUM2,DescripcionUM3,ValorUM1,ValorUM2,ValorUM3,Id_Departamento,Id_Municipio,MedioDeVerificacion,
                                                Fecha,Observaciones,Expediente,Resolucion,DictamenTecnico,NombreCientifico,CodigoMirasil,Troza,Lenia,
                                                TotalDeArboles,Municipal" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                    <Columns>
                                    <telerik:GridButtonColumn Text="Eliminar producto" CommandName="Delete" UniqueName="Botonx" HeaderText="Eliminar<br/>Producto" ButtonType="ImageButton" 
                                        ImageUrl="../Iconos/eliminar.png" ConfirmText="Desea eliminar el producto?" ConfirmDialogType="RadWindow" ConfirmTitle="Eliminar Producto" 
                                        ButtonCssClass="imageButtonClass">
                                     <HeaderStyle Width="20px" HorizontalAlign="Center" Font-Size="8" Font-Names="Arial" Font-Bold="true"/>
                                      <ItemStyle HorizontalAlign="Center" /> 
                                     </telerik:GridButtonColumn>  
                                            <telerik:GridBoundColumn DataField="Correlativo" UniqueName="Correlativo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_PoAnual" UniqueName="Id_PoAnual" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Id_Componente" UniqueName="Id_Componente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_Subcomponente" UniqueName="Id_Subcomponente" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_ProductoVerificable" UniqueName="Id_ProductoVerificable" Display="false"></telerik:GridBoundColumn>	                                        	                                        	                                        
                                            <telerik:GridBoundColumn DataField="Id_UM1" UniqueName="Id_UM1" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM2" UniqueName="Id_UM2" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Id_UM3" UniqueName="Id_UM3" Display="false"></telerik:GridBoundColumn>                                            
                                            <telerik:GridBoundColumn DataField="Id_Subregion" UniqueName="Id_Subregion" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Departamento" UniqueName="Id_Departamento" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Municipio" UniqueName="Id_Municipio" Display="false"></telerik:GridBoundColumn>	  
                                            <telerik:GridBoundColumn DataField="Id_Mes" UniqueName="Id_Mes" Display="false"></telerik:GridBoundColumn>	                                                  
                                            <telerik:GridBoundColumn DataField="Fecha" UniqueName="Fecha" Display="false"></telerik:GridBoundColumn>	
                                            <telerik:GridBoundColumn DataField="Observaciones" UniqueName="Observaciones" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Expediente" UniqueName="Expediente" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Resolucion" UniqueName="Resolucion" Display="false"></telerik:GridBoundColumn>                                           
                                            <telerik:GridBoundColumn DataField="DictamenTecnico" UniqueName="DictamenTecnico" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="NombreCientifico" UniqueName="NombreCientifico" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="CodigoMirasil" UniqueName="CodigoMirasil" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Troza" UniqueName="Troza" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Lenia" UniqueName="Lenia" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="TotalDeArboles" UniqueName="TotalDeArboles" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="Municipal" UniqueName="Municipal" Display="false"></telerik:GridBoundColumn>                                                                                         
                                            <telerik:GridBoundColumn DataField="Departamento" UniqueName="Departamento" HeaderText="Departamento" FooterText="Totales" FooterStyle-Font-Bold="true">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Municipio" UniqueName="Municipio" HeaderText="Municipio">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="Subcomponente" UniqueName="Subcomponente" HeaderText="Subcomponente">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="ProductoVerificable" UniqueName="ProductoVerificable" HeaderText="Producto Verificable">
                                                <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center"  VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="ValorUM1" UniqueName="ValorUM1" HeaderText="Valor UM1" Aggregate="Sum" FooterAggregateFormatString="{0:#,###.#0}" DataFormatString="{0:#,##0.#0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ValorUM2" UniqueName="ValorUM2" HeaderText="Valor UM2" DataFormatString="{0:#,##0.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>
                                             <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                                 
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="ValorUM3" UniqueName="ValorUM3" HeaderText="Valor UM3"  DataFormatString="{0:#,##0.###0}" Aggregate="Sum" FooterAggregateFormatString="{0:#,##0.###0}">
                                                 <HeaderStyle Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/> 
                                                 <FooterStyle Font-Names="Arial" HorizontalAlign="Right" Font-Size="10" ForeColor="#ff3300" Font-Bold="true" />
                                            </telerik:GridBoundColumn> 	                                                                                                                                                                                                                                                                                                                                                                                                                                                      
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>                      
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
                            <asp:Label ID="lblConfirm" Font-Size="14px" Text="Desea FInalizar el ingreso del Componente"
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
                <telerik:RadWindow runat="server" Modal="true" ID="VerDatosExtra" Skin="Office2007" Behaviors="Move,Close" Left="900px" Top="2px">
                    <ContentTemplate>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>                   
                    <div class="panel panel-success">
                        <div class="panel-heading"><div style="text-align:center;"><span class="glyphicon glyphicon-file"></span>&nbsp;&nbsp;<asp:Label ID="Label34" runat="server" Font-Bold="true" Text="Información Adicional" Font-Size="10"/></div></div>
                        <div class="panel-body">                                                  
                            <table style="margin:auto;border-collapse:separate;border-spacing:10px;" class="table table-bordered border-primary" runat="server"> 
                                <tr>
                                    <td><asp:Label ID="Label21" runat="server" Font-Bold="true" Text="Número de Expediente:" Font-Size="10" Width="200px" ForeColor="#006600"/></td>
                                    <td><asp:Label ID="lblNoExpediente" runat="server" Font-Bold="true" Font-Size="10" Width="200px" ForeColor="#000066"/></td>
                                </tr>
                                  <tr>
                                  <td><asp:Label ID="Label14" runat="server" Font-Bold="true" Text="Número de Dictamen Técnico:" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblDictamenTecnico" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>  
                                <tr><td><asp:Label ID="Label35" runat="server" Font-Bold="true" Text="Número de Resolución:" Font-Size="10" Width="200px" ForeColor="#006600"/></td>
                                    <td><asp:Label ID="LblResolucion" runat="server" Font-Bold="true" Font-Size="10" Width="200px" ForeColor="#000066"/></td>                                                                                                                                                                       
                                </tr>
                                <tr>
                                  <td><asp:Label ID="Label36" runat="server" Font-Bold="true" Text="Fecha de Resolución:" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="lblFecha" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>                               
                                <tr>
                                  <td><asp:Label ID="Label15" runat="server" Font-Bold="true" Text="Nombre Científico (SP):" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblNombreCientifico" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr> 
                                <tr>
                                  <td><asp:Label ID="Label16" runat="server" Font-Bold="true" Text="Codigo Especie:" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblCodigoMirasil" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>   
                                 <tr>
                                  <td><asp:Label ID="Label18" runat="server" Font-Bold="true" Text="Troza (Volumen):" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblTroza" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>   
                                 <tr>
                                  <td><asp:Label ID="Label20" runat="server" Font-Bold="true" Text="Leña (Volumen):" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblLenia" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>   
                                 <tr>
                                  <td><asp:Label ID="Label23" runat="server" Font-Bold="true" Text="Número de Árboles:" Width="200px" Font-Size="10" ForeColor="#006600"/></td>                                                                       
                                  <td><asp:Label ID="LblTotalDeArboles" runat="server" Font-Bold="true" Width="200px" Font-Size="10" ForeColor="#000066"/></td>
                                </tr>   
                            </table>                             
                        </div>
                        </div>                         
                    </ContentTemplate>
                </asp:UpdatePanel>
            </ContentTemplate> 
        </telerik:RadWindow>     
</asp:Content>
