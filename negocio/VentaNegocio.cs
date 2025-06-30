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
                    datos.setConsulta("SELECT V.ID,C.ID,C.Nombre AS NombreCliente,C.CuilCuit,V.Fecha,V.Total,V.Factura FROM Ventas V INNER JOIN Clientes C ON V.IDCliente=C.ID");
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();
                    venta.Id = (int)datos.Lector["ID"];
                    venta.Fecha = (DateTime)datos.Lector["Fecha"];
                    venta.Total = (Decimal)datos.Lector["Total"];
                    venta.Factura = (string)datos.Lector["Factura"];
                   
                    venta.Cliente=new Cliente() { 
                    Nombre = (string)datos.Lector["NombreCliente"]
                    };    

                    lista.Add(venta);
                }
                return lista;
            }
            catch (Exception ex )
            {

                throw ex;
            }
            
          
        }


        public bool ValidarItemExistente(List<ItemVenta> itemsVenta ,int idProducto)
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
            
            AccesoDatos datos =new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO Ventas (IDCliente, Fecha, Total, Factura) VALUES (IDCliente=@idCliente, Fecha=@fecha, Total=@total, Factura=@factura);");
                datos.setParametro("@idCliente",venta.Cliente.Id);
                datos.setParametro("@fecha", venta.Fecha);
                datos.setParametro("@total", venta.Total);
                datos.setParametro("@factura", venta.Factura);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }

    }
}
