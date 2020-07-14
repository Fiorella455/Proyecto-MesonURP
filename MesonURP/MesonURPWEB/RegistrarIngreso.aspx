<%@ Page Title="Manejar Stock | Registrar Ingreso" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistrarIngreso.aspx.cs" Inherits="MesonURPWEB.RegistrarIngreso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="women_main">
        <!-- start content -->
        <div class="grids">
            <div class="progressbar-heading grids-heading title-flex">
                <h2 class="tittle-margin5">Registrar Ingreso</h2>
            </div>
        </div>
        <div class="forms">
            <h3 class="title1"></h3>
            <asp:UpdatePanel ID="panelIngreso" runat="server">
                       <ContentTemplate>
            <div class="form-three widget-shadow">
                <div class="form-horizontal" runat="server">
                    <div class="form-group">
                        <label for="selector1" class="col-sm-2 control-label">Insumo</label>
                        <div class="col-sm-8">
                            <asp:DropDownList ID="ddlInsumos" runat="server" CssClass="form-control1" type="button" data-toggle="dropdown" AutoPostBack="true" OnSelectedIndexChanged="Selection_Change" aria-haspopup="true">
                                <asp:ListItem Text="" Value="">ss</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="validationInsumos" runat="server" ControlToValidate="ddlInsumos" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Fecha</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled="false" ID="txtFecha2" runat="server" CssClass="form-control1" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha2" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtCantidad2" runat="server" placeholder="Seleccione la cantidad" CssClass="form-control1" onkeypress="return SoloNumeroIntDouble(event);" MaxLength="5"/>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCantidad2" ErrorMessage="Campo Obligatorio" ValidationGroup="registrarIngreso" CssClass="required-item" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Cantidad máxima a Ingresar</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled="false" ID="txtOculto" runat="server" CssClass="form-control1" placeholder="Cantidad máxima a egresar" />
                    </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Unidad de Medida</label>
                        <div class="col-sm-8">
                            <asp:TextBox disabled="True" ID="txtUnidadMedida2" runat="server" placeholder="Unidad de Medida" CssClass="form-control1" />
                    </div>
                    </div>
                    <asp:UpdatePanel ID="PanelAñadir" runat="server">
                        <ContentTemplate>
                            <p class="center-button">
                                <asp:Button CssClass="btn btn-primary" runat="server" Text="Añadir" ID="btnAñadirInsumo" OnClick="btnAñadirInsumo_Click"/>
                                <input type="button" name="res1" value="Limpiar" runat="server" onserverclick="btnLimpiar_ServerClick" class="btn btn-danger" />
                            </p>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div class="panel panel-widget forms-panel">
                    <div class="form-grids widget-shadow" data-example-id="basic-forms">
                        <div class="form-title color-white">
                            <h4>Insumos a Ingresar</h4>
                        </div>
                    <%--<asp:UpdatePanel ID="panelIngreso" runat="server">
                       <ContentTemplate>--%>
                        <div class="table-wrapper-scroll-y my-custom-scrollbar">
                             <asp:GridView ID="gvInsumosIngreso" AllowPaging="True" runat="server" EmptyDataText="No hay información disponible." AutoGenerateColumns="false"
                                DataKeyNames="Fecha,Nombre insumo,Cantidad,Unidad de Medida" 
                                CssClass="table table-bordered table-striped mb-0" Style="text-align: center" CellPadding="4" GridLines="None" OnSelectedIndexChanged="gvInsumosIngreso_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Fecha" Datafield="Fecha" />
                                    <asp:BoundField HeaderText="Nombre insumo" Datafield="Nombre insumo" />
                                    <asp:BoundField HeaderText="Cantidad" Datafield="Cantidad" />
                                    <asp:BoundField HeaderText="Unidad de Medida" Datafield="Unidad de Medida" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <hr />
                                <p class="center-button">
                                    <button type="button" name="sub-1" class="btn btn-primary" runat="server" id="btnIngresar" onserverclick="btnIngresar_ServerClick">Ingresar</button>
                                    <input type="button" name="sub-1" value="Regresar" runat="server" onclick="location.href = 'ManejarStock';" onserverclick="btnRegresar_ServerClick" class="btn btn-primary" />
                                    <asp:Button CssClass="btn btn-primary" runat="server" Text="Quitar" OnClick="btnQuitarInsumo_Click" />
                                </p>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
                           </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
    </div>
    <!-- Validaciones -->
    <script>
        function SoloNumeroIntDouble(ev) {
            var tecla = (document.all) ? ev.keyCode : ev.which;
            if (tecla == 8 || tecla == 13 || tecla == 0) return true;
            if (tecla >= 8226 && tecla <= 10175) { return false; }
            var regEx = /^[0-9\.]+$/i;
            return regEx.test(String.fromCharCode(tecla));
        }
    </script>
    <!-- Alertas -->
    <script src="js/sweetalert.js"></script>
    <script>
        function alertaCantidad() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'La cantidad de insumos no es permitida',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaDuplicado() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No puedes añadir el mismo Insumo',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaError() {
            Swal.fire({
                title: 'Oh, no!',
                text: 'No has añadido ningún Insumo',
                icon: 'error',
                confirmButtonText: 'Aceptar'
            })
        }
        function alertaExito() {
            Swal.fire({
                title: 'Enhorabuena!',
                text: 'Se ha logrado ingresar correctamente',
                icon: 'success',
                confirmButtonText: 'Aceptar'
            }).then((result) => {
                if (result.value) {
                    window.location.href = "ManejarStock";
                }
            })
        }
    </script>
</asp:Content>
