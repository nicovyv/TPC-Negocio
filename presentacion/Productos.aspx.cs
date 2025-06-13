using dominio;
using System;
using System.Collections.Generic;

namespace presentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        private void cargarProductos()
        {
            List<Producto> listaProducto = new List<Producto>
            {
                //new Producto { Descripcion = "HP",
                //               Nombre="Notebook",
                //               StockActual=10,
                //               Codigo="1"},
                //new Producto { Descripcion = "ASUS",
                //               Nombre="Computadora",
                //               StockActual=10,
                //               Codigo="2" },
                //new Producto {Descripcion = "DELL",
                //                Nombre = "Monitor",
                //                StockActual = 10,
                //                Codigo = "3"},
                //new Producto {Descripcion = "LENOVO",
                //                Nombre = "Computadora",
                //                StockActual = 10,
                //                Codigo = "4"},
                //new Producto {Descripcion = "MSI",
                //                Nombre = "Placa de Video",
                //                StockActual = 10,
                //                Codigo = "5"}
             };
            dgvProducto.DataSource = listaProducto;
            dgvProducto.DataBind();
        }
    }
}