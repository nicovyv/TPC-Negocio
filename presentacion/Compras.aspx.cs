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
            dgvCompra.DataSource = Session["listaCompras"];
            dgvCompra.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Compra> lista = (List<Compra>)Session["listaCompras"];
            string filtro = txtFiltro.Text.Trim().ToUpper();

            List<Compra> listaFiltrada = lista.FindAll(x =>
                (!string.IsNullOrEmpty(x.Proveedor.CuilCuit) && x.Proveedor.CuilCuit.ToUpper().Contains(filtro)) ||
                (!string.IsNullOrEmpty(x.Proveedor.Nombre) && x.Proveedor.Nombre.ToUpper().Contains(filtro))
            );

            dgvCompra.DataSource = listaFiltrada;
            dgvCompra.DataBind();
            btnLimpiar.Visible = true;
        }
    }
}