<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="presentacion.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div>
      <h1>Lista de Categorias</h1>
      <div class="row">
          <div class="col-6">
              <div class="mb-3">
                  <label class="form-label" runat="server">Filtrar</label>
                  <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" AutoPostBack="true" />
              </div>
          </div>
           <div class="col-6">
              <div class="mb-3">
                  <label class="form-label" runat="server">Nueva Categoría</label>
                  <div CssClass="display-flex flex-direction-row">
                      <asp:TextBox runat="server" ID="txtNuevaCat" CssClass="form-control"/>
                      <asp:Button CssClass="btn btn-primary mt-1" Text="Guardar" runat="server" OnClick="On_Click" />
                     
                      <asp:Label Text="" runat="server" ID="lblErrorCatNueva" visible="false"/>
                  </div>

              </div>
          </div>
      </div>
      
      <asp:GridView ID="dgvCategorias" runat="server" DataKeyNames="Id"
          CssClass="table table-dark table-hover" AutoGenerateColumns="false"
          AllowPaging="false" PageSize="5">
          <Columns>
              <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
              <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Modificar" />
              <asp:CommandField HeaderText="" ShowSelectButton="True" SelectText="Eliminar" />
          </Columns>
      </asp:GridView>

  </div>
</asp:Content>
