using Microsoft.EntityFrameworkCore;
using Warehouse.Models;

namespace Warehouse.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

        public DbSet<Resource> Resources => Set<Resource>();
        public DbSet<UnitOfMeasurement> Units => Set<UnitOfMeasurement>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Resource>()
                .HasIndex(r => r.Name)
                .IsUnique();

            modelBuilder.Entity<UnitOfMeasurement>()
                .HasIndex(u => u.Name)
                .IsUnique();
        }
    }
}
