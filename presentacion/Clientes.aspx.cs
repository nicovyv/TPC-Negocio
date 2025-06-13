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
            cargarClientes();
        }

        private void cargarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            ClienteNegocio negocio = new ClienteNegocio();
            listaClientes = negocio.listar();
            dgvClientes.DataSource = listaClientes;
            dgvClientes.DataBind();
        }
    }
}