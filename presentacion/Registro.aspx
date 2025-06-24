<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="presentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        


    <div class="row justify-content-center align-items-center" style="min-height: 85vh;">
        <div class="col-10 col-sm-8 col-md-4 border border-primary rounded-1 p-4" >
            <h3 class="mb-4 text-center">Crea tu usuario</h3>
            <div class="mb-3 row">
                <label for="txtEmail" class="col-sm-3 col-form-label col-form-label-sm">Email</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" required ID="txtEmail" CssClass="form-control form-control-sm" />
                </div>
            </div>

            <div class="mb-3 row">

                <label for="txtPassword" class="col-sm-3 col-form-label col-form-label-sm">Password</label>
                <div class="col-sm-9">
                    <asp:TextBox runat="server" required type="password" ID="txtPassword" CssClass="form-control form-control-sm" />
                </div>
            </div>
              <asp:Button OnClick="btnRegistrarse_Click" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary float-end" runat="server" />
  <a href="Bienvenida.aspx" class="d-block m-2 float-end">cancelar</a>
        </div>

    </div>
  
  
    
    
</asp:Content>
