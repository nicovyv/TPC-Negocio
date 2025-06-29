<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h3 class="mb-4 text-center">Perfil del Usuario</h3>

        <div class="row justify-content-center">
            <!-- Datos del usuario -->
            <div class="col-md-5">
                <div class="mb-3">
                    <label class="form-label">Email</label>
                    <asp:TextBox runat="server" ID="txtEmail" Enabled="false" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}" title="Por ejemplo: email@dominio.com" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" maxlength="30" placeholder="Nombre" CssClass="form-control" />
                </div>
                <div class="mb-3">
                    <label class="form-label">Apellido</label>
                    <asp:TextBox runat="server" ID="txtApellido" maxlength="30" placeholder="Apellido" CssClass="form-control" />
                </div>
            </div>

            <!-- Imagen de perfil -->
            <div class="col-md-5 text-center">
                <div class="mb-3">
                    <label class="form-label">Imagen de Perfil</label>
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>
                <asp:Image ID="imagenNuevoPerfil"
                           CssClass="img-thumbnail mb-3"
                           Style="max-width: 250px;"
                           runat="server"
                           ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg" />
            </div>
        </div>

        <!-- Botones -->
        <div class="row mt-4">
            <div class="col text-center">
                <asp:Button Text="Guardar" OnClick="btnGuardar_Click1" ID="btnGuardar" CssClass="btn btn-primary me-2" runat="server" />
                <a href="Productos.aspx" class="btn btn-secondary">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>
