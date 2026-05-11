<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarExcelPOARegional.aspx.cs" Inherits="PlanificacionPOA.ExportarExcel.ExportarExcelPOARegional" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
          <telerik:RadScriptManager ID="RadScriptManager1" runat="server"/>                
        <div>
             <telerik:RadWindowManager ID="RadWindowManager1" runat="server" RenderMode="Lightweight" EnableShadow="true" Skin="Office2007"></telerik:RadWindowManager>
            <telerik:RadGrid runat="server" ID="GdrConfiguracion" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false">
                                   <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView  
                                   DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,Id_MetasRedProgramatica, 
                                                 Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,MedioDeVerificacion,	 
                                                 DireccionMedioVerificacion" NoMasterRecordsText="Sin Información">
                                   <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
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
                                            <telerik:GridBoundColumn DataField="DescripcionComponente" UniqueName="DescripcionComponente" HeaderText="Componente">
                                                  <HeaderStyle Width="300px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Left" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionSubComponente" UniqueName="DescripcionSubComponente" HeaderText="Subcomponente">
                                                  <HeaderStyle Width="300px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                        
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actividades">
                                                <HeaderStyle Width="600px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" HeaderText="UM1">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" HeaderText="UM2">
                                                 <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" HeaderText="UM3">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUnidadMedida" UniqueName="DescripcionUnidadMedida" HeaderText="Unidad Evaluada">
                                                  <HeaderStyle Width="100px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" HeaderText="Medio Verficación">
                                                  <HeaderStyle Width="300px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="DireccionMedioVerificacion" UniqueName="DireccionMedioVerificacion" HeaderText="Dirección Medio">
                                                  <HeaderStyle Width="500px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                                                                                                                   
                                </Columns>
                                 </MasterTableView>
                                 <PagerStyle Mode="Slider" NextPageText="Siguiente" PrevPageText="Anterior" Position="Bottom" PagerTextFormat="Change page: 
                                 {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                 &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                    
                               </telerik:RadGrid>    
        </div>
    </form>
</body>
</html>
