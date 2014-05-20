using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;

namespace Carofour.Controllers
{
    public class CarrinhoController : Controller
    {
        //
        // GET: /Store/

        public ActionResult Indice()
        {
            var categorias = new List<Categoria>
            { 
                new Categoria { nome = "Laticínios" },
                new Categoria { nome = "Carnes" },
                new Categoria { nome = "Padaria" },
                new Categoria { nome = "Hortifrutigranjeiros" }
            };
            return View(categorias);
        }

        public ActionResult Detalhes(int id)
        {
            var produto = new Produto { nome = "Produto " + id };
            return View(produto);
        }

        public ActionResult Navegar(string categoria)
        {
            var modeloCategoria = new Categoria { nome = categoria };
            return View(modeloCategoria);
        }

        public ActionResult FecharCompra(Cliente cliente)
        {
            List<Cliente> c = new List<Cliente>();

            if (cliente.nomeCompleto != null)
            {
                c.Add(cliente);
                TempData["Mensagem"] = "O Cliente foi cadastrado com sucesso !";
            }
            return View("FecharCompra", cliente);
        }

        public ActionResult VerCarrinho(Produto produto)
        {
            var produtos = new List<Produto>
            { 
                new Produto { id=2, nome = "Farinha de Trigo", descricao = "Farinha de Trigo bonita", preco = 2.20, urlImagem = "/Content/Images/farinhaDeTrigo.jpg"},
                new Produto { id=2, nome = "Carne Moída", descricao = "Carne Moída bonita", preco = 12.30, urlImagem = "/Content/Images/carneMoida.jpg"}
            };
            return View(produtos);
        }

        public ActionResult InformacoesDaCompra()
        {
            //List<Categoria> categoriasMapeadas = this.MapearCategorias();
            //Categoria categoriaRetorno = categoriasMapeadas.Where(c => c.nome == categoria).FirstOrDefault() as Categoria;
            return View();
        }
    }
}
