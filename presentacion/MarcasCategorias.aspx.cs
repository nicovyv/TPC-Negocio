using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using dominio;
using negocio;

namespace presentacion
{
    
    public partial class MarcasyCategorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMarcas();
            cargarCategorias();
        }


        private void cargarMarcas()
        {
            List<Marca> listaMarcas = new List<Marca>
            {
                new Marca { Descripcion = "HP" },
                new Marca { Descripcion = "ASUS" },
                new Marca { Descripcion = "DELL" },
                new Marca { Descripcion = "LENOVO" },
                new Marca { Descripcion = "MSI" }
             };
            dgvMarcas.DataSource = listaMarcas;
            dgvMarcas.DataBind();
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
    }
}