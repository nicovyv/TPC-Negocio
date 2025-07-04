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
    public partial class CompraRegistrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Compra compra = null;

            // SIEMPRE cargamos la compra, sea por URL o sesión
            if (Request.QueryString["id"] != null)
            {
                lblTitulo.Text = "Dettalle Compra";
                string idCompra = Request.QueryString["id"];
                CompraNegocio negocio = new CompraNegocio();
                compra = negocio.listar(idCompra).FirstOrDefault();
            }
            else
            {
                lblTitulo.Text = "Compra Exitosa";
                compra = (Compra)Session["compra"];
            }

            if (compra == null)
            {
                Session.Add("error", "No hay datos para mostrar");
                Response.Redirect("Error.aspx", false);
                return;
            }

            // SIEMPRE cargamos los datos para evitar error de validación
            cargarDatosCompra(compra);

            // SOLO si es una nueva compra y no es postback, limpiamos la sesión
            if (!IsPostBack && Request.QueryString["id"] == null)
            {
                Session.Remove("compra");
            }
        
        }

        protected void cargarDatosCompra(Compra compra)
        {
            try
            {
                // Datos del proveedor
                lblNombreProveedorCompraExito.Text = compra.Proveedor?.Nombre;
                lblCuilCompraExito.Text = compra.Proveedor?.CuilCuit;
                lblFechaCompra.Text = compra.Fecha.ToString("dd/MM/yyyy");

                // Detalle de la compra
                repDetalleCompraRegistrada.DataSource = compra.Detalle;
                repDetalleCompraRegistrada.DataBind();

                lblTotalCompraRegistrada.Text = compra.Total.ToString("F2");
            }
            catch (Exception)
            {
                Session.Add("error", "No se pudo visualizar la compra");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}