using DominioService;

namespace Api
{
    public static class DependencyContainerApi
    {
        public static IServiceCollection AddDependencyContainerApi(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDominioService(Configuration);
            return services;
        }
    }
}
