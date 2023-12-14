using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataBase;

namespace RepositoryImplementation
{
    public static class DependencyContainerRepositoryImplementation
    {

        public static IServiceCollection AddRepositoryImplementation(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDataDependency(Configuration);
            services.AddScoped<IRepository, Repository>();
   
            return services;
        }
    }
}
