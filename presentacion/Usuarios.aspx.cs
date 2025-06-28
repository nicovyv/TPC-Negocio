using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUsuarios();
            }
        }
        private void cargarUsuarios()
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Session.Add(("listaUsuarios"), negocio.Listar());
            dgvUsuarios.DataSource = Session["listaUsuarios"];
            dgvUsuarios.DataBind();
        }
    }
}