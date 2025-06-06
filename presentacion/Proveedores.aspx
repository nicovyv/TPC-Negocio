<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="presentacion.Proveedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Proveedores</h2>
    <a href="AltaCliente.aspx">Agregar Nuevo Cliente</a>
    <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" runat="server">Filtrar</label>
                    <asp:TextBox runat="server" ID="txtFiltroCliente" CssClass="form-control" AutoPostBack="true" />
                </div>
            </div>
           
        </div>
    <h3>Clientes Registrados</h3>
</asp:Content>
