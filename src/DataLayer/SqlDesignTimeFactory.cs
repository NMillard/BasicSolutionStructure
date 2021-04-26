using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataLayer {
    internal class SqlDesignTimeFactory : IDesignTimeDbContextFactory<AppDbContext> {
        
        public AppDbContext CreateDbContext(string[] args) {
            IConfiguration config = new ConfigurationBuilder()
                .AddUserSecrets<SqlDesignTimeFactory>()
                .Build();

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder()
                .UseSqlServer(config.GetConnectionString("sql"), optionsBuilder => {
                    optionsBuilder.MigrationsHistoryTable("_EFMigrationsHistory", "App");
                });

            return new AppDbContext(builder.Options);
        }
    }
}