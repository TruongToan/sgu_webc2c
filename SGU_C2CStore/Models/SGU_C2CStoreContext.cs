using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGU_C2CStore.Models
{
    public class SGU_C2CStoreContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        /* In your model a User entity has many Histories with each history having a required User and the relationship has a foreign key called UserId:

        modelBuilder.Entity<User>()
           .HasMany(u => u.Histories)
           .WithRequired()
           .HasForeignKey(h => h.UserId);
        (The relationship must be required(not optional) because the foreign key property UserId is not nullable.) */

        public SGU_C2CStoreContext() : base("name=SGU_C2CStoreContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // IMPORTANT
            modelBuilder.Entity<IdentityUserLogin>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(e => e.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(e => new { e.RoleId, e.UserId });
            modelBuilder.Entity<ApplicationUser>().HasKey(e => e.Id);

            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Comment>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().HasKey(e => e.Id);
            modelBuilder.Entity<OrderDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<Photo>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().HasMany(e => e.Photos).WithRequired().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<Product>().HasMany(e => e.Comments).WithRequired().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<Category>().HasMany(e => e.Products).WithRequired().HasForeignKey(e => e.CategoryId);

            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails).WithRequired().HasForeignKey(e => e.OrderId);
            modelBuilder.Entity<OrderDetail>().HasRequired(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Orders).WithRequired().HasForeignKey(e => e.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Product).WithRequired().HasForeignKey(e => e.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AutionProduct> AutionProducts { get; set; }
        public DbSet<AutionByPriceProduct> AutionByPriceProducts { get; set; }
        public DbSet<AutionByTimeProduct> AutionByTimeProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
