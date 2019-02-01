using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Models
{
    // entry point to the database
    public class CommerceDbContext:DbContext
    {
        public CommerceDbContext(DbContextOptions options) : base(options)
        {

        }
        public CommerceDbContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if(!options.IsConfigured)
            {
                options.UseSqlServer("data source=.;initial catalog=MyShop;integrated security=true");

            }
        }
        // DbSets are mapped to tables in the database
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
