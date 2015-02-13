using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeDados.Contexto;
using BancoDeDados.Generico;

namespace Servico
{
    public class CategoriaServico : BaseServico<Categoria>
    {
        public CategoriaServico()
        {
            contexto = new P3ImageContext();
            repositorio = new GenericRepository<Categoria>(contexto);
        }
    }
}
