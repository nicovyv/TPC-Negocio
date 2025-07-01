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
            Proveedor proveedor;

            //configuracion de cargar DropDownList
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                if (!(IsPostBack))
                {
                    if (Security.hayProveedorAsignado(Session["proveedor"]))
                    {
                        //configuracion de cargar Proveedor
                        proveedor = (Proveedor)Session["proveedor"];
                        lblNombreProveedor.Text = proveedor.Nombre;
                        lblCuilProveedor.Text = proveedor.CuilCuit;
                    }

                    //DDL Categorias
                    List<Categoria> categorias = categoriaNegocio.listar();
                    ddlCatCompra.DataSource = categorias;
                    ddlCatCompra.DataTextField = "Descripcion";
                    ddlCatCompra.DataValueField = "Id";
                    ddlCatCompra.DataBind();



                    //DDL Productos
                    List<Producto> productos = new List<Producto>();
                    int idCategoria = int.Parse(ddlCatCompra.SelectedValue);
                    productos = productoNegocio.FiltrarCategoria(idCategoria);

                    // SI LA CATEGORIA SELECCIONADA NO TIENE PRODUCTOS SE LIMPIA DDLPRODUCTOS. SI LOS TIENE CARGA DDL Y MUESTRA STOCK Y PRECIO
                    if (productos.Count > 0)
                    {
                        ddlProdCompra.DataSource = productos;
                        ddlProdCompra.DataTextField = "Nombre";
                        ddlProdCompra.DataValueField = "Id";
                        ddlProdCompra.DataBind();

                        //Cargar precio del producto y stock actual
                        Producto producto = productoNegocio.ObtenerPorId(int.Parse(ddlProdCompra.SelectedValue));
                        txtProdPrecio.Text = producto.PrecioCompra.ToString();
                        txtProdStock.Text = producto.StockActual.ToString();
                    }
                    else
                    {
                        ddlProdCompra.Items.Clear();
                        txtProdPrecio.Text = "";
                        txtProdStock.Text = "";

                        lblHelProdCompra.Text = "Sin Productos.";
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
}