using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class ItemPedido
    {
        public int quantidade { get; set; }
        public Pedido pedido { get; set; }
    }
}