<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosCompra.aspx.cs" Inherits="presentacion.IngresarProductosCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- CARD PROVEEDOR -->
        <div class="card shadow mb-4 col-md-4 p-0">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Proveedor</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblNombreProveedor" runat="server" CssClass="d-block fw-bold"></asp:Label>
                <asp:Label ID="lblCuilProveedor" runat="server" CssClass="d-block text-muted"></asp:Label>
            </div>
        </div>

        <!-- INGRESAR PRODUCTOS -->
        <div class="card shadow mb-4">
            <div class="card-header bg-primary text-white">
                <h5 class="mb-0">Ingresar Productos</h5>
            </div>
            <div class="card-body">
                <!-- SELECCIÓN DEL PRODUCTO -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblCatCompra" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlCatCompra" AutoPostBack="true" OnSelectedIndexChanged="ddlCatCompra_SelectedIndexChanged" runat="server" CssClass="form-control" />
                        <small class="form-text text-muted">Seleccione una categoría</small>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblProdCompra" runat="server" Text="Producto" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlProdCompra" AutoPostBack="true" OnSelectedIndexChanged="ddlProdCompra_SelectedIndexChanged" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblHelProdCompra" runat="server" CssClass="form-text text-muted">Seleccione un producto</asp:Label>
                    </div>
                </div>

                <!-- CANTIDAD Y DATOS DEL PRODUCTO -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <asp:Label ID="lblCantCompra" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCantCompra" runat="server" CssClass="form-control" pattern="^[1-9]\d*$" title="Ingrese solo números enteros positivos"></asp:TextBox>
                        <asp:Label ID="lblHelpCantCompra" runat="server" CssClass="form-text">Indique la cantidad</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Stock Actual</label>
                        <asp:Label runat="server" ID="lblStockProd" CssClass="form-text" />
                        <asp:TextBox runat="server" ID="txtProdStock" Enabled="false" CssClass="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Stock Mínimo</label>
                        <asp:Label runat="server" ID="lblMinimo" CssClass="form-text" />
                        <asp:TextBox runat="server" ID="txtMinimo" Enabled="false" CssClass="form-control" />
                    </div>
                    <div class="col-md-4 mt-3">
                        <label class="form-label">Precio Unitario</label>
                        <asp:Label runat="server" ID="lblPrecioProd" CssClass="form-text" />
                        <asp:TextBox ID="txtProdPrecio" runat="server" CssClass="form-control" pattern="^[1-9]\d*$" title="Ingrese solo números enteros positivos" />
                        <asp:Label ID="lblPrecioMsj" runat="server" CssClass="form-text text-muted"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="btnAgregarItemCompra" runat="server" Text="Agregar Producto" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarItemCompra_Click" />
            </div>
        </div>

        <!-- PRODUCTOS AGREGADOS -->
        <div class="card shadow mb-4">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Productos Agregados a la Compra</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="dgvDetalleCompra" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered text-center" OnRowCommand="dgvDetalleCompra_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <%# Eval("Producto.Codigo") %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnidad" />
                        <asp:BoundField HeaderText="SubTotal" DataField="Subtotal" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button ID="btnEliminarItem" Text="Eliminar" CssClass="btn btn-secondary btn-sm me-2"
                                    CommandName="Eliminar" CommandArgument='<%# Eval("Producto.Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="mt-3">
                    <strong>Total: </strong>
                    <asp:Label ID="lbltotalCompra" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lbltotalCompraValor" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- MENSAJE DE ERROR -->
        <asp:Label runat="server" ID="lblError" CssClass="form-label text-danger"></asp:Label>

        <!-- BOTONES -->
        <div class="mb-5">
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-success btn-sm me-2" OnClick="btnFinalizarCompra_Click" Enabled="false" />
            <asp:Button ID="btnVolverCompra" runat="server" Text="Volver" CssClass="btn btn-secondary btn-sm" OnClick="btnVolverCompra_Click" />
        </div>
    </div>
</asp:Content>
