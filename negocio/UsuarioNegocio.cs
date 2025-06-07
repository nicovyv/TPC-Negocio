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
        public bool Login(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                accesoDatos.setConsulta("select id, email, password, nombre, apellido, tipousuario,  from Usuarios where email=@email and password=@password");
                accesoDatos.setParametro("@email", usuario.Email);
                accesoDatos.setParametro("@password", usuario.Password);
                accesoDatos.ejecutarLectura();

                if (accesoDatos.Lector.Read())
                {
                    usuario.Id = (int)accesoDatos.Lector["id"];
                    usuario.TipoUsuario = (TipoUsuario)accesoDatos.Lector["TipoUsuario"];


                    if (!(accesoDatos.Lector["nombre"] is DBNull))
                    {
                        usuario.Nombre = (string)accesoDatos.Lector["nombre"];

                    }


                    if (!(accesoDatos.Lector["apellido"] is DBNull))
                    {
                        usuario.Apellido = (string)accesoDatos.Lector["apellido"];

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
