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

                foreach (ListItem item in cblProveedoresProd.Items)
                {
                    item.Attributes["class"] = "list-group-item";
                }
            }

            string id = Request.QueryString["id"];

            if (string.IsNullOrEmpty(id))
            {
                FormularioAlta();
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
            ProductoNegocio negocio = new ProductoNegocio();
            Producto nuevo = new Producto();

            try
            {

                if (!ValidarCamposObligatorios())
                {
                    return;
                }

                if (!negocio.ValidaCodigoProducto(txtCodProd.Text))
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


                negocio.Agregar(nuevo);




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




    }
}