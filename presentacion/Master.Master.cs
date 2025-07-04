using dominio;
using negocio;
using System;

namespace presentacion
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgNavbar.ImageUrl = "https://assets.stickpng.com/images/585e4beacb11b227491c3399.png";

            if (!(Page is Login|| Page is Bienvenida || Page is Registro||Page is Error || Page is PassReset))
            {
                if (!Security.isLogin(Session["usuario"]))
                    Response.Redirect("Bienvenida.aspx", false);
                else
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    labelUsuario.Text = usuario.Email;
                    if (!string.IsNullOrEmpty(usuario.ImagenUrl))
                    {
                        imgNavbar.ImageUrl = "~/Imagenes/" + ((Usuario)Session["usuario"]).ImagenUrl;
                    }
                    if(!(Page is Ventas || Page is IngresarProductosVenta || Page is VentasListado || Page is VentaRegistrada || Page is Perfil || Page is Clientes || Page is Productos || Page is FormProductos))
                    {
                        if (!Security.isAdmin(Session["usuario"]))
                            Response.Redirect("Ventas.aspx", false);
                    }
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