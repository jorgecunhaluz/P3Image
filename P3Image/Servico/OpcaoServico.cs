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
    public class OpcaoServico : BaseServico<Opcao>
    {
        public OpcaoServico()
        {
            contexto = new P3ImageContext();
            repositorio = new GenericRepository<Opcao>(contexto);
        }

        public List<Opcao> GetByIdCampo(int idCampo)
        {
            var consulta = contexto.Opcoes.Where(c => c.IdCampo == idCampo).ToList();
            return consulta;
        }
    }
}
