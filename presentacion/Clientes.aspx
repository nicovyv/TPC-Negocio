<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="presentacion.Clientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Clientes</h2>
    <a href="AltaCliente.aspx">Agregar Nuevo Cliente</a>
    <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label class="form-label" runat="server">Filtrar</label>
                    <asp:TextBox runat="server" ID="txtFiltroCliente" CssClass="form-control" AutoPostBack="true" />
                </div>
            </div>
           
        </div>
    <h3>Clientes Registrados</h3>

     <asp:GridView id="dgvClientes" runat="server" DataKeyNames="Id"
     CssClass="table table-dark table-hover" AutoGenerateColumns="false"
     AllowPaging="false" PageSize="5">
     <Columns>
         <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
         <asp:BoundField HeaderText="CuilCuit" DataField="CuilCuit" />
         <asp:BoundField HeaderText="Direccion" DataField="Direccion" />
         <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
         <asp:BoundField HeaderText="Email" DataField="Email" />
         <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Seleccionar" />         
     </Columns>
 </asp:GridView>
</asp:Content>
