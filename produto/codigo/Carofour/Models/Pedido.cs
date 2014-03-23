using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class Pedido
    {
        public int numero { get; set; }
        public virtual List<ItemPedido> listaPedidos { get; set; }
    }
}