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
        Cliente cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            //configuracion de cargar DropDownList
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                if (!(IsPostBack))
                {
                    if (Security.hayClienteAsignado(Session["cliente"]))
                    {
                        //configuracion de cargar cliente
                        cliente = (Cliente)Session["cliente"];
                        lblNombreCliente.Text = cliente.Nombre;
                        lblCuilCliente.Text = cliente.CuilCuit;
                    }
                    //DDL Categorias
                    List<Categoria> categorias = categoriaNegocio.listar();
                    ddlCatVenta.DataSource = categorias;
                    ddlCatVenta.DataTextField = "Descripcion";
                    ddlCatVenta.DataValueField = "Id";
                    ddlCatVenta.DataBind();
                }
                
                //DDL Productos
                List<Producto> productos = new List<Producto>();
                int idCategoria = int.Parse(ddlCatVenta.SelectedValue);
                productos = productoNegocio.FiltrarCategoria(idCategoria);
               
               
                
                ddlProdVenta.DataSource = productos;
                ddlProdVenta.DataTextField = "Nombre";
                ddlProdVenta.DataValueField = "Id";
                ddlProdVenta.DataBind();

                //Cargar precio del producto y stock actual
                Producto producto = productoNegocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));
                txtProdPrecio.Text = producto.PrecioVenta.ToString();
                txtProdStock.Text = producto.StockActual.ToString();


            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
           
           
           


        }
        protected void cargarCliente()
        {
            Cliente cliente = (Cliente)Session["cliente"];

            string cuil = cliente.CuilCuit;
            string nombre = cliente.Nombre;

            lblNombreCliente.Text = nombre;
            lblCuilCliente.Text = cuil;

        }

        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCatVenta.DataSource = negocio.listar();
            ddlCatVenta.DataTextField = "Descripcion";
            ddlCatVenta.DataValueField = "Id";
            ddlCatVenta.DataBind();

            //cargarProductos();
        }


        // SE CARGAN LOS DDL PARA LA CARGA DE PRODUCTOS A LA VENTA, SE MUESTRA EN PANTALLA STOCK Y PRECIO UNITARIO
        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            
            int idCategoria = int.Parse(ddlCatVenta.SelectedValue);

            List<Producto> productosFiltrados = negocio.FiltrarCategoria(idCategoria);

            ddlProdVenta.DataSource = productosFiltrados;
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();


           

            if (productosFiltrados.Count > 0)
            {
                Producto producto = negocio.ObtenerPorId(int.Parse(ddlProdVenta.SelectedValue));
               txtProdPrecio.Text = producto.PrecioVenta.ToString();
               txtProdStock.Text = producto.StockActual.ToString();


            }
            else
            {
                txtProdPrecio.Text = "";
                txtProdStock.Text = "";
                txtCantVenta.Text = "";
            }


        

        }




        protected void btnAgregarItemVenta_Click(object sender, EventArgs e)
        {

            try
            {   
                //INSTANCIAMOS LA PRODUCTO NEGOCIO CON LOS METODOS ABML DE UN PRODUCTO
                ProductoNegocio negocio = new ProductoNegocio();
                
                //CAPTURAMOS EL ID DEL PRODUCTO, SELECCIONADO EN EL DDL DE PRODUCTOS
                int idProducto = int.Parse(ddlProdVenta.SelectedValue);
                
                //USAMOS EL ID DEL PRODUCTO PARA CAPTURAR EL PRODUCTO POR ID
                Producto producto = negocio.ObtenerPorId(idProducto);
                
                
                int cantidad = 0;
                //VALIDACIÓN PARA QUE SE INGRESE UNA CANTIDAD DEL PRODUCTO
                //PARSEAMOS LA CANTIDAD DEL PRODUCTO DE STRING A ENTERO
                if (!string.IsNullOrEmpty(txtCantVenta.Text))
                { cantidad = int.Parse(txtCantVenta.Text); }
                else
                {
                    lblHelpCantVenta.Text = "Este campo es obligatorio";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }
                
               

                //VALIDACIONES

                //VALIDACIÓN PARA QUE  SE SELECCIONE UN PRODUCTO
                if (idProducto == 0)
                {
                    lblHelProdVenta.Text = "Debe seleccionar un Producto.";
                    lblHelProdVenta.CssClass = "text-danger";
                    return;
                }
                

                //VALIDACIÓN PARA QUE LA CANTIDAD INGRESADA SEA MAYOR A CERO
                if (cantidad < 1)
                {
                    lblHelpCantVenta.Text = "La cantidad debe ser mayor a 0 unidades";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }

                //VALIDACIÓN PARA QUE LA CANTIDAD INGRESADA NO SEA MAYOR AL STOCK DISPONIBLE
                int stock = producto.StockActual;
                int diferenciaDeStock = stock - cantidad;

                if (!(diferenciaDeStock>=0))
                {
                    lblHelpCantVenta.Text = "No hay stock suficiente.";
                    lblHelpCantVenta.CssClass = "text-danger";
                    return;
                }

                //AGREGAMOS LA VENTA A LA SESIÓN
                Venta venta = (Venta)Session["venta"];

                if (venta == null)
                {
                    venta = new Venta();
                    venta.ItemVenta = new List<ItemVenta>();
                    Session["venta"] = venta;
                }


                //INSTANCIAMOS ITEM DE LA VENTA
                ItemVenta item = new ItemVenta();
                item.Producto = producto;
                item.Cantidad = cantidad;
                item.PrecioUnidad = producto.PrecioVenta;

                //VALIDACIÓN PARA QUE NO SE REPITE EL ITEM EN EL LISTADO DE ITEMS DE LA VENTA
                //CODIGO DE LA VALIDACIÓN...

                //AGREGAMOS ITEM AL LISTADO DE PRODUCTOS DE LA VENTA
                venta.ItemVenta.Add(item);

               



                //GRILLA PARA VER PRODUCTOS INGRESADOS A LA VENTA
                dgvDetalleVenta.DataSource = venta.ItemVenta;
                dgvDetalleVenta.DataBind();



                //lblHelpCantVenta.Text = "Indique la cantidad";
                //lblHelProdVenta.Text = "seleccione un producto";

                //CALCULAR TOTAL DE LA VENTA
                decimal totalVenta = venta.ItemVenta.Sum(x => x.Cantidad * x.PrecioUnidad);
                lbltotalVentaValor.Text = totalVenta.ToString();

            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrio un error al agregar el producto";
                lblError.CssClass = "text-danger";
                throw ex;
            }


        }

        protected void btnVolverVenta_Click(object sender, EventArgs e)
        {
            Session.Remove("venta");
            Response.Redirect("Ventas.aspx");
        }

       

        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("VentaRegistrada.aspx");
        }
        // SE CARGAN LOS PRODUCTOS FILTADOS POR CATEGORIA
        protected void ddlCatVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            // cargarProductos();
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCatVenta.DataSource = negocio.listar();
            ddlCatVenta.DataTextField = "Descripcion";
            ddlCatVenta.DataValueField = "Id";
            ddlCatVenta.DataBind();
        }

        protected void ddlProdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {


            ProductoNegocio negocio = new ProductoNegocio();
           
           
            int idCategoria = int.Parse(ddlCatVenta.SelectedValue);
            List<Producto> productosFiltrados = negocio.FiltrarCategoria(idCategoria);

            ddlProdVenta.DataSource = productosFiltrados;
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();
            int idProducto = int.Parse(ddlProdVenta.SelectedValue);


            Producto producto = new Producto();
            producto = negocio.ObtenerPorId(idProducto);

            //lblPrecioProd.Text = producto.PrecioVenta.ToString();
            //lblStockProd.Text = producto.StockActual.ToString();
            txtProdPrecio.Text = producto.PrecioVenta.ToString();
            txtProdStock.Text= producto.StockActual.ToString(); 
        }
    }
}