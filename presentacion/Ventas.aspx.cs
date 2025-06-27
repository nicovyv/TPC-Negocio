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
    public partial class Ventas : System.Web.UI.Page
    {
        Venta venta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCategorias();
                cargarProductos();
            }
 
        }

        protected void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            
             
           
            try
            {
                cliente=clienteNegocio.buscarClientePorCuitCuil(txtBuscadorCliente.Text);
                //GENERAMOS UNA NUEVA VENTA
                venta = new Venta();
                //ASIGNAMOS CLIENTE A LA VENTA
                venta.Cliente = new Cliente();
                venta.Cliente = cliente;
                
                if(cliente.Id!=0 )
                {
                    txtCuit.Text = cliente.CuilCuit;
                    txtnombreCliente.Text = cliente.Nombre;
                }
                else
                {
                    Session.Add("error", "El cliente no está registrado en el sistema, no se puede realizar la venta");
                    Response.Redirect("Error.aspx",false);
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        protected void btnAgregarItemVenta_Click(object sender, EventArgs e)
        {
            //GENERAMOS UN LISTADO DE ITEMS VACIO PARA LA VENTA
            List<ItemVenta> itemsVentas = new List<ItemVenta>();
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                int idProducto = int.Parse(ddlProdVenta.SelectedValue);

                if (idProducto == 0)
                {
                    lblHelProdVenta.Text = "Debe seleccionar un Producto.";
                    lblHelProdVenta.CssClass = "text-danger";
                    return;
                }


                Producto producto =  negocio.ObtenerPorId(idProducto);

                int cantidad = int.Parse(txtCantVenta.Text);

                if(cantidad < 1)
                {
                    lblHelpCantVenta.Text = "La cantidad debe ser mayor a 0 unidades";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }

            
                else if(producto.StockActual - cantidad < producto.StockMinimo)
                {
                    lblHelpCantVenta.Text = "No hay stock suficiente.";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }



                ItemVenta item = new ItemVenta();
                item.Producto = producto;
                item.Cantidad = cantidad;
                item.PrecioUnidad = producto.PrecioVenta;


                List<ItemVenta> listaItems = new List<ItemVenta>();
                listaItems.Add(item);

                dgvDetalleVenta.DataSource = listaItems;
                dgvDetalleVenta.DataBind();


                lblCantVenta.Text = "";
                lblHelpCantVenta.Text = "Indique la cantidad";
                lblHelProdVenta.Text = "seleccione un producto";



            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void btnIngresarProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("IngresarProductosVenta.aspx", false);
        }
    }
}