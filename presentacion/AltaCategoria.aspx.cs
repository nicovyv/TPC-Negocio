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
    public partial class AltaCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    try
                    {
                        lblTitulo.Text = "Formulario Modificación de Categoria";
                        btnAgregar.Text = "Modificar";
                        CategoriaNegocio negocio = new CategoriaNegocio();
                        Categoria seleccionado = (negocio.listar(id))[0];

                        Session.Add("CategoriaSeleccionada", seleccionado);

                        txtDescripcion.Text = seleccionado.Descripcion;
                    }
                    catch (Exception)
                    {
                        lblValidarDescripción.Visible = true;
                        lblValidarDescripción.Text = "Categoria no disponible";
                        txtDescripcion.Enabled = false;
                        btnAgregar.Visible = false;
                    }
                    

                }
            }
        }

        public bool ValidarCamposVacios(object control)
        {
            if (control is TextBox texto)
            {
                if (string.IsNullOrEmpty(texto.Text))
                    return true;
                else
                    return false;

            }
            return false;
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposVacios(txtDescripcion))
                {
                    lblValidarDescripción.Text = "!Atención! Se debe completar el campo de Descripción, por favor";
                    lblValidarDescripción.Visible = true;
                    return;
                }

                Categoria nuevo = new Categoria();
                CategoriaNegocio negocio = new CategoriaNegocio();

                nuevo.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificar(nuevo);
                    Session.Remove("CategoriaSeleccionada");
                }
                else
                {
                    negocio.agregar(nuevo);
                }

                Response.Redirect("Categorias.aspx");
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {

                lblValidarDescripción.Visible = true;
                lblValidarDescripción.Text = "Categoria ingresada ya está registrada";
            }
        }
    }
}