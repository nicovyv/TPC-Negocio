<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PassReset.aspx.cs" Inherits="presentacion.PassReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row justify-content-center align-items-center" style="min-height: 85vh;">
        <div class="col-10 col-sm-8 col-md-4 border border-primary rounded-1 p-4">
            <h3 class="mb-4 text-center">Reestablecé tu password</h3>
            <div class="mb-3 row">
                <label for="txtEmail" class="col-sm-3 col-form-label col-form-label-sm">Email</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" ID="txtEmail" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}" title="Por ejemplo: email@dominio.com" placeholder="email@dominio.com" AutoCompleteType="Email" CssClass="form-control form-control-sm" />
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label Text="Codigo" class="col-sm-3 col-form-label col-form-label-sm" id="lblCodigo" visible="false" runat="server" />                
                <div class="col-sm-9">
                    <asp:TextBox runat="server" type="text" ID="txtCodigo" visible="false"  CssClass="form-control form-control-sm" />
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label Text="Nueva Contraseña" class="col-sm-3 col-form-label col-form-label-sm" id="lblCambiar" visible="false" runat="server" />    
                <div class="col-sm-9">
                    <asp:TextBox runat="server" type="password" ID="txtPassword" visible="false" CssClass="form-control form-control-sm" />
                </div>
            </div>
            <div class="d-flex justify-content-between align-items-center mt-4">
                <asp:Button Text="Generar Código" ID="btnGenerar" CssClass="btn btn-primary float-end" OnClick="btnGenerar_Click" runat="server" />
                <asp:Button Text="Comprobar Código" ID="btnComprobar" CssClass="btn btn-primary float-end" visible="false"  OnClick="btnComprobar_Click" runat="server" />
                <asp:Button Text="Confirmar Password" ID="btnCambiar" CssClass="btn btn-primary float-end" visible="false"  OnClick="btnCambiar_Click" runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" Cssclass="btn btn-primary float-end" runat="server" OnClick="btnCancelar_Click"/>
                <asp:Button Text="Ir a tu Perfil" runat="server" Cssclass="btn btn-primary float-end" Visible="false" ID="btnPerfil" OnClick="btnPerfil_Click" />               

            </div>
            <div class="d-flex justify-content-between align-items-center mt-4">
                <asp:Label Text="¡Cambio de Password exitoso! Puede seguir navegando!" CssClass="alert alert-success" id="lblExito" runat="server" visible="false"/>
            </div>

        </div>

    </div>

</asp:Content>
