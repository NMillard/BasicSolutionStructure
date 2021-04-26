using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application {
    public static class ServiceInjector {
        public static IServiceCollection AddApplicationEvents(this IServiceCollection services) {
            services.AddMediatR(typeof(ServiceInjector).Assembly);
            
            

            return services;
        }
    }
}