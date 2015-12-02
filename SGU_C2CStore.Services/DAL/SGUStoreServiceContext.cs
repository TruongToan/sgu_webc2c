
using Microsoft.AspNet.Identity.EntityFramework;
using SGU_C2CStore.Services.Models;
using System.Data.Entity;

namespace SGU_C2CStore.Services.DAL
{
    public class SGUStoreServiceContext : DbContext
    {
        public SGUStoreServiceContext() : base("name=SGU_C2CStoreContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public static SGUStoreServiceContext Create()
        {
            return new SGUStoreServiceContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // IMPORTANT
            modelBuilder.Entity<ApplicationUser>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Category>().HasKey(e => e.Id);
            modelBuilder.Entity<Comment>().HasKey(e => e.Id);
            modelBuilder.Entity<Order>().HasKey(e => e.Id);
            modelBuilder.Entity<OrderDetail>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>().HasMany(e => e.Comments).WithRequired().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<Category>().HasMany(e => e.Products).WithRequired().HasForeignKey(e => e.CategoryId);

            // IMPORTANT
            modelBuilder.Entity<IdentityUserLogin>().HasKey(e => e.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(e => e.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<Product>().HasRequired(e => e.Category).WithMany().HasForeignKey(e => e.CategoryId);
            modelBuilder.Entity<Order>().HasMany(e => e.OrderDetails).WithRequired().HasForeignKey(e => e.OrderId);
            modelBuilder.Entity<OrderDetail>().HasRequired(e => e.Product).WithMany().HasForeignKey(e => e.ProductId);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.Orders).WithRequired().HasForeignKey(e => e.BuyerId);
            modelBuilder.Entity<ApplicationUser>().HasMany(e => e.OwnProducts).WithRequired().HasForeignKey(e => e.OwnerId).WillCascadeOnDelete(false);

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
    }
}
