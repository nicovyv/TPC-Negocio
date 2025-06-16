using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> listaProductos = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("sp_ListarProd");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["IdProducto"];
                    producto.Codigo = (string)datos.Lector["Codigo"];
                    producto.Nombre = (string)datos.Lector["NombreProducto"];
                    producto.Descripcion = (string)datos.Lector["DescripcionProducto"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    producto.Categoria.Descripcion = (string)datos.Lector["DescripcionCategoria"];

                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IdMarca"];
                    producto.Marca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    producto.StockActual = (int)datos.Lector["StockActual"];
                    producto.StockMinimo = (int)datos.Lector["StockMinimo"];
                    producto.Ganancia = float.Parse(datos.Lector["Ganancia"].ToString());
                    producto.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    producto.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];

                    listaProductos.Add(producto);
                }

                return listaProductos;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
