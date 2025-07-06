<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormCompra.aspx.cs" Inherits="presentacion.FormCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h1 class="mb-4">Nueva Compra</h1>

        <!-- Buscador de Proveedor -->
        <div class="card shadow-sm mb-4">
            <div class="card-body">
                <div class="row align-items-end">
                    <div class="col-md-6">
                        <label for="txtBuscadorProveedor" class="form-label">CUIT/CUIL del Proveedor</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBuscadorProveedor" runat="server"
                                placeholder="Ingrese CUIT o CUIL del proveedor"
                                CssClass="form-control" AutoPostBack="true" />
                            <asp:Button Text="Asignar Proveedor" ID="btnAsignarProveedor"
                                runat="server" CssClass="btn btn-primary" OnClick="btnAsignarProveedor_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Datos del proveedor asignado -->
        <div class="card shadow-sm mb-5">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="bi bi-person-badge-fill"></i>Proveedor Asignado</h5>
            </div>
            <div class="card-body">
                <div class="row g-3">
                    <div class="col-md-6">
                        <label for="txtCuit" class="form-label">CUIT/CUIL</label>
                        <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                    <div class="col-md-6">
                        <label for="txtnombreProveedor" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtnombreProveedor" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                </div>

                <div class="d-flex justify-content-end mt-4">
                    <asp:Button
                        ID="btnIngresarProductos"
                        runat="server"
                        CssClass="btn btn-success"
                        Text="Ingresar Productos"
                        OnClick="btnIngresarProductos_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
