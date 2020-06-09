<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrarOC.aspx.cs" Inherits="MesonURPWEB.paginas.RegistrarOC" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
         <label for="cantidad">Cantidad</label>
    <input type="text" name="nombre">
    <br>
        <asp:DropDownList ID="ddlCategoria" runat="server">
        </asp:DropDownList>
        </br>
    
    <button class="btn" type="submit">Agregar</button>
    <button class="btn" type="submit">Quitar</button>
    </form>

</body>
</html>
