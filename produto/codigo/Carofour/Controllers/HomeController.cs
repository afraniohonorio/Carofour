using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;

namespace Carofour.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
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

    }
}
