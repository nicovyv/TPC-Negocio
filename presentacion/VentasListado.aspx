<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentasListado.aspx.cs" Inherits="presentacion.VentasListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5">
        <div class="row justify-content-center">
            <div class="col-md-10">

                <h2 class="text-center mb-4">Historial de Ventas</h2>

                <!-- Buscador -->
                <div class="mb-4">
                    <label for="txtBuscarVentas" class="form-label">Buscar por Cliente o Factura</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtBuscarVentas" runat="server"
                            CssClass="form-control"
                            placeholder="Ingrese cuil de cliente o número de factura"
                            AutoPostBack="true"  OnTextChanged="txtBuscarVentas_TextChanged"/>
                        <asp:Button ID="btnBuscarVentas" runat="server"
                            Text="Buscar"
                            CssClass="btn btn-primary" />
                    </div>
                    <asp:Button ID="btnLimpiarBusquedaVentas" runat="server"
                        Text="Limpiar"
                        CssClass="btn btn-light mt-2" 
                        OnClick="btnLimpiarBusquedaVentas_Click"
                        Visible="false" />
                </div>

                <asp:GridView ID="dgvHistorialVentas" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered text-center" OnRowCommand="dgvHistorialVentas_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Factura" DataField="Factura" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                        <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button
                                    ID="btnDetalleVenta"
                                    Text="Ver Detalle"
                                    CssClass="btn btn-secondary btn-sm"
                                    CommandName="DetalleVenta"
                                    CommandArgument='<%# Eval("Id") %>'
                                    runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>


                   <!-- Botón INGRESAR VENTA -->
                <div class="mt-4 text-end">
                    <a class="btn btn-success" href="Ventas.aspx">+ Nueva Venta</a>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
