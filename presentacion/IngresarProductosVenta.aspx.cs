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

                cargarCliente();

                cargarCategorias();


               // cargarProductos();

            }
           


        }


        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCatVenta.DataSource = negocio.listar();
            ddlCatVenta.DataTextField = "Descripcion";
            ddlCatVenta.DataValueField = "Id";
            ddlCatVenta.DataBind();

            cargarProductos();
        }


        // SE CARGAN LOS DDL PARA LA CARGA DE PRODUCTOS A LA VENTA, SE MUESTRA EN PANTALLA STOCK Y PRECIO UNITARIO
        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            //Producto producto = new Producto();

            int idCategoria = int.Parse(ddlCatVenta.SelectedValue);

            List<Producto> productosFiltrados = negocio.FiltrarCategoria(idCategoria);

            ddlProdVenta.DataSource = productosFiltrados;
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();


           

            //if (productosFiltrados.Count > 0)
            //{
            //    Producto producto = negocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));
            //    lblPrecioProd.Text = producto.PrecioVenta.ToString();
            //    lblStockProd.Text = producto.StockActual.ToString();


            //}
            //else
            //{
            //    lblPrecioProd.Text = "";
            //    lblStockProd.Text = "";
            //    txtCantVenta.Text = "";
            //}


        

        }




        protected void btnAgregarItemVenta_Click(object sender, EventArgs e)
        {

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
                if (string.IsNullOrEmpty(txtCantVenta.Text))
                {
                    lblHelpCantVenta.Text = "Este campo es obligatoria";
                    lblHelpCantVenta.CssClass = "text-danger";
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
                    Session["venta"] = venta;
                }



                ItemVenta item = new ItemVenta();
                item.Producto = producto;
                item.Cantidad = cantidad;
                item.PrecioUnidad = producto.PrecioVenta;



                venta.ItemVenta.Add(item);

               




                dgvDetalleVenta.DataSource = venta.ItemVenta;
                dgvDetalleVenta.DataBind();



                //lblHelpCantVenta.Text = "Indique la cantidad";
                //lblHelProdVenta.Text = "seleccione un producto";

                decimal totalVenta = venta.ItemVenta.Sum(x => x.Cantidad * x.PrecioUnidad);
                lbltotalVentaValor.Text = totalVenta.ToString();

            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void btnVolverVenta_Click(object sender, EventArgs e)
        {
            Session.Remove("venta");
            Response.Redirect("Ventas.aspx");
        }

        protected void cargarCliente()
        {
            Cliente cliente = (Cliente)Session["cliente"];

            string cuil = cliente.CuilCuit;
            string nombre = cliente.Nombre;

            lblNombreCliente.Text = nombre;
            lblCuilCliente.Text = cuil;

        }

        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentaRegistrada.aspx");
        }
        // SE CARGAN LOS PRODUCTOS FILTADOS POR CATEGORIA
        protected void ddlCatVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProductos();
        }

        protected void ddlProdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            int idProducto = int.Parse(ddlProdVenta.SelectedValue);

            Producto producto = new Producto();

            producto = negocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));

            lblPrecioProd.Text = producto.PrecioVenta.ToString();
            lblStockProd.Text = producto.StockActual.ToString();
        }
    }
}