using dominio;
using negocio;
using System;

namespace presentacion
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
              cliente=clienteNegocio.buscarClientePorCuitCuil(txtBuscadorCliente.Text);
                lblCUIT.Text = cliente.CuilCuit;
                lblNombre.Text = cliente.Nombre;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}