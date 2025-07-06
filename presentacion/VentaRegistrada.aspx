<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentaRegistrada.aspx.cs" Inherits="presentacion.VentaRegistrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <!-- Título -->
        <div class="text-center mb-5">
            <h2 class="fw-bold">Detalle de Venta</h2>
        </div>

        <!-- CARD CLIENTE -->
        <div class="row justify-content-start">
            <div class="card mb-5 col-md-6 col-lg-4 shadow-sm rounded-0">
                <div class="card-header bg-dark text-white">
                    <h5 class="mb-0">Cliente</h5>
                </div>
                <div class="card-body">
                    <p class="mb-1 fw-semibold">Cliente</p>
                    <asp:Label ID="lblNombreClienteVentaExito" runat="server" CssClass="d-block mb-2"></asp:Label>

                    <p class="mb-1 fw-semibold">CUIL-CUIT</p>
                    <asp:Label ID="lblCuilVentaExito" runat="server" CssClass="d-block mb-2"></asp:Label>

                    <p class="mb-1 fw-semibold">N° Factura</p>
                    <asp:Label ID="lblFacturaVenta" runat="server" CssClass="d-block mb-2"></asp:Label>

                    <p class="mb-1 fw-semibold">Fecha</p>
                    <asp:Label ID="lblFechaVentaExito" runat="server" CssClass="d-block"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Detalle de la venta -->
        <div class="row mb-4">
            <div class="col-12">
                <h4 class="mb-3">Detalle de la Venta</h4>
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
                        <asp:Repeater runat="server" ID="repDetalleVentaRegistrada">
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("Producto.codigo") %></td>
                                    <td><%# Eval("Producto.Nombre") %></td>
                                    <td><%# Eval("Producto.Categoria.Descripcion") %></td>
                                    <td><%# Eval("Producto.Marca.Descripcion") %></td>
                                    <td><%# Eval("Producto.PrecioVenta") %></td>
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
                    <asp:Label ID="lblTotalVentaRegistrada" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- Botones -->
        <div class="d-flex justify-content-end gap-2 mt-4">
            <a href="Ventas.aspx" class="btn btn-primary btn-sm">Nueva Venta</a>
            <a href="Perfil.aspx" class="btn btn-secondary btn-sm">Ir al Perfil</a>
        </div>
    </div>

</asp:Content>
