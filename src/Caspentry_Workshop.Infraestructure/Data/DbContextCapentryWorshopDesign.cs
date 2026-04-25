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
            optionsBuilder.UseNpgsql("Host=aws-1-us-west-2.pooler.supabase.com;Database=postgres;Username=postgres.obcwgoqpwpxgxohlzdhs;Password=*;SSL Mode=Require;Trust Server Certificate=true");
            return new AppCarpentry(optionsBuilder.Options);
        }
    }
}
