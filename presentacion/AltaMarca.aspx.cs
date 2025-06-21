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
    public partial class AltaMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Formulario Modificación de Marca";
                    btnAgregar.Text = "Modificar";
                    MarcaNegocio negocio = new MarcaNegocio();
                    Marca seleccionado = (negocio.listar(id))[0];

                    Session.Add("MarcaSeleccionada", seleccionado);

                    txtDescripcion.Text = seleccionado.Descripcion;

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

                Marca nuevo = new Marca();
                MarcaNegocio negocio = new MarcaNegocio();

                nuevo.Descripcion = txtDescripcion.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    negocio.modificarMarca(nuevo);
                    Session.Remove("MacaSeleccionada");
                }
                else
                {
                    negocio.agregarMarca(nuevo);
                }

                Response.Redirect("Marcas.aspx");
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                
                lblValidarDescripción.Visible = true;
                lblValidarDescripción.Text = "Marca ingresada ya está registrada";
            }
        }
    }
}