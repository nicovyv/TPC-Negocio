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
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:BoundField HeaderText="Admin" DataField="Admin" />
                <asp:BoundField HeaderText="Activo" DataField="Activo" />
                <asp:TemplateField HeaderText="Acción">
                    <ItemTemplate>                        
                        <asp:Button Text="Desactivar" CssClass="btn btn-danger" CommandName="Desactivar" CommandArgument='<%# Eval("Id") %>' Visible='<%# Eval("Activo") %>' runat="server" />                      
                        <asp:Button Text="Activar" CssClass="btn btn-light" CommandName="Activar" CommandArgument='<%# Eval("Id") %>' Visible='<%#!(bool) Eval("Activo") %>' runat="server" />                       
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
