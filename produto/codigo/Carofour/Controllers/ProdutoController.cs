using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;
using Carofour.DAO;

namespace Carofour.Controllers
{
    public class ProdutoController : Controller
    {
        private List<Produto> ObterTodos()
        {
            ProdutoDAO dao = new ProdutoDAO();
            List<Produto> produtos = new List<Produto>();

            produtos = dao.ObterTodos();

            return produtos;
        }

        private Produto ObterPorId(int id)
        {
            ProdutoDAO dao = new ProdutoDAO();
            Produto produto = new Produto();

            produto = dao.ObterPorId(id);

            return produto;
        }

        private List<Produto> ObterPorCategoria(int idCategoria)
        {
            ProdutoDAO dao = new ProdutoDAO();
            List<Produto> produtos = new List<Produto>();

            produtos = dao.ObterPorCategoria(idCategoria);

            return produtos;
        }
    }
}
