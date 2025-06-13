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
            if (!IsPostBack)
            {

                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Formulario Modificación de Cliente";
                    btnAgregarCliente.Text = "Modificar";
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = (negocio.listar(id))[0];

                    Session.Add("clienteSeleccionado", seleccionado);
                    
                    txtNombreCliente.Text = seleccionado.Nombre;
                    txtCuilCliente.Text = seleccionado.CuilCuit;
                    txtDireccion.Text = seleccionado.Direccion;
                    txtEmailCliente.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono.ToString();
                }            
            }
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

            if (Request.QueryString["id"] != null)
            {
                nuevo.Id = int.Parse(Request.QueryString["id"]);
                clienteNegocio.modificarCliente(nuevo);
                Session.Remove("clienteSeleccionado");
            }

            else
            {
                clienteNegocio.agregarCliente(nuevo);
            }

            Response.Redirect("Clientes.aspx");
            Context.ApplicationInstance.CompleteRequest();
            
        }
    }
}