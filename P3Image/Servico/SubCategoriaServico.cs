using BancoDeDados.Contexto;
using BancoDeDados.Generico;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class SubCategoriaServico : BaseServico<SubCategoria>
    {
        public SubCategoriaServico()
        {
            contexto = new P3ImageContext();
            repositorio = new GenericRepository<SubCategoria>(contexto);
        }

        public List<SubCategoria> GetByCategoriaId(int categoriaId)
        {
            return contexto.SubCategorias.Where(sb => sb.IdCategoria == categoriaId).ToList();
        }

        public SubCategoria GetBySlugCategoriaSubCategoria(string slugCategoria, string slugSubCategoria)
        {
            var consulta = contexto.SubCategorias.Where(sb => sb.Categoria.Slug == slugCategoria && sb.Slug == slugSubCategoria).FirstOrDefault();
            return consulta;
        }
    }
}
