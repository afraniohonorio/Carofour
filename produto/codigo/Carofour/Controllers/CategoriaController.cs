using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;
using Carofour.DAO;

namespace Carofour.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index()
        {
            Categoria categoriaModelo = new Categoria();
            return View(categoriaModelo.MapearCategorias());
        }

        public ActionResult DetalheCategoria(string categoria)
        {
            Categoria categoriaModelo = new Categoria();
            List<Categoria> categoriasMapeadas = categoriaModelo.MapearCategorias();
            Categoria categoriaRetorno = categoriasMapeadas.Where(c => c.nome == categoria).FirstOrDefault() as Categoria;
            return View(categoriaRetorno);
        }

    }
}
