using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public Cliente buscarClientePorCuitCuil(string cuitCuil)
        {
            AccesoDatos datos = new AccesoDatos();
            Cliente cliente = new Cliente();
            
            try
            {
                datos.setConsulta("SELECT Id,Nombre,Email,Direccion,CuilCuit,Telefono,Activo FROM Clientes WHERE CuilCuit=@cuilCuit AND Activo=1;");
                datos.setParametro("@cuilCuit",cuitCuil);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.CuilCuit = (string)datos.Lector["CuilCuit"];
                    cliente.Telefono = (string)datos.Lector["Telefono"];
                    cliente.Activo = (bool)datos.Lector["Activo"];
                }
                return cliente;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Cliente> listar(string id= "")
        {
            List<Cliente> listaClientes = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                
                if(id!= "")
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM CLIENTES WHERE activo=1 and ID = " + id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM CLIENTES WHERE activo=1");
                }
                    datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.CuilCuit = (string)datos.Lector["CuilCuit"];
                    cliente.Telefono = (string)datos.Lector["Telefono"];

                    listaClientes.Add(cliente);

                }

                return listaClientes;

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

        public void agregarCliente(Cliente cliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();



            try
            {
                accesoDatos.setConsulta("INSERT INTO CLIENTES (NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO) VALUES (@NOMBRE, @EMAIL, @DIRECCION, @CUILCUIT, @TELEFONO)");
                accesoDatos.setParametro("@NOMBRE", cliente.Nombre);
                accesoDatos.setParametro("@EMAIL", cliente.Email);
                accesoDatos.setParametro("@DIRECCION", cliente.Direccion);
                accesoDatos.setParametro("@CUILCUIT", cliente.CuilCuit);
                accesoDatos.setParametro("@TELEFONO", cliente.Telefono);
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

        public void modificarCliente(Cliente cliente)
        {
            AccesoDatos accesoDatos = new AccesoDatos();


            try
            {
                accesoDatos.setConsulta("UPDATE CLIENTES SET NOMBRE = @NOMBRE, EMAIL = @EMAIL, DIRECCION = @DIRECCION, CUILCUIT = @CUILCUIT, TELEFONO = @TELEFONO WHERE ID = @ID");
                accesoDatos.setParametro("@ID", cliente.Id);
                accesoDatos.setParametro("@NOMBRE", cliente.Nombre);
                accesoDatos.setParametro("@EMAIL", cliente.Email);
                accesoDatos.setParametro("@DIRECCION", cliente.Direccion);
                accesoDatos.setParametro("@CUILCUIT", cliente.CuilCuit);
                accesoDatos.setParametro("@TELEFONO", cliente.Telefono);

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

        public void eliminarCliente(int Id)
        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setConsulta("UPDATE CLIENTES SET ACTIVO = 0  WHERE ID = @ID");
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
    }
}
