<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="presentacion.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Ventas</h1>

        <!-- Buscador de cliente -->
        <div class="card shadow-sm mb-4">
            <div class="card-body">
                <div class="row align-items-end">
                    <div class="col-md-6">
                        <label for="txtBuscadorCliente" class="form-label">CUIT o CUIL del Cliente</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtBuscadorCliente" runat="server" CssClass="form-control" placeholder="Ingrese CUIL o CUIT del cliente" AutoPostBack="true" />
                            <asp:Button ID="btnAsignarCliente" Text="Asignar cliente" runat="server" CssClass="btn btn-primary"  OnClick="btnAsignarCliente_Click"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Datos del cliente -->
        <div class="card shadow-sm mb-4">
            <div class="card-header bg-dark text-white">
                <h5 class="mb-0"><i class="bi bi-person-vcard"></i>Cliente</h5>
            </div>
            <div class="card-body">
                <div class="row g-3">
                    <div class="col-md-6">
                        <label for="txtCuit" class="form-label">CUIT o CUIL del Cliente</label>
                        <asp:TextBox ID="txtCuit" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                    <div class="col-md-6">
                        <label for="txtnombreCliente" class="form-label">Nombre del Cliente</label>
                        <asp:TextBox ID="txtnombreCliente" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                </div>

                <div class="d-flex justify-content-end mt-4">
                    <asp:Button ID="btnIngresarProductos" runat="server" CssClass="btn btn-primary" Text="Ingresar productos"  OnClick="btnIngresarProductos_Click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
