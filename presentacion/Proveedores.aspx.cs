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
            ProveedorNegocio negocio = new ProveedorNegocio();            
            Session.Add(("listaProveedores"), negocio.listar()); 
            dgvProveedores.DataSource = Session["listaProveedores"];
            dgvProveedores.DataBind();
            
        }
        protected void dgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.eliminarProveedor(id);
                cargarProveedores();
            }
            else if (e.CommandName == "Modificar")
            {
                Response.Redirect("AltaProveedor.aspx?id=" + id);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {        
            List<Proveedor> lista = (List<Proveedor>)Session["listaProveedores"];
            List<Proveedor> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvProveedores.DataSource = listaFiltrada;
            dgvProveedores.DataBind();
            btnLimpiar.Visible = true;           
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = Session["listaProveedores"];
            dgvProveedores.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }
    }
}