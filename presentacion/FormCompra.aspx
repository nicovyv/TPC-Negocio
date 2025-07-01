<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="presentacion.FormCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Nueva compra</h1>
        <!-- Buscador de Proveedor -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtBuscador" class="form-label">CUIT O CUIL Del Proveedor</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscadorProveedor" placeholder="Ingrese Cuil o Cuit del Proveedor" runat="server" CssClass="form-control" AutoPostBack="true" />
                    <asp:Button Text="Asignar Proveedor" ID="btnAsignarProveedor" OnClick="btnAsignarProveedor_Click" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>

        </div>

        <!-- DATOS de Proveedor -->
        <div class="row">
            <div class="col-md-6">
                <h3>Proveedor:</h3>
                <div class="input-group">
                    <label for="txtCuit" class="form-label">CUIT O CUIL Del Proveedor</label>
                    <asp:TextBox ID="txtCuit" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />
                </div>
                <div class="input-group mt-4">
                    <label for="txtnombreProveedor" class="form-label">NOMBRE Del Proveedor</label>
                    <asp:TextBox ID="txtnombreProveedor" placeholder="" ReadOnly="true" runat="server" CssClass="form-control" AutoPostBack="true" />

                </div>
            </div>
            <div>
                <asp:Button
                    ID="btnIngresarProductos" OnClick="btnIngresarProductos_Click"
                    runat="server"
                    CssClass="btn btn-primary mt-4"
                    Text="Ingresar productos" />
            </div>

        </div>
    </div>

</asp:Content>
