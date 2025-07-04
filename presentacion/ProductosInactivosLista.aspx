<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductosInactivosLista.aspx.cs" Inherits="presentacion.ProductosInactivosLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="container mt-4">
        <h2 class="mb-4 text-center">Productos Dados de Baja</h2>
        <asp:GridView ID="dgvProdInactivos" runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-striped table-bordered"
            AllowPaging="true" PageSize="10" >
            <Columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Stock" DataField="StockActual" />
            </Columns>
        </asp:GridView>

        <asp:Button Text="Volver" runat="server" CssClass="btn btn-secondary mt-3"  />
    </div>

</asp:Content>
