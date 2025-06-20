﻿using dominio;
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

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();

            try
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
                    Session.Add("error", "Algún dato ingresado es incorrecto");
                    Response.Redirect("Error.aspx");
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