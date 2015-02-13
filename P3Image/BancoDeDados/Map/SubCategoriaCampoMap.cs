using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BancoDeDados.Map
{
    public class SubCategoriaCampoMap : EntityTypeConfiguration<SubCategoriaCampo>
    {
        public SubCategoriaCampoMap()
        {
            // Primary Key
            this.HasKey(t => new { t.IdSubCategoria, t.IdCampo, t.Ordem });

            // Properties
            this.Property(t => t.IdSubCategoria)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.IdCampo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Ordem)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("tblSubCategoriaCampo");
            this.Property(t => t.IdSubCategoria).HasColumnName("IdSubCategoria");
            this.Property(t => t.IdCampo).HasColumnName("IdCampo");
            this.Property(t => t.Ordem).HasColumnName("Ordem");

            // Relationships
            this.HasRequired(t => t.Campo)
                .WithMany(t => t.tblSubCategoriaCampos)
                .HasForeignKey(d => d.IdCampo);
            this.HasRequired(t => t.SubCategoria)
                .WithMany(t => t.SubCategoriaCampos)
                .HasForeignKey(d => d.IdSubCategoria);
        }
    }
}
