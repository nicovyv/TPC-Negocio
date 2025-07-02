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
        protected void cargarCliente()
        {
            Cliente cliente = (Cliente)Session["cliente"];

            string cuil = cliente.CuilCuit;
            string nombre = cliente.Nombre;

            lblNombreCliente.Text = nombre;
            lblCuilCliente.Text = cuil;

        }

        //SE AGREGAN A LA GRILLA DE VENTA LOS PROCUTOS QUE SE VAN SELECCIONANDO
        protected void btnAgregarItemVenta_Click(object sender, EventArgs e)
        {
            ItemVenta item = null;

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

                if (!(diferenciaDeStock >= 0))
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


                VentaNegocio ventaNegocio = new VentaNegocio();
                //INSTANCIAMOS ITEM DE LA VENTA





                //VALIDACIÓN PARA QUE NO SE REPITE EL ITEM EN EL LISTADO DE ITEMS DE LA VENTA
                if (ventaNegocio.ValidarItemExistente(venta.ItemVenta, idProducto))
                {

                    item = ventaNegocio.ObtenerItemExistente(venta.ItemVenta, idProducto);

                    int nuevaCantidad = item.Cantidad + cantidad;

                    if (nuevaCantidad > producto.StockActual)
                    {
                        lblHelpCantVenta.Text = "No hay stock suficiente.";
                        lblHelpCantVenta.CssClass = "text-danger";
                        return;
                    }

                    item.Cantidad = nuevaCantidad;


                }
                else
                {
                    item = new ItemVenta();


                    if (cantidad > producto.StockActual)
                    {
                        lblHelpCantVenta.Text = "No hay stock suficiente.";
                        lblHelpCantVenta.CssClass = "text-danger";
                        return;
                    }

                    item.Producto = producto;
                    item.Cantidad = cantidad;
                    item.PrecioUnidad = producto.PrecioVenta;


                    //AGREGAMOS ITEM AL LISTADO DE PRODUCTOS DE LA VENTA
                    venta.ItemVenta.Add(item);



                }


                //GRILLA PARA VER PRODUCTOS INGRESADOS A LA VENTA
                dgvDetalleVenta.DataSource = venta.ItemVenta;
                dgvDetalleVenta.DataBind();




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


        // FINALIZA LA SELECCIOÓN DE PRODUCTOS Y DE LA VENTA
        protected void btnFinalizarVenta_Click(object sender, EventArgs e)
        {

            try
            {
                VentaNegocio negocio = new VentaNegocio();
                Venta venta = (Venta)Session["venta"];
                Cliente cliente = (Cliente)Session["cliente"];

                venta.Cliente = cliente;
                venta.Fecha = DateTime.Now;
                venta.Factura = negocio.GenerarNumFacura();




                Response.Redirect("VentaRegistrada.aspx");
            }
            catch (Exception)
            {

                throw;
            }

           
        }


        // SE CARGAN LOS PRODUCTOS FILTADOS POR CATEGORIA
        protected void ddlCatVenta_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProductoNegocio productoNegocio = new ProductoNegocio();

            int idCategoria = int.Parse(ddlCatVenta.SelectedValue);
            List<Producto> productosFiltrados = productoNegocio.FiltrarCategoria(idCategoria);

            // SI LA CATEGORIA SELECCIONADA NO TIENE PRODUCTOS SE LIMPIA DDLPRODUCTOS. SI LOS TIENE CARGA DDL Y MUESTRA STOCK Y PRECIO
            if (productosFiltrados.Count > 0)
            {
                ddlProdVenta.DataSource = productosFiltrados;
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

        protected void ddlProdVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            int idProducto = int.Parse(ddlProdVenta.SelectedValue);

            Producto producto = new Producto();
            producto = negocio.ObtenerPorId(idProducto);

            txtProdPrecio.Text = producto.PrecioVenta.ToString();
            txtProdStock.Text = producto.StockActual.ToString();
        }


        //ELIMINACIÓN DE UN ITEM DE LA GRILLA DE VENTA A TRAVÉS DEL BOTÓN ELIMINAR
        protected void dgvDetalleVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {   // BUSCAMOS EL COMANDO
                if (e.CommandName == "Eliminar")
                {   // VARIABLE PARA GUARDAR EL ID DEL PRODUCTO
                    int idProd = int.Parse(e.CommandArgument.ToString());

                    //CREAMOS UNA VENTA Y LE ASIGMANOS LA EXISTENTE EN LA SESIÓN
                    Venta venta = (Venta)Session["venta"];

                    // VALIDAMOS QUE EXISTA
                    if (venta != null && venta.ItemVenta != null)
                    {
                        VentaNegocio negocio = new VentaNegocio();
                        // BUSCAMOS EL ITEM A TRAVÉS DEL ID DEL PRODUCTO
                        ItemVenta itemEliminar = negocio.ObtenerItemExistente(venta.ItemVenta, idProd);
                        // VALIDAMOS QUE TRAIGA UN ITEM
                        if (itemEliminar != null)
                        {   //LO QUITAMOS DE LA GRILLA
                            venta.ItemVenta.Remove(itemEliminar);
                            // ACTUALIZAMOS LA GRILLA
                            dgvDetalleVenta.DataSource = venta.ItemVenta;
                            dgvDetalleVenta.DataBind();
                            // ACTUALIZAMOS EL VALOR TOTAL
                            decimal totalVenta = venta.ItemVenta.Sum(x => x.Cantidad * x.PrecioUnidad);
                            lbltotalVentaValor.Text = totalVenta.ToString();

                        }





                    }


                }
            }
            catch (Exception)
            {

                Session.Add("error", "No se pudo eliminar el producto");
                Response.Redirect("Error.aspx");
            }


        }
    }
}