<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentaRegistrada.aspx.cs" Inherits="presentacion.VentaRegistrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Venta registrada exitosamente</h2>


    <div>
        <p>Cliente</p>
        <asp:Label ID="lblNombreClienteVentaExito" runat="server" Text=""></asp:Label>
        <p>CUIL-CUIT</p>
        <asp:Label ID="lblCuilVentaExito" runat="server" Text=""></asp:Label>
        <p>N° Factura</p>
        <asp:Label ID="lblFacturaVentaExito" runat="server" Text=""></asp:Label>
        <p>Fecha</p>
        <asp:Label ID="lblFechaVentaExito" runat="server" Text=""></asp:Label>
    </div>



    <h3>Detalle de la Venta</h3>
    <div class="col-8">


        <table class="table table-bordered">
            <thead>
                <tr>
                    <td scope="col" class="fw-bold">Código</td>
                    <td scope="col" class="fw-bold">Producto</td>
                    <td scope="col" class="fw-bold">Categoria</td>
                    <td scope="col" class="fw-bold">Marca</td>
                    <td scope="col" class="fw-bold">Precio Unitario</td>
                    <td scope="col" class="fw-bold">Cantidad</td>
                    <td scope="col" class="fw-bold">Subtotal</td>
                </tr>
            </thead>

            <tbody>
                <asp:Repeater runat="server" ID="repDetalleVentaRegistrada">
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("Producto.codigo")%></td>
                            <td><%#Eval("Producto.Nombre")%></td>
                            <td><%#Eval("Producto.Categoria.Descripcion")%></td>
                            <td><%#Eval("Producto.Marca.Descripcion")%></td>
                            <td><%#Eval("Producto.PrecioVenta")%></td>
                            <td><%#Eval("Cantidad")%></td>
                            <td><%#Eval("Subtotal")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>



    </div>

    <div>
        <asp:Button runat="server" Text="Nueva Venta" CssClass="mt-4 btn btn-primary btn-sm" />
        <asp:Button runat="server" Text="Ir al Perfil" CssClass="mt-4 btn btn-secondary btn-sm" />
    </div>

</asp:Content>
