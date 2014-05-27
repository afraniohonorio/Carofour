using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Carofour.DAO;

namespace Carofour.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string urlImagem { get; set; }
        public virtual List<Produto> produtos { get; set; }
        public string href { get; set; }

        public List<Categoria> MapearCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();
            CategoriaDAO dao = new CategoriaDAO();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            categorias = dao.ObterTodos();

            foreach (Categoria categoria in categorias)
            {
                categoria.produtos = produtoDAO.ObterPorCategoria(categoria.id);
            }

            return categorias;
        }
    }
}