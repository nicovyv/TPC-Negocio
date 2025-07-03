<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentasListado.aspx.cs" Inherits="presentacion.VentasListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5"> 
        <div class="row justify-content-center">
            <div class="col-md-10"> 

                <h2 class="text-center mb-4">Historial de Ventas</h2> 

                <asp:GridView ID="dgvHistorialVentas" runat="server" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered text-center"  OnRowCommand="dgvHistorialVentas_RowCommand">
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
                                    runat="server"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    
</asp:Content>
