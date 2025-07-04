using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class ProductosInactivosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosInactivos();
            }
        }


        private void CargarProductosInactivos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaInactivos = negocio.listarProdBaja();
            dgvProdInactivos.DataSource = listaInactivos;
            dgvProdInactivos.DataBind();
        }
    }
}