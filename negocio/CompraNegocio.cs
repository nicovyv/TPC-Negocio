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
        public List<Compra> listar(string id = "")
        {
            List<Compra> lista = new List<Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if(id != "")
                {
                    datos.setConsulta("SELECT C.ID, C.Fecha,C.Total,P.ID AS IDProveedor, P.Nombre AS NombreProveedor,U.ID AS IDUsuario, U.Email AS Email Usuario INNER JOIN PROVEEDORES P ON C.IDProveedor = P.ID INNER JOIN USUARIOS U ON C.IDUsuario = U.ID WHERE ID= "+id);
                }
                else
                {
                    datos.setConsulta("SELECT C.ID, C.Fecha,C.Total,P.ID AS IDProveedor, P.Nombre AS NombreProveedor,U.ID AS IDUsuario, U.Email AS Email Usuario INNER JOIN PROVEEDORES P ON C.IDProveedor = P.ID INNER JOIN USUARIOS U ON C.IDUsuario = U.ID");
                }
                    

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Compra compra = new Compra();
                    compra.Id = (int)datos.Lector["ID"];
                   
                    compra.Fecha = (DateTime)datos.Lector["Fecha"];
                    compra.Total = (decimal)datos.Lector["Total"];

                    compra.Proveedor = new Proveedor
                    {
                        Nombre = (string)datos.Lector["NombreProveedor"]

                    };

                    compra.Usuario = new Usuario
                    {
                        Id = (int)datos.Lector["IDUsuario"],
                        Email = (string)datos.Lector["Email"],
                    };

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

    }
}
