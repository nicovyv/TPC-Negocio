﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class Security
    {
        public static bool isAdmin(object user)
        {
            Usuario usuario;

            if (user != null)
            {
                usuario = (Usuario)user;
            }
            else
            {
                usuario = null;
            }

            
            if(usuario!=null)
            {
                return usuario.Admin;
            }
            else { return false; }
        }
       
        public static bool hayClienteAsignado(object client)
        {
            Cliente cliente;
            if( client != null )
            {
                cliente=(Cliente)client;
            }
            else
            {
                cliente = null;
            }

            if(cliente!=null && cliente.Id!=0 ) {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool isLogin(object user)
        {
            Usuario usuario;

            if (user != null)
            {

                usuario = (Usuario)user;
            }
            else
            {
                usuario = null;
            }

            // Usuario usuario = Session["usuario"] != null ? (Usuario)Session["usuario"] : null;
            if (usuario != null && usuario.Id != 0)
            {
                return true;
            }
            else { return false; }
        }
        public static string ManejoError(Exception ex)
        {
            return ex.ToString();
        }
    }
}
