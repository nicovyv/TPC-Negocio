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
            string codigo = "202020";
            Session.Add(("codigo"), codigo);
            try
            {
                


                if (!(string.IsNullOrEmpty((txtEmail.Text))) || !(string.IsNullOrWhiteSpace((txtEmail.Text))))
                {
                    usuario.Email = txtEmail.Text;

                    usuario = usuarioNegocio.buscarMail(usuario.Email);

                    if (usuario.Id != 0)
                    {
                        Session.Add("Reestablecimiento", usuario);
                        emailService.armarCorreo(usuario.Email, "Reestablecimiento de Clave", "Hola " + usuario.Email + ", su codigo para reestablecer su PassWord es " + codigo + ".");
                        emailService.enviarMail();
                        
                        txtCodigo.Visible = true;
                        lblCodigo.Visible = true;
                        btnComprobar.Visible = true;

                        txtEmail.Enabled = false;
                        btnGenerar.Visible = false;
                    }
                    else 
                    {
                        Session.Add("error", "Hubo un error al reestablecer la clave, intente más tarde.");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                else
                {
                    lblExito.Visible = true;
                    lblExito.Text = "Debe completar el campo de Email, por favor";
                    lblExito.CssClass = "alert alert-danger";                    
                }

            }
            catch (Exception ex)
            {
                
                Session.Add("error", Security.ManejoError(ex));
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnComprobar_Click(object sender, EventArgs e)
        {
            if (Session["codigo"].ToString() == txtCodigo.Text)
            {
                txtCodigo.Visible = false;
                lblCodigo.Visible = false;
                btnComprobar.Visible = false;
                btnCambiar.Visible = true;
                lblCambiar.Visible = true;
                txtPassword.Visible = true;
            }
        }

        protected void btnCambiar_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text != null || txtPassword.Text != "" || !(string.IsNullOrEmpty((txtPassword.Text))))
            {
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["Reestablecimiento"];
                usuario.Password = txtPassword.Text;
                usuarioNegocio.ResetPass(usuario);
                btnCambiar.Visible = false;
                txtPassword.Enabled = false;
                lblExito.Visible = true;
                btnCancelar.Visible = false;
                btnPerfil.Visible = true;
                Session.Add("Usuario", usuario);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Bienvenida.aspx", false);
        }

        protected void btnPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }
    }
}