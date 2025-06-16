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

                if (!negocio.ValidaCodigoProducto(txtCodProd.Text)){
                    return;
                }


                nuevo.Codigo = txtCodProd.Text;
                nuevo.Nombre = txtNombreProd.Text;
                nuevo.Descripcion = txtDescProd.Text;

                nuevo.Marca = new Marca();
                nuevo.Marca.Id = int.Parse(ddlMarcaProd.SelectedValue);

                nuevo.Categoria = new Categoria();
                nuevo.Categoria.Id = int.Parse(ddlCatProd.SelectedValue);

                nuevo.Ganancia = float.Parse(txtGananciaProd.Text);
                nuevo.StockMinimo = int.Parse(txtStockMinimoProd.Text);


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
    }
}