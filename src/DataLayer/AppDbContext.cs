using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataLayer {
    internal class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            modelBuilder.HasDefaultSchema("App");
        }
    }
}