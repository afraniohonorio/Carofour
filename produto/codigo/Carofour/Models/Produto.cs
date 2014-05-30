using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public double preco { get; set; }
        public string urlImagem { get; set; }
        public int quantidade { get; set; }
    }
}