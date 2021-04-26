using Application.Interfaces;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer {
    public static class ServiceInjector {
        
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString) {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(connectionString, builder => {
                    builder.MigrationsHistoryTable("_EFMigrationsHistory", "App");
                });
            });

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IUserRepository, SqlUserRepository>();
            
            return services;
        }
    }
}