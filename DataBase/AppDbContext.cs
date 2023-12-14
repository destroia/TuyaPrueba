using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddModelBuilder();
        }
    }
}
