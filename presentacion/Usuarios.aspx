<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="presentacion.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Usuarios</h1>
        <!-- Buscador -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtFiltro" class="form-label">Nombre del Usuario</label>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Usuarios..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                    <asp:Button Text="Buscar" runat="server" ID="Buscar" CssClass="btn btn-primary" />
                </div>
                <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnLimpiar" Visible="false" OnClick="btnLimpiar_Click" />
            </div>
        </div>
        <!-- Grilla -->
        <asp:GridView ID="dgvUsuarios" runat="server" DataKeyNames="Id"
            CssClass="table table-dark table-hover" AutoGenerateColumns="false"
            AllowPaging="false" PageSize="5" OnRowCommand="dgvUsuarios_RowCommand">
            <columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:TemplateField HeaderText="Rol">
                    <itemtemplate>
                        <%# Convert.ToBoolean(Eval("Admin")) ? "Admin" : "Vendedor" %>
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Activo">
                    <itemtemplate>
                        <%# Convert.ToBoolean(Eval("Activo")) ? "Si" : "No" %>
                    </itemtemplate>
                </asp:TemplateField>                
                <asp:TemplateField HeaderText="Acción">
                    <itemtemplate>
                        <asp:Button Text="Desactivar" CssClass="btn btn-danger" CommandName="Desactivar" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("Activo") %>' runat="server" />
                        <asp:Button Text="Activar" CssClass="btn btn-light" CommandName="Activar" CommandArgument='<%# Eval("Id") %>' Visible='<%#!(bool) Eval("Activo") %>' runat="server" />
                    </itemtemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Asignar Rol">
                    <itemtemplate>
                        <asp:Button Text="Admin" CssClass="btn btn-light" CommandName="Admin" CommandArgument='<%# Eval("Id") %>' Visible='<%#!(bool) Eval("Admin") %>' runat="server" />
                        <asp:Button Text="Vendedor" CssClass="btn btn-light" CommandName="Vendedor" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("Admin") %>' runat="server" />
                    </itemtemplate>
                </asp:TemplateField>
            </columns>
        </asp:GridView>
    </div>
</asp:Content>
