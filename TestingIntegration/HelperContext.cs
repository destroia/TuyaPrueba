using DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingIntegration
{
    public class HelperContext
    {
        public static IServiceProvider CreateContext()
        {
            var service = new ServiceCollection();
            service.AddDbContext<AppDbContext>(opts => opts.UseSqlServer("Data Source=DESKTOP-1FTS7RK\\SQLEXPRESS;Initial Catalog=Tuya;Integrated Security=true;TrustServerCertificate=True"));
            return service.BuildServiceProvider();
        }
    }
}
