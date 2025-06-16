<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="presentacion.FormProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h2>Alta de Nuevo Producto</h2>
        <div class="col-6">
            <div class="mb-3 d-flex">
                <label for="txtCodProd" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtNombreProd" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombreProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtDescProd" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" ID="txtDescProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="ddlMarcaProd" class="form-label">Marca: </label>
                <asp:DropDownList runat="server" ID="ddlMarcaProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex">
                <label for="ddlCatProd" class="form-label">Categoria: </label>
                <asp:DropDownList runat="server" ID="ddlCatProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex" ID="divPrecioCompra" runat="server" >
                <label for="txtPrecioCompraProd" class="form-label">Precio Compra: </label>
                <asp:TextBox runat="server" ID="txtPrecioCompraProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex" ID="divPrecioVenta" runat="server" >
                <label for="txtPrecioVentaProd" class="form-label">Precio Venta: </label>
                <asp:TextBox runat="server" ID="txtPrecioVentaProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtGananciaProd" class="form-label">% Ganancia: </label>
                <asp:TextBox runat="server" ID="txtGananciaProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtStockMinimoProd" class="form-label">Stock Minimo: </label>
                <asp:TextBox runat="server" ID="txtStockMinimoProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex" ID="divStockActual" runat="server" >
                <label for="txtStockActualProd" class="form-label">Stock Actual: </label>
                <asp:TextBox runat="server" ID="txtStockActualProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtProveedoresPord" class="form-label">Proveedores: </label>
                <asp:CheckBoxList ID="cblProveedoresProd" RepeatDirection="Vertical" RepeatColumns="1" runat="server" CssClass="list-group"></asp:CheckBoxList>
            </div>

            <div class="mb-3">
                <asp:Button ID="btnGuardarProd" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarProd_Click" />
                <asp:Button ID="btnCancelarProd" runat="server" Text="Cancelar" CssClass="btn btn-secondary"  />
            </div>


        </div>
    </div>

</asp:Content>
