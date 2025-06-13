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
            List<Cliente> listaClientes = new List<Cliente>();
            ClienteNegocio negocio = new ClienteNegocio();
            listaClientes = negocio.listar();
            dgvClientes.DataSource = listaClientes;
            dgvClientes.DataBind();
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
    }
}