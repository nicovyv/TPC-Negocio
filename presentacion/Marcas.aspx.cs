using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarMarcas();
            
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
    }
}