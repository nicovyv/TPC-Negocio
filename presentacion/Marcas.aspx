<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="presentacion.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2 class="d-flex justify-content-center">Marcas</h2>

    <div class="d-flex justify-content-center" style="height: 100px;">
        <div class="col-sm-6">
            <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Marcas..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
        </div>
        <div class="col-sm-1">
            <asp:Button Text="🔍" CssClass="btn btn-light" runat="server" />
        </div>
        <div class="col-sm-1">
            <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false" />
        </div>
    </div>

    <div class="row" style="height: 200px;">
        <div class="col">
            <a class="btn btn-dark" href="AltaMarca.aspx">Nueva Marca</a>
        </div>

        <asp:GridView ID="dgvMarcas" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5" OnRowCommand="dgvMarcas_RowCommand" OnPageIndexChanging="dgvMarcas_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                <asp:BoundField HeaderText="Cantidad de Productos" />
                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button Text="Modificar" CssClass="btn btn-light" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
