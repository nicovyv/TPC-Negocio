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
    public partial class Registro : System.Web.UI.Page
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

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
           
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            EmailService emailService= new EmailService();  
            try
            {
                
                usuario.Email = txtEmail.Text;
                usuario.Password = txtPassword.Text;
                usuario.Id=usuarioNegocio.AgregarUsuario(usuario);
                Session.Add("usuario", usuario);
                emailService.armarCorreo(usuario.Email, "Bienvenid@", "Hola bienvenido, gracias por elegirnos.");
                emailService.enviarMail();
                Response.Redirect("Perfil.aspx",false);
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
          
        }
    }
}