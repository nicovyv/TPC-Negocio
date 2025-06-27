using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;


namespace presentacion
{
    public partial class IngresarProductosVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCategorias();
                cargarProductos();

               

            }

            //cargarDetalleVenta();

        }


        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCatVenta.DataSource = negocio.listar();
            ddlCatVenta.DataTextField = "Descripcion";
            ddlCatVenta.DataValueField = "Id";
            ddlCatVenta.DataBind();

        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ddlProdVenta.DataSource = negocio.listar();
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();
        }


        //protected void cargarDetalleVenta()
        //{
        //    Venta venta = (Venta)Session["venta"];

        //    if (venta != null && venta.ItemVenta != null)
        //    {

        //        dgvDetalleVenta.DataSource = venta.ItemVenta;
        //        dgvDetalleVenta.DataBind();



        //    }

        //}

        protected void btnAgregarItemVenta_Click(object sender, EventArgs e)
        {
            //GENERAMOS UN LISTADO DE ITEMS VACIO PARA LA VENTA
            //List<ItemVenta> itemsVentas = new List<ItemVenta>();
            try
            {
                //Venta venta = null;

                ProductoNegocio negocio = new ProductoNegocio();
                int idProducto = int.Parse(ddlProdVenta.SelectedValue);

                if (idProducto == 0)
                {
                    lblHelProdVenta.Text = "Debe seleccionar un Producto.";
                    lblHelProdVenta.CssClass = "text-danger";
                    return;
                }


                Producto producto = negocio.ObtenerPorId(idProducto);

                int cantidad = int.Parse(txtCantVenta.Text);

                if (cantidad < 1)
                {
                    lblHelpCantVenta.Text = "La cantidad debe ser mayor a 0 unidades";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }


                else if (producto.StockActual - cantidad < producto.StockMinimo)
                {
                    lblHelpCantVenta.Text = "No hay stock suficiente.";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }


                Venta venta = (Venta)Session["venta"];

                if (venta == null)
                {
                    venta = new Venta();
                    venta.ItemVenta = new List<ItemVenta>();
                    Session.Add("venta", venta);
                }



                ItemVenta item = new ItemVenta();
                item.Producto = producto;
                item.Cantidad = cantidad;
                item.PrecioUnidad = producto.PrecioVenta;


                //List<ItemVenta> listaItems = new List<ItemVenta>();
                //listaItems.Add(item);

                venta.ItemVenta.Add(item);

                Session.Add("venta", venta);




                dgvDetalleVenta.DataSource = venta.ItemVenta;
                dgvDetalleVenta.DataBind();



                lblHelpCantVenta.Text = "Indique la cantidad";
                lblHelProdVenta.Text = "seleccione un producto";

               

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}