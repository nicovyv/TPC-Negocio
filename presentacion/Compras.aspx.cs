using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCompras();
            }
        }

        private void cargarCompras()
        {
            CompraNegocio compraNegocio = new CompraNegocio();
            Session.Add(("listaCompras"), compraNegocio.listar());
            dgvCompra.DataSource = Session["listaCompras"];
            dgvCompra.DataBind();
        }
        protected void dgvCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "VerDetalle")
            {
                int idCompra = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("CompraRegistrada.aspx?id=" + idCompra);
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}