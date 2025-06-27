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
        <div class="row">
            <div class="col-md-6">
                <h1>CLIENTE:</h1>
                <div class="input-group">
                    <label for="txtCuit" class="form-label">CUIT O CUIL Del Cliente</label>
                    <asp:TextBox ID="txtCuit" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />
                </div>
                <div class="input-group mt-4">
                    <label for="txtnombreCliente" class="form-label">NOMBRE Del Cliente</label>
                    <asp:TextBox ID="txtnombreCliente" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />

                </div>
            </div>
            <asp:Button 
                ID="btnIngresarProductos"
                OnClick="btnIngresarProductos_Click"
                runat="server" 
                CssClass="btn btn-primary mt-4" 
                Text="Ingresar productos" />
        </div>
        <!-- INGRESAR PRODUCTOS A LA VENTA -->
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
        <!-- BOTÓN AGREGAR PRODUCTO A LA VENTA -->
        <asp:Button ID="btnAgregarItemVenta" runat="server" Text="AGREGAR PRODUCTO" CssClass="mt-4 btn btn-primary btn-sm " OnClick="btnAgregarItemVenta_Click" />
        <!-- MOSTRAR DETALLES DE LA VENTA -->
        <hr />
        <h1 class="mt-4">PRODUCTOS AGREGADOS A LA VENTA</h1>
        <div>
            <!-- GRILLA DE PRODUCTOS AGREGADOS A LA VENTA -->
            <asp:GridView ID="dgvDetalleVenta" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Código" DataField="producto.codigo" />
                    <asp:BoundField HeaderText="Cantidad" DataField="cantidad" />
                    <asp:BoundField HeaderText="Precio Unitario" DataField="precioUnidad" />
                    <asp:BoundField HeaderText="SubTotal" DataField="" />
                </Columns>
            </asp:GridView>
        </div>
        <!-- BOTÓN PARA CONFIRMAR LA VENTA -->
        <div class="mb-3">
            <asp:Button ID="btnGuardarVenta" runat="server" Text="Confirmar Venta" CssClass="mt-4 btn btn-primary" />
            <%--<asp:Button ID="btnCancelarProd" runat="server" Text="Cancelar" CssClass="btn btn-secondary" />--%>
            <!-- BOTÓN PARA CANCELAR LA VENTA -->
            <a href="Productos.aspx" class="d-block m-2 float-end">Cancelar</a>
        </div>
    </div>
        
       

       
       
</asp:Content>
