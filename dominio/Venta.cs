using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<ItemVenta> ItemVenta { get; set; }
        public Decimal Total
        {
            get
            { //SE OBTIENE EL VALOR DE LA VENTA A PARTIR DE LOS VALORES SUBTOTALES DE SUS ITEMVENTA
                return ItemVenta.Sum(x => x.Subtotal);
            }
            set { }
        }
        public int Factura { get; set; }

    }
}