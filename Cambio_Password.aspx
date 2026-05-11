<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cambio_Password.aspx.cs" Inherits="PlanificacionPOA.Cambio_Password" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>Cambio de Contraseña</title>
  <link href="Login_Css/all.min.css" rel="stylesheet" />
  <link href="Login_Css/Login.css" rel="stylesheet" />
  <link href="Login_Css/sb-admin-2.min.css" rel="stylesheet" />
</head>
    <script type="text/javascript"> 
    document.oncontextmenu = function () { return false }
    window.history.forward(1); 
    </script>
<body class="bg-gradient-primary">
 <form class="user" id="Cambio" runat="server">
 <asp:ScriptManager runat="server"></asp:ScriptManager>
 <telerik:RadWindowManager ID="RadWMensaje" runat="server" Skin="Office2007" EnableShadow="true" RenderMode="Lightweight"></telerik:RadWindowManager> 
  <asp:UpdatePanel runat="server">
  <ContentTemplate>     
    <div class="container">        
        <div class="row justify-content-center">
            <div class="col-xl-10 col-lg-12 col-md-9">
                <div class="card o-hidden border-0 shadow-lg my-5">
                    <div class="card-body p-0">                       
                        <div class="row">
                            <div class="col-lg-6 d-none d-lg-block bg-password-image"></div>
                            <div class="col-lg-6">
                                <div class="p-5">
                                    <div class="text-center">
                                        <h1 class="h4 text-gray-900 mb-2">Cambio de Contraseña</h1>
                                        <p class="mb-4">Debe de cambiar la contraseña que se le envio
                                            al correo electronico por una nueva,para poder entrar al sistema.</p>
                                    </div>                                     
                                        <div class="form-group">
                                            <asp:TextBox ID="Password1" runat="server" class="form-control  form-control-user" placeholder="Nueva Contraseña" TextMode="Password"></asp:TextBox>                                            
                                        </div>
                                        <div class="form-group">
                                            <asp:TextBox ID="Password2" runat="server" class="form-control form-control-user" placeholder="Confirmar Contraseña" TextMode="Password"></asp:TextBox>                                            
                                        </div>
                                         <asp:Button ID="btnAceptar" runat="server" class="btn btn-success btn-user btn-block" Text="Cambiar Contraseña"/><hr />
                                         <div class="text-center">
                                         <asp:Button ID="btnCancelar" runat="server" class="btn btn-danger btn-user btn-block" Text="Cancelar"/>
                                    </div><hr/>
                                             <div id="mensaje" style="align-items:center;" runat="server" class="alert alert-warning" role="alert" visible="false">
                                                 Se ha Cambiado la contraseña de su usuario</div>                                                                               
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

