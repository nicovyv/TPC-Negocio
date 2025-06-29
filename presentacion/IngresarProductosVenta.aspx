<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosVenta.aspx.cs" Inherits="presentacion.IngresarProductosVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">

        <!-- CLIENTE -->
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
                <div class="row mb-3">
                    <div class="col-md-6">
                        <asp:Label ID="lblCatVenta" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlCatVenta" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList>
                       
                    </div>
                    <div class="col-md-6">
                        <asp:Label ID="lblProdVenta" runat="server" Text="Producto" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="ddlProdVenta" runat="server" CssClass="form-control"></asp:DropDownList>
                        <asp:Label id="lblHelProdVenta" runat="server" class="form-text">Seleccione un producto</asp:Label>
                    </div>
                </div>

                <div class="row mb-3 ">
                    <div class="col-md-4">
                        <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="txtCantVenta" runat="server" CssClass="form-control"></asp:TextBox>
                     <asp:Label id="lblHelpCantVenta" runat="server" class="form-text">Indique la cantidad</asp:Label>
                    </div>
                    <div class="col-md-4">
                        <p>Stock Disponible</p> <asp:Label  runat="server" ID="lblStockProd"/>
                    </div>
                    <div class="col-md-4">
                        <p>Precio Unitario</p> <asp:Label  runat="server" ID="lblPrecioProd"/>
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
                    CssClass="table table-striped table-bordered">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="Producto.Codigo" />
                        <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                        <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnidad" />
                        <asp:BoundField HeaderText="SubTotal" DataField="Subtotal" />
                    </Columns>
                </asp:GridView>

                <div class="mt-3">
                    <strong>Total: </strong>
                    <asp:Label ID="lbltotalVenta" runat="server" Text="$"></asp:Label>
                    <asp:Label ID="lbltotalVentaValor" runat="server"></asp:Label>
                </div>
            </div>
        </div>

        <!-- BOTONES -->
        <div class="mb-5">
            <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-success btn-sm me-2" OnClick="btnFinalizarVenta_Click" />
            <asp:Button ID="btnVolverVenta" runat="server" Text="Volver" CssClass="btn btn-secondary btn-sm" OnClick="btnVolverVenta_Click" />
        </div>
    </div>
</asp:Content>
