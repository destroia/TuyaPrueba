﻿using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class AppDbContext  : DbContext
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
