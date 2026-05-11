<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportarPOANacional.aspx.cs" Inherits="PlanificacionPOA.ExportarExcel.ExportarPOANacional" %>
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
                                   <MasterTableView DataKeyNames="Tipo,Correlativo_Configuracion,Descripcion,DescripcionUM1,DescripcionUM2,DescripcionUM3,PtUM1,PtUM2,
                                                    PtUM3,StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3,UnidadEvaludada,MedioDeVerificacion,Id_RedProgramatica,
                                                    IdObjetivo,IdResultado,IdIndicadores,Objetivo,Resultado,Indicadores" NoMasterRecordsText="Sin Información">  
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                           <telerik:GridColumnGroup HeaderText="Planificación Estrategica" Name="PE" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Cuatrimestral" Name="metacuatri" HeaderStyle-HorizontalAlign="Center">
                                                <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida" Name="UM">
                                                 <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="1er Cuatrimestre" Name="PC" ParentGroupName="metacuatri">
                                                 <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="2do Cuatrimestre" Name="SC" ParentGroupName="metacuatri">
                                                 <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="3er Cuatrimestre" Name="TC" ParentGroupName="metacuatri">
                                                 <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText=" Meta Anual" Name="CMA">
                                                 <HeaderStyle Font-Size="15" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                       </ColumnGroups> 
                                    <Columns>                                                                        
                                            <telerik:GridBoundColumn DataField="Tipo" UniqueName="Tipo" Display="false"></telerik:GridBoundColumn>
                                             <telerik:GridBoundColumn DataField="IdObjetivo" UniqueName="IdObjetivo" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IdResultado" UniqueName="IdResultado" Display="false"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="IdIndicadores" UniqueName="IdIndicadores" Display="false"></telerik:GridBoundColumn>                                                                                
                                            <telerik:GridBoundColumn DataField="Id_RedProgramatica" UniqueName="Id_RedProgramatica" Display="false"></telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="Correlativo_Configuracion" UniqueName="Correlativo_Configuracion" Display="false"></telerik:GridBoundColumn>                                        
                                            <telerik:GridBoundColumn DataField="Objetivo" UniqueName="Objetivo" ColumnGroupName="PE" HeaderText="Objetivo">
                                              <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" />
                                              <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	     
                                            <telerik:GridBoundColumn DataField="Resultado" UniqueName="Resultado" ColumnGroupName="PE" HeaderText="Resultado">
                                              <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" />
                                              <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	     
                                                <telerik:GridBoundColumn DataField="Indicadores" UniqueName="Indicadores" ColumnGroupName="PE" HeaderText="Indicadores">
                                                <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                                                                                                                          
                                         <telerik:GridBoundColumn DataField="Descripcion" UniqueName="Descripcion" HeaderText="Producto/ SubProductos / Actividades">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial" />
                                                  <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                        	                                        
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                       
                                            <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="PC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="PC" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="PC" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                          <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="SC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="SC" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="SC" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="TC" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="TC" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="TC" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="UnidadEvaludada" UniqueName="UnidadEvaludada" HeaderText="UM Evaluada">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" HeaderText="Medio de Verficación">
                                                  <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                           
                                </Columns>
                                 </MasterTableView>
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
        </div>
    </form>
</body>
</html>
