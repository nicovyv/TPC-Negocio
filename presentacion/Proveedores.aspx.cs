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
                cargarBajas();
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
                cargarBajas();
            }
            else if (e.CommandName == "Modificar")
            {
                Response.Redirect("AltaProveedor.aspx?id=" + id);
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {

            List<Proveedor> lista = (List<Proveedor>)Session["listaProveedores"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Proveedor> listaFiltrada = lista.FindAll(x =>
                (!string.IsNullOrEmpty(x.Nombre) && x.Nombre.ToUpper().Contains(filtro)) ||
                (!string.IsNullOrEmpty(x.CuilCuit) && x.CuilCuit.ToUpper().Contains(filtro))
            );

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvProveedores.DataSource = listaFiltrada;
                dgvProveedores.DataBind();
                btnLimpiar.Visible = true;
            }
            else
            {
                dgvProveedores.DataSource = listaFiltrada;
                dgvProveedores.DataBind();
                btnLimpiar.Visible = true;
            }


        
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvProveedores.DataSource = Session["listaProveedores"];
            dgvProveedores.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        private void cargarBajas()
        {
            ProveedorNegocio negocio = new ProveedorNegocio();
            Session.Add(("listaProveedoresBaja"), negocio.listarBajas());
            dgvBajas.DataSource = Session["listaProveedoresBaja"];
            dgvBajas.DataBind();

        }

        protected void dgvBajas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Reactivar")
            {
                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.reactivarProveedor(id);
                cargarProveedores();
                cargarBajas();
            }
        }

        protected void btnBaja_Click(object sender, EventArgs e)
        {
            dgvBajas.DataSource = Session["listaProveedoresBaja"];
            dgvBajas.DataBind();
            txtBaja.Text = "";
            btnBaja.Visible = false;
        }

        protected void txtBaja_TextChanged(object sender, EventArgs e)
        {

            List<Proveedor> lista = (List<Proveedor>)Session["listaProveedoresBaja"];
            string filtro = txtBaja.Text.ToUpper();

            List<Proveedor> listaFiltrada = lista.FindAll(x =>
                (!string.IsNullOrEmpty(x.Nombre) && x.Nombre.ToUpper().Contains(filtro)) ||
                (!string.IsNullOrEmpty(x.CuilCuit) && x.CuilCuit.ToUpper().Contains(filtro))
            );

            if (Security.isAdmin(Session["usuario"]))
            {
                dgvBajas.DataSource = listaFiltrada;
                dgvBajas.DataBind();
                btnBaja.Visible = true;
            }

        }
    }
}