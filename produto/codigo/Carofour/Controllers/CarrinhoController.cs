using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;
using Carofour.DAO;

namespace Carofour.Controllers
{
    public class CarrinhoController : Controller
    {
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //Insere produtos na sessão
        public ActionResult InserirProduto(string idProduto)
        {
            
            PedidoDAO pedidoDAO = new PedidoDAO();
            ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO();

            HttpContext.Session["ItensCarrinho"] = String.Format("{0}{1};", HttpContext.Session["ItensCarrinho"], idProduto);

            return RedirectToAction("FecharCompra", "Carrinho");
        }

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

        //Finaliza a compra
        public ActionResult FecharCompra(Cliente cliente)
        {
            ItemPedido itemPedidoVO = new ItemPedido();

            try
            {
                if (!(String.IsNullOrEmpty(cliente.nomeCompleto) &&
                    String.IsNullOrEmpty(cliente.senha) &&
                    String.IsNullOrEmpty(cliente.email) &&
                    String.IsNullOrEmpty(cliente.endereco) &&
                    String.IsNullOrEmpty(cliente.telefone)) &&
                    !String.IsNullOrEmpty(HttpContext.Session["ItensCarrinho"].ToString()))
                {
                    ClienteDAO clienteDAO = new ClienteDAO();

                    //Inserindo o cliente
                    cliente.id = clienteDAO.InserirCliente(cliente);

                    if (cliente.id > 0)
                    {
                        PedidoDAO pedidoDAO = new PedidoDAO();

                        //Criando o pedido para o cliente cadastrado anteriormente
                        itemPedidoVO.idPedido = pedidoDAO.InserirPedido(cliente.id);

                        if (itemPedidoVO.idPedido > 0)
                        {
                            ItemPedidoDAO itemPedidoDAO = new ItemPedidoDAO();
                            List<Produto> produtos = new List<Produto>();
                            ProdutoDAO produtoDAO = new ProdutoDAO();

                            //Obtendo os produtos presentes no carrinho
                            if (HttpContext.Session["ItensCarrinho"] != null)
                            {
                                string[] produtosSessao = HttpContext.Session["ItensCarrinho"].ToString().Split(';');

                                foreach (string p in produtosSessao)
                                {
                                    if (p != "")
                                    {
                                        produtos.Add(produtoDAO.ObterPorId(Convert.ToInt32(p)));
                                    }
                                }
                            }

                            //Criando os itens para o pedido
                            foreach (Produto p in produtos)
                            {
                                itemPedidoVO.quantidade = 1;
                                itemPedidoVO.idProduto = p.id;

                                itemPedidoDAO.InserirItemPedido(itemPedidoVO);
                            }
                            return this.InformacoesDaCompra(itemPedidoVO.idPedido);
                        }
                        else
                        {
                            return View("FecharCompra", cliente);
                        }
                    }
                    else
                    {
                        return View("FecharCompra", cliente);
                    }
                }
                else
                {
                    return View("FecharCompra", cliente);
                }
            }
            catch (Exception ex)
            {
                return View("FecharCompra", cliente);
            }
        }

        public ActionResult VerCarrinho()
        {
            List<Produto> produtos = new List<Produto>();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            try
            {
                if (HttpContext.Session["ItensCarrinho"] != null)
                {
                    string[] produtosSessao = HttpContext.Session["ItensCarrinho"].ToString().Split(';');

                    foreach (string p in produtosSessao)
                    {
                        if (p != "")
                        {
                            produtos.Add(produtoDAO.ObterPorId(Convert.ToInt32(p)));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return View("VerCarrinho", produtos);
        }

        public ActionResult RetirarDoCarrinho(int idProduto)
        {
            if (!string.IsNullOrEmpty(idProduto.ToString()))
            {
                HttpContext.Session["ItensCarrinho"] = HttpContext.Session["ItensCarrinho"].ToString().Replace(string.Format("{0};", idProduto), "");
            }

            return this.VerCarrinho();
        }

        public ActionResult LimparCarrinho()
        {
            HttpContext.Session["ItensCarrinho"] = "";

            return this.VerCarrinho();
        }

        public ActionResult InformacoesDaCompra(int idPedido)
        {
            PedidoDAO pedidoDAO = new PedidoDAO();
            PedidoView pedidoViewVO = new PedidoView();

            pedidoViewVO = pedidoDAO.ObterDetalhesPedido(idPedido);

            return View("InformacoesDaCompra", pedidoViewVO);
        }
    }
}
