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
                

               

            }
            cargarProductos();


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
            Producto producto = new Producto(); 
           
            ddlProdVenta.DataSource = negocio.FiltrarCategoria(ddlCatVenta.Text);
           
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();
            producto = negocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));
            txtPrecioProd.Text=producto.PrecioVenta.ToString();
            txtStockProd.Text=producto.StockActual.ToString();
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



                venta.ItemVenta.Add(item);

                Session.Add("venta", venta);




                dgvDetalleVenta.DataSource = venta.ItemVenta;
                dgvDetalleVenta.DataBind();



                lblHelpCantVenta.Text = "Indique la cantidad";
                lblHelProdVenta.Text = "seleccione un producto";

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
    }
}