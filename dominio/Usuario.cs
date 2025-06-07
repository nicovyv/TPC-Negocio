namespace dominio
{
    public enum TipoUsuario
    {
        Vendedor = 1,
        Administrador = 2,
        Gerente=3
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}