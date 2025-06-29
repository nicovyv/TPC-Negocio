using dominio;
using negocio;
using System;

namespace presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Security.isLogin(Session["usuario"]))

                    Response.Redirect("Productos.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            try
            {
                if (!txtPassword.Text.Contains(" ") && !(string.IsNullOrEmpty((txtPassword.Text))) && (!txtEmail.Text.Contains(" ") && !(string.IsNullOrEmpty((txtEmail.Text)))))
                {
                    usuario.Email = txtEmail.Text;
                    usuario.Password = txtPassword.Text;

                    if (usuarioNegocio.Login(usuario))
                    {
                        Session.Add("usuario", usuario);
                        Response.Redirect("Perfil.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "Email o Password incorrectos");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                



            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}