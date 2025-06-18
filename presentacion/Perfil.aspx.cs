using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Security.isLogin(Session["usuario"]))
                    {
                        Usuario usuario = (Usuario)Session["usuario"];
                        txtEmail.Text = usuario.Email;
                        txtEmail.ReadOnly = true;

                        txtNombre.Text = usuario.Nombre;
                        txtApellido.Text = usuario.Apellido;

                        if (!string.IsNullOrEmpty(usuario.ImagenUrl))
                        {
                            imagenNuevoPerfil.ImageUrl = "~/Imagenes/" + usuario.ImagenUrl;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
            }

        }

        

        protected void btnGuardar_Click1(object sender, EventArgs e)
        {
           
            try
            {   //Escribir IMG
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                Usuario usuario = (Usuario)Session["usuario"];
                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Imagenes/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.Id + ".jpg");
                    usuario.ImagenUrl = "perfil-" + usuario.Id + ".jpg";

                }

                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Email = txtEmail.Text;

                usuarioNegocio.ModificarUsuario(usuario);

                //Leer de la IMG
                Image img = (Image)Master.FindControl("imgNavbar");
                img.ImageUrl = "~/Imagenes/" + usuario.ImagenUrl;


            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());

            }
        }
    }
}