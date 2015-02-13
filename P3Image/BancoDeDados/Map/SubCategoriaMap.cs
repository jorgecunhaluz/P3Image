using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BancoDeDados.Map
{
    public class SubCategoriaMap : EntityTypeConfiguration<SubCategoria>
    {
        public SubCategoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Slug)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tblSubCategoria");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Slug).HasColumnName("Slug");
            this.Property(t => t.IdCategoria).HasColumnName("IdCategoria");

            // Relationships
            this.HasRequired(t => t.Categoria)
                .WithMany(t => t.tblSubCategorias)
                .HasForeignKey(d => d.IdCategoria);

        }
    }
}
