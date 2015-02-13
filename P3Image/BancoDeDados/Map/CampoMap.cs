using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BancoDeDados.Map
{
    public class CampoMap : EntityTypeConfiguration<Campo>
    {
        public CampoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tblCampo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.IdTipo).HasColumnName("IdTipo");

            // Relationships
            this.HasRequired(t => t.Tipo)
                .WithMany(t => t.Campos)
                .HasForeignKey(d => d.IdTipo);
        }
    }
}
