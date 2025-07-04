using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DetalleCompraNegocio
    {
        public List<DetalleCompra> Listar(int idCompra)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT DC.ID, DC.Cantidad, DC.PrecioUnidad, P.ID AS IDProducto, P.CodProd, P.Nombre, P.Descripcion, C.ID AS IDCategoria, C.Descripcion AS CatDesc, M.ID AS IDMarca, M.Descripcion AS MarcaDesc \r\nFROM DetalleCompra DC\r\nINNER JOIN Productos P ON P.ID = DC.IDProducto \r\nINNER JOIN Categorias C ON P.IDCategoria = C.ID \r\nINNER JOIN Marcas M ON P.IDMarca = M.ID \r\nWHERE DC.IDCompra = @IDCompra ");

                datos.setParametro("@IDCompra", idCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleCompra detalle = new DetalleCompra();
                    detalle.Id = (int)datos.Lector["ID"];
                    detalle.PrecioUnidad = (decimal)datos.Lector["PrecioUnidad"];
                    detalle.Cantidad = (int)datos.Lector["Cantidad"];

                    detalle.Producto = new Producto();
                    detalle.Producto.Id = (int)datos.Lector["IDProducto"];
                    detalle.Producto.Codigo = (string)datos.Lector["CodProd"];
                    detalle.Producto.Nombre = (string)datos.Lector["Nombre"];
                    detalle.Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    detalle.Producto.Marca = new Marca();
                    detalle.Producto.Marca.Id = (int)datos.Lector["IDMarca"];
                    detalle.Producto.Marca.Descripcion = (string)datos.Lector["MarcaDesc"];

                    detalle.Producto.Categoria = new Categoria();
                    detalle.Producto.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    detalle.Producto.Categoria.Descripcion = (string)datos.Lector["CatDesc"];
                    lista.Add(detalle);
                }

                return lista;
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
