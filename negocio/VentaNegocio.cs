using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> Listar(string id = "")
        {
            List<Venta> lista = new List<Venta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                if (id != "")
                {
                    datos.setConsulta("SELECT V.ID,C.ID,C.Nombre,C.CuilCuit,V.Fecha,V.Total,V.Factura FROM Ventas V INNER JOIN Clientes C ON V.IDCliente=C.ID WHERE ID= " + id);
                }
                else
                {
                    datos.setConsulta(" SELECT V.ID, V.Fecha, V.Total, V.Factura, C.ID AS IDCliente, C.Nombre, C.CuilCuit, C.Direccion, C.Telefono, C.Email, C.Activo FROM Ventas V INNER JOIN Clientes C ON C.ID = V.IDCliente ORDER BY V.Fecha DESC");
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.Id = (int)datos.Lector["ID"];
                    venta.Fecha = (DateTime)datos.Lector["Fecha"];
                    venta.Total = (Decimal)datos.Lector["Total"];
                    venta.Factura = (int)datos.Lector["Factura"];

                    venta.Cliente = new Cliente()
                    {
                        Id = (int)datos.Lector["IDCliente"],
                        Nombre = (string)datos.Lector["NombreCliente"],
                        CuilCuit = (string)datos.Lector["CuilCuit"],
                        Direccion = (string)datos.Lector["Direccion"],
                        Telefono = (string)datos.Lector["Telefono"],
                        Email = (string)datos.Lector["Email"],
                        Activo = (bool)datos.Lector["Activo"]
                    };

                    venta.ItemVenta = ObtenerItemsDeVenta(venta.Id);

                    lista.Add(venta);


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

        // OBTENER LOS ITEMS ASOCIADOS A UNA VENTA DESDE LA BASE DE DATOS
        private List<ItemVenta> ObtenerItemsDeVenta(int idVenta)
        {
            List<ItemVenta> items = new List<ItemVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {   // consulta sql
                datos.setConsulta("SELECT IV.ID, IV.Cantidad, IV.PrecioUnidad, P.ID AS IDProducto, P.CodProd, P.Nombre, P.Descripcion, C.ID AS IDCategoria, C.Descripcion AS CatDesc, M.ID AS IDMarca, M.Descripcion AS MarcaDesc FROM ItemVenta IV INNER JOIN Productos P ON P.ID = IV.IDProducto INNER JOIN Categorias C ON P.IDCategoria = C.ID INNER JOIN Marcas M ON P.IDMarca = M.ID WHERE IV.IDVenta = @idVenta");
                datos.setParametro("@idVenta", idVenta);
                datos.ejecutarLectura();


                // mapeo de datos
                while (datos.Lector.Read())
                {
                    ItemVenta item = new ItemVenta();
                    item.Id = (int)datos.Lector["ID"];
                    item.Cantidad = (int)datos.Lector["Cantidad"];
                    item.PrecioUnidad = (decimal)datos.Lector["PrecioUnidad"];

                    item.Producto = new Producto();
                    item.Producto.Id = (int)datos.Lector["IDProducto"];
                    item.Producto.Codigo = (string)datos.Lector["CodProd"];
                    item.Producto.Nombre = (string)datos.Lector["Nombre"];
                    item.Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    item.Producto.Marca = new Marca();
                    item.Producto.Marca.Id = (int)datos.Lector["IDMarca"];
                    item.Producto.Marca.Descripcion = (string)datos.Lector["MarcaDesc"];

                    item.Producto.Categoria = new Categoria();
                    item.Producto.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    item.Producto.Categoria.Descripcion = (string)datos.Lector["CatDesc"];


                    items.Add(item);

                }

                // retorno de la lista de items de la venta
                return items;

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


        // metodo para generar un nuevo numero de factura único
        public int GenerarNumFactura()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // se selecciona la ultima factura de la base de datos
                datos.setConsulta("SELECT MAX(Factura) FROM VENTAS");
                datos.ejecutarLectura();
                // se valida que se lea un registro
                if (datos.Lector.Read() && !datos.Lector.IsDBNull(0))
                {   // se guarda el valor y devuelve +1
                    int ultimaFactura = (int)datos.Lector[0];
                    return ultimaFactura + 1;
                }
                else
                {   // si no hay facuras guardadas dvuelve 1000000 como primer numero de factura
                    return 1000000;
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




        public bool ValidarItemExistente(List<ItemVenta> itemsVenta, int idProducto)
        {

            foreach (var item in itemsVenta)
            {
                if (item.Producto.Id == idProducto)
                    return true;
            }

            return false;
        }

        public ItemVenta ObtenerItemExistente(List<ItemVenta> itemsVenta, int idProducto)
        {
            foreach (var item in itemsVenta)
            {
                if (item.Producto.Id == idProducto)
                    return item;
            }
            return null;
        }

        public void Agregar(Venta venta)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO Ventas (IDCliente, Fecha, Total, Factura) VALUES (@idCliente, @fecha, @total, @factura); ; SELECT SCOPE_IDENTITY();");
                datos.setParametro("@idCliente", venta.Cliente.Id);
                datos.setParametro("@fecha", venta.Fecha);
                datos.setParametro("@total", venta.Total);
                datos.setParametro("@factura", venta.Factura);
                // recuperamos id venta
                int idVenta = Convert.ToInt32(datos.ejecutarEscalar());

                // cargamos los item en la base de datos
                foreach (var item in venta.ItemVenta)
                {
                    datos.limpiarParametros();
                    datos.setearSP("SP_GUARDAR_ITEM_VENTA");
                    datos.setParametro("@IDVenta", idVenta);
                    datos.setParametro("@IDProducto", item.Producto.Id);
                    datos.setParametro("@Cantidad", item.Cantidad);
                    datos.setParametro("@PrecioUnidad", item.Producto.PrecioVenta);

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
