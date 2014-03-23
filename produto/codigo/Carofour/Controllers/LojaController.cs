﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Carofour.Models;

namespace Carofour.Controllers
{
    public class LojaController : Controller
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
            var modeloCategoria = new Categoria { nome = categoria};
            return View(modeloCategoria);
        }
        
    }
}