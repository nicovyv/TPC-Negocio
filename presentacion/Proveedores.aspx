<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="presentacion.Proveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">

        <!-- Proveedores Activos -->
        <div class="card shadow mb-5">
            <div class="card-header bg-dark text-white">
                <h4 class="mb-0"><i class="bi bi-truck"></i>Proveedores Activos</h4>
            </div>
            <div class="card-body">

                <!-- Buscador -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="txtFiltro" class="form-label">Buscar por nombre</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Buscar por cuit o nombre..." AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                            <asp:Button runat="server" Text="Buscar" CssClass="btn btn-primary" />
                        </div>
                        <asp:Button runat="server" ID="btnLimpiar" Text="Limpiar" CssClass="btn btn-light mt-2" OnClick="btnLimpiar_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla Activos -->
                <asp:GridView ID="dgvProveedores" runat="server" DataKeyNames="Id" CssClass="table table-dark table-hover"
                    AutoGenerateColumns="false" AllowPaging="false" PageSize="5" OnRowCommand="dgvProveedores_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Cuil/Cuit" DataField="CuilCuit" />
                        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                        <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:Button Text="Modificar" CssClass="btn btn-outline-light btn-sm me-2"
                                    CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                                <asp:Button Text="Dar de Baja" CssClass="btn btn-danger btn-sm"
                                    CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <!-- Proveedores Dados de Baja -->
        <div class="card shadow mb-4">
            <div class="card-header bg-warning text-dark">
                <h5 class="mb-0"><i class="bi bi-archive"></i>Proveedores Dados de Baja</h5>
            </div>
            <div class="card-body">

                <!-- Buscador -->
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label for="txtBaja" class="form-label">Buscar por nombre</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtBaja" CssClass="form-control" placeholder="Buscar por cuil o nombre..." AutoPostBack="true" OnTextChanged="txtBaja_TextChanged" />
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-primary" />
                        </div>
                        <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnBaja" OnClick="btnBaja_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla Bajas -->
                <asp:GridView ID="dgvBajas" runat="server" DataKeyNames="Id" CssClass="table table-dark table-hover"
                    AutoGenerateColumns="false" AllowPaging="false" PageSize="5" OnRowCommand="dgvBajas_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Cuil/Cuit" DataField="CuilCuit" />
                        <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
                        <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button Text="Reactivar" CssClass="btn btn-success btn-sm"
                                    CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
</asp:Content>
