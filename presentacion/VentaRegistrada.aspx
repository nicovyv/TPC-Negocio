<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VentaRegistrada.aspx.cs" Inherits="presentacion.VentaRegistrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Venta registrada exitosamente</h2>

             
                <div>
                    <p>Cliente</p> <asp:Label ID="lblNombreClienteVentaExito" runat="server" Text=""></asp:Label>
                    <p>CUIL-CUIT</p><asp:Label ID="lblCuilVentaExito" runat="server" Text=""></asp:Label>
                    <p>N° Factura</p>  <asp:Label ID="lblFacturaVentaExito" runat="server" Text=""></asp:Label>
                    <p>Fecha</p> <asp:Label ID="lblFechaVentaExito" runat="server" Text=""></asp:Label>
                </div>




    <div>   
        <h3>Detalle de la Venta</h3>
    </div>

    <div>
        <asp:Button runat="server" Text="Nueva Venta" CssClass="mt-4 btn btn-primary btn-sm"/>
        <asp:Button runat="server" Text="Ir al Perfil" CssClass="mt-4 btn btn-secondary btn-sm"/>
    </div>

</asp:Content>
