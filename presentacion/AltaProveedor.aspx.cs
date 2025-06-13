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
            if (!IsPostBack)
            {

                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Formulario Modificación de Proveedor";
                    btnAgregarProveedor.Text = "Modificar";
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor seleccionado = (negocio.listar(id))[0];

                    Session.Add("proveedoreSeleccionado", seleccionado);

                    txtNombreProveedor.Text = seleccionado.Nombre;
                    txtCuilProveedor.Text = seleccionado.CuilCuit;
                    txtDireccion.Text = seleccionado.Direccion;
                    txtEmailProveedor.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono.ToString();
                }
            }
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

            if (Request.QueryString["id"] != null)
            {
                nuevo.Id = int.Parse(Request.QueryString["id"]);
                proveedorNegocio.modificarProveedor(nuevo);
                Session.Remove("proveedorSeleccionado");
            }

            else
            {
                proveedorNegocio.agregarProveedor(nuevo);
            }

            Response.Redirect("Proveedores.aspx");
            Context.ApplicationInstance.CompleteRequest();

            
        }
    }
}