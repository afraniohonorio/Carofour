using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Carofour.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public string nomeCompleto { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string dataNascimento { get; set; }
        public string sexo { get; set; }
        public string endereco { get; set; }
        public string telefone { get; set; }
    }
}