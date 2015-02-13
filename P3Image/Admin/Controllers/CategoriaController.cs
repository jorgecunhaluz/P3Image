using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Admin.Models;
using Entidades;
using Servico;

namespace Admin.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaServico categSVC;
        private SubCategoriaServico subCategoria;

        public CategoriaController(CategoriaServico categSVC, SubCategoriaServico subCategoria)
        {
            this.categSVC = categSVC;
            this.subCategoria = subCategoria;
        }

        public ActionResult Index()
        {
            return View(categSVC.GetAll());
        }

        public ActionResult Form(int? id)
        {
            Categoria categoria = new Categoria();

            if (id.HasValue)
            {
                categoria = categSVC.Get(id);
            }

            return View(categoria);
        }

        public ActionResult Adiciona(Categoria categoria)
        {
            try
            {
                if (categoria.Id == 0)
                    categSVC.Insert(categoria);
                else
                    categSVC.Update(categoria);

                TempData["Mensagem"] = new Mensagem { Texto = "Sucesso!", Sucesso = true };
            }
            catch (Exception)
            {
                TempData["Mensagem"] = new Mensagem { Texto = "Erro!", Sucesso = false };
            }

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(int id)
        {
            try
            {
                if (subCategoria.GetByCategoriaId(id).Any())
                {
                    TempData["Mensagem"] = new Mensagem { Texto = "Existem SubCategorias!" };
                }
                else
                {
                    categSVC.Delete(id);
                    TempData["Mensagem"] = new Mensagem { Texto = "Sucesso!", Sucesso = true };
                }
            }
            catch (Exception)
            {
                TempData["Mensagem"] = new Mensagem { Texto = "Erro!", Sucesso = false };
            }

            return RedirectToAction("Index");
        }
    }
}
