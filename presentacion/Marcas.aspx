<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="presentacion.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div>
     <h1>Lista de marcas</h1>
     <div class="row">
         <div class="col-6">
             <div class="mb-3">
                 <label class="form-label" runat="server">Filtrar</label>
                 <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" />
             </div>
         </div>
        
     </div>

     <asp:GridView ID="dgvMarcas" runat="server" DataKeyNames="Id"
         CssClass="table table-dark table-hover" AutoGenerateColumns="false"
         AllowPaging="true" PageSize="5">
         <Columns>
             <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
             <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Modificar" />
             <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Eliminar" />
         </Columns>
     </asp:GridView>
 </div>
</asp:Content>
