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
    public class TipoServico : BaseServico<Tipo>
    {
        public TipoServico()
        {
            contexto = new P3ImageContext();
            repositorio = new GenericRepository<Tipo>(contexto);
        }
    }
}
