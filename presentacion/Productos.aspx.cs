using dominio;
using System;
using System.Collections.Generic;
using negocio;

namespace presentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProducto.DataSource = negocio.listar();
            dgvProducto.DataBind();
        }
    }
}