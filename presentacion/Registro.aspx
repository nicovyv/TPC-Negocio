<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <h3 class="">Crea tu usuario</h3>

   
    <div class="row align-items-center">
        <div class="col-6 col-md-4">
           
            <div class="mb-3 row">
                <label for="txtEmail" class="col-sm-2 col-form-label col-form-label-sm">Email</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-sm" />
                </div>
            </div>

            <div class="mb-3 row">

                <label for="txtPassword"  class="col-sm-2 col-form-label col-form-label-sm">Password</label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" type="password" ID="txtPassword" CssClass="form-control form-control-sm"  />
                </div>
            </div>

        </div>

    </div>
    <asp:Button OnClick="btnRegistrarse_Click" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary text-center" runat="server" />
    <a href="Bienvenida.aspx">cancelar</a>
  
    
    
</asp:Content>
