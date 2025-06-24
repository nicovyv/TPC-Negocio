using System;
using System.Collections.Generic;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public string NFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedor Proveedor { get; set; }
        public Usuario Usuario { get; set; }
        public decimal Total { get; set; }
    }
}