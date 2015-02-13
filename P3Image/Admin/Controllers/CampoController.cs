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
    public class CampoController : Controller
    {
        private CampoServico campoSVC;
        private TipoServico tipoSVC;
        private CategoriaServico categSVC;
        private SubCategoriaServico subCategSVC;
        private OpcaoServico opcaoSVC;

        public CampoController(CampoServico campoSVC, TipoServico tipoSVC,
            CategoriaServico categSVC, SubCategoriaServico subCategSVC, OpcaoServico opcaoSVC)
        {
            this.campoSVC = campoSVC;
            this.tipoSVC = tipoSVC;
            this.categSVC = categSVC;
            this.subCategSVC = subCategSVC;
            this.opcaoSVC = opcaoSVC;
        }

        public ActionResult Index()
        {
            return View(campoSVC.GetAll());
        }

        public ActionResult Form(int? id)
        {
            Campo campo = new Campo();

            if (id.HasValue)
            {
                campo = campoSVC.Get(id);
            }

            ViewBag.Tipos = tipoSVC.GetAll();

            return View(campo);
        }

        public ActionResult Adiciona(Campo campo)
        {
            try
            {
                if (campo.Id == 0)
                    campoSVC.Insert(campo);
                else
                    campoSVC.Update(campo);

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
                if (subCategSVC.GetByCategoriaId(id).Any())
                {
                    TempData["Mensagem"] = new Mensagem { Texto = "Existem SubCategorias!" };
                }
                else
                {
                    campoSVC.Delete(id);
                    TempData["Mensagem"] = new Mensagem { Texto = "Sucesso!", Sucesso = true };
                }
            }
            catch (Exception)
            {
                TempData["Mensagem"] = new Mensagem { Texto = "Erro!", Sucesso = false };
            }

            return RedirectToAction("Index");
        }

        public ActionResult ListaDropDown(int Id)
        {
            ViewBag.DescricaoCampo = campoSVC.Get(Id).Descricao;
            ViewBag.IdCampo = Id.ToString();

            var teste = opcaoSVC.GetByIdCampo(Id);
            return View(teste);
        }

        public ActionResult GravaOpcaoAdicionada(Opcao opcao)
        {
            opcaoSVC.Insert(opcao);
            return RedirectToAction("ListaDropDown", new { id = opcao.IdCampo });
        }

        public ActionResult ExcluirOpcao(int Id)
        {
            int IdCampo = opcaoSVC.Get(Id).IdCampo;

            opcaoSVC.Delete(Id);
            return RedirectToAction("ListaDropDown", new { id = IdCampo });
        }
    }
}
