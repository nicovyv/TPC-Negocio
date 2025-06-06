 <%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="presentacion.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

            <h2>Ventas</h2>
    <a href="FormVenta.aspx">Nueva Venta</a>
    <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" runat="server">Filtrar</label>
                    <asp:TextBox runat="server" ID="txtFiltroVenta" CssClass="form-control" AutoPostBack="true" />
                </div>
            </div>
           
        </div>
    <h3>Historial de Ventas</h3>

</asp:Content>
