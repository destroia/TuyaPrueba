using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public static class ContainerModelBuilder
    {
        public static ModelBuilder AddModelBuilder(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PaisData>(entity => { entity.HasNoKey(); });

            return modelBuilder;
        }
    }
}
