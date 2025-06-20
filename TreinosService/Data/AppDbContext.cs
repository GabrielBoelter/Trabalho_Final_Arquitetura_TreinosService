using Microsoft.EntityFrameworkCore;
using TreinosService.Models;

namespace TreinosService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Treino> Treinos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treino>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Objetivo).IsRequired().HasMaxLength(500);
                entity.Property(e => e.DataCriacao).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}