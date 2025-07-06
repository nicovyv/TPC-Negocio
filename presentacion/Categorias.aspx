<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="presentacion.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <!-- TÍTULO -->
        <h2 class="mb-4">Gestión de Categorías</h2>

        <!-- SECCIÓN ACTIVAS -->
        <div class="card mb-5">
            <div class="card-header bg-dark text-white">
                <strong>Categorías Activas</strong>
            </div>
            <div class="card-body">

                <!-- BUSCADOR -->
                <div class="row mb-4">
                    <div class="col-md-6">
                        <label for="txtFiltro" class="form-label">Nombre de la categoría</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Categorías..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                            <asp:Button Text="Buscar" runat="server" CssClass="btn btn-outline-primary" />
                        </div>
                        <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light mt-2" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false" />
                    </div>
                </div>

                <!-- GRILLA ACTIVAS -->
                <asp:GridView ID="dgvCategorias" runat="server" DataKeyNames="Id"
                    CssClass="table table-dark table-hover text-center"
                    AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                    OnRowCommand="dgvCategorias_RowCommand" OnPageIndexChanging="dgvCategorias_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                        <asp:TemplateField HeaderText="Modificar">
                            <ItemTemplate>
                                <asp:Button Text="Modificar" CssClass="btn btn-light btn-sm me-1" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dar Baja">
                            <ItemTemplate>
                                <asp:Button Text="Dar Baja" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- SECCIÓN BAJAS -->
                <div class="card my-5">
                    <div class="card-header bg-warning text-dark">
                        <strong>Categorías Dadas de Baja</strong>
                    </div>
                    <div class="card-body">

                        <!-- BUSCADOR BAJAS -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtFiltroBaja" class="form-label">Buscar categoría</label>
                                <div class="input-group">
                                    <asp:TextBox runat="server" ID="txtFiltroBaja" CssClass="form-control" placeholder="Nombre de la categoría..." AutoPostBack="true" OnTextChanged="txtFiltroBaja_TextChanged" />
                                    <asp:Button Text="Buscar" runat="server" CssClass="btn btn-outline-primary" />
                                </div>
                                <asp:Button ID="btnLimpiarBaja" runat="server" Text="Limpiar" CssClass="btn btn-light mt-2" OnClick="btnLimpiarBaja_Click" Visible="false" />
                            </div>
                        </div>

                        <!-- GRILLA BAJAS -->
                        <asp:GridView ID="dgvBajas" runat="server" DataKeyNames="Id"
                            CssClass="table table-secondary table-hover text-center"
                            AutoGenerateColumns="false" AllowPaging="true" PageSize="5"
                            OnRowCommand="dgvBajas_RowCommand" OnPageIndexChanging="dgvBajas_PageIndexChanging">
                            <Columns>
                                <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                                <asp:TemplateField HeaderText="Acción">
                                    <ItemTemplate>
                                        <asp:Button ID="btnReactivarCategoria" runat="server" Text="Reactivar" CssClass="btn btn-success btn-sm" CommandName="Reactivar" CommandArgument='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
</asp:Content>
