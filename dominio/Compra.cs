namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
        public Proovedor Proovedor { get; set; }
    }
}