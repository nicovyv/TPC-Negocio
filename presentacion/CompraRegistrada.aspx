<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CompraRegistrada.aspx.cs" Inherits="presentacion.CompraRegistrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <!-- Título dinámico -->
        <div class="text-center mb-5">
            <asp:Label CssClass="h2 fw-bold" Text="text" ID="lblTitulo" runat="server" />
        </div>

        <!-- CARD PROVEEDOR -->
        <div class="row justify-content-start">
            <div class="card mb-5 col-md-6 col-lg-4 shadow-sm rounded-0">
                <div class="card-header bg-dark text-white">
                    <h5 class="mb-0">Proveedor</h5>
                </div>
                <div class="card-body">
                    <p class="mb-1 fw-semibold">Proveedor</p>
                    <asp:Label ID="lblNombreProveedorCompraExito" runat="server" CssClass="d-block mb-2"></asp:Label>

                    <p class="mb-1 fw-semibold">CUIL-CUIT</p>
                    <asp:Label ID="lblCuilCompraExito" runat="server" CssClass="d-block mb-2"></asp:Label>

                    <p class="mb-1 fw-semibold">Fecha</p>
                    <asp:Label ID="lblFechaCompra" runat="server" CssClass="d-block"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Detalle de la compra -->
        <div class="row mb-4">
            <div class="col-12">
                <h4 class="mb-3">Detalle de la Compra</h4>
                <table class="table table-striped table-bordered text-center">
                    <thead class="table-dark">
                        <tr>
                            <th scope="col">Código</th>
                            <th scope="col">Producto</th>
                            <th scope="col">Categoría</th>
                            <th scope="col">Marca</th>
                            <th scope="col">Precio Unitario</th>
                            <th scope="col">Cantidad</th>
                            <th scope="col">Subtotal</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater runat="server" ID="repDetalleCompraRegistrada">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Producto.codigo") %></td>
                                    <td><%# Eval("Producto.Nombre") %></td>
                                    <td><%# Eval("Producto.Categoria.Descripcion") %></td>
                                    <td><%# Eval("Producto.Marca.Descripcion") %></td>
                                    <td><%# Eval("PrecioUnidad") %></td>
                                    <td><%# Eval("Cantidad") %></td>
                                    <td><%# Eval("Subtotal") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>

                <!-- Total -->
                <div class="mt-3 text-end">
                    <strong>Total: $</strong>
                    <asp:Label ID="lblTotalCompraRegistrada" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Botones -->
        <div class="d-flex justify-content-end gap-2 mt-4">
            <a href="FormCompra.aspx" class="btn btn-primary btn-sm">Nueva Compra</a>
            <a href="Perfil.aspx" class="btn btn-secondary btn-sm">Ir al Perfil</a>
        </div>
    </div>
</asp:Content>
