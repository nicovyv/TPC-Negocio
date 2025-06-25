<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="presentacion.Compras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
      <h2 class="d-flex justify-content-center">Compras</h2>


  <div class="d-flex justify-content-center" style="height: 100px;">
      <div class="col-sm-6">
          <asp:TextBox runat="server" ID="txtFiltro" placeholder="Busque Compras..." CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"/>
      </div>
      <div class="col-sm-1">
          <asp:Button Text="🔍" CssClass="btn btn-light" runat="server" />

      </div>
      <div class="col-sm-1">
          <asp:Button Text="Limpiar" runat="server" CssClass="btn btn-light" ID="btnLimpiar" OnClick="btnLimpiar_Click" Visible="false"  />
      </div>

  </div>


  <div class="row" style="height: 200px;">
      <div class="col">
          <a class="btn btn-dark" href="FormCompra.aspx">Nuevo Compra</a>
      </div>
      <div class="">
          <asp:GridView ID="dgvCompra" runat="server" DataKeyNames="Id"
              CssClass="table table-dark table-hover" AutoGenerateColumns="false"
              AllowPaging="false" PageSize="5" OnRowCommand="dgvCompra_RowCommand">
              <Columns>
                  <asp:BoundField HeaderText="N Factura" DataField="NFactura"/>
                  <asp:BoundField HeaderText="Fecha" DataField="Fecha"  />
                  <asp:BoundField HeaderText="Proveedor" DataField="Proveedor"/>
                  <asp:BoundField HeaderText="Usuario" DataField="Usuario" />                  
                  <asp:BoundField HeaderText="Total" DataField="Total"/>
                  <asp:TemplateField HeaderText="Acción">
                      <ItemTemplate>
                          <asp:Button Text="Ver Detalle" CssClass="btn btn-light" CommandName="VerDetalle" CommandArgument='<%# Eval("Id") %>' runat="server" />                          
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </div>

  </div>

</asp:Content>
