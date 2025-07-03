<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="row justify-content-center align-items-center" style="min-height: 85vh;">

        <div class="col-10 col-sm-8 col-md-4 border border-primary rounded-1 p-4">
            <h3 class="mb-4 text-center">Crea tu usuario</h3>
            <div class="mb-3 row">
                <label for="txtEmail" class="col-sm-3 col-form-label col-form-label-sm">Email</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="txtEmail" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}" title="Por ejemplo: email@dominio.com" placeholder="Ingrese su email..." CssClass="form-control form-control-sm" />
                    <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="El campo Email es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                
            </div>
            <div class="mb-3 row">
                <label for="txtPassword" class="col-sm-3 col-form-label col-form-label-sm">Password</label>
                <div class="col-sm-9">
                 <asp:TextBox runat="server" type="password" ID="txtPassword" placeholder="Ingrese una contraseña..." CssClass="form-control form-control-sm" />
                 <asp:RequiredFieldValidator
                        runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="El campo Password es obligatorio."
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
            </div>
            <asp:Button OnClick="btnRegistrarse_Click" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary m-1 float-end" runat="server" />
            <a href="Bienvenida.aspx" class="d-block m-1 float-end btn btn-primary">Cancelar</a>
            <div class="mb-3 row">
                <asp:Label ID="lblExito" CssClass="align-items-center" runat="server" Visible="false" />
            </div>


        </div>
        <div>
        </div>

    </div>




</asp:Content>
