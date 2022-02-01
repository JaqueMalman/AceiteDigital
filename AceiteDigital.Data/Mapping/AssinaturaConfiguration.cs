using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceiteDigital.Data.Mapping
{
    public class AssinaturaConfiguration : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Assinatura");

            builder.Property(p => p.Assinado)
                .HasColumnName("Assinado");

            builder.Property(p => p.DataHoraRegistro)
                .IsRequired()
                .HasColumnName("DataHoraRegistro")
                .HasColumnType("datetime");

            builder.HasOne(p => p.DocumentoSignatario)
                .WithOne(d => d.Assinatura)
                .HasForeignKey<Assinatura>(e => e.DocumentoSignatarioId)
                .HasConstraintName("FK_DocumentoSignatario_Assinatura_DocumentoSignatarioId");

        }
    }
}
