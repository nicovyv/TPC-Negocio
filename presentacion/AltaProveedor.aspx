<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="presentacion.AltaProveedor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="lblTitulo" CssClass="h2" Text="Formulario de Alta Proveedor"></asp:Label>
<div class="row">
    <div class="col-6">
        <div class="mb-3">
            <label for="txtNombreProveedor" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombreProveedor" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtCuilProveedor" class="form-label">Cuil/Cuit</label>
            <asp:TextBox runat="server" ID="txtCuilProveedor" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtDireccion" class="form-label">Direccion</label>
            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtTelefono" class="form-label">Telefono</label>
            <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />
        </div>
        <div class="mb-3">
            <label for="txtEmailProveedor" class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txtEmailProveedor" CssClass="form-control" placeholder="ejemplo@email.com" />
        </div>
        <div class="mb-3">
            <asp:Button class="btn btn-dark" Text="Registrar Proveedor" runat="server" ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" />
            <a class="btn btn-dark" href="Proveedores.aspx">Cancelar</a>
        </div>
    </div>
</div>

</asp:Content>
