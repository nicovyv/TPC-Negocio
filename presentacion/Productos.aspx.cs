using dominio;
using System;
using System.Collections.Generic;
using negocio;

namespace presentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (Session["usuario"] == null)
            //{
            //    Usuario usuario = new Usuario();
            //    usuario.Id = 1;
            //    usuario.Nombre = "Usuario Test";
            //    usuario.Admin = true; // o false, según quieras probar permisos

            //    Session.Add("usuario", usuario);
            //}

            cargarProductos();
        }

        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            dgvProducto.DataSource = negocio.listar();
            dgvProducto.DataBind();
        }
    }
}