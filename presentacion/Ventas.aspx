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
     </div>
        <!-- DATOS de cliente -->
        <asp:Label CssClass="form-label" runat="server" ID="lblCUIT"></asp:Label>
        <asp:Label CssClass="form-label" runat="server" ID="lblNombre"></asp:Label>

        <!-- DATOS de venta -->


        <div class="column d-flex flex-column gap-4 ">
            <div class="col-6">
                <asp:Label ID="lblCatVenta" runat="server" Text="Categoria"></asp:Label>
                <asp:DropDownList ID="ddlCatVenta" runat="server"></asp:DropDownList>
                <asp:Label runat="server" Text="Seleccione una catégoria (opcional)"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblProdVenta" runat="server" Text="Producto"></asp:Label>
                <asp:DropDownList ID="ddlProdVenta" runat="server"></asp:DropDownList>
                 <asp:Label runat="server" Text="seleccione un producto" ID="lblHelProdVenta"></asp:Label>
            </div>
            <div class="col-6">
                <asp:Label ID="lblCantVenta" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox ID="txtCantVenta" runat="server"></asp:TextBox>
                <asp:Label runat="server" Text="Indique la cantidad" ID="lblHelpCantVenta"></asp:Label>
            </div>
            <asp:Button ID="btnAgregarItemVenta" runat="server" Text="Agregar" OnClick="btnAgregarItemVenta_Click" />

        </div>

        <h3>Detalle de la Venta</h3>
        <div>
            <asp:GridView ID="dgvDetalleVenta" runat="server">

                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="producto.codigo" />
                    <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="precioUnidad" />
                    <asp:BoundField HeaderText="SubTotal" DataField="" />
                </Columns>

            </asp:GridView>


        </div>

        <div class="mb-3">
            <asp:Button ID="btnGuardarVenta" runat="server" Text="Confirmar Venta" CssClass="btn btn-primary"  />
            <%--<asp:Button ID="btnCancelarProd" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />--%>
            <a href="Productos.aspx" class="d-block m-2 float-end">Cancelar</a>
        </div>
</asp:Content>
