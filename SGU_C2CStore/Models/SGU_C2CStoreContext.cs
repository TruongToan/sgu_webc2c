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
            modelBuilder.Entity<Product>().HasMany(e => e.Photos).WithRequired().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<Product>().HasRequired(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            modelBuilder.Entity<Product>().HasMany(e => e.Comments).WithRequired().HasForeignKey(e => e.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Photo> Photos { get; set; }
    }
}
