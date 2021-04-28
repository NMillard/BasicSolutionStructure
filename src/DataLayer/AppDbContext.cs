using DataLayer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace DataLayer {
    internal class AppDbContext : DbContext {

        // Important to have constructor that takes DbContextOptions
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<DomainUserPersistence> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasDefaultSchema("App");
        }
    }
}