
using SGU_C2CStore.Service.Models;
using System.Data.Entity;

namespace SGU_C2CStore.Service.DAL
{
    public class SGUStoreServiceContext : DbContext
    {
        public SGUStoreServiceContext() : base("name=SGU_C2CStoreContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // IMPORTANT
            modelBuilder.Entity<User>().HasKey(e => e.Id);
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
            modelBuilder.Entity<User>().HasMany(e => e.Orders).WithRequired().HasForeignKey(e => e.UserId);
            modelBuilder.Entity<User>().HasMany(e => e.Product).WithRequired().HasForeignKey(e => e.UserId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AutionProduct> AutionProducts { get; set; }
        public DbSet<AutionByPriceProduct> AutionByPriceProducts { get; set; }
        public DbSet<AutionByTimeProduct> AutionByTimeProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
