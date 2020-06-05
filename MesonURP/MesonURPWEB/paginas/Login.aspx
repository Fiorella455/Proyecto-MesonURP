<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MesonURPWEB.paginas.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-fields">
         
                <div class="field">
                    <label for="username">Correo:</label>
                    <input type="text" id="username" name="username" value="" placeholder="Usuario" class="login username-field" runat="server"/>
                    <asp:RegularExpressionValidator ID="RevCorreo" runat="server" ErrorMessage="correo incorrecto" ControlToValidate="username" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <!-- /field -->

                <div class="field">
                    <label for="password">Password:</label>
                    <input type="password" id="password" name="password" value="" placeholder="Contraseña" class="login password-field" runat="server"/>
                    <asp:RegularExpressionValidator ID="revContraseña" runat="server" ErrorMessage="Por favor ingrese solo letras o numeros" ControlToValidate="password" ForeColor="#CC0000" ValidationExpression="([a-zA-Z0-9]{1,})" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
        </div>
    </form>
</body>
</html>
