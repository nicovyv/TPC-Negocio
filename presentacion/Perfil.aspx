<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="presentacion.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <h3>Perfil del Usuario</h3>
 <div class="row">
     <div class="col-md-4">
          <div class="mb-3">
         
             <label class="form-label">Email</label>
             <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
         
         </div>
         <div class="mb-3">
         
             <label class="form-label">Nombre</label>
             <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
         
         </div>
         <div class="mb-3">
          <label class="form-label">Apellido</label>
          <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
         </div>
     </div>
    

     <div class="row">
         <div class="col-md-4">
             <asp:Button Text="Guardar" ID="btnGuardar"  CssClass="btn btn-primary" runat="server" />
             <a href="Productos.aspx">Regresar</a>
         </div>
     </div>
 </div>
</asp:Content>
