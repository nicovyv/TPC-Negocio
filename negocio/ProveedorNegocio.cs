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
        public List<Proveedor> listar()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("SELECT ID, NOMBRE FROM PROVEEDORES");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Proveedor proveedor = new Proveedor();
                    proveedor.Id = (int)datos.Lector["ID"];
                    proveedor.Nombre = (string)datos.Lector["Nombre"];

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
    }
}
