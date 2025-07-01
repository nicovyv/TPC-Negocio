using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProveedorNegocio
    {

        public Proveedor buscarProveedorPorCuitCuil(string cuitCuil)
        {
            AccesoDatos datos = new AccesoDatos();
            Proveedor proveedor = new Proveedor();

            try
            {
                datos.setConsulta("SELECT Id,Nombre,Email,Direccion,CuilCuit,Telefono FROM Proveedores WHERE CuilCuit=@cuilCuit AND Activo=1;");
                datos.setParametro("@cuilCuit", cuitCuil);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    proveedor.Id = (int)datos.Lector["Id"];
                    proveedor.Nombre = (string)datos.Lector["Nombre"];
                    proveedor.Email = (string)datos.Lector["Email"];
                    proveedor.Direccion = (string)datos.Lector["Direccion"];
                    proveedor.CuilCuit = (string)datos.Lector["CuilCuit"];
                    proveedor.Telefono = (string)datos.Lector["Telefono"];
                    //proveedor.Activo = (bool)datos.Lector["Activo"];
                }
                return proveedor;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Proveedor> listar(string id = "")
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                if (id != "")
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM PROVEEDORES WHERE ID = " + id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM PROVEEDORES");
                }
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = (int)datos.Lector["ID"];
                    proveedor.Nombre = (string)datos.Lector["Nombre"];
                    proveedor.Email = (string)datos.Lector["Email"];
                    proveedor.Direccion = (string)datos.Lector["Direccion"];
                    proveedor.CuilCuit = (string)datos.Lector["CuilCuit"];
                    proveedor.Telefono = (string)datos.Lector["Telefono"];

                    listaProveedores.Add(proveedor);

                }

                return listaProveedores;

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


        public void agregarProveedor(Proveedor proveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();



            try
            {
                accesoDatos.setConsulta("INSERT INTO PROVEEDORES (NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO) VALUES (@NOMBRE, @EMAIL, @DIRECCION, @CUILCUIT, @TELEFONO)");
                accesoDatos.setParametro("@NOMBRE", proveedor.Nombre);
                accesoDatos.setParametro("@EMAIL", proveedor.Email);
                accesoDatos.setParametro("@DIRECCION", proveedor.Direccion);
                accesoDatos.setParametro("@CUILCUIT", proveedor.CuilCuit);
                accesoDatos.setParametro("@TELEFONO", proveedor.Telefono);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void modificarProveedor(Proveedor proveedor)
        {
            AccesoDatos accesoDatos = new AccesoDatos();


            try
            {
                accesoDatos.setConsulta("UPDATE PROVEEDORES SET NOMBRE = @NOMBRE, EMAIL = @EMAIL, DIRECCION = @DIRECCION, CUILCUIT = @CUILCUIT, TELEFONO = @TELEFONO WHERE ID = @ID");
                accesoDatos.setParametro("@ID", proveedor.Id);
                accesoDatos.setParametro("@NOMBRE", proveedor.Nombre);
                accesoDatos.setParametro("@EMAIL", proveedor.Email);
                accesoDatos.setParametro("@DIRECCION", proveedor.Direccion);
                accesoDatos.setParametro("@CUILCUIT", proveedor.CuilCuit);
                accesoDatos.setParametro("@TELEFONO", proveedor.Telefono);

                accesoDatos.ejecutarAccion();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }

        public void eliminarProveedor(int Id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setConsulta("DELETE FROM PROVEEDORES WHERE ID = @ID");
                accesoDatos.setParametro("ID", Id);
                accesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                accesoDatos.cerrarConexion();
            }
        }



        public List<Proveedor> listarProveedoresXProducto(int idProd)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.setConsulta("SELECT P.ID FROM Proveedores P INNER JOIN ProductosXProveedor PXP ON P.ID = PXP.IDProveedor WHERE PXP.IDProducto = @idProd");
                datos.setParametro("@idProd", idProd);
                datos.ejecutarLectura();

                List<Proveedor> lista = new List<Proveedor>();


                while (datos.Lector.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = (int)datos.Lector["ID"];
                    proveedor.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(proveedor);
                }

                return lista;
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
