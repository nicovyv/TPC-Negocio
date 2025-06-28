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
            cargarDatosVenta();
        }



        protected void cargarDatosVenta()
        {
            try
            {
                Cliente cliente = new Cliente();
                cliente = (Cliente)Session["cliente"];

                lblNombreClienteVentaExito.Text = cliente.Nombre;
                lblCuilVentaExito.Text = cliente.CuilCuit;
                lblFechaVentaExito.Text = DateTime.Now.ToString();

                
                


                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}