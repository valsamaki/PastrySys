using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

namespace DAL.EF
{
    public class FabricContext : DbContext
    {
        public DbSet<Fabric> fabrics { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Plan> plans { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Gathering> gatherings { get; set; }

        public FabricContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}