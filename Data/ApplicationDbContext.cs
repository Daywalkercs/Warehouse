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

            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<UnitOfMeasurement>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Arrival>()
                .HasOne(a => a.Resource)
                .WithMany(r => r.Arrivals)
                .HasForeignKey(a => a.ResourceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
