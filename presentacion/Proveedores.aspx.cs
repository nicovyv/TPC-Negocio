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
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarProveedores();
            }
        }
        private void cargarProveedores()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            ProveedorNegocio negocio = new ProveedorNegocio();
            listaProveedores = negocio.listar();
            dgvProveedores.DataSource = listaProveedores;
            dgvProveedores.DataBind();
        }
        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}