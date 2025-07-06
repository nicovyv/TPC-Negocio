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
                dgvHistorialVentas.DataSource = negocioVenta.Listar();
                dgvHistorialVentas.DataBind();

            }
        }

        protected void dgvHistorialVentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DetalleVenta")
            {
                int idVenta = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("VentaRegistrada.aspx?id=" + idVenta);
            }
        }

        protected void txtBuscarVentas_TextChanged(object sender, EventArgs e)
        {
            VentaNegocio negocioVenta = new VentaNegocio();
            List<Venta> listaVentas = negocioVenta.Listar();

            string filtro = txtBuscarVentas.Text.Trim().ToLower();

            List<Venta> listaFiltrada;

            if (string.IsNullOrEmpty(filtro))
            {
                listaFiltrada = listaVentas;
                btnLimpiarBusquedaVentas.Visible = false;
            }
            else
            {
                // Intentar convertir filtro a int para comparar con factura
                bool esNumero = int.TryParse(filtro, out int filtroFactura);

                listaFiltrada = listaVentas.FindAll(v =>
                    (!string.IsNullOrEmpty(v.Cliente.CuilCuit) && v.Cliente.CuilCuit.ToLower().Contains(filtro)) ||
                    (esNumero && v.Factura == filtroFactura)
                );

                btnLimpiarBusquedaVentas.Visible = true;
            }

            dgvHistorialVentas.DataSource = listaFiltrada;
            dgvHistorialVentas.DataBind();
        }

        protected void btnLimpiarBusquedaVentas_Click(object sender, EventArgs e)
        {
            txtBuscarVentas.Text = string.Empty;
            btnLimpiarBusquedaVentas.Visible = false;

            VentaNegocio negocioVenta = new VentaNegocio();
            dgvHistorialVentas.DataSource = negocioVenta.Listar();
            dgvHistorialVentas.DataBind();
        }
    }
}