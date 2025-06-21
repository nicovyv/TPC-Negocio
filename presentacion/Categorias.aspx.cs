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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCategorias();
            }
        }
        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            Session.Add(("listaCategorias"), negocio.listar());
            dgvCategorias.DataSource = Session["listaCategorias"];
            dgvCategorias.DataBind();
        }        

        protected void dgvCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminarCategoria(id);
                cargarCategorias();
            }
            else if (e.CommandName == "Modificar")
            {
                Response.Redirect("AltaCategoria.aspx?id=" + id);
            }
        }

        protected void dgvCategorias_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCategorias.PageIndex = e.NewPageIndex;
            cargarCategorias();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvCategorias.DataSource = Session["listaCategorias"];
            dgvCategorias.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> lista = (List<Categoria>)Session["listaCategorias"];
            List<Categoria> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvCategorias.DataSource = listaFiltrada;
            dgvCategorias.DataBind();
            btnLimpiar.Visible = true;
        }
    }
    
}