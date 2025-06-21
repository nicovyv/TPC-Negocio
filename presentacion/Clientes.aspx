<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="presentacion.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="d-flex justify-content-center">Clientes</h2>


    <div class="d-flex justify-content-center" style="height: 100px;">
        <div class="col-sm-6">
            <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Clientes..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroCliente_TextChanged"/>
        </div>
        <div class="col-sm-1">
            <asp:Button Text="🔍" CssClass="btn btn-light" runat="server" />

        </div>
        <div class="col-sm-1">
            <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false"  />
        </div>

    </div>


    <div class="row" style="height: 200px;">
        <div class="col">
            <a class="btn btn-dark" href="AltaCliente.aspx">Nuevo Cliente</a>
        </div>
        <div class="">
            <asp:GridView ID="dgvClientes" runat="server" DataKeyNames="Id"
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
        </div>

    </div>


</asp:Content>
