<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bienvenida.aspx.cs" Inherits="presentacion.Bienvenida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container text-center mt-5">
        <h1 class="display-4 fw-bold">¡Bienvenid@!</h1>
        <p class="lead mt-3">
            Gracias por utilizar nuestro sistema de back office para comercios.
        </p>
        <% if (!negocio.Security.isLogin(Session["usuario"]))
    { %>
        <hr class="my-4" />

        <div class="mt-4">
            <p class="lead">¿Ya tienes una cuenta?</p>
            <a class="btn btn-primary btn-lg px-4 me-2" href="Login.aspx">Acceder</a>
        </div>

        <div class="mt-5">
            <p class="lead">¿No tienes una cuenta todavía?</p>
            <a class="btn btn-outline-primary btn-lg px-4" href="Registro.aspx">Crear cuenta</a>
        </div>
        <% } %>
    </div>
</asp:Content>

