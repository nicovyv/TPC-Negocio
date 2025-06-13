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
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            Proveedor nuevo = new Proveedor(); 
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            nuevo.Nombre = txtNombreProveedor.Text;
            nuevo.CuilCuit = txtCuilProveedor.Text;
            nuevo.Direccion = txtDireccion.Text;
            nuevo.Telefono = int.Parse(txtTelefono.Text);
            nuevo.Email = txtEmailProveedor.Text;

            proveedorNegocio.agregarProveedor(nuevo);

            Response.Redirect("Proveedores.aspx");
        }
    }
}