<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="presentacion.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-md-10">

                <h2 class="text-center mb-4">Historial de Compras</h2>

                <!-- Buscador -->
                <div class="mb-4">
                    <label for="txtFiltro" class="form-label">Buscar por Proveedor (CUIL/CUIT)</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtFiltro" runat="server"
                            CssClass="form-control"
                            placeholder="Buscar compras por cuit o nombre de proveedor..."
                            AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
                        <asp:Button ID="btnBuscar" runat="server"
                            Text="Buscar"
                            CssClass="btn btn-primary" />
                    </div>
                    <asp:Button ID="btnLimpiar" runat="server"
                        Text="Limpiar"
                        CssClass="btn btn-light mt-2"
                        OnClick="btnLimpiar_Click"
                        Visible="false" />
                </div>

                <!-- Grilla -->
                <asp:GridView ID="dgvCompra" runat="server" DataKeyNames="Id"
                    CssClass="table table-striped table-bordered text-center"
                    AutoGenerateColumns="false"
                    AllowPaging="false" PageSize="5"
                    OnRowCommand="dgvCompra_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha"
                            DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" />

                        <asp:BoundField HeaderText="Total" DataField="Total" />

                        <asp:TemplateField HeaderText="Cuil/Cuit Proveedor">
                            <ItemTemplate>
                                <%# Eval("Proveedor.CuilCuit") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre Proveedor">
                            <ItemTemplate>
                                <%# Eval("Proveedor.Nombre") %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button Text="Ver Detalle" CssClass="btn btn-secondary btn-sm"
                                    CommandName="VerDetalle" CommandArgument='<%# Eval("Id") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <!-- Botón INGRESAR COMPRA -->
                <div class="mt-4 text-end">
                    <a class="btn btn-success" href="FormCompra.aspx">+ Nueva Compra</a>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
