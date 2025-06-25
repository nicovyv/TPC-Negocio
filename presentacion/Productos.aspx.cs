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
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            if (!IsPostBack)
            {
                cargarProductos();

                if (Security.isAdmin(Session["usuario"]))
                {
                    btnNuevoProd.Visible = true;
                }
                else
                {
                    btnNuevoProd.Visible = false;
                }

            }


        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProducto.DataSource = negocio.listar();
            dgvProducto.DataBind();
        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvProducto_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            dgvProducto.PageIndex = e.NewPageIndex;
            dgvProducto.DataBind();
        }

        protected void dgvProducto_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {

            string id = e.CommandArgument.ToString();

            if (e.CommandName == "Modificar")
            {
                Response.Redirect("FormProductos.aspx?id=" + id + "&accion=modificar");
            }
            else if (e.CommandName == "Detalle")
            {
                Response.Redirect("FormProductos.aspx?id=" + id + "&accion=detalle");
            }

        }

        protected void btnNuevoProd_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormProductos.aspx");
        }

        //protected void dgvProducto_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
        //    Button btnModProd = 
        //}

    }
}