using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class CompraRegistrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatosCompra();
            }
        }

        protected void cargarDatosCompra()
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                proveedor = (Proveedor)Session["proveedor"];

                lblNombreProveedorCompraExito.Text = proveedor.Nombre;
                lblCuilCompraExito.Text = proveedor.CuilCuit;
                lblFechaCompra.Text = DateTime.Now.ToString("dd/MM/yyyy");


                Compra compra = new Compra();
                compra = (Compra)Session["compra"];

                repDetalleCompraRegistrada.DataSource = compra.Detalle;
                repDetalleCompraRegistrada.DataBind();

                lblTotalCompraRegistrada.Text = compra.Total.ToString();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}