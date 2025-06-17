using System.Collections.Generic;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal PrecioUnidad { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioFinal { get; set; }
        public Proveedor proveedor { get; set; }
    }
}