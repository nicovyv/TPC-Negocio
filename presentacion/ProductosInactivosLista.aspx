<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductosInactivosLista.aspx.cs" Inherits="presentacion.ProductosInactivosLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2 class="mb-4 text-center">Productos Dados de Baja</h2>

        <asp:Label ID="lblMsjProdActivo" Visible="false" runat="server" Text="Label"></asp:Label>

        <asp:GridView ID="dgvProdInactivos" runat="server"
            AutoGenerateColumns="false"
            CssClass="table table-striped table-bordered"
            AllowPaging="true" PageSize="10" OnRowCommand="dgvProdInactivos_RowCommand">
            <columns>
                <asp:BoundField HeaderText="Código" DataField="Codigo" />
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Stock" DataField="StockActual" />
                <asp:TemplateField HeaderText="Acciones">
                    <itemtemplate>
                        <asp:Button
                            ID="btnDarAlta"
                            runat="server"
                            Text="Dar de Alta"
                            CssClass="btn btn-secondary btn-sm"
                            CommandName="DarAlta"
                            CommandArgument='<%# Eval("Id") %>' />
                    </itemtemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
        <a href="Productos.aspx" class="btn btn-success mt-3">Ir a Productos</a>

    </div>

</asp:Content>
