using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UserCRUDAPIs.Entities;


namespace UserCRUDAPIs.Data.DbContextProduct
{
    public class AppDbContextProduct : DbContext
    {
        public AppDbContextProduct(DbContextOptions<AppDbContextProduct> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Products> products {get; set;}
    }
}