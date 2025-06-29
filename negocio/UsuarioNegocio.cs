using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar(string id="")
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                if (id != "")
                {
                    datos.setConsulta("select id, email, pass, nombre, apellido, admin, activo from Usuarios where id = " + id);
                }
                else
                {
                    datos.setConsulta("select id, email, pass, nombre, apellido, admin, activo from Usuarios");
                }
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Email = (string)datos.Lector["email"];
                    usuario.Password = (string)datos.Lector["pass"];
                    if (!(datos.Lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    }
                    if (!(datos.Lector["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    }
                    usuario.Admin = (bool)datos.Lector["admin"];
                    usuario.Activo = (bool)datos.Lector["activo"];
                    usuarios.Add(usuario);

                }

                return usuarios;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public Usuario buscarMail(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario usuario = new Usuario();
            try
            {
                if (email != "")
                {
                    datos.setConsulta("select id from usuarios where email = @email");
                    datos.setParametro("@email", email);
                    datos.ejecutarLectura();
                    datos.Lector.Read();
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Email = email;
                   
                    return usuario;
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void ResetPass(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set pass = @pass  where Id = @id");
                datos.setParametro("@pass", usuario.Password);
                datos.setParametro("@id", usuario.Id);
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
        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set email=@email, nombre = @nombre, apellido = @apellido, urlImagenPerfil = @img where Id = @id");
                datos.setParametro("@email", usuario.Email);
                datos.setParametro("@nombre", usuario.Nombre);
                datos.setParametro("@apellido", usuario.Apellido);
                datos.setParametro("@img", (object)usuario.ImagenUrl ?? DBNull.Value);
                datos.setParametro("@id", usuario.Id);
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
        public void Desactivar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set activo = 0 where Id = @id");
                datos.setParametro("@id", id);
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

        public void Activar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set activo = 1 where Id = @id");
                datos.setParametro("@id", id);
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
        public void Admin(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set admin = 1 where Id = @id");
                datos.setParametro("@id", id);
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
        public void Vendedor(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE Usuarios set admin = 0 where Id = @id");
                datos.setParametro("@id", id);
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
        public int AgregarUsuario(Usuario usuarioNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("insertarUsuario");
                datos.setParametro("@email", usuarioNuevo.Email);
                datos.setParametro("@pass", usuarioNuevo.Password);

                return datos.ejecutarAccionEscalar();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }
        public bool Login(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("select id, email, pass, nombre, apellido, admin,UrlImagenPerfil  from Usuarios where email=@email and pass=@pass");
                accesoDatos.setParametro("@email", usuario.Email);
                accesoDatos.setParametro("@pass", usuario.Password);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    usuario.Id = (int)accesoDatos.Lector["id"];
                    usuario.Admin = (bool)accesoDatos.Lector["admin"];


                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)accesoDatos.Lector["nombre"];

                    }


                    if (!(accesoDatos.Lector["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)accesoDatos.Lector["apellido"];

                    }
                    if (!(accesoDatos.Lector["urlImagenPerfil"] is DBNull))
                    {
                        usuario.ImagenUrl = (string)accesoDatos.Lector["urlImagenPerfil"];

                    }



                    return true;
                }

                return false;

            }

            catch (Exception ex)
            {

                throw ex;
            }
            finally { accesoDatos.cerrarConexion(); }
        }
    }
}
