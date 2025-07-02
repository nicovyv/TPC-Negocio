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
    public partial class VentaRegistrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                cargarDatosVenta();
            } 

        }



        protected void cargarDatosVenta()
        {
            try
            {
              //  Cliente cliente = new Cliente();
               // cliente = (Cliente)Session["cliente"];
                Venta venta = new Venta();
                venta = (Venta)Session["venta"];

                lblNombreClienteVentaExito.Text = venta.Cliente.Nombre;
                lblCuilVentaExito.Text = venta.Cliente.CuilCuit;
                lblFechaVentaExito.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblFacturaVenta.Text = venta.Factura.ToString();

               

                repDetalleVentaRegistrada.DataSource = venta.ItemVenta;
                repDetalleVentaRegistrada.DataBind();

                lblTotalVentaRegistrada.Text = venta.Total.ToString();


            }
            catch (Exception)
            {

                Session.Add("error", "No se pudo visualizar venta");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}