using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class IngresarProductosCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //configuracion de cargar DropDownList
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                if (!(IsPostBack))
                {
                  /*  if (Security.hayClienteAsignado(Session["cliente"]))
                    {
                        //configuracion de cargar cliente
                        cliente = (Cliente)Session["cliente"];
                        lblNombreCliente.Text = cliente.Nombre;
                        lblCuilCliente.Text = cliente.CuilCuit;
                    }
                  */
                    //DDL Categorias
                    List<Categoria> categorias = categoriaNegocio.listar();
                    ddlCatVenta.DataSource = categorias;
                    ddlCatVenta.DataTextField = "Descripcion";
                    ddlCatVenta.DataValueField = "Id";
                    ddlCatVenta.DataBind();



                    //DDL Productos
                    List<Producto> productos = new List<Producto>();
                    int idCategoria = int.Parse(ddlCatVenta.SelectedValue);
                    productos = productoNegocio.FiltrarCategoria(idCategoria);

                    // SI LA CATEGORIA SELECCIONADA NO TIENE PRODUCTOS SE LIMPIA DDLPRODUCTOS. SI LOS TIENE CARGA DDL Y MUESTRA STOCK Y PRECIO
                    if (productos.Count > 0)
                    {
                        ddlProdVenta.DataSource = productos;
                        ddlProdVenta.DataTextField = "Nombre";
                        ddlProdVenta.DataValueField = "Id";
                        ddlProdVenta.DataBind();

                        //Cargar precio del producto y stock actual
                        Producto producto = productoNegocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));
                        txtProdPrecio.Text = producto.PrecioVenta.ToString();
                        txtProdStock.Text = producto.StockActual.ToString();
                    }
                    else
                    {
                        ddlProdVenta.Items.Clear();
                        txtProdPrecio.Text = "";
                        txtProdStock.Text = "";

                        lblHelProdVenta.Text = "Sin Productos.";
                    }


                }






            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
    }
}