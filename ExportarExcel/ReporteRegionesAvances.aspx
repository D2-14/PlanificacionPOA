<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteRegionesAvances.aspx.cs" Inherits="PlanificacionPOA.ExportarExcel.ReporteRegionesAvances" %>
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
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
         <telerik:RadWindowManager ID="RadWindowManager1" runat="server" RenderMode="Lightweight" EnableShadow="true" Skin="Office2007"></telerik:RadWindowManager>
          <div id="Avances"> 
              <telerik:RadGrid runat="server" ID="GdrAvacesMonitoreo" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="true">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,MedioDeVerificacion,
                                       EneroUM1,EneroUM2,EneroUM3,FebreroUM1,FebreroUM2,FebreroUM3,MarzoUM1,MarzoUM2,MarzoUM3,AbrilUM1,AbrilUM2,AbrilUM3,MayoUM1,MayoUM2,MayoUM3,JunioUM1,JunioUM2,
                                       JunioUM3,JulioUM1,JulioUM2,JulioUM3,AgostoUM1,AgostoUM2,AgostoUM3,SeptiembreUM1,SeptiembreUM2,SeptiembreUM3,OctubreUM1,OctubreUM2,OctubreUM3,NoviembreUM1,
                                       NoviembreUM2,NoviembreUM3,DiciembreUM1,DiciembreUM2,DiciembreUM3,SPCUM1,SPCUM2,SPCUM3,SSUM1,SSUM2,SSUM3,STUM1,STUM2,STUM3,CmaUM1,CmaUM2,CmaUM3,
                                       GPCResultado,AJPC,GSCResultado,AJSC,GTCResultado,AJTC,GeneralResultado,GAjustado" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>                                           
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                       
                                            <telerik:GridColumnGroup HeaderText="Ejecución Anual" Name="CMA">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Enero" Name="enero" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Febrero" Name="febrero" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Marzo" Name="marzo" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Abril" Name="abril" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Mayo" Name="mayo" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Junio" Name="junio" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Julio" Name="julio" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Agosto" Name="agosto" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Septiembre" Name="septiembre" ParentGroupName="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Octubre" Name="octubre" ParentGroupName="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Noviembre" Name="noviembre" ParentGroupName="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Diciembre" Name="diciembre" ParentGroupName="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                           
                                           <telerik:GridColumnGroup HeaderText="Ejecución Primer Cuatrimestre" Name="MPC" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Ejecución Segundo Cuatrimestre" Name="MSC" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Ejecución Tercer Cuatrimestre" Name="MTC" ParentGroupName="tc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Evaluación del POA" Name="EVP">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="MPCE" ParentGroupName="EVP">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="MSCE" ParentGroupName="EVP">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="MTCE" ParentGroupName="EVP">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Anual" Name="Anual" ParentGroupName="EVP">
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
                                         <telerik:GridBoundColumn DataField="DescripcionComponente" UniqueName="DescripcionComponente" HeaderText="Componente">
                                                  <HeaderStyle Width="250px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                         
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionSubComponente" UniqueName="DescripcionSubComponente" HeaderText="Subcomponente">
                                                  <HeaderStyle Width="300px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Justify" Font-Size="8" VerticalAlign="Middle" ForeColor="RoyalBlue" Font-Names="Arial"/>                                        
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Productos Verificables">
                                                <HeaderStyle Width="450px" Font-Size="8" Font-Bold="true" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Justify" Font-Size="8" ForeColor="RoyalBlue" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
	                                        <telerik:GridBoundColumn DataField="DescripcionUM1" UniqueName="DescripcionUM1" ColumnGroupName="UM" HeaderText="UM1">
                                                 <HeaderStyle Width="150px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM2" UniqueName="DescripcionUM2" ColumnGroupName="UM" HeaderText="UM2">
                                                 <HeaderStyle Width="150px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
	                                        <telerik:GridBoundColumn DataField="DescripcionUM3" UniqueName="DescripcionUM3" ColumnGroupName="UM" HeaderText="UM3">
                                                  <HeaderStyle Width="150px" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                      
                                                 <telerik:GridBoundColumn DataField="EneroUM1" UniqueName="EneroUM1" ColumnGroupName="enero" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="EneroUM2" UniqueName="EneroUM2" ColumnGroupName="enero" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="EneroUM3" UniqueName="EneroUM3" ColumnGroupName="enero" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="FebreroUM1" UniqueName="FebreroUM2" ColumnGroupName="febrero" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="FebreroUM2" UniqueName="FebreroUM2" ColumnGroupName="febrero" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="FebreroUM3" UniqueName="FebreroUM2" ColumnGroupName="febrero" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                        
                                        <telerik:GridBoundColumn DataField="MarzoUM1" UniqueName="MarzoUM1" ColumnGroupName="marzo" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="MarzoUM2" UniqueName="MarzoUM2" ColumnGroupName="marzo" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="MarzoUM3" UniqueName="MarzoUM3" ColumnGroupName="marzo" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                 
                                        <telerik:GridBoundColumn DataField="AbrilUM1" UniqueName="AbrilUM1" ColumnGroupName="abril" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="AbrilUM2" UniqueName="AbrilUM2" ColumnGroupName="abril" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="AbrilUM3" UniqueName="AbrilUM3" ColumnGroupName="abril" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  

                                         <telerik:GridBoundColumn DataField="SPCUM1" UniqueName="SPCUM1" ColumnGroupName="MPC" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="SPCUM2" UniqueName="SPCUM2" ColumnGroupName="MPC" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="SPCUM3" UniqueName="SPCUM3" ColumnGroupName="MPC" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                        
                                        <telerik:GridBoundColumn DataField="MayoUM1" UniqueName="MayoUM1" ColumnGroupName="mayo" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="MayoUM2" UniqueName="MayoUM2" ColumnGroupName="mayo" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="MayoUM3" UniqueName="MayoUM3" ColumnGroupName="mayo" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="JunioUM1" UniqueName="JunioUM1" ColumnGroupName="junio" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="JunioUM2" UniqueName="JunioUM2" ColumnGroupName="junio" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="JunioUM3" UniqueName="JunioUM3" ColumnGroupName="junio" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="JulioUM1" UniqueName="JulioUM1" ColumnGroupName="julio" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="JulioUM2" UniqueName="JulioUM2" ColumnGroupName="julio" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="JulioUM3" UniqueName="JulioUM3" ColumnGroupName="julio" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                 
                                        <telerik:GridBoundColumn DataField="AgostoUM1" UniqueName="AgostoUM1" ColumnGroupName="agosto" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="AgostoUM2" UniqueName="AgostoUM2" ColumnGroupName="agosto" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="AgostoUM3" UniqueName="AgostoUM3" ColumnGroupName="agosto" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                        
                                             <telerik:GridBoundColumn DataField="SSUM1" UniqueName="SSUM1" ColumnGroupName="MSC" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="SSUM2" UniqueName="SSUM2" ColumnGroupName="MSC" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="SSUM3" UniqueName="SSUM3" ColumnGroupName="MSC" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 

                                        <telerik:GridBoundColumn DataField="SeptiembreUM1" UniqueName="SeptiembreUM1" ColumnGroupName="septiembre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="SeptiembreUM2" UniqueName="SeptiembreUM2" ColumnGroupName="septiembre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="SeptiembreUM3" UniqueName="SeptiembreUM3" ColumnGroupName="septiembre" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                
                                        <telerik:GridBoundColumn DataField="OctubreUM1" UniqueName="OctubreUM1" ColumnGroupName="octubre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="OctubreUM2" UniqueName="OctubreUM2" ColumnGroupName="octubre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="OctubreUM3" UniqueName="OctubreUM3" ColumnGroupName="octubre" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                 
                                        <telerik:GridBoundColumn DataField="NoviembreUM1" UniqueName="NoviembreUM1" ColumnGroupName="noviembre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="NoviembreUM2" UniqueName="NoviembreUM2" ColumnGroupName="noviembre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="NoviembreUM3" UniqueName="NoviembreUM3" ColumnGroupName="noviembre" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                         
                                        <telerik:GridBoundColumn DataField="DiciembreUM1" UniqueName="DiciembreUM1" ColumnGroupName="diciembre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="DiciembreUM2" UniqueName="DiciembreUM2" ColumnGroupName="diciembre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="DiciembreUM3" UniqueName="DiciembreUM3" ColumnGroupName="diciembre" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                        
                                        <telerik:GridBoundColumn DataField="STUM1" UniqueName="STUM1" ColumnGroupName="MTC" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="STUM2" UniqueName="STUM2" ColumnGroupName="MTC" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                         <telerik:GridBoundColumn DataField="STUM3" UniqueName="STUM3" ColumnGroupName="MTC" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>    
                                        
                                        <telerik:GridBoundColumn DataField="CmaUM1" UniqueName="CmaUM1" ColumnGroupName="CMA" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM2" UniqueName="CmaUM2" ColumnGroupName="CMA" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="CmaUM3" UniqueName="CmaUM3" ColumnGroupName="CMA" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         
                                        
                                        <telerik:GridBoundColumn DataField="GPCResultado" UniqueName="GPCResultado" ColumnGroupName="MPCE" HeaderText="General">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AJPC" UniqueName="AJPC" ColumnGroupName="MPCE" HeaderText="Ajustado">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                        <telerik:GridBoundColumn DataField="GSCResultado" UniqueName="GSCResultado" ColumnGroupName="MSCE" HeaderText="General">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial" />
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AJSC" UniqueName="AJSC" ColumnGroupName="MSCE" HeaderText="Ajustado">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GTCResultado" UniqueName="GTCResultado" ColumnGroupName="MTCE" HeaderText="General">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="AJTC" UniqueName="AJTC" ColumnGroupName="MTCE" HeaderText="Ajustado">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                         <telerik:GridBoundColumn DataField="GeneralResultado" UniqueName="GeneralResultado" ColumnGroupName="Anual" HeaderText="General">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="GAjustado" UniqueName="GAjustado" ColumnGroupName="Anual" HeaderText="Ajustado">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                        
                                        <telerik:GridBoundColumn DataField="DescripcionUnidadMedida" UniqueName="DescripcionUnidadMedida" HeaderText="Unidad de Medida Evaluada">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                         
                                        <telerik:GridBoundColumn DataField="MedioDeVerificacion" UniqueName="MedioDeVerificacion" HeaderText="Medio de Verificación">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                </Columns>
                                 </MasterTableView >
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
          </div>   
       </ContentTemplate>
    </asp:UpdatePanel> 
    </form>
</body>
</html>
