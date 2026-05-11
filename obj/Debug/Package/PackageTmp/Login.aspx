<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PlanificacionPOA.Login" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Inicio del Sistema</title>    
    <link href="Login_Css/all.min.css" rel="stylesheet" />
    <link href="Login_Css/Login.css" rel="stylesheet" />
    <link href="Login_Css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="~/Icono.png" rel="shortcut icon" type="image/x-icon" /> 
</head>
     <script type="text/javascript"> 
         document.oncontextmenu = function () { return false }        
        window.history.forward(1); 
     </script>
<body class="bg-gradient-primary">      
     <telerik:RadWindowManager ID="RadWMensaje" runat="server" Skin="Office2007" EnableShadow="true" RenderMode="Classic"></telerik:RadWindowManager> 
     <form class="user" id="Inicio" runat="server">   
       <asp:ScriptManager runat="server"></asp:ScriptManager>
       <asp:UpdatePanel runat="server">
       <ContentTemplate>
    <div class="container">        
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                       
               <%--Version--%>
                 <B><font COLOR="green">03-03-26</font></B>
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">                         

                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-login-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-4">Sistema de Planificación, Evaluación y Seguimiento Institucional</h1><hr />
                                    </div>                                       
                                        <div class="form-group">
                                            <asp:TextBox ID="Usuario" runat="server"   
                                            placeholder="Introducir la dirección de correo electrónico...." TextMode="Email" class="form-control form-control-user"></asp:TextBox>                                          
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="Password" runat="server" class="form-control form-control-user" placeholder="Introducir la Contraseña" TextMode="Password"></asp:TextBox>                                             
                                        </div> <br />                                          
                                        <asp:Button ID="btnAceptar" runat="server" class="btn btn-success btn-user btn-block" Text="Entrar al Sistema"/>                                        
                                        <br /><hr/>
                                         <div class="text-center">
                                            <asp:LinkButton class="small" ID="lkbOlvide" runat="server">¿Olvide mi Contraseña?</asp:LinkButton>
                                        </div>                                                                            
                                </div>                            
                            </div>
                        </div>
                    </div>                   
                </div>
            </div>          
        </div>
    </div>  
    </ContentTemplate>
  </asp:UpdatePanel> 
  <asp:UpdateProgress ID="cargando" runat="server">
  <ProgressTemplate>
   <div id="Fondo" class="background">
 <div id="Progreso" class="Progress">                  
 </div>
  </div>       
  </ProgressTemplate>      
 </asp:UpdateProgress>          
 </form>
 </body>   
</html>
