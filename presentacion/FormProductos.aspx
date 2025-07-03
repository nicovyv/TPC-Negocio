<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="presentacion.FormProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">


        <div class="col-6 mt-4">
               <%-- TITULO--%>
            <div class="mb-3">
                <asp:Label
                    runat="server"
                    ID="lblTitulo"
                    CssClass="h1" Text="Formulario de Alta Producto">
                </asp:Label>
            </div>
            <%--COD PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="txtCodProd" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodProd" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorCodProd" Visible="false"></asp:Label>
            </div>
            <%--NOMBRE PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="txtNombreProd" class="form-label">Nombre: </label>
                <asp:TextBox runat="server" ID="txtNombreProd" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorNombreProd" Visible="false"></asp:Label>
            </div>
            <%--DESCRIPCION PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="txtDescProd" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" ID="txtDescProd" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorDescProd" Visible="false"></asp:Label>
            </div>
            <%--MARCA PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="ddlMarcaProd" class="form-label">Marca: </label>
                <asp:DropDownList runat="server" ID="ddlMarcaProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <%--CATEGORIA PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="ddlCatProd" class="form-label">Categoria: </label>
                <asp:DropDownList runat="server" ID="ddlCatProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <%--PRECIO COMPRA--%>
            <div class="mb-3 d-flex" id="divPrecioCompra" runat="server">
                <label for="txtPrecioCompraProd" class="form-label">Precio Compra: </label>
                <asp:TextBox runat="server" ID="txtPrecioCompraProd" CssClass="form-control" Enabled="false" />
            </div>
            <%--PRECIO VENTA--%>
            <div class="mb-3 d-flex" id="divPrecioVenta" runat="server">
                <label for="txtPrecioVentaProd" class="form-label">Precio Venta: </label>
                <asp:TextBox runat="server" ID="txtPrecioVentaProd" CssClass="form-control" Enabled="false" />
            </div>
            <%--GANANCIA PRODUCTO--%>
            <div class="mb-3 d-flex">
                <label for="txtGananciaProd" class="form-label">% Ganancia: </label>
                <asp:TextBox runat="server" ID="txtGananciaProd" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorGananciaProd" Visible="false"></asp:Label>
            </div>
            <%--STOCK MINIMO--%>
            <div class="mb-3 d-flex">
                <label for="txtStockMinimoProd" class="form-label">Stock Minimo: </label>
                <asp:TextBox runat="server" ID="txtStockMinimoProd" CssClass="form-control" />
                <asp:Label runat="server" ID="lblErrorStockMinimoProd" Visible="false"></asp:Label>
            </div>
            <%--STOCK ACTUAL--%>
            <div class="mb-3 d-flex" id="divStockActual" runat="server">
                <label for="txtStockActualProd" class="form-label">Stock Actual: </label>
                <asp:TextBox runat="server" ID="txtStockActualProd" CssClass="form-control" />
            </div>
            <%--PROVEEDORES--%>
            <div class="mb-3 d-flex">
                <label for="txtProveedoresPord" class="form-label">Proveedores: </label>
                <asp:CheckBoxList ID="cblProveedoresProd" RepeatDirection="Vertical" RepeatColumns="1" runat="server" CssClass="list-group"></asp:CheckBoxList>
            </div>
            <%--BOTONES GUARDAR PRODUCTO Y BAJA PRODUCTO--%>
            <div class="mb-3">
                <asp:Button ID="btnGuardarProd" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarProd_Click" />
                <%--<asp:Button ID="btnCancelarProd" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />--%>
                <a href="Productos.aspx" class="d-block m-2 float-end">Cancelar</a>
                <asp:Button ID="btnBajaProd" runat="server" Text="Dar de Baja" CssClass="btn btn-danger ms-2" Visible="false" OnClick="btnBajaProd_Click" />
            </div>


        </div>
    </div>

</asp:Content>
