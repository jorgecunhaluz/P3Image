using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SubCategoria
    {
        public SubCategoria()
        {
            this.SubCategoriaCampos = new List<SubCategoriaCampo>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<SubCategoriaCampo> SubCategoriaCampos { get; set; }
        
    }
}
