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
                cargarBajas();
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
                cargarBajas();
            }
            else if(e.CommandName == "Modificar")
            {
                Response.Redirect("AltaCliente.aspx?id=" + id);
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

        private void cargarBajas()
        {
            if (Security.isAdmin(Session["usuario"]))
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Session.Add(("listaClientesBaja"), negocio.listarBajas());
                dgvBajas.DataSource = Session["listaClientesBaja"];
                dgvBajas.DataBind();
            }
        }
        protected void dgvBajas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Reactivar")
            {
                ClienteNegocio negocio = new ClienteNegocio();
                negocio.reactivarCliente(id);
                cargarClientes();
                cargarBajas();
            }
            
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            if (Security.isAdmin(Session["usuario"]))
            {
                dgvBajas.DataSource = Session["listaClientesBaja"];
                dgvBajas.DataBind();
                txtBaja.Text = "";
                btnBaja.Visible = false;
            }
        }

        protected void txtBaja_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientesBaja"];
            List<Cliente> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtBaja.Text.ToUpper()));

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvBajas.DataSource = listaFiltrada;
                dgvBajas.DataBind();
                btnBaja.Visible = true;
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
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
    }
}