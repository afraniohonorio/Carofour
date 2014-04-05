using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;

namespace Carofour.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        private List<Categoria> MapearCategorias()
        {
            List<Categoria> categoriasMapeadas = new List<Categoria>
                        { 
                new Categoria { id = 1, nome = "Laticínios", urlImagem = "/Content/Images/Laticinios244_154.jpg", href="/Categoria/DetalheCategoria?categoria=Laticínios",  

            produtos = new List<Produto>
            { 
                new Produto { id=2, nome = "Farinha de Trigo", descricao = "Farinha de Trigo bonita", preco = 2.20, urlImagem = ""},
                new Produto { id=2, nome = "Carne Moída", descricao = "Carne Moída bonita", preco = 12.30, urlImagem = ""}
            }},
            

            new Categoria { id = 2, nome = "Carnes", urlImagem = "/Content/Images/Carnes244_154.jpg", href="/Views/Loja/Categoria.cshtml?&categoria=Laticínios",
                    
            produtos = new List<Produto>
            { 
                new Produto { id=2, nome = "Pão Francês", descricao = "Pão Francês bonito", preco = 0.35, urlImagem = ""},
                new Produto { id=2, nome = "Picanha", descricao = "Picanha bonita", preco = 35.00, urlImagem = ""},
            }},
            
            new Categoria { id = 3, nome = "Padaria", urlImagem = "/Content/Images/Padaria244_154.jpg", href="/Views/Loja/Categoria.cshtml?&categoria=Laticínios",
                    
            produtos = new List<Produto>
            { 
                new Produto { id=2, nome = "Leite", descricao = "Leite bonito", preco = 2.22, urlImagem = ""},
                new Produto { id=2, nome = "Farinha de Trigo", descricao = "Farinha de Trigo bonita", preco = 2.20, urlImagem = ""},
                new Produto { id=2, nome = "Carne Moída", descricao = "Carne Moída bonita", preco = 12.30, urlImagem = ""}
            }},
            
            new Categoria { id = 4, nome = "Hortifrutigranjeiros", urlImagem = "/Content/Images/Hortifrutgranjeiros244_154.jpg", href="/Views/Loja/Categoria.cshtml?&categoria=Laticínios",
                    
            produtos = new List<Produto>
            { 
                new Produto { id=2, nome = "Leite", descricao = "Leite bonito", preco = 2.22, urlImagem = ""},
                new Produto { id=2, nome = "Pão Francês", descricao = "Pão Francês bonito", preco = 0.35, urlImagem = ""},
                new Produto { id=2, nome = "Farinha de Trigo", descricao = "Farinha de Trigo bonita", preco = 2.20, urlImagem = ""},
            }},
            
            };

            return categoriasMapeadas;

        }

        public ActionResult Index()
        {
            return View(this.MapearCategorias());
        }

        public ActionResult DetalheCategoria(string categoria)
        {
            List<Categoria> categoriasMapeadas = this.MapearCategorias();
            Categoria categoriaRetorno = categoriasMapeadas.Where(c => c.nome == categoria).FirstOrDefault() as Categoria;
            return View(categoriaRetorno);
        }

    }
}
