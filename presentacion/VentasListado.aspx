<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentasListado.aspx.cs" Inherits="presentacion.VentasListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div>
            <asp:GridView ID="dgvHistorialVentas" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered">
                <Columns>
                        <asp:BoundField HeaderText="Factura" DataField="Factura" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                        <asp:BoundField HeaderText="Cliente" DataField="Cliente.Nombre" />
                        <asp:TemplateField HeaderText="Acción">
                            <ItemTemplate>
                                <asp:Button
                                    ID="btnEliminarItem"
                                    Text="Ver Detalle"
                                    CssClass="btn btn-secondary btn-sm me-2"
                                    CommandName="DetalleVenta"
                                    CommandArgument='<%# Eval("Venta.Id")%>'
                                    runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
        </div>

    </div>
    
</asp:Content>
