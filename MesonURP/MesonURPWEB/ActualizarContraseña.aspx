<%@ Page Title="MesonURP | Cambiar Contraseña" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarContraseña.aspx.cs" Inherits="MesonURPWEB.ActualizarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
              <div class="grids">
                 <div class="progressbar-heading grids-heading title-flex">
                     <h2 class="tittle-margin5">Cambiar Contraseña</h2>
                   </div>
              </div>
              <div class="forms">
                  <div class="form-three widget-shadow">
                       <div class="form-horizontal" runat="server">
                           <div class="form-group">
                        <asp:Label ID="lblContraseñaA" runat="server" Text="Contraseña Actual" class="col-sm-2 control-label"></asp:Label>
&nbsp;                    <div class="col-sm-8">
                            <asp:TextBox ID="txtContraseñaAct" runat="server" CssClass="form-control1" type="password" ></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblContraseñaN" runat="server" Text="Nueva Contraseña" class="col-sm-2 control-label"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContraseñaN" runat="server" CssClass="form-control1"></asp:TextBox>
                        </div>
              </div>
                    <div class="form-group">
                         <asp:Label ID="lblContraseñaNR" runat="server" Text="Vuelve a escribir la contraseña" class="col-sm-2 control-label"></asp:Label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContraseñaNR" runat="server" CssClass="form-control1"></asp:TextBox>
                        </div>                           
                    </div>
                        </div> 
                       <p class="center-button">
        <asp:Button CssClass="btn btn-primary" runat="server" Text="Cambiar Contraseña" ID="btnCambiarCont" OnClick="btnCambiarCont_Click" />
        <asp:Label ID="lblMsj" runat="server"></asp:Label>
    </p>
                  </div>      
              </div>
                    
   
     
     
    
  </div>
    <script>
        function alertaCorrecto() {
            Swal.fire({
                 title: 'Contraseña Correcta',
                 text: 'Su contraseña ha sido verificada.',
                 icon: 'success',
                 confirmButtonText: 'Aceptar'
            })
        }
        function alertaAct() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Su contraseña ha sido cambiada satisfactoriamente.',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaNoAct() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Las contraseñas deben coincidir.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaWarning() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Debe escribir su contraseña.',
                icon: 'warning',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaIncorrecto() {
            Swal.fire({
                title: 'Contraseña Erronea',
                text: 'Su contraseña es incorrecta.',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "ActualizarContraseña";
                }
            })
        }
    </script>
</asp:Content>





