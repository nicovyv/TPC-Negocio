<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="presentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div>
        <h1>Productos</h1>

        <div class="row">
            <div class="col-8">
                <label class="form-label" runat="server">Buscador:</label>
            </div>
            <div class="col-10 d-flex">
                <label class="form-label" runat="server">Nombre del Producto</label>
                <asp:TextBox runat="server" ID="txtBuscador" CssClass="form-control" AutoPostBack="true" />
                <asp:Button Text="Buscar" runat="server" />
            </div>
        </div>


        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" runat="server">Filtrar:</label>
                </div>
                <div class="col-12">
                    <label class="form-label" runat="server">Marca:</label>
                    <asp:DropDownList ID="ddlFiltroMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                    <label class="form-label" runat="server">Categoria:</label>
                    <asp:DropDownList ID="ddlFiltroCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
                    <asp:Button Text="Ver productos dados de baja" runat="server" />
                </div>
            </div>

        </div>

        <asp:GridView ID="dgvProducto" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Id" DataField="Id" />
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria" />
                <asp:BoundField HeaderText="Stock" DataField="StockActual" />
                <asp:BoundField HeaderText="Precio de Venta" DataField="PrecioVenta" />
                <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Ver Detalle" />
                <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Modificar" />
                <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Eliminar" />
            </Columns>
        </asp:GridView>
    </div>


    <div class="col-6">
        <div class="mb-3">
            <%--<button class="form-label" runat="server" >Nuevo Producto</button>--%>
            <a href="FormProductos.aspx">Nuevo Producto</a>
        </div>
    </div>
</asp:Content>
