using dominio;
using negocio;
using System;
using System.Collections.Generic;

namespace presentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
            }
        }

        private void cargarClientes()
        {
            if (Security.isAdmin(Session["usuario"]))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add(("listaClientes"), negocio.listar());
                dgvClientesAdmin.DataSource = Session["listaClientes"];
                dgvClientesAdmin.DataBind();
            }
            else
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add(("listaClientes"), negocio.listar());
                dgvClientesVendedor.DataSource = Session["listaClientes"];
                dgvClientesVendedor.DataBind();
            }
            
        }
        protected void dgvClientes_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if(e.CommandName=="Eliminar")
            {
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminarCliente(id);
                cargarClientes();
            }
            else if(e.CommandName == "Modificar")
            {
                Response.Redirect("AltaCliente.aspx?id=" + id);
            }
        }

        protected void txtFiltroCliente_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            List<Cliente> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvClientesAdmin.DataSource = listaFiltrada;
                dgvClientesAdmin.DataBind();
                btnLimpiar.Visible = true;
            }
            else
            {
                dgvClientesVendedor.DataSource = listaFiltrada;
                dgvClientesVendedor.DataBind();
                btnLimpiar.Visible = true;
            }
            
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvClientesAdmin.DataSource = Session["listaClientes"];
                dgvClientesAdmin.DataBind();
                txtFiltro.Text = "";
                btnLimpiar.Visible = false;
            }
            else
            {
                dgvClientesVendedor.DataSource = Session["listaClientes"];
                dgvClientesVendedor.DataBind();
                txtFiltro.Text = "";
                btnLimpiar.Visible = false;
            }
            
        }
    }
}