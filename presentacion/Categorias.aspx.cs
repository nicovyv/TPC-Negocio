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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarCategorias();
        }
        private void cargarCategorias()
        {
            List<Categoria> listaCategorias = new List<Categoria>();
            CategoriaNegocio negocio = new CategoriaNegocio();
            //{
            //    new Marca { Descripcion = "DESKTOPS" },
            //    new Marca { Descripcion = "NOTEBOOKS" },
            //    new Marca { Descripcion = "CELULARES" }
            // };
            //dgvCategorias.DataSource = listaCategorias;
            listaCategorias = negocio.listar();
            dgvCategorias.DataSource = listaCategorias;
            dgvCategorias.DataBind();
        }

        protected void On_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNuevaCat.Text))
            {
                try
                {
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtNuevaCat.Text.Trim();

                    CategoriaNegocio negocio = new CategoriaNegocio();
                    negocio.agregar(nueva);
                    cargarCategorias();
                }
                catch (Exception ex)
                {

                    //throw ex;
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {

                lblErrorCatNueva.Text = "Se debe completar el campo";
                lblErrorCatNueva.CssClass = "text-danger";
                lblErrorCatNueva.Visible = true;

            }
        }

       
    }
    
}