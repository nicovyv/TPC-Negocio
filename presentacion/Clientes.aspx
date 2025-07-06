<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="presentacion.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2><i class="bi bi-people"></i>Clientes</h2>
            <% if (negocio.Security.isAdmin(Session["usuario"]))
                { %>
            <a class="btn btn-success" href="AltaCliente.aspx"><i class="bi bi-plus-circle"></i>Nuevo Cliente</a>
            <% } %>
        </div>

        <!-- Clientes Activos -->
        <div class="card mb-4">
            <div class="card-header bg-dark text-white">
                <strong>Clientes Activos</strong>
            </div>
            <div class="card-body">

                <!-- Buscador -->
                <div class="row g-2 align-items-end mb-3">
                    <div class="col-md-6">
                        <label for="txtFiltro" class="form-label">Nombre del Cliente</label>
                        <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" placeholder="Buscar por cuil o nombre..." AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    </div>
                    <div class="col-auto">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                    </div>
                    <div class="col-auto">
                        <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-outline-secondary" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla Clientes Vendedor -->
                <asp:Panel ID="pnlVendedor" runat="server">
                    <div class="table-responsive mb-4">
                        <asp:GridView ID="dgvClientesVendedor" runat="server" CssClass="table table-dark table-hover" AutoGenerateColumns="false" DataKeyNames="Id">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="CUIL/CUIT" DataField="CuilCuit" />
                                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                                <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>

                <!-- Grilla Clientes Admin -->
                <asp:Panel ID="pnlAdmin" runat="server">
                    <div class="table-responsive mb-4">
                        <asp:GridView ID="dgvClientesAdmin" runat="server" CssClass="table table-dark table-hover" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="dgvClientes_RowCommand">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="CUIL/CUIT" DataField="CuilCuit" />
                                <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                                <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:Button Text="Modificar" CssClass="btn btn-outline-light btn-sm me-2" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                        <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>

            </div>
        </div>

        <% if (negocio.Security.isAdmin(Session["usuario"]))
            { %>
        <!-- Clientes dados de baja -->
        <div class="card mb-4">
            <div class="card-header bg-warning text-dark">
                <strong>Clientes Dados de Baja</strong>
            </div>
            <div class="card-body">
                <!-- Buscador -->
                <div class="row g-2 align-items-end mb-3">
                    <div class="col-md-6">
                        <label for="txtBaja" class="form-label">Nombre del Cliente</label>
                        <asp:TextBox ID="txtBaja" runat="server" CssClass="form-control" placeholder="Buscar por cuil o nombre..." AutoPostBack="true" OnTextChanged="txtBaja_TextChanged" />
                    </div>
                    <div class="col-auto">
                        <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                    </div>
                    <div class="col-auto">
                        <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-outline-secondary" ID="btnBaja" OnClick="btnBaja_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla de Bajas -->
                <div class="table-responsive">
                    <asp:GridView ID="dgvBajas" runat="server" CssClass="table table-secondary table-hover" AutoGenerateColumns="false" DataKeyNames="Id" OnRowCommand="dgvBajas_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                            <asp:BoundField HeaderText="CUIL/CUIT" DataField="CuilCuit" />
                            <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:Button Text="Reactivar" CssClass="btn btn-success btn-sm" CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
        <% } %>
    </div>
</asp:Content>
