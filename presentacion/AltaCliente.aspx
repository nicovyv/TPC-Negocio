<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="presentacion.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="d-flex justify-content-center">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblTitulo" CssClass="h2" Text="Formulario de Alta Cliente"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblValidarCuit" runat="server" Visible="false" CssClass="alert alert-danger" />
            </div>
            <div class="mb-3">
                <label for="txtNombreCliente" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombreCliente" maxlength="30" placeholder="Nombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCuilCliente" class="form-label">Cuil/Cuit</label>
                <asp:TextBox runat="server" ID="txtCuilCliente" MaxLength="13" placeholder="20-00000000-5" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtDireccion" class="form-label">Direccion</label>
                <asp:TextBox runat="server" ID="txtDireccion" maxlength="30" placeholder="Calle 1234, Localidad" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtTelefono" class="form-label">Telefono</label>
                <asp:TextBox runat="server" ID="txtTelefono" pattern="\d{10}" 
             title="Ingrese solo números, exactamente 10 dígitos" maxlength="10" placeholder="1130000000" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtTelefono"  class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmailCliente" title="Por ejemplo: email@dominio.com" maxlength="30" CssClass="form-control" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}" AutoCompleteType="Email" placeholder="email@dominio.com" />
            </div>
            <div class="mb-3">
                <asp:Button class="btn btn-dark" Text="Registrar Cliente" runat="server" ID="btnAgregarCliente" OnClick="btnAgregarCliente_Click" />
                <a class="btn btn-dark" href="Clientes.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
