<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="presentacion.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Formulario de Alta Cliente</h2>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtNombreCliente" class="form-label">Nombre</label>
                <asp:textbox runat="server" ID="txtNombreCliente" cssclass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCuilCliente" class="form-label">Cuil/Cuit</label>
                <asp:textbox runat="server" ID="txtCuilCliente" cssclass="form-control" />
            </div>
            <div class="mb-3">
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:textbox runat="server" ID="txtEmailCliente" cssclass="form-control" placeholder="ejemplo@email.com"/>
            </div>
            <div class="mb-3">
                <asp:button text="Agregar" runat="server" ID="btnAgregarCliente"/>
            </div>
        </div>
    </div>
</asp:Content>
