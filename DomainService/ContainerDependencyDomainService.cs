using Microsoft.Extensions.DependencyInjection;
using static DomainService.Resource;
using RepositoryImplementation;
using Microsoft.Extensions.Configuration;

namespace DomainService
{
    public static class ContainerDependencyDomainService
    {
        public static IServiceCollection AddDomainService(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddRepositoryImplementation(Configuration);
            services.AddScoped<IResource, Resource>();

            return services;
        }
    }
}
