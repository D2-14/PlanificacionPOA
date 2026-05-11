<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteRegiones.aspx.cs" Inherits="PlanificacionPOA.ExportarExcel.ReporteRegiones" %>
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
        <div id="NacionalRED">
             <telerik:RadGrid runat="server" ID="GdrNacionalRED" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="false">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,
                                       EneroUM1,EneroUM2,EneroUM3,FebreroUM1,FebreroUM2,FebreroUM3,MarzoUM1,MarzoUM2,MarzoUM3,AbrilUM1,AbrilUM2,AbrilUM3,MayoUM1,MayoUM2,MayoUM3,JunioUM1,JunioUM2,
                                       JunioUM3,JulioUM1,JulioUM2,JulioUM3,AgostoUM1,AgostoUM2,AgostoUM3,SeptiembreUM1,SeptiembreUM2,SeptiembreUM3,OctubreUM1,OctubreUM2,OctubreUM3,NoviembreUM1,
                                       NoviembreUM2,NoviembreUM3,DiciembreUM1,DiciembreUM2,DiciembreUM3,SPCUM1,SPCUM2,SPCUM3,SSUM1,SSUM2,SSUM3,STUM1,STUM2,STUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="NACIONAL" Name="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="pc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="sc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="tc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                       
                                            <telerik:GridColumnGroup HeaderText="Meta Consolidada" Name="CMA">
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
                                           <telerik:GridColumnGroup HeaderText="Meta Primer Cuatrimestre" Name="MPC" ParentGroupName="pc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Segundo Cuatrimestre" Name="MSC" ParentGroupName="sc">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Tercer Cuatrimestre" Name="MTC" ParentGroupName="tc">
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
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actvidades">
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
                                </Columns>
                                 </MasterTableView >
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
        </div>
        <div id="Nacional">
            <telerik:RadGrid runat="server" ID="GdrNacional" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="false">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,
                                       PtUM1,PtUM2,PtUM3,StUM1,StUM2,StUM3,ttUM1,ttUM2,ttUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                           <telerik:GridColumnGroup HeaderText="NACIONAL" Name="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                           
                                           <telerik:GridColumnGroup HeaderText="Meta Primer Cuatrimestre" Name="pc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Segundo Cuatrimestre" Name="sc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Tercer Cuatrimestre" Name="tc" ParentGroupName="nac">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                       
                                            <telerik:GridColumnGroup HeaderText="Meta Consolidada" Name="CMA">
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
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actvidades">
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
                                              <telerik:GridBoundColumn DataField="PtUM1" UniqueName="PtUM1" ColumnGroupName="pc" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn DataField="PtUM2" UniqueName="PtUM2" ColumnGroupName="pc" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PtUM3" UniqueName="PtUM3" ColumnGroupName="pc" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                           
                                        <telerik:GridBoundColumn DataField="StUM1" UniqueName="StUM1" ColumnGroupName="sc" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="StUM2" UniqueName="StUM2" ColumnGroupName="sc" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="StUM3" UniqueName="StUM3" ColumnGroupName="sc" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                              
                                        <telerik:GridBoundColumn DataField="ttUM1" UniqueName="ttUM1" ColumnGroupName="tc" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ttUM2" UniqueName="ttUM2" ColumnGroupName="tc" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="ttUM3" UniqueName="ttUM3" ColumnGroupName="tc" HeaderText="UM3">
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
                                </Columns>
                                 </MasterTableView >
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
        </div>
        <div id="Regional">
             <telerik:RadGrid runat="server" ID="GdrRegional" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="false">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,
                                       PR1UM1,PR1UM2,PR1UM3,PR2UM1,PR2UM2,PR2UM3,PR3UM1,PR3UM2,PR3UM3,PR4UM1,PR4UM2,PR4UM3,PR5UM1,PR5UM2,PR5UM3,PR6UM1,PR6UM2,PR6UM3,PR7UM1,PR7UM2,PR7UM3,PR8UM1,
                                       PR8UM2,PR8UM3,PR9UM1,PR9UM2,PR9UM3,PR10UM1,PR10UM2,PR10UM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                           <telerik:GridColumnGroup HeaderText="REGIONES INAB" Name="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual I-Metropolitana" Name="enero" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual II-Las Verapaces e Ixcán" Name="febrero" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900" />
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual III-Nororiente" Name="marzo" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual IV-Suroriente" Name="abril" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual V-Chimaltenango y Sacatepéquez" Name="mayo" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VI-Suroccidente" Name="junio" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VII-Noroccidente" Name="julio" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VIII-Petén" Name="agosto" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual IX-Costa Sur" Name="septiembre" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>   
                                           <telerik:GridColumnGroup HeaderText="Meta Anual X-Baja Verapaz" Name="octubre" ParentGroupName="reg">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
                                            </telerik:GridColumnGroup>  
                                            <telerik:GridColumnGroup HeaderText="Meta Consolidada" Name="CMA">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial" BackColor="#ff9900"/>
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
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actvidades">
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
                                                 <telerik:GridBoundColumn DataField="PR1UM1" UniqueName="PR1UM1" ColumnGroupName="enero" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR1UM2" UniqueName="PR1UM2" ColumnGroupName="enero" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR1UM3" UniqueName="PR1UM3" ColumnGroupName="enero" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                
                                        <telerik:GridBoundColumn DataField="PR2UM1" UniqueName="PR2UM1" ColumnGroupName="febrero" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR2UM2" UniqueName="PR2UM2" ColumnGroupName="febrero" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR2UM3" UniqueName="PR2UM3" ColumnGroupName="febrero" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                            
                                        <telerik:GridBoundColumn DataField="PR3UM1" UniqueName="PR3UM1" ColumnGroupName="marzo" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR3UM2" UniqueName="PR3UM2" ColumnGroupName="marzo" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR3UM3" UniqueName="PR3UM3" ColumnGroupName="marzo" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                                                        
                                        <telerik:GridBoundColumn DataField="PR4UM1" UniqueName="PR4UM1" ColumnGroupName="abril" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR4UM2" UniqueName="PR4UM2" ColumnGroupName="abril" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR4UM3" UniqueName="PR4UM3" ColumnGroupName="abril" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                
                                        <telerik:GridBoundColumn DataField="PR5UM1" UniqueName="PR5UM1" ColumnGroupName="mayo" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR5UM2" UniqueName="PR5UM2" ColumnGroupName="mayo" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR5UM3" UniqueName="PR5UM3" ColumnGroupName="mayo" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                        
                                        <telerik:GridBoundColumn DataField="PR6UM1" UniqueName="PR6UM1" ColumnGroupName="junio" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR6UM2" UniqueName="PR6UM2" ColumnGroupName="junio" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                       <telerik:GridBoundColumn DataField="PR6UM3" UniqueName="PR6UM3" ColumnGroupName="junio" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                 
                                        <telerik:GridBoundColumn DataField="PR7UM1" UniqueName="PR7UM1" ColumnGroupName="julio" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR7UM2" UniqueName="PR7UM2" ColumnGroupName="julio" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR7UM3" UniqueName="PR7UM3" ColumnGroupName="julio" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                         
                                        <telerik:GridBoundColumn DataField="PR8UM1" UniqueName="PR8UM1" ColumnGroupName="agosto" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR8UM2" UniqueName="PR8UM2" ColumnGroupName="agosto" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR8UM3" UniqueName="PR8UM3" ColumnGroupName="agosto" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                                                                                                                                       
                                        <telerik:GridBoundColumn DataField="PR9UM1" UniqueName="PR9UM1" ColumnGroupName="septiembre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR9UM2" UniqueName="PR9UM2" ColumnGroupName="septiembre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR9UM3" UniqueName="PR9UM3" ColumnGroupName="septiembre" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>  
                                        <telerik:GridBoundColumn DataField="PR10UM1" UniqueName="PR10UM1" ColumnGroupName="octubre" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR10UM2" UniqueName="PR10UM2" ColumnGroupName="octubre" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                        <telerik:GridBoundColumn DataField="PR10UM3" UniqueName="PR10UM3" ColumnGroupName="octubre" HeaderText="UM3">
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
                                </Columns>
                                 </MasterTableView >
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
        </div>
        <div id="SubRegional">
             <telerik:RadGrid runat="server" ID="GdrSubRegional" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="false">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,
                                      PS11UM1,PS11UM2,PS11UM3,PS21UM1,PS21UM2,PS21UM3,PS22UM1,PS22UM2,PS22UM3,PS23UM1,PS23UM2,PS23UM3,PS24UM1,PS24UM2,PS24UM3,PS25UM1,PS25UM1,PS25UM1,PS26UM1,
                                      PS26UM2,PS26UM3,PS27UM1,PS27UM2,PS27UM3,PS31UM1,PS31UM2,PS31UM3,PS32UM1,PS32UM2,PS32UM3,PS33UM1,PS33UM2,PS33UM3,PS34UM1,PS34UM2,PS34UM3,PS41UM1,PS41UM2,
                                      PS41UM3,PS42UM1,PS42UM2,PS42UM3,PS43UM1,PS43UM2,PS43UM3,PS51UM1,PS51UM2,PS51UM3,PS52UM1,PS52UM2,PS52UM3,PS61UM1,PS61UM2,PS61UM3,PS62UM1,PS62UM2,PS62UM3,	
                                      PS63UM1,PS63UM2,PS63UM3,PS64UM1,PS64UM2,PS64UM3,PS65UM1,PS65UM2,PS65UM3,PS71UM1,PS71UM2,PS71UM3,PS72UM1,PS72UM2,PS72UM3,PS73UM1,PS73UM2,PS73UM3,PS74UM1,
                                      PS74UM2,PS74UM3,PS75UM1,PS75UM2,PS75UM3,PS81UM1,PS81UM2,PS81UM3,PS82UM1,PS82UM2,PS82UM3,PS83UM1,PS83UM2,PS83UM3,PS84UM1,PS84UM2,PS84UM3,PS85UM1,PS85UM2,PS85UM3,PS91UM1,PS91UM2,
                                      PS91UM3,PS92UM1,PS92UM2,PS92UM3,PS93UM1,PS93UM2,PS93UM3,PS94UM1,PS94UM2,PS94UM3,PS101UM1,PS101UM2,PS101UM3,PS102UM1,PS102UM2,PS102UM3,PS103UM1,PS103UM2,PS103UM3,
                                       CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual I-Metropolitana" Name="1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="II-Las Verapaces e Ixcán" Name="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="III-Nororiente" Name="3">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="IV-Suroriente" Name="4">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="V-Chimaltenango y Sacatepéquez" Name="5">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="VI-Suroccidente" Name="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="VII-Noroccidente" Name="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="VIII-Petén" Name="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="IX-Costa Sur" Name="9">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>  
                                            <telerik:GridColumnGroup HeaderText="X Baja Verapaz" Name="10">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual I-1 Metropolitana" Name="11" ParentGroupName="1">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                           
                                           <telerik:GridColumnGroup HeaderText="Meta Anual II-1 Tactic" Name="21" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                         <%--   <telerik:GridColumnGroup HeaderText="Meta Anual II-2 Rabinal" Name="22" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>--%>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual II-3 Cobán" Name="23" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <%--<telerik:GridColumnGroup  HeaderText="Meta Anual II-4 San Jerónimo" Name="24" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> --%>                                                                                                                                 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual II-5 Fray Bartolomé de las Casas" Name="25" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual II-6 Playa Grande Ixcán" Name="26" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual II-7 Santa Catalina La Tinta" Name="27" ParentGroupName="2">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual III-1 Izabal" Name="31" ParentGroupName="3">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                                                                 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual III-2 Zacapa" Name="32" ParentGroupName="3">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual III-3 Chiquimula" Name="33" ParentGroupName="3">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual III-4 El Progreso" Name="34" ParentGroupName="3">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                                                                 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual IV-1 Jalapa" Name="41" ParentGroupName="4">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual IV-2 Santa Rosa" Name="42" ParentGroupName="4">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                                                                 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual IV-3 Jutiapa" Name="43" ParentGroupName="4">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual V-1 Sacatepéquez" Name="51" ParentGroupName="5">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual V-2 Chimaltenango" Name="52" ParentGroupName="5">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VI-1 Quetzaltenango" Name="61" ParentGroupName="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                       
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VI-2 San Marcos" Name="62" ParentGroupName="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VI-3 Totonicapán" Name="63" ParentGroupName="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VI-4 Sololá" Name="64" ParentGroupName="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VI-5 Tejutla" Name="65" ParentGroupName="6">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>                                                                                                                                 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VII-1 Santa Cruz del Quiché" Name="71" ParentGroupName="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VII-2 Huehuetenango" Name="72" ParentGroupName="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VII-3 Nebaj" Name="73" ParentGroupName="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VII-4 Soloma" Name="74" ParentGroupName="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VII-5 Santa Ana Huista" Name="75" ParentGroupName="7">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VIII-1 San Francisco" Name="81" ParentGroupName="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VIII-2 Poptún" Name="82" ParentGroupName="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VIII-3 Sayaxche" Name="83" ParentGroupName="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual VIII-4 La Libertad" Name="84" ParentGroupName="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                            <telerik:GridColumnGroup HeaderText="Meta Anual VIII-5 El Chal" Name="85" ParentGroupName="8">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                           <telerik:GridColumnGroup HeaderText="Meta Anual IX-1 Mazatenango" Name="91" ParentGroupName="9">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Anual IX-2 Escuintla" Name="92" ParentGroupName="9">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual IX-3 Retalhuleu" Name="93" ParentGroupName="9">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Meta Anual IX-4 Coatepeque" Name="94" ParentGroupName="9">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>   
                                             <telerik:GridColumnGroup HeaderText="Meta Anual X-1 San Jerónimo" Name="95" ParentGroupName="10">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                             <telerik:GridColumnGroup HeaderText="Meta Anual X-2 Rabinal" Name="96" ParentGroupName="10">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                             <telerik:GridColumnGroup HeaderText="Meta Anual X-3 Granados" Name="97" ParentGroupName="10">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup> 
                                           <telerik:GridColumnGroup HeaderText="Meta Consolidada" Name="CMA">
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
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actvidades">
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
                                            <telerik:GridBoundColumn DataField="PS11UM1" UniqueName="PS11UM1" ColumnGroupName="11" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                            <telerik:GridBoundColumn DataField="PS11UM2" UniqueName="PS11UM2" ColumnGroupName="11" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                                <telerik:GridBoundColumn DataField="PS11UM3" UniqueName="PS11UM3" ColumnGroupName="11" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		
                                            <telerik:GridBoundColumn DataField="PS21UM1" UniqueName="PS21UM1" ColumnGroupName="21" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 			
                                            <telerik:GridBoundColumn DataField="PS21UM2" UniqueName="PS21UM2" ColumnGroupName="21" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 				
                                            <telerik:GridBoundColumn DataField="PS21UM3" UniqueName="PS21UM3" ColumnGroupName="21" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 				
                                            <%--<telerik:GridBoundColumn DataField="PS22UM1" UniqueName="PS22UM1" ColumnGroupName="22" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS22UM2" UniqueName="PS22UM2" ColumnGroupName="22" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                             <telerik:GridBoundColumn DataField="PS22UM3" UniqueName="PS22UM3" ColumnGroupName="22" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	--%>				                                                                                                                            
                                          <telerik:GridBoundColumn DataField="PS23UM1" UniqueName="PS23UM1" ColumnGroupName="23" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                    <telerik:GridBoundColumn DataField="PS23UM2" UniqueName="PS23UM2" ColumnGroupName="23" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                <telerik:GridBoundColumn DataField="PS23UM3" UniqueName="PS23UM3" ColumnGroupName="23" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					                                                                                                                           
                                           <%-- <telerik:GridBoundColumn DataField="PS24UM1" UniqueName="PS24UM1" ColumnGroupName="24" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS24UM2" UniqueName="PS24UM2" ColumnGroupName="24" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS24UM3" UniqueName="PS24UM3" ColumnGroupName="24" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> --%>					                                            
                                            <telerik:GridBoundColumn DataField="PS25UM1" UniqueName="PS25UM1" ColumnGroupName="25" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS25UM2" UniqueName="PS25UM2" ColumnGroupName="25" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS25UM3" UniqueName="PS25UM3" ColumnGroupName="25" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					                                                                                    
                                        <telerik:GridBoundColumn DataField="PS26UM1" UniqueName="PS26UM1" ColumnGroupName="26" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS26UM2" UniqueName="PS26UM2" ColumnGroupName="26" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS26UM3" UniqueName="PS26UM3" ColumnGroupName="26" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					                                                                                   
                                            <telerik:GridBoundColumn DataField="PS27UM1" UniqueName="PS27UM1" ColumnGroupName="27" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS27UM2" UniqueName="PS27UM2" ColumnGroupName="27" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS27UM3" UniqueName="PS27UM3" ColumnGroupName="27" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                                                                                                                                                                                                                                                                                                   
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS31UM1" UniqueName="PS31UM1" ColumnGroupName="31" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS31UM2" UniqueName="PS31UM2" ColumnGroupName="31" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS31UM3" UniqueName="PS31UM3" ColumnGroupName="31" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					                                                                                                                            
                                            <telerik:GridBoundColumn DataField="PS32UM1" UniqueName="PS32UM1" ColumnGroupName="32" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS32UM2" UniqueName="PS32UM2" ColumnGroupName="32" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS32UM3" UniqueName="PS32UM3" ColumnGroupName="32" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS33UM1" UniqueName="PS33UM1" ColumnGroupName="33" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS33UM2" UniqueName="PS33UM2" ColumnGroupName="33" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS33UM3" UniqueName="PS33UM3" ColumnGroupName="33" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                         
                                            <telerik:GridBoundColumn DataField="PS34UM1" UniqueName="PS34UM1" ColumnGroupName="34" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS34UM2" UniqueName="PS34UM2" ColumnGroupName="34" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS34UM3" UniqueName="PS34UM3" ColumnGroupName="34" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                       
                                            
                                            <telerik:GridBoundColumn DataField="PS41UM1" UniqueName="PS41UM1" ColumnGroupName="41" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS41UM2" UniqueName="PS41UM2" ColumnGroupName="41" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS41UM3" UniqueName="PS41UM3" ColumnGroupName="41" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 			                                                                                   
                                        <telerik:GridBoundColumn DataField="PS42UM1" UniqueName="PS42UM1" ColumnGroupName="42" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS42UM2" UniqueName="PS42UM2" ColumnGroupName="42" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS42UM3" UniqueName="PS42UM3" ColumnGroupName="42" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		                                                                                                                            
                                        <telerik:GridBoundColumn DataField="PS43UM1" UniqueName="PS43UM1" ColumnGroupName="43" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS43UM2" UniqueName="PS43UM2" ColumnGroupName="43" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS43UM3" UniqueName="PS43UM3" ColumnGroupName="43" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                                                                                                                                                    
                                        <telerik:GridBoundColumn DataField="PS51UM1" UniqueName="PS51UM1" ColumnGroupName="51" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					    
                                            <telerik:GridBoundColumn DataField="PS51UM2" UniqueName="PS51UM2" ColumnGroupName="51" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS51UM3" UniqueName="PS51UM3" ColumnGroupName="51" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS52UM1" UniqueName="PS52UM1" ColumnGroupName="52" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS52UM2" UniqueName="PS52UM2" ColumnGroupName="52" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS52UM3" UniqueName="PS52UM3" ColumnGroupName="52" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						                                                                                                                            
                                            <telerik:GridBoundColumn DataField="PS61UM1" UniqueName="PS61UM1" ColumnGroupName="61" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS61UM2" UniqueName="PS61UM2" ColumnGroupName="61" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS61UM3" UniqueName="PS61UM3" ColumnGroupName="61" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						                                                                                                                            
                                         <telerik:GridBoundColumn DataField="PS62UM1" UniqueName="PS62UM1" ColumnGroupName="62" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS62UM2" UniqueName="PS62UM2" ColumnGroupName="62" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS62UM3" UniqueName="PS62UM3" ColumnGroupName="62" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 			                                        
                                            <telerik:GridBoundColumn DataField="PS63UM1" UniqueName="PS63UM1" ColumnGroupName="63" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS63UM2" UniqueName="PS63UM2" ColumnGroupName="63" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS63UM3" UniqueName="PS63UM3" ColumnGroupName="63" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		                                        
                                            <telerik:GridBoundColumn DataField="PS64UM1" UniqueName="PS64UM1" ColumnGroupName="64" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS64UM2" UniqueName="PS64UM2" ColumnGroupName="64" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS64UM3" UniqueName="PS64UM3" ColumnGroupName="64" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		                                        
                                            <telerik:GridBoundColumn DataField="PS65UM1" UniqueName="PS65UM1" ColumnGroupName="65" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS65UM2" UniqueName="PS65UM2" ColumnGroupName="65" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS65UM3" UniqueName="PS65UM3" ColumnGroupName="65" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					    
                                            <telerik:GridBoundColumn DataField="PS71UM1" UniqueName="PS71UM1" ColumnGroupName="71" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                            <telerik:GridBoundColumn DataField="PS71UM2" UniqueName="PS71UM2" ColumnGroupName="71" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 							
                                            <telerik:GridBoundColumn DataField="PS71UM3" UniqueName="PS71UM3" ColumnGroupName="71" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>                                         
                                             <telerik:GridBoundColumn DataField="PS72UM1" UniqueName="PS72UM1" ColumnGroupName="72" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 						
                                                <telerik:GridBoundColumn DataField="PS72UM2" UniqueName="PS72UM2" ColumnGroupName="72" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                <telerik:GridBoundColumn DataField="PS72UM3" UniqueName="PS72UM3" ColumnGroupName="72" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                <telerik:GridBoundColumn DataField="PS73UM1" UniqueName="PS73UM1" ColumnGroupName="73" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS73UM2" UniqueName="PS73UM2" ColumnGroupName="73" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                             <telerik:GridBoundColumn DataField="PS73UM3" UniqueName="PS73UM3" ColumnGroupName="73" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		                                        
                                            <telerik:GridBoundColumn DataField="PS74UM1" UniqueName="PS74UM1" ColumnGroupName="74" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                <telerik:GridBoundColumn DataField="PS74UM2" UniqueName="PS74UM2" ColumnGroupName="74" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                             <telerik:GridBoundColumn DataField="PS74UM3" UniqueName="PS74UM3" ColumnGroupName="74" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS75UM1" UniqueName="PS75UM1" ColumnGroupName="75" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                                <telerik:GridBoundColumn DataField="PS75UM2" UniqueName="PS75UM2" ColumnGroupName="75" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS75UM3" UniqueName="PS75UM3" ColumnGroupName="75" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					                                                                                                                                                                                                                                                                                            
                                            <telerik:GridBoundColumn DataField="PS81UM1" UniqueName="PS81UM1" ColumnGroupName="81" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS81UM2" UniqueName="PS81UM2" ColumnGroupName="81" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS81UM3" UniqueName="PS81UM3" ColumnGroupName="81" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	                                        
                                            <telerik:GridBoundColumn DataField="PS82UM1" UniqueName="PS82UM1" ColumnGroupName="82" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS82UM2" UniqueName="PS82UM2" ColumnGroupName="82" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS82UM3" UniqueName="PS82UM3" ColumnGroupName="82" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS83UM1" UniqueName="PS83UM1" ColumnGroupName="83" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS83UM2" UniqueName="PS83UM2" ColumnGroupName="83" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS83UM3" UniqueName="PS83UM3" ColumnGroupName="83" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS84UM1" UniqueName="PS84UM1" ColumnGroupName="84" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS84UM2" UniqueName="PS84UM2" ColumnGroupName="84" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS84UM3" UniqueName="PS84UM3" ColumnGroupName="84" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                          
                                            </telerik:GridBoundColumn> 		                                         
                                        <telerik:GridBoundColumn DataField="PS85UM1" UniqueName="PS84UM1" ColumnGroupName="85" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS85UM2" UniqueName="PS84UM2" ColumnGroupName="85" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS85UM3" UniqueName="PS84UM3" ColumnGroupName="85" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="PS91UM1" UniqueName="PS91UM1" ColumnGroupName="91" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS91UM2" UniqueName="PS91UM2" ColumnGroupName="91" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS91UM3" UniqueName="PS91UM3" ColumnGroupName="91" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 				
                                            <telerik:GridBoundColumn DataField="PS92UM1" UniqueName="PS92UM1" ColumnGroupName="92" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS92UM2" UniqueName="PS92UM2" ColumnGroupName="92" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                           <telerik:GridBoundColumn DataField="PS92UM3" UniqueName="PS92UM3" ColumnGroupName="92" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 				
                                             <telerik:GridBoundColumn DataField="PS93UM1" UniqueName="PS93UM1" ColumnGroupName="93" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS93UM2" UniqueName="PS93UM2" ColumnGroupName="93" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                             <telerik:GridBoundColumn DataField="PS93UM3" UniqueName="PS93UM3" ColumnGroupName="93" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 				
                                            <telerik:GridBoundColumn DataField="PS94UM1" UniqueName="PS94UM1" ColumnGroupName="94" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS94UM2" UniqueName="PS94UM2" ColumnGroupName="94" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 					
                                            <telerik:GridBoundColumn DataField="PS94UM3" UniqueName="PS94UM3" ColumnGroupName="94" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 		
                                         <telerik:GridBoundColumn DataField="PS101UM1" UniqueName="PS101UM1" ColumnGroupName="95" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                         <telerik:GridBoundColumn DataField="PS101UM2" UniqueName="PS101UM2" ColumnGroupName="95" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="PS101UM3" UniqueName="PS101UM3" ColumnGroupName="95" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                            <telerik:GridBoundColumn DataField="PS102UM1" UniqueName="PS102UM1" ColumnGroupName="96" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                          <telerik:GridBoundColumn DataField="PS102UM2" UniqueName="PS102UM2" ColumnGroupName="96" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                          <telerik:GridBoundColumn DataField="PS102UM3" UniqueName="PS102UM3" ColumnGroupName="96" HeaderText="UM3">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 	
                                            <telerik:GridBoundColumn DataField="PS103UM1" UniqueName="PS103UM1" ColumnGroupName="97" HeaderText="UM1">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn> 
                                         <telerik:GridBoundColumn DataField="PS103UM2" UniqueName="PS103UM2" ColumnGroupName="97" HeaderText="UM2">
                                                 <HeaderStyle Width="100%" Font-Size="8" HorizontalAlign="Center" Font-Names="Arial"/>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="9" Font-Bold="true" ForeColor="Black" Font-Names="Arial"/>                                           
                                            </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="PS103UM3" UniqueName="PS103UM3" ColumnGroupName="97" HeaderText="UM3">
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
                                </Columns>
                                 </MasterTableView >
                                <PagerStyle Mode="Slider" Position="Top" PageSizeControlType="RadComboBox" PagerTextFormat="Change page: 
                                    {4} &amp;nbsp;Pagina &lt;strong&gt;{0}&lt;/strong&gt; de &lt;strong&gt;{1}&lt;/strong&gt;,registros &lt;strong&gt;{2}&lt;/strong&gt;a 
                                     &lt;strong&gt;{3}&lt;/strong&gt; de &lt;strong&gt;{5}&lt;/strong&gt;." PageSizeLabelText="Regitros"/>                                                  
                               </telerik:RadGrid>
        </div>
        <div id="Sicoin" runat="server">
            <telerik:RadGrid runat="server" ID="GdrSicoin" AutoGenerateColumns="False" Width="100%" AllowSorting ="false" AllowFilteringByColumn="false" AllowPaging="false" 
                                   GridLines="Both" Culture="es-GT" Skin="Office2007" ShowStatusBar ="True" ShowGroupPanel="false" Visible="false">                                       
                                     <GroupingSettings CaseSensitive="False" />
                                      <ClientSettings EnableRowHoverStyle="true" AllowColumnsReorder="True">
                                      <Selecting AllowRowSelect="True"></Selecting>                                      
                                     </ClientSettings>
                                   <MasterTableView DataKeyNames="Id_Componente,DescripcionComponente,Id_SubComponente,DescripcionSubComponente,Id_ProductoVeficable,DescripcionProductoVeficable,
                                       Id_MetasRedProgramatica,Id_NoPlanificable,Id_UM1,DescripcionUM1,Id_UM2,DescripcionUM2,Id_UM3,DescripcionUM3,Id_UnidadMedida,DescripcionUnidadMedida,
                                       EneroUM1,EneroUM2,EneroUM3,FebreroUM1,FebreroUM2,FebreroUM3,MarzoUM1,MarzoUM2,MarzoUM3,AbrilUM1,AbrilUM2,AbrilUM3,MayoUM1,MayoUM2,MayoUM3,JunioUM1,JunioUM2,
                                       EneroUM1,EneroUM2,EneroUM3,FebreroUM1,FebreroUM2,FebreroUM3,MarzoUM1,MarzoUM2,MarzoUM3,AbrilUM1,AbrilUM2,AbrilUM3,MayoUM1,MayoUM2,MayoUM3,JunioUM1,JunioUM2,
                                       JunioUM3,JulioUM1,JulioUM2,JulioUM3,AgostoUM1,AgostoUM2,AgostoUM3,SeptiembreUM1,SeptiembreUM2,SeptiembreUM3,OctubreUM1,OctubreUM2,OctubreUM3,NoviembreUM1,
                                       NoviembreUM2,NoviembreUM3,DiciembreUM1,DiciembreUM2,DiciembreUM3,SPCUM1,SPCUM2,SPCUM3,SSUM1,SSUM2,SSUM3,STUM1,STUM2,STUM3,CmaUM1,CmaUM2,CmaUM3" NoMasterRecordsText="Sin Información">                                       
                                        <RowIndicatorColumn Visible="False"></RowIndicatorColumn>
                                       <ColumnGroups>
                                            <telerik:GridColumnGroup HeaderText="Unidades de Medida -UM-" Name="UM">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Enero" Name="enero">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Febrero" Name="febrero">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Marzo" Name="marzo">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Abril" Name="abril">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Mayo" Name="mayo">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Junio" Name="junio">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Julio" Name="julio">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Agosto" Name="agosto">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Septiembre" Name="septiembre">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Octubre" Name="octubre">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Noviembre" Name="noviembre">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Diciembre" Name="diciembre">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Meta Consolidada" Name="CMA">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Primer Cuatrimestre" Name="MPC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                            <telerik:GridColumnGroup HeaderText="Segundo Cuatrimestre" Name="MSC">
                                                 <HeaderStyle Font-Size="10" HorizontalAlign="Center" Font-Bold="true" Font-Names="Arial"/>
                                            </telerik:GridColumnGroup>
                                           <telerik:GridColumnGroup HeaderText="Tercer Cuatrimestre" Name="MTC">
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
	                                        <telerik:GridBoundColumn DataField="DescripcionProductoVeficable" UniqueName="DescripcionProductoVeficable" HeaderText="Actvidades">
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
