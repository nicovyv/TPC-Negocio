using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dominio
{
    public class Compra
    {
        public int Id { get; set; }
        public string NFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Proveedor Proveedor { get; set; }
        public Usuario Usuario { get; set; }
        public List<DetalleCompra> Detalle { get; set; }
        public Decimal Total
        {
            get
            { //SE OBTIENE EL VALOR DE LA COMPRA A PARTIR DE LOS VALORES SUBTOTALES DE SUS ITEMVENTA
                return Detalle.Sum(x => x.Subtotal);
            }
            set { }
        }
    }
}