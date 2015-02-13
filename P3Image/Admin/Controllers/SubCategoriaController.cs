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
    public class SubCategoriaController : Controller
    {
        private CampoServico campoSVC;
        private CategoriaServico categSVC;
        private SubCategoriaServico subCategSVC;
        private SubCategoriaCampoServico subCategCampoSVC;

        public SubCategoriaController(CampoServico campoSVC, 
            CategoriaServico categSVC, 
            SubCategoriaServico subCategSVC, 
            SubCategoriaCampoServico subCategCampoSVC)
        {
            this.campoSVC = campoSVC;
            this.categSVC = categSVC;
            this.subCategSVC = subCategSVC;
            this.subCategCampoSVC = subCategCampoSVC;
        }

        public ActionResult Index()
        {
            return View(subCategSVC.GetAll());
        }

        public ActionResult Form(int? id)
        {
            SubCategoria subCategoria = new SubCategoria();

            if (id.HasValue)
            {
                subCategoria = subCategSVC.Get(id);
            }

            ViewBag.Categorias = categSVC.GetAll();
            ViewBag.Campos = campoSVC.GetAll();

            return View(subCategoria);
        }

        public ActionResult Adiciona(SubCategoria subCategoria)
        {
            try
            {
                if (subCategoria.Id == 0)
                    subCategSVC.Insert(subCategoria);
                else
                    subCategSVC.Update(subCategoria);

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
                subCategSVC.Delete(id);
                TempData["Mensagem"] = new Mensagem { Texto = "Sucesso!", Sucesso = true };
            }
            catch (Exception)
            {
                TempData["Mensagem"] = new Mensagem { Texto = "Erro!", Sucesso = false };
            }

            return RedirectToAction("Index");
        }

        public ActionResult Campos(int id)
        {
            SubCategoria subCategoria = subCategSVC.Get(id);

            ViewBag.Campos = campoSVC.GetAll();

            return View(subCategoria);
        }

        public ActionResult GravaCampoAdicionado(SubCategoriaCampo subCategoriaCampo)
        {
            subCategoriaCampo.Ordem = subCategCampoSVC.PegaOrdemCampoSubCategoria(subCategoriaCampo.IdSubCategoria);
            subCategCampoSVC.Insert(subCategoriaCampo);

            return RedirectToAction("Campos", new { id = subCategoriaCampo.IdSubCategoria });
        }

        public ActionResult GravaOrdem(int idSubCategoria, int[] idCampo)
        {
            subCategCampoSVC.DeleteAllSubCategoriaCampo(idSubCategoria);

            List<SubCategoriaCampo> categs = new List<SubCategoriaCampo>();
            ViewBag.Campos = campoSVC.GetAll();
            for (int i = 0; i < idCampo.Length; i++)
            {
                SubCategoriaCampo categitem = new SubCategoriaCampo { IdCampo = idCampo[i], IdSubCategoria = idSubCategoria, Ordem = (i + 1) };
                categs.Add(categitem);
            }

            subCategCampoSVC.InsertAllSubCategoriaCampo(categs);
            TempData["Mensagem"] = new Mensagem { Texto = "Sucesso!", Sucesso = true };


            return RedirectToAction("Campos", new { id = idSubCategoria });
        }

        public ActionResult ExcluirOpcao(int idSubCategoria, int idCampo, int ordem)
        {
            subCategCampoSVC.DeleteSubCategoriaCampo(idSubCategoria, idCampo, ordem);

            return RedirectToAction("Campos", new { id = idSubCategoria });
        }
    }
}
