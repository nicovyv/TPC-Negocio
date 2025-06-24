using System;

namespace dominio
{


    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { 
            if(!string.IsNullOrEmpty(value))
                    _password = value;
            else
                    throw new Exception("password vacio o nulo en el dominio");
            }
        }
        private string _email;
        public string Email { get { return _email; }
        set { if (!string.IsNullOrEmpty(value))
                    _email = value;
                else
                    throw new Exception("email vacio o nulo en el dominio");      }
        }
        public string ImagenUrl { get; set; }
        public bool Admin { get; set; }

    }
}