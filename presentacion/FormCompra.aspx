<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="presentacion.FormCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>Formulario de Compra</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtCompraProducto" class="form-label">Producto</label>
                <asp:DropDownList runat="server"></asp:DropDownList>
            </div>
          <div class="mb-3">
                <label for="txtCompraProveedor" class="form-label">Proveedor</label>
                <asp:DropDownList runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCompraCantidad" class="form-label">Cantidad</label>
                <asp:textbox runat="server" ID="txtCompraCantidad" cssclass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCompraPrecioUnit" class="form-label">Precio Unitario</label>
                <asp:textbox runat="server" ID="txtCompraPrecioUnit" cssclass="form-control" />
            </div>
            <asp:button text="Registrar Compra" runat="server" ID="btnAgregarCliente"/>
                    <a href="Compras.aspx">Cancelar</a>
        </div>
    </div>

</asp:Content>
