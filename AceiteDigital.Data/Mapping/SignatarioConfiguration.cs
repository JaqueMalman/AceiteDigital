using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AceiteDigital.Data.Mapping
{
    public class SignatarioConfiguration : IEntityTypeConfiguration<Signatario>
    {
        public void Configure(EntityTypeBuilder<Signatario> builder)
        {
            builder.ToTable("Signatario");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasMaxLength(320);

            builder.Property(p => p.Cpf)
                .IsRequired()
                .HasColumnName("Cpf")
                .HasMaxLength(11);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(200);
        }
    }
}
