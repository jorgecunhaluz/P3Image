using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeDados.Contexto;
using BancoDeDados.Generico;
using Entidades;

namespace Servico
{
    public class SubCategoriaCampoServico : BaseServico<SubCategoriaCampo>
    {
        public SubCategoriaCampoServico()
        {
            contexto = new P3ImageContext();
            repositorio = new GenericRepository<SubCategoriaCampo>(contexto);
        }

        public List<SubCategoriaCampo> GetAllBySubCategoriaId(int subCategoriaId)
        {
            return contexto.SubCategoriaCampos.Where(s => s.IdSubCategoria == subCategoriaId).ToList();
        }

        public void DeleteSubCategoriaCampo(int subCategoriaId, int idCampo, int ordem)
        {
            SubCategoriaCampo sub = contexto.SubCategoriaCampos.Where(s => s.IdSubCategoria == subCategoriaId 
                                                                        && s.IdCampo == idCampo
                                                                        && s.Ordem == ordem).First();

            contexto.SubCategoriaCampos.Remove(sub);
            contexto.SaveChanges();
        }

        public void DeleteAllSubCategoriaCampo(int subCategoriaId)
        {
            List<SubCategoriaCampo> subCampos = GetAllBySubCategoriaId(subCategoriaId);
            foreach (var item in subCampos)
            {
                repositorio.Delete(item);
            }
            contexto.SaveChanges();
        }

        public void InsertAllSubCategoriaCampo(List<SubCategoriaCampo> subCategorias)
        {
            for (int i = 0; i < subCategorias.Count; i++)
            {
                repositorio.Insert(subCategorias[i]);
            }

            contexto.SaveChanges();
        }

        public int PegaOrdemCampoSubCategoria(int subCategoriaId)
        {
            List<SubCategoriaCampo> lista = contexto.SubCategoriaCampos.Where(s => s.IdSubCategoria == subCategoriaId).ToList();

            if (lista.Count > 0)
                return lista.Max(p => p.Ordem) + 1;
            else
                return 1;
        }
    }
}
