using System.Collections.Generic;

namespace dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public decimal Ganancia { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }

        public decimal CalcularGanancia()
        {
            if (PrecioCompra <= 0)
                return 0;

            return ((PrecioVenta - PrecioCompra) / PrecioCompra) * 100;
        }
    }
}