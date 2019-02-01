using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CommerceApp.Models.DbFirst.Models
{
    public partial class MyShopContext : DbContext
    {
        public MyShopContext()
        {
        }

        public MyShopContext(DbContextOptions<MyShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<ProductStock> ProductStock { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=.;initial catalog=MyShop3;integrated security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(product => {
                product.Property(p => p.Name)
                .HasMaxLength(20)
                .IsRequired().HasColumnName("ProductName")
                .HasDefaultValue("Machine");
                product.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CID);
                // relation with attributes
                product
                .HasOne(p => p.ProductAtrribute)
                .WithOne(a => a.Product)
                .OnDelete(DeleteBehavior.Cascade);

                // relation with stock
                
            });
            modelBuilder.Ignore<Products>();
            modelBuilder.Entity<ProductStock>(ps => {

                //composite key to an entity
                ps.HasKey(s => new { s.ProductId, s.StockId });
                ps.HasOne(p => p.Product).WithMany(p =>p.Stores);
                ps.HasOne(p => p.Stock).WithMany(p => p.Products);

            });
        }
    }
}
