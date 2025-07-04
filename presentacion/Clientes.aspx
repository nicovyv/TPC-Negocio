﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="presentacion.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h1 class="mb-4">Clientes</h1>
        <!-- Buscador -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtFiltro" class="form-label">Nombre del cliente</label>
                <div class="input-group">
                    <asp:TextBox ID="txtFiltro" placeholder="Busque Clientes..." runat="server" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" AutoPostBack="true" />
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                </div>
                <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false" />

            </div>
        </div>
        <!-- Grilla para Vendedores -->
        <asp:GridView ID="dgvClientesVendedor" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="false" PageSize="5" OnRowCommand="dgvClientes_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="CuilCuit" DataField="CuilCuit" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Email" DataField="Email" />


            </Columns>
        </asp:GridView>
        <!-- Grilla para Admin -->
        <asp:GridView ID="dgvClientesAdmin" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="false" PageSize="5" OnRowCommand="dgvClientes_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="CuilCuit" DataField="CuilCuit" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Email" DataField="Email" />

                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button Text="Modificar" CssClass="btn btn-light" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                        <asp:Button Text="Eliminar" CssClass="btn btn-danger" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <% if (negocio.Security.isAdmin(Session["usuario"]))
    { %>
        <h1 class="mb-4">Clientes Dados de Baja</h1>
        <!-- Buscador BAJAS -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtFiltro" class="form-label">Nombre del cliente</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBaja" placeholder="Busque Clientes..." runat="server" CssClass="form-control" OnTextChanged="txtBaja_TextChanged" AutoPostBack="true" />
                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                </div>
                <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnBaja" OnClick="btnBaja_Click" Visible="false" />

            </div>
        </div>
        <% } %>
        <!-- Grilla de bajas para Admin -->
        <asp:GridView ID="dgvBajas" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="false" PageSize="5" OnRowCommand="dgvBajas_RowCommand">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="CuilCuit" DataField="CuilCuit" />
                <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                <asp:BoundField HeaderText="Email" DataField="Email" />

                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>
                        <asp:Button Text="Reactivar" CssClass="btn btn-light" CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' runat="server" />

                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        <% if (negocio.Security.isAdmin(Session["usuario"]))
            { %>
        <!-- Botón Nuevo CLIENTE -->
        <div class="mt-4">
            <a class="btn btn-success" href="AltaCliente.aspx">Nuevo Cliente</a>
        </div>
    </div>

    <% } %>
</asp:Content>
