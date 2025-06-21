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
        public List<Cliente> listar(string id= "")
        {
            List<Cliente> listaClientes = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                
                if(id!= "")
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM CLIENTES WHERE ID = "+ id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM CLIENTES");
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
                accesoDatos.setConsulta("DELETE FROM CLIENTES WHERE ID = @ID");
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
