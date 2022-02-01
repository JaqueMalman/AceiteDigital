using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceiteDigital.Data.Mapping
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.DataHoraEvento)
                .IsRequired()
                .HasColumnName("DataHoraEvento")
                .HasColumnType("datetime");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasMaxLength(400);

            builder.HasOne(p => p.Documento)
                .WithMany(d => d.Eventos)
                .HasForeignKey(e => e.DocumentoId)
                .HasConstraintName("FK_Documento_Evento_DocumentoId");
            

        }
    }
}
