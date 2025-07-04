<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="presentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h1 class="mb-4">Productos</h1>

        <!-- Buscador -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtBuscador" class="form-label">Nombre del Producto</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscadorProd" placeholder="Busque Productos..." runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtBuscadorProd_TextChanged" />
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                </div>
                <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light mt-2" ID="btnLimpiarBuscadorProd" Visible="false" OnClick="btnLimpiarBuscadorProd_Click" />
            </div>
        </div>

        <!-- Filtros -->
        <div class="row mb-4">
            <div class="col-md-6">
                <h5>Filtrar por:</h5>


                <div class="mb-3">
                    <label for="ddlFiltroCategoria" class="form-label">Categoría</label>
                    <asp:DropDownList 
                        ID="ddlFiltroCategoria" 
                        runat="server" 
                        CssClass="form-select"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlFiltroCategoria_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="ddlFiltroMarca" class="form-label">Marca</label>
                    <asp:DropDownList ID="ddlFiltroMarca" 
                        runat="server" 
                        CssClass="form-select" 
                        AutoPostBack="true" 
                        OnSelectedIndexChanged="ddlFiltroMarca_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>

                <% if(negocio.Security.isAdmin(Session["usuario"]))
                                { %> 
                <asp:Button Text="Ver productos dados de baja" runat="server" CssClass="btn btn-outline-info" ID="btnProdBaja" OnClick="btnProdBaja_Click" />
                <%} %>
            </div>
        </div>

        <!-- Grilla -->
        <asp:GridView ID="dgvProductoAdmin" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover"
            AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5"
            OnSelectedIndexChanged="dgvProducto_SelectedIndexChanged"
            OnPageIndexChanging="dgvProducto_PageIndexChanging"
            OnRowCommand="dgvProducto_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Stock Actual" DataField="StockActual" />
                <asp:BoundField HeaderText="Precio de Venta" DataField="PrecioVenta" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button
                            ID="btnModProd"
                            Text="Modificar"
                            CssClass="btn btn-light btn-sm me-2"
                            CommandName="Modificar"
                            CommandArgument='<%# Eval("Id") %>'
                            runat="server" />
                        <asp:Button
                            Text="Ver Detalle"
                            CssClass="btn btn-secondary btn-sm"
                            CommandName="Detalle"
                            CommandArgument='<%# Eval("Id") %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:GridView ID="dgvProductoVendedor" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover"
            AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5"
            OnSelectedIndexChanged="dgvProducto_SelectedIndexChanged"
            OnPageIndexChanging="dgvProducto_PageIndexChanging"
            OnRowCommand="dgvProducto_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Stock Actual" DataField="StockActual" />
                <asp:BoundField HeaderText="Precio de Venta" DataField="PrecioVenta" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button
                            Text="Ver Detalle"
                            CssClass="btn btn-secondary btn-sm"
                            CommandName="Detalle"
                            CommandArgument='<%# Eval("Id") %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <!-- Botón Nuevo Producto -->
        <div class="mt-4">
            <asp:Button ID="btnNuevoProd" OnClick="btnNuevoProd_Click" runat="server" Text="Nuevo Producto" CssClass="btn btn-success" />
        </div>
    </div>

</asp:Content>
