<%@ Page Title="Gestionar Categoría | Actualizar" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ActualizarCategoria.aspx.cs" Inherits="MesonURPWEB.ActualizarCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Actualizar Categoría</h2>
            </div>
        </div>
     <div class="forms">
            <h3 class="title1"></h3>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <asp:TextBox ID="txt1" runat="server" Visible="False"></asp:TextBox>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Categoría</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control1" onkeypress="return soloLetras(event);"/>
                           <%-- <asp:RegularExpressionValidator ID="revNombreC" runat="server" ErrorMessage="Por favor ingrese solo letras" ControlToValidate="txtCategoria" ForeColor="#CC0000" ValidationExpression="^[a-zA-Z_áéíóúñ\s]*$" SetFocusOnError="True" Display="Dynamic"></asp:RegularExpressionValidator>--%>
                            <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="txtCategoria" ErrorMessage="Campo Obligatorio" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                     <hr />
                    <p class="center-button">
                        <asp:Button ID="btnActualizar" CssClass="btn btn-primary" runat="server" Text="Actualizar Categoría" OnClick="btnActualizarCategoria_Click" />
                        <input type="button" name="sub-1" value="Regresar" onclick="location.href = 'GestionarCategoria';" class="btn btn-primary" />
                        <%--<asp:Button ID="btnCancelar" class="btn btn-danger" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="False" />--%>
                        <input type="reset" name="res-1" id="res-1" value="Limpiar" class="btn btn-danger" />
                    </p>
                </div>
              </div>
            </div>
        </div>
    <script>
        function soloLetras(e) {
            key = e.keyCode || e.which;
            tecla = String.fromCharCode(key).toLowerCase();
            letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
            especiales = [8, 37, 39, 46];

            tecla_especial = false
            for (var i in especiales) {
                if (key == especiales[i]) {
                    tecla_especial = true;
                    break;
                }
            }

            if (letras.indexOf(tecla) == -1 && !tecla_especial)
                return false;
        }

    </script>
    
    <script src="js/sweetalert.js"></script>
    <script>
        function myalertCat() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'Ya existe una categoría con el nombre',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertActualizacion1() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'La categoría fue actualizado correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = 'GestionarCategoria.aspx';
                }
            })
        }
    </script>
</asp:Content>