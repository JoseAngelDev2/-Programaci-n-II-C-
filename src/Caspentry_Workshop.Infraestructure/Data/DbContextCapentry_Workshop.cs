using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caspentry_Workshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Caspentry_Workshop.Infraestructure.Data
{
    public class DbContextCapentryWorkshop : DbContext
    {
        public DbContextCapentryWorkshop(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<CarpinterModel> Carpinters { get; set; }
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<DeliveryModel> Deliveries { get; set; }

    }
}