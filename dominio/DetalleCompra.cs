using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}