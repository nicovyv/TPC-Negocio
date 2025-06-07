using System;

namespace dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public decimal Valor { get; set; }
        public int Cantidad { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        

        public TipoUsuario Vendedor { get; set; }
    }
}