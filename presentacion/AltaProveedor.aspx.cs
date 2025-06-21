using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace presentacion
{
    public partial class AltaProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Formulario Modificación de Proveedor";
                    btnAgregarProveedor.Text = "Modificar";
                    ProveedorNegocio negocio = new ProveedorNegocio();
                    Proveedor seleccionado = (negocio.listar(id))[0];

                    Session.Add("proveedoreSeleccionado", seleccionado);

                    txtNombreProveedor.Text = seleccionado.Nombre;
                    txtCuilProveedor.Text = seleccionado.CuilCuit;
                    txtDireccion.Text = seleccionado.Direccion;
                    txtEmailProveedor.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono.ToString();
                }
            }
            if (IsPostBack)
            {
                lblValidarCuit.Visible = false;
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

        public static bool validarNumero(object control)
        {
            if (control is TextBox texto)
            {
                if (texto.Text.Length == 11 && texto.Text.All(char.IsDigit))
                    return true;
                else
                    return false;
            }

            return false;
        }
        public bool ValidarCuit(string cuit)
        {
            if (!string.IsNullOrWhiteSpace(cuit))
            {
                string sinGuion = cuit.Replace("-", "");
                if (sinGuion.All(char.IsDigit))
                {
                    if (sinGuion.Length == 11) return true;
                }
            }
            return false;
        }

        protected void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposVacios(txtTelefono) || ValidarCamposVacios(txtDireccion) ||
                    ValidarCamposVacios(txtCuilProveedor) || ValidarCamposVacios(txtEmailProveedor) || ValidarCamposVacios(txtNombreProveedor))
                {
                    lblValidarCuit.Visible = true;
                    lblValidarCuit.Text = "!Atención! Se deben completar todos los datos, por favor";
                    return;
                }

                if (!ValidarCuit(txtCuilProveedor.Text))
                {
                    lblValidarCuit.Visible = true;
                    lblValidarCuit.Text = "CUIT/CUIL inválido. Debe contener 11 dígitos";
                    return;
                }

                Proveedor nuevo = new Proveedor();
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

                nuevo.Nombre = txtNombreProveedor.Text;
                nuevo.CuilCuit = txtCuilProveedor.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Telefono = txtTelefono.Text;
                nuevo.Email = txtEmailProveedor.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    proveedorNegocio.modificarProveedor(nuevo);
                    Session.Remove("proveedorSeleccionado");
                }

                else
                {
                    proveedorNegocio.agregarProveedor(nuevo);
                }

                Response.Redirect("Proveedores.aspx");
                Context.ApplicationInstance.CompleteRequest();

            }
            catch (Exception ex)
            {
                lblValidarCuit.Visible = true;
                lblValidarCuit.Text = "El CUIL/CUIT ingresado ya está registrado";
            }
           
            
        }
    }
}