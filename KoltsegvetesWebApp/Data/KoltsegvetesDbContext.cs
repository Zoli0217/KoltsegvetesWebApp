using KoltsegvetesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace KoltsegvetesWebApp.Data
{
    public class KoltsegvetesDbContext : DbContext
    {
        public KoltsegvetesDbContext(DbContextOptions<KoltsegvetesDbContext> options) : base(options)
        {
        }

        public DbSet<Kategoria> Kategoriak { get; set; }
        public DbSet<Tranzakcio> Tranzakciok { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tranzakcio>()
                .HasOne(k => k.Kategoria)
                .WithMany(t => t.Tranzakciok)
                .HasForeignKey(k => k.KategoriaId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
