using AceiteDigital.Data.Mapping;
using AceiteDigitalApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AceiteDigital.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opcoes)
            : base(opcoes)
        {

        }

        public ApplicationDbContext()
        {
        }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Assinatura> Assinaturas { get; set; }

        public DbSet<Signatario> Signatarios { get; set; }

        public DbSet<DocumentoSignatario> DocumentosSignatarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Documento>(new DocumentoConfiguration().Configure);
            modelBuilder.Entity<Evento>(new EventoConfiguration().Configure);
            modelBuilder.Entity<Assinatura>(new AssinaturaConfiguration().Configure);
            modelBuilder.Entity<Signatario>(new SignatarioConfiguration().Configure);
            modelBuilder.Entity<DocumentoSignatario>(new DocumentoSignatarioConfiguration().Configure);


        }

    }
}
