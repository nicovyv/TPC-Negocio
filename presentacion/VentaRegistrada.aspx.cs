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
            {   // PREGUNTAMOS SI VIENE UN ID DE VENTA POR URL
               if(Request.QueryString["id"] != null)
                {
                    string idVenta = Request.QueryString["id"];
                    VentaNegocio negocio = new VentaNegocio();
                    // RECUPERAMOS LA VENTA
                    Venta venta = negocio.Listar(idVenta).FirstOrDefault();

                    if(venta != null)
                    {   // CARGAMOS LOS DATOS 
                        cargarDatosVenta(venta);
                    }
                    else
                    {
                        Session.Add("error", "Venta no encontrada");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {   // SI NO VIENE POR URL ENTONCES ES UNA NUEVA VENTA, Y LA RECUPERAMOS DE LA SESIÓN
                    Venta venta = (Venta)Session["venta"];

                    if(venta != null)
                    {
                        cargarDatosVenta(venta);
                    }
                    else
                    {
                        Session.Add("error", "No hay datos para mostrar");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                
            } 

        }


        // CARGA DE CONTROLES PARA LA VISTA
        protected void cargarDatosVenta(Venta venta)
        {
            try
            {
              //  Cliente cliente = new Cliente();
               // cliente = (Cliente)Session["cliente"];
              //  Venta venta = new Venta();
               // venta = (Venta)Session["venta"];

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