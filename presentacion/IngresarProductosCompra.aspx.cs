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

        protected void cargarCliente()
        {
            Proveedor proveedor = (Proveedor)Session["proveedor"];

            string cuil = proveedor.CuilCuit;
            string nombre = proveedor.Nombre;

            lblNombreProveedor.Text = nombre;
            lblCuilProveedor.Text = cuil;

        }

        protected void ddlProdCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            int idProducto = int.Parse(ddlProdCompra.SelectedValue);

            Producto producto = new Producto();
            producto = negocio.ObtenerPorId(idProducto);

            txtProdPrecio.Text = producto.PrecioCompra.ToString();
            txtProdStock.Text = producto.StockActual.ToString();
        }

        protected void ddlCatCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            int idCategoria = int.Parse(ddlCatCompra.SelectedValue);
            List<Producto> productosFiltrados = productoNegocio.FiltrarCategoria(idCategoria);

            // SI LA CATEGORIA SELECCIONADA NO TIENE PRODUCTOS SE LIMPIA DDLPRODUCTOS. SI LOS TIENE CARGA DDL Y MUESTRA STOCK Y PRECIO
            if (productosFiltrados.Count > 0)
            {
                ddlProdCompra.DataSource = productosFiltrados;
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

        protected void btnVolverCompra_Click(object sender, EventArgs e)
        {
            Session.Remove("compra");
            Response.Redirect("Compras.aspx");
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompraRegistrada.aspx");
        }

        protected void dgvDetalleCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {   // BUSCAMOS EL COMANDO
                if (e.CommandName == "Eliminar")
                {   // VARIABLE PARA GUARDAR EL ID DEL PRODUCTO
                    int idProd = int.Parse(e.CommandArgument.ToString());

                    //CREAMOS UNA Compra Y LE ASIGMANOS LA EXISTENTE EN LA SESIÓN
                    Compra compra = (Compra)Session["compra"];

                    // VALIDAMOS QUE EXISTA
                    if (compra != null && compra.Detalle != null)
                    {
                        CompraNegocio negocio = new CompraNegocio();
                        // BUSCAMOS EL ITEM A TRAVÉS DEL ID DEL PRODUCTO
                        DetalleCompra itemEliminar = negocio.ObtenerItemExistente(compra.Detalle, idProd);
                        // VALIDAMOS QUE TRAIGA UN ITEM
                        if (itemEliminar != null)
                        {   //LO QUITAMOS DE LA GRILLA
                            compra.Detalle.Remove(itemEliminar);
                            // ACTUALIZAMOS LA GRILLA
                            dgvDetalleCompra.DataSource = compra.Detalle;
                            dgvDetalleCompra.DataBind();
                            // ACTUALIZAMOS EL VALOR TOTAL
                            decimal totalCompra = compra.Detalle.Sum(x => x.Cantidad * x.PrecioUnidad);
                            lbltotalCompraValor.Text = totalCompra.ToString();

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

        protected void btnAgregarItemCompra_Click(object sender, EventArgs e)
        {
            DetalleCompra item = null;

            try
            {
                //INSTANCIAMOS LA PRODUCTO NEGOCIO CON LOS METODOS ABML DE UN PRODUCTO
                ProductoNegocio negocio = new ProductoNegocio();

                //CAPTURAMOS EL ID DEL PRODUCTO, SELECCIONADO EN EL DDL DE PRODUCTOS
                int idProducto = int.Parse(ddlProdCompra.SelectedValue);

                //USAMOS EL ID DEL PRODUCTO PARA CAPTURAR EL PRODUCTO POR ID
                Producto producto = negocio.ObtenerPorId(idProducto);


                int cantidad = 0;
                //VALIDACIÓN PARA QUE SE INGRESE UNA CANTIDAD DEL PRODUCTO
                //PARSEAMOS LA CANTIDAD DEL PRODUCTO DE STRING A ENTERO
                if (!string.IsNullOrEmpty(txtCantCompra.Text))
                { cantidad = int.Parse(txtCantCompra.Text); }
                else
                {
                    lblHelpCantCompra.Text = "Este campo es obligatorio";
                    lblHelpCantCompra.CssClass = "text-danger";
                    return;
                }



                //VALIDACIONES

                //VALIDACIÓN PARA QUE  SE SELECCIONE UN PRODUCTO
                if (idProducto == 0)
                {
                    lblHelProdCompra.Text = "Debe seleccionar un Producto.";
                    lblHelProdCompra.CssClass = "text-danger";
                    return;
                }


                //VALIDACIÓN PARA QUE LA CANTIDAD INGRESADA SEA MAYOR A CERO
                if (cantidad < 1)
                {
                    lblHelpCantCompra.Text = "La cantidad debe ser mayor a 0 unidades";
                    lblHelpCantCompra.CssClass = "text-danger";
                    return;
                }

                //VALIDACIÓN PARA QUE LA CANTIDAD INGRESADA NO SEA MAYOR AL STOCK DISPONIBLE
                int stock = producto.StockActual;
                int diferenciaDeStock = stock - cantidad;

                if (!(diferenciaDeStock >= 0))
                {
                    lblHelpCantCompra.Text = "No hay stock suficiente.";
                    lblHelpCantCompra.CssClass = "text-danger";
                    return;
                }

                //AGREGAMOS LA Compra A LA SESIÓN
                Compra compra = (Compra)Session["compra"];

                if (compra == null)
                {
                    compra = new Compra();
                    compra.Detalle = new List<DetalleCompra>();
                    Session["compra"] = compra;
                }


                CompraNegocio CompraNegocio = new CompraNegocio();
                //INSTANCIAMOS ITEM DE LA Compra





                //VALIDACIÓN PARA QUE NO SE REPITE EL ITEM EN EL LISTADO DE ITEMS DE LA Compra
                if (CompraNegocio.ValidarItemExistente(compra.Detalle, idProducto))
                {

                    item = CompraNegocio.ObtenerItemExistente(compra.Detalle, idProducto);

                    int nuevaCantidad = item.Cantidad + cantidad;

                    if (nuevaCantidad > producto.StockActual)
                    {
                        lblHelpCantCompra.Text = "No hay stock suficiente.";
                        lblHelpCantCompra.CssClass = "text-danger";
                        return;
                    }

                    item.Cantidad = nuevaCantidad;


                }
                else
                {
                    item = new DetalleCompra();


                    if (cantidad > producto.StockActual)
                    {
                        lblHelpCantCompra.Text = "No hay stock suficiente.";
                        lblHelpCantCompra.CssClass = "text-danger";
                        return;
                    }

                    item.Producto = producto;
                    item.Cantidad = cantidad;
                    item.PrecioUnidad = producto.PrecioCompra;


                    //AGREGAMOS ITEM AL LISTADO DE PRODUCTOS DE LA Compra
                    compra.Detalle.Add(item);



                }


                //GRILLA PARA VER PRODUCTOS INGRESADOS A LA Compra
                dgvDetalleCompra.DataSource = compra.Detalle;
                dgvDetalleCompra.DataBind();




                //CALCULAR TOTAL DE LA Compra
                decimal totalCompra = compra.Detalle.Sum(x => x.Cantidad * x.PrecioUnidad);
                lbltotalCompraValor.Text = totalCompra.ToString();

            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrio un error al agregar el producto";
                lblError.CssClass = "text-danger";
                throw ex;
            }

        }
    }
}