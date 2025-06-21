<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaMarca.aspx.cs" Inherits="presentacion.AltaMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="d-flex justify-content-center">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblTitulo" CssClass="h2" Text="Formulario de Alta Marca"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblValidarDescripción" runat="server" Visible="false" CssClass="alert alert-danger" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="30" placeholder="Descripción" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button class="btn btn-dark" Text="Registrar Marca" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
                <a class="btn btn-dark" href="Marcas.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
