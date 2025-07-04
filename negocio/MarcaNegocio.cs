using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {

        public List<Marca> listar(string id = "")
        {
            List<Marca> marcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                if (id != "")
                {
                    datos.setConsulta("SELECT ID, Descripcion FROM MARCAS WHERE ID = " + id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, Descripcion FROM MARCAS");
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Lector["ID"];
                    marca.Descripcion = (string)datos.Lector["DESCRIPCION"];

                    marcas.Add(marca);

                }

                return marcas;
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


        public void agregarMarca(Marca marca)
        {
            AccesoDatos accesoDatos = new AccesoDatos();



            try
            {
                accesoDatos.setConsulta("INSERT INTO MARCAS (DESCRIPCION) VALUES (@desc)");
                accesoDatos.setParametro("@desc", marca.Descripcion);
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

        public void modificarMarca(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setConsulta("UPDATE MARCAS SET Descripcion = @desc WHERE Id = @id");
                datos.setParametro("@desc", marca.Descripcion);
                datos.setParametro("@id", marca.Id);

                datos.ejecutarAccion();
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

        public void eliminarMarca(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("UPDATE MARCAS SET ACTIVO = 0 where id = @id");
                datos.setParametro("Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
