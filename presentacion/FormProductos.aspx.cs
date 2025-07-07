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
    public partial class FormProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                CargarListas();

                string id = Request.QueryString["id"];
                string accion = Request.QueryString["accion"];

                if (string.IsNullOrEmpty(id))
                {
                    if ((Security.isAdmin(Session["usuario"])))
                    {
                        FormularioAlta();
                    }

                }
                else
                {
                    if ((Security.isAdmin(Session["usuario"])) && accion == "modificar")
                    {
                        cargarProductosModificacion(int.Parse(id));
                        btnBajaProd.Visible = true;
                    }


                    else if (accion == "detalle")
                        CargarDetalleProducto(int.Parse(id));
                }

            }


        }

        private void cargarProductosModificacion(int id)
        {
            ProductoNegocio necgocio = new ProductoNegocio();
            Producto producto = necgocio.ObtenerPorId(id);

            if (producto != null)
            {
                lblTitulo.Text = "Modificar Producto";

                txtCodProd.Text = producto.Codigo;
                txtCodProd.Enabled = false;

                txtNombreProd.Text = producto.Nombre;
                txtDescProd.Text = producto.Descripcion;

                ddlCatProd.SelectedValue = producto.Categoria.Id.ToString();
                ddlMarcaProd.SelectedValue = producto.Marca.Id.ToString();

                txtPrecioVentaProd.Text = producto.PrecioVenta.ToString();
                txtPrecioVentaProd.Enabled = false;

                txtPrecioCompraProd.Text = producto.PrecioCompra.ToString();
                txtPrecioCompraProd.Enabled = false;

                txtStockActualProd.Text = producto.StockActual.ToString();
                txtStockActualProd.Enabled = false;

                txtStockMinimoProd.Text = producto.StockMinimo.ToString();
                txtGananciaProd.Text = producto.Ganancia.ToString();

                foreach (ListItem prov in cblProveedoresProd.Items)
                {
                    prov.Selected = producto.Proveedores.Any(x => x.Id.ToString() == prov.Value);
                }
            }




        }

        private void CargarDetalleProducto(int id)
        {

            try
            {
                ProductoNegocio necgocio = new ProductoNegocio();
                Producto producto = necgocio.ObtenerPorId(id);

                if (producto != null)
                {

                    lblTitulo.Text = "Detalle de Producto";

                    btnGuardarProd.Visible = false;

                    txtCodProd.Text = producto.Codigo;
                    txtCodProd.Enabled = false;

                    txtNombreProd.Text = producto.Nombre;
                    txtNombreProd.Enabled = false;

                    txtDescProd.Text = producto.Descripcion;
                    txtDescProd.Enabled = false;

                    ddlCatProd.SelectedValue = producto.Categoria.Id.ToString();
                    ddlCatProd.Enabled = false;

                    ddlMarcaProd.SelectedValue = producto.Marca.Id.ToString();
                    ddlMarcaProd.Enabled = false;

                    txtPrecioVentaProd.Text = producto.PrecioVenta.ToString();
                    txtPrecioVentaProd.Enabled = false;

                    txtPrecioCompraProd.Text = producto.PrecioCompra.ToString();
                    txtPrecioCompraProd.Enabled = false;

                    txtStockActualProd.Text = producto.StockActual.ToString();
                    txtStockActualProd.Enabled = false;

                    txtStockMinimoProd.Text = producto.StockMinimo.ToString();
                    txtStockMinimoProd.Enabled = false;

                    txtGananciaProd.Text = producto.Ganancia.ToString();
                    txtGananciaProd.Enabled = false;

                    foreach (ListItem prov in cblProveedoresProd.Items)
                    {
                        prov.Selected = producto.Proveedores.Any(x => x.Id.ToString() == prov.Value);
                    }

                    cblProveedoresProd.Enabled = false;

                }

            }
            catch (Exception)
            {

                throw;
            }


        }


        private void FormularioAlta()
        {
            divPrecioCompra.Visible = false;
            divPrecioVenta.Visible = false;
            divStockActual.Visible = false;
        }



        private void CargarListas()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            try
            {
                ddlMarcaProd.DataSource = marcaNegocio.listar();
                ddlMarcaProd.DataValueField = "Id";
                ddlMarcaProd.DataTextField = "Descripcion";
                ddlMarcaProd.DataBind();


                ddlCatProd.DataSource = categoriaNegocio.listar();
                ddlCatProd.DataValueField = "Id";
                ddlCatProd.DataTextField = "Descripcion";
                ddlCatProd.DataBind();


                cblProveedoresProd.DataSource = proveedorNegocio.listar();
                cblProveedoresProd.DataValueField = "Id";
                cblProveedoresProd.DataTextField = "Nombre";
                cblProveedoresProd.DataBind();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnGuardarProd_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            ProductoNegocio negocio = new ProductoNegocio();
            Producto nuevo = new Producto();

            try
            {

                if (!ValidarCamposObligatorios())
                {
                    return;
                }


                int idProducto = 0;

                if (Request.QueryString["id"] != null)
                    int.TryParse(Request.QueryString["id"], out idProducto);

                nuevo.Id = idProducto;

                if (!negocio.ValidaCodigoProducto(txtCodProd.Text, idProducto))
                {
                    lblErrorCodProd.Text = "El código de producto ya existe";
                    lblErrorCodProd.CssClass = "text-danger";
                    lblErrorCodProd.Visible = true;
                    return;
                }


                nuevo.Codigo = txtCodProd.Text;
                nuevo.Nombre = txtNombreProd.Text;
                nuevo.Descripcion = txtDescProd.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarcaProd.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCatProd.SelectedValue);


                if (!float.TryParse(txtGananciaProd.Text, out float ganancia))
                {
                    lblErrorGananciaProd.Text = "Debe ingresar un número válido";
                    lblErrorGananciaProd.Visible = true;
                    return;
                }

                //nuevo.Ganancia = float.Parse(txtGananciaProd.Text);
                nuevo.Ganancia = ganancia;


                if (!int.TryParse(txtStockMinimoProd.Text, out int stockMinimo))
                {
                    lblErrorStockMinimoProd.Text = "Debe ingresar un número válido";
                    lblErrorStockMinimoProd.Visible = true;
                    return;
                }
                //nuevo.StockMinimo = int.Parse(txtStockMinimoProd.Text);
                nuevo.StockMinimo = stockMinimo;



                nuevo.PrecioCompra = 0;
                nuevo.PrecioVenta = 0;
                nuevo.StockActual = 0;


                nuevo.Proveedores = new List<Proveedor>();
                foreach (ListItem item in cblProveedoresProd.Items)
                {
                    if (item.Selected)
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.Id = int.Parse(item.Value);
                        nuevo.Proveedores.Add(proveedor);
                    }
                }

                if (nuevo.Id == 0)
                {
                    negocio.Agregar(nuevo);
                }
                else
                {
                    negocio.Modificar(nuevo);
                }
                // negocio.Agregar(nuevo);

                Response.Redirect("Productos.aspx");

            }
            catch (Exception)
            {

                throw;
            }


        }




        private bool ValidarCamposObligatorios()
        {
            bool valida = true;

            lblErrorCodProd.Visible = false;
            lblErrorNombreProd.Visible = false;
            lblErrorDescProd.Visible = false;
            lblErrorGananciaProd.Visible = false;

            if (string.IsNullOrEmpty(txtCodProd.Text))
            {
                lblErrorCodProd.Text = "CAMPO REQUERIDO";
                lblErrorCodProd.CssClass = "text-danger";
                lblErrorCodProd.Visible = true;

                valida = false;
            }

            if (string.IsNullOrEmpty(txtNombreProd.Text))
            {
                lblErrorNombreProd.Text = "CAMPO REQUERIDO";
                lblErrorNombreProd.CssClass = "text-danger";
                lblErrorNombreProd.Visible = true;

                valida = false;
            }


            if (string.IsNullOrEmpty(txtDescProd.Text))
            {
                lblErrorDescProd.Text = "CAMPO REQUERIDO";
                lblErrorDescProd.CssClass = "text-danger";
                lblErrorDescProd.Visible = true;

                valida = false;
            }

            if (string.IsNullOrEmpty(txtGananciaProd.Text))
            {
                lblErrorGananciaProd.Text = "CAMPO REQUERIDO";
                lblErrorGananciaProd.CssClass = "text-danger";
                lblErrorGananciaProd.Visible = true;

                valida = false;
            }




            return valida;
        }

        protected void btnBajaProd_Click(object sender, EventArgs e)
        {
           
           

            try
            {
                ProductoNegocio negocio = new ProductoNegocio();

                int idProducto = int.Parse(Request.QueryString["Id"]);

                negocio.eliminar(idProducto);

                lblMsjBajaProd.Text = "Producto dado de baja.";
                lblMsjBajaProd.CssClass = "alert alert-warning text-center d-block";
                lblMsjBajaProd.Visible = true;

                // Response.Redirect("Productos.aspx");

            }
            catch (Exception)
            {

                Session.Add("error", "No se pudo dar de baja el producto.");
                Response.Redirect("Error.aspx");
            }
        }
    }
}