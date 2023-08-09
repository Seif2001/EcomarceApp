using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infastructure.Migrations.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var enityType in modelBuilder.Model.GetEntityTypes())
                {
                   var propeties = enityType.ClrType.GetProperties().Where(p=>p.PropertyType==typeof(decimal));

                    foreach (var property in propeties)
                    {
                        modelBuilder.Entity(enityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }
        }
    }
}
