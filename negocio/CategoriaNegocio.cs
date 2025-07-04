using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar(string id = "")
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                if (id != "")
                {
                    datos.setConsulta("SELECT ID, DESCRIPCION FROM CATEGORIAS WHERE ID = " + id);
                }
                else
                {
                    datos.setConsulta("SELECT ID, DESCRIPCION FROM CATEGORIAS");
                }
                    
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.Id = (int)datos.Lector["ID"];
                    categoria.Descripcion = (string)datos.Lector["Descripcion"];

                    listaCategoria.Add(categoria);

                }

                return listaCategoria;

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

        public void agregar(Categoria nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("INSERT INTO CATEGORIAS (DESCRIPCION) VALUES(@Descripcion)");
                datos.setParametro("@Descripcion", nuevo.Descripcion);
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

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("UPDATE CATEGORIAS SET DESCRIPCION = '" + categoria.Descripcion + "' WHERE ID = '" + categoria.Id + "'");
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

        public void eliminarCategoria(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("UPDATE CATEGORIAS SET ACTIVO = 0 where id = @id");
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
