
using ApiIntro.Core.Entities;
using ApiIntro.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ApiIntro.Data.Context
{
    public class ApiIntroDbContext:DbContext
    {
        public ApiIntroDbContext(DbContextOptions<ApiIntroDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        
    }
}
