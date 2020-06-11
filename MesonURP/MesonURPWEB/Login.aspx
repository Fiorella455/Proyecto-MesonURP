<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MesonURPWEB.paginas.WebForm1"%> 
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <title>Login - Bootstrap Admin Template</title>

    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="apple-mobile-web-app-capable" content="yes">

    <link href="../css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css"/>
   
    <link href="../css/font-awesome.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet">

    <link href="../css/style.css" rel="stylesheet" type="text/css">
    <link href="../css/pages/signin.css" rel="stylesheet" />
</head>

<body>

    <div class="navbar navbar-fixed-top">

        <div class="navbar-inner">

            <div class="container">
                <a class="brand">MesónURP		
                </a>
            </div>
            <!-- /container -->

        </div>
        <!-- /navbar-inner -->

    </div>
    <!-- /navbar -->



    <div class="account-container">

        <div class="content clearfix">

            <form id="form1" runat="server">

                <h1>Bienvenido</h1>

                <div class="login-fields">

                    <p><asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="#CC0000"></asp:Label></p>
                    <div class="content"> <asp:Label ID="lblMensajeAyuda" runat="server" Text=""></asp:Label> </div>

                    <div class="field">
                        <label for="correo">Correo</label>
                        <input type="text" id="correo" name="correo" value="" placeholder="Correo" class="login username-field" runat="server"/>
                        <asp:RegularExpressionValidator ID="RevCorreo" runat="server" ErrorMessage="Por favor ingrese su correo" ControlToValidate="correo" ForeColor="#CC0000" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <!-- /field -->

                    <div class="field">
                        <label for="contraseña">Contraseña:</label>
                        <input type="password" id="contraseña" name="contraseña" value="" placeholder="Contraseña" class="login password-field" runat="server"/>
                        <asp:RegularExpressionValidator ID="revContraseña" runat="server" ErrorMessage="Por favor ingrese solo letras o números" ControlToValidate="contraseña" ForeColor="#CC0000" ValidationExpression="([a-zA-Z0-9]{1,})" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    <!-- /password -->

                </div>
                <!-- /login-fields -->

                <div class="login-actions">

                    <asp:Button ID="btnLogin" class="button btn btn-success btn-large" runat="server" Text="Ingresar" OnClick="btnLogin_Click" />
                    
                </div>
                <!-- .actions -->



            </form>

        </div>
        <!-- /content -->

    </div>
    <!-- /account-container -->


    <script src="../js1/jquery-1.7.2.min.js"></script>
    <script src="../js1/bootstrap.js"></script>
    <script src="../js1/signin.js"></script>

    </body>
</html>