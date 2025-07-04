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
                    limpiarCampos();
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
                        //txtProdPrecio.Text = producto.PrecioCompra.ToString();
                        txtProdStock.Text = producto.StockActual.ToString();
                        txtMinimo.Text = producto.StockMinimo.ToString();
                    }
                    else
                    {
                        ddlProdCompra.Items.Clear();
                        txtProdPrecio.Text = "";
                        txtProdStock.Text = "";
                        txtMinimo.Text = "";
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

        private void corroborarPrecioExistente(int idProducto)
        {
            Compra compra = (Compra)Session["compra"];
            txtProdPrecio.Text = "";
            txtCantCompra.Text = "";

            if (compra != null)
            {
                var itemExistente = compra.Detalle.FirstOrDefault(x => x.Producto.Id == idProducto);
                if (itemExistente != null)
                {
                    txtProdPrecio.Enabled = false;
                    txtProdPrecio.Text = itemExistente.PrecioUnidad.ToString();
                }
                else
                {
                    txtProdPrecio.Enabled = true;
                }
            }
            else
            {
                txtProdPrecio.Enabled = true;
            }
        }

        private void limpiarCampos()
        {
            txtProdPrecio.Text = "";
            txtCantCompra.Text = "";
            txtProdStock.Text = "";
            txtMinimo.Text = "";
            txtProdPrecio.Enabled = true;
        }
        protected void ddlProdCompra_SelectedIndexChanged(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
            int idProducto = int.Parse(ddlProdCompra.SelectedValue);

            limpiarCampos();
            

            Producto producto = negocio.ObtenerPorId(idProducto);
            txtProdStock.Text = producto.StockActual.ToString();
            txtMinimo.Text = producto.StockMinimo.ToString();

            corroborarPrecioExistente(idProducto);
        }

        protected void ddlCatCompra_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCampos();
            ProductoNegocio productoNegocio = new ProductoNegocio();

            int idCategoria = int.Parse(ddlCatCompra.SelectedValue);
            List<Producto> productosFiltrados = productoNegocio.FiltrarCategoria(idCategoria);

            if (productosFiltrados.Count > 0)
            {
                ddlProdCompra.DataSource = productosFiltrados;
                ddlProdCompra.DataTextField = "Nombre";
                ddlProdCompra.DataValueField = "Id";
                ddlProdCompra.DataBind();

                int idProducto = int.Parse(ddlProdCompra.SelectedValue);
                Producto producto = productoNegocio.ObtenerPorId(idProducto);
                txtProdStock.Text = producto.StockActual.ToString();
                txtMinimo.Text = producto.StockMinimo.ToString();


            }
            else
            {
                ddlProdCompra.Items.Clear();
                txtProdPrecio.Text = "";
                txtProdStock.Text = "";
                txtMinimo.Text = "";
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
            try
            {
                CompraNegocio negocio = new CompraNegocio();
                Compra compra = (Compra)Session["compra"];
                Proveedor proveedor = (Proveedor)Session["proveedor"];

                compra.Proveedor = proveedor;
                compra.Fecha = DateTime.Now;


                negocio.Agregar(compra);


                limpiarCampos();
                Response.Redirect("CompraRegistrada.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {
                Session.Remove("compra");
                Session.Add("error", "No se pudo registrar la compra" + ex.ToString());
                Response.Redirect("Error.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
                throw;
            }
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
                            limpiarCampos();
                            corroborarPrecioExistente(idProd);
                            

                            
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
                    lblHelpCantCompra.Text = "El campo de Cantidad es obligatorio";
                    lblHelpCantCompra.CssClass = "text-danger";
                    return;
                }

                if (string.IsNullOrEmpty(txtProdPrecio.Text))
                {
                    lblHelpCantCompra.Text = "El campo de Precio Unitario es obligatorio";
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
                Compra compra = (Compra)Session["compra"];

                if (compra == null)
                {
                    compra = new Compra();
                    compra.Detalle = new List<DetalleCompra>();
                    Session["compra"] = compra;
                }

                CompraNegocio CompraNegocio = new CompraNegocio();

                item = CompraNegocio.ObtenerItemExistente(compra.Detalle, idProducto);

                if (item != null)
                {
                    cantidad += item.Cantidad;

                }



                //VALIDACIÓN PARA QUE LA CANTIDAD INGRESADA SEA MAYOR AL STOCK MINIMO
                int stock = producto.StockActual;
                int stockMin = producto.StockMinimo;
                int diferenciaDeStock = (stock - stockMin) + cantidad;

                if (!(diferenciaDeStock >= 0))
                {
                    diferenciaDeStock *= -1;
                    lblHelpCantCompra.Text = "Debe comprar " + diferenciaDeStock + " unidades más para cumplir con el stock minimo.";
                    lblHelpCantCompra.CssClass = "text-danger";
                    //txtCantCompra.Text = diferenciaDeStock.ToString();
                    return;
                }

                if (item != null)
                {
                    item.Cantidad = cantidad;

                    if(item.PrecioUnidad == 0)
                    {
                        item.PrecioUnidad = decimal.Parse(txtProdPrecio.Text);
                    }
                }

                if (!CompraNegocio.ValidarItemExistente(compra.Detalle, idProducto))
                {

                    item = new DetalleCompra();
                    int precioUnidad = int.Parse(txtProdPrecio.Text);
                    item.Producto = producto;
                    item.Cantidad = cantidad;
                    string precioTexto = txtProdPrecio.Text.Replace(',', '.'); //admitimos . o , cuando se ingresa numero con decimal
                    item.PrecioUnidad = decimal.Parse(txtProdPrecio.Text);



                    //AGREGAMOS ITEM AL LISTADO DE PRODUCTOS DE LA Compra
                    compra.Detalle.Add(item);

                }

                txtProdPrecio.Enabled = false;

                //GRILLA PARA VER PRODUCTOS INGRESADOS A LA Compra
                dgvDetalleCompra.DataSource = compra.Detalle;
                dgvDetalleCompra.DataBind();
                
                limpiarCampos();


                //CALCULAR TOTAL DE LA Compra
                decimal totalCompra = compra.Detalle.Sum(x => x.Cantidad * x.PrecioUnidad);
                lbltotalCompraValor.Text = totalCompra.ToString();
                lblHelpCantCompra.Text = "";
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