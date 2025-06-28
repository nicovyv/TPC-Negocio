using System;
using System.Collections.Generic;

namespace dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<ItemVenta> ItemVenta { get; set; }
        public Decimal Total { get; set; }
        public string Factura {  get; set; }    

    }
}