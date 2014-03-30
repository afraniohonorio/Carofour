using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string urlImagem { get; set; }
        //public virtual List<Produto> produtos { get; set; }
    }
}