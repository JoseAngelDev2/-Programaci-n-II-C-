using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using AppCarpentry = Caspentry_Workshop.Infraestructure.Data.DbContextCapentryWorkshop;
namespace Caspentry_Workshop.Infraestructure.Data
{
    public class DbContextCapentryWorshopDesign : IDesignTimeDbContextFactory<AppCarpentry> 
    {
          public AppCarpentry CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppCarpentry>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CapentryDb;Trusted_Connection=True;TrustServerCertificate=True");
            return new AppCarpentry(optionsBuilder.Options);
        }
    }
}