using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public DateTime data { get; set; }
        public int idCliente { get; set; }
        public virtual List<ItemPedido> listaItens { get; set; }
    }
}