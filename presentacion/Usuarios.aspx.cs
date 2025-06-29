using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace presentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuarios();
            }
        }
        private void cargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Session.Add(("listaUsuarios"), negocio.Listar());
            dgvUsuarios.DataSource = Session["listaUsuarios"];
            dgvUsuarios.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvUsuarios.DataSource = Session["listaUsuarios"];
            dgvUsuarios.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Usuario> lista = (List<Usuario>)Session["listaUsuarios"];
            List<Usuario> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvUsuarios.DataSource = listaFiltrada;
            dgvUsuarios.DataBind();
            btnLimpiar.Visible = true;
        }

        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Desactivar")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Desactivar(id);
                cargarUsuarios();
            }
            else if(e.CommandName == "Activar")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Activar(id);
                cargarUsuarios();
            }
            else if (e.CommandName == "Vendedor")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Vendedor(id);
                cargarUsuarios();
            }
            else if (e.CommandName == "Admin")
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.Admin(id);
                cargarUsuarios();
            }

        }
    }
}