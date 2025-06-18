<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Bienvenida.aspx.cs" Inherits="presentacion.Bienvenida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-2">
<h1 class="display-1">Bienvenid@</h1>
<p class="lead">
  Gracias por utilizar nuestro sistema de back office para comercios.
</p>
<div class="d-flex flex-row">
    <p class="lead">
  Si ya tienes una cuenta puedes acceder a ella y empezar a utilizar el sistema.
</p>
<a class="btn btn-primary" href="Login.aspx">ACCEDER</a>
</div>
<div class="d-flex flex-row mt-3">
    <p class="lead">
  Si no tienes una cuenta puedes crear una y empezar a utilizar el sistema.
</p>
<a class="btn btn-primary" href="Registro.aspx">CREAR CUENTA</a>
</div>
</div>


</asp:Content>
