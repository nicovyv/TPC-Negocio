﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentaRegistrada.aspx.cs" Inherits="presentacion.VentaRegistrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Venta registrada exitosamente</h2>



      <!-- CARD CLIENTE -->
  <div class="card mb-4 col-md-4 rounded-0">
      <div class="card-header">
          <h5 class="mb-0">Cliente</h5>
      </div>
      <div class="card-body">
          <p>Cliente</p>
          <asp:Label ID="lblNombreClienteVentaExito" runat="server" CssClass="d-block "></asp:Label>
          <p>CUIL-CUIT</p>
          <asp:Label ID="lblCuilVentaExito" runat="server" CssClass="d-block"></asp:Label>
          <p>N° Factura</p>
          <asp:Label ID="lblFacturaVenta" runat="server" Text=""></asp:Label>
          <p>Fecha</p>
          <asp:Label ID="lblFechaVentaExito" runat="server" Text=""></asp:Label>
      </div>
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
         <div class="mt-3">
                    <strong>Total: $</strong>
                    <asp:Label ID="lblTotalVentaRegistrada" runat="server"></asp:Label>
                </div>

    </div>

    <div>
        
        <a href="Ventas.aspx" class="mt-4 btn btn-primary btn-sm">Nueva Venta</a>
        <a href="Perfil.aspx" class="mt-4 btn btn-secondary btn-sm">Ir al Perfil</a>
    </div>

</asp:Content>
