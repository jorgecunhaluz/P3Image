using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tipo
    {
         public Tipo()
        {
            this.Campos = new List<Campo>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Campo> Campos { get; set; }
    }
}
