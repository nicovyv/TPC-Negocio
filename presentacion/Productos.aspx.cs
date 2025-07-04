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

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvProductoAdmin.DataSource = negocio.listar();
                dgvProductoAdmin.DataBind();
            }
            else
            {
                dgvProductoVendedor.DataSource = negocio.listar();
                dgvProductoVendedor.DataBind();
            }


        }

        protected void dgvProducto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void dgvProducto_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            //dgvProducto.PageIndex = e.NewPageIndex;
            //dgvProducto.DataBind();
            ProductoNegocio negocio = new ProductoNegocio();

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvProductoAdmin.PageIndex = e.NewPageIndex;
                dgvProductoAdmin.DataSource = negocio.listar();
                dgvProductoAdmin.DataBind();
            }
            else
            {
                dgvProductoVendedor.PageIndex = e.NewPageIndex;
                dgvProductoVendedor.DataSource = negocio.listar();
                dgvProductoVendedor.DataBind();
            }


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

        protected void btnProdBaja_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductosInactivosLista.aspx");



        }

        protected void txtBuscadorProd_TextChanged(object sender, EventArgs e)
        {
            //    List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            //    List<Marca> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            //    dgvMarcas.DataSource = listaFiltrada;
            //    dgvMarcas.DataBind();
            //    btnLimpiar.Visible = true;

            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto> productos = negocio.listar();

            List<Producto> productosFiltrados = productos.FindAll(x => x.Nombre.ToUpper().Contains(txtBuscadorProd.Text.ToUpper()));

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvProductoAdmin.DataSource = productosFiltrados;
                dgvProductoAdmin.DataBind();
            }
            else if (Security.isLogin(Session["usuario"]))
            {
                dgvProductoVendedor.DataSource = productosFiltrados;
                dgvProductoVendedor.DataBind();

            }
            else
            {
                Session.Add("error", "Debes estar logueado.");
                Response.Redirect("Error.aspx");
            }


            btnLimpiarBuscadorProd.Visible = true;


        }

        protected void btnLimpiarBuscadorProd_Click(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvProductoAdmin.DataSource = negocio.listar();
                dgvProductoAdmin.DataBind();
            }
            else
            {
                dgvProductoVendedor.DataSource = negocio.listar();
                dgvProductoVendedor.DataBind();
            }
            txtBuscadorProd.Text = "";
            btnLimpiarBuscadorProd.Visible = false;
        }
    }
}