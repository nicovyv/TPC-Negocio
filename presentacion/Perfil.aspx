<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Perfil</h2>

<div class="row">
    <div class="col-md-5">
        <label>Usuario</label>
        <asp:Label ID="lblUsuario" runat="server" />
    </div>
    <div class="col-md-5">
    </div>
    <div class="col-md-5">
        <label>Nombre</label>
        <asp:TextBox ID="txtBoxNombre" runat="server" />
        <label>Contraseña</label>
        <asp:TextBox ID="txtBoxContraseña" runat="server" />
    </div>
    <div class="col">
        <asp:Button Text="Guardar" runat="server" />
    </div>


</div>
</asp:Content>
