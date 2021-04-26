using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace EmailSender {
    public static class ServiceInjector {
        public static IServiceCollection AddEmailSender(this IServiceCollection services) {
            services.AddScoped<IEmailSender, FakeEmailSender>();
            
            return services;
        }
    }
}