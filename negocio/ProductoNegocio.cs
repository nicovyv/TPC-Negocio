﻿using System;
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
        public List<Producto> FiltrarCategoria(int idCategoria)
        {
            List<Producto> listaProductos = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT P.ID,P.CodProd AS codigo, P.Nombre AS nombre,P.Descripcion AS descripcion,P.Precio AS precio,P.StockActual As stock,\r\nC.ID AS IDCATEGORIA,C.Descripcion AS categoria,\r\nM.ID AS IDMARCA,M.Descripcion AS marca\r\nFROM Productos P\r\nINNER JOIN Categorias C\r\nON P.IDCategoria=C.ID\r\nINNER JOIN Marcas M\r\nON P.IDMarca=M.ID\r\nWHERE C.ID=@categoria AND P.Activo=1";
                datos.setConsulta(consulta);
                datos.setParametro("@categoria", idCategoria);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Codigo = (string)datos.Lector["codigo"];
                    producto.Nombre = (string)datos.Lector["nombre"];
                    producto.Descripcion = (string)datos.Lector["descripcion"];
                    producto.PrecioVenta = (decimal)datos.Lector["precio"];
                    producto.StockActual = (int)datos.Lector["stock"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IDCATEGORIA"];
                    producto.Categoria.Descripcion = (string)datos.Lector["categoria"];

                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IDMARCA"];
                    producto.Marca.Descripcion = (string)datos.Lector["marca"];
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }


        public List<Producto> FiltrarMarca(int idMarca)
        {
            List<Producto> listaProductos = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT P.ID,P.CodProd AS codigo, P.Nombre AS nombre,P.Descripcion AS descripcion,P.Precio AS precio,P.StockActual As stock,\r\nC.ID AS IDCATEGORIA,C.Descripcion AS categoria,\r\nM.ID AS IDMARCA,M.Descripcion AS marca\r\nFROM Productos P\r\nINNER JOIN Categorias C\r\nON P.IDCategoria=C.ID\r\nINNER JOIN Marcas M\r\nON P.IDMarca=M.ID\r\nWHERE C.ID=@marca AND P.Activo=1";
                datos.setConsulta(consulta);
                datos.setParametro("@marca", idMarca);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["Id"];
                    producto.Codigo = (string)datos.Lector["codigo"];
                    producto.Nombre = (string)datos.Lector["nombre"];
                    producto.Descripcion = (string)datos.Lector["descripcion"];
                    producto.PrecioVenta = (decimal)datos.Lector["precio"];
                    producto.StockActual = (int)datos.Lector["stock"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IDCATEGORIA"];
                    producto.Categoria.Descripcion = (string)datos.Lector["categoria"];

                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IDMARCA"];
                    producto.Marca.Descripcion = (string)datos.Lector["marca"];
                    listaProductos.Add(producto);
                }
                return listaProductos;
            }

            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool ValidaCodigoProducto(string codProd, int idProd = 0)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT COUNT(*) FROM Productos WHERE CodProd = @cod AND ID != @idProd");
                datos.setParametro("@cod", codProd);
                datos.setParametro("@idProd", idProd);
                datos.ejecutarLectura();



                if (datos.Lector.Read())
                {
                    int aux = datos.Lector.GetInt32(0);
                    return aux == 0;
                }
                else
                    return true;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }



        public void Agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setConsulta("INSERT INTO Productos (CodProd, Nombre, Descripcion, IDCategoria, IDMarca, Precio, StockMinimo, StockActual, Ganancia, PrecioCompra)VALUES(@cod, @nombre, @desc, @idCat, @idMarca, 0, @stockMinimo, 0, @ganancia, 0)");
                datos.setParametro("@cod", nuevo.Codigo);
                datos.setParametro("@nombre", nuevo.Nombre);
                datos.setParametro("@desc", nuevo.Descripcion);
                datos.setParametro("@idMarca", nuevo.Marca.Id);
                datos.setParametro("@stockMinimo", nuevo.StockMinimo);
                datos.setParametro("@ganancia", nuevo.Ganancia);
                datos.setParametro("@idCat", nuevo.Categoria.Id);

                datos.ejecutarAccion();


                datos.limpiarParametros();


                datos.setConsulta("SELECT ID FROM Productos WHERE CodProd = @cod");
                datos.setParametro("@cod", nuevo.Codigo);
                int idProducto = Convert.ToInt32(datos.ejecutarEscalar());

                foreach (var proveedor in nuevo.Proveedores)
                {
                    AccesoDatos datosProv = new AccesoDatos();
                    datosProv.setConsulta("INSERT INTO ProductosXProveedor (IDProducto, IDProveedor) VALUES(@IDProducto, @IDProveedor)");
                    datosProv.setParametro("@IDProducto", idProducto);
                    datosProv.setParametro("@IDProveedor", proveedor.Id);
                    datosProv.ejecutarAccion();
                    datosProv.cerrarConexion();
                }



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }



        public void Modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setConsulta("UPDATE Productos SET Nombre = @nombre, Descripcion = @desc, IDCategoria = @idCat, IDMarca = @idMarca, StockMinimo = @stockMinimo, Ganancia = @ganancia WHERE ID = @id");
                datos.setParametro("@id", producto.Id);
                datos.setParametro("@nombre", producto.Nombre);
                datos.setParametro("@desc", producto.Descripcion);
                datos.setParametro("@idCat", producto.Categoria.Id);
                datos.setParametro("@idMarca", producto.Marca.Id);
                datos.setParametro("@stockMinimo", producto.StockMinimo);
                datos.setParametro("@ganancia", producto.Ganancia);

                datos.ejecutarAccion();

                datos.limpiarParametros();

                datos.setConsulta("DELETE FROM ProductosXProveedor WHERE IDProducto = @idProd");
                datos.setParametro("@idProd", producto.Id);
                datos.ejecutarAccion();

                foreach (var proveedor in producto.Proveedores)
                {
                    AccesoDatos datosProv = new AccesoDatos();
                    datosProv.setConsulta("INSERT INTO ProductosXProveedor (IDProducto, IDProveedor) VALUES(@IDProducto, @IDProveedor)");
                    datosProv.setParametro("@IDProducto", producto.Id);
                    datosProv.setParametro("@IDProveedor", proveedor.Id);
                    datosProv.ejecutarAccion();
                    datosProv.cerrarConexion();
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

        public Producto ObtenerPorId(int id)
        {

            Producto producto = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("SELECT P.ID, P.CodProd, P.Nombre, P.Descripcion, P.IDCategoria, C.Descripcion AS Categoria, P.IDMarca, M.Descripcion AS Marca, P.Precio, P.StockMinimo, P.StockActual, P.Ganancia, P.PrecioCompra FROM Productos P INNER JOIN Categorias C ON P.IDCategoria = C.ID INNER JOIN Marcas M ON M.ID = P.IDMarca WHERE P.ID = @id");
                datos.setParametro("id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {

                    producto = new Producto();

                    producto.Id = (int)datos.Lector["ID"];
                    producto.Codigo = (string)datos.Lector["CodProd"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IDCategoria"];
                    producto.Categoria.Descripcion = (string)datos.Lector["Categoria"];

                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IdMarca"];
                    producto.Marca.Descripcion = (string)datos.Lector["Marca"];

                    producto.StockActual = (int)datos.Lector["StockActual"];
                    producto.StockMinimo = (int)datos.Lector["StockMinimo"];
                    producto.Ganancia = float.Parse(datos.Lector["Ganancia"].ToString());
                    producto.PrecioVenta = (decimal)datos.Lector["Precio"];
                    producto.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];


                    datos.cerrarConexion();


                    datos.limpiarParametros();


                    datos.setConsulta("SELECT P.ID, P.Nombre FROM Proveedores P INNER JOIN ProductosXProveedor PXP ON P.ID = PXP.IDProveedor WHERE PXP.IDProducto = @id");
                    datos.setParametro("@id", producto.Id);
                    datos.ejecutarLectura();

                    producto.Proveedores = new List<Proveedor>();


                    while (datos.Lector.Read())
                    {
                        Proveedor proveedor = new Proveedor();
                        proveedor.Id = (int)datos.Lector["ID"];
                        proveedor.Nombre = (string)datos.Lector["Nombre"];
                        producto.Proveedores.Add(proveedor);
                    }




                }



            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();


            }



            return producto;


        }



        // ELIMINACION LOGICA
        public void eliminar(int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setConsulta("UPDATE Productos SET Activo = 0 WHERE ID = @id");
                datos.setParametro("@id", id);


                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }


        public List<Producto> listarProdBaja()
        {
            List<Producto> listaInactivos = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT ID, CodProd, Nombre, Descripcion, IdCategoria, IdMarca, Precio, StockActual, StockMinimo, Ganancia, PrecioCompra, Activo FROM Productos WHERE Activo = 0");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["ID"];
                    producto.Codigo = (string)datos.Lector["CodProd"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IdCategoria"];


                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IdMarca"];


                    producto.StockActual = (int)datos.Lector["StockActual"];
                    producto.StockMinimo = (int)datos.Lector["StockMinimo"];
                    producto.Ganancia = float.Parse(datos.Lector["Ganancia"].ToString());
                    producto.PrecioVenta = (decimal)datos.Lector["Precio"];
                    producto.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];

                    listaInactivos.Add(producto);
                }

                return listaInactivos;

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



        // ALTA LOGICA
        public void Activar(int id)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setConsulta("UPDATE Productos SET Activo = 1 WHERE ID = @id");
                datos.setParametro("@id", id);


                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public List<Producto> FiltrarPorCategoriaYProveedor(int idCategoria, int idProveedor)
        {
            List<Producto> productosFiltrados = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();
            ProveedorNegocio proveedorNegocio = new ProveedorNegocio();

            try
            {
                datos.setConsulta("SELECT P.ID, P.CODPROD, P.NOMBRE, P.DESCRIPCION, P.IDCATEGORIA, P.IDMARCA, P.PRECIO, P.STOCKACTUAL, P.STOCKMINIMO, P.GANANCIA, P.PRECIOCOMPRA FROM PRODUCTOS P WHERE P.ACTIVO = 1 AND P.IDCATEGORIA = @idCategoria");
                datos.setParametro("@idCategoria", idCategoria);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto prod = new Producto();
                    prod.Id = (int)datos.Lector["ID"];
                    prod.Codigo = datos.Lector["CODPROD"].ToString();
                    prod.Nombre = datos.Lector["NOMBRE"].ToString();
                    prod.Descripcion = datos.Lector["DESCRIPCION"].ToString();
                    prod.PrecioVenta = (decimal)datos.Lector["PRECIO"];
                    prod.StockActual = (int)datos.Lector["STOCKACTUAL"];
                    prod.StockMinimo = (int)datos.Lector["STOCKMINIMO"];
                    prod.Ganancia = float.Parse(datos.Lector["GANANCIA"].ToString());
                    prod.PrecioCompra = (decimal)datos.Lector["PRECIOCOMPRA"];

                    // Agregamos los proveedores asociados a ese producto
                    prod.Proveedores = proveedorNegocio.listarProveedoresPorProducto(prod.Id);

                    // Solo agregamos el producto si está asociado al proveedor que queremos
                    if (prod.Proveedores.Any(p => p.Id == idProveedor))
                    {
                        productosFiltrados.Add(prod);
                    }
                }

                return productosFiltrados;
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

        public List<Producto> FiltrarMarcaCategoria(int idMarca, int idCategoria)
        {
            List<Producto> listaFiltrada = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();



            try
            {
                datos.setConsulta("SELECT P.ID, P.CodProd, P.Nombre, P.Descripcion, P.IdCategoria, P.IdMarca, P.StockActual, P.StockMinimo, P.Ganancia, P.PrecioCompra, P.Precio AS PrecioVenta, P.Activo, C.Descripcion AS CategoriaDescripcion, M.Descripcion AS MarcaDescripcion  FROM Productos P INNER JOIN Categorias C ON P.IdCategoria = C.Id INNER JOIN Marcas M ON P.IdMarca = M.Id WHERE P.Activo = 1 AND C.ID = @idCategoria AND M.ID = @idMarca");
                datos.setParametro("@idCategoria", idCategoria);
                datos.setParametro("@idMarca", idMarca);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = (int)datos.Lector["ID"];
                    producto.Codigo = (string)datos.Lector["CodProd"];
                    producto.Nombre = (string)datos.Lector["Nombre"];
                    producto.Descripcion = (string)datos.Lector["Descripcion"];
                    producto.StockActual = (int)datos.Lector["StockActual"];
                    producto.StockMinimo = (int)datos.Lector["StockMinimo"];
                    producto.Ganancia = float.Parse(datos.Lector["Ganancia"].ToString());
                    producto.PrecioCompra = (decimal)datos.Lector["PrecioCompra"];
                    producto.PrecioVenta = (decimal)datos.Lector["PrecioVenta"];
                    producto.Activo = (bool)datos.Lector["Activo"];

                    producto.Marca = new Marca();
                    producto.Marca.Id = (int)datos.Lector["IdMarca"];
                    producto.Marca.Descripcion = (string)datos.Lector["MarcaDescripcion"];

                    producto.Categoria = new Categoria();
                    producto.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    producto.Categoria.Descripcion = (string)datos.Lector["CategoriaDescripcion"];

                    listaFiltrada.Add(producto);
                }

                return listaFiltrada;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
