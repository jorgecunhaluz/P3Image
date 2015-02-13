using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BancoDeDados.Map
{
    public class OpcaoMap : EntityTypeConfiguration<Opcao>
    {
        public OpcaoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descricao)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("tblOpcao");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.IdCampo).HasColumnName("IdCampo");

            // Relationships
            this.HasRequired(t => t.Campo)
                .WithMany(t => t.Opcoes)
                .HasForeignKey(d => d.IdCampo);

        }
    }
}
