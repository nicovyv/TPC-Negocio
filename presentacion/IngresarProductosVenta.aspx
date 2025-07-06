<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosVenta.aspx.cs" Inherits="presentacion.IngresarProductosVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- CARD CLIENTE -->
        <div class="card shadow mb-4 col-md-4 p-0">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Cliente</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblNombreCliente" runat="server" CssClass="d-block fw-bold"></asp:Label>
                <asp:Label ID="lblCuilCliente" runat="server" CssClass="d-block text-muted"></asp:Label>
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
                        <asp:Label ID="lblCatVenta" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlCatVenta" AutoPostBack="true" OnSelectedIndexChanged="ddlCatVenta_SelectedIndexChanged" runat="server" CssClass="form-control" />
                        <small class="form-text text-muted">Seleccione una categoría</small>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblProdVenta" runat="server" Text="Producto" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlProdVenta" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlProdVenta_SelectedIndexChanged" />
                        <asp:Label ID="lblHelProdVenta" runat="server" CssClass="form-text text-muted">Seleccione un producto</asp:Label>
                    </div>
                </div>

                <!-- CANTIDAD Y DATOS DEL PRODUCTO -->
                <div class="row mb-3">
                    <div class="col-md-4">
                        <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCantVenta" runat="server" CssClass="form-control" />
                        <asp:Label ID="lblHelpCantVenta" runat="server" CssClass="form-text">Indique la cantidad</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Stock Disponible</label>
                        <asp:Label runat="server" ID="lblStockProd" CssClass="form-text" />
                        <asp:TextBox runat="server" ID="txtProdStock" ReadOnly="true" CssClass="form-control" />
                    </div>
                    <div class="col-md-4">
                        <label class="form-label">Precio Unitario</label>
                        <asp:Label runat="server" ID="lblPrecioProd" CssClass="form-text" />
                        <asp:TextBox runat="server" ID="txtProdPrecio" ReadOnly="true" CssClass="form-control" />
                    </div>
                </div>

                <asp:Button ID="btnAgregarItemVenta" runat="server" Text="Agregar Producto" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarItemVenta_Click" />
            </div>
        </div>

        <!-- PRODUCTOS AGREGADOS -->
        <div class="card shadow mb-4">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0">Productos Agregados a la Venta</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="dgvDetalleVenta" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered text-center" OnRowCommand="dgvDetalleVenta_RowCommand">
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
                    <asp:Label ID="lbltotalVenta" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lbltotalVentaValor" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- MENSAJE DE ERROR -->
        <asp:Label ID="lblError" runat="server" CssClass="form-label text-danger"></asp:Label>

        <!-- BOTONES DE ACCIÓN -->
        <div class="mb-5">
            <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-success btn-sm me-2" OnClick="btnFinalizarVenta_Click"  />
            <asp:Button ID="btnVolverVenta" runat="server" Text="Volver" CssClass="btn btn-secondary btn-sm" OnClick="btnVolverVenta_Click" />
        </div>
    </div>
</asp:Content>
