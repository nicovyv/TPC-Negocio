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
        public string Img { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public List<Proveedor> Proveedores { get; set; }
        public float Ganancia { get; set; }
        public decimal PrecioCompra { get; set; }
        public bool Activo { get; set; }
    }
}