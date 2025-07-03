using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CompraNegocio
    {
        public List<Compra> listar()
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                {
                    datos.setConsulta("SELECT C.ID as ID, C.Fecha as Fecha from Compras C");
                }


                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra compra = new Compra();
                    compra.Id = (int)datos.Lector["ID"];

                    compra.Fecha = (DateTime)datos.Lector["Fecha"];

                    DetalleCompraNegocio detalleNegocio = new DetalleCompraNegocio();
                    compra.Detalle = detalleNegocio.Listar(compra.Id);

                    lista.Add(compra);
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

        public bool ValidarItemExistente(List<DetalleCompra> detalleCompra, int idProducto)
        {

            foreach (var item in detalleCompra)
            {
                if (item.Producto.Id == idProducto)
                    return true;
            }

            return false;
        }

        public DetalleCompra ObtenerItemExistente(List<DetalleCompra> detalleCompra, int idProducto)
        {
            foreach (var item in detalleCompra)
            {
                if (item.Producto.Id == idProducto)
                    return item;
            }
            return null;
        }

        public void Agregar(Compra compra)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO Compras (idProveedor, Fecha, Total) VALUES (@idProveedor, @fecha, @total); ; SELECT SCOPE_IDENTITY();");
                datos.setParametro("@idProveedor", compra.Proveedor.Id);
                datos.setParametro("@fecha", compra.Fecha);
                datos.setParametro("@total", compra.Total);


                int idcompra = Convert.ToInt32(datos.ejecutarEscalar());


                foreach (var item in compra.Detalle)
                {
                    datos.limpiarParametros();
                    datos.setearSP("SP_GUARDAR_DETALLE_COMPRA");
                    datos.setParametro("@IDCompra", idcompra);
                    datos.setParametro("@IDProducto", item.Producto.Id);
                    datos.setParametro("@Cantidad", item.Cantidad);
                    datos.setParametro("@PrecioUnidad", item.PrecioUnidad);

                    datos.ejecutarAccion();
                }

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
