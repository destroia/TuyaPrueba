using EntityResponse;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public static class ContainerModelBuilder
    {
        public static ModelBuilder AddModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerResponse>(entity => { entity.HasNoKey(); });
            modelBuilder.Entity<OrderResponse>(entity => { entity.HasNoKey(); });

            return modelBuilder;
        }
    }
}
