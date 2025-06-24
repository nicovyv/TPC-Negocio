using System;

namespace dominio
{


    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get { return Email; }
        set { if (value != "")
                    Email = value;
                else
                    throw new Exception("email vacio en el dominio");      }
        }
        public string ImagenUrl { get; set; }
        public bool Admin { get; set; }

    }
}