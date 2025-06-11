using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class ItemVenta
    {
        public int Id { get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnidad { get; set; }
    }
}