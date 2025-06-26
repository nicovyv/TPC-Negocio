<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="presentacion.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Ventas</h1>
        <!-- Buscador de cliente -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtBuscador" class="form-label">CUIT O CUIL Del Cliente</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscadorCliente" placeholder="Ingrese Cuil o Cuit del cliente" runat="server" CssClass="form-control" AutoPostBack="true" />
                    <asp:Button Text="Asignar cliente" ID="btnAsignarCliente" OnClick="btnAsignarCliente_Click" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
        <!-- DATOS de cliente -->
        <asp:Label CssClass="form-label" runat="server" ID="lblCUIT"></asp:Label>
        <asp:Label CssClass="form-label" runat="server" ID="lblNombre"></asp:Label>


        <div class="row">
            <div class="col-6">
                <asp:Label ID="lblProdVenta" runat="server" Text="Producto"></asp:Label>
                <asp:DropDownList ID="ddlProdVenta" runat="server"></asp:DropDownList>
            </div>
            <div class="col-6">
                <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantVenta" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnAgregarItemVenta" runat="server" Text="Agregar" />

        </div>

        <h3>Detalle de la Venta</h3>
        <div>
            <asp:GridView ID="dgvDetalleVenta" runat="server">

                <Columns>
                    <asp:BoundField HeaderText="Producto" DataField="Producto" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioVenta" />
                </Columns>

            </asp:GridView>


        </div>

    </div>





</asp:Content>
