<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCategoria.aspx.cs" Inherits="presentacion.AltaCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="d-flex justify-content-center">

        <div class="col-6">
            <div class="mb-3">
                <asp:Label runat="server" ID="lblTitulo" CssClass="h2" Text="Formulario de Alta Categoria"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblValidarDescripción" runat="server" Visible="false" CssClass="alert alert-danger" />
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" MaxLength="30" placeholder="Descripción" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button class="btn btn-dark" Text="Registrar Categoria" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" />
                <a class="btn btn-dark" href="Categorias.aspx">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
