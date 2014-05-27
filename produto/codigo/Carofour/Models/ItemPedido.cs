using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class ItemPedido
    {
        public int id { get; set; }
        public int quantidade { get; set; }
        public int idPedido { get; set; }
        public int idProduto { get; set; }
    }
}