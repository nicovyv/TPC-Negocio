using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace presentacion
{
    public partial class VentasListado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                VentaNegocio negocioVenta = new VentaNegocio();
                dgvHistorialVentas.DataSource =  negocioVenta.Listar();
                dgvHistorialVentas.DataBind();
                
            }
        }

        protected void dgvHistorialVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "DetalleVenta")
            {
                int idVenta = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("VentaRegistrada.aspx?id=" + idVenta);
            }
        }
    }
}