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
    public partial class FormCompra : System.Web.UI.Page
    {
        Compra compra;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnIngresarProductos.Visible = false;
            }
        }

        protected void btnIngresarProductos_Click(object sender, EventArgs e)
        {
            if (Session["compra"] == null)
            {
                Compra compra = new Compra();
                compra.Detalle = new List<DetalleCompra>();
                Session.Add("compra", compra);
            }


            Response.Redirect("IngresarProductosCompra.aspx", false);
        }



        protected void btnAsignarProveedor_Click(object sender, EventArgs e)
        {
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
            Proveedor proveedor = new Proveedor();



            try
            {
                proveedor = proveedorNegocio.buscarProveedorPorCuitCuil(txtBuscadorProveedor.Text);
                //GENERAMOS UNA NUEVA COMPRA
                compra = new Compra();
                //ASIGNAMOS CLIENTE A LA COMPRA
                compra.Proveedor = new Proveedor();
                compra.Proveedor = proveedor;

                if (proveedor.Id != 0)
                {
                    txtCuit.Text = proveedor.CuilCuit;
                    txtnombreProveedor.Text = proveedor.Nombre;


                    Session.Add("proveedor", proveedor);

                    btnIngresarProductos.Visible = true;
                }
                else
                {
                    Session.Add("error", "El proveedor no está registrado en el sistema, no se puede realizar la compra");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}