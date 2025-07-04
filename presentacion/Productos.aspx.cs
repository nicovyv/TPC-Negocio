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
                CargarFiltros();

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


        protected void CargarFiltros()
        {
            CategoriaNegocio negocioCategoria = new CategoriaNegocio();
            List<Categoria> categorias = negocioCategoria.listar();
            ddlFiltroCategoria.DataSource = categorias;
            ddlFiltroCategoria.DataTextField = "Descripcion";
            ddlFiltroCategoria.DataValueField = "Id";

            ddlFiltroCategoria.DataBind();
            ddlFiltroCategoria.Items.Insert(0, new ListItem("Todas las categorías", "0"));




            MarcaNegocio negocioMarca = new MarcaNegocio();
            List<Marca> marcas = negocioMarca.listar();
            ddlFiltroMarca.DataSource = marcas;
            ddlFiltroMarca.DataTextField = "Descripcion";
            ddlFiltroMarca.DataValueField = "Id";
            
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.Items.Insert(0, new ListItem("Todas las marcas", "0"));

        }

        protected void ddlFiltroCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();

        }

        protected void ddlFiltroMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }


        protected void AplicarFiltros()
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();


            int idCategoria = 0;
            int idMarca = 0;

            if (!(string.IsNullOrEmpty(ddlFiltroCategoria.SelectedValue)))
            {
                idCategoria = int.Parse(ddlFiltroCategoria.SelectedValue);
            }

            if (!(string.IsNullOrEmpty(ddlFiltroMarca.SelectedValue)))
            {
                idMarca = int.Parse(ddlFiltroMarca.SelectedValue);
            }

            List<Producto> productosFiltrados = new List<Producto>();

            if (idMarca > 0 && idCategoria  > 0)
            {
                productosFiltrados = productoNegocio.FiltrarMarcaCategoria(idMarca, idCategoria);
            }
            else if (idMarca > 0)
            {
                productosFiltrados = productoNegocio.FiltrarMarca(idMarca);
            }
            else if(idCategoria > 0)
            {
                productosFiltrados = productoNegocio.FiltrarCategoria(idCategoria);
            }
            else
            {
                productosFiltrados = productoNegocio.listar();
            }




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


        }

      
    }
}