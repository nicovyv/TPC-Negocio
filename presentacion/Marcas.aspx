<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="presentacion.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">

    <!-- TÍTULO -->
    <h1 class="mb-4">Marcas</h1>

    <!-- BUSCADOR -->
    <div class="row mb-4">
        <div class="col-md-6">
            <label for="txtFiltro" class="form-label">Nombre de la marca</label>
            <div class="input-group">
                <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Marcas..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
            </div>
            <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light mt-2" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false" />
        </div>
    </div>

    <!-- GRILLA -->
    <asp:GridView ID="dgvMarcas" runat="server" DataKeyNames="Id"
        CssClass="table table-dark table-hover" AutoGenerateColumns="false"
        AllowPaging="true" PageSize="5"
        OnRowCommand="dgvMarcas_RowCommand" OnPageIndexChanging="dgvMarcas_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />            

            <asp:TemplateField HeaderText="Modificar">
                <ItemTemplate>
                    <asp:Button Text="Modificar" CssClass="btn btn-light me-1" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Dar Baja">
                <ItemTemplate>
                    <asp:Button Text="Dar Baja" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
        <!-- TÍTULO BAJAS -->
        <h2 class="mt-5 mb-4">Marcas Dadas de Baja</h2>

        <!-- BUSCADOR BAJAS -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtFiltroBaja" class="form-label">Nombre de la marca</label>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtFiltroBaja" placeholder="Busque Marcas..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroBaja_TextChanged" />
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                </div>
                <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light mt-2" ID="btnLimpiarBaja" OnClick="btnLimpiarBaja_Click" visble="false" />
            </div>
        </div>

        <!-- GRILLA BAJAS -->
        <asp:GridView ID="dgvBajas" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="true" PageSize="5" OnRowCommand="dgvBajas_RowCommand" OnPageIndexChanging="dgvBajas_PageIndexChanging">
            <Columns>
                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button Text="Reactivar" CssClass="btn btn-success" CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    <!-- BOTÓN NUEVA MARCA -->
    <div class="mt-4">
        <a class="btn btn-success" href="AltaMarca.aspx">Nueva Marca</a>
    </div>

</div>
</asp:Content>
