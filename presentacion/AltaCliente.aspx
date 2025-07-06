<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaCliente.aspx.cs" Inherits="presentacion.AltaCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="card shadow-lg">
            <div class="card-header bg-dark text-white">
                <asp:Label runat="server" ID="lblTitulo" CssClass="h4 bi bi-box-seam" Text="Formulario de Alta Cliente"></asp:Label>
            </div>
            <div class="card-body">

                <!-- Validación de CUIL -->
                <asp:Label ID="lblValidarCuit" runat="server" Visible="false" CssClass="alert alert-danger d-block" />

                <!-- Nombre -->
                <div class="mb-3">
                    <label for="txtNombreCliente" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" MaxLength="30" placeholder="Nombre" />
                    <asp:RequiredFieldValidator ControlToValidate="txtNombreCliente" runat="server" CssClass="text-danger" ErrorMessage="El campo Nombre es obligatorio." Display="Dynamic" />
                </div>

                <!-- CUIL / CUIT -->
                <div class="mb-3">
                    <label for="txtCuilCliente" class="form-label">CUIL / CUIT</label>
                    <asp:TextBox ID="txtCuilCliente" runat="server" MaxLength="11" placeholder="20000000005" CssClass="form-control"
                        pattern="\d{11}" title="Ingrese solo números, exactamente 11 dígitos" />
                    <asp:RequiredFieldValidator ControlToValidate="txtCuilCliente" runat="server" CssClass="text-danger" ErrorMessage="El campo CUIL/CUIT es obligatorio." Display="Dynamic" />
                </div>

                <!-- Dirección -->
                <div class="mb-3">
                    <label for="txtDireccion" class="form-label">Dirección</label>
                    <asp:TextBox ID="txtDireccion" runat="server" MaxLength="30" CssClass="form-control" placeholder="Calle 1234, Localidad" />
                    <asp:RequiredFieldValidator ControlToValidate="txtDireccion" runat="server" CssClass="text-danger" ErrorMessage="El campo Dirección es obligatorio." Display="Dynamic" />
                </div>

                <!-- Teléfono -->
                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" MaxLength="10" CssClass="form-control" placeholder="1130000000"
                        pattern="\d{10}" title="Ingrese solo números, exactamente 10 dígitos" />
                    <asp:RequiredFieldValidator ControlToValidate="txtTelefono" runat="server" CssClass="text-danger" ErrorMessage="El campo Teléfono es obligatorio." Display="Dynamic" />
                </div>

                <!-- Email -->
                <div class="mb-3">
                    <label for="txtEmailCliente" class="form-label">Email</label>
                    <asp:TextBox ID="txtEmailCliente" runat="server" MaxLength="30" CssClass="form-control" placeholder="email@dominio.com"
                        pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}"
                        title="Por ejemplo: email@dominio.com" AutoCompleteType="Email" />
                    <asp:RequiredFieldValidator ControlToValidate="txtEmailCliente" runat="server" CssClass="text-danger" ErrorMessage="El campo Email es obligatorio." Display="Dynamic" />
                </div>

                <!-- Botones -->
                <div class="d-flex justify-content-between align-items-center mt-4">
                    <asp:Button ID="btnAgregarCliente" runat="server" Text="Registrar Cliente" CssClass="btn btn-primary" OnClick="btnAgregarCliente_Click" />
                    <a class="btn btn-outline-secondary" href="Clientes.aspx">Cancelar</a>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
