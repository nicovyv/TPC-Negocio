using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCategorias();
                cargarProductos();
            }
 
        }

        protected void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            try
            {
                cliente=clienteNegocio.buscarClientePorCuitCuil(txtBuscadorCliente.Text);
                
                if(cliente.Id!=0 )
                {
                    lblCUIT.Text = cliente.CuilCuit;
                    lblNombre.Text = cliente.Nombre;
                }
                else
                {
                    Session.Add("error", "El cliente no está registrado en el sistema, no se puede realizar la venta");
                    Response.Redirect("Error.aspx",false);
                }
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        private void cargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            ddlCatVenta.DataSource = negocio.listar();
            ddlCatVenta.DataTextField = "Descripcion";
            ddlCatVenta.DataValueField = "Id";
            ddlCatVenta.DataBind();

        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ddlProdVenta.DataSource = negocio.listar();
            ddlProdVenta.DataTextField = "Nombre";
            ddlProdVenta.DataValueField = "Id";
            ddlProdVenta.DataBind();
        }



    }
}