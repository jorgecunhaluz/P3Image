using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public Categoria()
        {
            this.tblSubCategorias = new List<SubCategoria>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Slug { get; set; }
        public virtual ICollection<SubCategoria> tblSubCategorias { get; set; }
    }
}
