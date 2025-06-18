using dominio;
using negocio;
using System;

namespace presentacion
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Page is Login|| Page is Bienvenida || Page is Registro))
            {
                if (!Security.isLogin(Session["usuario"]))
                    Response.Redirect("Bienvenida.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    labelUsuario.Text = usuario.Email;
                    
                }
            }
        }

        protected void bntRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx", false);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}