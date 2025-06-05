namespace dominio
{
    public enum TipoUsuario
    {
        Vendedor = 1,
        Administrador = 2
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}