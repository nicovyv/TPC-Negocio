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
    public partial class PassReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {

            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            EmailService emailService = new EmailService();
            int codigo = 202020;
            try
            {
                usuario.Email = txtEmail.Text;

                usuario = usuarioNegocio.buscarMail(usuario.Email);


                /*if (!(string.IsNullOrEmpty((usuario.Email))))*/
                {
                    if (usuario.Id != 0)
                    {
                        Session.Add("usuario", usuario);
                        emailService.armarCorreo(usuario.Email, "Reestablecimiento de Clave", "Hola " + usuario.Email + ", su codigo para reestablecer la clave es " + codigo + ".");
                        emailService.enviarMail();
                        txtCodigo.Text = "correo encontrado";
                    }
                    else
                    {
                        Session.Add("error", "Hubo un error al reestablecer la clave, intente más tarde.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
               /* else
                {
                    Session.Add("error", "El campo Email Usuario es requerido.");
                    Response.Redirect("Error.aspx", false);
                }*/

            }
            catch (Exception ex)
            {

                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
        }
    }
}