using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Servico;
using Site.Models;

namespace Site.Controllers
{
    public class FormularioController : Controller
    {
        private SubCategoriaServico subCategSVC;

        public FormularioController(SubCategoriaServico subCategSVC)
        {
            this.subCategSVC = subCategSVC;
        }

        public ActionResult Index(string slugCategoria, string slugSubCategoria)
        {
            SubCategoria sc = subCategSVC.GetBySlugCategoriaSubCategoria(slugCategoria, slugSubCategoria);

            if (sc == null)
            {
                sc = new SubCategoria();
                TempData["Mensagem"] = new Mensagem { Texto = "Categoria ou SubCategoria não encontrada!", Sucesso = false };
            }

            return View(sc);
        }
    }
}
