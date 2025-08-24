using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }
        public DbSet<Arrival> Arrivals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
            modelBuilder.Entity<Resource>(entity =>
            {
                // Уникальный индекс по имени
                entity.HasIndex(r => r.Name).IsUnique();

                // Все текстовые поля как nvarchar
                entity.Property(r => r.Name).HasColumnType("nvarchar(200)");
                entity.Property(r => r.State).HasColumnType("nvarchar(50)");

                // Связь с UnitOfMeasurement
                entity.HasOne(r => r.UnitOfMeasurement)
                      .WithMany(u => u.Resources)
                      .HasForeignKey(r => r.UnitOfMeasurementId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            
            modelBuilder.Entity<UnitOfMeasurement>(entity =>
            {
                entity.HasIndex(u => u.Name).IsUnique();

                entity.Property(u => u.Name).HasColumnType("nvarchar(200)");
                entity.Property(u => u.Abbreviation).HasColumnType("nvarchar(50)");
            });

            
            modelBuilder.Entity<Arrival>(entity =>
            {
                // Связь с Resource
                entity.HasOne(a => a.Resource)
                      .WithMany(r => r.Arrivals)
                      .HasForeignKey(a => a.ResourceId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Настройка decimal поля Quantity
                entity.Property(a => a.Quantity).HasPrecision(18, 4);
            });
        }

    }
}
