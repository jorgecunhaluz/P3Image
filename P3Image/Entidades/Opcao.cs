using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Opcao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdCampo { get; set; }
        public virtual Campo Campo { get; set; }
    }
}
