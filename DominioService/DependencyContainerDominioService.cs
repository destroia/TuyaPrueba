using DomainService;
using DominioService.Customer;
using DominioService.Order;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static DomainService.Resource;

namespace DominioService
{
    public static class DependencyContainerDominioService
    {
        public static IServiceCollection AddDominioService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDomainService(Configuration);
            services.AddScoped<IDCustomer, DCustomer>();
            services.AddScoped<IDOrder, DOrder>();

            return services;
        }
    }
}
