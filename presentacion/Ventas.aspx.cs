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
        Venta venta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }



        }

        protected void btnAsignarCliente_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();



            try
            {
                cliente = clienteNegocio.buscarClientePorCuitCuil(txtBuscadorCliente.Text);
                //GENERAMOS UNA NUEVA VENTA
                venta = new Venta();
                //ASIGNAMOS CLIENTE A LA VENTA
                venta.Cliente = new Cliente();
                venta.Cliente = cliente;

                if (cliente.Id != 0)
                {
                    txtCuit.Text = cliente.CuilCuit;
                    txtnombreCliente.Text = cliente.Nombre;
                }
                else
                {
                    Session.Add("error", "El cliente no está registrado en el sistema, no se puede realizar la venta");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void btnIngresarProductos_Click(object sender, EventArgs e)
        {
            if (Session["venta"] == null)
            {
                Venta venta = new Venta();
                venta.ItemVenta = new List<ItemVenta>();
                Session.Add("venta", venta);
            }


            Response.Redirect("IngresarProductosVenta.aspx", false);
        }


      
    }
}