﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace presentacion
{
    public partial class Marcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarMarcas();
                cargarBajas();
            }            
            
        }
        private void cargarMarcas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Session.Add(("listaMarcas"), negocio.listar());
            dgvMarcas.DataSource = Session["listaMarcas"];
            dgvMarcas.DataBind();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvMarcas.DataSource = Session["listaMarcas"];
            dgvMarcas.DataBind();
            txtFiltro.Text = "";
            btnLimpiar.Visible = false;
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcas"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvMarcas.DataSource = listaFiltrada;
            dgvMarcas.DataBind();
            btnLimpiar.Visible = true;
        }

        protected void dgvMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Eliminar")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarca(id);
                cargarMarcas();
                cargarBajas();
            }
            else if (e.CommandName == "Modificar")
            {
                Response.Redirect("AltaMarca.aspx?id=" + id);
            }
        }


        protected void dgvMarcas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvMarcas.PageIndex=e.NewPageIndex;
            cargarMarcas();
        }
        private void cargarBajas()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            Session.Add(("listaMarcasBaja"), negocio.listarBaja());
            dgvBajas.DataSource = Session["listaMarcasBaja"];
            dgvBajas.DataBind();
        }

        protected void txtFiltroBaja_TextChanged(object sender, EventArgs e)
        {
            List<Marca> lista = (List<Marca>)Session["listaMarcasBaja"];
            List<Marca> listaFiltrada = lista.FindAll(x => x.Descripcion.ToUpper().Contains(txtFiltroBaja.Text.ToUpper()));
            dgvBajas.DataSource = listaFiltrada;
            dgvBajas.DataBind();
            btnLimpiarBaja.Visible = true;
        }

        protected void btnLimpiarBaja_Click(object sender, EventArgs e)
        {
            dgvBajas.DataSource = Session["listaMarcasBaja"];
            dgvBajas.DataBind();
            txtFiltroBaja.Text = "";
            btnLimpiarBaja.Visible = false;
        }

        protected void dgvBajas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Reactivar")
            {
                MarcaNegocio negocio = new MarcaNegocio();
                negocio.reactivarMarca(id);
                cargarMarcas();
                cargarBajas();
            }
           
        }

        protected void dgvBajas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvBajas.PageIndex = e.NewPageIndex;
            cargarBajas();
        }
    }
}