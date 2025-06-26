 <%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="presentacion.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Ventas</h1>
        <!-- Buscador de cliente -->
        <div class="row mb-4">
            <div class="col-md-6">
                <label for="txtBuscador" class="form-label">CUIT O CUIL Del Cliente</label>
                <div class="input-group">
                    <asp:TextBox ID="txtBuscadorCliente" placeholder="Ingrese Cuil o Cuit del cliente" runat="server" CssClass="form-control" AutoPostBack="true" />
                    <asp:Button Text="Asignar cliente" ID="btnAsignarCliente" OnClick="btnAsignarCliente_Click" runat="server" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
        <!-- DATOS de cliente -->
        <asp:Label CssClass="form-label" runat="server" ID="lblCUIT"></asp:Label>
        <asp:Label CssClass="form-label" runat="server" ID="lblNombre"></asp:Label>

    </div>
            
    
  


</asp:Content>
