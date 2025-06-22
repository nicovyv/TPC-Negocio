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
                if(!(string.IsNullOrEmpty(usuario.Email)) & !(string.IsNullOrEmpty(usuario.Password)))
                {
                    usuario.Id = usuarioNegocio.AgregarUsuario(usuario);
                    if (usuario.Id != 0)
                    {
                        Session.Add("usuario", usuario);
                        emailService.armarCorreo(usuario.Email, "Bienvenid@", "Hola bienvenido, gracias por elegirnos.");
                        emailService.enviarMail();
                        Response.Redirect("Perfil.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "Hubo un error al crear el usuario, intente más tarde.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    Session.Add("error", "El campo Email Usuario y Password son requeridos.");
                    Response.Redirect("Error.aspx", false);
                }
                
                
               
               

               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
          
        }
    }
}