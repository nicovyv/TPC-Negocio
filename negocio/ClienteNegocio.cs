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
        public List<Cliente> listar()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT ID, NOMBRE, EMAIL, DIRECCION, CUILCUIT, TELEFONO FROM CLIENTES");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["ID"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.CuilCuit = (string)datos.Lector["CuilCuit"];
                    cliente.Telefono = (int)datos.Lector["Telefono"];

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
    }
}
