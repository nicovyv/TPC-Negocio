using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace presentacion
{
    public partial class AltaCliente : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string id = Request.QueryString["id"];
                if (!string.IsNullOrEmpty(id))
                {
                    lblTitulo.Text = "Formulario Modificación de Cliente";
                    btnAgregarCliente.Text = "Modificar";
                    ClienteNegocio negocio = new ClienteNegocio();
                    Cliente seleccionado = (negocio.listar(id))[0];

                    Session.Add("clienteSeleccionado", seleccionado);

                    txtNombreCliente.Text = seleccionado.Nombre;
                    txtCuilCliente.Text = seleccionado.CuilCuit;
                    txtDireccion.Text = seleccionado.Direccion;
                    txtEmailCliente.Text = seleccionado.Email;
                    txtTelefono.Text = seleccionado.Telefono.ToString();
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

        protected void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposVacios(txtTelefono) || ValidarCamposVacios(txtDireccion) ||
                    ValidarCamposVacios(txtCuilCliente) || ValidarCamposVacios(txtEmailCliente) || ValidarCamposVacios(txtNombreCliente))
                {
                    lblValidarCuit.Visible = true;
                    lblValidarCuit.Text = "!Atención! Se deben completar todos los datos, por favor";
                    return;
                }

                if (!ValidarCuit(txtCuilCliente.Text))
                {
                    lblValidarCuit.Visible = true;
                    lblValidarCuit.Text = "CUIT/CUIL inválido. Debe contener 11 dígitos";
                    return;
                }


              
                Cliente nuevo = new Cliente();
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                nuevo.Nombre = txtNombreCliente.Text;
                nuevo.CuilCuit = txtCuilCliente.Text;
                nuevo.Direccion = txtDireccion.Text;
                nuevo.Telefono = int.Parse(txtTelefono.Text);
                nuevo.Email = txtEmailCliente.Text;

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id = int.Parse(Request.QueryString["id"]);
                    clienteNegocio.modificarCliente(nuevo);
                    Session.Remove("clienteSeleccionado");
                }

                else
                {
                    clienteNegocio.agregarCliente(nuevo);
                }

                Response.Redirect("Clientes.aspx");
                Context.ApplicationInstance.CompleteRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
            
        }
    }
}