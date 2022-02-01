using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AceiteDigital.Data.Mapping
{
    public class DocumentoSignatarioConfiguration : IEntityTypeConfiguration<DocumentoSignatario>
    {
        public void Configure(EntityTypeBuilder<DocumentoSignatario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("DocumentoSignatario");

            builder.Property(p => p.TipoSignatario)
                .HasColumnName("TipoSignatario")
                .HasConversion(new EnumToNumberConverter<TipoSignatario, int>());

            builder.HasOne(e => e.Documento)
                .WithMany(d => d.DocumentosSignatarios)
                .HasForeignKey(e => e.DocumentoId)
                .HasConstraintName("FK_Documento_DocumentoSignatario_DocumentoId");

            builder.HasOne(e => e.Signatario)
                .WithMany(d => d.DocumentosSignatarios)
                .HasForeignKey(e => e.SignatarioId)
                .HasConstraintName("FK_Signatario_DocumentoSignatario_SignatarioId");



        }
    }
}
