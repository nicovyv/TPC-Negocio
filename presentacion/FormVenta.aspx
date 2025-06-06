<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormVenta.aspx.cs" Inherits="presentacion.FormVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <h2>Formulario de Venta</h2>

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtVentaCliente" class="form-label">Cliente</label>
                <asp:DropDownList runat="server"></asp:DropDownList>
            </div>
          <div class="mb-3">
                <label for="txtVentaProd" class="form-label">Producto</label>
                <asp:DropDownList runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtVentaCantidad" class="form-label">Cantidad</label>
                <asp:textbox runat="server" ID="txtVentaCantidad" cssclass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtVentaPrecioUnit" class="form-label">Precio Unitario</label>
                <asp:textbox runat="server" ID="txtVentaPrecioUnit" cssclass="form-control" />
            </div>
            <asp:button text="Registrar Venta" runat="server" ID="btnAgregarCliente"/>
                    <a href="Ventas.aspx">Cancelar</a>
        </div>
    </div>

</asp:Content>
