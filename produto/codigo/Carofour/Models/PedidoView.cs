using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class PedidoView
    {
        //Pedido
        public virtual List<Produto> listaProdutos { get; set; }
        //Cliente
        public int idPedido { get; set; }
        public string nomeCompletoCliente { get; set; }
        public string emailCliente { get; set; }
        //public DateTime dataNascimentoCliente { get; set; }
        //public char sexoCliente { get; set; }
        public string enderecoCliente { get; set; }
        public string telefoneCliente { get; set; }

    }
}