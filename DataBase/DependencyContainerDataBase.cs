using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataBase
{
    public static class DependencyContainerDataBase
    {
        public static IServiceCollection AddDataDependency(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("ConnectionMain")));
            services.AddLocalization(options => options.ResourcesPath = "Resource");
            return services;
        }
    }
}
