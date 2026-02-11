using Microsoft.EntityFrameworkCore;
using System.Reflection;
using SystemAdminAPI.Entitties;

namespace SystemAdminAPI.DbContextAdmin
{
    public class AppDbContextAdmin : DbContext
    {
   
        public AppDbContextAdmin(DbContextOptions<AppDbContextAdmin> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Users> Users { get; set; }
    }
}