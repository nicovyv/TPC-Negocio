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
    public partial class ProductosInactivosLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosInactivos();
            }
        }


        private void CargarProductosInactivos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> listaInactivos = negocio.listarProdBaja();
            dgvProdInactivos.DataSource = listaInactivos;
            dgvProdInactivos.DataBind();
        }

        protected void dgvProdInactivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DarAlta")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ProductoNegocio negocio = new ProductoNegocio();


                try
                {
                    negocio.Activar(id);
                    CargarProductosInactivos();

                    lblMsjProdActivo.Text = "Producto reactivado correctamente.";
                    lblMsjProdActivo.CssClass = "alert alert-success text-center d-block";
                    lblMsjProdActivo.Visible = true;


                }
                catch (Exception)
                {
                    Session.Add("error", "No se pudo reactivar el producto.");
                    Response.Redirect("Error.aspx");
                }

            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void btnIrAProd_Click(object sender, EventArgs e)
        {

        }
    }
}