<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosVenta.aspx.cs" Inherits="presentacion.IngresarProductosVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- CARD CLIENTE -->
        <div class="card mb-4 col-md-4 rounded-0">
            <div class="card-header">
                <h5 class="mb-0">Cliente</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblNombreCliente" runat="server" CssClass="d-block "></asp:Label>
                <asp:Label ID="lblCuilCliente" runat="server" CssClass="d-block"></asp:Label>
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
                        <asp:Label ID="lblCatVenta" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                        <asp:DropDownList
                            ID="ddlCatVenta"
                            OnSelectedIndexChanged="ddlCatVenta_SelectedIndexChanged"
                            AutoPostBack="true"
                            runat="server"
                            CssClass="form-control" />

                        <small class="form-text text-muted">Seleccione una categoría</small>
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblProdVenta" runat="server" Text="Producto" CssClass="form-label"></asp:Label>
                        <asp:DropDownList
                            ID="ddlProdVenta"
                            runat="server"
                            AutoPostBack="true"
                            CssClass="form-control"
                            OnSelectedIndexChanged="ddlProdVenta_SelectedIndexChanged" />

                        <asp:Label ID="lblHelProdVenta" runat="server" class="form-text text-muted">Seleccione un producto</asp:Label>
                    </div>
                </div>
                <%-- SELECCIÓN DEL PRODUCTO --%>
                <div class="row mb-3 ">
                    <%--CANTIDADES DEL PRODUCTO--%>
                    <div class="col-md-4">
                        <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCantVenta" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:Label ID="lblHelpCantVenta" runat="server" class="form-text">Indique la cantidad</asp:Label>
                    </div>
                    <%--INFORMACIÓN DEL PRODUCTO--%>
                    <div class="col-md-4">
                        <p>Stock Disponible</p>
                        <asp:Label runat="server" CssClass="form" ID="lblStockProd" />
                        <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtProdStock"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <p>Precio Unitario</p>
                        <asp:Label runat="server" ID="lblPrecioProd" />
                        <asp:TextBox runat="server" ReadOnly="true" CssClass="form-control" ID="txtProdPrecio"></asp:TextBox>
                    </div>
                </div>

                <asp:Button ID="btnAgregarItemVenta" runat="server" Text="Agregar Producto" CssClass="btn btn-primary btn-sm" OnClick="btnAgregarItemVenta_Click" />
            </div>
        </div>

        <!-- PRODUCTOS AGREGADOS -->
        <div class="card mb-4 rounded-0">
            <div class="card-header">
                <h5 class="mb-0">Productos Agregados a la Venta</h5>
            </div>
            <div class="card-body">
                <asp:GridView ID="dgvDetalleVenta" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered" OnRowCommand="dgvDetalleVenta_RowCommand">
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
                                    runat="server"/>
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
        <asp:Label runat="server" ID="lblError" CssClass="form-label"></asp:Label>
        <!-- BOTONES -->
        <div class="mb-5">
            <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-success btn-sm me-2" OnClick="btnFinalizarVenta_Click" />
            <asp:Button ID="btnVolverVenta" runat="server" Text="Volver" CssClass="btn btn-secondary btn-sm" OnClick="btnVolverVenta_Click" />
        </div>
    </div>
</asp:Content>
