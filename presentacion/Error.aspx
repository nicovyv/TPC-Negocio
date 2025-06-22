<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="presentacion.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 class="display-5 fw-bold">¡Algo salió mal!</h1>
        <p>
            <asp:Label runat="server" ID="lblError" CssClass="form-label lead"></asp:Label>
        </p>

        <p class="text-muted">Por favor, intente volver más tarde o regrese al inicio.</p>
        <div class="mt-4">
            <a href="Bienvenida.aspx" class="btn btn-primary">Volver atrás</a>
        </div>
    </div>
   
   
</asp:Content>
