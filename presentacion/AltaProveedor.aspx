<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AltaProveedor.aspx.cs" Inherits="presentacion.AltaProveedor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">

                <!-- Título -->
                <div class="card shadow">
                    <div class="card-header bg-dark text-white">
                        <asp:Label runat="server" ID="lblTitulo" CssClass="h4 mb-0" Text="Formulario de Alta Proveedor"></asp:Label>
                    </div>

                    <div class="card-body">

                        <!-- Validación de CUIL duplicado -->
                        <asp:Label ID="lblValidarCuit" runat="server" Visible="false" CssClass="alert alert-danger w-100" />

                        <!-- Nombre -->
                        <div class="mb-3">
                            <label for="txtNombreProveedor" class="form-label">Nombre</label>
                            <asp:TextBox runat="server" ID="txtNombreProveedor" MaxLength="30" placeholder="Nombre" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtNombreProveedor"
                                ErrorMessage="El campo Nombre es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <!-- Cuil/Cuit -->
                        <div class="mb-3">
                            <label for="txtCuilProveedor" class="form-label">Cuil/Cuit</label>
                            <asp:TextBox runat="server" ID="txtCuilProveedor" MaxLength="11" placeholder="20000000005"
                                pattern="\d{11}" title="Ingrese solo números, exactamente 11 dígitos" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCuilProveedor"
                                ErrorMessage="El campo Cuil/Cuit es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <!-- Dirección -->
                        <div class="mb-3">
                            <label for="txtDireccion" class="form-label">Dirección</label>
                            <asp:TextBox runat="server" ID="txtDireccion" MaxLength="30" placeholder="Calle 1234, Localidad" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion"
                                ErrorMessage="El campo Dirección es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <!-- Teléfono -->
                        <div class="mb-3">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <asp:TextBox runat="server" ID="txtTelefono" pattern="\d{10}"
                                title="Ingrese solo números, exactamente 10 dígitos"
                                MaxLength="10" placeholder="1130000000" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtTelefono"
                                ErrorMessage="El campo Teléfono es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <!-- Email -->
                        <div class="mb-3">
                            <label for="txtEmailProveedor" class="form-label">Email</label>
                            <asp:TextBox runat="server" ID="txtEmailProveedor" title="Por ejemplo: email@dominio.com"
                                MaxLength="30" CssClass="form-control" pattern="[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([.][a-zA-Z0-9_]+)*[.][a-zA-Z]{1,5}"
                                AutoCompleteType="Email" placeholder="email@dominio.com" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmailProveedor"
                                ErrorMessage="El campo Email es obligatorio." CssClass="text-danger" Display="Dynamic" />
                        </div>

                        <!-- Botones -->
                        <div class="d-flex justify-content-between">
                            <asp:Button CssClass="btn btn-dark" Text="Registrar Proveedor" runat="server" ID="btnAgregarProveedor" OnClick="btnAgregarProveedor_Click" />
                            <a class="btn btn-secondary" href="Proveedores.aspx">Cancelar</a>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
