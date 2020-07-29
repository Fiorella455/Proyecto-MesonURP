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
                        <label for="focusedinput" class="col-sm-2 control-label">Contraseña Actual</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContraseñaAct" runat="server" CssClass="form-control1" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Nueva Contraseña</label>
                        <div class="col-sm-8">
                            <asp:TextBox ID="txtContraseñaN" runat="server" CssClass="form-control1"></asp:TextBox>
                        </div>
              </div>
                    <div class="form-group">
                        <label for="focusedinput" class="col-sm-2 control-label">Vuealve a escribir la contraseña</label>
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
</asp:Content>





