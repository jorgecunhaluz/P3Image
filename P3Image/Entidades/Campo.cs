using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Campo
    {
       public Campo()
        {
            this.Opcoes = new List<Opcao>();
        }
        
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int IdTipo { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual ICollection<Opcao> Opcoes { get; set; }
        public virtual ICollection<SubCategoriaCampo> tblSubCategoriaCampos { get; set; }
    }
}
