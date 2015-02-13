using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoDeDados.Map;

namespace BancoDeDados.Contexto
{
    public class P3ImageContext : DbContext
    {
        public P3ImageContext()
            : base("P3ImageContext")
        {
            Database.SetInitializer<P3ImageContext>(new CreateDatabaseIfNotExists<P3ImageContext>());
        }

        public DbSet<Campo> Campos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Opcao> Opcoes { get; set; }
        public DbSet<SubCategoria> SubCategorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<SubCategoriaCampo> SubCategoriaCampos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CampoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new OpcaoMap());
            modelBuilder.Configurations.Add(new SubCategoriaMap());
            modelBuilder.Configurations.Add(new TipoMap());
            modelBuilder.Configurations.Add(new SubCategoriaCampoMap());
        }
    }
}
