﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                datos.setConsulta("select email, password, nombre, apellido, admin from Usuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["id"];
                    usuario.Email = (string)datos.Lector["email"];
                    usuario.Password = (string)datos.Lector["password"];    
                    usuario.Nombre = (string)datos.Lector["nombre"];
                    usuario.Apellido = (string)datos.Lector["apellido"];
                    usuario.Admin = (bool)datos.Lector["admin"];
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
        public void ModificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE usuarios SET email=@email, nombre = @nombre, apellido = @apellido where Id = @id");
                datos.setParametro("@email", usuario.Email);
                datos.setParametro("@nombre", usuario.Nombre);
                datos.setParametro("@apellido", usuario.Apellido);
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
        public void AgregarUsuario(Usuario usuarioNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO Usuarios(email, password, nombre, apellido, admin) VALUES (@email, @password, @nombre, @apellido,0)");
                datos.setParametro("@email", usuarioNuevo.Email);
                datos.setParametro("@password", usuarioNuevo.Password);
                datos.setParametro("@nombre", usuarioNuevo.Nombre);
                datos.setParametro("@apellido", usuarioNuevo.Apellido);
                
                datos.ejecutarAccion();

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
                accesoDatos.setConsulta("select id, email, password, nombre, apellido, admin from Usuarios where email=@email and password=@password");
                accesoDatos.setParametro("@email", usuario.Email);
                accesoDatos.setParametro("@password", usuario.Password);
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
