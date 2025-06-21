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
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMarcas();
            }            
            
        }
        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Session.Add(("listaMarcas"), negocio.listar());
            dgvMarcas.DataSource = Session["listaMarcas"];
            dgvMarcas.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvMarcas.DataSource = Session["listaMarcas"];
            dgvMarcas.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvMarcas.DataSource = listaFiltrada;
            dgvMarcas.DataBind();
            btnLimpiar.Visible = true;
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarca(id);
                cargarMarcas();
            }
            else if (e.CommandName == "Modificar")
            {
                Response.Redirect("AltaMarca.aspx?id=" + id);
            }
        }
    }
}