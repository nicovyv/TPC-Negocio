using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class DetalleCompraNegocio
    {
        public List<DetalleCompra> Listar(int idCompra)
        {
            List<DetalleCompra> lista = new List<DetalleCompra>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT DC.PrecioUnidad, DC.Cantidad FROM DetalleCompra DC WHERE DC.IDCompra = @IDCompra");

                datos.setParametro("@IDCompra", idCompra);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleCompra detalle = new DetalleCompra();
                    detalle.PrecioUnidad = (decimal)datos.Lector["PrecioUnidad"];
                    detalle.Cantidad = (int)datos.Lector["Cantidad"];
                    lista.Add(detalle);
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
    }
}
