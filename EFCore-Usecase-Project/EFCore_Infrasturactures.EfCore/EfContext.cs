using EFCore.Domain.ProductAgg;
using EFCore.Domain.ProductCategoryAgg;
using EFCore_Infrasturactures.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Infrasturactures.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        public EfContext(DbContextOptions<EfContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assembly = typeof(ProductMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
