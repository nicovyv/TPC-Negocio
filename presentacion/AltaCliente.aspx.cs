using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;
namespace presentacion
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            Cliente nuevo = new Cliente(); 
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            nuevo.Nombre = txtNombreCliente.Text;
            nuevo.CuilCuit = txtCuilCliente.Text;
            nuevo.Direccion = txtDireccion.Text;
            nuevo.Telefono = int.Parse(txtTelefono.Text);
            nuevo.Email = txtEmailCliente.Text;

            clienteNegocio.agregarCliente(nuevo);

            Response.Redirect("Clientes.aspx");
            
        }
    }
}