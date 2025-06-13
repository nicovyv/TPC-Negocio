<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormProductos.aspx.cs" Inherits="presentacion.FormProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-6">
            <div class="mb-3 d-flex">
                <label for="txtCodProd" class="form-label">Codigo: </label>
                <asp:TextBox runat="server" ID="txtCodProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtDescProd" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" ID="txtDescProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="ddlMarcaProd" class="form-label">Marca: </label>
                <asp:DropDownList runat="server" ID="ddlMarcaProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex">
                <label for="ddlCatProd" class="form-label">Categoria: </label>
                <asp:DropDownList runat="server" ID="ddlCatProd" CssClass="form-select"></asp:DropDownList>
            </div>
            <div class="mb-3 d-flex">
                <label for="txtStockMinimoProd" class="form-label">Stock Minimo: </label>
                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtGananciaProd" class="form-label">Stock Minimo: </label>
                <asp:TextBox runat="server" ID="txtGananciaProd" CssClass="form-control" />
            </div>
            <div class="mb-3 d-flex">
                <label for="txtProveedoresPord" class="form-label">Proveedores: </label>
                <asp:CheckBoxList ID="cblProveedoresProd" RepeatDirection="Vertical" RepeatColumns="1" runat="server"></asp:CheckBoxList>
            </div>

        </div>
    </div>

</asp:Content>
