<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="presentacion.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <!-- TÍTULO GENERAL CON BOTÓN -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="mb-0"><i class="bi bi-tags-fill"></i>Gestión de Marcas</h2>
            <a class="btn btn-success" href="AltaMarca.aspx"><i class="bi bi-plus-circle"></i>Nueva Marca</a>
        </div>

        <!-- CARD: MARCAS ACTIVAS -->
        <div class="card mb-5">
            <div class="card-header bg-dark text-white">
                <strong>Marcas Activas</strong>
            </div>
            <div class="card-body">

                <!-- Buscador -->
                <div class="row g-2 align-items-end mb-3">
                    <div class="col-md-6">
                        <label for="txtFiltro" class="form-label">Nombre de la marca</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" placeholder="Buscar marca..." AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-outline-primary" />
                        </div>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary" OnClick="btnLimpiar_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla Activas -->
                <div class="table-responsive">
                    <asp:GridView ID="dgvMarcas" runat="server" DataKeyNames="Id"
                        CssClass="table table-dark table-hover text-center"
                        AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                        OnRowCommand="dgvMarcas_RowCommand" OnPageIndexChanging="dgvMarcas_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:TemplateField HeaderText="Modificar">
                                <ItemTemplate>
                                    <asp:Button ID="btnModificarMarca" runat="server" Text="Modificar" CssClass="btn btn-outline-light btn-sm me-2" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Dar Baja">
                                <ItemTemplate>
                                    <asp:Button ID="btnDarBajaMarca" runat="server" Text="Dar Baja" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

        <!-- CARD: MARCAS DADAS DE BAJA -->
        <div class="card mb-5">
            <div class="card-header bg-warning text-dark">
                <strong>Marcas Dadas de Baja</strong>
            </div>
            <div class="card-body">

                <!-- Buscador -->
                <div class="row g-2 align-items-end mb-3">
                    <div class="col-md-6">
                        <label for="txtFiltroBaja" class="form-label">Nombre de la marca</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtFiltroBaja" CssClass="form-control" placeholder="Buscar marca..." AutoPostBack="true" OnTextChanged="txtFiltroBaja_TextChanged" />
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-outline-primary" />
                        </div>
                    </div>
                    <div class="col-auto">
                        <asp:Button ID="btnLimpiarBaja" runat="server" Text="Limpiar" CssClass="btn btn-outline-secondary" OnClick="btnLimpiarBaja_Click" Visible="false" />
                    </div>
                </div>

                <!-- Grilla Bajas -->
                <div class="table-responsive">
                    <asp:GridView ID="dgvBajas" runat="server" DataKeyNames="Id"
                        CssClass="table table-secondary table-hover"
                        AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                        OnRowCommand="dgvBajas_RowCommand" OnPageIndexChanging="dgvBajas_PageIndexChanging">
                        <Columns>
                            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                            <asp:TemplateField HeaderText="Acción">
                                <ItemTemplate>
                                    <asp:Button ID="btnReactivarMarca" runat="server" Text="Reactivar" CssClass="btn btn-success btn-sm" CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
        </div>

    </div>
</asp:Content>
