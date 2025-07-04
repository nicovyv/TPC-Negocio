<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosCompra.aspx.cs" Inherits="presentacion.IngresarProductosCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- CARD Proveedor -->
        <div class="card mb-4 col-md-4 rounded-0">
            <div class="card-header">
                <h5 class="mb-0">Proveedor</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblNombreProveedor" runat="server" CssClass="d-block "></asp:Label>
                <asp:Label ID="lblCuilProveedor" runat="server" CssClass="d-block"></asp:Label>
            </div>
        </div>

        <!-- INGRESAR PRODUCTOS -->
        <div class="card mb-4 rounded-0">
            <div class="card-header">
                <h5 class="mb-0">Ingresar Productos</h5>
            </div>
            <div class="card-body">
                <%-- SELECCIÓN DEL PRODUCTO --%>
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblCatCompra" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                        <asp:DropDownList
                            ID="ddlCatCompra" OnSelectedIndexChanged="ddlCatCompra_SelectedIndexChanged"
                            AutoPostBack="true"
                            runat="server"
                            CssClass="form-control" />

                        <small class="form-text text-muted">Seleccione una categoría</small>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblProdCompra" runat="server" Text="Producto" CssClass="form-label"></asp:Label>
                        <asp:DropDownList
                            ID="ddlProdCompra" OnSelectedIndexChanged="ddlProdCompra_SelectedIndexChanged"
                            runat="server"
                            AutoPostBack="true"
                            CssClass="form-control" />

                        <asp:Label ID="lblHelProdCompra" runat="server" class="form-text text-muted">Seleccione un producto</asp:Label>
                    </div>
                </div>
                <%-- SELECCIÓN DEL PRODUCTO --%>
                <div class="row mb-3 ">
                    <%--CANTIDADES DEL PRODUCTO--%>
                    <div class="col-md-4">
                        <asp:Label ID="lblCantCompra" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCantCompra" runat="server" pattern="^[1-9]\d*$" title="Ingrese solo números enteros positivos" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblHelpCantCompra" runat="server" class="form-text">Indique la cantidad</asp:Label>
                    </div>
                    <%--INFORMACIÓN DEL PRODUCTO--%>
                    <div class="col-md-4">
                        <p>Stock Actual</p>
                        <asp:Label runat="server" CssClass="form" ID="lblStockProd" />
                        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" ID="txtProdStock"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p>Stock Minimo</p>
                        <asp:Label runat="server" CssClass="form" ID="lblMinimo" />
                        <asp:TextBox runat="server" CssClass="form-control" Enabled="false" ID="txtMinimo"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p>Precio Unitario</p>
                        <asp:Label runat="server" ID="lblPrecioProd" />
                        <asp:TextBox runat="server" pattern="^[1-9]\d*$" title="Ingrese solo números enteros positivos" CssClass="form-control" ID="txtProdPrecio"></asp:TextBox>
                        <asp:Label ID="lblPrecioMsj" runat="server" class="form-text"></asp:Label>
                    </div>
                </div>

                <asp:Button ID="btnAgregarItemCompra" runat="server" Text="Agregar Producto" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarItemCompra_Click" />
            </div>
        </div>

        <!-- PRODUCTOS AGREGADOS -->
        <div class="card mb-4 rounded-0">
            <div class="card-header">
                <h5 class="mb-0">Productos Agregados a la Compra</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="dgvDetalleCompra" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered" OnRowCommand="dgvDetalleCompra_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <%# Eval("Producto.Codigo")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField HeaderText="Código" DataField="Producto.Codigo" />--%>
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnidad" />
                        <asp:BoundField HeaderText="SubTotal" DataField="Subtotal" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button
                                    ID="btnEliminarItem"
                                    Text="Eliminar"
                                    CssClass="btn btn-secondary btn-sm me-2"
                                    CommandName="Eliminar"
                                    CommandArgument='<%# Eval("Producto.Id")%>'
                                    runat="server" />
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
        <asp:Label runat="server" ID="lblError" CssClass="form-label"></asp:Label>
        <!-- BOTONES -->
        <div class="mb-5">
            <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-success btn-sm me-2" OnClick="btnFinalizarCompra_Click" />
            <asp:Button ID="btnVolverCompra" runat="server" Text="Volver" CssClass="btn btn-secondary btn-sm" OnClick="btnVolverCompra_Click" />
        </div>
    </div>
</asp:Content>
