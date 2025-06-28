<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="IngresarProductosVenta.aspx.cs" Inherits="presentacion.IngresarProductosVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">


            <div class="col-md-6">
                <h3>CLIENTE:</h3>
                <div class="input-group">
                    <label for="txtCuit" class="form-label">CUIT O CUIL Del Cliente</label>
                    <asp:TextBox ID="txtCuit" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />
                </div>
                <div class="input-group mt-4">
                    <label for="txtnombreCliente" class="form-label">NOMBRE Del Cliente</label>
                    <asp:TextBox ID="txtnombreCliente" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />

                </div>
            </div>




        <div class="column d-flex flex-column gap-4 ">
            <h1 class="mt-4">INGRESAR PRODUCTOS</h1>
            <div class="d-flex justify-content-center align-items-center">
                <!-- DDL CATEGORIA PRODUCTO -->
                <div class="col-6">
                    <asp:Label ID="lblCatVenta" runat="server" Text="Categoria"></asp:Label>
                    <asp:DropDownList ID="ddlCatVenta" runat="server"></asp:DropDownList>
                    <asp:Label runat="server" Text="Seleccione una catégoria (opcional)"></asp:Label>
                </div>
                <!-- DDL PRODUCTO -->
                <div class="col-6">
                    <asp:Label ID="lblProdVenta" runat="server" Text="Producto"></asp:Label>
                    <asp:DropDownList ID="ddlProdVenta" runat="server"></asp:DropDownList>
                    <asp:Label runat="server" Text="seleccione un producto" ID="lblHelProdVenta"></asp:Label>
                </div>
            </div>

            <!--INPUT CANTIDAD PRODUCTO -->
            <div class="col-6">
                <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantVenta" runat="server"></asp:TextBox>
                <asp:Label runat="server" Text="Indique la cantidad" ID="lblHelpCantVenta"></asp:Label>
            </div>
        </div>

        <asp:Button ID="btnAgregarItemVenta" runat="server" Text="AGREGAR PRODUCTO" CssClass="mt-4 btn btn-primary btn-sm " OnClick="btnAgregarItemVenta_Click" />


        <h1 class="mt-4">PRODUCTOS AGREGADOS A LA VENTA</h1>
        <div>
            <!-- GRILLA DE PRODUCTOS AGREGADOS A LA VENTA -->
            <asp:GridView ID="dgvDetalleVenta" runat="server" AutoGenerateColumns="false"
                CssClass="table table-dark table-hover">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="Producto.Codigo" />
                    <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnidad" />
                    <asp:BoundField HeaderText="SubTotal" DataField="Subtotal" />
                </Columns>
            </asp:GridView>

            <div>
                <asp:Label ID="lbltotalVenta" runat="server" Text="Total: $"></asp:Label>
                <asp:Label ID="lbltotalVentaValor" runat="server" ></asp:Label>
            </div>

        </div>


        <div>
            <asp:Button ID="btnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn-primary"/>
            <asp:Button ID="btnVolverVenta" runat="server" Text="Volver"  CssClass="btn-secondary" OnClick="btnVolverVenta_Click"/>
        </div>

    </div>

</asp:Content>
