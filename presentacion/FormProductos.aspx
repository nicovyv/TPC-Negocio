<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="presentacion.FormProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">
        <div class="card shadow-lg">
            <div class="card-header bg-primary text-white">
                <asp:Label
                    runat="server"
                    ID="lblTitulo"
                    CssClass="h4 bi bi-box-seam" Text="Formulario de Alta Producto">
                </asp:Label>
            </div>
            <div class="card-body">
                <!-- Campo: Código -->
                <div class="mb-3">
                    <label for="txtCodProd" class="form-label">Código</label>
                    <asp:TextBox runat="server" ID="txtCodProd" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCodProd" ErrorMessage="El campo es obligatorio." CssClass="text-danger" Display="Dynamic" />
                     <asp:Label runat="server" ID="lblErrorCodProd" Visible="false"></asp:Label>
                </div>

                <!-- Campo: Nombre -->
                <div class="mb-3">
                    <label for="txtNombreProd" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombreProd" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreProd" ErrorMessage="El campo es obligatorio." CssClass="text-danger" Display="Dynamic" />
                    <asp:Label runat="server" ID="lblErrorNombreProd" Visible="false"></asp:Label>
                </div>

                <!-- Campo: Descripción -->
                <div class="mb-3">
                    <label for="txtDescProd" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" ID="txtDescProd" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDescProd" ErrorMessage="El campo es obligatorio." CssClass="text-danger" Display="Dynamic" />
                    <asp:Label runat="server" ID="lblErrorDescProd" Visible="false"></asp:Label>
                </div>

                <!-- Marca y Categoría en 2 columnas -->
                <div class="row">
                    <div class="col-md-6 mb-3">
                        <label for="ddlMarcaProd" class="form-label">Marca</label>
                        <asp:DropDownList runat="server" ID="ddlMarcaProd" CssClass="form-select"></asp:DropDownList>
                    </div>
                    <div class="col-md-6 mb-3">
                        <label for="ddlCatProd" class="form-label">Categoría</label>
                        <asp:DropDownList runat="server" ID="ddlCatProd" CssClass="form-select"></asp:DropDownList>
                    </div>
                </div>

                <!-- Precios -->
                <div class="row">
                    <div class="col-md-6 mb-3" runat="server" id="divPrecioCompra">
                        <label for="txtPrecioCompraProd" class="form-label">Precio Compra</label>
                        <asp:TextBox runat="server" ID="txtPrecioCompraProd" CssClass="form-control" Enabled="false" />
                    </div>
                    <div class="col-md-6 mb-3" runat="server" id="divPrecioVenta">
                        <label for="txtPrecioVentaProd" class="form-label">Precio Venta</label>
                        <asp:TextBox runat="server" ID="txtPrecioVentaProd" CssClass="form-control" Enabled="false" />
                    </div>
                </div>

                <!-- Ganancia, Stock Mínimo, Stock Actual -->
                <div class="row">
                    <div class="col-md-4 mb-3">
                        <label for="txtGananciaProd" class="form-label">% Ganancia</label>
                        <asp:TextBox runat="server" ID="txtGananciaProd" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtGananciaProd" ErrorMessage="Campo requerido." CssClass="text-danger" Display="Dynamic" />
                        <asp:Label runat="server" ID="lblErrorGananciaProd" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-4 mb-3">
                        <label for="txtStockMinimoProd" class="form-label">Stock Mínimo</label>
                        <asp:TextBox runat="server" ID="txtStockMinimoProd" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txtStockMinimoProd" ErrorMessage="Campo requerido." CssClass="text-danger" Display="Dynamic" />
                         <asp:Label runat="server" ID="lblErrorStockMinimoProd" Visible="false"></asp:Label>
                    </div>
                    <div class="col-md-4 mb-3" runat="server" id="divStockActual">
                        <label for="txtStockActualProd" class="form-label">Stock Actual</label>
                        <asp:TextBox runat="server" ID="txtStockActualProd" CssClass="form-control" />
                    </div>
                </div>

                <!-- Proveedores -->
                <div class="mb-3">
                    <label class="form-label">Proveedores</label>
                    <asp:CheckBoxList ID="cblProveedoresProd" runat="server" CssClass="form-check" RepeatLayout="Flow" RepeatDirection="Vertical" />
                </div>

                <!-- Botones -->
                <div class="d-flex justify-content-between align-items-center mt-4">
                    <div>
                        <asp:Button ID="btnGuardarProd" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarProd_Click" />
                        <asp:Button ID="btnBajaProd" runat="server" Text="Dar de Baja" CssClass="btn btn-danger ms-2" Visible="false" OnClick="btnBajaProd_Click" />
                    </div>
                    <a href="Productos.aspx" class="btn btn-outline-secondary">Volver</a>
                </div>

                <asp:Label ID="lblMsjBajaProd" Visible="false" runat="server" CssClass="text-info mt-2 d-block" />
            </div>
        </div>
    </div>

</asp:Content>
